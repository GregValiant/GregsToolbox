Attribute VB_Name = "CommandModule"

Sub SendTheString(StrToSend)
On Error GoTo ErrHandler
    VCommForm.VComm.Output = StrToSend & vbLf
Exit Sub
ErrHandler:
MsgBox "The Message """ & StrToSend & """ caused an Error:" & vbCr & Err.Description, vbOKOnly + vbCritical, "Stoopid Engineering"
End Sub

Sub ParseTheStringSteps()
On Error Resume Next
thestring = PrinterComForm.TextBox1.Value
If Left(thestring, 4) <> "M503" Then
    MsgBox "The Printer Response box line #1 must be ""M503"" to parse through the settings.", vbOKOnly + vbInformation, "Stoopid Engineering"
    Exit Sub
End If
TheFirst = InStr(1, thestring, "M92", vbTextCompare)
If TheFirst = 0 Then
    MsgBox "There is a problem with the Printer Response box text string.  There must be an M92", vbOKOnly, "Stoopid Engineering"
    Exit Sub
End If
strlen = Len(thestring)
NewStr = Right(thestring, strlen - TheFirst - 3)
FinalLF = InStr(1, NewStr, vbLf, vbTextCompare)
NewStr = Left(NewStr, FinalLF)
X = InStr(1, NewStr, "X", vbTextCompare)
sp = InStr(1, NewStr, " ", vbTextCompare)
XStr = Left(NewStr, sp - 1)
XStr = Right(XStr, Len(XStr) - 1)
Cleanup = Right(NewStr, Len(NewStr) - sp)
Y = InStr(1, Cleanup, "Y", vbTextCompare)
sp = InStr(1, Cleanup, " ", vbTextCompare)
Ystr = Left(Cleanup, sp - 1)
Ystr = Right(Ystr, Len(Ystr) - 1)
Cleanup = Right(Cleanup, Len(Cleanup) - sp)
Z = InStr(1, Cleanup, "Z", vbTextCompare)
sp = InStr(1, Cleanup, " ", vbTextCompare)
ZStr = Left(Cleanup, sp - 1)
ZStr = Right(ZStr, Len(ZStr) - 1)
Cleanup = Right(Cleanup, Len(Cleanup) - sp)
E = InStr(1, Cleanup, "E", vbTextCompare)
sp = InStr(1, Cleanup, " ", vbTextCompare)
EStr = Left(Cleanup, sp - 1)
If Err <> 0 Then EStr = Cleanup
EStr = Right(EStr, Len(EStr) - 1)
Err.Clear
EStr = Application.WorksheetFunction.Clean(EStr)
With PrinterComForm
    .StepsE.Value = EStr
    .StepsX.Value = XStr
    .StepsY.Value = Ystr
    .StepsZ.Value = ZStr
End With
End Sub

Sub ParseTheStringPID()
On Error Resume Next
thestring = PrinterComForm.TextBox1.Value
If Left(thestring, 4) <> "M503" Then
    MsgBox "The Printer Response box line #1 must be ""M503"" to parse through the settings.", vbOKOnly, "Stoopid Engineering"
    Exit Sub
End If
TheFirst = InStr(1, thestring, "M301", vbTextCompare)
If TheFirst = 0 Then
    MsgBox "There is a problem with the text string in the Printer Response box.  There must be an M301.", vbOKOnly, "Stoopid Engineering"
    Exit Sub
End If
strlen = Len(thestring)
NewStr = Right(thestring, strlen - TheFirst - 3)
FinalLF = InStr(1, NewStr, vbLf, vbTextCompare)
NewStr = Left(NewStr, FinalLF)
P = InStr(1, NewStr, "P", vbTextCompare)
sp = InStr(P, NewStr, " ", vbTextCompare)
PStr = Left(NewStr, sp - 1)
PStr = Application.WorksheetFunction.Clean(PStr)
PStr = Right(PStr, Len(PStr) - P)

Cleanup = Right(NewStr, Len(NewStr) - sp)
i = InStr(1, Cleanup, "I", vbTextCompare)
sp = InStr(i, Cleanup, " ", vbTextCompare)
IStr = Left(Cleanup, sp - 1)
IStr = Right(IStr, Len(IStr) - 1)
Cleanup = Right(Cleanup, Len(Cleanup) - sp)
D = InStr(1, Cleanup, "D", vbTextCompare)
sp = InStr(D, Cleanup, " ", vbTextCompare)
DStr = Left(Cleanup, sp - 1)
If Err <> 0 Then DStr = Cleanup
Err.Clear
DStr = Application.WorksheetFunction.Clean(DStr)
DStr = Right(DStr, Len(DStr) - 1)
With PrinterComForm
    .PIDP.Value = PStr
    .PIDI.Value = IStr
    .PIDD.Value = DStr
End With
End Sub

Sub ParseTheStringOffset()
On Error Resume Next
thestring = PrinterComForm.TextBox1.Value
If Left(thestring, 4) <> "M503" Then
    MsgBox "The Printer Response box line #1 must be ""M503"" to parse through the settings.", vbOKOnly + vbInformation, "Stoopid Engineering"
    Exit Sub
End If
TheFirst = InStr(1, thestring, "M206", vbTextCompare)
If TheFirst = 0 Then
    MsgBox "There is a problem with the text string in the Printer Response box.  There must be an M206.", vbOKOnly + vbInformation, "Stoopid Engineering"
    Exit Sub
End If
strlen = Len(thestring)
NewStr = Right(thestring, strlen - TheFirst - 3)
FinalLF = InStr(1, NewStr, vbLf, vbTextCompare)
NewStr = Left(NewStr, FinalLF)
sp = InStr(1, NewStr, " ", vbTextCompare)
NewStr = Right(NewStr, Len(NewStr) - sp)
X = InStr(1, NewStr, "X", vbTextCompare)
sp = InStr(1, NewStr, " ", vbTextCompare)
XStr = Left(NewStr, sp - 1)
XStr = Right(XStr, Len(XStr) - 1)
Cleanup = Right(NewStr, Len(NewStr) - sp)
Y = InStr(1, Cleanup, "Y", vbTextCompare)
sp = InStr(1, Cleanup, " ", vbTextCompare)
Ystr = Left(Cleanup, sp - 1)
Ystr = Right(Ystr, Len(Ystr) - 1)
Cleanup = Right(Cleanup, Len(Cleanup) - sp)
Z = InStr(1, Cleanup, "Z", vbTextCompare)
ZStr = Right(Cleanup, Len(Cleanup) - 1)
ZStr = Application.WorksheetFunction.Clean(ZStr)
With PrinterComForm
    .OffsetXbox.Value = XStr
    .OffsetYbox.Value = Ystr
    .OffsetZbox.Value = ZStr
End With
End Sub

Function FormatTime(TotalTime)
    Hrs = "00"
    Mins = "00"
    Secs = "00.0"
        If TotalTime >= 3600 Then
            Hrs = Format(Int(TotalTime / 3600), "00")
            TotalTime = TotalTime - (Hrs * 3600)
        End If
        If TotalTime >= 60 Then
            Mins = Format(Int(TotalTime / 60), "00")
            TotalTime = TotalTime - (Mins * 60)
        End If
        Secs = Format(TotalTime, "00.0")
        FormatTime = Hrs & ":" & Mins & ":" & Secs
If Secs < 0 Then
    MsgBox "The time indicated is in error.  Please enter a valid layer and Z height.", vbOKOnly, "Stooid Engineering"
End If
End Function

Function FormatTotalHrs(TimeString)
If Val(Left(TimeString, 2)) >= 24 Then
    Daystamp = Int(Left(TimeString, 2) / 24)
    NewHrs = Val(Left(TimeString, 2)) - (Daystamp * 24)
    FormatTotalHrs = Daystamp & "d " & NewHrs & Right(TimeString, 8)
Else
    FormatTotalHrs = TimeString
End If
End Function

Sub FindByteLocation()
On Error GoTo TheHandler
If PrinterComForm.GCODE_FileNameBox.Value <> "" Then
    FileResponse = PrinterComForm.GCODE_FileNameBox.Value
    GoTo JumpStart
End If
FileResponse = Application.GetOpenFilename("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
If FileResponse = False Then
    Exit Sub
End If
JumpStart:
If PrinterComForm.GCODE_FileNameBox.Value = "" Then PrinterComForm.GCODE_FileNameBox.Value = FileResponse

ImportFileName = FileResponse
    Dim fs, f, ts, s
    Set fs = CreateObject("Scripting.FileSystemObject")

Set GCODE_File = fs.OpenTextFile(ImportFileName, 1, False)
Dim Counter As Long
Dim LineCount As Double
Dim DataLine As String
Dim PrevDataLine As String
Dim FileLength As String
Dim ZStr, Zpresent, ZPrev, Zretract
ZPrev = 0
Zretract = False
Counter = 0
LineCount = 1
Do While GCODE_File.atendofstream <> True
DataLine = GCODE_File.readline
    Zpresent = InStr(1, DataLine, " Z", vbTextCompare)
        If Zpresent > 0 Then
            ZStr = Right(DataLine, Len(DataLine) - Zpresent)
            Zpresent = InStr(1, ZStr, " ", vbTextCompare)
            On Error Resume Next
            ZStr = Left(ZStr, Zpresent - 1)
            ZStr = Right(ZStr, Len(ZStr) - 1)
        End If
    If ZPrev > ZStr And LineCount > 65 Then
    Zretract = True
    End If
Counter = Counter + Len(DataLine) + 2
    If Counter >= PrinterComForm.ByteCountBox.Value Then
        MsgBox "Byte " & PrinterComForm.ByteCountBox.Value & " is in line " & LineCount & ".  The Byte #, Byte Line Content, and Byte Line have been updated" & vbLf & "Current Z = " & ZStr, vbOKOnly + vbInformation, "Stoopid Engineering"
        PrinterComForm.ByteLineBox.Value = LineCount
        PrinterComForm.ByteContentBox.Value = DataLine
        PrinterComForm.GCODE_SizeBox.Value = FileLen(ImportFileName)
        PrinterComForm.ByteZBox.Value = ZStr
        GCODE_File.Close
        If Zretract = True Then
            MsgBox "Z-Hops were found in the file.  Double check the ""Current Z"" to make sure it wasn't just a Z-Hop height.", vbOKOnly + vbExclamation, "Stoopid Engineering"
        End If
        Exit Sub
    End If
PrevDataLine = DataLine
LineCount = LineCount + 1
ZPrev = ZStr
Loop
MsgBox "The end of the file was reached before the Byte was found.", vbOKOnly + vbCritical, "Stoopid Engineering"
GCODE_File.Close
Exit Sub
TheHandler:
MsgBox "An error occurred." & vbLf & Err.Description, vbOKOnly + vbCritical, "Stoopid Engineering"
End Sub

Sub FindLayerByte()
On Error GoTo TheHandler
Dim FileResponse
If PrinterComForm.GCODE_FileNameBox.Value <> "" Then
    FileResponse = PrinterComForm.GCODE_FileNameBox.Value
    GoTo JumpStart
End If

FileResponse = Application.GetOpenFilename("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
If FileResponse = False Then
    Exit Sub
End If
JumpStart:
If PrinterComForm.GCODE_FileNameBox.Value = "" Then PrinterComForm.GCODE_FileNameBox.Value = FileResponse

ImportFileName = FileResponse
    Dim fs, f, ts, s
    Set fs = CreateObject("Scripting.FileSystemObject")

Set GCODE_File = fs.OpenTextFile(ImportFileName, 1, False)

Dim Counter As Long
Dim LineCount As Double
Dim DataLine As String
Dim MyLayer As String
Dim SearchLayer As Integer
Dim TheZ, Zpresent, ZPrev, Zretract
Zretract = False
ZPrev = 0
Counter = 0
LineCount = 0
If PrinterComForm.LayerIsG.Value = True Then
    SearchLayer = PrinterComForm.ByteLayerSearchBox.Value
ElseIf PrinterComForm.LayerIsC.Value = True Then
    SearchLayer = Val(PrinterComForm.ByteLayerSearchBox.Value) - 1
End If
Do While GCODE_File.atendofstream <> True
DataLine = GCODE_File.readline
    Zpresent = InStr(1, DataLine, " Z", vbTextCompare)
        If Zpresent > 0 Then
            ZStr = Right(DataLine, Len(DataLine) - Zpresent)
            Zpresent = InStr(1, ZStr, " ", vbTextCompare)
            On Error Resume Next
            ZStr = Left(ZStr, Zpresent - 1)
            ZStr = Right(ZStr, Len(ZStr) - 1)
        End If
    If ZPrev > ZStr Then
    Zretract = True
    End If
    LineCount = LineCount + 1
    Counter = Counter + Len(DataLine) + 2
If InStr(1, DataLine, ";Layer:" & SearchLayer, vbTextCompare) Then
    PrinterComForm.ByteCountBox.Value = Counter
    PrinterComForm.ByteLineBox.Value = LineCount
    PrinterComForm.ByteContentBox.Value = DataLine
    PrinterComForm.ByteZBox.Value = ZStr
        MsgBox "Layer " & PrinterComForm.ByteLayerSearchBox.Value & " is at Byte " & PrinterComForm.ByteCountBox.Value & ".  The Byte #, Byte Line Content, and Byte Line have been updated" & vbLf & "Current Z = " & ZStr, vbOKOnly + vbInformation, "Stoopid Engineering"
    PrinterComForm.GCODE_SizeBox.Value = FileLen(ImportFileName)
    GCODE_File.Close
        If Zretract = True Then
            MsgBox "Z-Hops were found in the file.  Double check the ""Current Z"" to make sure it wasn't just a Z-Hop height.", vbOKOnly + vbExclamation, "Stoopid Engineering"
        End If
    Exit Sub
End If
ZPrev = ZStr
Loop
MsgBox "The end of the file was reached before the Layer # was found.", vbOKOnly + vbCritical, "Stoopid Engineering"
GCODE_File.Close
Exit Sub
TheHandler:
MsgBox "An error occurred." & vbLf & Err.Description & LineCount, vbOKOnly + vbCritical, "Stoopid Engineering"

End Sub

Sub FindLineByte()
On Error GoTo TheHandler
Dim FileResponse
If PrinterComForm.GCODE_FileNameBox.Value <> "" Then
    FileResponse = PrinterComForm.GCODE_FileNameBox.Value
    GoTo JumpStart
End If
FileResponse = Application.GetOpenFilename("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
If FileResponse = False Then
    Exit Sub
End If
JumpStart:
If PrinterComForm.GCODE_FileNameBox.Value = "" Then PrinterComForm.GCODE_FileNameBox.Value = FileResponse
ImportFileName = FileResponse
    Dim fs, f, ts, s
    Set fs = CreateObject("Scripting.FileSystemObject")

Set GCODE_File = fs.OpenTextFile(ImportFileName, 1, False)

Dim Counter As Long
Dim LineCount As Double
Dim DataLine As String
Dim MyLine As String
Dim ZStr, Zpresent, ZPrev, Zretract
Zretract = False
ZPrev = 0
Counter = 0
LineCount = 0
MyLine = PrinterComForm.ByteLineSearchBox.Value
Do While GCODE_File.atendofstream <> True
DataLine = GCODE_File.readline
LineCount = LineCount + 1
    Counter = Counter + Len(DataLine) + 2
    Zpresent = InStr(1, DataLine, " Z", vbTextCompare)
        If Zpresent > 0 Then
            ZStr = Right(DataLine, Len(DataLine) - Zpresent)
            Zpresent = InStr(1, ZStr, " ", vbTextCompare)
            On Error Resume Next
            ZStr = Left(ZStr, Zpresent - 1)
            ZStr = Right(ZStr, Len(ZStr) - 1)
        End If
    If ZPrev > ZStr Then
        Zretract = True
    End If
If LineCount = MyLine Then
    PrinterComForm.ByteCountBox.Value = Counter
    PrinterComForm.ByteContentBox.Value = DataLine
    PrinterComForm.ByteLineBox.Value = LineCount
    PrinterComForm.ByteZBox.Value = ZStr
        MsgBox "File Name: " & PrinterComForm.GCODE_FileNameBox.Value & vbLf & vbLf & "Line # " & PrinterComForm.ByteLineSearchBox.Value & " is at Byte " & PrinterComForm.ByteCountBox.Value & ".  The Byte #, Byte Line Content, and Byte Line have been updated." & vbLf & "Current Z = " & ZStr, vbOKOnly + vbInformation, "Stoopid Engineering"
    PrinterComForm.GCODE_SizeBox.Value = FileLen(ImportFileName)
    GCODE_File.Close
    If Zretract = True Then
        MsgBox "Z-Hops were found in the file.  Double check the ""Current Z"" to make sure it wasn't just a Z-Hop height.", vbOKOnly + vbExclamation, "Stoopid Engineering"
    End If

    Exit Sub
End If
ZPrev = ZStr
Loop
MsgBox "The end of the file was reached before the Layer # was found.", vbOKOnly + vbExclamation, "Stoopid Engineering"
GCODE_File.Close
Exit Sub
TheHandler:
MsgBox "An error occurred." & vbLf & Err.Description, vbOKOnly + vbCritical, "Stoopid Engineering"

End Sub

Sub GetAdjacentLines()
On Error GoTo TheHandler
If Val(PrinterComForm.ByteLineBox.Value) < 16 Then
    MsgBox "The line number cannot be less than 16.", vbOKOnly, "Stoopid Engineering"
    Exit Sub
End If

Dim FileResponse

If PrinterComForm.GCODE_FileNameBox.Value <> "" Then
    FileResponse = PrinterComForm.GCODE_FileNameBox.Value
    GoTo JumpStart
End If

If PrinterComForm.ByteLineBox.Value = "" Then
    MsgBox "There is no line number", vbOKOnly + vbExclamation, "Stoopid Engineering"
    Exit Sub
End If
FileResponse = Application.GetOpenFilename("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
If FileResponse = False Then
    Exit Sub
End If
JumpStart:
If PrinterComForm.GCODE_FileNameBox.Value = "" Then PrinterComForm.GCODE_FileNameBox.Value = FileResponse
ImportFileName = FileResponse
    Dim fs, f, ts, s
    Set fs = CreateObject("Scripting.FileSystemObject")

Set GCODE_File = fs.OpenTextFile(ImportFileName, 1, False)

Dim Counter As Long
Dim LineCount As Double
Dim DataLine As String
Dim MyLine As String
Dim LineM15, LineM14, LineM13, LineM12, LineM11, LineM10, LineM9, LineM8, LineM7, LineM6, LineM5, LineM4, LineM3, LineM2, LineM1
Dim LineP1, LineP2, LineP3, LineP4, LineP5, LineP6, LineP7, LineP8, LineP9, LineP10, LineP11, LineP12, LineP13, LineP14, LineP15
Dim Line0

Counter = 0
LineCount = 0
MyLine = PrinterComForm.ByteLineSearchBox.Value
Do While GCODE_File.atendofstream <> True
LineCount = LineCount + 1
DataLine = GCODE_File.readline
    If LineCount = Val(PrinterComForm.ByteLineBox.Value) - 15 Then
        On Error Resume Next
        LineM15 = DataLine
        LineM14 = GCODE_File.readline
        LineM13 = GCODE_File.readline
        LineM12 = GCODE_File.readline
        LineM11 = GCODE_File.readline
        LineM10 = GCODE_File.readline
        LineM9 = GCODE_File.readline
        LineM8 = GCODE_File.readline
        LineM7 = GCODE_File.readline
        LineM6 = GCODE_File.readline
        LineM5 = GCODE_File.readline
        LineM4 = GCODE_File.readline
        LineM3 = GCODE_File.readline
        LineM2 = GCODE_File.readline
        LineM1 = GCODE_File.readline
        Line0 = GCODE_File.readline
        LineP1 = GCODE_File.readline
        LineP2 = GCODE_File.readline
        LineP3 = GCODE_File.readline
        LineP4 = GCODE_File.readline
        LineP5 = GCODE_File.readline
        LineP6 = GCODE_File.readline
        LineP7 = GCODE_File.readline
        LineP8 = GCODE_File.readline
        LineP9 = GCODE_File.readline
        LineP10 = GCODE_File.readline
        LineP11 = GCODE_File.readline
        LineP12 = GCODE_File.readline
        LineP13 = GCODE_File.readline
        LineP14 = GCODE_File.readline
        LineP15 = GCODE_File.readline
            PrinterComForm.TextBox1.Value = _
        PrinterComForm.ByteLineBox.Value - 15 & ") " & LineM15 & vbLf & PrinterComForm.ByteLineBox.Value - 14 & ") " & LineM14 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 13 & ") " & LineM13 & vbLf & PrinterComForm.ByteLineBox.Value - 12 & ") " & LineM12 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 11 & ") " & LineM11 & vbLf & PrinterComForm.ByteLineBox.Value - 10 & ") " & LineM10 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 9 & ") " & LineM9 & vbLf & PrinterComForm.ByteLineBox.Value - 8 & ") " & LineM8 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 7 & ") " & LineM7 & vbLf & PrinterComForm.ByteLineBox.Value - 6 & ") " & LineM6 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 5 & ") " & LineM5 & vbLf & PrinterComForm.ByteLineBox.Value - 4 & ") " & LineM4 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 3 & ") " & LineM3 & vbLf & PrinterComForm.ByteLineBox.Value - 2 & ") " & LineM2 & vbLf & _
        PrinterComForm.ByteLineBox.Value - 1 & ") " & LineM1 & vbLf & vbLf & _
        PrinterComForm.ByteLineBox.Value & ") " & Line0 & vbLf & vbLf & _
        PrinterComForm.ByteLineBox.Value + 1 & ") " & LineP1 & vbLf & PrinterComForm.ByteLineBox.Value + 2 & ") " & LineP2 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 3 & ") " & LineP3 & vbLf & PrinterComForm.ByteLineBox.Value + 4 & ") " & LineP4 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 5 & ") " & LineP5 & vbLf & PrinterComForm.ByteLineBox.Value + 6 & ") " & LineP6 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 7 & ") " & LineP7 & vbLf & PrinterComForm.ByteLineBox.Value + 8 & ") " & LineP8 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 9 & ") " & LineP9 & vbLf & PrinterComForm.ByteLineBox.Value + 10 & ") " & LineP10 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 11 & ") " & LineP11 & vbLf & PrinterComForm.ByteLineBox.Value + 12 & ") " & LineP12 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 13 & ") " & LineP13 & vbLf & PrinterComForm.ByteLineBox.Value + 14 & ") " & LineP14 & vbLf & _
        PrinterComForm.ByteLineBox.Value + 15 & ") " & LineP15
        
        GCODE_File.Close
        Exit Sub
    End If
Loop
MsgBox "The Line number wasn't found", vbOKOnly + vbCritical, "Stoopid Engineering"
GCODE_File.Close
Exit Sub
TheHandler:
MsgBox "There was an error" & vbLf & Err.Description, vbOKOnly + vbCritical, "Stoopid Engineering"
End Sub

Sub Kill_Time()
PrinterComForm.CBGetTempContButt.Value = False
End Sub
