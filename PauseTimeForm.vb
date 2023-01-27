Imports System.ComponentModel

Public Class PauseTimeForm
    Private Sub GetTimesBut_Click(sender As Object, e As EventArgs) Handles GetTimesBut.Click
        On Error Resume Next
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim ImportFileName = FirstFile
        Call GetTheTimes(ImportFileName)
    End Sub

    Public Sub GetTheTimes(ImportFileName As String)
        On Error GoTo Ehandler
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim TopLayer As Integer
        Dim Dataline As String
        Dim PrintTime = 0
        Dim PrintStartLocal As String
        Dim Start = False
        Dim LineCount = 0
        Do Until Start = True
            Dataline = GCODE_File_R.ReadLine
            LineCount += 1
            If InStr(Dataline, ";LAYER_COUNT:") > 0 Then
                TopLayer = CInt(Strings.Right(Dataline, Len(Dataline) - 13))
            End If
            If InStr(Dataline, "layer:0") > 0 Then Start = True
            If InStr(Dataline, ";Time:") > 0 Then
                PrintTime = CInt(Strings.Right(Dataline, Len(Dataline) - 6))
            End If
        Loop
        Dim ElapsedTime = 0
        Dim LayerArray() As String
        ReDim LayerArray(9)
        Dim ReasonArray() As String
        ReDim ReasonArray(9)
        Dim TimeElapsedArray() As String
        ReDim TimeElapsedArray(9)
        With Me
            If .Lay1A.Text <> "" Then
                LayerArray(0) = .Lay1A.Text
                ReasonArray(0) = .Lay1D.Text
            Else
                LayerArray(0) = Nothing
                ReasonArray(0) = Nothing
            End If
            If .Lay2A.Text <> "" Then
                LayerArray(1) = .Lay2A.Text
                ReasonArray(1) = .Lay2D.Text
            Else
                LayerArray(1) = Nothing
                ReasonArray(1) = Nothing
            End If
            If .Lay3A.Text <> "" Then
                LayerArray(2) = .Lay3A.Text
                ReasonArray(2) = .Lay3D.Text
            Else
                LayerArray(2) = Nothing
                ReasonArray(2) = Nothing
            End If
            If .Lay4A.Text <> "" Then
                LayerArray(3) = .Lay4A.Text
                ReasonArray(3) = .Lay4D.Text
            Else
                LayerArray(3) = Nothing
                ReasonArray(3) = Nothing
            End If
            If .Lay5A.Text <> "" Then
                LayerArray(4) = .Lay5A.Text
                ReasonArray(4) = .Lay5D.Text
            Else
                LayerArray(4) = Nothing
                ReasonArray(4) = Nothing
            End If
            If .Lay6A.Text <> "" Then
                LayerArray(5) = .Lay6A.Text
                ReasonArray(5) = .Lay6D.Text
            Else
                LayerArray(5) = Nothing
                ReasonArray(5) = Nothing
            End If
            If .Lay7A.Text <> "" Then
                LayerArray(6) = .Lay7A.Text
                ReasonArray(6) = .Lay7D.Text
            Else
                LayerArray(6) = Nothing
                ReasonArray(6) = Nothing
            End If
            If .Lay8A.Text <> "" Then
                LayerArray(7) = .Lay8A.Text
                ReasonArray(7) = .Lay8D.Text
            Else
                LayerArray(7) = Nothing
                ReasonArray(7) = Nothing
            End If
            If .Lay9A.Text <> "" Then
                LayerArray(8) = .Lay9A.Text
                ReasonArray(8) = .Lay9D.Text
            Else
                LayerArray(8) = Nothing
                ReasonArray(8) = Nothing
            End If
            If .Lay10A.Text <> "" Then
                LayerArray(9) = .Lay10A.Text
                ReasonArray(9) = .Lay10D.Text
            Else
                LayerArray(9) = Nothing
                ReasonArray(9) = Nothing
            End If
        End With

        GCODE_File_R.Close()
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim SearchString = ""
        Dim LayerCount As Integer
        LayerCount = 0
        Do Until GCODE_File_R.EndOfStream = True
            SearchString = ";LAYER:" & LayerArray(LayerCount)
            If SearchString = ";LAYER:" Then Exit Do
            Dataline = GCODE_File_R.ReadLine
            If InStr(Dataline, ";TIME_ELAPSED:") <> 0 Then
                ElapsedTime = CInt(Strings.Right(Dataline, Len(Dataline) - 14))
            End If
            If InStr(Dataline, SearchString) > 0 Then
                TimeElapsedArray(LayerCount) = CStr(ElapsedTime)
                LayerCount += 1
                If LayerCount = 10 Then Exit Do
            End If
        Loop
        If GCODE_File_R.EndOfStream = True Then
            MsgBox("The end of the file was reached without finding (at least) one of the layers" & vbCr & "The command will continue", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        End If
        Dim Q As Integer
        For Q = 0 To 9 Step 1
            If LayerArray(Q) = "" Then
                TimeElapsedArray(Q) = ""
            End If
        Next Q

        PrintStartLocal = Me.Lay0C.Text
        Dim MyFormat = "h:mm tt   M/d"
        With Me
            If LayerArray(0) <> "" Then
                .Lay1B.Text = TimeElapsedArray(0)
                .Lay1C.Text = DateAdd("s", CDbl(TimeElapsedArray(0)), PrintStartLocal).ToString(MyFormat)
                .Lay1D.Text = ReasonArray(0)
            Else
                .Lay1A.Text = ""
                .Lay1B.Text = ""
                .Lay1C.Text = ""
                .Lay1D.Text = ""
                .Lay1E.Text = ""
            End If
            If LayerArray(1) <> "" Then
                .Lay2B.Text = TimeElapsedArray(1)
                .Lay2C.Text = DateAdd("s", CDbl(TimeElapsedArray(1)), PrintStartLocal).ToString(MyFormat)
                .Lay2D.Text = ReasonArray(1)
            Else
                .Lay2A.Text = ""
                .Lay2B.Text = ""
                .Lay2C.Text = ""
                .Lay2D.Text = ""
                .Lay2E.Text = ""
            End If
            If LayerArray(2) <> "" Then
                .Lay3B.Text = TimeElapsedArray(2)
                .Lay3C.Text = DateAdd("s", CDbl(TimeElapsedArray(2)), PrintStartLocal).ToString(MyFormat)
                .Lay3D.Text = ReasonArray(2)
            Else
                .Lay3A.Text = ""
                .Lay3B.Text = ""
                .Lay3C.Text = ""
                .Lay3D.Text = ""
                .Lay3E.Text = ""
            End If
            If LayerArray(3) <> "" Then
                .Lay4B.Text = TimeElapsedArray(3)
                .Lay4C.Text = DateAdd("s", CDbl(TimeElapsedArray(3)), PrintStartLocal).ToString(MyFormat)
                .Lay4D.Text = ReasonArray(3)
            Else
                .Lay4A.Text = ""
                .Lay4B.Text = ""
                .Lay4C.Text = ""
                .Lay4D.Text = ""
                .Lay4E.Text = ""
            End If
            If LayerArray(4) <> "" Then
                .Lay5B.Text = TimeElapsedArray(4)
                .Lay5C.Text = DateAdd("s", CDbl(TimeElapsedArray(4)), PrintStartLocal).ToString(MyFormat)
                .Lay5D.Text = ReasonArray(4)
            Else
                .Lay5A.Text = ""
                .Lay5B.Text = ""
                .Lay5C.Text = ""
                .Lay5D.Text = ""
                .Lay5E.Text = ""
            End If
            If LayerArray(5) <> "" Then
                .Lay6B.Text = TimeElapsedArray(5)
                .Lay6C.Text = DateAdd("s", CDbl(TimeElapsedArray(5)), PrintStartLocal).ToString(MyFormat)
                .Lay6D.Text = ReasonArray(5)
            Else
                .Lay6A.Text = ""
                .Lay6B.Text = ""
                .Lay6C.Text = ""
                .Lay6D.Text = ""
                .Lay6E.Text = ""
            End If
            If LayerArray(6) <> "" Then
                .Lay7B.Text = TimeElapsedArray(6)
                .Lay7C.Text = DateAdd("s", CDbl(TimeElapsedArray(6)), PrintStartLocal).ToString(MyFormat)
                .Lay7D.Text = ReasonArray(6)
            Else
                .Lay7A.Text = ""
                .Lay7B.Text = ""
                .Lay7C.Text = ""
                .Lay7D.Text = ""
                .Lay7E.Text = ""
            End If
            If LayerArray(7) <> "" Then
                .Lay8B.Text = TimeElapsedArray(7)
                .Lay8C.Text = DateAdd("s", CDbl(TimeElapsedArray(7)), PrintStartLocal).ToString(MyFormat)
                .Lay8D.Text = ReasonArray(7)
            Else
                .Lay8A.Text = ""
                .Lay8B.Text = ""
                .Lay8C.Text = ""
                .Lay8D.Text = ""
                .Lay8E.Text = ""
            End If
            If LayerArray(8) <> "" Then
                .Lay9B.Text = TimeElapsedArray(8)
                .Lay9C.Text = DateAdd("s", CDbl(TimeElapsedArray(8)), PrintStartLocal).ToString(MyFormat)
                .Lay9D.Text = ReasonArray(8)
            Else
                .Lay9A.Text = ""
                .Lay9B.Text = ""
                .Lay9C.Text = ""
                .Lay9D.Text = ""
                .Lay9E.Text = ""
            End If
            If LayerArray(9) <> "" Then
                .Lay10B.Text = TimeElapsedArray(9)
                .Lay10C.Text = DateAdd("s", CDbl(TimeElapsedArray(9)), PrintStartLocal).ToString(MyFormat)
                .Lay10D.Text = ReasonArray(9)
            Else
                .Lay10A.Text = ""
                .Lay10B.Text = ""
                .Lay10C.Text = ""
                .Lay10D.Text = ""
                .Lay10E.Text = ""
            End If

            If .Lay10B.Text <> "" Then
                .Lay10E.Text = CStr(ConvertTime(.Lay10B.Text, .Lay9B.Text))
            End If
            If .Lay9B.Text <> "" Then
                .Lay9E.Text = CStr(ConvertTime(.Lay9B.Text, .Lay8B.Text))
            End If
            If .Lay8B.Text <> "" Then
                .Lay8E.Text = CStr(ConvertTime(.Lay8B.Text, .Lay7B.Text))
            End If
            If .Lay7B.Text <> "" Then
                .Lay7E.Text = CStr(ConvertTime(.Lay7B.Text, .Lay6B.Text))
            End If
            If .Lay6B.Text <> "" Then
                .Lay6E.Text = CStr(ConvertTime(.Lay6B.Text, .Lay5B.Text))
            End If
            If .Lay5B.Text <> "" Then
                .Lay5E.Text = CStr(ConvertTime(.Lay5B.Text, .Lay4B.Text))
            End If
            If .Lay4B.Text <> "" Then
                .Lay4E.Text = CStr(ConvertTime(.Lay4B.Text, .Lay3B.Text))
            End If
            If .Lay3B.Text <> "" Then
                .Lay3E.Text = CStr(ConvertTime(.Lay3B.Text, .Lay2B.Text))
            End If
            If .Lay2B.Text <> "" Then
                .Lay2E.Text = CStr(ConvertTime(.Lay2B.Text, .Lay1B.Text))
            End If
            If .Lay1B.Text <> "" Then
                .Lay1E.Text = CStr(ConvertTime(.Lay1B.Text, "0"))
            End If
            .Lay11B.Text = CStr(PrintTime)
            .Lay11E.Text = CStr(ConvertTime(CStr(PrintTime), "0"))
            .FileNameBox.Text = ImportFileName
            .Lay11A.Text = CStr(TopLayer)
            .Lay11C.Text = DateAdd("s", PrintTime, PrintStartLocal).ToString(MyFormat)
        End With
        GCODE_File_R.Close()
        Exit Sub
Ehandler:
        MsgBox("There was an error in ""PauseTimeForm.GetTheTimes""." & vbCr & Err.Description)
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        Me.Hide()
    End Sub

    Private Sub ClearBut_Click(sender As Object, e As EventArgs) Handles ClearBut.Click
        For Each MyBox In Me.Controls.OfType(Of TextBox)()
            If MyBox.Name <> "Lay0C" And MyBox.Name <> "Lay0A" And MyBox.Name <> "Lay0B" Then
                MyBox.Text = ""
            End If
        Next
    End Sub

    Public Function ConvertTime(FirstT As String, SecondT As String) As String
        Dim SubTime = CLng(FirstT) - CLng(SecondT)
        Dim hr1 = Format(Int(SubTime / 3600), "00")
        Dim midnum = SubTime - (CLng(hr1) * 3600)
        Dim min1 = Format(Int(midnum / 60), "00")
        Dim sec1 = Format(Int(midnum - (CLng(min1) * 60)), "00")
        ConvertTime = hr1 & ":" & min1 & ":" & sec1
    End Function

    Private Sub AdjPrintStartBut_Click(sender As Object, e As EventArgs) Handles AdjPrintStartBut.Click
        Dim aResponse As MsgBoxResult
        aResponse = MsgBox("Adjust the Start Time to the contents of the text box.  The format must be correct" & vbCr & vbCr & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If aResponse = vbNo Then Exit Sub
        Dim TestTime As Date
        Try
            TestTime = DateValue(Me.Lay0C.Text)
        Catch ex As Exception
            MsgBox("The Start Date and Time is in an incorrect format.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End Try
        PrintStartTime = Me.Lay0C.Text
        Me.InfoLab.Text = "Start = User Entry"
    End Sub

    Private Sub AdjStartNowBut_Click(sender As Object, e As EventArgs) Handles AdjStartNowBut.Click
        Me.Lay0C.Text = CStr(Now)
        Me.InfoLab.Text = "Start = Now"
    End Sub

    Private Sub AdjStartPrint_Click(sender As Object, e As EventArgs) Handles AdjStartPrint.Click
        If PrintStartTime <> Nothing Then
            Me.Lay0C.Text = PrintStartTime
            Me.InfoLab.Text = "Start = Print Start Time"
        Else
            MsgBox("The Print Start Time is 0. You can use the NOW button.", vbOKOnly, "Greg's Toolbox")
        End If
    End Sub

    Private Sub SendToFileBut_Click(sender As Object, e As EventArgs) Handles SendToFileBut.Click
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim fs As Object
        With EnderMainForm
            .SaveFileDialog1.Title = "Create a Text File"
            .SaveFileDialog1.Filter = "TEXT Files|*.txt"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "txt"
            .SaveFileDialog1.FileName = "*.txt"
            .SaveFileDialog1.OverwritePrompt = True
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                fs = CreateObject("Scripting.FileSystemObject")

                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
                Me.Refresh()
            Else
                Exit Sub
            End If
        End With
        Try
            NewGcodeFile.Close()
        Catch ex As Exception
            MsgBox("There was an error creating the new file.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End Try
        NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(EnderMainForm.SaveFileDialog1.FileName, True)
        With Me
            NewGcodeFile.WriteLine("Start Time = " & .Lay0C.Text & vbCr)
            NewGcodeFile.WriteLine("Layer" & vbTab & vbTab & "Seconds" & vbTab & vbTab & "Time Interval" & vbTab & vbTab & "Time and Date" & vbTab & vbTab & "Reason" & vbCr)
            If .Lay1A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay1A.Text & vbTab & vbTab & .Lay1B.Text & vbTab & vbTab & .Lay1E.Text & vbTab & vbTab & .Lay1C.Text & vbTab & vbTab & .Lay1D.Text)
            End If
            If .Lay2A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay2A.Text & vbTab & vbTab & .Lay2B.Text & vbTab & vbTab & .Lay2E.Text & vbTab & vbTab & .Lay2C.Text & vbTab & vbTab & .Lay2D.Text)
            End If
            If .Lay3A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay3A.Text & vbTab & vbTab & .Lay3B.Text & vbTab & vbTab & .Lay3E.Text & vbTab & vbTab & .Lay3C.Text & vbTab & vbTab & .Lay3D.Text)
            End If
            If .Lay4A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay4A.Text & vbTab & vbTab & .Lay4B.Text & vbTab & vbTab & .Lay4E.Text & vbTab & vbTab & .Lay4C.Text & vbTab & vbTab & .Lay4D.Text)
            End If
            If .Lay5A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay5A.Text & vbTab & vbTab & .Lay5B.Text & vbTab & vbTab & .Lay5E.Text & vbTab & vbTab & .Lay5C.Text & vbTab & vbTab & .Lay5D.Text)
            End If
            If .Lay6A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay6A.Text & vbTab & vbTab & .Lay6B.Text & vbTab & vbTab & .Lay6E.Text & vbTab & vbTab & .Lay6C.Text & vbTab & vbTab & .Lay6D.Text)
            End If
            If .Lay7A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay7A.Text & vbTab & vbTab & .Lay7B.Text & vbTab & vbTab & .Lay7E.Text & vbTab & vbTab & .Lay7C.Text & vbTab & vbTab & .Lay7D.Text)
            End If
            If .Lay8A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay8A.Text & vbTab & vbTab & .Lay8B.Text & vbTab & vbTab & .Lay8E.Text & vbTab & vbTab & .Lay8C.Text & vbTab & vbTab & .Lay8D.Text)
            End If
            If .Lay9A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay9A.Text & vbTab & vbTab & .Lay9B.Text & vbTab & vbTab & .Lay9E.Text & vbTab & vbTab & .Lay9C.Text & vbTab & vbTab & .Lay9D.Text)
            End If
            If .Lay10A.Text <> "" Then
                NewGcodeFile.WriteLine(.Lay10A.Text & vbTab & vbTab & .Lay10B.Text & vbTab & vbTab & .Lay10E.Text & vbTab & vbTab & .Lay10C.Text & vbTab & vbTab & .Lay10D.Text & vbCr)
            End If
            NewGcodeFile.WriteLine("Total Layers = " & .Lay11A.Text & vbCr & "Total Time = " & .Lay11E.Text)
            NewGcodeFile.Close()
        End With
    End Sub

    Private Sub OpenTextFileBut_Click(sender As Object, e As EventArgs) Handles OpenTextFileBut.Click
        On Error Resume Next
        If IsRunningExe("notepad.exe") Then
            Dim MyGcodeFile = EnderMainForm.SaveFileDialog1.FileName
            Do Until InStr(1, MyGcodeFile, "\") = 0
                MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
            Loop
            AppActivate(MyGcodeFile & " - Notepad")
            If Err.Number <> 0 Then
                System.Diagnostics.Process.Start("notepad.exe", EnderMainForm.SaveFileDialog1.FileName)
                Err.Clear()
            End If
            Exit Sub
        End If
        System.Diagnostics.Process.Start("notepad.exe", EnderMainForm.SaveFileDialog1.FileName)
    End Sub

    Private Sub GetPauseLayerBut_Click(sender As Object, e As EventArgs) Handles GetPauseLayerBut.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("This command searches for M0 and M25 only." & vbCr & vbCr & "Do you want to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim ImportFileName = FirstFile
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim layerArray() As Integer
        ReDim layerArray(0)
        Dim PauseCount = 0
        Dim Dataline As String
        Dim PrintTime = 0
        Dim Start = False
        Dim LineCount = 0
        Do Until GCODE_File_R.EndOfStream = True
            Dataline = GCODE_File_R.ReadLine
            LineCount += 1
            If Strings.Left(Dataline, 3) = "M0 " Or Strings.Left(Dataline, 4) = "M25 " Then
                Do Until InStr(1, Dataline, ";LAYER:") > 0
                    Dataline = GCODE_File_R.ReadLine
                Loop
                layerArray(PauseCount) = CInt(Strings.Right(Dataline, Len(Dataline) - 7))
                PauseCount += 1
                ReDim Preserve layerArray(PauseCount)
            End If
        Loop
        ReDim Preserve layerArray(PauseCount - 1)
        PauseCount -= 1
        If PauseCount = -1 Then
            MsgBox("No Pauses were found in the file", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Me.Lay1A.Text = CStr(layerArray(0))
        Me.Lay2A.Text = CStr(layerArray(1))
        Me.Lay3A.Text = CStr(layerArray(2))
        Me.Lay4A.Text = CStr(layerArray(3))
        Me.Lay5A.Text = CStr(layerArray(4))
        Me.Lay6A.Text = CStr(layerArray(5))
        Me.Lay7A.Text = CStr(layerArray(6))
        Me.Lay8A.Text = CStr(layerArray(7))
        Me.Lay9A.Text = CStr(layerArray(8))
        Me.Lay10A.Text = CStr(layerArray(9))
    End Sub

    Private Sub PauseTimeForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        Dim AResponse = MsgBox("If you dismiss the dialog it will clear the form.  Do you want to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then
            e.Cancel = True
            Exit Sub
        ElseIf AResponse = vbYes Then
            e.Cancel = True
        End If
        Me.Dispose()
    End Sub

    Private Sub UseFileBut_Click(sender As Object, e As EventArgs) Handles UseFileBut.Click
        If Me.FileNameBox.Text = "" Then
            MsgBox("Use the other button first", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim ImportFileName = Me.FileNameBox.Text
        Call GetTheTimes(ImportFileName)
    End Sub
End Class