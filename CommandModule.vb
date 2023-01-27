Module CommandModule
    Public Resume_X_Start As String
    Public Resume_Y_Start As String
    Public Resume_E_Start As String
    Public Resume_Z_Start As String

    Sub FindLayerByte()
        On Error GoTo TheHandler
        Dim FileResponse As String
        Dim OpenResponse As DialogResult
        Dim Importfilename As String
        Dim theCompleteFile As String
        If EnderMainForm.GCODE_FileNameBox.Text <> "" Then
            FileResponse = EnderMainForm.GCODE_FileNameBox.Text
            GoTo JumpStart
        End If
        EnderMainForm.OpenFileDialog1.Title = "Open a GCODE file to search"
        EnderMainForm.OpenFileDialog1.Filter = "GCODE Files|*.gcode"
        EnderMainForm.OpenFileDialog1.FilterIndex = 1
        EnderMainForm.OpenFileDialog1.DefaultExt = "gcode"
        EnderMainForm.OpenFileDialog1.FileName = ""
        OpenResponse = EnderMainForm.OpenFileDialog1.ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
        If OpenResponse = 2 Then
            Return 'Exit Sub
        End If
JumpStart:
        Cursor.Current = Cursors.WaitCursor
        'EnderMainForm.Refresh()
        FileResponse = EnderMainForm.OpenFileDialog1.FileName
        TheSlicer = FindSlicer(FileResponse)
        EnderMainForm.SlicerBox.Text = TheSlicer
        EnderMainForm.LayerSearchStrBox.Text = LayerSearchStr
        EnderMainForm.GCODE_SizeBox.Text = Format(FileLen(FileResponse), "0,000")
        If EnderMainForm.GCODE_FileNameBox.Text = "" Then EnderMainForm.GCODE_FileNameBox.Text = FileResponse
        Importfilename = FileResponse
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(Importfilename)
        Dim Counter As Long
        Dim LineCount As Double
        Dim DataLine As String = ""
        Dim MyLayer As String
        Dim SearchLayer As String
        Dim LayerCounter = 0
        Dim KissIndex = -1
        Dim zSpace = 0
        Dim TheZ As Integer
        Dim Zpresent As Integer, ZPrev As String, Zstr As String
        Dim Progindex As Long
        Dim LayerString As String
        Dim Slicr_Layer_Hgt As Double = 0
        Progindex = 0
        Zstr = "0"
        Dim Xloc As Integer
        Dim Yloc As Integer
        Dim Zloc As Integer
        Dim Eloc As Integer
        Resume_X_Start = "0"
        Resume_Y_Start = "0"
        Resume_Z_Start = "0"
        Resume_E_Start = "0"
        EnderMainForm.ProgressBar1.Visible = True
        Dim Zretract As Boolean = False
        ZPrev = "0"
        Counter = 0
        LineCount = 0
        If EnderMainForm.LayerIsG.Checked = True Then
            SearchLayer = EnderMainForm.ByteLayerSearchBox.Text
        ElseIf EnderMainForm.LayerIsC.Checked = True And (TheSlicer = "Cura" Or TheSlicer = "ideaMaker" Or TheSlicer = "Unknown") Then
            SearchLayer = CStr(CLng(EnderMainForm.ByteLayerSearchBox.Text) - 1)
        Else
            SearchLayer = EnderMainForm.ByteLayerSearchBox.Text
        End If
        If TheSlicer = "Slic3r" Then
            Do Until Left(DataLine, 3) = "M82"
                DataLine = GCODE_File_R.ReadLine
                LineCount += 1
                Counter += Len(DataLine) + 2
            Loop
        End If
        Do While GCODE_File_R.EndOfStream <> True
            DataLine = GCODE_File_R.ReadLine
            Zpresent = InStr(1, DataLine, " Z")
            If Zpresent > 0 And Left(DataLine, 1) <> ";" And Left(DataLine, 1) <> "M" Then
                Zstr = Right(DataLine, Len(DataLine) - Zpresent - 1)
                Zpresent = InStr(1, Zstr, " ")
                On Error Resume Next
                If TheSlicer = "Slic3r" And Slicr_Layer_Hgt = 0 Then
                    Zstr = Left(Zstr, Zpresent - 1)
                    LayerSearchStr &= Format(CLng(Zstr) * CInt(SearchLayer), "0.000")
                    SearchLayer = "0"
                    SearchLayer = Format(Convert.ToString(SearchLayer), "")
                    SearchLayer = ""
                    Slicr_Layer_Hgt = CDbl(Zstr)
                End If
                If TheSlicer = "KISSlicer" Then
                    LayerCounter = CInt(SearchLayer)
                    SearchLayer = "0"
                    SearchLayer = Format(Convert.ToString(SearchLayer), "")
                    SearchLayer = ""
                End If
                Zstr = Left(Zstr, Zpresent - 1)
            End If
ZFound:
            If LineCount > 50 Then
                If Zstr < ZPrev And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    Zretract = False
                    ZPrev = Zstr
                ElseIf Zstr > ZPrev And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    Zretract = True
                End If
                If Strings.Left(DataLine, 2) = "G0" Or Strings.Left(DataLine, 2) = "G1" Then
                    Xloc = InStr(DataLine, " X")
                    If Xloc > 0 Then Resume_X_Start = FileOnFileForm.GetXValue(DataLine, Xloc)
                    Yloc = InStr(DataLine, " Y")
                    If Yloc > 0 Then Resume_Y_Start = FileOnFileForm.GetYValue(DataLine, Yloc)
                    Zloc = InStr(DataLine, " Z")
                    If Zloc > 0 And Xloc > 0 And Yloc > 0 Then
                        Resume_Z_Start = FileOnFileForm.GetZValue(DataLine, Zloc)
                    End If
                    Eloc = InStr(DataLine, " E")
                    If Eloc > 0 Then Resume_E_Start = FileOnFileForm.GetEValue(DataLine, Eloc)
                End If
                If Strings.Left(DataLine, 2) = "G92" Then
                    Eloc = InStr(DataLine, " E")
                    If Eloc > 0 Then Resume_E_Start = FileOnFileForm.GetEValue(DataLine, Eloc)
                End If
            End If
            Progindex += 1
            If Progindex = 250 Then
                EnderMainForm.ProgressBar1.PerformStep()
                If EnderMainForm.ProgressBar1.Value = EnderMainForm.ProgressBar1.Maximum Then EnderMainForm.ProgressBar1.Value = 0
                EnderMainForm.ProgressBar1.Refresh()
                Progindex = 0
            End If
            LineCount += 1
            Counter += Len(DataLine) + 2
            If InStr(DataLine, LayerSearchStr & SearchLayer) > 0 Then
                If TheSlicer = "KISSlicer" Then
                    KissIndex += 1
                    If LayerCounter > KissIndex Then
                        GoTo JumpOut
                    Else
                        TheZ = InStr(1, DataLine, "Z")
                        zSpace = InStr(TheZ, DataLine, " ")
                        Zstr = Mid(DataLine, TheZ + 2, zSpace - TheZ - 2)
                    End If
                End If
                EnderMainForm.ByteCountBox.Text = CStr(Counter)
                EnderMainForm.ByteLineBox.Text = CStr(LineCount)
                EnderMainForm.ByteContentBox.Text = DataLine
                If TheSlicer = "Simplify3D" Then
                    zSpace = InStr(1, DataLine, "Z")
                    Zstr = Right(DataLine, Len(DataLine) - zSpace - 3)
                End If
                EnderMainForm.ByteZBox.Text = Zstr
                MsgBox("Layer " & EnderMainForm.ByteLayerSearchBox.Text & " Is at Byte " & EnderMainForm.ByteCountBox.Text & ".  The Byte #, Byte Line Content, And Byte Line have been updated" & vbLf & "Current Z = " & Zstr, CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                EnderMainForm.GCODE_SizeBox.Text = Format(FileLen(Importfilename), "0, 0")
                GCODE_File_R.Close()
                If Zretract = True Then
                    MsgBox("The current Z (" & Zstr & ") appears to be a Z-Hop height.", CType(vbOKOnly + vbExclamation, MsgBoxStyle), "Greg's Toolbox")
                End If
                EnderMainForm.ProgressBar1.Value = 0
                EnderMainForm.ProgressBar1.Visible = False
                EnderMainForm.LayerSearchStrBox.Text = LayerSearchStr
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
            ZPrev = Zstr
JumpOut:
        Loop
        EnderMainForm.ProgressBar1.Value = 0
        EnderMainForm.ProgressBar1.Visible = False
        MsgBox("The end of the file was reached before the Layer # was found.", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        GCODE_File_R.Close()
        Cursor.Current = Cursors.Default
        Exit Sub
TheHandler:
        Cursor.Current = Cursors.Default
        MsgBox("An error occurred in ""CommandModule.FindLayerByte""." & vbLf & Err.Description & LineCount, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Sub FindLineByte()
        On Error GoTo TheHandler
        Dim FileResponse As DialogResult
        Dim ImportFileName As String
        Dim ProgIndex As Integer
        Dim LayerString As String
        ProgIndex = 0
        If EnderMainForm.GCODE_FileNameBox.Text <> "" Then
            ImportFileName = EnderMainForm.GCODE_FileNameBox.Text
            GoTo JumpStart
        End If
        EnderMainForm.OpenFileDialog1.Title = "Open a GCODE file to search"
        EnderMainForm.OpenFileDialog1.Filter = "GCODE Files|*.gcode"
        EnderMainForm.OpenFileDialog1.FilterIndex = 1
        EnderMainForm.OpenFileDialog1.DefaultExt = "gcode"
        EnderMainForm.OpenFileDialog1.FileName = ""
        FileResponse = EnderMainForm.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        ImportFileName = EnderMainForm.OpenFileDialog1.FileName
JumpStart:
        Cursor.Current = Cursors.WaitCursor
        EnderMainForm.SlicerBox.Text = ""
        EnderMainForm.LayerSearchStrBox.Text = ""
        If EnderMainForm.GCODE_FileNameBox.Text = "" Then EnderMainForm.GCODE_FileNameBox.Text = ImportFileName
        EnderMainForm.GCODE_SizeBox.Text = Format(FileLen(ImportFileName), "0,000")
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        EnderMainForm.ProgressBar1.Visible = True
        Dim Counter As Long
        Dim LineCount As Double
        Dim DataLine As String
        Dim MyLine As String
        Dim ZStr As String, Zpresent As Integer, ZPrev As String, Zretract As Boolean
        Zretract = False
        ZPrev = "0"
        Counter = 0
        LineCount = 0
        ZStr = "0"
        MyLine = EnderMainForm.ByteLineSearchBox.Text
        Do While GCODE_File_R.EndOfStream <> True
            DataLine = GCODE_File_R.ReadLine
            LineCount += 1
            Counter = Counter + Len(DataLine) + 2
            Zpresent = InStr(DataLine, " Z")

            If Zpresent > 0 And Left(DataLine, 1) <> ";" And Left(DataLine, 1) <> "M" Then
                ZStr = (Right(DataLine, Len(DataLine) - Zpresent - 1))
                Zpresent = InStr(1, ZStr, " ")
                On Error Resume Next
                ZStr = Left(ZStr, Zpresent - 1)
            End If
            If LineCount > 50 Then
                If ZStr < ZPrev And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    Zretract = False
                    ZPrev = ZStr
                ElseIf ZStr > ZPrev And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    Zretract = True
                End If
            End If
            ProgIndex += 1
            ProgIndex += 1

            If ProgIndex = 250 Then
                EnderMainForm.ProgressBar1.PerformStep()
                If EnderMainForm.ProgressBar1.Value = EnderMainForm.ProgressBar1.Maximum Then EnderMainForm.ProgressBar1.Value = 0
                EnderMainForm.ProgressBar1.Refresh()
                ProgIndex = 0
            End If
            If LineCount = CDbl(MyLine) Then
                EnderMainForm.ByteCountBox.Text = CStr(Counter)
                EnderMainForm.ByteContentBox.Text = DataLine
                EnderMainForm.ByteLineBox.Text = CStr(LineCount)
                EnderMainForm.ByteZBox.Text = ZStr
                MsgBox("File Name: " & EnderMainForm.GCODE_FileNameBox.Text & vbLf & vbLf & "Line # " & EnderMainForm.ByteLineSearchBox.Text & " is at Byte " & EnderMainForm.ByteCountBox.Text & ".  The Byte #, Byte Line Content, and Byte Line have been updated." & vbLf & "Current Z = " & ZStr, CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                EnderMainForm.GCODE_SizeBox.Text = Format(FileLen(ImportFileName), "0,000")
                GCODE_File_R.Close()
                If Zretract = True Then
                    MsgBox("The current Z height (" & ZStr & ") appears to be a Z-Hop.", CType(vbOKOnly + vbExclamation, MsgBoxStyle), "Greg's Toolbox")
                End If
                EnderMainForm.ProgressBar1.Value = 0
                EnderMainForm.ProgressBar1.Visible = False
                Exit Sub
            End If
            ZPrev = ZStr
        Loop
        EnderMainForm.ProgressBar1.Value = 0
        EnderMainForm.ProgressBar1.Visible = False
        MsgBox("The end of the file was reached before the Line # was found.", CType(vbOKOnly + vbExclamation, MsgBoxStyle), "Greg's Toolbox")
        GCODE_File_R.Close()
        Cursor.Current = Cursors.Default
        Exit Sub
TheHandler:
        Cursor.Current = Cursors.Default
        MsgBox("An error occurred in ""CommandModule.FindLineByte""." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub
    Sub FindByteLocation()
        On Error GoTo TheHandler
        Dim FileResponse As DialogResult
        Dim ImportFileName As String
        If EnderMainForm.GCODE_FileNameBox.Text <> "" Then
            ImportFileName = EnderMainForm.GCODE_FileNameBox.Text
            GoTo JumpStart
        End If
        EnderMainForm.OpenFileDialog1.Title = "Open a GCODE file to search"
        EnderMainForm.OpenFileDialog1.Filter = "GCODE Files|*.gcode"
        EnderMainForm.OpenFileDialog1.FilterIndex = 1
        EnderMainForm.OpenFileDialog1.DefaultExt = "gcode"
        EnderMainForm.OpenFileDialog1.FileName = ""
        FileResponse = EnderMainForm.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        ImportFileName = EnderMainForm.OpenFileDialog1.FileName
JumpStart:
        Cursor.Current = Cursors.WaitCursor
        If EnderMainForm.GCODE_FileNameBox.Text = "" Then EnderMainForm.GCODE_FileNameBox.Text = ImportFileName
        EnderMainForm.GCODE_SizeBox.Text = Format(FileLen(ImportFileName), "0,000")
        Dim TheSlicer As String = FindSlicer(ImportFileName)
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)

        Dim Counter As Long
        Dim LineCount As Long
        Dim DataLine As String
        Dim PrevDataLine As String
        Dim FileLength As String
        Dim ZStr As String, Zpresent As Long, ZPrev As String, Zretract As Boolean
        Dim zSpace As Long
        Dim ProgIndex As Integer
        Dim KissIndex = 0
        Dim TheZ As Single
        Dim LayerCounter = 0
        ProgIndex = 0
        ZPrev = "0"
        Zretract = False
        Counter = 0
        ZStr = "0"
        EnderMainForm.ProgressBar1.Visible = True
        LineCount = 1
        Do While GCODE_File_R.EndOfStream <> True
            DataLine = GCODE_File_R.ReadLine
            Zpresent = InStr(DataLine, " Z")
            If Zpresent > 0 Then
                ZStr = Right(DataLine, CInt(Len(DataLine) - Zpresent))
                Zpresent = InStr(1, ZStr, " ")
                On Error Resume Next
                ZStr = Left(ZStr, CInt(Zpresent - 1))
                ZStr = Right(ZStr, Len(ZStr) - 1)
            End If
            ProgIndex += 1
            If ProgIndex = 250 Then
                EnderMainForm.ProgressBar1.PerformStep()
                If EnderMainForm.ProgressBar1.Value = EnderMainForm.ProgressBar1.Maximum Then EnderMainForm.ProgressBar1.Value = 0
                EnderMainForm.ProgressBar1.Refresh()
                ProgIndex = 0
            End If
            If LineCount > 65 Then
                If ZStr < ZPrev And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    Zretract = False
                    ZPrev = ZStr
                ElseIf ZStr > ZPrev And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    Zretract = True
                End If
            End If
            Counter = Counter + Len(DataLine) + 2

            If Counter >= CLng(EnderMainForm.ByteCountBox.Text) Then
                If TheSlicer = "KISSlicer" Then
                    KissIndex += 1
                    If LayerCounter > KissIndex Then
                        GoTo JumpOut
                    Else
                        TheZ = InStr(1, DataLine, "Z")
                        ZStr = Strings.Right(DataLine, CInt(Len(DataLine) - TheZ))
                        zSpace = Strings.InStr(DataLine, " ")
                        ZStr = Mid(DataLine, CInt(TheZ + 2), CInt(zSpace - TheZ - 2))
                    End If
                End If
                If TheSlicer = "Simplify3D" Then
                    zSpace = InStr(1, DataLine, "Z")
                    ZStr = Right(DataLine, Len(DataLine) - CInt(zSpace) - 3)
                End If
                MsgBox("Byte " & EnderMainForm.ByteCountBox.Text & " is in line " & LineCount & ".  The Byte #, Byte Line Content, and Byte Line have been updated" & vbLf & "Current Z = " & ZStr, CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                EnderMainForm.ByteLineBox.Text = CStr(LineCount)
                EnderMainForm.ByteContentBox.Text = DataLine
                EnderMainForm.GCODE_SizeBox.Text = Format(FileLen(ImportFileName), "0,000")
                EnderMainForm.ByteZBox.Text = ZStr
                GCODE_File_R.Close()

                If Zretract = True Then
                    MsgBox("The Z height (" & ZStr & ") appears to be a Z-Hop", CType(vbOKOnly + vbExclamation, MsgBoxStyle), "Greg's Toolbox")
                End If
                EnderMainForm.ProgressBar1.Value = 0
                EnderMainForm.ProgressBar1.Visible = False
                Cursor.Current = Cursors.Default
                EnderMainForm.SlicerBox.Text = TheSlicer
                EnderMainForm.LayerSearchStrBox.Text = LayerSearchStr
                Exit Sub
            End If
            PrevDataLine = DataLine
            LineCount += 1
            ZPrev = ZStr
JumpOut:
        Loop
        EnderMainForm.ProgressBar1.Value = 0
        EnderMainForm.ProgressBar1.Visible = False
        MsgBox("The end of the file was reached before the Byte was found.", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        GCODE_File_R.Close()
        Cursor.Current = Cursors.Default
        Exit Sub
TheHandler:
        Cursor.Current = Cursors.Default
        MsgBox("An error occurred in ""CommandModule.FindByteLocation""." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub
    Sub GetAdjacentLines()
        On Error GoTo TheHandler
        If Val(EnderMainForm.ByteLineBox.Text) < 1 Then
            MsgBox("The line number cannot be less than 1.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim NumOfLine As Double = Val(EnderMainForm.ByteLineBox.Text)
        Dim FileResponse As DialogResult
        Dim ImportFileName As String

        If EnderMainForm.GCODE_FileNameBox.Text <> "" Then
            ImportFileName = EnderMainForm.GCODE_FileNameBox.Text
            GoTo JumpStart
        End If
        If EnderMainForm.ByteLineBox.Text = "" Then
            MsgBox("There is no line number", CType(vbOKOnly + vbExclamation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        EnderMainForm.OpenFileDialog1.Title = "Open a GCODE file to search"
        Const V As String = "GCODE Files (*.gcode) *.gcode"
        'EnderMainForm.OpenFILEDialog1.Filter()
        FileResponse = EnderMainForm.OpenFileDialog1.ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
        If FileResponse = 2 Then
            Exit Sub
        End If
        ImportFileName = EnderMainForm.OpenFileDialog1.FileName
JumpStart:
        Cursor.Current = Cursors.WaitCursor
        If EnderMainForm.GCODE_FileNameBox.Text = "" Then EnderMainForm.GCODE_FileNameBox.Text = ImportFileName
        GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)

        Dim Counter As Long
        Dim LineCount As Double
        Dim DataLine As String
        Dim MyLine As String
        Dim LineM15 As String, LineM14 As String, LineM13 As String, LineM12 As String, LineM11 As String, LineM10 As String, LineM9 As String, LineM8 As String, LineM7 As String, LineM6 As String, LineM5 As String, LineM4 As String, LineM3 As String, LineM2 As String, LineM1 As String
        Dim LineP1 As String, LineP2 As String, LineP3 As String, LineP4 As String, LineP5 As String, LineP6 As String, LineP7 As String, LineP8 As String, LineP9 As String, LineP10 As String, LineP11 As String, LineP12 As String, LineP13 As String, LineP14 As String, LineP15 As String
        Dim Line0 As String

        LineP1 = NumOfLine + 1 & ") "
        LineP2 = NumOfLine + 2 & ") "
        LineP3 = NumOfLine + 3 & ") "
        LineP4 = NumOfLine + 4 & ") "
        LineP5 = NumOfLine + 5 & ") "
        LineP6 = NumOfLine + 6 & ") "
        LineP7 = NumOfLine + 7 & ") "
        LineP8 = NumOfLine + 8 & ") "
        LineP9 = NumOfLine + 9 & ") "
        LineP10 = NumOfLine + 10 & ") "
        LineP11 = NumOfLine + 11 & ") "
        LineP12 = NumOfLine + 12 & ") "
        LineP13 = NumOfLine + 13 & ") "
        LineP14 = NumOfLine + 14 & ") "
        LineP15 = NumOfLine + 15 & ") "

        Counter = 0
        LineCount = 0
        MyLine = EnderMainForm.ByteLineSearchBox.Text
        Do While GCODE_File_R.EndOfStream <> True
            LineCount += 1
            DataLine = GCODE_File_R.ReadLine
            If LineCount - NumOfLine <= 1 Then
                On Error Resume Next
                If NumOfLine - 1 = 0 Then
                    Line0 = NumOfLine & ") " & DataLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 2 = 0 Then
                    LineM1 = NumOfLine - 1 & ") " & DataLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 3 = 0 Then
                    LineM2 = NumOfLine - 2 & ") " & DataLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 4 = 0 Then
                    LineM3 = NumOfLine - 3 & ") " & DataLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 5 = 0 Then
                    LineM4 = NumOfLine - 4 & ") " & DataLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 6 = 0 Then
                    LineM5 = NumOfLine - 5 & ") " & DataLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 7 = 0 Then
                    LineM6 = NumOfLine - 6 & ") " & DataLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 8 = 0 Then
                    LineM7 = NumOfLine - 7 & ") " & DataLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 9 = 0 Then
                    LineM8 = NumOfLine - 8 & ") " & DataLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 10 = 0 Then
                    LineM9 = NumOfLine - 9 & ") " & DataLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 11 = 0 Then
                    LineM10 = NumOfLine - 10 & ") " & DataLine & vbCrLf
                    LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 12 = 0 Then
                    LineM11 = NumOfLine - 11 & ") " & DataLine & vbCrLf
                    LineM10 = NumOfLine - 10 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 13 = 0 Then
                    LineM12 = NumOfLine - 12 & ") " & DataLine & vbCrLf
                    LineM11 = NumOfLine - 11 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM10 = NumOfLine - 10 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 14 = 0 Then
                    LineM13 = NumOfLine - 13 & ") " & DataLine & vbCrLf
                    LineM12 = NumOfLine - 12 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM11 = NumOfLine - 11 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM10 = NumOfLine - 10 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 15 = 0 Then
                    LineM14 = NumOfLine - 14 & ") " & DataLine & vbCrLf
                    LineM13 = NumOfLine - 13 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM12 = NumOfLine - 12 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM11 = NumOfLine - 11 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM10 = NumOfLine - 10 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                ElseIf NumOfLine - 16 = 0 Then
                    LineM15 = NumOfLine - 15 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM14 = NumOfLine - 14 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM13 = NumOfLine - 13 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM12 = NumOfLine - 12 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM11 = NumOfLine - 11 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM10 = NumOfLine - 10 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                    LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                    LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                    LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                    Exit Do
                End If
            End If
            If LineCount + 15 = NumOfLine Then
                LineM15 = NumOfLine - 15 & ") " & DataLine & vbCrLf
                LineM14 = NumOfLine - 14 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM13 = NumOfLine - 13 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM12 = NumOfLine - 12 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM11 = NumOfLine - 11 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM10 = NumOfLine - 10 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM9 = NumOfLine - 9 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM8 = NumOfLine - 8 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM7 = NumOfLine - 7 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM6 = NumOfLine - 6 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM5 = NumOfLine - 5 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM4 = NumOfLine - 4 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM3 = NumOfLine - 3 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM2 = NumOfLine - 2 & ") " & GCODE_File_R.ReadLine & vbCrLf
                LineM1 = NumOfLine - 1 & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                Line0 = NumOfLine & ") " & GCODE_File_R.ReadLine & vbCrLf & vbCrLf
                LineP1 &= GCODE_File_R.ReadLine & vbCrLf
                LineP2 &= GCODE_File_R.ReadLine & vbCrLf
                LineP3 &= GCODE_File_R.ReadLine & vbCrLf
                LineP4 &= GCODE_File_R.ReadLine & vbCrLf
                LineP5 &= GCODE_File_R.ReadLine & vbCrLf
                LineP6 &= GCODE_File_R.ReadLine & vbCrLf
                LineP7 &= GCODE_File_R.ReadLine & vbCrLf
                LineP8 &= GCODE_File_R.ReadLine & vbCrLf
                LineP9 &= GCODE_File_R.ReadLine & vbCrLf
                LineP10 &= GCODE_File_R.ReadLine & vbCrLf
                LineP11 &= GCODE_File_R.ReadLine & vbCrLf
                LineP12 &= GCODE_File_R.ReadLine & vbCrLf
                LineP13 &= GCODE_File_R.ReadLine & vbCrLf
                LineP14 &= GCODE_File_R.ReadLine & vbCrLf
                LineP15 &= GCODE_File_R.ReadLine & vbCrLf
                Exit Do
            End If
        Loop
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        EnderMainForm.TextBox1.Text =
                    LineM15 & LineM14 &
                    LineM13 & LineM12 &
                    LineM11 & LineM10 &
                    LineM9 & LineM8 &
                    LineM7 & LineM6 &
                    LineM5 & LineM4 &
                    LineM3 & LineM2 &
                    LineM1 &
                    Line0 &
                    LineP1 & LineP2 &
                    LineP3 & LineP4 &
                    LineP5 & LineP6 &
                    LineP7 & LineP8 &
                    LineP9 & LineP10 &
                    LineP11 & LineP12 &
                    LineP13 & LineP14 &
                    LineP15
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
        GCODE_File_R.Close()
        Cursor.Current = Cursors.Default
        Exit Sub
        MsgBox("The Line number wasn't found", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        GCODE_File_R.Close()
        Cursor.Current = Cursors.Default
        Exit Sub
TheHandler:
        MsgBox("There was an error in ""CommandModule.GetAdjacentLines""." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Sub ParseTheStringSteps()
        On Error Resume Next
        Dim TheString = EnderMainForm.TextBox1.Text
        If Left(TheString, 4) <> "M503" Then
            MsgBox("The Printer Response box line #1 must be ""M503"" to parse through the settings.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim TheFirst = InStr(1, TheString, "M92")
        If TheFirst = 0 Then
            MsgBox("There is a problem with the Printer Response box text string.  There must be an M92", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim strlen = Len(TheString)
        Dim NewStr = Microsoft.VisualBasic.Right(TheString, strlen - TheFirst - 3)
        Dim FinalLF = InStr(1, NewStr, vbLf)
        NewStr = Left(NewStr, FinalLF)
        Dim X = InStr(1, NewStr, "X")
        Dim sp = InStr(1, NewStr, " ")
        Dim XStr = Left(NewStr, sp - 1)
        XStr = Right(XStr, Len(XStr) - 1)
        Dim Cleanup = Right(NewStr, Len(NewStr) - sp)
        Dim Y = InStr(1, Cleanup, "Y")
        sp = InStr(1, Cleanup, " ")
        Dim Ystr = Left(Cleanup, sp - 1)
        Ystr = Right(Ystr, Len(Ystr) - 1)
        Cleanup = Right(Cleanup, Len(Cleanup) - sp)
        Dim Z = InStr(1, Cleanup, "Z")
        sp = InStr(1, Cleanup, " ")
        Dim ZStr = Left(Cleanup, sp - 1)
        ZStr = Right(ZStr, Len(ZStr) - 1)
        Cleanup = Right(Cleanup, Len(Cleanup) - sp)
        Dim E = InStr(1, Cleanup, "E")
        sp = InStr(1, Cleanup, " ")
        Dim EStr = Left(Cleanup, sp - 1)
        If Err.Number <> 0 Then EStr = Cleanup
        EStr = Right(EStr, Len(EStr) - 1)
        Err.Clear()
        Strings.Replace(Microsoft.VisualBasic.Left(EStr, 0), Environment.NewLine, String.Empty) 'EStr = Clean(EStr) '
        With PrinterSettings
            .StepsE.Text = EStr
            .StepsX.Text = XStr
            .StepsY.Text = Ystr
            .StepsZ.Text = ZStr
        End With
    End Sub

    Sub ParseTheStringOffset()
        On Error Resume Next
        Dim TheString = EnderMainForm.TextBox1.Text
        If Left(TheString, 4) <> "M503" Then
            MsgBox("The Printer Response box line #1 must be ""M503"" to parse through the settings.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim TheFirst = InStr(1, TheString, "M206")
        If TheFirst = 0 Then
            MsgBox("There is a problem with the text string in the Printer Response box.  There must be an M206.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim strlen = Len(TheString)
        Dim NewStr = Right(TheString, strlen - TheFirst - 3)
        Dim FinalLF = InStr(1, NewStr, vbLf)
        NewStr = Left(NewStr, FinalLF)
        Dim sp = InStr(1, NewStr, " ")
        NewStr = Right(NewStr, Len(NewStr) - sp)
        Dim X = InStr(1, NewStr, "X")
        sp = InStr(1, NewStr, " ")
        Dim XStr = Left(NewStr, sp - 1)
        XStr = Right(XStr, Len(XStr) - 1)
        Dim Cleanup = Right(NewStr, Len(NewStr) - sp)
        Dim Y = InStr(1, Cleanup, "Y")
        sp = InStr(1, Cleanup, " ")
        Dim Ystr = Left(Cleanup, sp - 1)
        Ystr = Right(Ystr, Len(Ystr) - 1)
        Cleanup = Right(Cleanup, Len(Cleanup) - sp)
        Dim Z = InStr(1, Cleanup, "Z")
        Dim ZStr = Right(Cleanup, Len(Cleanup) - 1)
        ZStr = Strings.Replace(ZStr, Environment.NewLine, String.Empty)
        With PrinterSettings
            .OffsetXbox.Text = XStr
            .OffsetYbox.Text = Ystr
            .OffsetZbox.Text = ZStr
        End With
    End Sub

    Sub ParseTheStringPID()
        On Error Resume Next
        Dim TheString = EnderMainForm.TextBox1.Text
        If Left(TheString, 4) <> "M503" Then
            MsgBox("The Printer Response box line #1 must be ""M503"" to parse through the settings.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim TheFirst = InStr(1, TheString, "M301")
        If TheFirst = 0 Then
            MsgBox("There is a problem with the text string in the Printer Response box.  There must be an M301.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim strlen = Len(TheString)
        Dim NewStr = Right(TheString, strlen - TheFirst - 3)
        Dim FinalLF = InStr(1, NewStr, vbLf)
        NewStr = Left(NewStr, FinalLF)
        Dim P = InStr(1, NewStr, "P")
        Dim sp = InStr(P, NewStr, " ")
        Dim PStr = Left(NewStr, sp - 1)
        PStr = Strings.Replace(PStr, Environment.NewLine, String.Empty)
        PStr = Right(PStr, Len(PStr) - P)
        Dim Cleanup = Right(NewStr, Len(NewStr) - sp)
        Dim i = InStr(1, Cleanup, "I")
        sp = InStr(i, Cleanup, " ")
        Dim IStr = Left(Cleanup, sp - 1)
        IStr = Right(IStr, Len(IStr) - 1)
        Cleanup = Right(Cleanup, Len(Cleanup) - sp)
        Dim D = InStr(1, Cleanup, "D")
        sp = InStr(D, Cleanup, " ")
        Dim DStr = Left(Cleanup, sp - 1)
        If Err.Number <> 0 Then DStr = Cleanup
        Err.Clear()
        DStr = Strings.Replace(DStr, Environment.NewLine, String.Empty)
        DStr = Right(DStr, Len(DStr) - 1)
        With PrinterSettings
            .PIDP.Text = PStr
            .PIDI.Text = IStr
            .PIDD.Text = DStr
        End With
    End Sub
End Module
