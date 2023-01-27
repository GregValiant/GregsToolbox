Option Compare Text

Imports System.ComponentModel

Public Class FileOnFileForm
    Public DataLineArray(0 To 20) As String
    Public ESet As Boolean
    Public SecondGCODEFile As Object = CreateObject("Scripting.FileSystemObject")
    Public WholeFile As Boolean = False
    Public RetractDist As Double = 0.00
    Public IsRetracted_1st As Boolean = False
    Public RetractDist_1st As Single = 0.00
    Public PrevE As Double
    Public FinalE As Single
    Public ZHopHgt As Single = 0
    Public WorkingZFirst As Single
    Public WorkingZSecond As Single
    Public FirstFileInitLayerHgt As Single
    Public FirstFileLayerHgt As Single
    Public SecondFileInitLayerHgt As Single
    Public SecondFileLayerHgt As Single
    Public LAYER_COUNT As Integer
    Public StartMode As String
    Public ContMode As String
    Public FirstFilePrintTime As Single
    Public ResumeX As Single
    Public ResumeY As Single
    Public ResumeZ As Single
    Public ResumeE As Double
    Public SupportRemoval As Boolean
    Public AbsExtrusion As String = "M82"
    Public G92String As String
    Public G92Zstring As String
    Public FirstFileName As String
    Public SecondFileName As String
    Public ZHopBool As Boolean = False
    Public ZPrev As String
    Public ZVal As String
    Public ZHop As String
    Public ToContinue As Boolean

    Private Declare Function GetShortPathName Lib "kernel32" Alias "GetShortPathNameA" (ByVal lpszLongPath As String, ByVal lpszShortPath As String, ByVal lBuffer As Long) As Long
    Public Function GetShortPath(strFileName As String) As String
        On Error Resume Next
        Dim lngRes As Long, strPath As String
        'Create a buffer
        strPath = Strings.StrDup(165, "0")
        lngRes = GetShortPathName(strFileName, strPath, 164)
        GetShortPath = Strings.Left(strPath, Convert.ToInt32(lngRes))
        Do Until InStr(GetShortPath, "\") = 0
            GetShortPath = Strings.Right(GetShortPath, Len(GetShortPath) - 1)
        Loop
    End Function

    Public Function GetFileName(IndX As String) As String
        On Error Resume Next
        Dim OpenTitle As String
        If IndX = "First" Then
            OpenTitle = "Open the 1st file"
        Else
            OpenTitle = "Open the 2nd file"
        End If
        With EnderMainForm
            .OpenFileDialog1.Title = OpenTitle
            .OpenFileDialog1.Filter = "GCODE Files|*.gcode"
            .OpenFileDialog1.FilterIndex = 1
            .OpenFileDialog1.DefaultExt = "gcode"
            .OpenFileDialog1.FileName = ""
            Dim FileResponse = .OpenFileDialog1.ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
            If FileResponse = 2 Then
                GetFileName = ""
                Exit Function
            End If
            GetFileName = .OpenFileDialog1.FileName
        End With
    End Function

    Private Sub GetFile1But_Click(sender As Object, e As EventArgs) Handles GetFile1But.Click
        On Error Resume Next
        If Me.StartModeOpt1.Checked Then
            StartMode = "Pause"
            If Me.PauseLayerBox.Text = "" Then
                MsgBox("You must enter the layer number of the pause in the gcode file", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
        Else
            StartMode = "Layer0"
        End If
        Dim IndX = "First"
        Dim FirstFile = GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Me.FirstFilePathNameBox.Text = FirstFile
        Me.Refresh()
        If Me.FirstFilePathNameBox.Text = "" Then
            MsgBox("The GCODE File Name box cannot be empty." & vbLf & vbLf & "Use the ""Get Gcode File Name"" button.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        End If
    End Sub

    Private Sub GetFile2But_Click(sender As Object, e As EventArgs) Handles GetFile2But.Click
        On Error Resume Next
        If Me.ContModeOpt1.Checked Then
            ContMode = "Pause"
            If Me.PauseLayerBox2.Text = "" Then
                MsgBox("You must enter the layer number of the pause in the gcode file", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
        Else
            ContMode = "Layer0"
        End If

        Dim StartLayerStr = ""
        Dim ELoc = 0, XLoc = 0, YLoc = 0, ZLoc = 0, FLoc = 0
        Dim IndX = "Second"
        Dim SecondFile = GetFileName(IndX)
        If SecondFile = "" Then Exit Sub
        Me.SecondFilePathNameBox.Text = SecondFile
        Me.Refresh()
        If Me.SecondFilePathNameBox.Text = "" Then
            MsgBox("The Second File Name box cannot be empty." & vbLf & vbLf & "Use the ""Get Top File Name"" button.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        End If
    End Sub

    Public Sub WriteFirstFile(NewGcodeStream As System.IO.StreamWriter)
        On Error GoTo EHandler
        Dim Dataline As String
        Dim ImportFileName = Me.FirstFilePathNameBox.Text
        Dim FirstGcodeFile As System.IO.StreamReader
        Dim LineCount = 0
        FirstGcodeFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dataline = FirstGcodeFile.ReadLine
        Dataline = System.Text.RegularExpressions.Regex.Replace(Dataline, "[^\u0000-\u007F]", "")
        Dim GregToolboxLine As String
        FirstFileName = Me.FirstFilePathNameBox.Text
        Do Until InStr(1, FirstFileName, "\") = 0
            FirstFileName = Strings.Right(FirstFileName, Len(FirstFileName) - InStr(1, FirstFileName, "\"))
        Loop
        SecondFileName = Me.SecondFilePathNameBox.Text
        Do Until InStr(1, SecondFileName, "\") = 0
            SecondFileName = Strings.Right(SecondFileName, Len(SecondFileName) - InStr(1, SecondFileName, "\"))
        Loop
        GregToolboxLine = ";POSTPROCESSED by Greg's Toolbox - Combine Gcode Files" & vbCr &
                            ";    Base File: " & FirstFileName & vbCr &
                            ";    Top File: " & SecondFileName
        If StartMode = "Pause" Then
            Do Until InStr(Dataline, ";current layer: " & Me.PauseLayerBox.Text) > 0 Or InStr(Dataline, ";current height:") > 0
                If InStr(Dataline, ";Layer height: ") > 0 Then
                    Dataline = ";Layer Height: " & SecondFileLayerHgt
                    NewGcodeStream.WriteLine(Dataline)
                    Dataline = FirstGcodeFile.ReadLine
                End If
                If InStr(Dataline, "Generated with") > 0 Then
                    NewGcodeStream.WriteLine(Dataline)
                    NewGcodeStream.WriteLine(GregToolboxLine)
                    FirstGcodeFile.ReadLine()
                End If
                If InStr(Dataline, ";script: PauseAtHeight.py") > 0 Then
                    Dataline = ";Greg's Toolbox: Combine_Gcode_Files"
                End If
                NewGcodeStream.WriteLine(Dataline)
                Dataline = FirstGcodeFile.ReadLine
                LineCount += 1
                If LineCount >= 1000 Then
                    LineCount = 0
                    Me.Refresh()
                End If
KeepOn:
                If FirstGcodeFile.EndOfStream = True Then
                    MsgBox("Greg's Toolbox failed to find one of the search criteria in the StartUp Gcode part of the base file." & vbCr & "Make sure the transition code is correct", vbOKOnly, "Greg's Toolbox")
                    ToContinue = False
                    Exit Sub
                End If
            Loop
        Else 'if StartMoode = Layer0
            Do Until InStr(Dataline, "TIME_ELAPSED:" & FirstFilePrintTime) > 0
                NewGcodeStream.WriteLine(Dataline)
                Dataline = FirstGcodeFile.ReadLine
                If InStr(Dataline, "Generated with") > 0 Then
                    NewGcodeStream.WriteLine(Dataline)
                    NewGcodeStream.WriteLine(GregToolboxLine)
                End If
                LineCount += 1
                If LineCount >= 1000 Then
                    LineCount = 0
                    Me.Refresh()
                End If
            Loop
            NewGcodeStream.WriteLine(Dataline)
        End If
        FirstGcodeFile.Close()
        Exit Sub
EHandler:
        MsgBox("There was an error in ""FileOnFileForm.WriteFirstFile"" procedure.  The command must continue but the new Gcode file is likely scrap", vbOKOnly, "Greg's Toolbox")
    End Sub

    Public Sub WriteTransitionCode(NewGcodeStream As System.IO.StreamWriter)
        On Error GoTo EHandler
        Dim TransitionText As String = Me.TransitionBox.Text
        Dim LineFeed As Long
        Dim TransLineStart As String = ";" & vbCrLf & ";Transition Code"
        Dim TransLineEnd As String = ";End of Transition Code" & vbCrLf & ";"
        Dim TransitionArray(1) As String
        Dim TransCount As Integer = 1
        TransitionArray(0) = TransLineStart
        Do While InStr(TransitionText, vbCrLf) > 0
            LineFeed = InStr(TransitionText, vbCrLf)
            TransitionArray(TransCount) = Strings.Left(TransitionText, Convert.ToInt32(LineFeed) - 1)
            TransitionText = Strings.Right(TransitionText, Convert.ToInt32(Len(TransitionText)) - Convert.ToInt32(LineFeed) - 1)
            TransCount += 1
            ReDim Preserve TransitionArray(TransCount)
        Loop
        TransitionArray(TransCount) = TransitionText
        ReDim Preserve TransitionArray(TransCount + 1)
        TransitionArray(TransCount + 1) = TransLineEnd
        For Each MyTrans In TransitionArray
            NewGcodeStream.WriteLine(MyTrans)
        Next
        Exit Sub
EHandler:
        MsgBox("There was an error in ""FileOnFileForm.WriteTransitionCode"" procedure.  The command must continue but the new Gcode file is likely scrap", vbOKOnly, "Greg's Toolbox")
    End Sub

    Public Sub WriteSecondFile(NewGcodeStream As System.IO.StreamWriter)
        On Error GoTo Ehandler
        Dim DataLine0 As String = ""
        Dim ImportFileName = Me.SecondFilePathNameBox.Text
        Dim LineCount = 0
        Dim XLoc As Integer = 0
        Dim YLoc As Integer = 0
        Dim Eloc As Integer = 0
        Dim ZLoc As Integer = 0
        Dim xVal As String = ""
        Dim yVal As String = ""
        Dim eVal As String = ""
        Dim zVal As String = ""
        SupportRemoval = Me.RemoveSupts.Checked
        If Me.ContModeOpt1.Checked Then
            ContMode = "Pause"
        Else
            ContMode = "Layer0"
        End If
        Dim SecondGCODEFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        If SupportRemoval Then
            Call GetRidOfSupport(NewGcodeStream)
            Exit Sub
        End If
        Do Until SecondGCODEFile.EndOfStream = True
            If ContMode = "Layer0" Then
                Do Until InStr(DataLine0, "MESH") > 0 Or InStr(DataLine0, "TYPE:SUPPORT") > 0
                    DataLine0 = SecondGCODEFile.ReadLine
                    Dim TheCommand = Strings.Left(DataLine0, 3)
                    If TheCommand = "G1 " Or TheCommand = "G92" Or TheCommand = "G2 " Or TheCommand = "G3 " Then
                        XLoc = InStr(DataLine0, " X")
                        YLoc = InStr(DataLine0, " Y")
                        ZLoc = InStr(DataLine0, " Z")
                        Eloc = InStr(DataLine0, " E")
                        If XLoc > 0 Then xVal = GetXValue(DataLine0, XLoc)
                        If YLoc > 0 Then yVal = GetYValue(DataLine0, YLoc)
                        If ZLoc > 0 Then zVal = GetZValue(DataLine0, ZLoc)
                        If Eloc > 0 Then eVal = GetEValue(DataLine0, Eloc)
                    End If
                    If InStr(DataLine0, ";LAYER:0") > 0 Then
                        Do While Strings.Left(DataLine0, 1) = ";"
                            NewGcodeStream.WriteLine(DataLine0)
                            DataLine0 = SecondGCODEFile.ReadLine
                        Loop
                    End If

                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                    If SecondGCODEFile.EndOfStream = True Then
                        MsgBox("The Pause Layer:" & Me.PauseLayerBox2.Text & " was not found in the second file.", vbOKOnly)
                        NewGcodeStream.Close()
                        SecondGCODEFile.Close()
                        Exit Sub
                    End If
                Loop
                Exit Do
            ElseIf ContMode = "Pause" Then
                Do Until InStr(DataLine0, ";current layer: " & Me.PauseLayerBox2.Text) > 0 Or InStr(DataLine0, ";current height:") > 0
                    DataLine0 = SecondGCODEFile.ReadLine
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                Loop
                Do Until InStr(DataLine0, "G92") > 0
                    DataLine0 = SecondGCODEFile.ReadLine
                    G92String = DataLine0
                Loop
                DataLine0 = SecondGCODEFile.ReadLine
                Exit Do
            End If
        Loop
        Do Until SecondGCODEFile.EndOfStream = True
            NewGcodeStream.WriteLine(DataLine0)
            DataLine0 = SecondGCODEFile.ReadLine
            LineCount += 1
            If LineCount >= 1000 Then
                LineCount = 0
                Me.Refresh()
            End If
        Loop
AllDone:
            On Error Resume Next
            SecondGCODEFile.Close()
            NewGcodeStream.Close()
            Exit Sub
Ehandler:
        MsgBox("There was an error in the ""FileOnFileForm.WriteSecondFile"" procedure." & vbCr & vbCr & Err.Description & vbCr & vbCr & "The command must continue but the New file may be scrap", vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub GetRidOfSupport(NewGcodeStream As System.IO.StreamWriter)
        Dim ImportFileName As String = Me.SecondFilePathNameBox.Text
        Dim SecondGCODEFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim DataLineArray(0 To 20) As String
        Dim LineCount As Single = 0
        Dim RepeatMeshLine As String = ";"
        Dim XLoc As Integer = 0, YLoc As Integer = 0, ZLoc As Integer = 0, ELoc As Integer = 0
        Dim XVal As String = "", YVal As String = "", EVal As String = ""
        ZVal = CStr(ResumeZ)
        Do Until SecondGCODEFile.EndOfStream = True
            If ContMode = "Layer0" Then
                'get rid of the skirt/brim
                Do Until InStr(DataLineArray(10), "MESH") > 0 Or InStr(DataLineArray(10), "TYPE:SUPPORT") > 0
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    Dim TheCommand = Strings.Left(DataLineArray(10), 3)
                    If TheCommand = "G1 " Or TheCommand = "G92" Or TheCommand = "G0 " Or TheCommand = "G2 " Or TheCommand = "G3 " Then
                        XLoc = InStr(DataLineArray(10), " X")
                        YLoc = InStr(DataLineArray(10), " Y")
                        ZLoc = InStr(DataLineArray(10), " Z")
                        ELoc = InStr(DataLineArray(10), " E")
                        If XLoc > 0 Then XVal = GetXValue(DataLineArray(10), XLoc)
                        If YLoc > 0 Then YVal = GetYValue(DataLineArray(10), YLoc)
                        If ZLoc > 0 Then
                            ZHop = WhatTheHop(DataLineArray(10))
                        End If
                        If ELoc > 0 Then EVal = GetEValue(DataLineArray(10), ELoc)
                    End If
                    If InStr(DataLineArray(10), ";LAYER:0") > 0 Then
                        Do While Strings.Left(DataLineArray(10), 1) = ";"
                            NewGcodeStream.WriteLine(DataLineArray(10))
                            DataLineArray(20) = SecondGCODEFile.ReadLine
                            IndexDatalineArray(DataLineArray)
                        Loop
                    End If
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                Loop
                NewGcodeStream.WriteLine("G92 E" & EVal & " ;Adjust the extruder location")
                NewGcodeStream.WriteLine("G1 X" & XVal & " Y" & YVal & " Z" & ZVal & " ; Adjust location to start of extrusion")
                Exit Do
            ElseIf ContMode = "Pause" Then
                Do Until InStr(DataLineArray(10), ";current layer: " & Me.PauseLayerBox2.Text) > 0 Or InStr(DataLineArray(10), ";current height:") > 0
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                Loop
                Do Until InStr(DataLineArray(10), "G92") > 0
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                Loop
                G92String = DataLineArray(10)
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                Exit Do
            End If
        Loop
        NewGcodeStream.WriteLine(G92String)
RemoveSupt:
        Do Until SecondGCODEFile.EndOfStream = True
            If InStr(DataLineArray(10), ";TYPE:SUPPORT") > 0 Then
                Do Until InStr(DataLineArray(10), ";MESH") > 0
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        Me.Refresh()
                        LineCount = 0
                    End If
                    Dim TheCommand = Strings.Left(DataLineArray(10), 3)
                    If AbsExtrusion = "M82" Then
                        If (TheCommand = "G1 " Or TheCommand = "G92" Or TheCommand = "G0 " Or TheCommand = "G2 " Or TheCommand = "G3 ") And InStr(DataLineArray(10), " E") > 0 Then
                            G92String = "G92 E" & GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E"))
                        End If
                    End If
                    If TheCommand = "G1 " Or TheCommand = "G92" Or TheCommand = "G0 " Or TheCommand = "G2 " Or TheCommand = "G3 " Then
                        XLoc = InStr(DataLineArray(10), " X")
                        YLoc = InStr(DataLineArray(10), " Y")
                        ZLoc = InStr(DataLineArray(10), " Z")
                        ELoc = InStr(DataLineArray(10), " E")
                        If XLoc > 0 Then XVal = GetXValue(DataLineArray(10), XLoc)
                        If YLoc > 0 Then YVal = GetYValue(DataLineArray(10), YLoc)
                        If ZLoc > 0 Then
                            ZHop = WhatTheHop(DataLineArray(10))
                        End If
                        If ELoc > 0 Then EVal = GetEValue(DataLineArray(10), ELoc)
                    End If
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                Loop
                If InStr(DataLineArray(10), "NONMESH") > 0 Then
                    RepeatMeshLine = DataLineArray(11)
                Else
                    RepeatMeshLine = ";"
                End If
                NewGcodeStream.WriteLine("G92 E" & EVal)
                NewGcodeStream.WriteLine("G0 X" & XVal & " Y" & YVal & " ;ReStart X Y")
                NewGcodeStream.WriteLine("G0 Z" & ZVal & ";Restart Z")
            Else
                Do Until SecondGCODEFile.EndOfStream = True Or InStr(DataLineArray(10), ";TYPE:SUPPORT") > 0
                    NewGcodeStream.WriteLine(DataLineArray(10))
                    ZLoc = InStr(DataLineArray(10), " Z")
                    If ZLoc > 0 Then
                        ZHop = WhatTheHop(DataLineArray(10))
                    End If
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                Loop
            End If
            If InStr(DataLineArray(10), ";TYPE:SUPPORT") > 0 And SecondGCODEFile.EndOfStream = False Then
                GoTo RemoveSupt
            ElseIf SecondGCODEFile.EndOfStream = True Then
                IndexDatalineArray(DataLineArray)
                Do Until DataLineArray(10) = ""
                    NewGcodeStream.WriteLine(DataLineArray(10))
                    IndexDatalineArray(DataLineArray)
                Loop
                GoTo AllDone
            End If
            If InStr(DataLineArray(10), "MESH") > 0 Then
                Do Until SecondGCODEFile.EndOfStream = True
                    NewGcodeStream.WriteLine(DataLineArray(10))
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                    If InStr(DataLineArray(10), " Z") > 0 Then
                        ZHop = WhatTheHop(DataLineArray(10))
                    End If
                    If InStr(DataLineArray(10), ";TYPE:SUPPORT") > 0 Then GoTo RemoveSupt
                Loop
                IndexDatalineArray(DataLineArray)
                Do Until DataLineArray(10) = ""
                    NewGcodeStream.WriteLine(DataLineArray(10))
                    IndexDatalineArray(DataLineArray)
                Loop
                GoTo AllDone
            End If

RemoveSupt2:
            If SupportRemoval And InStr(DataLineArray(10), ";TYPE:SUPPORT") > 0 Then
                Do Until InStr(DataLineArray(10), "MESH") > 0
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    Dim TheCommand = Strings.Left(DataLineArray(10), 3)
                    If AbsExtrusion = "M82" Then
                        If (TheCommand = "G1 " Or TheCommand = "G92" Or TheCommand = "G2 " Or TheCommand = "G3 ") And InStr(DataLineArray(10), " E") > 0 Then
                            G92String = "G92 E" & GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E"))
                        End If
                    End If
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                Loop
            End If
            DataLineArray(20) = SecondGCODEFile.ReadLine
            IndexDatalineArray(DataLineArray)
            LineCount += 1
            If LineCount >= 1000 Then
                Me.Refresh()
                LineCount = 0
            End If
        Loop
        NewGcodeStream.WriteLine(DataLineArray(10))
        Do Until SecondGCODEFile.EndOfStream = True
            DataLineArray(20) = SecondGCODEFile.ReadLine
            IndexDatalineArray(DataLineArray)
            NewGcodeStream.WriteLine(DataLineArray(10))
            LineCount += 1
            If LineCount >= 1000 Then
                LineCount = 0
                Me.Refresh()
            End If
        Loop
        IndexDatalineArray(DataLineArray)
        Do Until DataLineArray(10) = ""
            NewGcodeStream.WriteLine(DataLineArray(10))
            IndexDatalineArray(DataLineArray)
        Loop
AllDone:
        SecondGCODEFile.Close()
        Exit Sub
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        Me.Hide()
        EnderMainForm.BringToFront()
    End Sub

    Private Sub FinishBut_Click(sender As Object, e As EventArgs) Handles FinishBut.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("This command will assemble:" & vbCr & vbCr & Me.FirstFilePathNameBox.Text & vbCr & Me.TransitionBox.Text & vbCr & Me.SecondFilePathNameBox.Text & vbCr & vbCr & "Do you wish to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        With Me
            If .FirstFilePathNameBox.Text = "" Then
                MsgBox("1st File - You haven't picked the FIRST FILE", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If .SecondFilePathNameBox.Text = "" Then
                MsgBox("2nd File - You haven't picked the SECOND FILE", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If .NewFileNameBox.Text = "" Then
                MsgBox("Create File - You haven't created the NEW FILE yet.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            Dim TestFile As System.IO.StreamReader
            Dim Dataline = ""
            Dim Importfilename = Me.FirstFilePathNameBox.Text
            .ProgressBar1.Visible = True
            .ProgressBar1.MarqueeAnimationSpeed = 100
            .ProgLabel.Visible = True
            .ProgLabel.Text = "Opening Files"
        End With
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim NewGcodeFile = Me.NewFileNameBox.Text
        Dim NewGcodeStream As System.IO.StreamWriter
        NewGcodeStream = My.Computer.FileSystem.OpenTextFileWriter(NewGcodeFile, True)
        Me.ProgLabel.Text = "Writing the 1st file"
        Me.Refresh()
        Call WriteFirstFile(NewGcodeStream)
        Me.ProgLabel.Text = "Writing the Transition"
        Me.Refresh()
        Call WriteTransitionCode(NewGcodeStream)
        Me.ProgLabel.Text = "Writing the 2nd file"
        Me.Refresh()
        Call WriteSecondFile(NewGcodeStream)
        NewGcodeStream.close
        Cursor.Current = Cursors.Default
        With Me
            .FinishBut.BackColor = Color.PaleGreen
            .ProgressBar1.MarqueeAnimationSpeed = 0
            .ProgressBar1.Visible = False
            .ProgLabel.Visible = False
        End With
        Beep()
    End Sub

    Private Sub ClearFormBut_Click(sender As Object, e As EventArgs) Handles ClearFormBut.Click
        With Me
            .SecondFilePathNameBox.Text = ""
            .RemoveSupts.Checked = True
            .SecondFilePathNameBox.Text = ""
            .FirstFilePathNameBox.Text = ""
            .PauseLayerBox.Text = "1"
            .PauseLayerBox2.Text = "1"
            .NewDOS83Box.Text = ""
            .NewFileNameBox.Text = ""
            .TransitionBox.Text = ""
        End With
    End Sub

    Private Sub OpenGcode_Click(sender As Object, e As EventArgs) Handles OpenGcode.Click
        On Error Resume Next
        If Me.FirstFilePathNameBox.Text = "" Then
            MsgBox("The GCODE File Name box cannot be empty." & vbLf & vbLf & "Use the ""Get Gcode File Name"" button.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        Else
            If IsRunningExe("notepad.exe") Then
                Dim MyGcodeFile = Me.NewFileNameBox.Text
                Do Until InStr(1, MyGcodeFile, "\") = 0
                    MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
                Loop
                AppActivate(MyGcodeFile & " - Notepad")
                If Err.Number <> 0 Then
                    System.Diagnostics.Process.Start("notepad.exe", Me.NewFileNameBox.Text)
                    Err.Clear()
                End If
                Exit Sub
            End If
            System.Diagnostics.Process.Start("notepad.exe", Me.NewFileNameBox.Text)
        End If
    End Sub

    Private Sub GenerateTransitionBut_Click(sender As Object, e As EventArgs) Handles GenerateTransitionBut.Click
        Dim TransText As String = ""
        Dim Dataline As String = ""
        Dim ImportFileName As String
        Dim SecondGCODEFile As System.IO.StreamReader
        Dim LastLayer As String = "0"
        Dim LineCount As Long = 0
        Dim Elocation As Single = 0
        Dim StopLayer As Long = 0
        Dim StopLength As Integer = 8
        Dim IsRetracted_2nd As Boolean = False
        Dim RetractDist_2nd As Single = 0.00
        Dim MoveE As Double = 0.0
        Dim IsRetracted As Boolean = False
        'Dim GcodeList As List(Of String) = New List(Of String)
        RetractDist = 0.0
        PrevE = 0
        FinalE = 0
        Try
            SupportRemoval = Me.RemoveSupts.Checked
            If Me.ContModeOpt1.Checked Then
                ContMode = "Pause"
                If Me.PauseLayerBox2.Text = "" Then
                    MsgBox("The pause layer box for the top file must be filled in." & vbCr & "The command will end.", vbOKOnly, "Greg's Toolbox")
                    Exit Sub
                End If
            Else
                ContMode = "Layer0"
            End If
            With Me
                .ProgressBar1.Visible = True
                .ProgressBar1.MarqueeAnimationSpeed = 100
                .ProgLabel.Visible = True
                .ProgLabel.Text = "Generate Transition"
            End With
        Catch
        End Try
        ToContinue = True
        Call GetFirstFileInfo()
        If ToContinue = False Then
            With Me
                .ProgressBar1.MarqueeAnimationSpeed = 0
                .ProgressBar1.Visible = False
                .ProgLabel.Visible = False
            End With
            Exit Sub
        End If
        ReDim DataLineArray(0 To 20)

        'Get second file info
        ImportFileName = Me.SecondFilePathNameBox.Text
        If ImportFileName = "" Then
            MsgBox("The Second File Name box is empty.", vbOKOnly, "Greg's Toolbox")
            With Me
                .ProgressBar1.MarqueeAnimationSpeed = 0
                .ProgressBar1.Visible = False
                .ProgLabel.Visible = False
            End With
            Exit Sub
        End If
        SecondGCODEFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Do Until InStr(Dataline, ";Layer height: ") > 0
            Dataline = SecondGCODEFile.ReadLine
            If SecondGCODEFile.EndOfStream = True Then
                MsgBox("Can't find the "";LAYER_HEIGHT:"" line in the second gcodefile.  The command will exit.", vbOKOnly, "Greg's Toolbox")
                With Me
                    .ProgressBar1.MarqueeAnimationSpeed = 0
                    .ProgressBar1.Visible = False
                    .ProgLabel.Visible = False
                End With
                SecondGCODEFile.Close()
                Exit Sub
            End If
        Loop

        SecondFileLayerHgt = CSng(Strings.Right(Dataline, Len(Dataline) - 15))
        SecondFileInitLayerHgt = SecondFileLayerHgt

        Do Until InStr(Dataline, "LAYER:0") > 0
            If InStr(Dataline, "M82") > 0 Then
                AbsExtrusion = "M82"
            End If
            If InStr(Dataline, "M83") > 0 Then
                AbsExtrusion = "M83"
            End If
            Dataline = SecondGCODEFile.ReadLine
        Loop
        If CheckForZhop(ImportFileName) = True Then
            Dim AResponse = MsgBox("There are Z-Hops in the Second Gcode file.  You must review the transition ""G0 Z"" resume height and the ""G92 Z"" transition height.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        End If
        SecondGCODEFile.Close()
        SecondGCODEFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        LineCount = 0
        Do Until DataLineArray(10) <> ""
            DataLineArray(20) = SecondGCODEFile.ReadLine
            LineCount += 1
            IndexDatalineArray(DataLineArray)
        Loop
        If ContMode = "Pause" Then
            Try
                Do Until InStr(DataLineArray(10), ";current layer: " & Me.PauseLayerBox2.Text) > 0 Or InStr(DataLineArray(10), ";current height:") > 0
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        LineCount = 0
                        Me.Refresh()
                    End If
                    If SecondGCODEFile.EndOfStream = True Then
                        MsgBox("The end of the file was reached without finding a pause.", vbOKOnly, "Greg's Toolbox")
                        ToContinue = False
                        With Me
                            .ProgressBar1.MarqueeAnimationSpeed = 0
                            .ProgressBar1.Visible = False
                            .ProgLabel.Visible = False
                        End With
                        Exit Sub
                    End If
                Loop
            Catch
                If SecondGCODEFile.EndOfStream = True Then
                    MsgBox("The End Of the 2nd file was reached without coming across ""PauseAtHeight.py"".  The command will end.", vbOKOnly, "Greg's Toolbox")
                    With Me
                        .ProgressBar1.MarqueeAnimationSpeed = 0
                        .ProgressBar1.Visible = False
                        .ProgLabel.Visible = False
                    End With
                    Exit Sub
                End If
            End Try

            Do Until InStr(DataLineArray(10), "G92") > 0
                If InStr(DataLineArray(10), " X") > 0 Then
                    ResumeX = CSng(GetXValue(DataLineArray(10), InStr(DataLineArray(10), " X")))
                End If
                If InStr(DataLineArray(10), " Y") > 0 Then
                    ResumeY = CSng(GetYValue(DataLineArray(10), InStr(DataLineArray(10), " Y")))
                End If
                If InStr(DataLineArray(10), " Z") > 0 Then
                    ResumeZ = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                    If InStr(DataLineArray(10), "move up a millimeter to get out of the way") > 0 Then ResumeZ -= 1
                    If WhatTheHop(DataLineArray(10)) = "Up" Then
                        ResumeZ -= ZHopHgt
                    End If
                End If
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If SecondGCODEFile.EndOfStream = True Then Exit Do
            Loop
            ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
            DataLineArray(20) = SecondGCODEFile.ReadLine
            IndexDatalineArray(DataLineArray)
            LineCount += 1
            Dim TheCommand = Strings.Left(DataLineArray(10), 2)
            Do Until (TheCommand = "G1" Or TheCommand = "G2" Or TheCommand = "G3") And InStr(DataLineArray(10), " E") > 0
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                TheCommand = Strings.Left(DataLineArray(10), 2)
            Loop
            If InStr(DataLineArray(10), " E") > 0 And InStr(DataLineArray(10), " X") = 0 And InStr(DataLineArray(10), " Y") = 0 Then
                IsRetracted_2nd = True
                RetractDist_2nd = CSng(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E"))) - CSng(ResumeE)
            Else
                IsRetracted_2nd = False
            End If
            If SupportRemoval Then
                Do Until InStr(DataLineArray(10), ";MESH") > 0
                    If InStr(DataLineArray(10), " X") > 0 Then
                        ResumeX = CSng(GetXValue(DataLineArray(10), InStr(DataLineArray(10), " X")))
                    End If
                    If InStr(DataLineArray(10), " Y") > 0 Then
                        ResumeY = CSng(GetYValue(DataLineArray(10), InStr(DataLineArray(10), " Y")))
                    End If
                    If InStr(DataLineArray(10), " Z") > 0 Then
                        ResumeZ = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                        If WhatTheHop(DataLineArray(10)) = "Up" Then
                            ResumeZ -= ZHopHgt
                        End If
                    End If
                    If InStr(DataLineArray(10), " E") > 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        If AbsExtrusion = "M82" Then
                            If ResumeE < PrevE Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(PrevE - ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = ResumeE
                        Else
                            If ResumeE < 0 Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = 0
                        End If
                    End If
                    If InStr(DataLineArray(10), "G92 E") > 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        PrevE = ResumeE
                    End If
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        Me.Refresh()
                        LineCount = 0
                    End If
                Loop
            End If
            DataLineArray(20) = SecondGCODEFile.ReadLine
            IndexDatalineArray(DataLineArray)
            LineCount += 1
        Else 'If ContMode = "Layer0"
            Do Until InStr(DataLineArray(10), ";LAYER:0") > 0
                If InStr(DataLineArray(10), " X") > 0 Then
                    ResumeX = CSng(Val(GetXValue(DataLineArray(10), Convert.ToInt32(InStr(DataLineArray(10), " X")))))
                End If
                If InStr(DataLineArray(10), " Y") > 0 Then
                    ResumeY = CSng(Val(GetYValue(DataLineArray(10), Convert.ToInt32(InStr(DataLineArray(10), " Y")))))
                End If
                If InStr(DataLineArray(10), " Z") > 0 Then
                    ZHop = WhatTheHop(DataLineArray(10))
                End If
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
            Loop
            ZHop = "Up"
            Dataline = SecondGCODEFile.ReadLine
            IndexDatalineArray(DataLineArray)
            LineCount += 1
            SecondFileInitLayerHgt = 0
            Do Until InStr(DataLineArray(10), " X") > 0 And InStr(DataLineArray(10), " Y") > 0 And InStr(DataLineArray(10), " E") > 0
                If InStr(DataLineArray(10), " Z") > 0 Then
                    ZHop = WhatTheHop(DataLineArray(10))
                    SecondFileInitLayerHgt = CSng(ZVal)
                    ZHop = "Down"
                End If
                If InStr(DataLineArray(10), " X") > 0 Then
                    ResumeX = CSng(Val(GetXValue(DataLineArray(10), InStr(DataLineArray(10), " X"))))
                End If
                If InStr(DataLineArray(10), " Y") > 0 Then
                    ResumeY = CSng(Val(GetYValue(DataLineArray(10), Convert.ToInt32(InStr(DataLineArray(10), " Y")))))
                End If
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If LineCount >= 1000 Then
                    Me.Refresh()
                    LineCount = 0
                End If
            Loop
            Dataline = SecondGCODEFile.ReadLine
            IndexDatalineArray(DataLineArray)
            LineCount += 1
            ESet = False
            PrevE = ResumeE
            IsRetracted = False
            If SupportRemoval Then
                Do Until InStr(DataLineArray(10), ";MESH") > 0
                    If InStr(DataLineArray(10), " X") > 0 Then
                        ResumeX = CSng(GetXValue(DataLineArray(10), InStr(DataLineArray(10), " X")))
                    End If
                    If InStr(DataLineArray(10), " Y") > 0 Then
                        ResumeY = CSng(GetYValue(DataLineArray(10), InStr(DataLineArray(10), " Y")))
                    End If
                    If InStr(DataLineArray(10), " Z") > 0 Then
                        ResumeZ = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                        If WhatTheHop(DataLineArray(10)) = "Up" Then
                            ResumeZ -= ZHopHgt
                        End If
                        ZPrev = ZVal
                    End If
                    If InStr(DataLineArray(10), " E") > 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        If AbsExtrusion = "M82" Then
                            If ResumeE < PrevE Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(PrevE - ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = ResumeE
                        Else
                            If ResumeE < 0 Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = 0
                        End If
                    End If
                    If InStr(DataLineArray(10), "G92 E") > 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        PrevE = ResumeE
                    End If
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        Me.Refresh()
                        LineCount = 0
                    End If
                Loop
            ElseIf Not SupportRemoval Then
                Do Until (InStr(DataLineArray(10), ";MESH") > 0 Or InStr(DataLineArray(10), ";TYPE") > 0) And InStr(DataLineArray(10), "SKIRT") = 0
                    If InStr(DataLineArray(10), " X") > 0 Then
                        ResumeX = CSng(GetXValue(DataLineArray(10), InStr(DataLineArray(10), " X")))
                    End If
                    If InStr(DataLineArray(10), " Y") > 0 Then
                        ResumeY = CSng(GetYValue(DataLineArray(10), InStr(DataLineArray(10), " Y")))
                    End If
                    If InStr(DataLineArray(10), " Z") > 0 Then
                        ResumeZ = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                        If WhatTheHop(DataLineArray(10)) = "Up" Then
                            ResumeZ -= ZHopHgt
                        End If
                    End If
                    If InStr(DataLineArray(10), " E") > 0 And InStr(DataLineArray(10), " X") = 0 And InStr(DataLineArray(10), " Y") = 0 And InStr(DataLineArray(10), "|") = 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        If AbsExtrusion = "M82" Then
                            If ResumeE < PrevE Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(PrevE - ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = ResumeE
                        Else
                            If ResumeE < 0 Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = 0
                        End If
                    ElseIf InStr(DataLineArray(10), " E") > 0 And InStr(DataLineArray(10), " X") > 0 And InStr(DataLineArray(10), " Y") > 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        If AbsExtrusion = "M82" Then
                            If ResumeE < PrevE Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(PrevE - ResumeE)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = ResumeE
                        Else
                            If ResumeE < 0 Then
                                IsRetracted_2nd = True
                                RetractDist_2nd = CSng(ResumeE * -1)
                            Else
                                IsRetracted_2nd = False
                            End If
                            PrevE = 0
                        End If
                    End If
                    If InStr(DataLineArray(10), "G92 E") > 0 Then
                        ResumeE = CDbl(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        PrevE = ResumeE
                    End If
                    DataLineArray(20) = SecondGCODEFile.ReadLine
                    IndexDatalineArray(DataLineArray)
                    LineCount += 1
                    If LineCount >= 1000 Then
                        Me.Refresh()
                        LineCount = 0
                    End If
                Loop
            End If
            ResumeZ = SecondFileInitLayerHgt
        End If
        SecondGCODEFile.Close()
        SecondGCODEFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        If ContMode = "Pause" Then
            Do Until InStr(DataLineArray(10), ";LAYER:" & Val(PauseLayerBox2.Text) - 1) > 0
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If LineCount >= 1000 Then
                    Me.Refresh()
                    LineCount = 0
                End If
            Loop
            Do Until InStr(DataLineArray(10), "Do the actual pause") > 0
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
            Loop
            Dim ZFound As Boolean = False
            Do Until ZFound = True
                DataLineArray(20) = SecondGCODEFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If InStr(DataLineArray(10), " Z") > 0 Then ResumeZ = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                If InStr(DataLineArray(10), " X") > 0 And InStr(DataLineArray(10), " Y") > 0 And InStr(DataLineArray(10), " E") > 0 Then
                    ZFound = True
                End If
            Loop
        End If
        If IsRetracted_1st And IsRetracted_2nd Then
            ResumeE = ResumeE + RetractDist_2nd - RetractDist_1st
            MoveE = ResumeE
        ElseIf IsRetracted_1st And Not IsRetracted_2nd Then
            ResumeE -= RetractDist_1st
            MoveE = ResumeE + RetractDist_1st
        ElseIf Not IsRetracted_1st And IsRetracted_2nd Then
            ResumeE += RetractDist_2nd
            MoveE = ResumeE
        ElseIf Not IsRetracted_1st And Not IsRetracted_2nd Then
            ResumeE = ResumeE
            MoveE = ResumeE
        End If

        If ContMode = "Layer0" Then
            ResumeZ = SecondFileInitLayerHgt
        End If
        Dim ActualStartHeight As Single = 0
        If Not CheckForZhop(ImportFileName) Then
            If ContMode = "Pause" Then
                ActualStartHeight = CSng(WorkingZFirst) - FirstFileLayerHgt + SecondFileLayerHgt
            ElseIf ContMode = "Layer0" Then
                ActualStartHeight = CSng(WorkingZFirst) + CSng(SecondFileInitLayerHgt)
            End If
        Else
            If ContMode = "Pause" Then
                ActualStartHeight = CSng(WorkingZFirst) + CSng(SecondFileLayerHgt)
            ElseIf ContMode = "Layer0" Then
                ActualStartHeight = CSng(WorkingZFirst) + CSng(SecondFileInitLayerHgt)
                ResumeZ = SecondFileInitLayerHgt
            End If
        End If
        ZVal = CStr(ResumeZ)
        Me.TransitionBox.Text = "G0 Z" & WorkingZFirst + 1 & vbCrLf &
            "G0 X" & ResumeX & " Y" & ResumeY & vbCrLf &
            "G0 Z" & ActualStartHeight & vbCrLf &
            AbsExtrusion & vbCrLf &
            "G92 Z" & ResumeZ & vbCrLf &
            "G92 E" & Format(ResumeE, "0.00000") & vbCrLf &
            "G1 F1800 E" & Format(MoveE, "0.00000")

        With Me
            .ProgressBar1.MarqueeAnimationSpeed = 0
            .ProgressBar1.Visible = False
            .ProgLabel.Visible = False
        End With
        Beep()
        Exit Sub
EHandler:
        MsgBox("There was an error in the ""GenerateTransitionGcode"" procedure.", vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub CreateNewBut_Click(sender As Object, e As EventArgs) Handles CreateNewBut.Click
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim fs As Object
        Dim TempName = Me.FirstFilePathNameBox.Text
        Do Until InStr(TempName, "\") = 0
            TempName = Strings.Right(TempName, Len(TempName) - InStr(TempName, "\"))
        Loop
        TempName = Strings.Left(TempName, Len(TempName) - 6)
        With EnderMainForm
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = TempName & "_COMBINED.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)

                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If

                fs = CreateObject("Scripting.FileSystemObject")
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
                Me.NewFileNameBox.Text = .SaveFileDialog1.FileName
                Me.NewDOS83Box.Text = GetShortPath(.SaveFileDialog1.FileName)
                Me.Refresh()
            Else
                Exit Sub
            End If
        End With
        Try
            NewGcodeFile.Close()
        Catch ex As Exception
            MsgBox("There was an error creating the new file.", vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Public Function GetXValue(MyLine As String, XLoc As Integer) As String
        Dim Xstr = Strings.Right(MyLine, Len(MyLine) - XLoc - 1)
        Dim SpLoc = InStr(Xstr, " ")
        If SpLoc = 0 Then
            GetXValue = Xstr
        Else
            GetXValue = Strings.Trim(Strings.Left(Xstr, SpLoc))
        End If
        If GetXValue = "" Then GetXValue = "0"
    End Function

    Public Function GetYValue(MyLine As String, YLoc As Integer) As String
        Dim Ystr = Strings.Right(MyLine, Len(MyLine) - YLoc - 1)
        Dim SpLoc = InStr(Ystr, " ")
        If SpLoc = 0 Then
            GetYValue = Ystr
        Else
            GetYValue = Strings.Trim(Strings.Left(Ystr, SpLoc))
        End If
        If GetYValue = "" Then GetYValue = "0"
    End Function

    Public Function GetZValue(MyLine As String, ZLoc As Integer) As String
        Dim Zstr = Strings.Right(MyLine, Len(MyLine) - ZLoc - 1)
        Dim SpLoc = InStr(Zstr, " ")
        If SpLoc = 0 Then
            GetZValue = Zstr
        Else
            GetZValue = Strings.Trim(Strings.Left(Zstr, SpLoc))
        End If
    End Function

    Public Function GetEValue(MyLine As String, ELoc As Integer) As String
        Dim Estr = Strings.Right(MyLine, Len(MyLine) - ELoc - 1)
        Dim SpLoc = InStr(Estr, " ")
        If SpLoc = 0 Then
            GetEValue = Estr
        Else
            GetEValue = Strings.Trim(Strings.Left(Estr, SpLoc))
        End If
    End Function

    Public Function GetSValue(MyLine As String, SLoc As Integer) As String
        Dim Sstr = Strings.Right(MyLine, Len(MyLine) - SLoc - 1)
        Dim SpLoc = InStr(Sstr, " ")
        If SpLoc = 0 Then
            GetSValue = Sstr
        Else
            GetSValue = Strings.Trim(Strings.Left(Sstr, SpLoc))
        End If
    End Function

    Private Sub StartModeOpt1_CheckedChanged(sender As Object, e As EventArgs) Handles StartModeOpt1.CheckedChanged
        If Me.StartModeOpt1.Checked Then
            Me.PauseLayerBox.Enabled = True
        Else
            Me.PauseLayerBox.Enabled = False
        End If
    End Sub

    Private Sub StartModeOpt2_CheckedChanged(sender As Object, e As EventArgs) Handles StartModeOpt2.CheckedChanged
        If Me.StartModeOpt2.Checked = True Then
            Me.PauseLayerBox.Enabled = False
            Me.PauseLayerBox.Text = "0"
        Else
            Me.PauseLayerBox.Enabled = True
        End If
    End Sub

    Private Sub ContModeOpt1_CheckedChanged(sender As Object, e As EventArgs) Handles ContModeOpt1.CheckedChanged
        If Me.ContModeOpt1.Checked = True Then
            Me.PauseLayerBox2.Enabled = True
        Else
            Me.PauseLayerBox2.Enabled = False
        End If
    End Sub

    Private Sub ContModeOpt2_CheckedChanged(sender As Object, e As EventArgs) Handles ContModeOpt2.CheckedChanged
        If Me.ContModeOpt2.Checked = True Then
            Me.PauseLayerBox2.Enabled = False
            Me.PauseLayerBox2.Text = "0"
        Else
            Me.PauseLayerBox2.Enabled = True
        End If
    End Sub

    Private Sub FileOnFileForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Call Me.CancelBut_Click(sender, e)
    End Sub

    Private Sub GetFirstFileInfo()
        Dim ImportFileName As String = Me.FirstFilePathNameBox.Text
        If ImportFileName = "" Then
            MsgBox("The first filename box is empty.", vbOKOnly, "Greg's Toolbox")
            ToContinue = False
            Exit Sub
        End If
        ReDim DataLineArray(0 To 20)
        Dim DataLine As String
        Dim LineCount As Integer = 0
        Dim StopLength = 0
        Dim StopLayer = 0
        LineCount = 0
        PrevE = 0
        FinalE = 0
        If Me.StartModeOpt1.Checked Then
            StartMode = "Pause"
        Else
            StartMode = "Layer0"
        End If
        Dim FirstGcodeFile As System.IO.StreamReader
        FirstGcodeFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        DataLine = FirstGcodeFile.ReadLine
        Do Until InStr(DataLine, ";Layer height: ") > 0
            DataLine = FirstGcodeFile.ReadLine
        Loop
        FirstFileLayerHgt = CSng(Strings.Right(DataLine, Len(DataLine) - 15))
        If CheckForZhop(ImportFileName) = True Then
            Dim AResponse = MsgBox("There are Z-Hops in the First Gcode file.  You must review the transition Gcode ""G0 Z"" resume height and the ""G92 Z"" transition height.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        End If
        FirstGcodeFile.Close()
        FirstGcodeFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)

        If StartMode = "Pause" Then
            If Val(Me.PauseLayerBox.Text) > 0 Then
                StopLength = Len(Me.PauseLayerBox.Text) + 7
                StopLayer = Convert.ToInt32(Me.PauseLayerBox.Text) - 1
                If StopLayer > 0 Then StopLayer -= 1
            End If
            Do Until InStr(DataLine, ";LAYER:0") > 0
                DataLine = FirstGcodeFile.ReadLine
                LineCount += 1
                If InStr(DataLine, "M82") > 0 Then
                    AbsExtrusion = "M82"
                ElseIf InStr(DataLine, "M83") > 0 Then
                    AbsExtrusion = "M83"
                End If
                If FirstGcodeFile.EndOfStream = True Then
                    Dim Aresponse = MsgBox("The program is stuck in a loop because it couldn't find the pause layer. Check your settings and try again.", vbOKOnly, "Greg's Toolbox")
                    FirstGcodeFile.Close()
                    ToContinue = False
                    Exit Sub
                End If
            Loop
            DataLineArray(20) = FirstGcodeFile.ReadLine
            IndexDatalineArray(DataLineArray)
            Do Until InStr(DataLineArray(10), ";LAYER:" & StopLayer) > 0
                DataLineArray(20) = FirstGcodeFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If LineCount >= 1000 Then
                    LineCount = 0
                    Me.Refresh()
                End If
                If FirstGcodeFile.EndOfStream = True Then
                    MsgBox("The end of the file was reached without coming across ""PauseAtHeight.py"".  The command will exit", vbOKOnly, "Greg's Toolbox")
                    With Me
                        .ProgressBar1.MarqueeAnimationSpeed = 0
                        .ProgressBar1.Visible = False
                        .ProgLabel.Visible = False
                    End With
                    FirstGcodeFile.Close()
                    ToContinue = False
                    Exit Sub
                End If
            Loop

            Do Until InStr(DataLineArray(10), ";current layer: " & Me.PauseLayerBox.Text) > 0 Or InStr(DataLineArray(10), ";current height:") > 0 Or FirstGcodeFile.EndOfStream = True
                DataLineArray(20) = FirstGcodeFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                Try
                    If AbsExtrusion = "M82" Then
                        If InStr(DataLineArray(10), " X") > 0 And InStr(DataLineArray(10), " Y") > 0 And InStr(DataLineArray(10), " E") > 0 Then
                            FinalE = CSng(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                            PrevE = FinalE
                            IsRetracted_1st = False
                            GoTo KickOut
                        End If
                    ElseIf AbsExtrusion = "M83" Then
                        FinalE = 0
                        IsRetracted_1st = False
                        GoTo KickOut
                    End If
                    If InStr(DataLineArray(10), "G92") > 0 Then
                        FinalE = CSng(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        PrevE = FinalE
                        IsRetracted_1st = False
                        GoTo KickOut
                    End If
                    If InStr(DataLineArray(10), " X") = 0 And InStr(DataLineArray(10), " Y") = 0 And InStr(DataLineArray(10), " E") > 0 Then
                        FinalE = CSng(GetEValue(DataLineArray(10), InStr(DataLineArray(10), " E")))
                        If FinalE < PrevE Then
                            IsRetracted_1st = True
                            RetractDist_1st = CSng(PrevE) - CSng(FinalE)
                        ElseIf Val(FinalE) >= Val(PrevE) Then
                            IsRetracted_1st = False
                        End If
                    End If
                    If InStr(DataLineArray(10), " Z") > 0 Then
                        WorkingZFirst = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                        If WhatTheHop(DataLineArray(10)) = "Up" Then
                            WorkingZFirst -= ZHopHgt
                        End If
                    End If
                Catch
                End Try
KickOut:
                LineCount += 1
                If LineCount >= 1000 Then
                    LineCount = 0
                    Me.Refresh()
                End If
            Loop
            If FirstGcodeFile.EndOfStream = True Then
                MsgBox("The end of the file was reached without coming across ""PauseAtHeight.py"".  The command will exit", vbOKOnly, "Greg's Toolbox")
                With Me
                    .ProgressBar1.MarqueeAnimationSpeed = 0
                    .ProgressBar1.Visible = False
                    .ProgLabel.Visible = False
                End With
                FirstGcodeFile.Close()
                ToContinue = False
                Exit Sub
            End If
            Do Until InStr(DataLineArray(10), "G92") > 0
                DataLineArray(20) = FirstGcodeFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If LineCount >= 1000 Then
                    Me.Refresh()
                    LineCount = 0
                End If
            Loop
        Else 'StartMode = "LAYER0"
            Do Until InStr(DataLineArray(10), "TIME:") > 0
                DataLineArray(20) = FirstGcodeFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If LineCount >= 1000 Then
                    Me.Refresh()
                    LineCount = 0
                End If
            Loop
            FirstFilePrintTime = CSng(Strings.Right(DataLineArray(10), Len(DataLineArray(10)) - 6))
            Do Until InStr(DataLineArray(10), ";TIME_ELAPSED:" & FirstFilePrintTime) > 0
                DataLineArray(20) = FirstGcodeFile.ReadLine
                IndexDatalineArray(DataLineArray)
                LineCount += 1
                If LineCount >= 1000 Then
                    Me.Refresh()
                    LineCount = 0
                End If
                Dim TheCommand = Strings.Left(DataLineArray(10), 3)
                If (TheCommand = "G0 " Or TheCommand = "G1 " Or TheCommand = "G92" Or TheCommand = "G2 " Or TheCommand = "G3 ") And InStr(DataLineArray(10), " Z") > 0 Then
                    WorkingZFirst = CSng(GetZValue(DataLineArray(10), InStr(DataLineArray(10), " Z")))
                    If WhatTheHop(DataLineArray(10)) = "Up" Then
                        WorkingZFirst = CSng(Val(ZVal) - ZHopHgt)
                    Else
                        WorkingZFirst = CSng(ZVal)
                    End If
                End If
                If FirstGcodeFile.EndOfStream = True Then
                    MsgBox("The end of the first file was reached without finding the TIME_ELAPSED line in the gcode.", vbOKOnly, "Greg's Toolbox")
                    ToContinue = False
                    Exit Do
                End If
            Loop
        End If
        FirstGcodeFile.Close()
    End Sub

    Public Function CheckForZhop(EitherGCODEFile As String) As Boolean
        Dim Dataline As String = ""
        Dim TheGcodeFile = My.Computer.FileSystem.OpenTextFileReader(EitherGCODEFile)
        Dim SettingString As String = ""
        CheckForZhop = False
        ZHopBool = False
        ZHopHgt = 0
        Do Until TheGcodeFile.EndOfStream = True
            If InStr(Dataline, ";SETTING_3 ") > 0 Then
                SettingString &= Strings.Right(Dataline, Len(Dataline) - 11)
            End If
            Dataline = TheGcodeFile.ReadLine
        Loop
        If InStr(1, SettingString, "retraction_hop_enabled = True") > 0 Then
            CheckForZhop = True
            ZHopBool = True
        End If
        If InStr(1, SettingString, "retraction_hop = ") > 0 Then
            If CheckForZhop Then
                Dim HopEquals = InStr(1, SettingString, "retraction_hop = ")
                Dim ShortLine = Strings.Right(SettingString, Len(SettingString) - HopEquals - 16)
                HopEquals = InStr(ShortLine, "\")
                ZHopHgt = CSng(Strings.Left(ShortLine, HopEquals - 1))
            End If
        End If
        TheGcodeFile.Close()
    End Function

    Public Function WhatTheHop(Dataline0 As String) As String
        WhatTheHop = ZHop
        Dim TheCommand = Strings.Left(Dataline0, 3)
        If TheCommand = "G1 " Then
            If InStr(1, Dataline0, " Z") > 0 And (InStr(1, Dataline0, " X") = 0 And InStr(1, Dataline0, " Y") = 0) Then
                ZVal = GetZValue(Dataline0, InStr(1, Dataline0, " Z"))
                If InStr(Dataline0, "move up a millimeter to get out of the way") > 0 Then ZVal = CStr(CSng(ZVal) - 1)
                If Val(ZVal) > Val(ZPrev) Then
                    ZHop = "Up"
                    ZPrev = ZVal
                ElseIf Val(ZVal) < Val(ZPrev) Then
                    ZHop = "Down"
                    ZPrev = ZVal
                End If
                WhatTheHop = ZHop
            ElseIf InStr(1, Dataline0, " Z") > 0 And (InStr(1, Dataline0, " X") > 0 Or InStr(1, Dataline0, " Y") > 0) Then
                ZVal = GetZValue(Dataline0, InStr(1, Dataline0, " Z"))
                ZPrev = ZVal
            End If
        ElseIf Strings.Left(Dataline0, 3) = "G0 " Then
            ZVal = GetZValue(Dataline0, InStr(1, Dataline0, " Z"))
            ZPrev = ZVal
        End If
    End Function

    Private Sub File1OpenBut_Click(sender As Object, e As EventArgs) Handles File1OpenBut.Click
        If IsRunningExe("notepad.exe") Then
            Dim MyGcodeFile = Me.FirstFilePathNameBox.Text
            Do Until InStr(1, MyGcodeFile, "\") = 0
                MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
            Loop
            AppActivate(MyGcodeFile & " - Notepad")
        Else
            System.Diagnostics.Process.Start("notepad.exe", Me.FirstFilePathNameBox.Text)
            Err.Clear()
            Exit Sub
        End If
    End Sub

    Private Sub File2OpenBut_Click(sender As Object, e As EventArgs) Handles File2OpenBut.Click
        If IsRunningExe("notepad") Then
            Dim MyGcodeFile = Me.SecondFilePathNameBox.Text
            Do Until InStr(1, MyGcodeFile, "\") = 0
                MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
            Loop
            Err.Clear()
            AppActivate(MyGcodeFile & " - Notepad")
        Else
            System.Diagnostics.Process.Start("notepad.exe", Me.SecondFilePathNameBox.Text)
            Err.Clear()
        End If
    End Sub

    Public Sub IndexDatalineArray(IndexArray1() As String)
        On Error Resume Next
        For MyLine = 0 To 19 Step 1
            IndexArray1(MyLine) = IndexArray1(MyLine + 1)
        Next
        IndexArray1(20) = ""
        DataLineArray = IndexArray1
    End Sub

    Private Sub GetFirstPauseLayerBut_Click_1(sender As Object, e As EventArgs) Handles GetFirstPauseLayerBut.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        Dim LayerCounter As String = "0"
        Dim ImportFileName As String = Me.FirstFilePathNameBox.Text
        Dim GcodeFile As System.IO.StreamReader
        AResponse = MsgBox("This command searches for M0 and M25 only." & vbCr & vbCr & "Do you want to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub

        If ImportFileName = "" Then
            ImportFileName = Me.GetFileName("First")
        End If
        If ImportFileName = "" Then Exit Sub
        GcodeFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim LayerArray() As Integer
        ReDim LayerArray(0)
        Dim PauseCount = 0
        Dim Dataline As String
        Dim PrintTime = 0
        Dim Start = False
        Dim LineCount = 0
        Do Until GcodeFile.EndOfStream = True
            Dataline = GcodeFile.ReadLine
            LineCount += 1
            If InStr(Dataline, ";LAYER:") > 0 Then LayerCounter = Strings.Right(Dataline, Len(Dataline) - 7)
            If Strings.Left(Dataline, 2) = "M0" Or Strings.Left(Dataline, 3) = "M25" Then
                Do Until InStr(1, Dataline, ";LAYER:") > 0
                    Dataline = GcodeFile.ReadLine
                    If InStr(Dataline, ";LAYER:") > 0 Then LayerCounter = Strings.Right(Dataline, Len(Dataline) - 7)
                Loop
                LayerArray(PauseCount) = CInt(Strings.Right(Dataline, Len(Dataline) - 7))
                PauseCount += 1
                ReDim Preserve LayerArray(PauseCount)
            End If
        Loop
        ReDim Preserve layerArray(PauseCount - 1)
        PauseCount -= 1
        If PauseCount = -1 Then
            MsgBox("No Pauses were found in the file." & vbCr & "There are " & CDbl(LayerCounter) + 1 & " layers.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim Pauses As Integer
        Dim PauseText As String = ""
        For Pauses = 0 To PauseCount
            PauseText &= "#" & Pauses + 1 & ": at Layer: " & CStr(LayerArray(Pauses)) & vbCr
        Next
        MsgBox("Pauses in the file:" & vbCr & vbCr & PauseText & vbCr & "There are " & CDbl(LayerCounter) + 1 & " layers.", vbOKOnly, "Greg's Toolbox")
        GcodeFile.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        Dim LayerCounter As String = "0"
        Dim ImportFileName As String = Me.SecondFilePathNameBox.Text
        Dim GcodeFile As System.IO.StreamReader
        AResponse = MsgBox("This command searches for M0 and M25 only." & vbCr & vbCr & "Do you want to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub

        If ImportFileName = "" Then
            ImportFileName = Me.GetFileName("Second")
        End If
        If ImportFileName = "" Then Exit Sub
        GcodeFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim LayerArray() As Integer
        ReDim LayerArray(0)
        Dim PauseCount = 0
        Dim Dataline As String
        Dim PrintTime = 0
        Dim Start = False
        Dim LineCount = 0
        Do Until GcodeFile.EndOfStream = True
            Dataline = GcodeFile.ReadLine
            LineCount += 1
            If InStr(Dataline, ";LAYER:") > 0 Then LayerCounter = Strings.Right(Dataline, Len(Dataline) - 7)
            If Strings.Left(Dataline, 2) = "M0" Or Strings.Left(Dataline, 3) = "M25" Then
                Do Until InStr(1, Dataline, ";LAYER:") > 0
                    Dataline = GcodeFile.ReadLine
                    If InStr(Dataline, ";LAYER:") > 0 Then LayerCounter = Strings.Right(Dataline, Len(Dataline) - 7)
                Loop
                LayerArray(PauseCount) = CInt(Strings.Right(Dataline, Len(Dataline) - 7))
                PauseCount += 1
                ReDim Preserve LayerArray(PauseCount)
            End If
        Loop
        ReDim Preserve LayerArray(PauseCount - 1)
        PauseCount -= 1
        If PauseCount = -1 Then
            MsgBox("No Pauses were found in the file." & vbCr & "There are " & CDbl(LayerCounter) + 1 & " layers.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim Pauses As Integer
        Dim PauseText As String = ""
        For Pauses = 0 To PauseCount
            PauseText &= "#" & Pauses + 1 & ": at Layer: " & CStr(LayerArray(Pauses)) & vbCr
        Next
        MsgBox("Pauses in the file:" & vbCr & vbCr & PauseText & vbCr & "There are " & CDbl(LayerCounter) + 1 & " layers.", vbOKOnly, "Greg's Toolbox")
        GcodeFile.Close()
    End Sub
End Class