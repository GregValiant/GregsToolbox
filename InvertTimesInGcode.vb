Public Class InvertTimesInGcode
    Private Sub SelectGcodeBut_Click(sender As Object, e As EventArgs) Handles SelectGcodeBut.Click
        'On Error GoTo TheHandler
        Dim FileResponse As DialogResult ', GCODE_Filedelegate As [Delegate]
        Dim OriginalFile As System.IO.StreamReader
        Dim OutputFileName As String
        Dim TimeArray() As String
        Dim PauseArray(0) As String
        Dim PauseCount As Integer = 0
        Dim ImportFileName As String
        Dim ExportFile As System.IO.StreamWriter
        Dim DataLine As String = ""
        Dim TotalPrintTime As String = ""
        Dim LayerCount As Integer = 0
        Dim AdjustETA As Double = 0.0
        Dim StartTime As Date
        Dim LayNum As String = "0"
        Dim MyFormat = "h:mm tt" '   M/d"

        With EnderMainForm
            .OpenFileDialog1.Title = "Open a GCODE file To search"
            .OpenFileDialog1.Filter = "GCODE Files|*.gcode"
            .OpenFileDialog1.FilterIndex = 1
            .OpenFileDialog1.DefaultExt = "gcode"
            .OpenFileDialog1.FileName = ""
            FileResponse = .OpenFileDialog1.ShowDialog()
            If FileResponse = 2 Then
                Exit Sub
            End If
            ImportFileName = .OpenFileDialog1.FileName
        End With
        With EnderMainForm
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = "*.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)

                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If
                OutputFileName = .SaveFileDialog1.FileName
            Else
                Exit Sub
            End If
        End With
        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Do Until InStr(DataLine, "LAYER:0") > 0
            DataLine = OriginalFile.ReadLine
            If InStr(DataLine, ";TIME:") > 0 Then
                TotalPrintTime = Strings.Right(DataLine, Len(DataLine) - 6)
            End If
            If InStr(DataLine, ";LAYER_COUNT:") > 0 Then
                LayerCount = CInt(Strings.Right(DataLine, Len(DataLine) - 13))
            End If
        Loop
        DataLine = OriginalFile.ReadLine
        ReDim TimeArray(LayerCount)
        TimeArray(0) = TotalPrintTime
        Dim LayerCounter As Integer = 1
        Do Until InStr(DataLine, ";End of Gcode") > 0
            DataLine = OriginalFile.ReadLine
            If InStr(DataLine, ";TIME_ELAPSED:") > 0 Then
                TimeArray(LayerCounter) = CStr(Val(TotalPrintTime) - Val(Strings.Right(DataLine, Len(DataLine) - 14)))
                LayerCounter += 1
            End If
        Loop
        OriginalFile.Close()
        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        'Count Pauses
        Do Until OriginalFile.EndOfStream = True
            DataLine = OriginalFile.ReadLine
            If InStr(DataLine, ";LAYER:") > 0 Then
                LayNum = Strings.Right(DataLine, Len(DataLine) - 7)
            End If
            If InStr(DataLine, "Pauseatheight.py") > 0 Then
                PauseArray(PauseCount) = TimeArray(CInt(LayNum))
                PauseCount += 1
                ReDim Preserve PauseArray(PauseCount)
            End If
        Loop
        OriginalFile.Close()




        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)

        ExportFile = My.Computer.FileSystem.OpenTextFileWriter(OutputFileName, True)
        StartTime = Now
        DataLine = OriginalFile.ReadLine
        Do Until OriginalFile.EndOfStream = True
            If InStr(DataLine, ";LAYER:") > 0 Then
                LayNum = Strings.Right(DataLine, Len(DataLine) - 7)
            End If
            If InStr(DataLine, "PauseAtHeight.py") > 0 Then
                AdjustETA = CDbl(Val(TotalPrintTime) - Val(TimeArray(CInt(LayNum))))
            End If
            If InStr(DataLine, ";LAYER:") > 0 Then
                ExportFile.WriteLine(DataLine)
                DataLine = OriginalFile.ReadLine
                If InStr(DataLine, "M117") > 0 Then
                    ExportFile.WriteLine(DataLine)
                    DataLine = "M117 " & PauseTimeForm.ConvertTime(CStr(Val(TimeArray(CInt(LayNum))) - AdjustETA), CStr(0))
                Else
                    DataLine = "M117 " & PauseTimeForm.ConvertTime(CStr(Val(TimeArray(CInt(LayNum))) - AdjustETA), CStr(0))
                End If
            End If
            ExportFile.WriteLine(DataLine)
            DataLine = OriginalFile.ReadLine
        Loop

        ExportFile.Close()
        OriginalFile.Close()

        Exit Sub
TheHandler:
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        Me.Hide()
        EnderMainForm.BringToFront()
    End Sub
End Class