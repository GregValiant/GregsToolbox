Imports System.ComponentModel
Public Class DebugForm
    Public NoExtrude As Boolean = False
    Public InAir As Boolean = False

    Private Sub CloseBut_Click(sender As Object, e As EventArgs) Handles CloseBut.Click
        On Error Resume Next
        GCODE_File_R.Close()
        Me.Hide()
    End Sub

    Private Sub StartBut_Click(sender As Object, e As EventArgs) Handles StartBut.Click
        On Error GoTo TheHandler
        If Me.DebugLineBox.Text = "" Then
            MsgBox("There has to be a line number to search for.  The command will stop.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim FileResponse1 As DialogResult
        Dim FileResponse As String
        Dim ImportFileName As String
        If Me.DebugFileNameBox.Text <> "" Then
            FileResponse = Me.DebugFileNameBox.Text
            GoTo JumpStart
        End If
        EnderMainForm.OpenFileDialog1.Title = "Open a GCODE file to Debug"
        EnderMainForm.OpenFileDialog1.Filter = "GCODE Files|*.gcode"
        EnderMainForm.OpenFileDialog1.FilterIndex = 1
        EnderMainForm.OpenFileDialog1.DefaultExt = "gcode"
        EnderMainForm.OpenFileDialog1.FileName = ""
        FileResponse1 = EnderMainForm.OpenFileDialog1.ShowDialog()
        If FileResponse1 = 2 Then
            Exit Sub
        End If
        FileResponse = EnderMainForm.OpenFileDialog1.FileName
JumpStart:
        Cursor.Current = Cursors.WaitCursor
        If Me.DebugFileNameBox.Text = "" Then Me.DebugFileNameBox.Text = FileResponse
        ImportFileName = FileResponse
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim Counter As Long
        Dim LineCount As Double
        Dim DataLine As String
        Dim MyLine As String
        Counter = 0
        LineCount = 0
        MyLine = Me.DebugLineBox.Text
        Do While GCODE_File_R.EndOfStream <> True And LineCount < CLng(MyLine) + 4
            DataLine = GCODE_File_R.ReadLine
            DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
            LineCount += 1
            Counter = Counter + Len(DataLine) + 2
            If LineCount = CLng(MyLine) - 4 Then
                Me.LabelMinus4L.Text = CStr(LineCount)
                Me.LabelMinus4.Text = DataLine
            ElseIf LineCount = CLng(MyLine) - 3 Then
                Me.LabelMinus3L.Text = CStr(LineCount)
                Me.LabelMinus3.Text = DataLine
            ElseIf LineCount = CLng(MyLine) - 2 Then
                Me.LabelMinus2L.Text = CStr(LineCount)
                Me.LabelMinus2.Text = DataLine
            ElseIf LineCount = CLng(MyLine) - 1 Then
                Me.LabelMinus1L.Text = CStr(LineCount)
                Me.LabelMinus1.Text = DataLine
            ElseIf LineCount = CLng(MyLine) Then
                Me.LabelCurrent.Text = MyLine
                Me.DebugCurrentLineBox.Text = DataLine
            ElseIf LineCount = CLng(MyLine) + 1 Then
                Me.LabelPlus1L.Text = CStr(LineCount)
                Me.LabelPlus1.Text = DataLine
            ElseIf LineCount = CLng(MyLine) + 2 Then
                Me.LabelPlus2L.Text = CStr(LineCount)
                Me.LabelPlus2.Text = DataLine
            ElseIf LineCount = CLng(MyLine) + 3 Then
                Me.LabelPlus3L.Text = CStr(LineCount)
                Me.LabelPlus3.Text = DataLine
            ElseIf LineCount = CLng(MyLine) + 4 Then
                Me.LabelPlus4L.Text = CStr(LineCount)
                Me.LabelPlus4.Text = DataLine
            End If
        Loop
        Cursor.Current = Cursors.Default
        Exit Sub
TheHandler:
        Cursor.Current = Cursors.Default
        MsgBox("An error occurred in ""DebugForm.StartBut_Click""." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub SendBut_Click(sender As Object, e As EventArgs) Handles SendBut.Click
        On Error Resume Next
        If Not EnderMainForm.Vcomm.IsOpen Then
            MsgBox("The port is closed.", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If

        Dim endStr = ""
        If Not NoExtrude Then
            StrToSend = Me.DebugCurrentLineBox.Text
        Else
            Dim ThereisExtrude = InStr(Me.DebugCurrentLineBox.Text, " E")
            If ThereisExtrude > 0 Then
                Dim Estr = Strings.Right(Me.DebugCurrentLineBox.Text, Len(Me.DebugCurrentLineBox.Text) - ThereisExtrude)
                Dim spaceStr = InStr(Estr, " ")
                If spaceStr > 0 Then
                    endStr = Strings.Right(Estr, Len(Estr) - spaceStr)
                End If
                Dim RemLine = Strings.Left(Me.DebugCurrentLineBox.Text, ThereisExtrude - 1)

                StrToSend = RemLine & " " & endStr
            Else
                StrToSend = Me.DebugCurrentLineBox.Text
            End If
        End If
        If InAir Then
            Dim Zstr = InStr(StrToSend, " Z")
            If Zstr > 0 Then
                Dim PreStr = Strings.Left(StrToSend, Zstr - 1)
                endStr = Strings.Right(StrToSend, Len(StrToSend) - Zstr)
                Dim Zspace = InStr(endStr, " ")
                If Zspace > 0 Then
                    endStr = " " & Strings.Right(endStr, Len(endStr) - Zspace)
                Else
                    endStr = ""
                End If
                StrToSend = PreStr & endStr
            End If
        End If
        SendTheString(StrToSend)
        With Me
            .LabelMinus4L.Text = .LabelMinus3L.Text
            .LabelMinus4.Text = .LabelMinus3.Text
            .LabelMinus3L.Text = .LabelMinus2L.Text
            .LabelMinus3.Text = .LabelMinus2.Text
            .LabelMinus2L.Text = .LabelMinus1L.Text
            .LabelMinus2.Text = .LabelMinus1.Text
            .LabelMinus1L.Text = .LabelCurrent.Text
            .LabelMinus1.Text = .DebugCurrentLineBox.Text
            .DebugCurrentLineBox.Text = .LabelPlus1.Text
            .LabelCurrent.Text = .LabelPlus1L.Text
            .LabelPlus1.Text = .LabelPlus2.Text
            .LabelPlus1L.Text = .LabelPlus2L.Text
            .LabelPlus2.Text = .LabelPlus3.Text
            .LabelPlus2L.Text = .LabelPlus3L.Text
            .LabelPlus3.Text = .LabelPlus4.Text
            .LabelPlus3L.Text = .LabelPlus4L.Text
            .LabelPlus4.Text = GCODE_File_R.ReadLine
            .LabelPlus4L.Text = CStr(CLng(.LabelPlus3L.Text) + 1)
        End With
    End Sub

    Private Sub SkipBut_Click(sender As Object, e As EventArgs) Handles SkipBut.Click
        On Error Resume Next
        With Me
            .LabelMinus4L.Text = .LabelMinus3L.Text
            .LabelMinus4.Text = .LabelMinus3.Text
            .LabelMinus3L.Text = .LabelMinus2L.Text
            .LabelMinus3.Text = .LabelMinus2.Text
            .LabelMinus2L.Text = .LabelMinus1L.Text
            .LabelMinus2.Text = .LabelMinus1.Text
            .LabelMinus1L.Text = .LabelCurrent.Text
            .LabelMinus1.Text = .DebugCurrentLineBox.Text
            .DebugCurrentLineBox.Text = .LabelPlus1.Text
            .LabelCurrent.Text = .LabelPlus1L.Text
            .LabelPlus1.Text = .LabelPlus2.Text
            .LabelPlus1L.Text = .LabelPlus2L.Text
            .LabelPlus2.Text = .LabelPlus3.Text
            .LabelPlus2L.Text = .LabelPlus3L.Text
            .LabelPlus3.Text = .LabelPlus4.Text
            .LabelPlus3L.Text = .LabelPlus4L.Text
            .LabelPlus4.Text = GCODE_File_R.ReadLine
            .LabelPlus4L.Text = CStr(CLng(.LabelPlus3L.Text) + 1)
        End With
    End Sub

    Private Sub KillExtrudeChk_CheckedChanged(sender As Object, e As EventArgs) Handles KillExtrudeChk.CheckedChanged
        NoExtrude = Me.KillExtrudeChk.Checked
        If Me.KillExtrudeChk.Checked Then
            Me.KillExtrudeChk.Text = "Ignore Extrusion"
            Me.WarningLabel.Visible = False
        Else
            Me.KillExtrudeChk.Text = "Extrude"
            Me.WarningLabel.Visible = True
        End If
    End Sub

    Private Sub AirPrintChk_CheckedChanged(sender As Object, e As EventArgs) Handles AirPrintChk.CheckedChanged
        InAir = Me.AirPrintChk.Checked
        If Me.AirPrintChk.Checked Then
            SendTheString("G91")
            SendTheString("G0 Z10")
            SendTheString("G90")
        End If
    End Sub

    Private Sub DebugForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Call CloseBut_Click(sender, e)
    End Sub

    Private Sub HideWarningBut_Click(sender As Object, e As EventArgs) Handles HideWarningBut.Click
        Me.WarningLabel.Visible = False
    End Sub

    Private Sub InsertCmdBut_Click(sender As Object, e As EventArgs) Handles InsertCmdBut.Click
        StrToSend = UCase(InputBox("Insert a Gcode Command Line (NOTE: All commands are converted to Upper Case)", "Insert Line", "M117 Hello"))
        If StrToSend = "" Then Exit Sub
        SendTheString(StrToSend)
        With Me
            .LabelMinus4L.Text = .LabelMinus3L.Text
            .LabelMinus4.Text = .LabelMinus3.Text
            .LabelMinus3L.Text = .LabelMinus2L.Text
            .LabelMinus3.Text = .LabelMinus2.Text
            .LabelMinus2L.Text = .LabelMinus1L.Text
            .LabelMinus2.Text = .LabelMinus1.Text
            .LabelMinus1L.Text = "---"
            .LabelMinus1.Text = StrToSend
        End With
    End Sub

    Private Sub RunGcodeBut_CheckedChanged(sender As Object, e As EventArgs) Handles RunGcodeBut.CheckedChanged
        With Me.RunGcodeBut
            If .Checked Then
                .BackColor = Color.GreenYellow
                .Text = "Stop"
            Else
                .BackColor = Color.LightSteelBlue
                .Text = "Run"
            End If
            Do While .Checked = True
                Call SendBut_Click(sender, e)
                Threading.Thread.Sleep(200)
                Application.DoEvents()
            Loop
        End With
    End Sub
End Class