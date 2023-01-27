Public Class InsertAtLayerChange
    Public MyResponse As Boolean

    Private Sub Layer0Opt_CheckedChanged(sender As Object, e As EventArgs) Handles Layer0Opt.CheckedChanged
        With Me
            If .Layer0Opt.Checked Then
                .LayerStartBox.Enabled = False
                .LayerStartBox.Text = "0"
            Else
                .LayerStartBox.Enabled = True
            End If
        End With
    End Sub

    Private Sub GoBut_Click(sender As Object, e As EventArgs) Handles GoBut.Click
        With Me
            If Val(.LayerStartBox.Text) < 0 Or .LayerStartBox.Text = "" Then
                MsgBox("The Start Layer must be 0 or greater.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If .CommandBox.Text = "" Then
                MsgBox("You must enter at least one gcode command.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
        End With
        MyResponse = True
        Me.Hide()
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        MyResponse = False
        Me.Hide()
    End Sub

    Public Sub InsertAtLayerChangeSub()
        Dim Originalgcodefile As System.IO.StreamReader
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim GcodeCommands() As String
        Dim Freq As Integer = 1
        Dim StartLay As String = "0"
        Dim CurLayer As String = ""
        Me.ShowDialog()
        If MyResponse = False Then Exit Sub
        With Me
            If .L1opt.Checked = True Then
                Freq = 1
            ElseIf .L2opt.Checked = True Then
                Freq = 2
            ElseIf .L3opt.Checked = True Then
                Freq = 3
            ElseIf .L50opt.Checked = True Then
                Freq = 5
            ElseIf .L10opt.Checked = True Then
                Freq = 10
            ElseIf .L25opt.Checked = True Then
                Freq = 25
            ElseIf .L50opt.Checked = True Then
                Freq = 50
            ElseIf .L100opt.Checked = True Then
                Freq = 100
            End If
            If .Layer0Opt.Checked = True Then
                StartLay = "0"
            ElseIf .LayerOtherOpt.Checked = True Then
                StartLay = .LayerStartBox.Text
            End If
            GcodeCommands = Strings.Split(.CommandBox.Text, vbNewLine)
        End With
        With EnderMainForm.OpenFileDialog1
            .Title = "Open a GCODE File"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            .FileName = "*.gcode"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then 'Use Save File dialog to create a new text file the a specified name *.gcode.
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                Originalgcodefile = My.Computer.FileSystem.OpenTextFileReader(.FileName)
            Else
                Exit Sub
            End If
        End With
        With EnderMainForm.SaveFileDialog1
            .Title = "Create the New File"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            Dim ShortName As String = EnderMainForm.OpenFileDialog1.FileName
            Dim SlashLoc As Integer = 0
            Do Until InStr(ShortName, "\") = 0
                SlashLoc = InStr(ShortName, "\")
                ShortName = Strings.Right(ShortName, Len(ShortName) - SlashLoc)
            Loop
            ShortName = Strings.Left(ShortName, Len(ShortName) - 6)
            .FileName = ShortName & "_Inserts.gcode"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then 'Use Save File dialog to create a new text file the a specified name *.gcode.
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                Try
                    If System.IO.File.Exists(.FileName) Then
                        System.IO.File.Delete(.FileName)
                    End If
                Catch
                End Try
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.FileName, True)
            Else
                Originalgcodefile.Close()
                Exit Sub
            End If
        End With
        Originalgcodefile = My.Computer.FileSystem.OpenTextFileReader(EnderMainForm.OpenFileDialog1.FileName)
        Dim Dataline As String = ""
        Dataline = Originalgcodefile.ReadLine
        Try
            Do Until InStr(Dataline, "LAYER:0") > 0
                If InStr(Dataline, "generated with") > 0 Then
                    NewGcodeFile.WriteLine(";      POSTPROCESSED Greg's Toolbox (Insert at Layer Change)")
                End If
                NewGcodeFile.WriteLine(Dataline)
                Dataline = Originalgcodefile.ReadLine
            Loop
            NewGcodeFile.WriteLine(Dataline)
            Dataline = Originalgcodefile.ReadLine
            Do Until InStr(Dataline, ";LAYER:" & StartLay) > 0
                NewGcodeFile.WriteLine(Dataline)
                Dataline = Originalgcodefile.ReadLine
            Loop
            Do Until Originalgcodefile.EndOfStream = True Or InStr(Dataline, ";End of Gcode") > 0
                If InStr(Dataline, ";LAYER:") > 0 Then
                    CurLayer = Strings.Right(Dataline, Len(Dataline) - 7)
                    If (Val(CurLayer) / Freq) - Int((Val(CurLayer) / Freq)) = 0 Then
                        For Each MCode In GcodeCommands
                            NewGcodeFile.WriteLine(MCode)
                        Next
                    End If
                End If
                NewGcodeFile.WriteLine(Dataline)
                Dataline = Originalgcodefile.ReadLine
            Loop
        Catch
        End Try
        Originalgcodefile.Close()
        NewGcodeFile.Close()
        Dim AResponse As MsgBoxResult = MsgBox("The file is complete.  Do you want to open it in NotePad?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim MyGcodeFile As String = EnderMainForm.SaveFileDialog1.FileName
        If IsRunningExe("notepad.exe") Then
            Do Until InStr(1, MyGcodeFile, "\") = 0
                MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
            Loop
            AppActivate(MyGcodeFile & " - Notepad")
            If Err.Number <> 0 Then
                System.Diagnostics.Process.Start("notepad.exe", MyGcodeFile)
                Err.Clear()
            End If
            Exit Sub
        End If
        System.Diagnostics.Process.Start("notepad.exe", MyGcodeFile)
    End Sub

End Class