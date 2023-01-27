Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Security.AccessControl
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Public Class EnderMainForm
    Public NewRetractionDistance As String
    Public ScaleResponse As Boolean
    Public PathResponse As DialogResult
    Public ScriptResponse As String
    Public PrResponse As Boolean
    Public PathName As String
    Public CuraTitleBarInfo As String
    Public MyCura As Object

    Private Sub EnderMainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        Dim AResponse = MsgBox("Are you sure you want to exit?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then
            e.Cancel = True
            Exit Sub
        End If
        If Me.Vcomm.IsOpen Then
            If Me.CBGetTempContButt.Checked = True Then
                MsgBox("Continous Time Reporting is turned on.  It will be turned off and then you may exit again.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Me.CBGetTempContButt.Checked = False
                TheTimer.Enabled = False
                e.Cancel = True
                Exit Sub
            End If
            Call ClosePort()
        End If
        Me.Dispose()
    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        On Error Resume Next
        Dim AResponse = MsgBox("Are you sure you want to exit?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        If Me.Vcomm.IsOpen Then
            If Me.CBGetTempContButt.Checked = True Then
                MsgBox("Continous Time Reporting is turned on.  It will be turned off and then you may exit again.", CType(CType(vbOKOnly + vbInformation, MsgBoxStyle), MsgBoxStyle), "Greg's Toolbox")
                Me.CBGetTempContButt.Checked = False
                TheTimer.Enabled = False
                Exit Sub
            End If
            Call ClosePort()
        End If
        Me.Dispose()
    End Sub

    Private Sub ComPortManualCmdsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComPortManualCmdsToolStripMenuItem.Click
        On Error Resume Next
        With ComPanel
            .Left = 10
            .Top = 40
            .Width = 900
            .Height = 650
            .BringToFront()
            .Visible = True
        End With
        SDPrintPanel.Visible = False
        RecoveryPanel.Visible = False
        TuneUpPanel.Visible = False
        MovementPanel.Visible = False
        StatsPanel.Visible = False
    End Sub

    Private Sub PrintFromSDCardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintFromSDCardToolStripMenuItem.Click
        On Error Resume Next
        With SDPrintPanel
            .Left = 10
            .Top = 40
            .Width = 900
            .Height = 650
            .BringToFront()
            .Visible = True
        End With
        ComPanel.Visible = False
        RecoveryPanel.Visible = False
        TuneUpPanel.Visible = False
        MovementPanel.Visible = False
        StatsPanel.Visible = False
        If Me.EPrimeButt.Text = "Pr" Then Me.EPrimeButt.Text = "Pr " & My.Settings.PrimeAmt
        If Me.Box_E2.Text = "" Then Me.Box_E2.Text = My.Settings.ExtrudeAmt
        Me.HotLabel.Text = "(Hot End - " & Me.HeatBox.Text & "°)"
        Me.BedLabel.Text = "(Bed - " & Me.BedBox.Text & "°)"
    End Sub

    Private Sub RecoveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecoveryToolStripMenuItem.Click
        On Error Resume Next
        With RecoveryPanel
            .Left = 10
            .Top = 40
            .Width = 900
            .Height = 650
            .BringToFront()
            .Visible = True
        End With
        ComPanel.Visible = False
        SDPrintPanel.Visible = False
        TuneUpPanel.Visible = False
        MovementPanel.Visible = False
        StatsPanel.Visible = False
    End Sub

    Public Sub TuneUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TuneUpToolStripMenuItem.Click
        On Error Resume Next
        With TuneUpPanel
            .Left = 10
            .Top = 40
            .Width = 900
            .Height = 650
            .BringToFront()
            .Visible = True
        End With
        ComPanel.Visible = False
        SDPrintPanel.Visible = False
        RecoveryPanel.Visible = False
        MovementPanel.Visible = False
        StatsPanel.Visible = False
        Me.BedSend.Enabled = My.Settings.Heated_Bed
        Me.BedUpBut.Enabled = My.Settings.Heated_Bed
        Me.BedDnBut.Enabled = My.Settings.Heated_Bed
        Me.BedBox.Enabled = My.Settings.Heated_Bed
        Me.BedLabel.Visible = My.Settings.Heated_Bed
        With Me
            Select Case Val(My.Settings.NumOfExtruders)
                Case Is = 1
                    .HotEndActiveChk.Checked = True
                    .HotEndActiveChk.Enabled = False
                    .HotEnd1Check.Checked = False
                    .HotEnd1Check.Enabled = False
                    .HotEnd1Check.Visible = False
                    .HotEnd2Check.Checked = False
                    .HotEnd2Check.Enabled = False
                    .HotEnd2Check.Visible = False
                    .HotEnd3Check.Checked = False
                    .HotEnd3Check.Enabled = False
                    .HotEnd3Check.Visible = False
                    .HotEnd4Check.Checked = False
                    .HotEnd4Check.Enabled = False
                    .HotEnd4Check.Visible = False
                    .TuneButtonPanel.Height = 255
                    .T1But.Visible = False
                    .T1But2But.Visible = False
                    .T2But.Visible = False
                    .T2But2But.Visible = False
                    .T3But.Visible = False
                    .T3But2But.Visible = False
                    .T4But.Visible = False
                    .T4But2But.Visible = False
                Case Is = 2
                    .HotEndActiveChk.Checked = True
                    .HotEndActiveChk.Enabled = True
                    .HotEnd1Check.Checked = False
                    .HotEnd1Check.Enabled = True
                    .HotEnd1Check.Visible = True
                    .HotEnd2Check.Checked = False
                    .HotEnd2Check.Enabled = True
                    .HotEnd2Check.Visible = True
                    .HotEnd3Check.Checked = False
                    .HotEnd3Check.Enabled = False
                    .HotEnd3Check.Visible = False
                    .HotEnd4Check.Checked = False
                    .HotEnd4Check.Enabled = False
                    .HotEnd4Check.Visible = False
                    .TuneButtonPanel.Height = 300
                    .T1But.Visible = True
                    .T1But2But.Visible = True
                    .T2But.Visible = True
                    .T2But2But.Visible = True
                    .T3But.Visible = False
                    .T3But2But.Visible = False
                    .T4But.Visible = False
                    .T4But2But.Visible = False
                Case Is = 3
                    .HotEndActiveChk.Checked = True
                    .HotEndActiveChk.Enabled = True
                    .HotEnd1Check.Checked = False
                    .HotEnd1Check.Enabled = True
                    .HotEnd1Check.Visible = True
                    .HotEnd2Check.Checked = False
                    .HotEnd2Check.Enabled = True
                    .HotEnd2Check.Visible = True
                    .HotEnd3Check.Checked = False
                    .HotEnd3Check.Enabled = True
                    .HotEnd3Check.Visible = True
                    .HotEnd4Check.Checked = False
                    .HotEnd4Check.Enabled = False
                    .HotEnd4Check.Visible = False
                    .TuneButtonPanel.Height = 325
                    .T1But.Visible = True
                    .T1But2But.Visible = True
                    .T2But.Visible = True
                    .T2But2But.Visible = True
                    .T3But.Visible = True
                    .T3But2But.Visible = True
                    .T4But.Visible = False
                    .T4But2But.Visible = False
                Case Is = 4
                    .HotEndActiveChk.Checked = True
                    .HotEndActiveChk.Enabled = True
                    .HotEnd1Check.Checked = False
                    .HotEnd1Check.Enabled = True
                    .HotEnd2Check.Checked = False
                    .HotEnd2Check.Enabled = True
                    .HotEnd3Check.Checked = False
                    .HotEnd3Check.Enabled = True
                    .HotEnd4Check.Checked = False
                    .HotEnd4Check.Enabled = True
                    .HotEnd2Check.Visible = True
                    .HotEnd3Check.Visible = True
                    .HotEnd4Check.Visible = True
                    .TuneButtonPanel.Height = 350
                    .T1But.Visible = True
                    .T1But2But.Visible = True
                    .T2But.Visible = True
                    .T2But2But.Visible = True
                    .T3But.Visible = True
                    .T3But2But.Visible = True
                    .T4But.Visible = True
                    .T4But2But.Visible = True
            End Select
            If .HeatBox.Text = "0" And .BedBox.Text = "0" Then
                Select Case Me.MaterialType.Text
                    Case Is = My.Settings.Matl1_Name
                        .HeatBox.Text = My.Settings.Matl1_Hot
                        .BedBox.Text = My.Settings.Matl1_Bed
                        .FanBox.Text = My.Settings.Matl1_Fan
                    Case Is = My.Settings.Matl2_Name
                        .HeatBox.Text = My.Settings.Matl2_Hot
                        .BedBox.Text = My.Settings.Matl2_Bed
                        .FanBox.Text = My.Settings.Matl2_Fan
                    Case Is = My.Settings.Matl3_Name
                        .HeatBox.Text = My.Settings.Matl3_Hot
                        .BedBox.Text = My.Settings.Matl3_Bed
                        .FanBox.Text = My.Settings.Matl3_Fan
                    Case Is = My.Settings.Matl4_Name
                        .HeatBox.Text = My.Settings.Matl4_Hot
                        .BedBox.Text = My.Settings.Matl4_Bed
                        .FanBox.Text = My.Settings.Matl4_Fan
                End Select
            End If
        End With
        With Me
            .HotLabel.Text = "(Hot End - " & Me.HeatBox.Text & "°)"
            .BedLabel.Text = "(Bed - " & Me.BedBox.Text & "°)"
        End With
    End Sub

    Private Sub MovementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovementToolStripMenuItem.Click
        On Error Resume Next
        With MovementPanel
            .Left = 10
            .Top = 40
            .Width = 900
            .Height = 650
            .BringToFront()
            .Visible = True
        End With
        ComPanel.Visible = False
        SDPrintPanel.Visible = False
        RecoveryPanel.Visible = False
        TuneUpPanel.Visible = False
        StatsPanel.Visible = False
        With Me
            If Me.Box_E_Retract.Text = "" Then Me.Box_E_Retract.Text = My.Settings.Retraction
            If Me.Box_E.Text = "" Then Me.Box_E.Text = My.Settings.ExtrudeAmt
            .CBStep1.Text = "Left Front" & vbLf & My.Settings.Lev_LFx & ", " & My.Settings.Lev_LFy & ", " & My.Settings.Lev_LFz
            .CBStep2.Text = "Right Front" & vbLf & My.Settings.Lev_RFx & ", " & My.Settings.Lev_RFy & ", " & My.Settings.Lev_RFz
            .CBStep3.Text = "Right Rear" & vbLf & My.Settings.Lev_RRx & ", " & My.Settings.Lev_RRy & ", " & My.Settings.Lev_RRz
            .CBStep4.Text = "Left Rear" & vbLf & My.Settings.Lev_LRx & ", " & My.Settings.Lev_LRy & ", " & My.Settings.Lev_LRz
            .CBStepMid.Text = "Middle" & vbLf & My.Settings.Lev_MIDx & ", " & My.Settings.Lev_MIDy & ", " & My.Settings.Lev_MIDz
            .ParkButt.Text = "Present Print" & vbLf & "Y " & My.Settings.Bed_Ymax & " (Absolute)   Z " & My.Settings.PrePr_z & " (Relative)"
        End With
    End Sub

    Private Sub StatisticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatisticsToolStripMenuItem.Click
        On Error Resume Next
        With StatsPanel
            .Left = 10
            .Top = 40
            .Width = 900
            .Height = 650
            .BringToFront()
            .Visible = True
        End With
        ComPanel.Visible = False
        SDPrintPanel.Visible = False
        RecoveryPanel.Visible = False
        TuneUpPanel.Visible = False
        MovementPanel.Visible = False
    End Sub

    Private Sub StartUpButton_Click(sender As Object, e As EventArgs) Handles StartUpButton.Click
        Try
            RemoveHandler Me.Vcomm.DataReceived, AddressOf Me.SerialPort1_DataReceived
            Me.Vcomm.Close()
            AddHandler Me.Vcomm.DataReceived, AddressOf Me.SerialPort1_DataReceived
        Catch ex As Exception
        End Try
        Me.AvailablePortsBox.Items.Clear()
        Me.AvailablePortsBox.SelectedItem = ""
        Me.AvailablePortsBox.ResetText()
        Call StartUp()
        Me.PrinterNameBox.Items.Clear()
        Me.PrinterNameBox.SelectedItem = ""
        Me.PrinterNameBox.ResetText()
    End Sub

    Private Sub SDcardInitButt_Click(sender As Object, e As EventArgs) Handles SDcardInitButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M21"
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub ListSDCard_Click(sender As Object, e As EventArgs) Handles ListSDCard.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim TheClearButton As Boolean
        RecvStr = ""
        TheClearButton = Me.ClearResponseButt.Checked
        AllResponses = False
        Me.ClearResponseButt.Checked = True
        Me.TextBox1.Text = ""
        StrToSend = "M20"
        SendTheString(StrToSend)
        'StrToSend = ""
    End Sub

    Private Sub ImportFileNameBut_Click(sender As Object, e As EventArgs) Handles ImportFileNameBut.Click
        On Error Resume Next
        Dim TheFullList As String
        Dim TheListStart As Integer
        Dim FileList As String
        Dim ListLength As Integer
        Dim TheSpace As Integer
        Dim TheFile As String
        Dim NextFileStart As Integer
        Me.FileListBox.Items.Clear()
        Me.FileListBox.Text = ""
        TheFullList = Me.TextBox1.Text
        TheListStart = InStr(1, TheFullList, "file list")
        FileList = Strings.Right(TheFullList, Len(TheFullList) - TheListStart - 10)
        ListLength = Len(FileList)
        Do Until InStr(1, FileList, "GCO") = 0
            TheSpace = InStr(1, FileList, "gco")
            TheFile = Strings.Replace(Strings.Left(FileList, TheSpace + 2), " ", "")
            TheFile = System.Text.RegularExpressions.Regex.Replace(TheFile, "[^\u0000-\u007F]", "")
            If Strings.Left(TheFile, 1) <> "/" Then
                TheFile = "\" & TheFile
            ElseIf Strings.Left(TheFile, 1) = "/" Then
                TheFile = Strings.Right(TheFile, Len(TheFile) - 1)
                TheFile = "\" & TheFile
            End If
            If Me.PrinterSubFolderCheckBox.Checked = True Then
                Me.FileListBox.Items.Add(TheFile)
            ElseIf Me.PrinterSubFolderCheckBox.Checked = False Then
                If InStr(2, TheFile, "/") = 0 Then
                    Me.FileListBox.Items.Add(TheFile)
                End If
            End If
            FileList = Strings.Right(FileList, Len(FileList) - Len(TheFile))
            NextFileStart = InStr(1, FileList, Chr(10))
            FileList = Strings.Right(FileList, Len(FileList) - NextFileStart)
        Loop
        Me.FileListBox.Text = CStr(Me.FileListBox.Items.Item(0))
        If Me.FileListBox.Text = "" Then Me.FileListBox.Text = "{None}"
        Me.ClearResponseButt.Checked = False
    End Sub

    Public Sub ComOpenBut_CheckedChanged(sender As Object, e As EventArgs) Handles ComOpenBut.CheckedChanged
        On Error Resume Next
        If Me.ComOpenBut.Checked = True Then
            Call OpenAPort()
            If Me.Vcomm.IsOpen = True Then
                Me.SendCmdBut.Enabled = True
                Me.ComOpenBut.Text = "Serial Port " & ComPortName & " is Open"
                Me.ComOpenBut.BackColor = Color.DarkGreen
                Me.TextBox1.Text = ComPortName & " is Open" & vbCrLf
                Me.StepOnOffBut.Checked = True
                Me.TextBox1.Text += "Stepper time-out is set to 4 hours " & vbCrLf
                Me.ComOpenLab.Text = "Com Port " & Me.Vcomm.PortName & " is Open"
                Me.ComOpenLab.BackColor = Color.DarkGreen
            End If
        ElseIf Me.ComOpenBut.Checked = False Then
            If Me.Vcomm.IsOpen Then
                Call ClosePort()
            End If
            Me.ComOpenBut.Text = "Com Port Is Closed"
            Me.ComOpenBut.BackColor = Color.Red
            Me.ComOpenLab.Text = "Com Port Closed"
            Me.ComOpenLab.BackColor = Color.Red
            RecvStr = ""
            Me.TextBox1.Text = "Close Com Port" & vbCrLf
        End If
    End Sub

    Private Sub SendCmdBut_Click(sender As Object, e As EventArgs) Handles SendCmdBut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        If Me.CmdToSendBox.Text = "" Then
            MsgBox("Enter a Command Code", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = Me.CmdToSendBox.Text
        Call SendTheString(StrToSend)
        StrToSend = ""
        Me.CmdToSendBox.Text = ""
    End Sub

    Public Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles Vcomm.DataReceived
        On Error Resume Next
        Dim OldString As String
        Dim OldStrToSend = ""
        Dim NextChar As String
        OldString = ""
        'Get the current contents of the text box
        If Me.Vcomm.BytesToRead > 0 Then
            If AllResponses = True Then
                OldString = Me.TextBox1.Text
            Else
                OldString = ""
            End If
            'Clear the text box
            Me.BeginInvoke(New mydelegate(AddressOf Command_Handler), "") 'Me.TextBox1.Text = ""

            'If the receipt is a response to the port opening, or to M503
            If StrToSend = "OpenCom" Or StrToSend = "M503" Then

                'Empty the receive buffer
                Do While Me.Vcomm.BytesToRead > 0
                    NextChar = Chr(Me.Vcomm.ReadByte)
                    If NextChar = vbLf Then NextChar = vbCrLf
                    RecvStr &= NextChar
                Loop
                'Format the response line depending if StrtoSend is empty or not, then empty StrtoSend
                If StrToSend <> "" Then
                    FinalString = StrToSend & vbCrLf & RecvStr
                Else
                    FinalString = RecvStr
                End If
                'StrToSend = ""

                'Send the final string to the text box
                If FinalString = vbCrLf Then FinalString = ""
                Me.BeginInvoke(New mydelegate(AddressOf Command_Handler), FinalString)
                Exit Sub
            End If
            'Check if strtosend is M303 or M20 or M83
            If Strings.Left(StrToSend, 4) = "M303" Or StrToSend = "M20" Or StrToSend = "M83" Then
                Do Until Me.Vcomm.BytesToRead > 0
                    NextChar = CStr(Me.Vcomm.ReadChar)
                    If NextChar = vbLf Then NextChar = vbCrLf
                    RecvStr &= NextChar
                Loop
            Else
                RecvStr = ""
GetMore:
                Do Until Strings.Right(RecvStr, 1) = vbLf And Me.Vcomm.BytesToRead = 0
                    NextChar = Chr(Me.Vcomm.ReadByte)
                    If NextChar = vbLf Then NextChar = vbCrLf
                    RecvStr &= NextChar
                Loop
                If Me.Vcomm.BytesToWrite > 0 Then GoTo GetMore
            End If
        End If

        'End of reading the port

        If Strings.Left(StrToSend, 4) = "M118" Then StrToSend = ""
        OldStrToSend = OldString & StrToSend
        If OldStrToSend <> "" Then
            Dim Crap = Strings.Right(OldString, 2)
            Dim Crap1 = Strings.Left(Crap, 1)
            Dim Crap2 = Strings.Right(Crap, 1)
            If Crap1 = vbCr And Crap2 = vbLf Then
            Else
                OldStrToSend &= vbCrLf
            End If
        End If
        If Me.IgnoreBusyBut.Checked Then
            If InStr(RecvStr, "echo:busy: processing") > 0 Then
                RecvStr = Strings.Replace(RecvStr, "echo:busy: processing", "", 1, -1)
                RecvStr = Strings.Replace(RecvStr, vbCrLf, "", 1, -1)
            End If
            If InStr(RecvStr, "failed") > 0 Then
                RecvStr = Strings.Replace(RecvStr, "open failed, File: .", "", 1, -1)
                RecvStr = Strings.Replace(RecvStr, "Write power off file failed.", "", 1, -1)
                RecvStr = Strings.Replace(RecvStr, vbLf, "", 1, -1)
            End If
        End If
        FinalString = OldStrToSend & RecvStr
        If FinalString = vbCrLf Then FinalString = ""
        Me.BeginInvoke(New mydelegate(AddressOf Command_Handler), FinalString)

        'In case more has come into the buffer
        If Me.Vcomm.BytesToRead > 0 Then
            GoTo GetMore
        End If
    End Sub


    Public Delegate Sub mydelegate(ByVal s As String)
    Public Delegate Sub getDelegate(ByVal s As String)
    Public Sub Command_Handler(ByVal command_string As String)
        Try
            If Me.IgnoreResponseBut.Checked = False Then ' Exit Sub
                With Me.TextBox1
                    If command_string = "" Then
                        .Text = ""
                        Exit Sub
                    End If
                    If MemoryString <> "" Then
                        .Text = FinalString & vbCrLf & MemoryString
                    Else
                        .Text = FinalString
                    End If
                    .Select(.Text.Length, .Text.Length)
                    .ScrollToCaret()
                End With
                MemoryString = ""
            Else
                MemoryString &= RecvStr
            End If
            If InStr(Me.TextBox1.Text, "End of gcode") > 0 Then
                Me.DisableMovementBut.Checked = False
            End If
        Catch
        End Try
    End Sub
    Private Function Fetch_Str() As String
        On Error Resume Next
        Fetch_Str = Me.TextBox1.Text
    End Function
    Private Sub ClearRespBut_Click(sender As Object, e As EventArgs) Handles ClearRespBut.Click
        On Error Resume Next
        Me.TextBox1.Text = ""
        StrToSend = ""
        RecvStr = ""
    End Sub

    Private Sub GetFileNameBut_Click(sender As Object, e As EventArgs) Handles GetFileNameBut.Click
        On Error GoTo TheHandler
        Dim FileResponse As DialogResult, GCODE_Filedelegate As [Delegate]
        Me.OpenFileDialog1.Title = "Open a GCODE file To search"
        Me.OpenFileDialog1.Filter = "GCODE Files|*.gcode"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = ""
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        Dim ImportFileName = Me.OpenFileDialog1.FileName
        Me.GCODE_FileNameBox.Text = ImportFileName
        Me.GCODE83Name.Text = FileOnFileForm.GetShortPath(ImportFileName)
        Me.GCODE_SizeBox.Text = Format(FileLen(ImportFileName), "0,000")
        Exit Sub
TheHandler:
        MsgBox("There was an Error in ""MainForm.GetFileNameBut_Click""" & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub ClearFileNameBut_Click(sender As Object, e As EventArgs) Handles ClearFileNameBut.Click
        On Error Resume Next
        Me.GCODE_FileNameBox.Text = ""
        Me.GCODE_SizeBox.Text = ""
        Me.GCODE83Name.Text = ""
    End Sub

    Private Sub ByteGetPrintLocBut_Click(sender As Object, e As EventArgs) Handles ByteGetPrintLocBut.Click
        On Error Resume Next
        AllResponses = False
        StrToSend = "M27"
        SendTheString(StrToSend)
    End Sub

    Private Sub FetchByteBut_Click(sender As Object, e As EventArgs) Handles FetchByteBut.Click
        On Error GoTo EHandler
        Dim ByteLoc As String
        Dim ByteString As String = Me.TextBox1.Text
        Dim ByteSpace As Integer = CInt(InStr(1, ByteString, "/"))
        ByteString = Microsoft.VisualBasic.Left(ByteString, ByteSpace - 1)
        ByteSpace = InStr(1, ByteString, " ")
        ByteString = Microsoft.VisualBasic.Right(ByteString, Len(ByteString) - ByteSpace)
        ByteSpace = InStr(1, ByteString, " ")
        ByteString = Microsoft.VisualBasic.Right(ByteString, Len(ByteString) - ByteSpace)
        ByteSpace = InStr(1, ByteString, " ")
        ByteString = Microsoft.VisualBasic.Right(ByteString, Len(ByteString) - ByteSpace)
        Me.ByteCountBox.Text = ByteString
        Exit Sub
EHandler:
        MsgBox("There was an Error in ""Mainform.FetchByteBut_Click"":" & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub OpenGCODEtoSearch_Click(sender As Object, e As EventArgs) Handles OpenGCODEtoSearch.Click
        Call FindByteLocation()
    End Sub

    Private Sub ShowCodeBut_Click(sender As Object, e As EventArgs) Handles ShowCodeBut.Click
        Call GetAdjacentLines()
    End Sub

    Private Sub ByteLayerSearchBut_Click(sender As Object, e As EventArgs) Handles ByteLayerSearchBut.Click
        Call FindLayerByte()
    End Sub

    Private Sub ByteLineSearchBut_Click(sender As Object, e As EventArgs) Handles ByteLineSearchBut.Click
        Call FindLineByte()
    End Sub

    Private Sub LayerIsC_CheckedChanged(sender As Object, e As EventArgs) Handles LayerIsC.CheckedChanged
        On Error Resume Next
        With Me
            If .LayerIsC.Checked = True Then
                .ByteLayerSearchBox.BackColor = Color.Bisque
                .LayerIsG.BackColor = Color.Khaki
                .LayerIsC.BackColor = Color.Bisque
            End If
        End With
    End Sub

    Private Sub LayerIsG_CheckedChanged(sender As Object, e As EventArgs) Handles LayerIsG.CheckedChanged
        On Error Resume Next
        With Me
            If .LayerIsG.Checked = True Then
                .ByteLayerSearchBox.BackColor = Color.Khaki
                .LayerIsC.BackColor = Color.Bisque
                .LayerIsG.BackColor = Color.Khaki
            End If
        End With
    End Sub

    Private Sub SaveRecoverBut_Click(sender As Object, e As EventArgs) Handles SaveRecoverBut.Click
        On Error Resume Next
        Dim ZHgt As String, ELoc As String, Filename As String, ByteNum As String, FanSpeed As String, XLoc As String, YLoc As String
        Dim HotTemp As String, BedTemp As String, FlowRate As String, FeedRate As String
        Dim LineToWrite As String
        Dim FileResponse = ""
        With Me
            ZHgt = .PauseZ.Text
            ELoc = .PauseE.Text
            ByteNum = .ByteCountBox.Text
            Filename = System.Text.RegularExpressions.Regex.Replace(.FileListBox.Text, "[^\u0000-\u007F]", "")
            XLoc = .PauseX.Text
            YLoc = .PauseY.Text
            HotTemp = .HeatBox.Text
            BedTemp = .BedBox.Text
            FlowRate = .FloBox.Text
            FeedRate = .FeedBox.Text
            FanSpeed = .FanBox.Text
        End With
        LineToWrite = Filename & vbLf & ByteNum & vbLf & XLoc & vbLf & YLoc & vbLf &
            ZHgt & vbLf & ELoc & vbLf & HotTemp & vbLf & BedTemp & vbLf & FlowRate & vbLf & FeedRate & vbLf & FanSpeed
        Me.SaveFileDialog1.Title = "Save Recovery Information"
        Me.SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        Me.SaveFileDialog1.FilterIndex = 1
        Me.SaveFileDialog1.DefaultExt = "txt"
        Me.SaveFileDialog1.FileName = "Recovery1.txt"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            My.Computer.FileSystem.WriteAllText _
            (Me.SaveFileDialog1.FileName, LineToWrite, False)
        End If
    End Sub

    Private Sub LoadRecoverBut_Click(sender As Object, e As EventArgs) Handles LoadRecoverBut.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim RecoveryFileName As String = ""
        Dim RecoveryFile As System.IO.StreamReader
        Dim TempLine As String = ""
        With Me
            .OpenFileDialog1.Title = "Open a Recovery Text file"
            .OpenFileDialog1.Filter = "Text Files|*.txt"
            .OpenFileDialog1.FilterIndex = 1
            .OpenFileDialog1.DefaultExt = "Text"
            .OpenFileDialog1.FileName = ""
            FileResponse = .OpenFileDialog1.ShowDialog()
            If FileResponse = 2 Then
                Exit Sub
            End If
            RecoveryFileName = .OpenFileDialog1.FileName
        End With
JumpStart:
        RecoveryFile = My.Computer.FileSystem.OpenTextFileReader(RecoveryFileName)
        Me.FileListBox.Items.Clear()
        TempLine = System.Text.RegularExpressions.Regex.Replace(RecoveryFile.ReadLine, "[^\u0000-\u007F]", "")
        Me.FileListBox.Items.Add(TempLine)
        Me.FileListBox.SelectedIndex = Me.FileListBox.Items.Count - 1
        Me.ByteCountBox.Text = RecoveryFile.ReadLine
        Me.PauseX.Text = RecoveryFile.ReadLine
        Me.PauseY.Text = RecoveryFile.ReadLine
        Me.PauseZ.Text = RecoveryFile.ReadLine
        Me.PauseE.Text = RecoveryFile.ReadLine
        Me.HeatBox.Text = RecoveryFile.ReadLine
        Me.BedBox.Text = RecoveryFile.ReadLine
        Me.FloBox.Text = RecoveryFile.ReadLine
        Me.FeedBox.Text = RecoveryFile.ReadLine
        Me.FanBox.Text = RecoveryFile.ReadLine
        RecoveryFile.Close()
    End Sub

    Private Sub SendToPrintPageBut_Click(sender As Object, e As EventArgs) Handles SendToPrintPageBut.Click
        On Error GoTo EHandler
        Dim TheLocation As String = Me.ByteContentBox.Text
        Dim TheX As Integer, SpX As Integer, TheY As Integer, SpY As Integer, TheZ As Integer, SpZ As Integer, TheE As Integer, SpE As Integer
        Dim Xval As String, Yval As String, Zval As String, Eval As String
        Dim NewStr = ""
        TheX = CInt(InStr(TheLocation, " X", vbTextCompare))
        If TheX > 0 Then
            NewStr = Microsoft.VisualBasic.Right(TheLocation, Len(TheLocation) - TheX - 1)
            SpX = InStr(1, NewStr, " ")
            If SpX > 0 Then
                Xval = Microsoft.VisualBasic.Left(NewStr, SpX - 1)
            Else
                Xval = NewStr
            End If
        Else
            Xval = ""
        End If
        TheY = InStr(1, NewStr, " Y")
        If TheY > 0 Then
            NewStr = Microsoft.VisualBasic.Right(NewStr, Len(NewStr) - TheY - 1)
            SpY = InStr(1, NewStr, " ")
            If SpY > 0 Then
                Yval = Microsoft.VisualBasic.Left(NewStr, SpY - 1)
            Else
                Yval = NewStr
            End If
        Else
            Yval = ""
        End If
        TheZ = InStr(1, NewStr, " Z")
        If TheZ > 0 Then
            NewStr = Microsoft.VisualBasic.Right(NewStr, Len(NewStr) - TheZ - 1)
            SpZ = InStr(1, NewStr, " ")
            If SpZ > 0 Then
                Zval = Microsoft.VisualBasic.Left(NewStr, SpZ - 1)
            Else
                Zval = NewStr
            End If
        Else
            Zval = Me.ByteZBox.Text
        End If
        If NewStr = "" Then NewStr = TheLocation
        TheE = InStr(1, NewStr, " E")
        If TheE > 0 Then
            NewStr = Microsoft.VisualBasic.Right(NewStr, Len(NewStr) - TheE - 1)
            SpE = InStr(1, NewStr, " ")
            If SpE > 0 Then
                Eval = Microsoft.VisualBasic.Left(NewStr, SpE - 1)
            Else
                Eval = NewStr
            End If
        Else
            Eval = ""
        End If
        With Me
            If CommandModule.Resume_X_Start <> "" Then
                .PauseX.Text = CommandModule.Resume_X_Start
            ElseIf Xval <> "" Then
                .PauseX.Text = Xval
            End If
            If CommandModule.Resume_Y_Start <> "" Then
                .PauseY.Text = CommandModule.Resume_Y_Start
            ElseIf Yval <> "" Then
                .PauseY.Text = Yval
            End If
            If CommandModule.Resume_Z_Start <> "" Then
                .PauseZ.Text = CommandModule.Resume_Z_Start
            ElseIf Zval <> "" Then
                .PauseZ.Text = Zval
            End If
            If CommandModule.Resume_E_Start <> "" Then
                .PauseE.Text = CommandModule.Resume_E_Start
            ElseIf Eval <> "" Then
                .PauseE.Text = Eval
            End If
            If Eval <> "" Then .PauseE.Text = Eval
        End With
        If Eval = "" And CommandModule.Resume_E_Start = "" Then
            MsgBox("There was no E value in the line.  The E value in the box on the Print page will remain unchanged. Please check your E location.  It should match the E value of a gcode line above line " & Me.ByteLineBox.Text, CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        End If
        Call PrintFromSDCardToolStripMenuItem_Click(sender, e)
        MsgBox("The calculated ""Resume"" values have been entered.  Check them carefully.", vbOKOnly, "Greg's Toolbox")
        Exit Sub
EHandler:
        MsgBox("There was an error in ""Mainform.SendToPrintPageBut_Click""." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")

    End Sub

    Private Sub ReleaseSDBut_Click(sender As Object, e As EventArgs) Handles ReleaseSDBut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M22"
        SendTheString(StrToSend)
        'StrToSend = ""
    End Sub

    Private Sub AbortButt_Click(sender As Object, e As EventArgs) Handles AbortButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("Abort?", CType(vbYesNo + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = 7 Then Exit Sub
        StrToSend = "M400"
        SendTheString(StrToSend)
        StrToSend = "M25"
        SendTheString(StrToSend)
        StrToSend = "M114"
        SendTheString(StrToSend)
        StrToSend = "M83"
        SendTheString(StrToSend)
        StrToSend = "G0 F1200 E-5"
        SendTheString(StrToSend)
        StrToSend = "G91"
        SendTheString(StrToSend)
        StrToSend = "G0 Z10"
        SendTheString(StrToSend)
        StrToSend = "G0 F1200 E5"
        SendTheString(StrToSend)
        StrToSend = "M82"
        SendTheString(StrToSend)
        StrToSend = "G90"
        SendTheString(StrToSend)
        StrToSend = "G0 Y" & My.Settings.Bed_Ymax & "F6000"
        SendTheString(StrToSend)
        AResponse = MsgBox("Shut-off the hot end and bed?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = 7 Then GoTo SkipOut
        StrToSend = "M104 S0"
        SendTheString(StrToSend)
        If My.Settings.Heated_Bed Then
            StrToSend = "M140 S0"
            SendTheString(StrToSend)
        End If
SkipOut:
        StrToSend = ""
        PrintStartTime = Nothing
        Me.DisableMovementBut.Checked = False
    End Sub

    Private Sub DeleteFileButt_Click(sender As Object, e As EventArgs) Handles DeleteFileButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim FResponse As Integer
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("Are you sure you want to delete " & Me.FileListBox.Text & " from the SD Card?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        StrToSend = "M30 " & Me.FileListBox.Text
        SendTheString(StrToSend)
        'StrToSend = ""
        FResponse = Me.FileListBox.SelectedIndex
        Me.FileListBox.Items.RemoveAt(FResponse)
    End Sub

    Private Sub PrintFileButt_Click(sender As Object, e As EventArgs) Handles PrintFileButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim MyFile = Me.FileListBox.Text
        MyFile = System.Text.RegularExpressions.Regex.Replace(MyFile, "[^\u0000-\u007F]", "")
        If Len(MyFile) > 12 Then MyFile = MyFile
        StrToSend = "M21"
        SendTheString(StrToSend)
        StrToSend = "M23 " & MyFile
        SendTheString(StrToSend)
        StrToSend = "M24"
        SendTheString(StrToSend)
        Me.DisableMovementBut.Checked = True
        StrToSend = ""
        PrintStartTime = CStr(Now)
        PauseTimeForm.Lay0C.Text = PrintStartTime
        PauseTimeForm.InfoLab.Text = "Start Time = Print Start Time"
    End Sub

    Private Sub PausePrintButt_Click(sender As Object, e As EventArgs) Handles PausePrintButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("M25")
        SendTheString("M400")
        SendTheString("M83")
        SendTheString("G91")
        SendTheString("G0 F1200 E-5")
        SendTheString("G0 Z10")
        SendTheString("G90")
        SendTheString("M18 S14400")
        SendTheString("G1 F1200 X0 Y0")
        SendTheString("G0 F1200 E5")
        SendTheString("M82")
        SendTheString("G1 F1800")
        SendTheString("M114")
        StrToSend = ""
        Me.DisableMovementBut.Checked = False
    End Sub

    Private Sub GetLocButt_Click(sender As Object, e As EventArgs) Handles GetLocButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Me.TextBox1.Text = ""
        StrToSend = "M114"
        SendTheString(StrToSend)
    End Sub

    Private Sub ImportLocationButt_Click(sender As Object, e As EventArgs) Handles ImportLocationButt.Click
        On Error GoTo Handler
        Dim TheLocation As String
        Dim TheX As Long, TheY As Long, TheZ As Long, TheE As Long, Xval As String, Yval As String, Zval As String, Eval As String, TheEnd As Long
        TheLocation = Me.TextBox1.Text

        TheX = InStr(TheLocation, "X:")
        TheY = InStr(TheLocation, "Y:")
        TheZ = InStr(TheLocation, "Z:")
        TheE = InStr(TheLocation, "E:")
        Xval = Strings.Mid(TheLocation, CInt(TheX) + 2, CInt(TheY) - CInt(TheX) - 3)
        Xval = Trim(Xval)
        Yval = Mid(TheLocation, CInt(TheY) + 2, CInt(TheZ) - CInt(TheY) - 3)
        Yval = Trim(Yval)
        Zval = Mid(TheLocation, CInt(TheZ) + 2, CInt(TheE) - CInt(TheZ) - 3)
        Zval = Trim(Zval)
        TheEnd = InStr(TheLocation, "Count")
        Eval = Mid(TheLocation, CInt(TheE) + 2, CInt(TheEnd) - CInt(TheE) - 3)
        Eval = Trim(Eval)
        With Me
            .PauseX.Text = Xval
            .PauseY.Text = Yval
            .PauseZ.Text = Zval
            .PauseE.Text = Eval
        End With
        Exit Sub
Handler:
        MsgBox("There was an error in ""Mainform.ImportLocationButt_Click"".  It can happen when there is too much information in the Printer Response box." & vbCrLf & "The location information must be in the Printer Response box." & vbCrLf & vbCrLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")

    End Sub

    Private Sub ResumePrintButt_Click(sender As Object, e As EventArgs) Handles ResumePrintButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim Response As MsgBoxResult
        Dim Estr As String
        If Me.PauseE.Text = "" Then
            Estr = "Ignore E "
        Else
            Estr = "Set E value to " & Me.PauseE.Text
        End If
        Response = MsgBox("Resume Print?" & vbLf & vbLf & "Yes = " & Estr & " and RESUME" & vbLf & "No = RESUME (with current E value)" & vbLf & "Cancel = Exit without resuming.", CType(vbYesNoCancel + vbQuestion, MsgBoxStyle), "Greg's Toolbox - RESUME PRINT")
        If Response = vbYes Then
            If Me.PauseE.Text <> "" Then
                SendTheString("G92 E" & Val(Me.PauseE.Text))
            End If
        ElseIf Response = vbCancel Then
            Exit Sub
        End If
        If Me.PauseFeed.Text = "" Or Val(Me.PauseFeed.Text) = 0 Then
            Me.PauseFeed.Text = "50"
        End If
        SendTheString("M24")
        SendTheString("G91")
        SendTheString("G0 Z-10")
        SendTheString("G0 F" & Val(Me.PauseFeed.Text) * 60)
        SendTheString("G90")
        'StrToSend = ""
    End Sub

    Private Sub RetToLocButt_Click(sender As Object, e As EventArgs) Handles RetToLocButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        With Me
            If .PauseX.Text = "" Or .PauseY.Text = "" Or .PauseZ.Text = "" Then
                MsgBox("You cannot leave X, Y or Z blank.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            StrToSend = "G0 Z" & CStr(CInt(.PauseZ.Text) + 10)
            SendTheString(StrToSend)
            StrToSend = "G0 X" & .PauseX.Text & " Y" & .PauseY.Text & " F3000"
            SendTheString(StrToSend)
            StrToSend = "G0 Z" & .PauseZ.Text
            SendTheString(StrToSend)
        End With
        'StrToSend = ""
    End Sub

    Private Sub CBResetEbut_Click(sender As Object, e As EventArgs) Handles CBResetEbut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim TheE As String
        If Me.PauseE.Text = "" Then
            TheE = Nothing
        Else
            TheE = Me.PauseE.Text
        End If
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("Do you want to send the ""E"" location contained in the ""E"" box? (the value is currently " _
        & TheE & ").  If the box is empty nothing will be sent.  If you want to reset ""E"" to zero you need to enter a zero." & vbLf & vbLf &
        "OK means set the Extruder to " & TheE & "." & vbLf & "Cancel means EXIT", CType(vbOKCancel + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbOK Then
            If Me.PauseE.Text <> "" Then
                StrToSend = "G92 E" & Me.PauseE.Text
                SendTheString(StrToSend)
                'StrToSend = ""
            End If
        ElseIf AResponse = vbCancel Then
            Exit Sub
        End If
    End Sub

    Private Sub CBExtrude2_Click(sender As Object, e As EventArgs) Handles CBExtrude2.Click
        Call CBExtrude_Click(sender, e)
    End Sub

    Private Sub Box_E2_TextChanged(sender As Object, e As EventArgs) Handles Box_E2.TextChanged
        Me.Box_E.Text = Me.Box_E2.Text
    End Sub

    Private Sub EPrimeButt_Click(sender As Object, e As EventArgs) Handles EPrimeButt.Click
        Try
            If Me.PauseE.Text = "" Then Me.PauseE.Text = "0"
            Me.PauseE.Text = CStr(Val(Me.PauseE.Text) - Val(My.Settings.PrimeAmt))
        Catch
        End Try
    End Sub

    Private Sub PrintReStartBut_Click(sender As Object, e As EventArgs) Handles PrintReStartBut.Click
        With RecoveryForm
            RecoveryForm.ByteLab.Text = Me.ByteCountBox.Text
            .FileLab.Text = Me.FileListBox.Text
            .ELab.Text = Me.PauseE.Text
            .ZLab.Text = Me.PauseZ.Text
            .XLab.Text = Me.PauseX.Text
            .YLab.Text = Me.PauseY.Text
            .BedLab.Text = Me.BedBox.Text
            .HotLab.Text = Me.HeatBox.Text
            .FeedLab.Text = Me.FeedBox.Text
            .FlowLab.Text = Me.FloBox.Text
            .FanLab.Text = Me.FanBox.Text
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub CalculateButt_Click(sender As Object, e As EventArgs) Handles CalculateButt.Click
        On Error GoTo EHandler
        Dim NumLayers As Integer
        Dim Hrs As String
        Dim Min As String
        Dim Sec As String
        Dim TotalSec As Long
        Dim CurrTime As DateTime
        Dim EndTime As DateTime
        Dim EndString As String
        Dim LayerTime As String
        Dim DeltaZ As String
        Dim ZTime As String
        Dim Colon As Long
        If Me.Layer1Box.Text = "" Or Me.LayerHgtBox.Text = "" Then
            MsgBox("The ""Initial Layer Hgt"" and ""Layer Height"" boxes cannot be blank", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.PrintLayerTime.Text = "" Then Me.PrintLayerTime.Text = "00:00:00"
        With Me
            NumLayers = CInt(Val(.StatTargetLayer.Text) - Val(.StatLayerBox.Text))
            Hrs = Strings.Left(.PrintLayerTime.Text, 2)
            Min = Mid(.PrintLayerTime.Text, 4, 2)
            Sec = Strings.Right(.PrintLayerTime.Text, 2)
            TotalSec = (CLng(Hrs) * 3600) + (CLng(Min) * 60) + CLng(Sec)
            .StatLayerWaitBox.Text = FormatTime(CStr(TotalSec * NumLayers))
            Colon = InStr(.StatLayerWaitBox.Text, ":")
            Hrs = Strings.Left(.StatLayerWaitBox.Text, CInt(Colon) - 1)
            Min = Mid(.StatLayerWaitBox.Text, 4, 2)
            Sec = Strings.Right(.StatLayerWaitBox.Text, 2)
            CurrTime = Now
            EndString = CStr(CurrTime.AddHours(CDbl(Hrs)).AddMinutes(CDbl(Min)).AddSeconds(CDbl(Sec)))
            .LayTOD.Text = CStr(DateAndTime.TimeValue(EndString))
            .LayDate.Text = CStr(DateAndTime.DateValue(EndString))
            DeltaZ = CStr(Val(.StatTargetZ.Text) - Val(.StatZBox.Text)) ' + FudgeZ
            NumLayers = CInt(Val(DeltaZ) / Val(.LayerHgtBox.Text)) ' + FudgeLayer
            Colon = InStr(.PrintLayerTime.Text, ":")
            On Error Resume Next
            Hrs = Microsoft.VisualBasic.Left(.PrintLayerTime.Text, CInt(Colon) - 1)
            On Error GoTo EHandler
            Min = Mid(.PrintLayerTime.Text, 4, 2)
            Sec = Microsoft.VisualBasic.Right(.PrintLayerTime.Text, 2)
            TotalSec = (CLng(Hrs) * 3600) + (CLng(Min) * 60) + CLng(Sec)
            .StatZWaitBox.Text = FormatTime(CStr(TotalSec * NumLayers))
            Colon = InStr(.StatZWaitBox.Text, ":")
            Hrs = Strings.Left(.StatZWaitBox.Text, CInt(Colon) - 1)
            Min = Mid(.StatZWaitBox.Text, 4, 2)
            Sec = Strings.Right(.StatZWaitBox.Text, 2)
            ZTime = CStr(CurrTime.AddHours(CDbl(Hrs)).AddMinutes(CDbl(Min)).AddSeconds(CDbl(Sec)))
            .ZTOD.Text = CStr(TimeValue(ZTime))
            .ZDate.Text = CStr(DateValue(ZTime))

        End With
        Exit Sub
EHandler:
        MsgBox("There was an error in ""Mainform.CalculateButt_Click"": " & vbLf & vbLf & Err.Description, CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub AllOffButt_Click(sender As Object, e As EventArgs) Handles AllOffButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("Please Confirm ALL OFF.", CType(vbOKCancel + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbCancel Then Exit Sub
        SendTheString("M220 S100")
        SendTheString("M221 S100")
        SendTheString("M106 S0")
        SendTheString("M104 S0")
        If My.Settings.Heated_Bed Then
            SendTheString("M140 S0")
        End If
        If My.Settings.Heated_Build_Volume Then
            SendTheString("M141 S0")
        End If
        SendTheString("M84 X Y E")
        SendTheString("M117 All Off")
        SendTheString("M118 All Off")
        StrToSend = ""
        With Me
            .FloBox.Text = "100"
            .FeedBox.Text = "100"
            '.HeatBox.Text = 0
            '.BedBox.Text = 0
            '.FanBox.Text = 0
            .FanSend.Checked = False
            .FanSend.BackColor = Color.LightPink
        End With
    End Sub

    Private Sub FloUpBut_Click(sender As Object, e As EventArgs) Handles FloUpBut.Click
        With Me
            .FloBox.Text = CStr(CInt(.FloBox.Text) + 5)
            If Val(.FloBox.Text) > 150 Then .FloBox.Text = CStr(150)
        End With
    End Sub

    Private Sub FloDnBut_Click(sender As Object, e As EventArgs) Handles FloDnBut.Click
        With Me
            .FloBox.Text = CStr(CInt(.FloBox.Text) - 5)
            If Val(.FloBox.Text) < 50 Then .FloBox.Text = CStr(50)
        End With
    End Sub

    Private Sub FloSend_Click(sender As Object, e As EventArgs) Handles FloSend.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M221 S" & Me.FloBox.Text
        SendTheString(StrToSend)
        StrToSend = "M117 Flow " & Me.FloBox.Text & "%"
        SendTheString(StrToSend)
        StrToSend = "M118 Flow " & Me.FloBox.Text & "%"
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub FeedUpBut_Click(sender As Object, e As EventArgs) Handles FeedUpBut.Click
        Me.FeedBox.Text = CStr(CInt(Me.FeedBox.Text) + 5)
        If Val(Me.FeedBox.Text) > 200 Then Me.FeedBox.Text = CStr(200)
    End Sub

    Private Sub FeedDnBut_Click(sender As Object, e As EventArgs) Handles FeedDnBut.Click
        With Me
            .FeedBox.Text = CStr(CInt(.FeedBox.Text) - 5)
            If CInt(.FeedBox.Text) < 30 Then .FeedBox.Text = CStr(30)
        End With
    End Sub

    Private Sub FeedSend_Click(sender As Object, e As EventArgs) Handles FeedSend.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M220 S" & Me.FeedBox.Text
        SendTheString(StrToSend)
        SendTheString("M118 Feed " & Me.FeedBox.Text & "%")
        StrToSend = ""
    End Sub

    Private Sub HotEndUpBut_Click(sender As Object, e As EventArgs) Handles HotEndUpBut.Click
        With Me
            If CInt(.HeatBox.Text) = 0 Then .HeatBox.Text = CStr(150)
            .HeatBox.Text = CStr(CInt(.HeatBox.Text) + 5)
            If Val(.HeatBox.Text) > 260 Then .HeatBox.Text = CStr(260)
        End With
    End Sub

    Private Sub HotEndDnBut_Click(sender As Object, e As EventArgs) Handles HotEndDnBut.Click
        With Me
            .HeatBox.Text = CStr(CInt(.HeatBox.Text) - 5)
            If Val(.HeatBox.Text) < 130 Then .HeatBox.Text = CStr(0)
        End With
    End Sub

    Private Sub HeatSend_Click(sender As Object, e As EventArgs) Handles HeatSend.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        If AllResponses = False Then Me.TextBox1.Text = ""
        With Me
            If Val(.HeatBox.Text) > 260 Then .HeatBox.Text = "260"
            If Val(.HeatBox.Text) < 0 Then .HeatBox.Text = "0"
            If .HotEndActiveChk.Checked Then
                StrToSend = "M104 S" & .HeatBox.Text
                SendTheString(StrToSend)
            End If
            If .HotEnd1Check.Checked Then
                StrToSend = "M104 S" & .HeatBox.Text & " T0"
                SendTheString(StrToSend)
            End If
            If .HotEnd2Check.Checked Then
                StrToSend = "M104 S" & .HeatBox.Text & " T1"
                SendTheString(StrToSend)
            End If
            If .HotEnd3Check.Checked Then
                StrToSend = "M104 S" & .HeatBox.Text & " T2"
                SendTheString(StrToSend)
            End If
            If .HotEnd4Check.Checked Then
                StrToSend = "M104 S" & .HeatBox.Text & " T3"
                SendTheString(StrToSend)
            End If
        End With
        SendTheString("M118 Hot End Temp " & Me.HeatBox.Text)
        StrToSend = ""
    End Sub

    Private Sub BedUpBut_Click(sender As Object, e As EventArgs) Handles BedUpBut.Click
        With Me
            If Val(.BedBox.Text) = 0 Then .BedBox.Text = CStr(35)
            .BedBox.Text = CStr(CInt(.BedBox.Text) + 5)
            If CInt(.BedBox.Text) > 110 Then .BedBox.Text = CStr(110)
        End With
    End Sub

    Private Sub BedDnBut_Click(sender As Object, e As EventArgs) Handles BedDnBut.Click
        With Me
            .BedBox.Text = CStr(CInt(.BedBox.Text) - 5)
            If Val(.BedBox.Text) < 40 Then .BedBox.Text = CStr(0)
        End With
    End Sub

    Private Sub BedSend_Click(sender As Object, e As EventArgs) Handles BedSend.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        If CInt(Me.BedBox.Text) > 110 Then Me.BedBox.Text = CStr(110)
        If Val(Me.BedBox.Text) < 0 Then Me.BedBox.Text = CStr(0)
        StrToSend = "M140 S" & Me.BedBox.Text
        SendTheString(StrToSend)
        SendTheString("M118 Bed " & Me.BedBox.Text)
        StrToSend = ""
    End Sub

    Private Sub FanUpBut_Click(sender As Object, e As EventArgs) Handles FanUpBut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False And Me.FanSend.Checked = True Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PWMSpeed = 0
        With Me
            If Val(.FanBox.Text) = 0 Then .FanBox.Text = CStr(10)
            .FanBox.Text = CStr(CInt(.FanBox.Text) + 10)
            If Val(.FanBox.Text) > 100 Then .FanBox.Text = CStr(100)
            PWMSpeed = CInt(Math.Ceiling(255 * CInt(.FanBox.Text) * 0.01))
            If .FanSend.Checked = True Then
                StrToSend = "M106 S" & PWMSpeed
                SendTheString(StrToSend)
                SendTheString("M118 Fan Speed " & .FanBox.Text & "%")
                StrToSend = ""
            End If
        End With
    End Sub

    Private Sub FanDnBut_Click(sender As Object, e As EventArgs) Handles FanDnBut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False And Me.FanSend.Checked = True Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PWMSpeed = 0
        With Me
            .FanBox.Text = CStr(CInt(.FanBox.Text) - 10)
            If Val(.FanBox.Text) < 20 Then .FanBox.Text = CStr(0)
            PWMSpeed = CInt(Math.Ceiling(255 * CInt(.FanBox.Text) * 0.01))
            If .FanSend.Checked = True Then
                If Val(.FanBox.Text) = 0 Then
                    StrToSend = "M106 S0"
                    SendTheString(StrToSend)
                    StrToSend = ""
                    Exit Sub
                End If
                StrToSend = "M106 S" & PWMSpeed
                SendTheString(StrToSend)
                SendTheString("M118 Fan Speed " & .FanBox.Text & "%")
                StrToSend = ""
            End If
        End With
    End Sub

    Private Sub FanSend_CheckedChanged(sender As Object, e As EventArgs) Handles FanSend.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Me.FanSend.Checked = False
            Exit Sub
        End If
        Dim PWMSpeed = 0
        With Me
            If Val(.FanBox.Text) > 100 Then .FanBox.Text = "100"
            If Val(.FanBox.Text) < 0 Then .FanBox.Text = "0"
            If .FanSend.Checked = True Then
                PWMSpeed = CInt(Math.Ceiling(255 * CInt(.FanBox.Text) * 0.01))
                StrToSend = "M106 S" & PWMSpeed
                .FanSend.BackColor = Color.LightGreen
                .FanSend.Text = "Fan ON"
            Else
                StrToSend = "M106 S0"
                .FanSend.BackColor = Color.Aqua
                .FanSend.Text = "Fan Off"
            End If
        End With
        SendTheString(StrToSend)
        If StrToSend = "M106 S0" Then
            SendTheString("M118 Fan Off")
        Else
            SendTheString("M118 Fan Speed " & Me.FanBox.Text & "%")
        End If
        StrToSend = ""
    End Sub

    Private Sub CBStep4_Click(sender As Object, e As EventArgs) Handles CBStep4.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Call SendTheString("G0 F5000 Z10")
        Dim TheX = Val(My.Settings.Lev_LRx)
        Dim TheY = Val(My.Settings.Lev_LRy)
        Dim TheZ = Val(My.Settings.Lev_LRz)
        StrToSend = "G0 X" & TheX & " Y" & TheY & " F6000"
        Call SendTheString(StrToSend)
        StrToSend = "G0 F500 Z" & TheZ
        Call SendTheString(StrToSend)
        StrToSend = "M117 Left Rear"
        Call SendTheString(StrToSend)
        StrToSend = "M118 Left Rear"
        Call SendTheString(StrToSend)
        Me.DisableSteppersButt.Checked = False
        Me.CBStep4.Text = "Left Rear" & vbLf & TheX & ", " & TheY & ", " & TheZ
        StrToSend = ""
    End Sub

    Private Sub CBHome_Click(sender As Object, e As EventArgs) Handles CBHome.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "G28 X Y"
        SendTheString(StrToSend)
        StrToSend = "G28 Z"
        SendTheString(StrToSend)
        Me.DisableSteppersButt.Checked = False
        SendTheString("M118 Auto-Home All")
        StrToSend = ""
    End Sub

    Private Sub CBStep3_Click(sender As Object, e As EventArgs) Handles CBStep3.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("G0 F5000 Z10")
        Dim TheX = Val(My.Settings.Lev_RRx)
        Dim TheY = Val(My.Settings.Lev_RRy)
        Dim TheZ = Val(My.Settings.Lev_RRz)
        StrToSend = "G0 X" & TheX & " Y" & TheY & " F6000"
        SendTheString(StrToSend)
        StrToSend = "G0 F500 Z" & TheZ
        SendTheString(StrToSend)
        StrToSend = "M117 Right Rear"
        SendTheString(StrToSend)
        StrToSend = "M118 Right Rear"
        SendTheString(StrToSend)
        StrToSend = ""
        Me.DisableSteppersButt.Checked = False
        Me.CBStep3.Text = "Right Rear" & vbLf & TheX & ", " & TheY & ", " & TheZ
    End Sub

    Private Sub CBStep1_Click(sender As Object, e As EventArgs) Handles CBStep1.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("G0 F5000 Z10")
        Dim TheX = Val(My.Settings.Lev_LFx)
        Dim TheY = Val(My.Settings.Lev_LFy)
        Dim TheZ = Val(My.Settings.Lev_LFz)
        StrToSend = "G0 X" & TheX & " Y" & TheY & " F6000"
        SendTheString(StrToSend)
        StrToSend = "G0 F500 Z" & TheZ
        SendTheString(StrToSend)
        StrToSend = "M117 Left Front"
        SendTheString(StrToSend)
        StrToSend = "M118 Left Front"
        SendTheString(StrToSend)
        StrToSend = ""
        Me.DisableSteppersButt.Checked = False
        Me.CBStep1.Text = "Left Front" & vbLf & TheX & ", " & TheY & ", " & TheZ
    End Sub

    Private Sub CBStep2_Click(sender As Object, e As EventArgs) Handles CBStep2.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("G0 F5000 Z10")
        Dim TheX = Val(My.Settings.Lev_RFx)
        Dim TheY = Val(My.Settings.Lev_RFy)
        Dim TheZ = Val(My.Settings.Lev_RFz)
        StrToSend = "G0 X" & TheX & " Y" & TheY & " F6000"
        SendTheString(StrToSend)
        StrToSend = "G0 F500 Z" & TheZ
        SendTheString(StrToSend)
        StrToSend = "M117 Right Front"
        SendTheString(StrToSend)
        StrToSend = "M118 Right Front"
        SendTheString(StrToSend)
        Me.DisableSteppersButt.Checked = False
        StrToSend = ""
        Me.CBStep2.Text = "Right Front" & vbLf & TheX & ", " & TheY & ", " & TheZ
    End Sub

    Private Sub CBStepMid_Click(sender As Object, e As EventArgs) Handles CBStepMid.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("G0 F5000 Z10")
        Dim TheX = Val(My.Settings.Lev_MIDx)
        Dim TheY = Val(My.Settings.Lev_MIDy)
        Dim TheZ = Val(My.Settings.Lev_MIDz)
        StrToSend = "G0 X" & TheX & " Y" & TheY & " F6000"
        SendTheString(StrToSend)
        StrToSend = "G0 F500 Z" & TheZ
        SendTheString(StrToSend)
        StrToSend = "M117 Middle"
        SendTheString(StrToSend)
        StrToSend = "M118 Middle"
        SendTheString(StrToSend)
        StrToSend = ""
        Me.DisableSteppersButt.Checked = False
        Me.CBStepMid.Text = "Middle" & vbLf & TheX & ", " & TheY & ", " & TheZ
    End Sub

    Private Sub ParkButt_Click(sender As Object, e As EventArgs) Handles ParkButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim TheX = Val(My.Settings.PrePr_x)
        Dim TheY = Val(My.Settings.Bed_Ymax)
        Dim TheZ = Val(My.Settings.PrePr_z)
        StrToSend = "G91"
        SendTheString(StrToSend)
        StrToSend = "G0 Z" & TheZ
        SendTheString(StrToSend)
        StrToSend = "G90"
        SendTheString(StrToSend)
        StrToSend = "G0 Y" & TheY & " F5000"
        SendTheString(StrToSend)
        StrToSend = "M117 Present Print"
        Call SendTheString(StrToSend)
        StrToSend = "M118 Present Print"
        SendTheString(StrToSend)
        StrToSend = ""
        Me.DisableSteppersButt.Checked = False
        Me.ParkButt.Text = "Present Print" & vbLf & "Y " & My.Settings.Bed_Ymax & " (Absolute)   Z " & My.Settings.PrePr_z & " (Relative)"
    End Sub

    Private Sub DisableSteppersButt_CheckedChanged(sender As Object, e As EventArgs) Handles DisableSteppersButt.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        With Me
            If .DisableSteppersButt.Checked = True Then
                StrToSend = "M18 X Y"
                .DisableSteppersButt.Text = "X & Y Disabled"
                .DisableSteppersButt.BackColor = Color.LightGreen
                SendTheString("M118 X and Y Disabled")
            Else
                StrToSend = "M17"
                .DisableSteppersButt.Text = "X Y Enabled"
                .DisableSteppersButt.BackColor = Color.Pink
                SendTheString("M118 Steppers Enabled")
            End If
        End With
        SendTheString(StrToSend)
        'StrToSend = ""
    End Sub

    Private Sub StepOnOffBut_CheckedChanged(sender As Object, e As EventArgs) Handles StepOnOffBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        If ButtonReset = True Then
            ButtonReset = False
            Me.StepOnOffBut.Checked = False
            Me.StepOnOffBut.Text = "Stepper 2min"
            Me.StepOnOffBut.BackColor = Color.LightGreen
            Exit Sub
        End If
        With Me.StepOnOffBut
            If .Checked = True Then
                StrToSend = "M18 S14400"
                .Text = "Stepper 4hr"
                .BackColor = Color.Pink
            Else
                StrToSend = "M18 S120"
                .Text = "Stepper 2min"
                .BackColor = Color.LightGreen
            End If
        End With
        SendTheString(StrToSend)
        SendTheString("M118 Disarm = " & Me.StepOnOffBut.Text)
        StrToSend = ""
    End Sub

    Private Sub CBG0_Click(sender As Object, e As EventArgs) Handles CBG0.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "G0"
        Dim XStr As String
        Dim Ystr As String
        Dim ZStr As String
        Dim SStr As String

        With Me
            If .Box_X.Text <> "" Then
                XStr = " X" & .Box_X.Text
            Else
                XStr = ""
            End If
            If .Box_Y.Text <> "" Then
                Ystr = " Y" & .Box_Y.Text
            Else
                Ystr = ""
            End If
            If .Box_Z.Text <> "" Then
                ZStr = " Z" & .Box_Z.Text
            Else
                ZStr = ""
            End If
            If .Box_S.Text <> "" Then
                SStr = " F" & Val(.Box_S.Text) * 60
            Else
                SStr = ""
            End If
            If SStr = "" And XStr = "" And Ystr = "" And ZStr = "" Then Exit Sub
            StrToSend &= XStr & Ystr & ZStr & SStr
            Call SendTheString(StrToSend)
            StrToSend = ""
        End With
        Me.DisableSteppersButt.Checked = False
    End Sub

    Private Sub GoChangeNozButt_Click(sender As Object, e As EventArgs) Handles GoChangeNozButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("G28")
        Dim Xval = " X" & Val(My.Settings.ChngNoz_x)
        Dim Yval = " Y" & Val(My.Settings.ChngNoz_y)
        Dim Zval = " Z" & Val(My.Settings.ChngNoz_z)
        Dim Fval = " F" & Val(Me.Box_S.Text) * 60
        StrToSend = "G0" & Xval & Yval & Zval & Fval
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub GoCalEButt_Click(sender As Object, e As EventArgs) Handles GoCalEButt.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("G28")
        Dim Xval = " X" & Val(My.Settings.Cali_E_x)
        Dim Yval = " Y" & Val(My.Settings.Cali_E_y)
        Dim Zval = " Z" & Val(My.Settings.Cali_E_z)
        Dim Fval = " F" & Val(Me.Box_S.Text) * 60
        StrToSend = "G0" & Xval & Yval & Zval & Fval
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub ColdExtButt_CheckedChanged(sender As Object, e As EventArgs) Handles ColdExtButt.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        With Me
            If ButtonReset = True Then
                .ColdExtButt.Text = "Cold Ext 175°"
                .ColdExtButt.BackColor = Color.Pink
                ButtonReset = False
                Exit Sub
            End If
            If .ColdExtButt.Checked = True Then
                StrToSend = "M302 S0"
                .ColdExtButt.Text = "Allow Cold Ext"
                .ColdExtButt.BackColor = Color.LightGreen
            ElseIf .ColdExtButt.Checked = False Then
                StrToSend = "M302 S175"
                .ColdExtButt.Text = "Cold Ext 175°"
                .ColdExtButt.BackColor = Color.Pink
            End If
        End With
        SendTheString(StrToSend)
        SendTheString("M118 Cold Extrude Setting = " & Me.ColdExtButt.Text)
        StrToSend = ""
    End Sub

    Private Sub CBRetract_Click(sender As Object, e As EventArgs) Handles CBRetract.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If

        '#Disable Warning IDE0059 ' Unnecessary assignment of a value
        Dim Speed = 100

        StrToSend = "M83"
        SendTheString(StrToSend)
        If Me.ColdExtButt.Checked = False Then
            Speed = 100
        Else
            Speed = 300
        End If
        '#Enable Warning IDE0059 ' Unnecessary assignment of a value
        StrToSend = "G1 E" & CLng(Me.Box_E_Retract.Text) * -1 & " F1000"
        SendTheString(StrToSend)
        StrToSend = "M82"
        SendTheString(StrToSend)
        StrToSend = "G0 F3500"
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub CBExtrude_Click(sender As Object, e As EventArgs) Handles CBExtrude.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M83"
        SendTheString(StrToSend)
        Dim Speed As Integer
        If Me.ColdExtButt.Checked = False Then
            Speed = 150
        Else
            Speed = 300
        End If
        StrToSend = "G0 E" & Me.Box_E.Text & " F" & CStr(Speed)
        SendTheString(StrToSend)
        StrToSend = "M82"
        SendTheString(StrToSend)
        StrToSend = "G0 F5000"
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub Box_E_TextChanged(sender As Object, e As EventArgs) Handles Box_E.TextChanged
        Me.Box_E2.Text = Me.Box_E.Text
    End Sub

    Private Sub ClearResponseButt_CheckedChanged(sender As Object, e As EventArgs) Handles ClearResponseButt.CheckedChanged
        If Me.ClearResponseButt.Checked = False Then
            AllResponses = True
            Me.ClearResponseButt.Text = "Show All Responses"
        Else
            AllResponses = False
            Me.ClearResponseButt.Text = "Single Response"
            StrToSend = ""
        End If
    End Sub

    Private Sub ClockButt_CheckedChanged(sender As Object, e As EventArgs) Handles ClockButt.CheckedChanged
        On Error Resume Next
        Dim CurrentTime As DateTime
        Dim Hrs = "00"
        If Me.ClockButt.Checked = True Then
            Me.ClockButt.BackColor = Color.Pink
            Me.ClockButt.Text = "Split Time"
        End If
        If StartTime = Nothing Then
            StartTime = Now
            Exit Sub
        End If
        CurrentTime = Now
        With Me
            If .ClockButt.Checked = False Then
                .ClockButt.BackColor = Color.Pink
                .ClockButt.Text = "Running"
                TotalTime = CStr(CurrentTime.AddHours(Hour(StartTime) * -1).AddMinutes(Minute(StartTime) * -1).AddSeconds(Second(StartTime) * -1))
                If Hour(CDate(TotalTime)) = 12 And Microsoft.VisualBasic.Right(TotalTime, 2) = "AM" Then
                    Hrs = "00"
                Else
                    Hrs = CStr(Hour(CDate(TotalTime)))
                End If
                .ClockBox.Text = Format(Hrs, "00") & ":" & Format(Minute(CDate(TotalTime)), "00") & ":" & Format(Second(CDate(TotalTime)), "00")
                .PrintLayerTime.Text = .ClockBox.Text
            End If
        End With
    End Sub

    Private Sub ClockClearButt_Click(sender As Object, e As EventArgs) Handles ClockClearButt.Click
        Me.ClockButt.Checked = False
        Me.ClockBox.Text = "00:00:00"
        Me.ClockButt.Text = "Stop Watch"
        Me.ClockButt.BackColor = Color.LightGreen
        StartTime = Nothing
    End Sub

    Private Sub LayerZBox_TextChanged(sender As Object, e As EventArgs) Handles LayerZBox.TextChanged
        MyLay = False
        MyZ = True
    End Sub

    Private Sub LayerBox_TextChanged(sender As Object, e As EventArgs) Handles LayerBox.TextChanged
        MyLay = True
        MyZ = False
    End Sub

    Private Sub CBLayer_Click(sender As Object, e As EventArgs) Handles CBLayer.Click
        With Me
            If Val(.Layer1Box.Text) = Val(.LayerHgtBox.Text) Then
                If MyZ Then .LayerBox.Text = CStr(Val(.LayerZBox.Text) / Val(.LayerHgtBox.Text))
                If MyLay Then .LayerZBox.Text = CStr(Val(.LayerHgtBox.Text) * Val(.LayerBox.Text))
            Else
                If MyZ Then .LayerBox.Text = CStr(((CLng(.LayerZBox.Text) - CLng(.Layer1Box.Text)) / CLng(.LayerHgtBox.Text)) + 1)
                If MyLay Then .LayerZBox.Text = CStr((CLng(.LayerHgtBox.Text) * (CLng(.LayerBox.Text) - 1)) + CLng(.Layer1Box.Text))
            End If
        End With
    End Sub

    Private Sub MatlDnBut_Click(sender As Object, e As EventArgs) Handles MatlDnBut.Click
        If MatlSelection = Nothing Then MatlSelection = "5"
        With Me
            MatlSelection = CStr(CInt(MatlSelection) - 1)
            If CInt(MatlSelection) < 1 Then MatlSelection = CStr(4)
            Select Case CInt(MatlSelection)
                Case Is = 1
                    .MaterialType.Text = My.Settings.Matl1_Name
                    .HeatBox.Text = My.Settings.Matl1_Hot
                    .BedBox.Text = My.Settings.Matl1_Bed
                    .FanBox.Text = My.Settings.Matl1_Fan
                Case Is = 2
                    .MaterialType.Text = My.Settings.Matl2_Name
                    .HeatBox.Text = My.Settings.Matl2_Hot
                    .BedBox.Text = My.Settings.Matl2_Bed
                    .FanBox.Text = My.Settings.Matl2_Fan
                Case Is = 3
                    .MaterialType.Text = My.Settings.Matl3_Name
                    .HeatBox.Text = My.Settings.Matl3_Hot
                    .BedBox.Text = My.Settings.Matl3_Bed
                    .FanBox.Text = My.Settings.Matl3_Fan
                Case Else
                    .MaterialType.Text = My.Settings.Matl4_Name
                    .HeatBox.Text = My.Settings.Matl4_Hot
                    .BedBox.Text = My.Settings.Matl4_Bed
                    .FanBox.Text = My.Settings.Matl4_Fan
            End Select
        End With
    End Sub

    Private Sub MatlUpBut_Click(sender As Object, e As EventArgs) Handles MatlUpBut.Click
        If MatlSelection = Nothing Then MatlSelection = "0"
        With Me
            MatlSelection = CStr(CInt(MatlSelection) - 1)
            If CInt(MatlSelection) > 4 Then MatlSelection = "1"
            Select Case CInt(MatlSelection)
                Case Is = 1
                    .MaterialType.Text = My.Settings.Matl1_Name
                    .HeatBox.Text = My.Settings.Matl1_Hot
                    .BedBox.Text = My.Settings.Matl1_Bed
                    .FanBox.Text = My.Settings.Matl1_Fan
                Case Is = 2
                    .MaterialType.Text = My.Settings.Matl2_Name
                    .HeatBox.Text = My.Settings.Matl2_Hot
                    .BedBox.Text = My.Settings.Matl2_Bed
                    .FanBox.Text = My.Settings.Matl2_Fan
                Case Is = 3
                    .MaterialType.Text = My.Settings.Matl3_Name
                    .HeatBox.Text = My.Settings.Matl3_Hot
                    .BedBox.Text = My.Settings.Matl3_Bed
                    .FanBox.Text = My.Settings.Matl3_Fan
                Case Else
                    .MaterialType.Text = My.Settings.Matl4_Name
                    .HeatBox.Text = My.Settings.Matl4_Hot
                    .BedBox.Text = My.Settings.Matl4_Bed
                    .FanBox.Text = My.Settings.Matl4_Fan
            End Select
        End With
    End Sub

    Private Sub ApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplicationToolStripMenuItem.Click
        GCODE_Settings.ShowDialog()
        GCODE_Settings.BringToFront()
    End Sub

    Private Sub PrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrinterToolStripMenuItem.Click
        On Error Resume Next
        PrinterSettings.Show()
        PrinterSettings.BringToFront()
    End Sub

    Private Sub StatsPanel_DoubleClick(sender As Object, e As EventArgs) Handles StatsPanel.DoubleClick
        Call TuneUpToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub TuneUpPanel_DoubleClick(sender As Object, e As EventArgs) Handles TuneUpPanel.DoubleClick
        Call StatisticsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PreHeatBut_Click(sender As Object, e As EventArgs) Handles PreHeatBut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If PreHeatSync Then
            If Val(My.Settings.NumOfExtruders) >= 1 Then
                StrToSend = "M104 S" & Me.HeatBox.Text & " T0"
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) >= 2 Then
                StrToSend = "M104 S" & Me.HeatBox.Text & " T1"
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) >= 3 Then
                StrToSend = "M104 S" & Me.HeatBox.Text & " T2"
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) = 4 Then
                StrToSend = "M104 S" & Me.HeatBox.Text & " T3"
                SendTheString(StrToSend)
            End If
            If My.Settings.Heated_Bed Then
                StrToSend = "M140 S" & Me.BedBox.Text
                SendTheString(StrToSend)
            End If
        ElseIf Not PreHeatSync Then
            If My.Settings.Heated_Bed Then
                StrToSend = "M190 S" & Me.BedBox.Text
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) >= 1 Then
                StrToSend = "M109 S" & Me.HeatBox.Text & " T0"
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) >= 2 Then
                StrToSend = "M109 S" & Me.HeatBox.Text & " T1"
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) >= 3 Then
                StrToSend = "M109 S" & Me.HeatBox.Text & " T2"
                SendTheString(StrToSend)
            End If
            If Val(My.Settings.NumOfExtruders) = 4 Then
                StrToSend = "M109 S" & Me.HeatBox.Text & " T3"
                SendTheString(StrToSend)
            End If

        End If
        StrToSend = ""
    End Sub

    Private Sub CBCurrentTemp_Click(sender As Object, e As EventArgs) Handles CBCurrentTemp.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M105"
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub CBGetTempContButt_CheckedChanged(sender As Object, e As EventArgs) Handles CBGetTempContButt.CheckedChanged
        On Error Resume Next
        With Me
            If .Vcomm.IsOpen = False Then
                MsgBox("The port is closed.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            If CheckDefeat = True Then Exit Sub
            CheckDefeat = True
            If .CBGetTempContButt.Checked = True Then
                StrToSend = "M155 S" & .TempIntervalBox.Text
                .CBGetTempContButt.Text = "Report ON"
                .CBGetTempContButt.BackColor = Color.Khaki
                CheckDefeat = True
                .TimerLabel.Visible = True
                Call ThreeMinuteTimer()
            Else
                StrToSend = "M155 S0"
                .CBGetTempContButt.Text = "Report Temp"
                .CBGetTempContButt.BackColor = Color.LightGreen
                CheckDefeat = False
                .TimerLabel.Visible = False
            End If
        End With
        SendTheString(StrToSend)
        StrToSend = ""
        CheckDefeat = False
    End Sub

    Private Sub ButEquals_Click(sender As Object, e As EventArgs) Handles ButEquals.Click
        On Error GoTo EHandler
        With Me
            If Val(.Math2box.Text) = 0 And .ButDiv.Checked = True Then
                MsgBox("You still can't divide by zero", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Valiant User")
                .Math2box.Focus()
                Exit Sub
            End If
            If .ButAdd.Checked = True Then
                .MathAbox.Text = CStr(CSng(Math1box.Text) + CSng(Math2box.Text))
            ElseIf .ButSubtract.Checked = True Then
                .MathAbox.Text = CStr(CSng(Math1box.Text) - CSng(Math2box.Text))
            ElseIf .ButMulti.Checked = True Then
                .MathAbox.Text = Format(CSng(Math1box.Text) * CSng(Math2box.Text), "0.000")
            ElseIf .ButDiv.Checked = True Then
                .MathAbox.Text = Format(CSng(Math1box.Text) / CSng(Math2box.Text), "0.000")
            End If
        End With
        Exit Sub
EHandler:
        MsgBox("There was an error in ""Mainform.ButEquals_Click""" & vbLf & vbLf & Err.Description, CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        AboutForm.Show()
        AboutForm.BringToFront()
    End Sub

    Public WithEvents Timer As New System.Windows.Forms.Timer
    Sub ThreeMinuteTimer()
        TheTimer.Enabled = True
        TheTimer.Interval = 1000 * 60 * 3 '3 minutes
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TheTimer.Tick
        Me.CBGetTempContButt.Checked = False
        TheTimer.Enabled = False
        TempCalled = False
    End Sub

    Public WithEvents PortTimer As New System.Windows.Forms.Timer
    Sub FifeenSecondTimer()
        PortTimer.Enabled = True
        PortTimer.Interval = 1000 * 15 * 1 '15 seconds
    End Sub

    Private Sub PortTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PortTimer.Tick
        Dim PortString As String = ""
        If Me.Vcomm.IsOpen Then
            PortTimer.Enabled = False
            Exit Sub
        End If
        If My.Computer.Ports.SerialPortNames.Count > 0 Then
            For Each Po In My.Computer.Ports.SerialPortNames
                PortString += Po & ", "
            Next
            PortTimer.Enabled = False
            Dim AResponse As MsgBoxResult
            AResponse = MsgBox("COM port(s) available: " & PortString & " ." & vbCr & vbCr & "Do you want to connect to a Port?" & vbCr & "(YES will attempt to connect.  NO will continue to poll.  CANCEL will stop polling)", vbYesNoCancel, "Greg's Toolbox")
            If AResponse = vbYes Then
                Me.ComOpenBut.Checked = True
            ElseIf AResponse = vbNo Then
                PortTimer.Enabled = True
                PortTimer.Interval = 1000 * 5 * 1 '5 seconds
            ElseIf AResponse = vbCancel Then
                PortTimer.Enabled = False
            End If
        End If
    End Sub

    Private Sub NotepadBut_Click(sender As Object, e As EventArgs) Handles NotepadBut.Click
        On Error Resume Next
        If Me.GCODE_FileNameBox.Text = "" Then
            MsgBox("The GCODE File Name box cannot be empty." & vbLf & vbLf & "Use the ""Get Gcode File Name"" button.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        Else
            If IsRunningExe("notepad.exe") Then
                Dim MyGcodeFile = Me.GCODE_FileNameBox.Text
                Do Until InStr(1, MyGcodeFile, "\") = 0
                    MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
                Loop
                AppActivate(MyGcodeFile & " - Notepad")
                If Err.Number <> 0 Then
                    System.Diagnostics.Process.Start("notepad.exe", Me.GCODE_FileNameBox.Text)
                    Err.Clear()
                End If
                Exit Sub
            End If
            System.Diagnostics.Process.Start("notepad.exe", Me.GCODE_FileNameBox.Text)
        End If
    End Sub

    Private Sub ConvertBut_Click(sender As Object, e As EventArgs) Handles ConvertBut.Click
        On Error Resume Next
        Dim TopNum As Integer = 1
        Dim BtmNum As Integer = 512
        Dim WholeNum As Integer
        Dim FracNum As Double = 1
        With Me
            .BarbInBox.Text = Format(Val(MathAbox.Text) / 25.4, "0.000") & " in."
            WholeNum = CInt(CSng(MathAbox.Text) / 25.4)
            FracNum = (CInt(MathAbox.Text) / 25.4) - WholeNum
            TopNum = CInt(Math.Floor(CSng(FracNum) * CInt(BtmNum)))
            If TopNum = 0 Then GoTo EvenSteven
            Do Until IsOdd(TopNum) = True
                TopNum = CInt(TopNum / 2)
                BtmNum = CInt(BtmNum / 2)
            Loop
EvenSteven:
            If WholeNum = 0 Then
                WholeNum = CInt(Format(WholeNum, "0"))
                WholeNum = CInt("")
            End If
            If TopNum > 0 Then
                .BarbFracBox.Text = WholeNum & " " & TopNum & "/" & BtmNum & " in."
            Else
                If Str(WholeNum) = "" Then WholeNum = 0
                .BarbFracBox.Text = WholeNum & " in."
            End If
            .BarbFBox.Text = Format((Val(.MathAbox.Text) * 1.8) + 32, "0.0") & " °F"
        End With
    End Sub
    Function IsOdd(ByVal iNum As Integer) As Boolean
        IsOdd = ((iNum \ 2) * 2 <> iNum)
    End Function

    Private Sub G29But_Click(sender As Object, e As EventArgs) Handles G29But.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = My.Settings.AutoLevelCMD
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub GCODECmdListBut_Click(sender As Object, e As EventArgs) Handles GCODECmdListBut.Click
        On Error GoTo EHandler
        Dim TheDirectory = EnderApp.My.Application.Info.DirectoryPath
        Dim FilePath = TheDirectory & "\GCOList.txt"
        If System.IO.File.Exists(FilePath) = False Then
            MsgBox("The Gcode List text file was not found.", CType(vbOKOnly & vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        'Dim TheDirectory = "C:\Users\Home\source\repos\EnderApp"
        If IsRunningExe("notepad.exe") Then
            On Error Resume Next
            For Each p As Process In Process.GetProcessesByName("notepad")
                ShowWindow(p.MainWindowHandle, SHOW_WINDOW.SW_NORMAL)
            Next p
            AppActivate("GCOList.txt - Notepad")
            If Err.Number <> 0 Then
                Err.Clear()
                MyNotePad = Process.Start("notepad.exe", TheDirectory & "\GCOList.txt")
            End If
            Exit Sub
        End If
        MyNotePad = Process.Start("notepad.exe", TheDirectory & "\GCOList.txt")
        Exit Sub
EHandler:
        MsgBox("There was an error opening the text file ""Mainform.GCODECmdListBut_Click"".", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Declare Function ShowWindow Lib "user32.dll" (
ByVal hWnd As IntPtr,
ByVal nCmdShow As SHOW_WINDOW) As Boolean

    Private Enum SHOW_WINDOW As Integer
        SW_HIDE = 0
        SW_SHOWNORMAL = 1
        SW_NORMAL = 1
        SW_SHOWMINIMIZED = 2
        SW_SHOWMAXIMIZED = 3
        SW_MAXIMIZE = 3
        SW_SHOWNOACTIVATE = 4
        SW_SHOW = 5
        SW_MINIMIZE = 6
        SW_SHOWMINNOACTIVE = 7
        SW_SHOWNA = 8
        SW_RESTORE = 9
        SW_SHOWDEFAULT = 10
        SW_FORCEMINIMIZE = 11
        SW_MAX = 11
    End Enum
    Private Sub SlicerInfoBut_Click(sender As Object, e As EventArgs) Handles SlicerInfoBut.Click
        MsgBox("The following slicers (and their search info) support a search:" & vbCr & vbCr &
               "Cura (;layer:)" & vbCr &
               "Simplify3D (; layer )" & vbCr &
               "Slic3r (G1 Z)" & vbCr &
               "ideaMaker (;layer:)" & vbCr &
               "CraftWare (; Layer #)" & vbCr &
               "MatterSlice (; LAYER:)" & vbCr &
               "KISSlicer (BEGIN_LAYER_OBJECT)" & vbCr &
               "Unknown (;layer:)" & vbCr & vbCr &
               "Slicer's that don't support a search:" & vbCr &
               "Models sliced using Repetier-Host", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub DisableMovementBut_CheckedChanged(sender As Object, e As EventArgs) Handles DisableMovementBut.CheckedChanged
        On Error Resume Next
        If Me.DisableMovementBut.Checked = True Then
            Me.SDcardInitButt.Enabled = False
            Me.MovementPanel.Enabled = False
            Me.MovementToolStripMenuItem.Enabled = False
            Me.PrinterToolStripMenuItem.Enabled = False
            Me.CustomButtonGroup.Enabled = False
            Me.ScriptGroupBox.Enabled = False
            Me.GroupBox1.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.ChkBaudBut.Enabled = False
            Me.DisableMovementBut.Text = "Movement Controls are DISABLED for printing"
            Me.DisableMovementBut.BackColor = Color.Red
            Me.DisableMovementBut.ForeColor = Color.White
            Me.EnableMoveBut.BackColor = Color.Red
            Me.EnableMoveBut.ForeColor = Color.White
            Me.EnableMoveBut.Text = "Movement is DISABLED"
        ElseIf Me.DisableMovementBut.Checked = False Then
            Me.SDcardInitButt.Enabled = True
            Me.MovementPanel.Enabled = True
            Me.MovementToolStripMenuItem.Enabled = True
            Me.PrinterToolStripMenuItem.Enabled = True
            Me.CustomButtonGroup.Enabled = True
            Me.ScriptGroupBox.Enabled = True
            Me.GroupBox1.Enabled = True
            Me.GroupBox2.Enabled = True
            Me.ChkBaudBut.Enabled = True
            Me.DisableMovementBut.Text = "Movement Controls are ENABLED"
            Me.DisableMovementBut.BackColor = Color.LightGreen
            Me.DisableMovementBut.ForeColor = Color.Black
            Me.EnableMoveBut.BackColor = Color.LightGreen
            Me.EnableMoveBut.ForeColor = Color.Black
            Me.EnableMoveBut.Text = "Movement is ENABLED"
        End If
    End Sub

    Private Sub JogXplus_Click(sender As Object, e As EventArgs) Handles JogXplus.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "Jog X +" & JogDistance
        SendTheString("M400")
        SendTheString("G91")
        SendTheString("G1 F3600 X" & Val(JogDistance) + Val(My.Settings.HomeOffsetX))
        SendTheString("G90")
        StrToSend = ""
    End Sub

    Private Sub JogXminus_Click(sender As Object, e As EventArgs) Handles JogXminus.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "Jog X -" & JogDistance
        SendTheString("M400")
        SendTheString("G91")
        SendTheString("G1 F3600 X-" & Val(JogDistance) - Val(My.Settings.HomeOffsetX))
        SendTheString("G90")
        StrToSend = ""
    End Sub
    Private Sub JogYplus_Click(sender As Object, e As EventArgs) Handles JogYplus.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "Jog Y +" & JogDistance
        SendTheString("M400")
        SendTheString("M400")
        SendTheString("G91")
        SendTheString("G1 F3600 Y" & Val(JogDistance) + Val(My.Settings.HomeOffsetY))
        SendTheString("G90")
        StrToSend = ""
    End Sub

    Private Sub JogYminus_Click(sender As Object, e As EventArgs) Handles JogYminus.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "Jog Y -" & JogDistance
        SendTheString("M400")
        SendTheString("G91")
        SendTheString("G1 F3600 Y-" & Val(JogDistance) - Val(My.Settings.HomeOffsetY))
        SendTheString("G90")
        StrToSend = ""
    End Sub

    Private Sub JogZplus_Click(sender As Object, e As EventArgs) Handles JogZplus.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "Jog Z +" & JogDistance
        SendTheString("M400")
        SendTheString("G91")
        SendTheString("G1 F2700 Z" & Val(JogDistance) + Val(My.Settings.HomeOffsetZ))
        SendTheString("G90")
        StrToSend = ""
    End Sub

    Private Sub JogZminus_Click(sender As Object, e As EventArgs) Handles JogZminus.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "Jog Z -" & JogDistance
        SendTheString("M400")
        SendTheString("G91")
        SendTheString("G1 F2700 Z-" & Val(JogDistance) - Val(My.Settings.HomeOffsetZ))
        SendTheString("G90")
        StrToSend = ""
    End Sub

    Private Sub JogDist10_Click(sender As Object, e As EventArgs) Handles JogDist10.Click
        Me.JogDistLabel.Text = "Jog = 10.0"
        Me.JogDistLabel.BackColor = Me.JogDist10.BackColor
        JogDistance = "10"
    End Sub

    Private Sub JogDist1_Click(sender As Object, e As EventArgs) Handles JogDist1.Click
        Me.JogDistLabel.Text = "Jog = 1.0"
        Me.JogDistLabel.BackColor = Me.JogDist1.BackColor
        JogDistance = "1"
    End Sub

    Private Sub JogDist_1_Click(sender As Object, e As EventArgs) Handles JogDist_1.Click
        Me.JogDistLabel.Text = "Jog = 0.10"
        Me.JogDistLabel.BackColor = Me.JogDist_1.BackColor
        JogDistance = "0.1"
    End Sub

    Private Sub RaceBut_Click(sender As Object, e As EventArgs) Handles RaceBut.Click
        Dim AResponse As MsgBoxResult
        If Not Me.Vcomm.IsOpen Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If RacingForm.Visible = False Then
            AResponse = MsgBox("The build plate must be empty." & vbLf &
                            "Do not enter a build plate size that is larger than what you have." & vbLf &
                            "Setting either Accell or Jerk to 0 disables control of the setting." & vbLf & vbLf &
                            "Do you want to continue>", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then Exit Sub
        End If
        RacingForm.MaxX.Text = My.Settings.Bed_Xmax
        RacingForm.MaxY.Text = My.Settings.Bed_Ymax
        RacingForm.Show()
        RacingForm.BringToFront()
        RacingForm.Staged = False
    End Sub


    Private Sub CustomMacro_CheckedChanged(sender As Object, e As EventArgs) Handles CustomMacro.CheckedChanged
        If Me.CustomMacro.Checked = True Then
            Me.CustomMacro.Text = "Click to Edit" & vbLf & "a Custom Command"
            Me.CustomMacro.BackColor = Color.Yellow
            Me.Custom1.BackColor = Color.Yellow
            Me.Custom2.BackColor = Color.Yellow
            Me.Custom3.BackColor = Color.Yellow
            Me.Custom4.BackColor = Color.Yellow
        Else
            Me.CustomMacro.Text = "Click to Edit" & vbLf & "a Custom Command"
            Me.CustomMacro.BackColor = Color.Silver
            Me.Custom1.BackColor = Color.Lime
            Me.Custom2.BackColor = Color.Salmon
            Me.Custom3.BackColor = Color.Lime
            Me.Custom4.BackColor = Color.Salmon
        End If
    End Sub

    Private Sub Custom1_Click_1(sender As Object, e As EventArgs) Handles Custom1.Click
        On Error Resume Next

        If Me.CustomMacro.Checked = True Then
            Dim MyCustom1 As String = InputBox("Enter a ""G"" or ""M"" command and any parameters.  Your entry will be converted to Upper Case." & vbLf & vbLf &
                                               "An empty entry will clear the Command.  The CANCEL key will also clear an existing command.", "Set a Custom Command", My.Settings.Custom1)
            If MyCustom1 = "" Then
                My.Settings.Custom1 = ""
                Me.Custom1.Text = "Custom1"
                Me.RecoverTip.SetToolTip(Me.Custom1, "Empty")
            Else
                My.Settings.Custom1 = UCase(MyCustom1)
                Me.Custom1.Text = Strings.Left(My.Settings.Custom1, 4)
                Me.RecoverTip.SetToolTip(Me.Custom1, My.Settings.Custom1)
            End If
            Me.CustomMacro.Checked = False
            Exit Sub
        Else
            If Me.Vcomm.IsOpen = False Then
                MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            If My.Settings.Custom1 <> "" Then
                StrToSend = My.Settings.Custom1
                SendTheString(StrToSend)
                StrToSend = ""
            End If
        End If
    End Sub

    Private Sub Custom2_Click(sender As Object, e As EventArgs) Handles Custom2.Click
        On Error Resume Next

        If Me.CustomMacro.Checked = True Then
            Dim MyCustom2 As String = InputBox("Enter a ""G"" or ""M"" command and any parameters.  Your entry will be converted to Upper Case." & vbLf & vbLf &
                                               "An empty entry will clear the Command.  The CANCEL key will also clear an existing command.", "Set a Custom Command", My.Settings.Custom2)
            If MyCustom2 = "" Then
                My.Settings.Custom2 = ""
                Me.Custom2.Text = "Custom2"
                Me.RecoverTip.SetToolTip(Me.Custom2, "Empty")
            Else
                My.Settings.Custom2 = UCase(MyCustom2)
                Me.Custom2.Text = Strings.Left(My.Settings.Custom2, 4)
                Me.RecoverTip.SetToolTip(Me.Custom2, My.Settings.Custom2)
            End If
            Me.CustomMacro.Checked = False
            Exit Sub
        Else
            If Me.Vcomm.IsOpen = False Then
                MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            If My.Settings.Custom2 <> "" Then
                StrToSend = My.Settings.Custom2
                SendTheString(StrToSend)
                StrToSend = ""
            End If
        End If
    End Sub

    Private Sub Custom3_Click(sender As Object, e As EventArgs) Handles Custom3.Click
        On Error Resume Next

        If Me.CustomMacro.Checked = True Then
            Dim MyCustom3 As String = InputBox("Enter a ""G"" or ""M"" command and any parameters.  Your entry will be converted to Upper Case." & vbLf & vbLf &
                                               "An empty entry will clear the Command.  The CANCEL key will also clear an existing command.", "Set a Custom Command", My.Settings.Custom3)
            If MyCustom3 = "" Then
                My.Settings.Custom3 = ""
                Me.Custom3.Text = "Custom3"
                Me.RecoverTip.SetToolTip(Me.Custom3, "Empty")
            Else
                My.Settings.Custom3 = UCase(MyCustom3)
                Me.Custom3.Text = Strings.Left(My.Settings.Custom3, 4)
                Me.RecoverTip.SetToolTip(Me.Custom3, My.Settings.Custom3)
            End If
            Me.CustomMacro.Checked = False
            Exit Sub
        Else
            If Me.Vcomm.IsOpen = False Then
                MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            If My.Settings.Custom3 <> "" Then
                StrToSend = My.Settings.Custom3
                SendTheString(StrToSend)
                StrToSend = ""
            End If
        End If
    End Sub

    Private Sub Custom4_Click(sender As Object, e As EventArgs) Handles Custom4.Click
        On Error Resume Next

        If Me.CustomMacro.Checked = True Then
            Dim MyCustom4 As String = InputBox("Enter a ""G"" or ""M"" command and any parameters.  Your entry will be converted to Upper Case." & vbLf & vbLf &
                                               "An empty entry will clear the Command.  The CANCEL key will also clear an existing command.", "Set a Custom Command", My.Settings.Custom4)
            If MyCustom4 = "" Then
                My.Settings.Custom4 = ""
                Me.Custom4.Text = "Custom4"
                Me.RecoverTip.SetToolTip(Me.Custom4, "Empty")
            Else
                My.Settings.Custom4 = UCase(MyCustom4)
                Me.Custom4.Text = Strings.Left(My.Settings.Custom4, 4)
                Me.RecoverTip.SetToolTip(Me.Custom4, My.Settings.Custom4)
            End If
            Me.CustomMacro.Checked = False
            Exit Sub
        Else
            If Me.Vcomm.IsOpen = False Then
                MsgBox("The port is closed", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            If My.Settings.Custom4 <> "" Then
                StrToSend = My.Settings.Custom4
                SendTheString(StrToSend)
                StrToSend = ""
            End If
        End If
    End Sub

    Private Sub CustomScript_CheckedChanged(sender As Object, e As EventArgs) Handles CustomScript.CheckedChanged
        If Me.CustomScript.Checked = True Then
            Me.CustomScript.Text = "Click to Edit" & vbLf & "a Custom Script"
            Me.CustomScript.BackColor = Color.Yellow
            Me.Script1.BackColor = Color.Yellow
            Me.Script2.BackColor = Color.Yellow
            Me.Script3.BackColor = Color.Yellow
            Me.Script4.BackColor = Color.Yellow
        Else
            Me.CustomScript.Text = "Click to Edit" & vbLf & "a Custom Script"
            Me.CustomScript.BackColor = Color.Silver
            Me.Script1.BackColor = Color.Lime
            Me.Script2.BackColor = Color.Salmon
            Me.Script3.BackColor = Color.Lime
            Me.Script4.BackColor = Color.Salmon
        End If
    End Sub

    Private Sub Script1_Click(sender As Object, e As EventArgs) Handles Script1.Click
        On Error Resume Next
        'If Me.Vcomm.IsOpen = False Then
        'MsgBox("The port is closed", Ctype(vbOKOnly + vbInformation,msgboxstyle), "Greg's Toolbox")
        'Exit Sub
        'End If
        If Me.CustomScript.Checked = True Then
            ScriptResponse = "Cancel"
            CustomScriptDialog.TextBox1.Text = My.Settings.Script1
            CustomScriptDialog.ShowDialog()
            If ScriptResponse = "Cancel" Then
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Forget" Then
                My.Settings.Script1 = ""
                Me.Script1.Text = "Empty 1"
                Me.RecoverTip.SetToolTip(Me.Script1, "Empty")
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Save" Then
                My.Settings.Script1 = CustomScriptDialog.TextBox1.Text
                Me.Script1.Text = "Script #1"
                Me.RecoverTip.SetToolTip(Me.Script1, "A custom Script is attached")
                Me.CustomScript.Checked = False
            End If
            Exit Sub
        End If
        If My.Settings.Script1 = "" Then Exit Sub
        If Me.Vcomm.IsOpen = False Then
            Dim MyPort = MsgBox("The Port is Closed", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim CmdArray() As String
        ReDim Preserve CmdArray(1)
        Dim cntr = 0
        Dim MyLine = My.Settings.Script1
        Dim TheCmd As Integer = 1
        Do Until TheCmd = 0
            TheCmd = InStr(MyLine, vbCrLf)
            CmdArray(cntr) = Strings.Left(MyLine, TheCmd - 1)
            ReDim Preserve CmdArray(cntr + 1)
            If TheCmd = 0 And Len(MyLine) > 0 Then
                CmdArray(cntr) = MyLine
                MyLine = ""
            End If
            MyLine = Strings.Right(MyLine, Len(MyLine) - (TheCmd + 1))
            cntr += 1
        Loop
        ReDim Preserve CmdArray(cntr - 1)
        For Each cmdLine In CmdArray
            StrToSend = cmdLine ' & vbLf
            SendTheString(StrToSend)
            StrToSend = ""
            Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub Script2_Click(sender As Object, e As EventArgs) Handles Script2.Click
        On Error Resume Next
        'If Me.Vcomm.IsOpen = False Then
        'MsgBox("The port is closed", Ctype(vbOKOnly + vbInformation,msgboxstyle), "Greg's Toolbox")
        'Exit Sub
        'End If
        If Me.CustomScript.Checked = True Then
            ScriptResponse = "Cancel"
            CustomScriptDialog.TextBox1.Text = My.Settings.Script2
            CustomScriptDialog.ShowDialog()
            If ScriptResponse = "Cancel" Then
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Forget" Then
                My.Settings.Script2 = ""
                Me.Script2.Text = "Empty 2"
                Me.RecoverTip.SetToolTip(Me.Script2, "Empty")
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Save" Then
                My.Settings.Script2 = CustomScriptDialog.TextBox1.Text
                Me.Script2.Text = "Script #2"
                Me.RecoverTip.SetToolTip(Me.Script2, "A custom Script is attached")
                Me.CustomScript.Checked = False
            End If
            Exit Sub
        End If
        If My.Settings.Script2 = "" Then Exit Sub
        If Me.Vcomm.IsOpen = False Then
            Dim MyPort = MsgBox("The Port is Closed", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim CmdArray() As String
        ReDim Preserve CmdArray(1)
        Dim cntr = 0
        Dim MyLine = My.Settings.Script2
        Dim TheCmd As Integer = 1
        Do Until TheCmd = 0
            TheCmd = InStr(MyLine, vbCrLf)
            CmdArray(cntr) = Strings.Left(MyLine, TheCmd - 1)
            ReDim Preserve CmdArray(cntr + 1)
            If TheCmd = 0 And Len(MyLine) > 0 Then
                CmdArray(cntr) = MyLine
                MyLine = ""
            End If
            MyLine = Strings.Right(MyLine, Len(MyLine) - (TheCmd + 1))
            cntr += 1
        Loop
        ReDim Preserve CmdArray(cntr - 1)
        For Each cmdLine In CmdArray
            StrToSend = cmdLine & vbLf
            SendTheString(StrToSend)
            StrToSend = ""
            Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub Script3_Click(sender As Object, e As EventArgs) Handles Script3.Click
        On Error Resume Next
        'If Me.Vcomm.IsOpen = False Then
        'MsgBox("The port is closed", Ctype(vbOKOnly + vbInformation,msgboxstyle), "Greg's Toolbox")
        'Exit Sub
        'End If
        If Me.CustomScript.Checked = True Then
            ScriptResponse = "Cancel"
            CustomScriptDialog.TextBox1.Text = My.Settings.Script3
            CustomScriptDialog.ShowDialog()
            If ScriptResponse = "Cancel" Then
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Forget" Then
                My.Settings.Script3 = ""
                Me.Script3.Text = "Empty 3"
                Me.RecoverTip.SetToolTip(Me.Script3, "Empty")
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Save" Then
                My.Settings.Script3 = CustomScriptDialog.TextBox1.Text
                Me.Script3.Text = "Script #3"
                Me.RecoverTip.SetToolTip(Me.Script3, "A custom Script is attached")
                Me.CustomScript.Checked = False
            End If
            Exit Sub
        End If
        If My.Settings.Script3 = "" Then Exit Sub
        If Me.Vcomm.IsOpen = False Then
            Dim MyPort = MsgBox("The Port is Closed", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim CmdArray() As String
        ReDim Preserve CmdArray(1)
        Dim cntr = 0
        Dim MyLine = My.Settings.Script3
        Dim TheCmd As Integer = 1
        Do Until TheCmd = 0
            TheCmd = InStr(MyLine, vbCrLf)
            CmdArray(cntr) = Strings.Left(MyLine, TheCmd - 1)
            ReDim Preserve CmdArray(cntr + 1)
            If TheCmd = 0 And Len(MyLine) > 0 Then
                CmdArray(cntr) = MyLine
                MyLine = ""
            End If
            MyLine = Strings.Right(MyLine, Len(MyLine) - (TheCmd + 1))
            cntr += 1
        Loop
        ReDim Preserve CmdArray(cntr - 1)
        For Each cmdLine In CmdArray
            StrToSend = cmdLine & vbLf
            SendTheString(StrToSend)
            StrToSend = ""
            Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub Script4_Click(sender As Object, e As EventArgs) Handles Script4.Click
        On Error Resume Next
        'If Me.Vcomm.IsOpen = False Then
        'MsgBox("The port is closed", Ctype(vbOKOnly + vbInformation,msgboxstyle), "Greg's Toolbox")
        'Exit Sub
        'End If
        If Me.CustomScript.Checked = True Then
            ScriptResponse = "Cancel"
            CustomScriptDialog.TextBox1.Text = My.Settings.Script4
            CustomScriptDialog.ShowDialog()
            If ScriptResponse = "Cancel" Then
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Forget" Then
                My.Settings.Script4 = ""
                Me.Script4.Text = "Empty 4"
                Me.RecoverTip.SetToolTip(Me.Script4, "Empty")
                Me.CustomScript.Checked = False
            ElseIf ScriptResponse = "Save" Then
                My.Settings.Script4 = CustomScriptDialog.TextBox1.Text
                Me.Script4.Text = "Script #4"
                Me.RecoverTip.SetToolTip(Me.Script4, "A custom Script is attached")
                Me.CustomScript.Checked = False
            End If
            Exit Sub
        End If
        If My.Settings.Script4 = "" Then Exit Sub
        If Me.Vcomm.IsOpen = False Then
            Dim MyPort = MsgBox("The Port is Closed", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim CmdArray() As String
        ReDim Preserve CmdArray(1)
        Dim cntr = 0
        Dim MyLine = My.Settings.Script4
        Dim TheCmd As Integer = 1
        Do Until TheCmd = 0
            TheCmd = InStr(MyLine, vbCrLf)
            CmdArray(cntr) = Strings.Left(MyLine, TheCmd - 1)
            ReDim Preserve CmdArray(cntr + 1)
            If TheCmd = 0 And Len(MyLine) > 0 Then
                CmdArray(cntr) = MyLine
                MyLine = ""
            End If
            MyLine = Strings.Right(MyLine, Len(MyLine) - (TheCmd + 1))
            cntr += 1
        Loop
        ReDim Preserve CmdArray(cntr - 1)
        For Each cmdLine In CmdArray
            StrToSend = cmdLine & vbLf
            SendTheString(StrToSend)
            StrToSend = ""
            Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub AutoOpenBut_CheckedChanged(sender As Object, e As EventArgs) Handles AutoOpenBut.CheckedChanged
        My.Settings.AutoPortOpen = Me.AutoOpenBut.Checked
    End Sub

    Private Sub DebugBut_Click(sender As Object, e As EventArgs) Handles DebugBut.Click
        On Error Resume Next
        With DebugForm
            .DebugFileNameBox.Text = Me.GCODE_FileNameBox.Text
            If Me.ByteLineBox.Text <> "" Then
                If .DebugLineBox.Text <> Me.ByteLineBox.Text Then
                    .LabelMinus4L.Text = "---"
                    .LabelMinus4.Text = "---"
                    .LabelMinus3L.Text = "---"
                    .LabelMinus3.Text = "---"
                    .LabelMinus2L.Text = "---"
                    .LabelMinus2.Text = "---"
                    .LabelMinus1L.Text = "---"
                    .LabelMinus1.Text = "---"
                    .DebugCurrentLineBox.Text = "---"
                    .LabelCurrent.Text = "---"
                    .LabelPlus1.Text = "---"
                    .LabelPlus1L.Text = "---"
                    .LabelPlus2.Text = "---"
                    .LabelPlus2L.Text = "---"
                    .LabelPlus3.Text = "---"
                    .LabelPlus3L.Text = "---"
                    .LabelPlus4.Text = "---"
                    .LabelPlus4L.Text = "---"
                End If
                .DebugLineBox.Text = Me.ByteLineBox.Text
            Else
                .DebugLineBox.Text = "1"
            End If
            If .KillExtrudeChk.Checked = False Then
                .WarningLabel.Visible = True
            End If
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub InitializeBut_CheckedChanged(sender As Object, e As EventArgs) Handles InitializeBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.InitializeBut.Checked Then
            Me.InitializeBut.Text = "Wait for M503"
            Me.Refresh()
            StrToSend = "M503"
            SendTheString(StrToSend)
            'StrToSend = ""
            Threading.Thread.Sleep(1000)
            Me.InitializeBut.Text = "Now Click"
            Me.InitializeBut.BackColor = Color.Yellow
        Else
            Me.InitializeBut.Text = "Initialize the Toobox (Home Offsets)"
            Me.InitializeBut.BackColor = Color.Silver
            Call ParseTheStringOffset()
            My.Settings.HomeOffsetX = PrinterSettings.OffsetXbox.Text
            My.Settings.HomeOffsetY = PrinterSettings.OffsetYbox.Text
            My.Settings.HomeOffsetZ = PrinterSettings.OffsetZbox.Text
            MsgBox("Make all the necessary changes in the next dialog to configure the app for your printer.  You MUST do this the first time because the Home Offsets effect the Jog commands.  You must Initialize anytime you change your Home Offsets.", vbOKOnly, "Greg's Toolbox")
            GCODE_Settings.Show()
        End If
    End Sub

    Private Sub SetLRBut_CheckedChanged(sender As Object, e As EventArgs) Handles SetLRBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.SetLRBut.BackColor <> Color.Yellow Then
            Dim AResponse = MsgBox("This will set the Left Rear leveling location to the current location.  Release the button when it turns yellow." & vbLf & vbLf &
              "Continue?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then
                RemoveHandler SetLRBut.CheckedChanged, AddressOf SetLRBut_CheckedChanged
                Me.SetLRBut.Checked = False
                AddHandler SetLRBut.CheckedChanged, AddressOf SetLRBut_CheckedChanged
                Exit Sub
            End If
        End If
        If Me.SetLRBut.Checked Then
            Me.TextBox1.Text = ""
            StrToSend = ""
            SendTheString("M114")
            StrToSend = ""
            Threading.Thread.Sleep(1500)
            Me.SetLRBut.BackColor = Color.Yellow
        Else
            Me.SetLRBut.BackColor = Color.Silver
            Dim LocLine = Me.TextBox1.Text
            Dim Xstart = InStr(LocLine, "X:")
            Dim Xstr = Strings.Right(LocLine, Len(LocLine) - Xstart - 1)
            Dim firstSpace = InStr(Xstr, " ")
            Dim Xloc = Strings.Left(Xstr, firstSpace - 1)
            My.Settings.Lev_LRx = CStr(Val(Xloc))
            Dim Ystr = Strings.Right(Xstr, Len(Xstr) - firstSpace - 2)
            firstSpace = InStr(Ystr, " ")
            Dim Yloc = Strings.Left(Ystr, firstSpace - 1)
            My.Settings.Lev_LRy = CStr(Val(Yloc))
            Dim Zstr = Strings.Right(Ystr, Len(Ystr) - firstSpace - 2)
            firstSpace = InStr(Zstr, " ")
            Dim Zloc = Strings.Left(Zstr, firstSpace - 1)
            My.Settings.Lev_LRz = CStr(Val(Zloc))
            Me.CBStep4.Text = "Left Rear" & vbLf & Val(Xloc) & ", " & Val(Yloc) & ", " & Val(Zloc)
        End If
    End Sub

    Private Sub SetLFBut_CheckedChanged(sender As Object, e As EventArgs) Handles SetLFBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.SetLFBut.BackColor <> Color.Yellow Then
            Dim AResponse = MsgBox("This will set the Left Front leveling location to the current location.  Release the button when it turns yellow." & vbLf & vbLf &
              "Continue?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then
                RemoveHandler SetLFBut.CheckedChanged, AddressOf SetLFBut_CheckedChanged
                Me.SetLFBut.Checked = False
                AddHandler SetLFBut.CheckedChanged, AddressOf SetLFBut_CheckedChanged
                Exit Sub
            End If
        End If
        If Me.SetLFBut.Checked Then
            Me.TextBox1.Text = ""
            StrToSend = ""
            SendTheString("M114")
            StrToSend = ""
            Threading.Thread.Sleep(1500)
            Me.SetLFBut.BackColor = Color.Yellow
        Else
            Me.SetLFBut.BackColor = Color.Silver
            Dim LocLine = Me.TextBox1.Text
            Dim Xstart = InStr(LocLine, "X:")
            Dim Xstr = Strings.Right(LocLine, Len(LocLine) - Xstart - 1)
            Dim firstSpace = InStr(Xstr, " ")
            Dim Xloc = Strings.Left(Xstr, firstSpace - 1)
            My.Settings.Lev_LFx = Xloc
            Dim Ystr = Strings.Right(Xstr, Len(Xstr) - firstSpace - 2)
            firstSpace = InStr(Ystr, " ")
            Dim Yloc = Strings.Left(Ystr, firstSpace - 1)
            My.Settings.Lev_LFy = Yloc
            Dim Zstr = Strings.Right(Ystr, Len(Ystr) - firstSpace - 2)
            firstSpace = InStr(Zstr, " ")
            Dim Zloc = Strings.Left(Zstr, firstSpace - 1)
            My.Settings.Lev_LFz = Zloc
            Me.CBStep1.Text = "Left Front" & vbLf & Val(Xloc) & ", " & Val(Yloc) & ", " & Val(Zloc)
        End If
    End Sub

    Private Sub SetMidBut_CheckedChanged(sender As Object, e As EventArgs) Handles SetMidBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.SetMidBut.BackColor <> Color.Yellow Then
            Dim AResponse = MsgBox("This will set the Middle leveling location to the current location.  Release the button when it turns yellow." & vbLf & vbLf &
              "Continue?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then
                RemoveHandler SetMidBut.CheckedChanged, AddressOf SetMidBut_CheckedChanged
                Me.SetMidBut.Checked = False
                AddHandler SetMidBut.CheckedChanged, AddressOf SetMidBut_CheckedChanged
                Exit Sub
            End If
        End If
        If Me.SetMidBut.Checked Then
            Me.TextBox1.Text = ""
            StrToSend = ""
            SendTheString("M114")
            StrToSend = ""
            Threading.Thread.Sleep(1500)
            Me.SetMidBut.BackColor = Color.Yellow
        Else
            Me.SetMidBut.BackColor = Color.Silver
            Dim LocLine = Me.TextBox1.Text
            Dim Xstart = InStr(LocLine, "X:")
            Dim Xstr = Strings.Right(LocLine, Len(LocLine) - Xstart - 1)
            Dim firstSpace = InStr(Xstr, " ")
            Dim Xloc = Strings.Left(Xstr, firstSpace - 1)
            My.Settings.Lev_MIDx = Xloc
            Dim Ystr = Strings.Right(Xstr, Len(Xstr) - firstSpace - 2)
            firstSpace = InStr(Ystr, " ")
            Dim Yloc = Strings.Left(Ystr, firstSpace - 1)
            My.Settings.Lev_MIDy = Yloc
            Dim Zstr = Strings.Right(Ystr, Len(Ystr) - firstSpace - 2)
            firstSpace = InStr(Zstr, " ")
            Dim Zloc = Strings.Left(Zstr, firstSpace - 1)
            My.Settings.Lev_MIDz = Zloc
            Me.CBStepMid.Text = "Middle" & vbLf & Val(Xloc) & ", " & Val(Yloc) & ", " & Val(Zloc)
        End If
    End Sub

    Private Sub SetRRBut_CheckedChanged(sender As Object, e As EventArgs) Handles SetRRBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.SetRRBut.BackColor <> Color.Yellow Then
            Dim AResponse = MsgBox("This will set the Right Rear leveling location to the current location.  Release the button when it turns yellow." & vbLf & vbLf &
              "Continue?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then
                RemoveHandler SetRRBut.CheckedChanged, AddressOf SetRRBut_CheckedChanged
                Me.SetRRBut.Checked = False
                AddHandler SetRRBut.CheckedChanged, AddressOf SetRRBut_CheckedChanged
                Exit Sub
            End If
        End If
        If Me.SetRRBut.Checked Then
            Me.TextBox1.Text = ""
            StrToSend = ""
            SendTheString("M114")
            StrToSend = ""
            Threading.Thread.Sleep(1500)
            Me.SetRRBut.BackColor = Color.Yellow
        Else
            Me.SetRRBut.BackColor = Color.Silver
            Dim LocLine = Me.TextBox1.Text
            Dim Xstart = InStr(LocLine, "X:")
            Dim Xstr = Strings.Right(LocLine, Len(LocLine) - Xstart - 1)
            Dim firstSpace = InStr(Xstr, " ")
            Dim Xloc = Strings.Left(Xstr, firstSpace - 1)
            My.Settings.Lev_RRx = Xloc
            Dim Ystr = Strings.Right(Xstr, Len(Xstr) - firstSpace - 2)
            firstSpace = InStr(Ystr, " ")
            Dim Yloc = Strings.Left(Ystr, firstSpace - 1)
            My.Settings.Lev_RRy = Yloc
            Dim Zstr = Strings.Right(Ystr, Len(Ystr) - firstSpace - 2)
            firstSpace = InStr(Zstr, " ")
            Dim Zloc = Strings.Left(Zstr, firstSpace - 1)
            My.Settings.Lev_RRz = Zloc
            Me.CBStep3.Text = "Right Rear" & vbLf & Val(Xloc) & ", " & Val(Yloc) & ", " & Val(Zloc)
        End If
    End Sub

    Private Sub SetRFBut_CheckedChanged(sender As Object, e As EventArgs) Handles SetRFBut.CheckedChanged
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port must be open.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        If Me.SetRFBut.BackColor <> Color.Yellow Then
            Dim AResponse = MsgBox("This will set the Right Front leveling location to the current location.  Release the button when it turns yellow." & vbLf & vbLf &
              "Continue?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then
                RemoveHandler SetRFBut.CheckedChanged, AddressOf SetRFBut_CheckedChanged
                Me.SetRFBut.Checked = False
                AddHandler SetRFBut.CheckedChanged, AddressOf SetRFBut_CheckedChanged
                Exit Sub
            End If
        End If
        If Me.SetRFBut.Checked Then
            Me.TextBox1.Text = ""
            StrToSend = ""
            SendTheString("M114")
            StrToSend = ""
            Threading.Thread.Sleep(1500)
            Me.SetRFBut.BackColor = Color.Yellow
        Else
            Me.SetRFBut.BackColor = Color.Silver
            Dim LocLine = Me.TextBox1.Text
            Dim Xstart = Convert.ToInt32(InStr(LocLine, "X:"))
            Dim Xstr = Strings.Right(LocLine, Convert.ToInt32(Len(LocLine)) - Xstart - 1)
            Dim firstSpace = Convert.ToInt32(InStr(Xstr, " "))
            Dim Xloc = Strings.Left(Xstr, firstSpace - 1)
            My.Settings.Lev_RFx = Xloc
            Dim Ystr = Strings.Right(Xstr, Convert.ToInt32(Len(Xstr)) - firstSpace - 2)
            firstSpace = Convert.ToInt32(InStr(Ystr, " "))
            Dim Yloc = Strings.Left(Ystr, firstSpace - 1)
            My.Settings.Lev_RFy = Yloc
            Dim Zstr = Strings.Right(Ystr, Len(Ystr) - firstSpace - 2)
            firstSpace = Convert.ToInt32(InStr(Zstr, " "))
            Dim Zloc = Strings.Left(Zstr, firstSpace - 1)
            My.Settings.Lev_RFz = Zloc
            Me.CBStep2.Text = "Right Front" & vbLf & Val(Xloc) & ", " & Val(Yloc) & ", " & Val(Zloc)
        End If
    End Sub

    Private Sub CreateINIBut_Click(sender As Object, e As EventArgs) Handles CreateINIBut.Click
        On Error GoTo EHandler
        Dim FileResponse = ""
        Dim LineToWrite = ""
        Dim NewScript1 As String = ""
        Dim NewScript2 As String = ""
        Dim NewScript3 As String = ""
        Dim NewScript4 As String = ""
        With My.Settings
            If .Script1 <> "" Then
                NewScript1 = Replace(.Script1, vbCrLf, ",", 1,)
            End If
            If .Script2 <> "" Then
                NewScript2 = Replace(.Script2, vbCrLf, ",", 1,)
            End If
            If .Script3 <> "" Then
                NewScript3 = Replace(.Script3, vbCrLf, ",", 1,)
            End If
            If .Script4 <> "" Then
                NewScript4 = Replace(.Script4, vbCrLf, ",", 1,)
            End If
            LineToWrite = .AutoLevel & vbCrLf &
                .AutoPortOpen & vbCrLf &
                .Bed_Xmax & vbCrLf &
                .Bed_Ymax & vbCrLf &
                .Bed_ZMax & vbCrLf &
                .Cali_E_x & vbCrLf &
                .Cali_E_y & vbCrLf &
                .Cali_E_z & vbCrLf &
                .ChngNoz_x & vbCrLf &
                .ChngNoz_y & vbCrLf &
                .ChngNoz_z & vbCrLf &
                ";" & .Custom1 & vbCrLf &
                ";" & .Custom2 & vbCrLf &
                ";" & .Custom3 & vbCrLf &
                ";" & .Custom4 & vbCrLf &
                .DefaultPort & vbCrLf &
                .DefaultXAccel & vbCrLf &
                .DefaultXJerk & vbCrLf &
                .DefaultYAccel & vbCrLf &
                .DefaultYJerk & vbCrLf &
                .ExtrudeAmt & vbCrLf &
                .Heated_Bed & vbCrLf &
                .HomeOffsetX & vbCrLf &
                .HomeOffsetY & vbCrLf &
                .HomeOffsetZ & vbCrLf &
                .Lev_LFx & vbCrLf &
                .Lev_LFy & vbCrLf &
                .Lev_LFz & vbCrLf &
                .Lev_LRx & vbCrLf &
                .Lev_LRy & vbCrLf &
                .Lev_LRz & vbCrLf &
                .Lev_MIDx & vbCrLf &
                .Lev_MIDy & vbCrLf &
                .Lev_MIDz & vbCrLf &
                .Lev_RFx & vbCrLf &
                .Lev_RFy & vbCrLf &
                .Lev_RFz & vbCrLf &
                .Lev_RRx & vbCrLf &
                .Lev_RRy & vbCrLf &
                .Lev_RRz & vbCrLf &
                .Matl1_Bed & vbCrLf &
                .Matl1_Fan & vbCrLf &
                .Matl1_Hot & vbCrLf &
                .Matl1_Name & vbCrLf &
                .Matl2_Bed & vbCrLf &
                .Matl2_Fan & vbCrLf &
                .Matl2_Hot & vbCrLf &
                .Matl2_Name & vbCrLf &
                .Matl3_Bed & vbCrLf &
                .Matl3_Fan & vbCrLf &
                .Matl3_Hot & vbCrLf &
                .Matl3_Name & vbCrLf &
                .Matl4_Bed & vbCrLf &
                .Matl4_Fan & vbCrLf &
                .Matl4_Hot & vbCrLf &
                .Matl4_Name & vbCrLf &
                .MaxPorts & vbCrLf &
                .NumOfExtruders & vbCrLf &
                .PortBaud & vbCrLf &
                .PortBytes & vbCrLf &
                .PortParity & vbCrLf &
                .PortStopBits & vbCrLf &
                .PrePr_x & vbCrLf &
                .PrePr_y & vbCrLf &
                .PrePr_z & vbCrLf &
                .PrimeAmt & vbCrLf &
                .Retraction & vbCrLf &
                ";" & NewScript1 & vbCrLf &
                ";" & NewScript2 & vbCrLf &
                ";" & NewScript3 & vbCrLf &
                ";" & NewScript4 & vbCrLf &
                Me.FloBox.Text & vbCrLf &
                Me.FeedBox.Text & vbCrLf &
                Me.HeatBox.Text & vbCrLf &
                Me.BedBox.Text & vbCrLf &
                Me.FanBox.Text & vbCrLf &
                .DefaultPAccel & vbCrLf &
                .DefaultTAccel & vbCrLf &
                .JunctionDeviation & vbCrLf &
                .PreHeatSync & vbCrLf &
                .AutoLevelCMD & vbCrLf &
                .FilamentDia & vbCrLf &
                .WhatColor & vbCrLf &
                .Heated_Build_Volume

        End With
        Me.SaveFileDialog1.Title = "Save Profile File"
        Me.SaveFileDialog1.Filter = "PRO Files (*.pro*)|*.pro"
        Me.SaveFileDialog1.FilterIndex = 1
        Me.SaveFileDialog1.DefaultExt = "pro"
        Me.SaveFileDialog1.FileName = "MyPrinter1.pro"
        Me.SaveFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK _
     Then
            My.Computer.FileSystem.WriteAllText _
            (Me.SaveFileDialog1.FileName, LineToWrite, False)
        End If
        Exit Sub
EHandler:
        MsgBox("There was an error in ""Mainform.CreateINIBut_Click""" & vbLf & Err.Description, vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub ImportINIBut_Click(sender As Object, e As EventArgs) Handles ImportINIBut.Click
        On Error GoTo TheHandler
        Dim FileResponse As DialogResult
        Dim INI_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a PROFILE file"
        Me.OpenFileDialog1.Filter = "PRO Files|*.pro|Text Files|*.txt|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "pro"
        Me.OpenFileDialog1.FileName = "*.pro"
        Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        ImportFileName = Me.OpenFileDialog1.FileName
        INI_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim Index = 0
        Dim CmdArray(83) As String
        Do While INI_File.EndOfStream <> True
            CurLine = INI_File.ReadLine
            CmdArray(Index) = CurLine
            Index += 1
        Loop
        INI_File.Close()

        With My.Settings
            .AutoLevel = CBool(System.Text.RegularExpressions.Regex.Replace(CmdArray(0), "[^\u0000-\u007F]", ""))
            GCODE_Settings.Auto_Level.Checked = .AutoLevel
            .AutoPortOpen = CBool(CmdArray(1))
            Me.AutoOpenBut.Checked = .AutoPortOpen
            .Bed_Xmax = CmdArray(2)
            .Bed_Ymax = CmdArray(3)
            .Bed_ZMax = CmdArray(4)
            .Cali_E_x = CmdArray(5)
            .Cali_E_y = CmdArray(6)
            .Cali_E_z = CmdArray(7)
            .ChngNoz_x = CmdArray(8)
            .ChngNoz_y = CmdArray(9)
            .ChngNoz_z = CmdArray(10)
            CurLine = CmdArray(11)
            If CurLine = ";" Then
                .Custom1 = ""
                Me.Custom1.Text = "Custom 1"
            Else
                .Custom1 = Strings.Right(CurLine, Len(CurLine) - 1)
                Me.Custom1.Text = Strings.Left(My.Settings.Custom1, 4)
            End If
            CurLine = CmdArray(12)
            If CurLine = ";" Then
                .Custom2 = ""
                Me.Custom2.Text = "Custom 2"
            Else
                .Custom2 = Strings.Right(CurLine, Len(CurLine) - 1)
                Me.Custom2.Text = Strings.Left(My.Settings.Custom2, 4)
            End If
            CurLine = CmdArray(13)
            If CurLine = ";" Then
                .Custom3 = ""
                Me.Custom3.Text = "Custom 3"
            Else
                .Custom3 = Strings.Right(CurLine, Len(CurLine) - 1)
                Me.Custom3.Text = Strings.Left(My.Settings.Custom3, 4)
            End If
            CurLine = CmdArray(14)
            If CurLine = ";" Then
                .Custom4 = ""
                Me.Custom4.Text = "Custom 4"
            Else
                .Custom4 = Strings.Right(CurLine, Len(CurLine) - 1)
                Me.Custom4.Text = Strings.Left(My.Settings.Custom4, 4)
            End If
            .DefaultPort = CmdArray(15)
            .DefaultXAccel = CmdArray(16)
            .DefaultXJerk = CmdArray(17)
            .DefaultYAccel = CmdArray(18)
            .DefaultYJerk = CmdArray(19)
            .ExtrudeAmt = CmdArray(20)
            .Heated_Bed = CBool(CmdArray(21))
            .HomeOffsetX = CmdArray(22)
            .HomeOffsetY = CmdArray(23)
            .HomeOffsetZ = CmdArray(24)
            .Lev_LFx = CmdArray(25)
            .Lev_LFy = CmdArray(26)
            .Lev_LFz = CmdArray(27)
            .Lev_LRx = CmdArray(28)
            .Lev_LRy = CmdArray(29)
            .Lev_LRz = CmdArray(30)
            .Lev_MIDx = CmdArray(31)
            .Lev_MIDy = CmdArray(32)
            .Lev_MIDz = CmdArray(33)
            .Lev_RFx = CmdArray(34)
            .Lev_RFy = CmdArray(35)
            .Lev_RFz = CmdArray(36)
            .Lev_RRx = CmdArray(37)
            .Lev_RRy = CmdArray(38)
            .Lev_RRz = CmdArray(39)
            .Matl1_Bed = CmdArray(40)
            .Matl1_Fan = CmdArray(41)
            .Matl1_Hot = CmdArray(42)
            .Matl1_Name = CmdArray(43)
            .Matl2_Bed = CmdArray(44)
            .Matl2_Fan = CmdArray(45)
            .Matl2_Hot = CmdArray(46)
            .Matl2_Name = CmdArray(47)
            .Matl3_Bed = CmdArray(48)
            .Matl3_Fan = CmdArray(49)
            .Matl3_Hot = CmdArray(50)
            .Matl3_Name = CmdArray(51)
            .Matl4_Bed = CmdArray(52)
            .Matl4_Fan = CmdArray(53)
            .Matl4_Hot = CmdArray(54)
            .Matl4_Name = CmdArray(55)
            .MaxPorts = CmdArray(56)
            .NumOfExtruders = CmdArray(57)
            GCODE_Settings.NumOfExtruders.Text = CmdArray(57)
            .PortBaud = CmdArray(58)
            .PortBytes = CmdArray(59)
            .PortParity = CmdArray(60)
            .PortStopBits = CmdArray(61)
            .PrePr_x = CmdArray(62)
            .PrePr_y = CmdArray(63)
            .PrePr_z = CmdArray(64)
            .PrimeAmt = CmdArray(65)
            .Retraction = CmdArray(66)
            CurLine = CmdArray(67)
            If CurLine = ";" Then
                .Script1 = ""
                Me.Script1.Text = "Empty 1"
            Else
                NewScript1 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript1 = Replace(NewScript1, ",", vbCrLf, 1,)
                .Script1 = NewScript1
                Me.Script1.Text = "Script #1"
            End If
            CurLine = CmdArray(68)
            If CurLine = ";" Then
                .Script2 = ""
                Me.Script2.Text = "Empty 2"
            Else
                NewScript2 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript2 = Replace(NewScript2, ",", vbCrLf, 1,)
                .Script2 = NewScript2
                Me.Script2.Text = "Script #2"
            End If
            CurLine = CmdArray(69)
            If CurLine = ";" Then
                .Script3 = ""
                Me.Script3.Text = "Empty 3"
            Else
                NewScript3 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript3 = Replace(NewScript3, ",", vbCrLf, 1,)
                .Script3 = Strings.Right(CurLine, Len(CurLine) - 1)
                Me.Script3.Text = "Script #3"
            End If
            CurLine = CmdArray(70)
            If CurLine = ";" Then
                .Script4 = ""
                Me.Script4.Text = "Empty 4"
            Else
                NewScript4 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript4 = Replace(NewScript4, ",", vbCrLf, 1,)
                .Script4 = NewScript4
                Me.Script4.Text = "Script #4"
            End If
            Me.FloBox.Text = CmdArray(71)
            Me.FeedBox.Text = CmdArray(72)
            Me.HeatBox.Text = CmdArray(73)
            Me.BedBox.Text = CmdArray(74)
            Me.FanBox.Text = CmdArray(75)
            .DefaultPAccel = CmdArray(76)
            .DefaultTAccel = CmdArray(77)
            .JunctionDeviation = CmdArray(78)
            Me.PreHeatSyncBox.Checked = CBool(CmdArray(79))
            GCODE_Settings.AutoLevelCmdBox.Text = CmdArray(80)
            GCODE_Settings.FilDiaBox.Text = CmdArray(81)
            If CmdArray(82) = "Dark" Then
                Me.ColorButtonD.Checked = True
                Me.ColorButtonS.Checked = False
            Else
                Me.ColorButtonS.Checked = True
                Me.ColorButtonD.Checked = False
            End If
            .Heated_Build_Volume = CBool(CmdArray(83))
            GCODE_Settings.HeatedBuildVolume.Checked = .Heated_Build_Volume
        End With
        INI_File.Close()

        Exit Sub
TheHandler:
        MsgBox("There was an Error in ""Mainform.ImportINIBut_Click""" & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub SetDefaultPortBut_Click(sender As Object, e As EventArgs) Handles SetDefaultPortBut.Click
        On Error GoTo Handler
        If Strings.Right(CStr(Me.AvailablePortsBox.SelectedItem), 3) = "COM" Then
            My.Settings.DefaultPort = Strings.Right(CStr(Me.AvailablePortsBox.SelectedItem), Len(CStr(Me.AvailablePortsBox.SelectedItem)) - 3)
        Else
            My.Settings.DefaultPort = "COM1"
        End If
        Exit Sub
Handler:
        MsgBox("There was an error in ""Mainform.SetDefaultPortBut_Click"".  The port must match an existing port.", vbOKOnly, "Greg's Toolbox")
        Me.AvailablePortsBox.SelectedIndex = 0
    End Sub

    Private Sub ColorButtonS_CheckedChanged(sender As Object, e As EventArgs) Handles ColorButtonS.CheckedChanged
        If Me.ColorButtonS.Checked = True Then
            My.Settings.WhatColor = "Standard"
            Me.MenuStrip1.BackColor = SystemColors.Control
            Me.ComPanel.BackColor = SystemColors.Control
            Me.BackColor = SystemColors.Control
            Me.TextBox1.BackColor = SystemColors.Window
            PrinterSettings.BackColor = SystemColors.Control
            GCODE_Settings.BackColor = SystemColors.Control
        Else
            My.Settings.WhatColor = "Dark"
            Me.MenuStrip1.BackColor = Color.DimGray
            Me.BackColor = Color.DimGray
            Me.ComPanel.BackColor = Color.DimGray
            Me.TextBox1.BackColor = SystemColors.AppWorkspace
            PrinterSettings.BackColor = Color.DimGray
            GCODE_Settings.BackColor = Color.DimGray
        End If
    End Sub

    Private Sub ColorButtonD_CheckedChanged(sender As Object, e As EventArgs) Handles ColorButtonD.CheckedChanged
        If Me.ColorButtonD.Checked = True Then
            My.Settings.WhatColor = "Dark"
            Me.MenuStrip1.BackColor = Color.DimGray
            Me.ComPanel.BackColor = Color.DimGray
            Me.BackColor = Color.DimGray
            Me.TextBox1.BackColor = Color.Silver
            PrinterSettings.BackColor = Color.DimGray
            GCODE_Settings.BackColor = Color.DimGray
            Call ChangeForeColors()
        Else
            My.Settings.WhatColor = "Standard"
            Me.MenuStrip1.BackColor = SystemColors.Control
            Me.ComPanel.BackColor = SystemColors.Control
            Me.BackColor = SystemColors.Control
            Me.TextBox1.BackColor = SystemColors.Window
            PrinterSettings.BackColor = SystemColors.Control
            GCODE_Settings.BackColor = SystemColors.Control
            Call ChangeForeColors()
        End If
    End Sub

    Private Sub EnableMoveBut_Click(sender As Object, e As EventArgs) Handles EnableMoveBut.Click
        Me.DisableMovementBut.Checked = False
        Me.EnableMoveBut.BackColor = Color.LightGreen
        Me.EnableMoveBut.ForeColor = Color.Black
    End Sub

    Public Sub CuraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuraToolStripMenuItem.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim Setup_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a Cura GCODE file"
        Me.OpenFileDialog1.Filter = "Gcode Files|*.gcode|Gcode Files|*.gco|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = "*.gcode"
        'Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        ImportFileName = Me.OpenFileDialog1.FileName
        Setup_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim SetLine = ""
        Dim StartStr = ""
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            If Strings.Left(CurLine, 8) = ";SETTING" Then
                SetLine += CurLine
                StartStr = Strings.Left(CurLine, 11)
            End If
        Loop
        Setup_File.Close()
        SetLine = Strings.Replace(SetLine, StartStr, "", 1, -1)
        SetLine = Strings.Replace(SetLine, "\\n", vbCrLf, 1, -1)
        Cursor.Current = Cursors.Default
        Me.TextBox1.Text = SetLine
    End Sub

    Private Sub Simplify3DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Simplify3DToolStripMenuItem.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim Setup_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a Simplify3D GCODE file"
        Me.OpenFileDialog1.Filter = "Gcode Files|*.gcode|Gcode Files|*.gco|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = "*.gcode"
        'Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        ImportFileName = Me.OpenFileDialog1.FileName
        Setup_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim SetLine = ""
        'Dim StartStr = ""
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            If Strings.Left(CurLine, 4) = ";   " Then
                SetLine += CurLine
                'StartStr = Strings.Left(CurLine, 10)
            End If
        Loop
        Setup_File.Close()
        SetLine = Strings.Replace(SetLine, ";   ", vbCrLf, 1, -1)
        Cursor.Current = Cursors.Default
        Me.TextBox1.Text = SetLine
    End Sub

    Private Sub Slic3RToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Slic3RToolStripMenuItem.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim Setup_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a Simplify3D GCODE file"
        Me.OpenFileDialog1.Filter = "Gcode Files|*.gcode|Gcode Files|*.gco|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = "*.gcode"
        'Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        ImportFileName = Me.OpenFileDialog1.FileName
        Setup_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim SetLine = ""
        'Dim StartStr = ""
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            If Strings.Left(CurLine, 2) = "; " Then
                SetLine += CurLine
                'StartStr = Strings.Left(CurLine, 10)
            End If
        Loop
        Setup_File.Close()
        SetLine = Strings.Replace(SetLine, "; ", vbCrLf, 1, -1)
        Cursor.Current = Cursors.Default
        Me.TextBox1.Text = SetLine
    End Sub

    Private Sub MatterControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatterControlToolStripMenuItem.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim Setup_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a Simplify3D GCODE file"
        Me.OpenFileDialog1.Filter = "Gcode Files|*.gcode|Gcode Files|*.gco|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = "*.gcode"
        'Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        ImportFileName = Me.OpenFileDialog1.FileName
        Setup_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim SetLine = ""
        'Dim StartStr = ""
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            If InStr(CurLine, "GCode settings used") > 0 Then
                Do While Setup_File.EndOfStream <> True
                    CurLine = Setup_File.ReadLine
                    SetLine += CurLine
                Loop
            End If
        Loop
        Setup_File.Close()
        SetLine = Strings.Replace(SetLine, "; ", vbCrLf, 1, -1)
        Cursor.Current = Cursors.Default
        Me.TextBox1.Text = SetLine
    End Sub

    Private Sub KISSSlicerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KISSSlicerToolStripMenuItem.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim Setup_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a Simplify3D GCODE file"
        Me.OpenFileDialog1.Filter = "Gcode Files|*.gcode|Gcode Files|*.gco|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = "*.gcode"
        'Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        ImportFileName = Me.OpenFileDialog1.FileName
        Setup_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim SetLine = ""
        'Dim StartStr = ""
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            If InStr(CurLine, "*** Material Settings for Extruder 1 ***") > 0 Then
                Do While Setup_File.EndOfStream <> True
                    CurLine = Setup_File.ReadLine
                    If InStr(CurLine, "*** G-code Prefix ***") = 0 Then
                        SetLine += CurLine
                    Else
                        GoTo KickOut
                    End If
                Loop
            End If
        Loop
KickOut:
        SetLine = Strings.Replace(SetLine, "; ", vbCrLf, 1, -1)
        Me.TextBox1.Text = SetLine
    End Sub

    Private Sub PreHeatSyncBox_CheckedChanged(sender As Object, e As EventArgs) Handles PreHeatSyncBox.CheckedChanged
        If Me.PreHeatSyncBox.Checked Then
            PreHeatSync = True
            My.Settings.PreHeatSync = True
        Else
            PreHeatSync = False
            My.Settings.PreHeatSync = False
        End If
    End Sub

    Private Sub PrusaSlicerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrusaSlicerToolStripMenuItem.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim Setup_File As System.IO.StreamReader
        Dim ImportFileName As String
        Dim NewScript1 = ""
        Dim NewScript2 = ""
        Dim NewScript3 = ""
        Dim NewScript4 = ""
        Me.OpenFileDialog1.Title = "Load a Cura GCODE file"
        Me.OpenFileDialog1.Filter = "Gcode Files|*.gcode|Gcode Files|*.gco|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.DefaultExt = "gcode"
        Me.OpenFileDialog1.FileName = "*.gcode"
        'Me.OpenFileDialog1.InitialDirectory = EnderApp.My.Application.Info.DirectoryPath
        FileResponse = Me.OpenFileDialog1.ShowDialog()
        If FileResponse = 2 Then
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        ImportFileName = Me.OpenFileDialog1.FileName
        Setup_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim CurLine = ""
        Dim SetLine = ""
        Dim StartStr = ""
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            If Strings.Left(CurLine, 9) = "M84 X Y E" Then
                Exit Do
            End If
        Loop
        Do While Setup_File.EndOfStream <> True
            CurLine = Setup_File.ReadLine
            SetLine += CurLine
        Loop
        Setup_File.Close()
        SetLine = Strings.Replace(SetLine, "; ", vbCrLf, 1, -1)
        'SetLine = Strings.Replace(SetLine, "\n", vbCrLf, 1, -1)
        'SetLine = Strings.Replace(SetLine, StartStr, "", 1, -1)
        'SetLine = Strings.Replace(SetLine, "\", "", 1, -1)
        'SetLine = Strings.Replace(SetLine, " ", "", 1, -1)
        Cursor.Current = Cursors.Default
        Me.TextBox1.Text = SetLine
    End Sub

    Private Sub IgnoreResponseBut_CheckedChanged(sender As Object, e As EventArgs) Handles IgnoreResponseBut.CheckedChanged
        On Error Resume Next
        With Me.IgnoreResponseBut
            If .Checked Then
                .BackColor = Color.LightCoral
                .Text = "No Updates"
            Else
                .BackColor = Color.LightSeaGreen
                .Text = "Update on Receive"
            End If
        End With
    End Sub

    Private Sub SetLocBut_Click(sender As Object, e As EventArgs) Handles SetLocBut.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        Dim Xtext = ""
        Dim Ytext = ""
        Dim Ztext = ""
        If Me.PauseX.Text <> "" Then
            Xtext = " X" & Me.PauseX.Text
        End If
        If Me.PauseY.Text <> "" Then
            Ytext = " Y" & Me.PauseY.Text
        End If
        If Me.PauseZ.Text <> "" Then
            Ztext = " Z" & Me.PauseZ.Text
        End If
        AResponse = MsgBox("Blank X Y Z boxes are ignored." & vbLf & "The current NOZZLE LOCATION will be re-defined to:" & vbCr & vbCr &
                            Xtext & vbLf & Ytext & vbLf & Ztext & vbLf & vbLf & "Continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        StrToSend = "G92" & Xtext & Ytext & Ztext
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub IgnoreBusyBut_CheckedChanged(sender As Object, e As EventArgs) Handles IgnoreBusyBut.CheckedChanged
        On Error Resume Next
        With Me.IgnoreBusyBut
            If .Checked Then
                .BackColor = Color.LightCoral
                .Text = "No Busy Signals"
            Else
                .BackColor = Color.Gold
                .Text = "Post Busy Signal"
            End If
        End With
    End Sub

    Private Sub PrinterNameBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrinterNameBox.SelectedIndexChanged
        Dim ex As System.Exception
        Try
            RemoveHandler AvailablePortsBox.SelectedIndexChanged, AddressOf AvailablePortsBox_SelectedIndexChanged
            Dim PortToOpen As String = ""
            If Me.Vcomm.IsOpen Then
                Call ClosePort()
                Threading.Thread.Sleep(500)
            End If
            For M = 0 To Me.PrinterNameBox.Items.Count
                If CStr(PrinterNameBox.SelectedItem) = PrinterNameArray(M, 0) Then
                    Me.AvailablePortsBox.SelectedItem = "COM" & PrinterNameArray(M, 1)
                    PortToOpen = "COM" & PrinterNameArray(M, 1)
                    Me.Text = "Greg's Toolbox ~ " & CStr(PrinterNameBox.SelectedItem)
                    GoTo KickOut
                End If
            Next M
KickOut:
            Call AutoOpenAPort(PortToOpen)
            Call FormsModule.LoadProfileOnPort()
            Call Load_Settings_Dialog()
            AddHandler AvailablePortsBox.SelectedIndexChanged, AddressOf AvailablePortsBox_SelectedIndexChanged
        Catch ex
            MsgBox("There was an error" & vbCrLf & ex.Message, vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Public Sub AvailablePortsBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AvailablePortsBox.SelectedIndexChanged
        Dim ex As System.Exception
        Try
            If Me.AvailablePortsBox.Items.Count = 0 Then GoTo KickOut2
            RemoveHandler PrinterNameBox.SelectedIndexChanged, AddressOf PrinterNameBox_SelectedIndexChanged
            Dim PortToOpen As String = ""
            If Me.Vcomm.IsOpen Then
                Call ClosePort()
            End If
            If Me.PrinterNameBox.Items.Count > 0 Then
                For M = 0 To Me.AvailablePortsBox.Items.Count - 1
                    For T = 0 To 9 Step 1
                        If CStr(Me.AvailablePortsBox.SelectedItem) = "COM" & PrinterNameArray(T, 1) Then
                            Me.PrinterNameBox.SelectedItem = PrinterNameArray(T, 0)
                            PortToOpen = "COM" & PrinterNameArray(T, 1)
                            Me.Text = "Greg's Toolbox ~ " & CStr(PrinterNameBox.SelectedItem)
                            GoTo KickOut
                        End If
                    Next T
                Next M
            Else
                PortToOpen = CStr(Me.AvailablePortsBox.SelectedItem)
            End If
KickOut:
            Call AutoOpenAPort(PortToOpen)
            If Me.PrinterNameBox.Items.Count > 0 Then Call FormsModule.LoadProfileOnPort()
            Call Load_Settings_Dialog()
KickOut2:
            AddHandler PrinterNameBox.SelectedIndexChanged, AddressOf PrinterNameBox_SelectedIndexChanged
        Catch ex
            MsgBox("There was an error" & vbCrLf & ex.Message, vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Public Sub LinkPrinterAndProfile_Click(sender As Object, e As EventArgs) Handles LinkPrinterAndProfile.Click
        Try
            PrResponse = False
            PrintersToPortNames.ShowDialog()
            If PrResponse = False Then
                Exit Sub
            End If
            Me.PrinterNameBox.Items.Clear()
            Me.AvailablePortsBox.Items.Clear()
            Call FormsModule.FillPrinterArray()

            For PrData = 0 To 9 Step 1
                If PrinterNameArray(PrData, 0) <> "" Then
                    Me.PrinterNameBox.Items.Add(PrinterNameArray(PrData, 0))
                    Me.AvailablePortsBox.Items.Add("COM" & PrinterNameArray(PrData, 1))
                End If
            Next
            If Me.PrinterNameBox.Items.Count > 0 Then
                Me.PrinterNameBox.SelectedIndex = 0
            Else
                Me.PrinterNameBox.Items.Clear()
                Me.PrinterNameBox.ResetText()
                Me.AvailablePortsBox.ResetText()
                Me.ComOpenBut.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListsSettingsBut_Click(sender As Object, e As EventArgs) Handles ListsSettingsBut.Click
        On Error Resume Next
        Dim FileResponse = ""
        Dim LineToWrite = ""
        Dim NewScript1 As String = ""
        Dim NewScript2 As String = ""
        Dim NewScript3 As String = ""
        Dim NewScript4 As String = ""
        With My.Settings
            If .Script1 <> "" Then
                NewScript1 = Replace(.Script1, vbCrLf, ",", 1,)
            End If
            If .Script2 <> "" Then
                NewScript2 = Replace(.Script2, vbCrLf, ",", 1,)
            End If
            If .Script3 <> "" Then
                NewScript3 = Replace(.Script3, vbCrLf, ",", 1,)
            End If
            If .Script4 <> "" Then
                NewScript4 = Replace(.Script4, vbCrLf, ",", 1,)
            End If
            LineToWrite = "    Greg's Toolbox application settings:" & vbCrLf &
                "Auto Level: " & .AutoLevel & vbCrLf &
                "Auto Level Cmd: " & .AutoLevelCMD & vbCrLf &
                "Auto Open Port: " & .AutoPortOpen & vbCrLf &
                "Background Color: " & .WhatColor & vbCrLf &
                "Default Port: " & .DefaultPort & vbCrLf &
                "Bed Size Xmax: " & .Bed_Xmax & vbCrLf &
                "Bed Size Ymax: " & .Bed_Ymax & vbCrLf &
                "Bed Size Zmax: " & .Bed_ZMax & vbCrLf &
                "Number of Extruders: " & .NumOfExtruders & vbCrLf &
                "Calibrate E Xloc: " & .Cali_E_x & vbCrLf &
                "   Calibrate E Yloc: " & .Cali_E_y & vbCrLf &
                "   Calibrate E Zloc: " & .Cali_E_z & vbCrLf &
                "Change Nozzle Xloc: " & .ChngNoz_x & vbCrLf &
                "   Change Nozzle Yloc: " & .ChngNoz_y & vbCrLf &
                "   Change Nozzle Zloc: " & .ChngNoz_z & vbCrLf &
                "Custom Buttons" & vbCrLf &
                "   Custom Button 1: " & .Custom1 & vbCrLf &
                "   Custom Button 2: " & .Custom2 & vbCrLf &
                "   Custom Button 3: " & .Custom3 & vbCrLf &
                "   Custom Button 4: " & .Custom4 & vbCrLf &
                "Custom Scripts" & vbCrLf &
                "   Script 1: " & NewScript1 & vbCrLf &
                "   Script 2: " & NewScript2 & vbCrLf &
                "   Script 3: " & NewScript3 & vbCrLf &
                "   Script 4: " & NewScript4 & vbCrLf &
                "Default X Accel: " & .DefaultXAccel & vbCrLf &
                "Default X Jerk: " & .DefaultXJerk & vbCrLf &
                "Default Y Accel: " & .DefaultYAccel & vbCrLf &
                "Default Y Jerk: " & .DefaultYJerk & vbCrLf &
                "Print Accel: " & .DefaultPAccel & vbCrLf &
                "Travel Accel: " & .DefaultTAccel & vbCrLf &
                "Junction Deviation: " & .JunctionDeviation & vbCrLf &
                "Prime after Pause: " & .PrimeAmt & vbCrLf &
                "Extrude (Move) Distance: " & .ExtrudeAmt & vbCrLf &
                "Retract (Move) Distance: " & .Retraction & vbCrLf &
                "Sync Pre-Heat: " & .PreHeatSync & vbCrLf &
                "Heated Bed: " & .Heated_Bed & vbCrLf &
                "Heated Buld Volume: " & .Heated_Build_Volume & vbCrLf &
                "Home Offset X: " & .HomeOffsetX & vbCrLf &
                "   Home Offset Y: " & .HomeOffsetY & vbCrLf &
                "   Home Offset Z: " & .HomeOffsetZ & vbCrLf &
                "Level Left Frt X: " & .Lev_LFx & vbCrLf &
                "   Level Left Frt Y: " & .Lev_LFy & vbCrLf &
                "   Level Left Frt Z: " & .Lev_LFz & vbCrLf &
                "Level Left Rr X: " & .Lev_LRx & vbCrLf &
                "   Level Left Rr Y: " & .Lev_LRy & vbCrLf &
                "   Level Left Rr Z: " & .Lev_LRz & vbCrLf &
                "Level Middle X: " & .Lev_MIDx & vbCrLf &
                "   Level Middle Y: " & .Lev_MIDy & vbCrLf &
                "   Level Middle Z: " & .Lev_MIDz & vbCrLf &
                "Level Right Frt X: " & .Lev_RFx & vbCrLf &
                "   Level Right Frt Y: " & .Lev_RFy & vbCrLf &
                "   Level Right Frt Z: " & .Lev_RFz & vbCrLf &
                "Level Right Rr X: " & .Lev_RRx & vbCrLf &
                "   Level Right Rr Y: " & .Lev_RRy & vbCrLf &
                "   Level Right Rr Z: " & .Lev_RRz & vbCrLf &
                "Present Print X: " & .PrePr_x & vbCrLf &
                "   Present Print Y: " & .PrePr_y & vbCrLf &
                "   Present Print Z: " & .PrePr_z & vbCrLf &
                "Matl 1 Name: " & .Matl1_Name & vbCrLf &
                "   Matl 1 Bed Temp: " & .Matl1_Bed & vbCrLf &
                "   Matl 1 Fan Speed %: " & .Matl1_Fan & vbCrLf &
                "   Matl 1 Hot End Temp: " & .Matl1_Hot & vbCrLf &
                "Matl 2 Name: " & .Matl2_Name & vbCrLf &
                "   Matl 2 Bed Temp: " & .Matl2_Bed & vbCrLf &
                "   Matl 2 Fan Speed %: " & .Matl2_Fan & vbCrLf &
                "   Matl 2 Hot End Temp: " & .Matl2_Hot & vbCrLf &
                "Matl 3 Name: " & .Matl3_Name & vbCrLf &
                "   Matl 3 Bed Temp: " & .Matl3_Bed & vbCrLf &
                "   Matl 3 Fan Speed %: " & .Matl3_Fan & vbCrLf &
                "   Matl 3 Hot End Temp: " & .Matl3_Hot & vbCrLf &
                "Matl 4 Name: " & .Matl4_Name & vbCrLf &
                "   Matl 4 Bed Temp: " & .Matl4_Bed & vbCrLf &
                "   Matl 4 Fan Speed %: " & .Matl4_Fan & vbCrLf &
                "   Matl 4 Hot End Temp: " & .Matl4_Hot & vbCrLf &
                "Max Ports: " & .MaxPorts & vbCrLf &
                "Port Settings" & vbCrLf &
                "   Baud Rate: " & .PortBaud & vbCrLf &
                "   Bytes: " & .PortBytes & vbCrLf &
                "   Parity: " & .PortParity & vbCrLf &
                "   Stop Bits: " & .PortStopBits & vbCrLf &
                "Flow Rate %: " & Me.FloBox.Text & vbCrLf &
                "Feed Rate %: " & Me.FeedBox.Text & vbCrLf &
                "Hot End Temp: " & Me.HeatBox.Text & vbCrLf &
                "Bed Temp: " & Me.BedBox.Text & vbCrLf &
                "Fan Speed %: " & Me.FanBox.Text & vbCrLf &
                "Filament Diameter: " & .FilamentDia & vbCrLf
        End With
        Me.TextBox1.Text = LineToWrite

    End Sub

    Public Sub FilamentDiameterChange(ConvFactor As Single, RetractDist As Single, PostStr As String)
        On Error Resume Next
        Dim EndLayer = ""
        Dim EndLayerStr = ""
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim ELoc As Long
        Dim EVal = ""
        Dim IsPrime As Boolean = False
        AbsExtrusion = True
        Dim NewE = "0"
        Dim PrevE As String = "0"
        Dim PrevEAdj As String = "0"
        Dim NewEstr As String
        Dim ReplacmentLine = ""
        Dim ImportFileName = FirstFile
        Dim First_GCODE_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim ShortName As String = FirstFile
        Do Until InStr(ShortName, "\") = 0
            Dim SlashLoc = InStr(ShortName, "\")
            ShortName = Strings.Right(ShortName, Len(ShortName) - SlashLoc)
        Loop
        ShortName = Strings.Left(ShortName, Len(ShortName) - 6)

        With Me
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = ShortName & "_" & RetractDist & "retract.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)

                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.Close()
                Exit Sub
            End If
        End With
        Dim DataLine = First_GCODE_File.ReadLine
        DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
        Dim PrevDataline = ""
        Do Until InStr(DataLine, ";Generated") > 0 Or InStr(DataLine, ";LAYER:0") > 0
            NewGcodeFile.WriteLine(DataLine)
            DataLine = First_GCODE_File.ReadLine
        Loop

        NewGcodeFile.WriteLine(PostStr)
        NewGcodeFile.WriteLine(DataLine)
        DataLine = First_GCODE_File.ReadLine

        Do Until First_GCODE_File.EndOfStream = True
            DataLine = First_GCODE_File.ReadLine

            PrevDataline = DataLine
            If Strings.Left(DataLine, 1) = "M" Then
                If Strings.Left(DataLine, 3) = "M82" Then
                    AbsExtrusion = True
                ElseIf Strings.Left(DataLine, 3) = "M83" Then
                    AbsExtrusion = False
                End If
            End If
            If Strings.Left(DataLine, 1) = ";" Or Strings.Left(DataLine, 1) = "M" Then
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If
            If Strings.Left(DataLine, 3) = "G92" Then
                ELoc = InStr(DataLine, " E")
                If ELoc > 0 Then
                    EVal = FileOnFileForm.GetEValue(DataLine, CInt(ELoc))
                    NewGcodeFile.WriteLine(DataLine)
                    IsPrime = False
                    PrevE = EVal
                    GoTo SkipOut
                End If
            End If
            If Strings.Left(DataLine, 2) = "G0" Or Strings.Left(DataLine, 2) = "G1" Then
                ELoc = InStr(DataLine, " E")
                If ELoc > 0 Then

                    EVal = FileOnFileForm.GetEValue(DataLine, CInt(ELoc))
                    If Val(EVal) = 0 Then
                        NewGcodeFile.WriteLine(DataLine)
                        GoTo SkipOut
                    End If
                    If InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 And Not IsPrime Then
                        If AbsExtrusion Then
                            If Val(EVal) < Val(PrevE) Then
                                If Val(PrevE) <> 0 Then
                                    NewE = Format(Val(PrevEAdj) - Val(RetractDist), "0.00000")
                                    IsPrime = True
                                Else
                                    NewE = Format(RetractDist * -1, "0.00000")
                                    PrevDataline = Strings.Replace(DataLine, "E" & EVal, NewE, 1, -1)
                                    IsPrime = False
                                End If
                            ElseIf CLng(PrevE) > 0 Then
                                NewE = Format(Val(PrevEAdj) - Val(RetractDist), "0.00000")
                                IsPrime = True
                            ElseIf CLng(PrevE) <= 0 Then
                                NewE = Format(Val(PrevEAdj) + Val(RetractDist), "0.00000")
                                IsPrime = True
                            End If
                        ElseIf Not AbsExtrusion Then
                            If Val(EVal) < 0 Then
                                IsPrime = False
                                NewE = Format(Val(RetractDist) * -1 * ConvFactor, "0.00000")
                            Else
                                IsPrime = True
                                NewE = Format(Val(RetractDist) * ConvFactor, "0.00000")
                            End If
                        End If
                    Else
                        NewE = Format(Val(EVal) * ConvFactor, "0.00000")
                        PrevE = NewE
                        IsPrime = False
                    End If
                    NewEstr = "E" & NewE
                    DataLine = Strings.Replace(DataLine, "E" & EVal, NewEstr, 1, -1)
                    NewGcodeFile.WriteLine(DataLine)
                    ELoc = InStr(PrevDataline, " E")
                    PrevE = FileOnFileForm.GetEValue(PrevDataline, CInt(ELoc))
                    PrevEAdj = NewE
                    GoTo SkipOut
                Else
                    NewGcodeFile.WriteLine(DataLine)
                    If Strings.InStr(DataLine, " E") > 0 Then
                        ELoc = InStr(PrevDataline, " E")
                        PrevE = FileOnFileForm.GetEValue(PrevDataline, CInt(ELoc))
                        PrevEAdj = NewE
                        GoTo SkipOut
                    End If
                    GoTo SkipOut
                End If
            End If
            NewGcodeFile.WriteLine(DataLine)
SkipOut:
        Loop
        First_GCODE_File.Close()
        NewGcodeFile.Close()
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("The file is complete.  Do you want to open it in NotePad?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim MyGcodeFile As String = Me.SaveFileDialog1.FileName
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

    Private Sub T1But_Click(sender As Object, e As EventArgs) Handles T1But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T0"
            SendTheString(StrToSend)
            SendTheString("M118 T0")
            StrToSend = ""
        End If
    End Sub

    Private Sub T2But_Click(sender As Object, e As EventArgs) Handles T2But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T1"
            SendTheString(StrToSend)
            SendTheString("M118 T1")
            StrToSend = ""
        End If
    End Sub

    Private Sub T3But_Click(sender As Object, e As EventArgs) Handles T3But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T2"
            SendTheString(StrToSend)
            SendTheString("M118 T2")
            StrToSend = ""
        End If
    End Sub

    Private Sub T4But_Click(sender As Object, e As EventArgs) Handles T4But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T3"
            SendTheString(StrToSend)
            SendTheString("M118 T3")
            StrToSend = ""
        End If
    End Sub

    Public Sub ZHOP_Change(AlterZStartLayer As Integer, AlterZEndLayer As Integer, NewZHopHgt As Single)
        On Error Resume Next
        Dim EndLayer = AlterZEndLayer
        Dim StartLayer = AlterZStartLayer
        Dim HopUp = False
        Dim HopHgt = NewZHopHgt
        Dim OrigHopHgt As Single = 0
        Dim IndX = "First"
        Dim InitZHgt As String = "0"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim ZLoc As Long = 0
        Dim ZVal As Single = 0
        Dim NewZVal As Single = 0
        Dim PrevZ As Single = 0
        Dim ActualZ As Single = 0
        Dim ImportFileName = FirstFile
        Dim First_GCODE_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim ShortName As String = FirstFile
        Do Until InStr(ShortName, "\") = 0
            Dim SlashLoc = InStr(ShortName, "\")
            ShortName = Strings.Right(ShortName, Len(ShortName) - SlashLoc)
        Loop
        ShortName = Strings.Left(ShortName, Len(ShortName) - 6)
        With Me
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = ShortName & "_Zhop.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)

                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.Close()
                PrResponse = False
                Exit Sub
            End If
        End With
        Dim MySlicer = FindSlicer(ImportFileName)
        Dim MySearchStr = LayerSearchStr & StartLayer

        Dim DataLine As String = First_GCODE_File.ReadLine
        DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
        Dim PrevDataline = ""
        Do Until InStr(DataLine, ";Generated") > 0
            NewGcodeFile.WriteLine(DataLine)
            DataLine = First_GCODE_File.ReadLine
            If InStr(DataLine, "MINZ:") > 0 Then
                InitZHgt = Strings.Right(DataLine, Len(DataLine) - 6)
                PrevZ = CSng(InitZHgt)
            End If
        Loop
        Dim EndText = "1"
        If EndLayer = 0 Then
            EndText = "End-Of-File"
        Else
            EndText = "LAYER:" & CStr(EndLayer)
        End If
        NewGcodeFile.WriteLine(";POSTPROCESSED by Greg's Toolbox (Z-Hop Change from layer:" & CStr(StartLayer) & " to " & EndText & ")")
        NewGcodeFile.WriteLine(DataLine)
        DataLine = First_GCODE_File.ReadLine
        Do Until InStr(DataLine, MySearchStr) > 0
            NewGcodeFile.WriteLine(DataLine)
            DataLine = First_GCODE_File.ReadLine
        Loop
        NewGcodeFile.WriteLine(DataLine)
        DataLine = ";Start of Z-Hop Changes"
        NewGcodeFile.WriteLine(DataLine)
        Do Until First_GCODE_File.EndOfStream = True
            If InStr(DataLine, LayerSearchStr & EndLayer) > 0 Then
                DataLine = ";End of Z-Hop Changes"
                Do Until First_GCODE_File.EndOfStream = True
                    NewGcodeFile.WriteLine(DataLine)
                    DataLine = First_GCODE_File.ReadLine
                Loop
                GoTo EndOfFile
            End If
            DataLine = First_GCODE_File.ReadLine
            PrevDataline = DataLine
            If Strings.Left(DataLine, 1) = ";" Or Strings.Left(DataLine, 1) = "M" Then
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If
            If Strings.Left(DataLine, 3) = "G92" Then
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If


            If Strings.Left(DataLine, 3) = "G1 " Then 'Or Strings.Left(DataLine, 2) = "G1" 
                'Z with no X or Y
                If InStr(DataLine, " Z") > 0 And InStr(DataLine, " X") = 0 And InStr(DataLine, " Y") = 0 Then
                    ZLoc = InStr(DataLine, " Z")
                    ZVal = CSng(FileOnFileForm.GetZValue(DataLine, CInt(ZLoc)))
                    ActualZ = ZVal
                    If ZVal > PrevZ Then
                        If OrigHopHgt = 0 Then
                            OrigHopHgt = ZVal - PrevZ
                        End If
                        NewZVal = CSng(Val(PrevZ) + Val(NewZHopHgt))
                    ElseIf ZVal <= PrevZ Then
                        NewZVal = ZVal
                    Else
                        NewZVal = ZVal
                    End If

                    If NewZVal = 0 Then NewZVal = CSng(InitZHgt)
                    PrevZ = ZVal
                    DataLine = Strings.Replace(DataLine, CStr(ZVal), CStr(NewZVal), 1, -1)
                    NewGcodeFile.WriteLine(DataLine)
                    HopUp = Not HopUp
                    HopHgt = CSng(NewZVal)
                    GoTo SkipOut
                    'Z with X or Y no E
                End If
            ElseIf Strings.Left(DataLine, 3) = "G0 " Then
                If InStr(DataLine, " Z") > 0 And (InStr(DataLine, " X") > 0 Or InStr(DataLine, " Y") > 0) And InStr(DataLine, " E") = 0 Then
                    ZLoc = InStr(DataLine, " Z")
                    ZVal = CSng(FileOnFileForm.GetZValue(DataLine, CInt(ZLoc)))
                    ActualZ = ZVal
                    If HopUp And ZVal = PrevZ Then
                        DataLine = Strings.Replace(DataLine, CStr(ZVal), CStr(NewZVal), 1, -1)
                        NewGcodeFile.WriteLine(DataLine)
                        GoTo SkipOut
                    ElseIf HopUp And ZVal > PrevZ Then
                        DataLine = Strings.Replace(DataLine, CStr(ZVal), CStr(ZVal - OrigHopHgt + NewZHopHgt), 1, -1)
                        NewGcodeFile.WriteLine(DataLine)
                        PrevZ = ZVal
                        GoTo SkipOut
                    End If
                    If ZVal = PrevZ Then
                        NewZVal = HopHgt
                    ElseIf ZVal > PrevZ Then
                        DataLine = Strings.Replace(DataLine, CStr(ZVal), CStr(ZVal - OrigHopHgt + NewZHopHgt), 1, -1)
                        NewGcodeFile.WriteLine(DataLine)
                        PrevZ = ZVal
                        GoTo SkipOut
                    Else
                        NewZVal = ZVal
                    End If
                    PrevZ = NewZVal
                    DataLine = Strings.Replace(DataLine, CStr(ZVal), CStr(NewZVal), 1, -1)
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                End If
            End If
            NewGcodeFile.WriteLine(DataLine)
SkipOut:
        Loop
EndOfFile:
        First_GCODE_File.Close()
        NewGcodeFile.Close()
        Me.ProgressBar1.Visible = False
    End Sub

    Public Sub ContinueFanProfile()
        Dim LineToEnter As String
        Dim ArrayIndex = 0
        If PrResponse = False Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim DataLine As String
        DataLine = FanProfileForm.FanOriginalFile.ReadLine
        DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
        If FanProfileForm.FanProfileArray(0, 0) = "" Then
            MsgBox("There Is no fan profile.  The process will end now.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Do Until InStr(DataLine, ";Generated") > 0
            FanProfileForm.FanNewGcodeFile.WriteLine(DataLine)
            DataLine = FanProfileForm.FanOriginalFile.ReadLine
        Loop
        FanProfileForm.FanNewGcodeFile.WriteLine(";POSTPROCESSED by Greg's Toolbox (Cooling by Layer)")
        FanProfileForm.FanNewGcodeFile.WriteLine(DataLine)
        DataLine = FanProfileForm.FanOriginalFile.ReadLine
        Do Until FanProfileForm.FanOriginalFile.EndOfStream = True
            Try
                Do Until InStr(DataLine, FanProfileForm.FanProfileArray(0, ArrayIndex), vbTextCompare) > 0 And Len(DataLine) = Len(FanProfileForm.FanProfileArray(0, ArrayIndex))
                    If InStr(DataLine, "M107", vbTextCompare) > 0 Or InStr(DataLine, "M106", vbTextCompare) > 0 Then
                        'If InStr(DataLine, "M106 S0 ;Turn-off fan") > 0 Then
                        'DataLine = DataLine
                        'Else
                        DataLine = ""
                        'End If
                    End If
                    If FanProfileForm.FanProfileArray(0, 0) <> ";LAYER:0" Then
                        If InStr(DataLine, ";LAYER:0") > 0 Then
                            FanProfileForm.FanNewGcodeFile.WriteLine("M106 S0")
                        End If
                    End If
                    If DataLine <> "" Then
                        FanProfileForm.FanNewGcodeFile.WriteLine(DataLine)
                    End If
                    If FanProfileForm.FanOriginalFile.EndOfStream = True Then Exit Do
                    DataLine = FanProfileForm.FanOriginalFile.ReadLine
                Loop
                LineToEnter = FanProfileForm.FanProfileArray(1, ArrayIndex)
                ArrayIndex += 1
                If ArrayIndex <= UBound(FanProfileForm.FanProfileArray, 2) Then
                    FanProfileForm.FanNewGcodeFile.WriteLine(DataLine)
                    FanProfileForm.FanNewGcodeFile.WriteLine(LineToEnter)
                    DataLine = FanProfileForm.FanOriginalFile.ReadLine
                ElseIf ArrayIndex > UBound(FanProfileForm.FanProfileArray, 2) Then
                    FanProfileForm.FanNewGcodeFile.WriteLine(DataLine)
                    FanProfileForm.FanNewGcodeFile.WriteLine(LineToEnter)
                    DataLine = FanProfileForm.FanOriginalFile.ReadLine
                    GoTo SkipOut
                End If
                If InStr(DataLine, ";End of Gcode") > 0 Then
                    FanProfileForm.FanNewGcodeFile.WriteLine("M106 S0 ;Turn off the layer blower")
                End If
            Catch ex As Exception
                Exit Do
            End Try
        Loop
SkipOut:
        Do Until FanProfileForm.FanOriginalFile.EndOfStream = True
            If InStr(DataLine, "M106", vbTextCompare) > 0 Then 'And Len(DataLine) < 10 Then
                DataLine = FanProfileForm.FanOriginalFile.ReadLine
            End If
            If InStr(DataLine, ";End of Gcode") > 0 Then
                FanProfileForm.FanNewGcodeFile.WriteLine("M106 S0 ;Turn off the layer blower")
            End If
            FanProfileForm.FanNewGcodeFile.WriteLine(DataLine)
            If FanProfileForm.FanOriginalFile.EndOfStream = True Then GoTo SkipOut2
            DataLine = FanProfileForm.FanOriginalFile.ReadLine
        Loop
SkipOut2:
        FanProfileForm.FanOriginalFile.Close()
        FanProfileForm.FanNewGcodeFile.Close()
        Me.TextBox1.Text &= vbCrLf & "Completed"
        Me.Refresh()
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("The file is complete" & vbCr & vbCr & "Do you want to open the new file?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbYes Then Call FanProfileForm.OpenCoolingFile(Me.SaveFileDialog1.FileName)
    End Sub

    Private Sub T1But2But_Click(sender As Object, e As EventArgs) Handles T1But2But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T0"
            SendTheString(StrToSend)
            SendTheString("M118 T0")
            StrToSend = ""
        End If
    End Sub

    Private Sub T2But2But_Click(sender As Object, e As EventArgs) Handles T2But2But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T1"
            SendTheString(StrToSend)
            SendTheString("M118 T1")
            StrToSend = ""
        End If
    End Sub

    Private Sub T3But2But_Click(sender As Object, e As EventArgs) Handles T3But2But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T2"
            SendTheString(StrToSend)
            SendTheString("M118 T2")
            StrToSend = ""
        End If
    End Sub

    Private Sub T4But2But_Click(sender As Object, e As EventArgs) Handles T4But2But.Click
        If Me.Vcomm.IsOpen Then
            StrToSend = "T3"
            SendTheString(StrToSend)
            SendTheString("M118 T3")
            StrToSend = ""
        End If
    End Sub

    Public Sub MirrorAboutX(MaxBedY As Single, HomeOffY As Single)
        On Error Resume Next
        Dim NewHomeOffset As Single = -1 * MaxBedY
        NewHomeOffset += HomeOffY
        Dim IndX = "First"
        Dim FirstFile As String = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim XLoc As Long
        Dim XVal = ""
        Dim NewX = "0"
        Dim NewXStr = ""
        Dim ReplacmentLine = ""
        Dim ImportFileName = FirstFile
        Dim First_GCODE_File As System.IO.StreamReader
        First_GCODE_File = My.Computer.FileSystem.OpenTextFileReader(FirstFile)
        Dim NewGcodeFile As System.IO.StreamWriter
        With Me
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
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.Close()
                Exit Sub
            End If
        End With
        Dim DataLine = ""
        Dim PrevDataline = ""
        Do Until First_GCODE_File.EndOfStream = True
            DataLine = First_GCODE_File.ReadLine
            DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")

            If Strings.Left(DataLine, 1) = ";" Or Strings.Left(DataLine, 1) = "M" Then
                If InStr(DataLine, ";Generated with") > 0 Then
                    NewGcodeFile.WriteLine(DataLine)
                    NewGcodeFile.WriteLine(";POSTPROCESSED Greg's Toolbox (Mirror about Y)")
                    GoTo SkipOut
                End If
                If InStr(DataLine, ";End of Gcode") > 0 Then
                    NewGcodeFile.WriteLine("M206 X" & HomeOffY)
                    NewGcodeFile.WriteLine(DataLine)
                End If
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If
            If Strings.Left(DataLine, 2) = "G0" Or Strings.Left(DataLine, 2) = "G1" Then
                XLoc = InStr(DataLine, " X")
                If XLoc > 0 Then
                    XVal = FileOnFileForm.GetXValue(DataLine, CInt(XLoc))
                    NewX = CStr(CLng(XVal) * -1)
                    NewXStr = "X" & NewX
                    DataLine = Strings.Replace(DataLine, "X" & XVal, NewXStr, 1, -1)
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                Else
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                End If
            End If
            If InStr(DataLine, "G28") > 0 Then
                NewGcodeFile.WriteLine(DataLine)
                NewGcodeFile.WriteLine("M206 X" & NewHomeOffset)
                GoTo SkipOut
            End If
            NewGcodeFile.WriteLine(DataLine)
SkipOut:
        Loop
        First_GCODE_File.Close()
        NewGcodeFile.Close()
    End Sub

    Public Sub MirrorAboutY(MaxBedX As Single, HomeOffX As Single)
        On Error Resume Next
        Dim NewHomeOffset = -1 * MaxBedX
        NewHomeOffset += HomeOffX
        Dim IndY = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndY)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim YLoc As Integer
        Dim YVal = ""
        Dim NewY = "0"
        Dim NewYStr = ""
        Dim ReplacmentLine = ""
        Dim ImportFileName = FirstFile
        Dim First_GCODE_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim NewGcodeFile As System.IO.StreamWriter
        With Me
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = "*.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.Close()
                Exit Sub
            End If
        End With
        Dim DataLine = ""
        Dim PrevDataline = ""
        Do Until First_GCODE_File.EndOfStream = True
            DataLine = First_GCODE_File.ReadLine
            DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
            If Strings.Left(DataLine, 1) = ";" Or Strings.Left(DataLine, 1) = "M" Then
                If InStr(DataLine, ";Generated with") > 0 Then
                    NewGcodeFile.WriteLine(DataLine)
                    NewGcodeFile.WriteLine(";POSTPROCESSED Greg's Toolbox (Mirror about X)")
                    GoTo SkipOut
                End If
                If InStr(DataLine, ";End of Gcode") > 0 Then
                    NewGcodeFile.WriteLine("M206 Y" & HomeOffX)
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                End If
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If

            If Strings.Left(DataLine, 2) = "G0" Or Strings.Left(DataLine, 2) = "G1" Then
                YLoc = InStr(DataLine, " Y")
                If YLoc > 0 Then
                    YVal = FileOnFileForm.GetYValue(DataLine, YLoc)
                    NewY = CStr(CLng(YVal) * -1)
                    NewYStr = "Y" & NewY
                    DataLine = Strings.Replace(DataLine, "Y" & YVal, NewYStr, 1, -1)
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                Else
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                End If
            End If
            If InStr(DataLine, "G28") > 0 Then
                NewGcodeFile.WriteLine(DataLine)
                NewGcodeFile.WriteLine("M206 Y" & NewHomeOffset)
                GoTo SkipOut
            End If
            NewGcodeFile.WriteLine(DataLine)
SkipOut:
        Loop
        First_GCODE_File.Close()
        NewGcodeFile.Close()
    End Sub

    Private Sub SetAutoLevBut_Click(sender As Object, e As EventArgs) Handles SetAutoLevBut.Click
        On Error Resume Next
        Dim Aresponse = MsgBox("This will set the command for the Auto-Level button.  The default is ""G29"" but you can make it any single command that works for your printer.  If you need a multi-line command then use the macro buttons on the Com Port page" &
               vbCr & vbCr & "Do you want to continue?", vbYesNo, "Greg's A and J Tool")
        If Aresponse = vbNo Then Exit Sub
        Dim TheCmd = UCase(InputBox("Enter the G-Code command (and any parameters) you wish to use for Auto-Leveling.", "Auto-Level Command", My.Settings.AutoLevelCMD, -1, -1))
        If TheCmd = "" Or TheCmd = My.Settings.AutoLevelCMD Then Exit Sub
        My.Settings.AutoLevelCMD = TheCmd
        GCODE_Settings.AutoLevelCmdBox.Text = TheCmd
        Me.G29But.Text = "Auto Level" & vbLf & TheCmd
        Me.G29But.Visible = True
        Me.G29But.Enabled = True
        Me.SetAutoLevBut.Visible = True
        Me.SetAutoLevBut.Enabled = True
    End Sub

    Private Sub MarlinWebsiteBut_Click(sender As Object, e As EventArgs) Handles MarlinWebsiteBut.Click
        Dim URL As String = "https://marlinfw.org/meta/gcode/"
        Dim NewProcess As New Diagnostics.ProcessStartInfo(URL) With {
            .UseShellExecute = True
        }

        'Dim NewProcess As Diagnostics.ProcessStartInfo = New Diagnostics.ProcessStartInfo(URL) With {
        '.UseShellExecute = True
        '}
        Process.Start(NewProcess)
    End Sub

    Private Sub RepRapBut_Click(sender As Object, e As EventArgs) Handles RepRapBut.Click
        Dim URL As String = "https://reprap.org/wiki/G-code"
        Dim NewProcess As New Diagnostics.ProcessStartInfo(URL) With {
            .UseShellExecute = True
        }
        NewProcess.UseShellExecute = True
        Process.Start(NewProcess)
    End Sub

    Private Sub LW_TextChanged(sender As Object, e As EventArgs) Handles LW.TextChanged
        Dim FillArea = (Val(My.Settings.FilamentDia) / 2) ^ 2 * Math.PI
        With Me
            .cumm.Text = Format(Val(.LW.Text) * Val(.LH.Text) * Val(.mmPsec.Text), "0.0")
            .FilSec.Text = Format(Val(.cumm.Text) / FillArea, "0.0")
            .Evalue.Text = Format((Val(.LW.Text) * Val(.LH.Text) * Val(.ExtLength.Text)) / FillArea, "0.00000")
        End With
    End Sub

    Private Sub LH_TextChanged(sender As Object, e As EventArgs) Handles LH.TextChanged
        Dim FilArea = (Val(My.Settings.FilamentDia) / 2) ^ 2 * Math.PI
        With Me
            .cumm.Text = Format(Val(.LW.Text) * Val(.LH.Text) * Val(.mmPsec.Text), "0.0")
            .FilSec.Text = Format(Val(.cumm.Text) / FilArea, "0.0")
            .Evalue.Text = Format((Val(.LW.Text) * Val(.LH.Text) * Val(.ExtLength.Text)) / FilArea, "0.00000")
        End With
    End Sub

    Private Sub MMPsec_TextChanged(sender As Object, e As EventArgs) Handles mmPsec.TextChanged
        Dim FilArea = (Val(My.Settings.FilamentDia) / 2) ^ 2 * Math.PI
        With Me
            .cumm.Text = Format(Val(.LW.Text) * Val(.LH.Text) * Val(.mmPsec.Text), "0.0")
            .FilSec.Text = Format(Val(.cumm.Text) / FilArea, "0.0")
        End With
    End Sub

    Private Sub CBHomeXYbut_Click(sender As Object, e As EventArgs) Handles CBHomeXYbut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "G28 X Y"
        SendTheString(StrToSend)
        Me.DisableSteppersButt.Checked = False
        SendTheString("M118 Auto-Home X Y")
        StrToSend = ""
    End Sub

    Private Sub CBHomeZbut_Click(sender As Object, e As EventArgs) Handles CBHomeZbut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "G28 Z"
        SendTheString(StrToSend)
        Me.DisableSteppersButt.Checked = False
        SendTheString("M118 Auto-Home Z")
        StrToSend = ""
    End Sub

    Private Sub ChkBaudBut_Click(sender As Object, e As EventArgs) Handles ChkBaudBut.Click
        If Me.AvailablePortsBox.Items.Count = 0 Or Strings.Left(CStr(Me.AvailablePortsBox.SelectedItem), 3) <> "COM" Then
            MsgBox("You must have a COM listed in Available Ports box.  Use the Search for Ports button.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        Else
            Try
                'If Me.Vcomm.IsOpen Then
                Me.Vcomm.DiscardInBuffer()
                Me.Vcomm.DiscardOutBuffer()
                'End If
                Dim MyPort = Me.AvailablePortsBox.Text '9600, 19200, 38400, 57600, 115200, 230400, 250000, 460800, 921600
                If CheckBaudRate(MyPort, "921600") Then
                    My.Settings.PortBaud = "921600"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "460800") Then
                    My.Settings.PortBaud = "460800"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "250000") Then
                    My.Settings.PortBaud = "250000"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "230400") Then
                    My.Settings.PortBaud = "230400"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "115200") Then
                    My.Settings.PortBaud = "115200"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "57600") Then
                    My.Settings.PortBaud = "57600"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "38400") Then
                    My.Settings.PortBaud = "38400"
                    Exit Sub
                ElseIf CheckBaudRate(MyPort, "19200") Then
                    My.Settings.PortBaud = "19200"
                    Exit Sub
                Else
                    My.Settings.PortBaud = "9600"
                    MsgBox("The following Baud Rates were checked and none worked.
921600, 460800, 250000, 230400, 115200, 57600, 38400, 19200." & vbCr & vbCr & " So the Baud Rate test has failed.  The default Baud Rate has been changed to 9600.", vbOKOnly, "Greg's Toolbox")
                    Me.ComOpenBut.Checked = False
                    Exit Sub
                End If
            Catch
                MsgBox("There was an error when trying to find the Baud Rate.", vbOKOnly, "Greg's SD Print Tool")
                Exit Sub
            End Try
        End If
        If Me.Vcomm.IsOpen Then
            If Me.ComOpenBut.Checked = False Then
                Me.ComOpenBut.Checked = True
            End If
        End If
    End Sub

    Public Function CheckBaudRate(PName As String, BRate As String) As Boolean
        Try
            If Me.Vcomm.IsOpen Then
                Me.Vcomm.Close()
            End If
        Catch
        End Try
        With Me
            RemoveHandler Vcomm.DataReceived, AddressOf Me.SerialPort1_DataReceived
            Vcomm.BaudRate = CInt(BRate)
            .TextBox1.Text &= "Checking ~ " & BRate & vbCrLf
            Me.Refresh()
            Vcomm.PortName = PName
            Try
                Vcomm.Open()
            Catch
                MsgBox("There is no available port open.", vbOKOnly, "Greg's Toolbox")
                CheckBaudRate = False
                Exit Function
            End Try
            Threading.Thread.Sleep(500)
            Vcomm.WriteLine("M105")
            Threading.Thread.Sleep(500)
            RecvStr = ""
            Do Until Vcomm.BytesToRead = 0
                Try
                    RecvStr += Vcomm.ReadLine
                Catch
                End Try
            Loop
        End With
        If InStr(RecvStr, "ok") > 0 Then
            CheckBaudRate = True
            Me.ChkBaudBut.Text = "Baud Rate - " & Me.Vcomm.BaudRate
            RecvStr = Strings.Replace(RecvStr, "M105", vbCrLf & "M105", 1, -1, vbTextCompare)
            Me.TextBox1.Text = RecvStr
            SendTheString("M118 If you can read this then the baud rate of " & BRate & " works." & vbCrLf)
            My.Settings.PortBaud = BRate
            If Me.ComOpenBut.Checked = False And Me.Vcomm.IsOpen = True Then
                RemoveHandler ComOpenBut.CheckedChanged, AddressOf ComOpenBut_CheckedChanged
                Me.ComOpenBut.Checked = True
                Me.ComOpenBut.Text = "Serial Port " & ComPortName & " is Open"
                Me.ComOpenBut.BackColor = Color.DarkGreen
                Me.TextBox1.Text = ComPortName & " is Open" & vbCrLf
                Me.StepOnOffBut.Checked = True
                Me.TextBox1.Text += "Stepper time-out is set to 4 hours " & vbCrLf
                Me.ComOpenLab.Text = "Com Port " & Me.Vcomm.PortName & " is Open"
                Me.ComOpenLab.BackColor = Color.DarkGreen
                AddHandler ComOpenBut.CheckedChanged, AddressOf ComOpenBut_CheckedChanged
            End If

        Else
            CheckBaudRate = False
            Me.ChkBaudBut.Text = "Baud Rate - {???}"
            Me.TextBox1.Text &= "FAIL" & vbCrLf & vbCrLf
            Me.Refresh()
        End If
        RecvStr = ""
        AddHandler Vcomm.DataReceived, AddressOf Me.SerialPort1_DataReceived
    End Function

    Private Sub AddACoolingProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddACoolingProfileToolStripMenuItem.Click
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("This command will remove existing M106 and M107 lines in a CURA Gcode file.  New M106 lines will be added from a profile you create.  If your Start Layer is other than LAYER:0 then the print will start with the fan off." & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX) 'Use Open File Dialog to get the name of the gcode file to be altered.
        If FirstFile = "" Then Exit Sub
        Dim LineToEnter = ""
        Me.TextBox1.Text &= vbCrLf & "Add a Cooling Profile" & vbCrLf & vbCrLf & "Original File Name:  " & vbCrLf & FirstFile
        Me.Refresh()
        Dim ImportFileName = FirstFile
        FanProfileForm.FanOriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        FanProfileForm.MaxLayer = -1
        Dim SearchLine As String
        Dim MaxLayerFound As Long
        Do Until FanProfileForm.MaxLayer > -1
            SearchLine = FanProfileForm.FanOriginalFile.ReadLine
            MaxLayerFound = InStr(SearchLine, ";LAYER_COUNT:")
            If MaxLayerFound > 0 Then
                FanProfileForm.MaxLayer = CInt(Strings.Right(SearchLine, CInt(Len(SearchLine) - 13))) - 1
                FanProfileForm.Label22.Text = "Gcode Top Layer# is: " & FanProfileForm.MaxLayer
                FanProfileForm.FanOriginalFile.Close()
                FanProfileForm.FanOriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
            End If
        Loop
        With Me
            Dim TempName = FirstFile
            Do Until InStr(TempName, "\") = 0
                TempName = Strings.Right(TempName, Len(TempName) - InStr(TempName, "\"))
            Loop
            TempName = Strings.Left(TempName, Len(TempName) - 6)
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = TempName & "_COOLED.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then 'Use Save File dialog to create a new text file the a specified name *.gcode.
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)

                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If
                FanProfileForm.FanNewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
                .TextBox1.Text &= vbCrLf & vbCrLf & "New File Name:  " & vbCrLf & SaveFileDialog1.FileName & vbCrLf
                .Refresh()
            Else
                FanProfileForm.FanOriginalFile.Close()
                .TextBox1.Text &= vbCrLf & "Canceled"
                Exit Sub
            End If
        End With
        Dim MySlicer = FindSlicer(ImportFileName) 'find the slicer that created the gcode file so "layers #'s" can be found.
        FanProfileForm.FanArrayIndex = "0"
        ReDim FanProfileForm.FanProfileArray(1, 0)
        FanProfileForm.Counter = -1
        FanProfileForm.TextBox1.Text = "0"
        FanProfileForm.TextBox2.Text = "0"
        FanProfileForm.ShowDialog() 'Show the Fan Profile Form
    End Sub

    Private Sub CombineGcodeFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CombineGcodeFilesToolStripMenuItem.Click
        FileOnFileForm.Show()
        FileOnFileForm.BringToFront()
    End Sub

    Private Sub MirrorAboutXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MirrorAboutXToolStripMenuItem.Click
        Dim AResponse = MsgBox("This will MIRROR a GCODE file about the X axis and create a new file.  The ""Y"" Home Offset will be adjusted and all the ""Y"" values in the file will be re-written to ""Y * -1""" & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim MaxBedY = InputBox("Please enter the MAXIMUM ""Y"" DIMENSION of your build plate).", "Max ""Y""", My.Settings.Bed_Ymax)
        If MaxBedY = "" Then
            MsgBox("You must enter a valid dimension for the bed Y Max.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim HomeOffsetY = InputBox("Please enter the current HOME OFFSET Y value).", "Home Offset ""Y""", My.Settings.HomeOffsetY)
        If HomeOffsetY = "" Then
            MsgBox("You must enter a value.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Call Me.MirrorAboutY(CSng(MaxBedY), CSng(HomeOffsetY))
        MsgBox("The process is complete.  Note that the file will not display correctly in Cura because Cura will not take the Home Offset change into account.", vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub MirrorAboutYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MirrorAboutYToolStripMenuItem.Click
        Dim AResponse = MsgBox("This will MIRROR a GCODE file about the Y axis and create a new file.  The ""X"" Home Offset will be adjusted and all the ""X"" values in the file will be re-written to ""X * -1""" & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim MaxBedX = InputBox("Please enter the MAXIMUM ""X"" DIMENSION of your build plate).", "Max ""X""", My.Settings.Bed_Xmax)
        If MaxBedX = "" Then
            MsgBox("You must enter a valid dimension for the bed X Max.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim HomeOffsetX = InputBox("Please enter the current HOME OFFSET X value).", "Home Offset ""X""", My.Settings.HomeOffsetX)
        If HomeOffsetX = "" Then
            MsgBox("You must enter a value.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If

        Call Me.MirrorAboutX(CSng(MaxBedX), CSng(HomeOffsetX))
        MsgBox("The process is complete.  Note that the file will not display correctly in Cura because Cura will not take the Home Offset change into account.", vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub To285FilamentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles To285FilamentToolStripMenuItem.Click
        Dim AResponse = MsgBox("This will change all the extrusions in a GCODE file from 1.75 dia filament to 2.85 dia filament.  Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Me.NewRetractionDistance = InputBox("Adjusting the retraction distance can result in extremely long retractions.  Please enter the Retraction Distance you want to use for the 2.85mm filament.", "Retraction Distance", "7")
        If Me.NewRetractionDistance = "" Then
            MsgBox("You must enter a retraction distance.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PostStr = ";POSTPROCESSED by Greg's Toolbox (Filament Dia Change to 2.85)"
        Call Me.FilamentDiameterChange(0.37704, CSng(Me.NewRetractionDistance), PostStr)
    End Sub

    Private Sub To175FilamentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles To175FilamentToolStripMenuItem.Click
        Dim AResponse = MsgBox("This will change all the extrusions in a GCODE file from 2.85 dia filament to 1.75 dia filament.  Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Me.NewRetractionDistance = InputBox("Adjusting the retraction distance can result in extremely long retractions.  Please enter the Retraction Distance you want to use for the 1.75mm filament.", "Retraction Distance", "5")
        If Me.NewRetractionDistance = "" Then
            MsgBox("You must enter a retraction distance.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PostStr = ";POSTPROCESSED by Greg's Toolbox (Filament Dia Change to 1.75)"
        Call Me.FilamentDiameterChange(2.65225, CSng(Me.NewRetractionDistance), PostStr)
    End Sub

    Private Sub MicroLayersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MicroLayersToolStripMenuItem.Click
        On Error GoTo TheHandler
        Dim FileResponse As DialogResult
        Dim NewHeight As Single
        Dim LayerHeight As Single
        Dim ConversionFactor As Single
        Dim Gcode_File As System.IO.StreamReader
        Dim NewFileResponse As DialogResult
        Dim FirstFile As String
        Dim Dataline As String
        Dim Zprev As String, Zcur As String
        Dim ImportFileName As String
        Dim Start As Boolean
        Dim ELoc As Long
        Dim OldEValue As Single
        Dim OldEstr As String
        Dim NewEvalue As Single
        Dim NewEstr As String
        Dim Zpresent As String
        Dim OldZ As Single
        Dim NewZ As Single
        Dim Zstr As String
        Dim Zspace As Long
        Dim NewZstr As String
        Dim LineToWrite As String
        Dim MyShell As Object
        Dim LineCount As Long
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim IndX As String = "First"
        Dim AResponse = MsgBox("This will alter all the Layer Height moves in a GCODE file and will also adjust the extrusion volume (if there are extrusions) and create a New file." & vbCr & vbCr &
                                "The model must have been properly scaled in the Z prior to creating the Gcode.  You cannot have used Adaptive Layers in the Gcode." & vbCr & vbCr &
                                "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        FirstFile = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim ZLoc = ""
        Dim ZVal = ""
        Dim NewZVal = ""
        Dim PrevZ As String = "0"
        Dim First_GCODE_File = My.Computer.FileSystem.OpenTextFileReader(FirstFile)
        'Dim NewGcodeFile As System.IO.StreamWriter
        With Me
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = "*.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.Close()
                Exit Sub
            End If
        End With
        LayerHeight = CSng(InputBox("Enter the Layer Height of the main gcode file.", "Old Layer Height", ".2"))
        If LayerHeight = 0 Then Exit Sub
        NewHeight = CSng(InputBox("Enter the NEW Layer Height", "New Layer Height", ".01"))
        If NewHeight = 0 Then Exit Sub
        ConversionFactor = LayerHeight / NewHeight
        'FileResponse = Application.GetOpenFilename("GCODE Files (*.gcode), *.gcode", 1, " Open the Main GCODE File...")
        'If FileResponse = False Then
        'Exit Sub
        'End If
        ImportFileName = FirstFile
        Gcode_File = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        'NewFileResponse = Application.GetSaveAsFilename("*.gcode", "GCODE Files (*.gcode), *.gcode", 1, "  Save the NEW gcode file")
        'If NewFileResponse = False Then Exit Sub
        'Dim outputFile = fs.CreateTextFile(NewGcodeFile, True)
        'NewGcodeFile = fs.OpenTextFile(outputFile, 1, True)
        Start = False
        Do Until Start = True
            Dataline = Gcode_File.ReadLine
            NewGcodeFile.WriteLine(Dataline)
            If InStr(1, Dataline, "layer:0") > 0 Then Start = True
        Loop
        Do While Gcode_File.EndOfStream <> True
            Dataline = Gcode_File.ReadLine
            If Strings.Left(Dataline, 2) = "G0" Or Strings.Left(Dataline, 2) = "G1" Then
                If InStr(1, Dataline, " E") > 0 Then
                    ELoc = InStr(1, Dataline, " E")
                    OldEValue = CSng(Get_E_Value(Dataline, CStr(ELoc)))
                    OldEstr = "E" & OldEValue
                    NewEvalue = OldEValue / ConversionFactor
                    NewEstr = "E" & NewEvalue
                    Dataline = Strings.Replace(Dataline, OldEstr, NewEstr, 1, -1)
                End If
                If InStr(1, Dataline, " Z") = 0 Then
                    NewGcodeFile.WriteLine(Dataline)
                    GoTo Kickout
                Else
                    Zpresent = CStr(InStr(1, Dataline, " Z"))
                    OldZ = CSng(Get_Z_Value(Dataline, Zpresent))
                    NewZ = OldZ / ConversionFactor
                    Zstr = Strings.Right(Dataline, Len(Dataline) - CInt(Zpresent) - 0)
                    Zspace = InStr(1, Zstr, " ")
                    If Zspace > 0 Then
                        Zstr = Strings.Left(Zstr, CInt(Zspace) - 0)
                    End If
                    NewZstr = "Z" & NewZ
                    LineToWrite = Strings.Replace(Dataline, Zstr, NewZstr, 1, -1)
                    NewGcodeFile.WriteLine(LineToWrite)
                End If
            Else
                If InStr(Dataline, ";LAYER:") > 0 Then
                    FormsModule.StrToSend = "M118 " & Strings.Replace(GetLayerNumber(Dataline), ";", "", 1, 1)
                    If Me.Vcomm.IsOpen Then
                        FormsModule.SendTheString(StrToSend)
                        StrToSend = ""
                        Threading.Thread.Sleep(250)
                    End If
                End If
                NewGcodeFile.WriteLine(Dataline)
            End If
Kickout:
        Loop
        Gcode_File.Close()
        NewGcodeFile.Close()
        AResponse = MsgBox("The transition is complete." & vbCr & "Would you like to open the file in Notepad to view?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbYes Then
            MyShell = Shell("notepad.exe " & Me.SaveFileDialog1.FileName, vbNormalFocus)
        End If
        MsgBox("The process is complete.", vbOKOnly, "Greg's Toolbox")
        Exit Sub
TheHandler:
        MsgBox("There was an error in ""Mainform.MicroLayersToolStripMenuItem_Click""." & vbLf & Err.Description & vbCr & "In line: " & LineCount, vbOKOnly, "Stoopid Engineering")
    End Sub

    Function Get_X_Value(Dataline As String, Xpresent As Integer) As String
        On Error Resume Next
        Dim Xstr As String
        Dim Xspace As Integer
        Xstr = Strings.Right(Dataline, Len(Dataline) - Xpresent - 1)
        Xspace = InStr(1, Xstr, " ")
        If Xspace > 0 Then
            Xstr = Strings.Left(Xstr, Xspace - 1)
        End If
        Get_X_Value = Xstr
    End Function

    Function Get_Y_Value(Dataline As String, Ypresent As Integer) As String
        On Error Resume Next
        Dim Ystr As String
        Dim Yspace As Integer
        Ystr = Strings.Right(Dataline, Len(Dataline) - Ypresent - 1)
        Yspace = InStr(Ystr, " ", vbTextCompare)
        If Yspace > 0 Then
            Ystr = Strings.Left(Ystr, Yspace - 1)
        End If
        Get_Y_Value = Ystr
    End Function

    Function Get_Z_Value(Dataline As String, Zpresent As String) As String
        On Error Resume Next
        Dim Zstr As String
        Dim Zspace As String
        Zstr = Strings.Right(Dataline, Len(Dataline) - CInt(Zpresent) - 1)
        Zspace = CStr(InStr(Zstr, " ", vbTextCompare))
        If CInt(Zspace) > 0 Then
            Zstr = Strings.Left(Zstr, CInt(Zspace) - 1)
        End If
        Get_Z_Value = Zstr
    End Function

    Function Get_E_Value(Dataline As String, Epresent As String) As String
        On Error Resume Next
        Dim Estr As String
        Dim Espace As String
        Estr = Strings.Right(Dataline, Len(Dataline) - CInt(Epresent) - 1)
        Espace = CStr(InStr(Estr, " ", vbTextCompare))
        If CInt(Espace) > 0 Then
            Estr = Strings.Left(Estr, CInt(Espace) - 1)
        End If
        Get_E_Value = Estr
    End Function

    Function Get_F_Value(Dataline As String, Fpresent As String) As String
        On Error Resume Next
        Dim Fstr As String
        Dim Fspace As String
        Fstr = Strings.Right(Dataline, Len(Dataline) - CInt(Fpresent) - 1)
        Fspace = CStr(InStr(Fstr, " ", vbTextCompare))
        If CInt(Fspace) > 0 Then
            Fstr = Strings.Left(Fstr, CInt(Fspace) - 1)
        End If
        Get_F_Value = Fstr
    End Function

    Public Function GetLayerNumber(Dataline As String) As String
        Dim TheSpace = InStr(Dataline, " ")
        If TheSpace > 0 Then
            GetLayerNumber = Strings.Left(Dataline, TheSpace)
        Else
            GetLayerNumber = Dataline
        End If
    End Function

    Private Sub SearchAndReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchAndReplaceToolStripMenuItem.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("This command will find text strings and replace them with new text." & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX) 'Use Open File Dialog to get the name of the gcode file to be altered.
        If FirstFile = "" Then Exit Sub
        Dim LineToEnter = ""
        Dim ImportFileName = FirstFile
        Dim SearchOriginalFile As System.IO.StreamReader
        Dim SearchMaxLayer As Integer
        SearchOriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        SearchMaxLayer = -1
        Dim ReplaceGcodeFile As System.IO.StreamWriter
        Dim SearchLine As String
        Dim MaxLayerFound As Long = 0
        Do Until FanProfileForm.MaxLayer > -1
            SearchLine = FanProfileForm.FanOriginalFile.ReadLine
            MaxLayerFound = InStr(SearchLine, ";LAYER_COUNT:")
            If MaxLayerFound > 0 Then
                SearchMaxLayer = CInt(Strings.Right(SearchLine, Len(SearchLine) - 13 - 1))
                SearchOriginalFile.Close()
                SearchOriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
            End If
        Loop
        Dim ShortName As String = FirstFile
        Do Until InStr(ShortName, "\") = 0
            Dim SlashLoc = InStr(ShortName, "\")
            ShortName = Strings.Right(ShortName, Len(ShortName) - SlashLoc)
        Loop
        ShortName = Strings.Left(ShortName, Len(ShortName) - 6)
        With Me
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = ShortName & "_SandR.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then 'Use Save File dialog to create a new text file the a specified name *.gcode.
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                ReplaceGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                SearchOriginalFile.Close()
                Exit Sub
            End If
        End With
        Dim MySlicer = FindSlicer(ImportFileName) 'find the slicer that created the gcode file so "layers #'s" can be found.
        SearchOriginalFile.Close()
        ReplaceGcodeFile.Close()
        Call SearchAndReplace(ImportFileName, Me.SaveFileDialog1.FileName)
    End Sub

    Private Sub SearchAndReplace(ImportFileName As String, SaveAsFile As String)
        On Error Resume Next
        PrResponse = False
        SearchAndReplaceForm.ShowDialog()
        If PrResponse = False Then Exit Sub
        Dim SearchOriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Dim ReplacementFile = My.Computer.FileSystem.OpenTextFileWriter(SaveAsFile, True)
        Dim DataLine As String
        Dim ExactMatch = SearchAndReplaceForm.ExactMatchOpt.Checked
        Dim SearchString = SearchAndReplaceForm.SearchStringBox.Text
        Dim ReplacementText = SearchAndReplaceForm.ReplaceStringBox.Text
        Dim LeaveString As Boolean = SearchAndReplaceForm.LeaveSearchChk.Checked
        DataLine = SearchOriginalFile.ReadLine
        Do Until InStr(DataLine, "generated") > 0
            ReplacementFile.WriteLine(DataLine)
            DataLine = SearchOriginalFile.ReadLine
        Loop
        ReplacementFile.WriteLine(DataLine)
        ReplacementFile.WriteLine(";POSTPROCESSED by Greg's Toolbox (Search and Replace")
        Do Until SearchOriginalFile.EndOfStream = True
            DataLine = SearchOriginalFile.ReadLine
            If InStr(DataLine, SearchString) > 0 Then
                If Not ExactMatch Then
                    If LeaveString Then
                        ReplacementFile.WriteLine(DataLine)
                        DataLine = ReplacementText 'Strings.Replace(DataLine, SearchString, ReplacementText, 1, -1)
                    Else
                        DataLine = Strings.Replace(DataLine, SearchString, ReplacementText, 1, -1)
                    End If
                ElseIf ExactMatch Then
                    If DataLine = SearchString And Strings.Len(DataLine) = Strings.Len(SearchString) Then
                        If LeaveString Then
                            ReplacementFile.WriteLine(DataLine)
                            DataLine = ReplacementText
                        Else
                            DataLine = ReplacementText
                        End If
                    End If
                End If
            End If
            ReplacementFile.WriteLine(DataLine)
        Loop
        SearchOriginalFile.Close()
        ReplacementFile.Close()
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("The file is complete.  Do you want to open it in NotePad?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim MyGcodeFile As String = Me.SaveFileDialog1.FileName
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

    Private Sub ChangeZHopHeightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeZHopHeightToolStripMenuItem.Click
        Dim AResponse = MsgBox("This will change Z-Hops in an existing GCODE file and create a new file.  You can change the Z-Hop height from certain layers.  You cannot add Z-Hops to a file that doesn't have them.  You can lower the Z-Hop height down to ""0""" & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim AlterZStartLayer = InputBox("Please enter the FIRST LAYER # to change Z-hops at. (NOTE: Layer numbering in gcode files starts at Layer:0).", "First Z-Hop Layer#", "0")
        If AlterZStartLayer = "" Then
            MsgBox("You must enter a Layer #.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim AlterZEndLayer = InputBox("Please enter the LAST LAYER # for Z-hop changes. (NOTE: Enter ""-1"" for All Layers).", "Last Z-Hop Layer#", "-1")
        If AlterZEndLayer = "" Then
            MsgBox("You must enter a Layer #.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        ElseIf Val(AlterZEndLayer) <> -1 Then
            If AlterZEndLayer <= AlterZStartLayer Then
                MsgBox("The END layer number must be greater than the START layer number.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
        End If
        AlterZEndLayer = CStr(CInt(AlterZEndLayer) + 1)
        Dim NewZHopHgt = InputBox("Please enter the New Z-Hop Height. (NOTE: Enter ""0"" for No Z-Hop).", "New Z-Hop Height", "0")
        If NewZHopHgt = "" Or Val(NewZHopHgt) < 0 Then
            MsgBox("You must enter a valid Z-Hop replacement height.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Me.PrResponse = True
        Dim ArResponse As MsgBoxResult
        Call Me.ZHOP_Change(CInt(AlterZStartLayer), CInt(AlterZEndLayer), CInt(NewZHopHgt))
        If Me.PrResponse = True Then
            ArResponse = MsgBox("The process is complete. Do you want to open the new file?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If ArResponse = vbYes Then
                Dim MyShell = Shell("notepad.exe " & Me.SaveFileDialog1.FileName, vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub ChangeRetractDistanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeRetractDistanceToolStripMenuItem.Click
        On Error Resume Next
        Dim AResponse = MsgBox("This will change all the RETRACTIONS in an existing GCODE file and create a new file.  Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Me.NewRetractionDistance = InputBox("Please enter the new Retraction Distance.", "Retraction Distance", "5.5")
        If Me.NewRetractionDistance = "" Then
            MsgBox("You must enter a retraction distance.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PostStr = ";POSTPROCESSED by Greg's Toolbox (Retract Distance Change to " & Me.NewRetractionDistance & " )"
        Call Me.FilamentDiameterChange(1, CSng(Me.NewRetractionDistance), PostStr)
    End Sub

    Private Sub ExtLength_TextChanged(sender As Object, e As EventArgs) Handles ExtLength.TextChanged
        With Me
            .Evalue.Text = Format((1 / ((((Val(My.Settings.FilamentDia) / 2) ^ 2) * Math.PI) / (Val(.LW.Text) * Val(.LH.Text)))) * Val(.ExtLength.Text), "0.00000")
        End With
    End Sub

    Private Sub FtoCbut_Click(sender As Object, e As EventArgs) Handles FtoCbut.Click
        With Me
            Try
                If InStr(1, .BarbFBox.Text, "°") = 0 Then
                    .BarbFBox.Text = Format((Val(BarbFBox.Text) - 32) / 1.8, "0.0") & " °C"
                Else
                    Dim MyString As String = Format(Strings.Left(.BarbFBox.Text, Len(.BarbFBox.Text) - 3))
                    MyString = CStr((CDbl(MyString) - 32) / 1.8)
                    .BarbFBox.Text = Format(CSng(MyString), "0.0") & " °C"
                End If
            Catch ex As Exception
            End Try
        End With
    End Sub

    Private Sub TimeToPauseBut_Click(sender As Object, e As EventArgs) Handles TimeToPauseBut.Click
        If PauseTimeForm.Lay0C.Text = "" Then
            If PrintStartTime Is Nothing And Me.DisableMovementBut.Checked = False Then
                PauseTimeForm.Lay0C.Text = CStr(Now)
                PauseTimeForm.InfoLab.Text = "Start Time = NOW()"
            Else
                PauseTimeForm.Lay0C.Text = CStr(PrintStartTime)
                PauseTimeForm.InfoLab.Text = "Start Time = Print Start Time"
            End If
        End If
        PauseTimeForm.Show()
        PauseTimeForm.BringToFront()
    End Sub

    Public Function LongFileName(ByVal short_name As String) As String
        Dim pos As Integer
        Dim result As String
        Dim long_name As String

        ' Start after the drive letter if any.
        If Strings.Mid$(short_name, 2, 1) = ":" Then
            result = Strings.Left$(short_name, 2)
            pos = 3
        Else
            result = ""
            pos = 1
        End If

        ' Consider each section in the file name.
        Do While pos > 0
            ' Find the next \.
            pos = InStr(pos + 1, short_name, "\")

            ' Get the next piece of the path.
            If pos = 0 Then
                long_name = Dir$(short_name, CType(vbNormal + vbHidden + vbSystem + vbDirectory, FileAttribute))
            Else
                long_name = Dir$(Strings.Left$(short_name, pos - 1), CType(vbNormal + vbHidden + vbSystem + vbDirectory, FileAttribute))
            End If
            result = result & "\" & long_name
        Loop

        LongFileName = result
    End Function

    Private Sub GetLongFileNameBut_Click(sender As Object, e As EventArgs) Handles GetLongFileNameBut.Click
        On Error Resume Next
        Dim backslashCount As Integer = 0
        Dim i As Integer = 1
        Dim AResponse As DialogResult
        Dim TheShortName As String = ""
        AResponse = Me.FolderBrowserDialog1.ShowDialog()
        If AResponse = 2 Then
            Exit Sub
        End If
        Me.LongNameListBox.Items.Clear()
        Me.LongToShortNameBox.Items.Clear()
        PathName = Me.FolderBrowserDialog1.SelectedPath
        For Each d As String In DirSearch(PathName)
            TheShortName = GetShortPrinterPath(d)
            TheShortName = Strings.Replace(TheShortName, "\", "/", 1, -1)
            d = Strings.Replace(d, "\", "/", 2, -1)
            If Strings.Right(d, 5) = "gcode" Then
                For i = 1 To Len(d)
                    If Mid$(d, i, 1) = "/" Then backslashCount += 1
                Next
                If backslashCount = 1 Then
                    Me.LongNameListBox.Items.Add(Strings.Right(d, Len(d) - 2))
                    Me.LongToShortNameBox.Items.Add("\" & Strings.Right(TheShortName, Len(TheShortName) - 3))
                    'Me.TextBox1.Text &= Strings.Right(d, Len(d) - 3) & vbCrLf
                ElseIf backslashCount > 1 Then
                    Me.LongNameListBox.Items.Add(Strings.Right(d, Len(d) - 2))
                    Me.LongToShortNameBox.Items.Add("\" & Strings.Right(TheShortName, Len(TheShortName) - 3))
                    'Me.TextBox1.Text &= Strings.Right(d, Len(d) - 2) & vbCrLf
                End If
                backslashCount = 0
            End If
        Next
        Me.LongNameListBox.Text = CStr(Me.LongNameListBox.Items.Item(0))
        Me.LongToShortNameBox.Text = CStr(Me.LongToShortNameBox.Items.Item(0))
        If Me.LongNameListBox.Text = "" Then
            Me.LongNameListBox.Text = "{None}"
            Me.LongToShortNameBox.Text = "{None}"
        End If
        If Me.LongNameListBox.Text <> "{None}" Then
            Me.EjectDriveBut.Text = "Eject Drive  " & PathName
            Me.EjectDriveBut.Enabled = True
        Else
            Me.EjectDriveBut.Text = "Eject Drive"
            Me.EjectDriveBut.Enabled = False
        End If
    End Sub

    Private Declare Function GetShortPathName Lib "kernel32" Alias "GetShortPathNameA" (ByVal lpszLongPath As String, ByVal lpszShortPath As String, ByVal lBuffer As Long) As Long
    Public Function GetShortPrinterPath(strFileName As String) As String
        Dim lngRes As Long, strPath As String
        strPath = Strings.StrDup(165, "0")
        lngRes = GetShortPathName(strFileName, strPath, 164)
        GetShortPrinterPath = Strings.Left(strPath, CInt(lngRes))
    End Function

    Private Const GENERIC_READ As UInteger = &H80000000UI
    Private Const GENERIC_WRITE As UInteger = &H40000000
    Private Const FILE_SHARE_READ As UInteger = &H1
    Private Const FILE_SHARE_WRITE As UInteger = &H2
    Private Const OPEN_EXISTING As Integer = &H3
    Private Const IOCTL_STORAGE_EJECT_MEDIA As UInteger = &H2D4808

    <DllImport("kernel32.dll")>
    Private Shared Function DeviceIoControl(ByVal deviceHandle As IntPtr, ByVal ioControlCode As UInteger, ByVal inBuffer As IntPtr, ByVal inBufferSize As Integer, ByVal outBuffer As IntPtr, ByVal outBufferSize As Integer, ByRef bytesReturned As Integer, ByVal overlapped As IntPtr) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CreateFileW")>
    Public Shared Function CreateFileW(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpFileName As String, ByVal dwDesiredAccess As UInteger, ByVal dwShareMode As UInteger, ByVal lpSecuritys As IntPtr, ByVal dwCreationDisposition As UInteger, ByVal dwFlagsAnds As UInteger, ByVal hTemplateFile As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As Integer
    End Function

    'driveletter can be passed to this sub with or without the ending backslash, like C: or C:\
    Private Sub SafelyEjectDrive(driveLetter As String)
        Dim DriveDevicePath As String = "\\.\" & If(driveLetter.EndsWith("\"), driveLetter.Remove(driveLetter.IndexOf("\")), driveLetter)
        Dim handle As IntPtr = CreateFileW(DriveDevicePath, GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
        Try
            If handle.ToInt32 = -1 Then Throw New ComponentModel.Win32Exception(Marshal.GetLastWin32Error)
        Catch
            Exit Sub
        End Try
        Dim ByteCount As Integer = 0
        Dim MyCloseCommand As Integer = DeviceIoControl(handle, IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0, IntPtr.Zero, 0, ByteCount, IntPtr.Zero)

        If MyCloseCommand = 1 Then
            MsgBox("It is safe to remove the {" & PathName & "} drive.", vbOKOnly, "Greg's Toolbox")
        End If
    End Sub

    Private Sub EjectDriveBut_Click(sender As Object, e As EventArgs) Handles EjectDriveBut.Click
        On Error Resume Next
        Dim DriveEjected As Boolean = False
        Dim DriveToEject As String = Strings.Left(CStr(PathName), 3)
        For Each MyDrive In System.IO.DriveInfo.GetDrives()

            If MyDrive.DriveType = IO.DriveType.Removable And MyDrive.Name = CStr(DriveToEject) Then
                SafelyEjectDrive(CStr(DriveToEject))
                DriveEjected = True
                Exit For
            End If
        Next MyDrive
        If DriveEjected = False Then
            MsgBox("Non-Removeable drives cannot be ejected", vbOKOnly, "Greg's Toolbox")
        End If

        Me.EjectDriveBut.Enabled = False
        Me.EjectDriveBut.Text = "Eject Drive"
    End Sub

    Private Sub FileListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileListBox.SelectedIndexChanged
        On Error Resume Next
        sender = Me.ToString
        Dim PName As String = ""
        Dim ShName As String = ""
        If Me.LongToShortNameBox.Items.Count > 0 Then
            For Each MyItem In Me.LongToShortNameBox.Items
                ShName = Strings.Right(MyItem.ToString, Len(MyItem) - 1)
                PName = Strings.Right(Me.FileListBox.SelectedItem.ToString, Len(Me.FileListBox.SelectedItem.ToString) - 1)
                If ShName = PName Then
                    Me.LongToShortNameBox.SelectedItem = MyItem.ToString
                End If
            Next
        End If
    End Sub

    Private Sub LongNameListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LongNameListBox.SelectedIndexChanged
        Dim TheName As String 'Me.LongToShortNameBox.SelectedIndex = TheIndex
        Try
            If sender.ToString = "FileListBox" Then
                TheName = Me.LongNameListBox.SelectedItem.ToString
                Me.LongToShortNameBox.SelectedIndex = Me.LongNameListBox.SelectedIndex
            Else
                Me.LongToShortNameBox.SelectedIndex = Me.LongNameListBox.SelectedIndex
            End If
        Catch ex As Exception
            MsgBox("Long Name.  The selected index doesn't match.", vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Private Sub LongtoshortNameBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LongToShortNameBox.SelectedIndexChanged
        Dim TheIndex = Me.LongToShortNameBox.SelectedIndex
        Dim TheName = Me.LongToShortNameBox.SelectedItem.ToString
        Try
            For Each ShFileName In Me.FileListBox.Items
                If ShFileName.ToString = TheName Then
                    Me.FileListBox.SelectedItem = ShFileName.ToString
                End If
            Next
            Me.LongNameListBox.SelectedIndex = TheIndex
        Catch ex As Exception
            MsgBox("Short Name.  The selected index doesn't match.", vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Private Sub HBVSendBut_Click(sender As Object, e As EventArgs) Handles HBVSendBut.Click
        On Error Resume Next
        If Me.Vcomm.IsOpen = False Then
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M141 S" & Me.HBVBox.Text
        SendTheString(StrToSend)
        StrToSend = "M117 BldVol Temp " & Me.HBVBox.Text
        SendTheString(StrToSend)
        StrToSend = "M118 BldVol Temp " & Me.HBVBox.Text
        SendTheString(StrToSend)
        StrToSend = ""
    End Sub

    Private Sub FontUpDn_ValueChanged(sender As Object, e As EventArgs) Handles FontUpDn.ValueChanged
        Dim GFont = New Font(Font.FontFamily, Me.FontUpDn.Value, FontStyle.Regular)
        Me.TextBox1.Font = GFont
    End Sub

    Private Function DirSearch(ByVal sDir As String) As List(Of String)
        Dim files As New List(Of String)()
        Try
            For Each f As String In IO.Directory.GetFiles(sDir)
                files.Add(f)
            Next
            If Me.SubFolderChkBox.Checked = True Then
                For Each d As String In IO.Directory.GetDirectories(sDir)
                    files.AddRange(DirSearch(d))
                Next
            End If
        Catch excpt As System.Exception
        End Try
        Return files
    End Function

    Private Sub AddTimeToPauseToGCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTimeToPauseToGCODEToolStripMenuItem.Click
        'On Error GoTo TheHandler
        Dim FileResponse As DialogResult ', GCODE_Filedelegate As [Delegate]
        Dim OriginalFile As System.IO.StreamReader
        Dim OutputFileName As String
        Dim TimeArray() As String
        Dim AlteredArray() As String
        Dim PauseArray(1, 0) As String
        Dim PauseCount As Integer = -1
        Dim ImportFileName As String
        Dim ExportFile As System.IO.StreamWriter
        Dim DataLine As String = ""
        Dim TotalPrintTime As String = ""
        Dim LayerCount As Integer = 0
        Dim AdjustETA As Double = 0.0
        Dim LayNum As String = "0"
        Dim MyFormat = "h:mm tt" '   M/d"
        Dim FudgeFactor As Single
        Dim PostProcessLine As String = "POSTPROCESSED by Greg's Toolbox (Countdown to Pauses)"
        With TimeToPauseFudgeForm
            .CuraHrBox.Text = ""
            .CuraMinBox.Text = ""
            .ActHrBox.Text = ""
            .ActMinBox.Text = ""
            .FudgeBar1.Value = 100
            .Label1.Text = "100%"
            FileResponse = .ShowDialog
        End With
        If FileResponse = 2 Then Exit Sub
        With Me
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
        With Me
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
        FudgeFactor = CSng(Val(TimeToPauseFudgeForm.Label1.Text) / 100)
        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Try
            Do Until InStr(DataLine, "LAYER:0") > 0
                DataLine = OriginalFile.ReadLine
                If InStr(DataLine, ";TIME:") > 0 Then
                    TotalPrintTime = CStr(Val(Strings.Right(DataLine, Len(DataLine) - 6)) * FudgeFactor)
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
                Try
                    DataLine = OriginalFile.ReadLine
                    If InStr(DataLine, ";TIME_ELAPSED:") > 0 Or InStr(DataLine, "transition") > 0 Then
                        TimeArray(LayerCounter) = CStr((Val(TotalPrintTime) - Val(Strings.Right(DataLine, Len(DataLine) - 14)) * FudgeFactor))
                        LayerCounter += 1
                    End If
                Catch
                    Exit Do
                End Try
            Loop
            OriginalFile.Close()
            OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
            'Count Pauses
            Do Until OriginalFile.EndOfStream = True
                DataLine = OriginalFile.ReadLine
                If InStr(DataLine, ";LAYER:") > 0 Then
                    LayNum = Strings.Right(DataLine, Len(DataLine) - 7)
                End If
                If InStr(DataLine, "Pauseatheight.py") > 0 Or InStr(DataLine, ";Transition Code") > 0 Then
                    PauseCount += 1
                    PauseArray(0, PauseCount) = TimeArray(CInt(LayNum))
                    PauseArray(1, PauseCount) = CStr(Val(LayNum))
                    PauseCount += 1
                    ReDim Preserve PauseArray(1, PauseCount)
                    PauseCount -= 1
                End If
            Loop
            If PauseCount >= 0 Then
                ReDim Preserve PauseArray(1, PauseCount)
            End If
            Dim PCounter As Integer
            Dim TempStartP1 As Double = CDbl(TotalPrintTime)
            Dim TempStartP2 As Double
            Dim MyCount As Integer
            Dim MyLayer As Integer = 0
            ReDim AlteredArray(LayerCount)
            TempStartP2 = CDbl(TotalPrintTime)
            AlteredArray(0) = "0"
            If PauseCount > -1 Then
                TempStartP1 = TempStartP2 - CDbl(PauseArray(0, 0))
                AlteredArray(0) = CStr(TempStartP1)
                For PCounter = 0 To PauseCount
                    For MyCount = MyLayer To CInt(PauseArray(1, PCounter))
                        AlteredArray(MyCount) = CStr(TempStartP1 - (TempStartP2 - CDbl(TimeArray(MyCount))))
                    Next
                    Try
                        TempStartP2 = CDbl(TimeArray(CInt(PauseArray(1, PCounter))))
                        TempStartP1 = TempStartP2 - CDbl(TimeArray(CInt(PauseArray(1, PCounter + 1))))
                        MyLayer = CInt(PauseArray(1, PCounter)) + 1
                    Catch
                        Exit For
                    End Try
                Next
                For anycount = MyCount To LayerCount - 1
                    AlteredArray(anycount) = TimeArray(anycount)
                Next
            Else
                For MyCount = 0 To LayerCount - 1
                    AlteredArray(MyCount) = TimeArray(MyCount)
                Next
            End If
            OriginalFile.Close()
            'first pause = TotalTime - time at pause
            'second pause = time first pause - time second pause
            'third pause = time second pause - time third pause
            'at last pause time = remaining time
            'Exit Sub
            OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
            ExportFile = My.Computer.FileSystem.OpenTextFileWriter(OutputFileName, True)
            DataLine = OriginalFile.ReadLine
            Do Until InStr(DataLine, "Generated") > 0
                ExportFile.WriteLine(DataLine)
                DataLine = OriginalFile.ReadLine
            Loop
            ExportFile.WriteLine(";POSTPROCESSED by Greg's Toolbox (Time to Pause / Time to End)")
            ExportFile.WriteLine(DataLine)
            DataLine = OriginalFile.ReadLine
            Do Until OriginalFile.EndOfStream = True
                If InStr(DataLine, ";LAYER:") > 0 Then
                    LayNum = Strings.Right(DataLine, Len(DataLine) - 7)
                    ExportFile.WriteLine(DataLine)
                    DataLine = OriginalFile.ReadLine
                    ExportFile.WriteLine(DataLine)
                    DataLine = OriginalFile.ReadLine
                    ExportFile.WriteLine(DataLine)
                    DataLine = OriginalFile.ReadLine
                    ExportFile.WriteLine(DataLine)
                    DataLine = "M117 " & Val(LayNum) + 1 & "/" & LayerCount & " | " & PauseTimeForm.ConvertTime(CStr(Val(AlteredArray(CInt(LayNum)))), CStr(0))
                    ExportFile.WriteLine(DataLine)
                    DataLine = "M118 Layer " & Val(LayNum) + 1 & " of " & LayerCount & " | ET " & PauseTimeForm.ConvertTime(CStr(Val(AlteredArray(CInt(LayNum)))), CStr(0))
                End If
                ExportFile.WriteLine(DataLine)
                DataLine = OriginalFile.ReadLine
            Loop
            ExportFile.Close()
            OriginalFile.Close()
            Dim ArResponse As MsgBoxResult
            ArResponse = MsgBox("Do you want to open the new Gcode file?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
            If ArResponse = vbYes Then
                System.Diagnostics.Process.Start("notepad.exe", OutputFileName)
            End If
            Exit Sub
        Catch
            MsgBox("There was an error in ""Mainform.AddTimeToPauseToGCODEToolStripMenuItem_Click""." & vbCr & vbCr & Err.Description, vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Private Sub ReadAll()
        Dim FileResponse As DialogResult ', GCODE_Filedelegate As [Delegate]
        Dim ImportFileName As String
        Dim OriginalFile As System.IO.StreamReader
        Dim OutPutFileName As String
        Dim NewFile As System.IO.StreamWriter
        Dim AllData As String
        Dim SplitData As String()
        With Me
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
        With Me
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
                OutPutFileName = .SaveFileDialog1.FileName
            Else
                Exit Sub
            End If
        End With
        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        NewFile = My.Computer.FileSystem.OpenTextFileWriter(OutPutFileName, True)
        Dim Count As Integer = 0
        Dim Count2 As Integer = 0
        AllData = OriginalFile.ReadToEnd
        SplitData = Strings.Split(AllData, vbNewLine, -1)
        AllData = ""
        For Each MyLine In SplitData
            If InStr(MyLine, ";LAYER:") > 0 Then
                MyLine = ";FUCKU:" & Count
                Count += 1
            End If
            AllData &= MyLine & vbNewLine
        Next
        'Dim CombinedData = Strings.Join(AllData, vbNewLine)

        NewFile.Write(AllData)
        NewFile.Close()
        OriginalFile.Close()
    End Sub

    Private Sub ReNumberLayersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReNumberLayersToolStripMenuItem.Click
        On Error GoTo TheHandler
        Dim FileResponse As DialogResult
        Dim OriginalFile As System.IO.StreamReader
        Dim OutputFileName As String
        Dim LayerIndex As Integer = 0
        Dim BarLoc As Integer = 0
        Dim PauseArray(1, 0) As String
        Dim ImportFileName As String
        Dim ExportFile As System.IO.StreamWriter
        Dim DataLine As String = ""
        Dim TotalPrintTime As String = ""
        Dim LayerCount As Integer = 0
        Dim AdjustETA As String = ""
        Dim LayStTime As Double = 0.0
        Dim LayEndTime As Double = 0.0
        Dim LayNum As String = "0"
        With Me
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
        With Me
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

ContinueOn:
        DataLine = OriginalFile.ReadLine
        Do Until InStr(DataLine, "Transition") > 0 Or InStr(DataLine, "End of gcode") > 0
            If InStr(DataLine, ";TIME_ELAPSED:") > 0 Then
                LayEndTime = CDbl(Strings.Right(DataLine, Len(DataLine) - 14))
            End If
            DataLine = OriginalFile.ReadLine
        Loop
        If InStr(DataLine, "End of gcode") = 0 Then
            TotalPrintTime = CStr(Val(TotalPrintTime) + (LayEndTime - LayStTime))
            LayStTime = LayEndTime
            GoTo ContinueOn
        End If
        OriginalFile.Close()
        Dim MyHours = Int(CDbl(TotalPrintTime) / 3600)
        Dim MyMinutes = Int((CDbl(TotalPrintTime) - (MyHours * 3600)) / 60)
        AdjustETA = "PrT:" & MyHours & "h" & MyMinutes & "m"
        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        DataLine = OriginalFile.ReadLine
        Do Until InStr(DataLine, "End of Gcode") > 0
            If InStr(DataLine, ";LAYER:") > 0 Then
                LayerCount += 1
            End If
            DataLine = OriginalFile.ReadLine
        Loop
        OriginalFile.Close()


        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        ExportFile = My.Computer.FileSystem.OpenTextFileWriter(OutputFileName, True)
        DataLine = OriginalFile.ReadLine
        Do Until InStr(DataLine, "End of Gcode") > 0
            If InStr(DataLine, ";LAYER_COUNT:") > 0 Then
                DataLine = ";LAYER_COUNT:" & LayerCount
            End If
            If InStr(DataLine, ";LAYER:") > 0 Then
                DataLine = ";LAYER:" & LayerIndex
                LayerIndex += 1
            End If
            If InStr(DataLine, "M117") > 0 Then
                BarLoc = InStr(DataLine, "|")
                DataLine = Strings.Right(DataLine, Len(DataLine) - BarLoc)
                DataLine = "M117 " & LayerIndex & "/" & LayerCount & " | " & AdjustETA
            End If
            If InStr(DataLine, "M118") > 0 Then
                BarLoc = InStr(DataLine, "|")
                DataLine = Strings.Right(DataLine, Len(DataLine) - BarLoc)
                DataLine = "M118 " & LayerIndex & "/" & LayerCount & " | " & AdjustETA
            End If
            ExportFile.WriteLine(DataLine)
            DataLine = OriginalFile.ReadLine
        Loop
        Do Until OriginalFile.EndOfStream = True
            ExportFile.WriteLine(DataLine)
            DataLine = OriginalFile.ReadLine
        Loop
        ExportFile.WriteLine(DataLine)
        OriginalFile.Close()
        ExportFile.Close()
        Exit Sub
TheHandler:
        MsgBox("There was an error in ""Mainform.ReNumberLayersToolStripMenuItem_Click""." & vbCr & Err.Description, vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub HBVDownBut_Click(sender As Object, e As EventArgs) Handles HBVDownBut.Click
        Me.HBVBox.Text = CStr(Val(HBVBox.Text) - 5)
        If Val(Me.HBVBox.Text) < 15 Then Me.HBVBox.Text = "15"
    End Sub

    Private Sub HBVUpBut_Click(sender As Object, e As EventArgs) Handles HBVUpBut.Click
        Me.HBVBox.Text = CStr(Val(HBVBox.Text) + 5)
        If Val(Me.HBVBox.Text) > 100 Then Me.HBVBox.Text = "100"
    End Sub

    Private Sub UploadToSDBut_Click(sender As Object, e As EventArgs) Handles UploadToSDBut.Click
        On Error Resume Next
        Dim FileResponse As DialogResult
        Dim ImportFileName As String
        Dim OriginalFile As System.IO.StreamReader
        Dim Dataline As String
        Dim ShortFileName As String = ""
        Dim SlashLocation As Integer
        With Me
            .OpenFileDialog1.Title = "Open a GCODE file To Upload"
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
        ShortFileName = ImportFileName
        Do Until InStr(ShortFileName, "\") = 0
            SlashLocation = InStr(ShortFileName, "\")
            If SlashLocation > 0 Then
                ShortFileName = Strings.Right(ShortFileName, Len(ShortFileName) - SlashLocation)
            End If
        Loop
        Dim FileToUpload As String = FileOnFileForm.GetShortPath(ImportFileName)
        SendTheString("M28 " & FileToUpload)
        Threading.Thread.Sleep(1000)
        OriginalFile = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)

        'Dim StorageString As String

        'fill a string with the file contents
        'note the encoding parameter
        'Dim myReader As New System.IO.StreamReader("c:\test.jpg", System.Text.Encoding.Default)
        'StorageString = myReader.ReadToEnd
        'myReader.Close()

        Do Until OriginalFile.EndOfStream = True
            Dataline = OriginalFile.ReadLine
            If Strings.Left(Dataline, 1) <> ";" Then
                SendTheString(Dataline)
                Threading.Thread.Sleep(10)
            End If
        Loop
        SendTheString("M29")
        OriginalFile.Close()
    End Sub

    Private Sub SubFolderChkBox_CheckedChanged(sender As Object, e As EventArgs) Handles SubFolderChkBox.CheckedChanged
        Me.PrinterSubFolderCheckBox.Checked = Me.SubFolderChkBox.Checked
    End Sub

    Private Sub PrinterSubFolderCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PrinterSubFolderCheckBox.CheckedChanged
        Me.SubFolderChkBox.Checked = Me.PrinterSubFolderCheckBox.Checked
    End Sub

    Private Sub ActivateCuraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateCuraToolStripMenuItem.Click
        If My.Settings.CuraVersion <> "" And Len(Me.ShowCuraToolStripMenuItem.Text) = 9 Then
            Me.ShowCuraToolStripMenuItem.Text = Me.ShowCuraToolStripMenuItem.Text & " - " & My.Settings.CuraVersion
        End If
    End Sub

    Private Sub ShowCuraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowCuraToolStripMenuItem.Click
        On Error Resume Next
        If My.Settings.CuraExeName = "" Or My.Settings.CuraPath = "" Then
            Call SetCuraLocationVersionToolStripMenuItem_Click(sender, e)
        End If
        Dim PName = ""
        If My.Settings.CuraExeName = "Cura.exe" Then
            PName = "Cura"
        Else
            PName = "Ultimaker-Cura"
        End If
        Err.Clear()
        If IsRunningExe(PName) Then
            AppActivate(CuraTitleBarInfo)
            ShowAppWindow(PName)
            If Err.Number <> 0 Then
                System.Diagnostics.Process.Start(My.Settings.CuraPath)
                Err.Clear()
            End If
            Call SillyShit()
            Exit Sub
        End If
        System.Diagnostics.Process.Start(My.Settings.CuraPath)
        Call SillyShit()
    End Sub

    Private Declare Function ShowWindow Lib "user32" (ByVal handle As IntPtr, ByVal nCmdShow As Integer) As Integer
    Sub ShowAppWindow(TitleBarInfo As String)
        Try
            Dim localByName As Process() = Process.GetProcessesByName(TitleBarInfo)
            For Each p As Process In localByName
                ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                Dim MyText As String = "Ultimaker Cura"
                If Len(p.MainWindowTitle) = 14 And InStr(p.MainWindowTitle, "Greg's") = 0 Then
                    MyText = p.MainWindowTitle & " - Greg's Toolbox"
                ElseIf Len(p.MainWindowTitle) > 14 And InStr(p.MainWindowTitle, "Greg's") = 0 Then
                    MyText = p.MainWindowTitle & " - Greg's Toolbox"
                Else
                    MyText = p.MainWindowTitle
                End If
                SetWindowText(p.MainWindowHandle, MyText)
                CuraTitleBarInfo = p.MainWindowTitle
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetCuraLocationVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetCuraLocationVersionToolStripMenuItem.Click
        On Error Resume Next
        Dim CuraPath As String
        Dim CuraExeName As String = ""
        Dim CuraVersion As String = ""
        MsgBox("Select the Cura folder/version you want to use.", vbOKOnly, "Greg's Toolbox")
        FolderBrowserDialog1.ShowDialog()
        CuraPath = Me.FolderBrowserDialog1.SelectedPath

        If CuraPath = "" Then Exit Sub
        If InStr(CuraPath, "5.") > 0 Then
            CuraExeName = "Ultimaker-Cura.exe"
        Else
            CuraExeName = "Cura.exe"
        End If
        Dim UltiLoc As Integer = InStr(CuraPath, "Ultimaker Cura")

        If UltiLoc > 0 Then
            CuraVersion = Strings.Right(CuraPath, Len(CuraPath) - UltiLoc - 14)
            ShowCuraToolStripMenuItem.Text = "Show Cura " & CuraVersion
            My.Settings.CuraVersion = CuraVersion
        End If
        CuraPath = CuraPath & "\" & CuraExeName
        'Do Until InStr(CuraExeName, "\") = 0
        'CuraExeName = Strings.Right(CuraExeName, Len(CuraExeName) - InStr(CuraExeName, "\"))
        'Loop
        My.Settings.CuraPath = CuraPath
        My.Settings.CuraExeName = CuraExeName
        'Call SillyShit()
    End Sub

    Declare Auto Function SetWindowText Lib "user32" (ByVal hWnd As IntPtr, ByVal lpstring As String) As Boolean
    Private Sub SillyShit()
        On Error Resume Next
        Dim proclist() As Process = Process.GetProcessesByName("Ultimaker-Cura")
        If proclist.Length = 0 Then
            proclist = Process.GetProcessesByName("Cura")
        End If
        If proclist.Length = 0 Then
            MsgBox("No process was found for Cura.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim p As Process = Nothing
        Dim hWnd As Integer
        System.Threading.Thread.Sleep(3000)
        For Each p In proclist
            hWnd = CInt(p.MainWindowHandle)
        Next
        Dim MyText As String = "Ultimaker Cura"
        If Len(p.MainWindowTitle) = 14 And InStr(p.MainWindowTitle, "Greg's") = 0 Then
            MyText = p.MainWindowTitle & " - Greg's Toolbox"
        ElseIf Len(p.MainWindowTitle) > 14 And InStr(p.MainWindowTitle, "Greg's") > 0 Then
            MyText = p.MainWindowTitle
        End If
        SetWindowText(p.MainWindowHandle, MyText)
        CuraTitleBarInfo = p.MainWindowTitle
    End Sub

    Private Sub AutoLinkBut_CheckedChanged(sender As Object, e As EventArgs) Handles AutoLinkBut.CheckedChanged
        If Me.AutoLinkBut.Checked = True Then
            Me.Label59.Visible = True
            Me.Label60.Visible = True
            Me.ProfileLabel.Visible = True
            Me.LinkPrinterAndProfile.Visible = True
            Me.PrinterNameBox.Visible = True
        Else
            Me.Label59.Visible = False
            Me.Label60.Visible = False
            Me.ProfileLabel.Visible = False
            Me.LinkPrinterAndProfile.Visible = False
            Me.PrinterNameBox.Visible = False
        End If
    End Sub
    Private Sub ChangeForeColors()
        If My.Settings.WhatColor = "Dark" Then
            For Each CtrlPanel As Control In Me.Controls
                If TypeOf CtrlPanel Is Label Then
                    Dim myLabel As Label = DirectCast(CtrlPanel, Label)
                    myLabel.ForeColor = Color.White
                End If
                If TypeOf CtrlPanel Is Panel Then
                    For Each CtrlLabel As Control In CtrlPanel.Controls
                        If TypeOf CtrlLabel Is Label Then
                            If InStr(CtrlLabel.Name, "Banner") = 0 Then
                                CtrlLabel.ForeColor = Color.White
                            End If
                        End If
                    Next
                End If
            Next
            Me.PreHeatSyncBox.ForeColor = Color.White
            Me.SubFolderChkBox.ForeColor = Color.White
            Me.PrinterSubFolderCheckBox.ForeColor = Color.White
            Me.GroupBox14.ForeColor = Color.White
            PrinterSettings.Label1.ForeColor = Color.White
        Else
            For Each CtrlPanel As Control In Me.Controls
                If TypeOf CtrlPanel Is Label Then
                    Dim myLabel As Label = DirectCast(CtrlPanel, Label)
                    myLabel.ForeColor = Color.Black
                End If
                If TypeOf CtrlPanel Is Panel Then
                    For Each CtrlLabel As Control In CtrlPanel.Controls
                        If TypeOf CtrlLabel Is Label Then
                            If InStr(CtrlLabel.Name, "Banner") = 0 Then
                                CtrlLabel.ForeColor = Color.Black
                            End If
                        End If
                    Next
                End If
            Next
            Me.PreHeatSyncBox.ForeColor = Color.Black
            Me.SubFolderChkBox.ForeColor = Color.Black
            Me.PrinterSubFolderCheckBox.ForeColor = Color.Black
            Me.GroupBox14.ForeColor = Color.Black
            PrinterSettings.Label1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub EmulateAMultiExtruderPrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmulateAMultiExtruderPrinterToolStripMenuItem.Click
        Dim ExtruderCount As Integer = 2
        Dim M84Line As String = ""
        Dim PauseCommand As String = ""
        Dim ExtMode As String = ""
        Dim ParkHead As Boolean = True
        Dim ParkHeadX As String = "0"
        Dim ParkHeadY As String = "0"
        Dim ParkString As String = ""
        Dim AddM117Line As Boolean = False
        Dim T0message As String = ""
        Dim T1message As String = ""
        Dim T2message As String = ""
        Dim T3message As String = ""
        Dim Dataline As String = ""
        Dim OriginalFileName As String = ""
        Dim OriginalGcodeFile As System.IO.StreamReader
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim T0ReplacementCommandString As String = ""
        Dim T1ReplacementCommandString As String = ""
        Dim T2ReplacementCommandString As String = ""
        Dim T3ReplacementCommandString As String = ""
        Dim GcodeAfterString As String = ""
        Dim ToolStr As String = ""
        Dim T0Loc As Integer = 0
        Dim T0Length As Integer = 0
        Dim T1Loc As Integer = 0
        Dim T1Length As Integer = 0
        Dim T2Loc As Integer = 0
        Dim T2Length As Integer = 0
        Dim T3Loc As Integer = 0
        Dim T3Length As Integer = 0
        Dim T0PrintTemp As String = "0"
        Dim T1PrintTemp As String = "0"
        Dim T2PrintTemp As String = "0"
        Dim T3PrintTemp As String = "0"
        Dim ChangeTemperature As Boolean = False

        PrResponse = False
        With EmulateMultiExtruder
            .ShowDialog()
            If PrResponse = False Then Exit Sub
            If .T1But.Checked = True Then ExtruderCount = 2
            If .T2But.Checked = True Then ExtruderCount = 3
            If .T3But.Checked = True Then ExtruderCount = 4
            If .TimeOutBox.Text <> "" Then
                M84Line = "M84 S" & Val(.TimeOutBox.Text) * 60
            End If
            PauseCommand = .PauseCmdBox.Text
            If .M82OptBut.Checked Then
                ExtMode = "M82"
            Else
                ExtMode = "M83"
            End If
            ParkHead = .ParkHeadChk.Checked
            ParkHeadX = .ParkHeadXbox.Text
            ParkHeadY = .ParkHeadYbox.Text
            If ParkHead Then
                ParkString = "G0 X" & ParkHeadX & " Y" & ParkHeadY & " F7200 ;Move to park position"
            End If
            If .T0MessageBox.Text <> "" Then
                T0message = "M117 " & .T0MessageBox.Text & " ;send to LCD" & vbCr & "M118 " & .T0MessageBox.Text & " ;send to print server"
            End If
            If .T1MessageBox.Text <> "" Then
                T1message = "M117 " & .T1MessageBox.Text & " ;send To LCD" & vbCr & "M118 " & .T1MessageBox.Text & " ;send to print server"
            End If
            If .T2MessageBox.Text <> "" Then
                T2message = "M117 " & .T2MessageBox.Text & " ;send to LCD" & vbCr & "M118 " & .T2MessageBox.Text & " ;send to print server"
            End If
            If .T3MessageBox.Text <> "" Then
                T3message = "M117 " & .T3MessageBox.Text & " ;send to LCD" & vbCr & "M118 " & .T3MessageBox.Text & " ;send to print server"
            End If
            If .GcodeAfterBox.Text <> "" Then
                GcodeAfterString = Strings.Replace(.GcodeAfterBox.Text, ",", vbCr, 1, -1)
                GcodeAfterString = Strings.UCase(GcodeAfterString)
            End If
            T0PrintTemp = .E1PrintTemp.Text
            T1PrintTemp = .E2PrintTemp.Text
            T2printtemp = .E3PrintTemp.Text
            T3PrintTemp = .E4PrintTemp.Text
            If .T1But.Checked = True Then
                If Val(.E1PrintTemp.Text) = Val(.E2PrintTemp.Text) Then ' And Val(.E2PrintTemp.Text) = Val(.E3PrintTemp.Text) And Val(.E3PrintTemp.Text) = Val(.E4PrintTemp.Text) Then
                    ChangeTemperature = False
                Else
                    ChangeTemperature = True
                End If
            ElseIf .T2But.Checked = True Then
                If Val(.E1PrintTemp.Text) = Val(.E2PrintTemp.Text) And Val(.E2PrintTemp.Text) = Val(.E3PrintTemp.Text) Then 'And Val(.E3PrintTemp.Text) = Val(.E4PrintTemp.Text) Then
                    ChangeTemperature = False
                Else
                    ChangeTemperature = True
                End If
            ElseIf .T3But.Checked = True Then
                If Val(.E1PrintTemp.Text) = Val(.E2PrintTemp.Text) And Val(.E2PrintTemp.Text) = Val(.E3PrintTemp.Text) And Val(.E3PrintTemp.Text) = Val(.E4PrintTemp.Text) Then
                    ChangeTemperature = False
                Else
                    ChangeTemperature = True
                End If
            End If
        End With
        ' find and open the original file
        With Me.OpenFileDialog1
            .Title = "Open your Original GCODE file"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            .FileName = ""
            Dim FileResponse = .ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
            If FileResponse = 2 Then
                Exit Sub
            End If
            OriginalFileName = .FileName
        End With
        ' create, save, open the new file
        With Me
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
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                PrResponse = False
                Exit Sub
            End If
        End With
        OriginalGcodeFile = My.Computer.FileSystem.OpenTextFileReader(OriginalFileName)

        T0ReplacementCommandString = ";" & vbCr &
            ";T0 Tool Change replacement code" & vbCr &
            M84Line & ";Stepper timeout" & vbCr &
            "G91 ;Relative positioning" & vbCr &
            "M83 ;Relative extrusion" & vbCr
        If EmulateMultiExtruder.AddRetractChk.Checked = True Then T0ReplacementCommandString &= "G1 F2100 E-" & EmulateMultiExtruder.AddRetractAmountBox.Text & "    ;Retraction" & vbCr
        T0ReplacementCommandString &= "G1 Z10 ;Move Up" & vbCr &
            "G90 ;Absolute movement" & vbCr &
            ParkString & vbCr
        If EmulateMultiExtruder.AddM117MsgChk.Checked Then T0ReplacementCommandString &= T0message & vbCr
        If EmulateMultiExtruder.BeepBox.Checked Then T0ReplacementCommandString &= "M300 ;Beep" & vbCr
        If ChangeTemperature Then
            T0ReplacementCommandString &= "M118 Wait for temperature change" & vbCr &
                "M109 R" & T0PrintTemp & vbCr
        End If
        T0ReplacementCommandString &= PauseCommand & vbCr
        If GcodeAfterString <> "" Then T0ReplacementCommandString &= GcodeAfterString & vbCr
        T0ReplacementCommandString &= ";G0 F7200 X Y ;""Return to"" XY location (If required).  It's the last XY location before the pause." & vbCr &
            ";G1 F600 Z  ;""Return to"" Z location (if required).  It Is the last Z location before the pause." & vbCr &
            ExtMode & " ;Reset extrusion mode (absolute Or relative)" & vbCr &
            ";End of Tool Change code" & vbCr &
            ";"

        T1ReplacementCommandString = ";" & vbCr &
            ";T1 Tool Change replacement code" & vbCr &
            M84Line & ";Stepper timeout" & vbCr &
            "G91 ;Relative positioning" & vbCr &
            "M83 ;Relative extrusion" & vbCr
        If EmulateMultiExtruder.AddRetractChk.Checked = True Then T1ReplacementCommandString &= "G1 F2100 E-" & EmulateMultiExtruder.AddRetractAmountBox.Text & "    ;Retraction" & vbCr
        T1ReplacementCommandString &= "G1 Z10 ;Move Up" & vbCr &
            "G90 ;Absolute movement" & vbCr &
            ParkString & vbCr
        If EmulateMultiExtruder.AddM117MsgChk.Checked Then T1ReplacementCommandString &= T1message & vbCr
        If EmulateMultiExtruder.BeepBox.Checked Then T1ReplacementCommandString &= "M300 ;Beep" & vbCr
        If ChangeTemperature Then
            T1ReplacementCommandString &= "M118 Wait for temperature change" & vbCr &
                "M109 R" & T1PrintTemp & vbCr
        End If
        T1ReplacementCommandString &= PauseCommand & vbCr
        If GcodeAfterString <> "" Then T1ReplacementCommandString &= GcodeAfterString & vbCr
        T1ReplacementCommandString &= ";G0 F7200 X Y ;""Return to"" XY location (If required).  It's the last XY location before the pause." & vbCr &
            ";G1 F600 Z  ;""Return to"" Z location (if required).  It Is the last Z location before the pause." & vbCr &
            ExtMode & " ;Reset extrusion mode (absolute Or relative)" & vbCr &
            ";End of Tool Change code" & vbCr &
            ";"

        T2ReplacementCommandString = ";" & vbCr &
            ";T2 Tool Change replacement code" & vbCr &
            M84Line & ";Stepper timeout" & vbCr &
            "G91 ;Relative positioning" & vbCr &
            "M83 ;Relative extrusion" & vbCr
        If EmulateMultiExtruder.AddRetractChk.Checked = True Then T2ReplacementCommandString &= "G1 F2100 E-" & EmulateMultiExtruder.AddRetractAmountBox.Text & "    ;Retraction" & vbCr
        T2ReplacementCommandString &= "G1 Z10 ;Move Up" & vbCr &
            "G90 ;Absolute movement" & vbCr &
            ParkString & vbCr
        If EmulateMultiExtruder.AddM117MsgChk.Checked Then T2ReplacementCommandString &= T2message & vbCr
        If EmulateMultiExtruder.BeepBox.Checked Then T2ReplacementCommandString &= "M300 ;Beep" & vbCr
        If ChangeTemperature Then
            T2ReplacementCommandString &= "M118 Wait for temperature change" & vbCr &
                "M109 R" & T2PrintTemp & vbCr
        End If
        T2ReplacementCommandString &= PauseCommand & vbCr
        If GcodeAfterString <> "" Then T2ReplacementCommandString &= GcodeAfterString & vbCr
        T2ReplacementCommandString &= ";G0 F7200 X Y ;""Return to"" XY location (If required).  It's the last XY location before the pause." & vbCr &
            ";G1 F600 Z  ;""Return to"" Z location (if required).  It Is the last Z location before the pause." & vbCr &
            ExtMode & " ;Reset extrusion mode (absolute Or relative)" & vbCr &
            ";End of Tool Change code" & vbCr &
            ";"

        T3ReplacementCommandString = ";" & vbCr &
            ";T3 Tool Change replacement code" & vbCr &
            M84Line & ";Stepper timeout" & vbCr &
            "G91 ;Relative positioning" & vbCr &
            "M83 ;Relative extrusion" & vbCr
        If EmulateMultiExtruder.AddRetractChk.Checked = True Then T3ReplacementCommandString &= "G1 F2100 E-" & EmulateMultiExtruder.AddRetractAmountBox.Text & "    ;Retraction" & vbCr
        T3ReplacementCommandString &= "G1 Z10 ;Move Up" & vbCr &
            "G90 ;Absolute movement" & vbCr &
            ParkString & vbCr
        If EmulateMultiExtruder.AddM117MsgChk.Checked Then T3ReplacementCommandString &= T3message & vbCr
        If EmulateMultiExtruder.BeepBox.Checked Then T3ReplacementCommandString &= "M300 ;Beep" & vbCr
        If ChangeTemperature Then
            T3ReplacementCommandString &= "M118 Wait for temperature change" & vbCr &
                "M109 R" & T3PrintTemp & vbCr
        End If
        T3ReplacementCommandString &= PauseCommand & vbCr
        If GcodeAfterString <> "" Then T3ReplacementCommandString &= GcodeAfterString & vbCr
        T3ReplacementCommandString &= ";G0 F7200 X Y ;""Return to"" XY location (If required).  It's the last XY location before the pause." & vbCr &
            ";G1 F600 Z  ;""Return to"" Z location (if required).  It Is the last Z location before the pause." & vbCr &
            ExtMode & " ;Reset extrusion mode (absolute Or relative)" & vbCr &
            ";End of Tool Change code" & vbCr &
            ";"

        Dataline = OriginalGcodeFile.ReadLine
        Do Until InStr(Dataline, "Generated with") > 0
            NewGcodeFile.WriteLine(Dataline)
            Dataline = OriginalGcodeFile.ReadLine
        Loop
        NewGcodeFile.WriteLine(Dataline)
        NewGcodeFile.WriteLine(";POSTPROCESSED by Greg's Toolbox (Emulate Multi-Extruder)")
        Dataline = OriginalGcodeFile.ReadLine
        Do Until InStr(Dataline, ";LAYER:0") > 0
            NewGcodeFile.WriteLine(Dataline)
            Dataline = OriginalGcodeFile.ReadLine
        Loop
        Do Until OriginalGcodeFile.EndOfStream = True
            ToolStr = Strings.Left(Dataline, 2)
            If ToolStr = "T0" And Len(Dataline) = 2 Then
                Dataline = T0ReplacementCommandString
            ElseIf InStr(Dataline, "T1") > 0 And Len(Dataline) = 2 Then
                Dataline = T1ReplacementCommandString
            ElseIf InStr(Dataline, "T2") > 0 And Len(Dataline) = 2 Then
                Dataline = T2ReplacementCommandString
            ElseIf InStr(Dataline, "T3") > 0 And Len(Dataline) = 2 Then
                Dataline = T3ReplacementCommandString
            End If
            If InStr(Dataline, " T0") > 0 And Strings.Left(Dataline, 1) = "M" Then
                Dataline = ";" & Dataline
            End If
            If Strings.Left(Dataline, 4) = "M104" Or Strings.Left(Dataline, 4) = "M109" Then
                Dataline = ";" & Dataline
            End If
            If InStr(Dataline, "End of gcode") > 0 Then
                NewGcodeFile.WriteLine("M104 S0")
            End If
            NewGcodeFile.WriteLine(Dataline)
            Dataline = OriginalGcodeFile.ReadLine
        Loop
        OriginalGcodeFile.Close()
        NewGcodeFile.Close()
        Dim Aresponse = MsgBox("The new file is complete.  Do you want to open the new file in NotePad?", CType(vbYesNo + vbQuestion, MsgBoxStyle))
        If Aresponse = vbYes Then
            System.Diagnostics.Process.Start("notepad.exe", Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub ConvertBlackBeltToCartesianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertBlackBeltToCartesianToolStripMenuItem.Click
        Dim Aresponse = MsgBox("This will swap all the ""Y"" parameters to ""Z"" parameters and vice versa.  You will need to supply a proper StatUp Gcode." & vbCr &
                               "Do you wish to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If Aresponse = vbNo Then Exit Sub
        Call FormsModule.ConvertBlackbelt()
    End Sub

    Private Sub FirstLayerWallsFirstToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirstLayerWallsFirstToolStripMenuItem.Click
        On Error GoTo EHandler
        Dim MyErrorText As String = "At The Start of opening files."
        Dim WallDataLine As String = ""
        Dim WallDataArray() As String
        Dim SkinDataLine As String = ""
        Dim SkinDataArray() As String
        Dim OriginalFileName As String = ""
        Dim OriginalGcodeFile As System.IO.StreamReader
        Dim WallsFileName As String
        Dim WallsFile As System.IO.StreamReader
        Dim SkinsFileName As String
        Dim SkinsFile As System.IO.StreamReader
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim MyResponse As MsgBoxResult = MsgBox("You need three files and all three MUST be sliced in Relative Extrusion mode:" & vbCr &
               "The ""Main"" file that will comprise layers 1 to the top layer will be opened first." & vbCr & "The ""Walls"" file (Walls, Skirt/Brim, No infill, No Skins) that will become part of layer 0 will be opened second." & vbCr &
               "The ""Skins"" file (Skins, No Walls, No Skirt/Brim, Init Layer Hori. Expan. = (WallCount * LineWidth) * -1) that will become the second part of Layer 0 will be opened third." & vbCr & "Finally you will be asked for the ""SaveAs"" file name that will be the combined file to print.", vbYesNo, "Greg's Toolbox - Re-order Layer 0")
        If MyResponse = vbNo Then Exit Sub

        With Me.OpenFileDialog1
            .Title = "Open your MAIN gcode file"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            .FileName = ""
            Dim FileResponse = .ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
            If FileResponse = 2 Then
                Exit Sub
            End If
            OriginalFileName = .FileName
        End With
        With Me.OpenFileDialog1
            .Title = "Open your WALLS gcode file"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            .FileName = ""
            Dim FileResponse = .ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
            If FileResponse = 2 Then
                Exit Sub
            End If
            WallsFileName = .FileName
        End With
        With Me.OpenFileDialog1
            .Title = "Open your SKINS gcode file"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            .FileName = ""
            Dim FileResponse = .ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
            If FileResponse = 2 Then
                Exit Sub
            End If
            SkinsFileName = .FileName
        End With
        ' create, save, open the new file
        With Me
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
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                PrResponse = False
                Exit Sub
            End If
        End With
        OriginalGcodeFile = My.Computer.FileSystem.OpenTextFileReader(OriginalFileName)
        WallsFile = My.Computer.FileSystem.OpenTextFileReader(WallsFileName)
        SkinsFile = My.Computer.FileSystem.OpenTextFileReader(SkinsFileName)

        MyErrorText = "Before the Original File StartUp Writes"
        'Start Write
        Me.TextBox1.Text &= vbCrLf & "Starting to Write - Startup Gcode"
        Dim Dataline As String = OriginalGcodeFile.ReadLine
        Do Until InStr(Dataline, ";LAYER:0") > 0
            NewGcodeFile.WriteLine(Dataline)
            Dataline = OriginalGcodeFile.ReadLine
        Loop
        NewGcodeFile.WriteLine(Dataline)
        Dataline = ""

        MyErrorText = "Before the Walls portion Writes"
        'Walls File
        Me.TextBox1.Text &= vbCrLf & "Writing the LAYER:0 Walls..."
        Me.Refresh()
        Dataline = WallsFile.ReadLine
        Do Until InStr(Dataline, ";LAYER:0") > 0
            Dataline = WallsFile.ReadLine
        Loop
        Dataline = WallsFile.ReadLine
        Dim LineCount As Integer = 1
        WallDataLine = WallsFile.ReadLine & vbNewLine
        Do Until InStr(WallDataLine, ";LAYER:1") > 0
            WallDataLine &= WallsFile.ReadLine & vbNewLine
            LineCount += 1
        Loop
        WallDataArray = Strings.Split(WallDataLine, vbNewLine)
        Dim N = 0
        For N = LineCount To 0 Step -1
            If InStr(WallDataArray(N), "NONMESH") > 0 Then
                Exit For
            End If
        Next
        ReDim Preserve WallDataArray(N)
        For Each WallDataLine In WallDataArray
            NewGcodeFile.WriteLine(WallDataLine)
        Next

        MyErrorText = "Before the Skins portion Writes"
        'Skins File
        Me.TextBox1.Text &= vbCrLf & "Writing the LAYER:0 Skins..."
        Me.Refresh()
        LineCount = 0
        Do Until InStr(Dataline, ";LAYER:0") > 0
            Dataline = SkinsFile.ReadLine
        Loop
        Dataline = SkinsFile.ReadLine
        Dataline = ""
        Do Until InStr(SkinDataLine, ";LAYER:1") > 0
            If InStr(SkinDataLine, "SKIRT") > 0 Or InStr(SkinDataLine, "BRIM") > 0 Then
                Strings.Replace(SkinDataLine, ";TYPE:SKIRT" & vbNewLine, "", Len(SkinDataLine) - 20, 1)
                Do Until InStr(Dataline, ";") > 0
                    Dataline = SkinsFile.ReadLine
                Loop
                'SkinDataLine &= Dataline & vbNewLine
            End If
            SkinDataLine &= SkinsFile.ReadLine & vbNewLine
            LineCount += 1
        Loop
        'LineCount -= 1
        SkinDataArray = Strings.Split(SkinDataLine, vbNewLine)
        For N = LineCount - 1 To 0 Step -1
            If InStr(SkinDataArray(N), "NONMESH") > 0 Then
                Exit For
            End If
        Next
        ReDim Preserve SkinDataArray(N)
        For Each SkinDataLine In SkinDataArray
            NewGcodeFile.WriteLine(SkinDataLine)
        Next
        Dataline = ""
        LineCount = 0
        Me.TextBox1.Text &= vbCrLf & ";LAYER:1"
        Me.Refresh()

        MyErrorText = "Before the Original File completes Writing"
        'Finish original file
        Do Until InStr(Dataline, ";LAYER:1") > 0
            Dataline &= OriginalGcodeFile.ReadLine & vbNewLine
            LineCount += 1
        Loop
        Dim DataLineArray = Strings.Split(Dataline, vbNewLine)
        For N = LineCount - 1 To 0 Step -1
            If InStr(DataLineArray(N), "NONMESH") > 0 Then
                Exit For
            End If
        Next
        Dim M = 0
        For M = N + 1 To UBound(DataLineArray)
            NewGcodeFile.WriteLine(DataLineArray(M))
        Next
        Dataline = OriginalGcodeFile.ReadLine
        MyErrorText = "After Layer 1 was written"
        Do Until OriginalGcodeFile.EndOfStream = True
            NewGcodeFile.WriteLine(Dataline)
            Dataline = OriginalGcodeFile.ReadLine
            If InStr(Dataline, ";LAYER:") > 0 Then
                With Me.TextBox1
                    .Text += vbCrLf & Dataline
                    .Select(.Text.Length, .Text.Length)
                    .ScrollToCaret()
                End With
                Me.Refresh()
            End If
        Loop
        NewGcodeFile.WriteLine(Dataline)
        Dim ShortName As String = Me.SaveFileDialog1.FileName
        Do Until InStr(ShortName, "\") = 0
            Dim SlashLoc = InStr(ShortName, "\")
            ShortName = Strings.Right(ShortName, Len(ShortName) - SlashLoc)
        Loop
        With Me.TextBox1
            .Text &= vbCrLf & "Finished writing the """ & ShortName & """ file."
            .Select(.Text.Length, .Text.Length)
            .ScrollToCaret()
        End With
        OriginalGcodeFile.Close()
        NewGcodeFile.Close()
        WallsFile.Close()
        SkinsFile.Close()
        Exit Sub
EHandler:
        MsgBox("There was an error in ""Mainform.FirstLayerWallsFirstToolStripMenuItem_Click""." & vbCr & "Greg's description: " & MyErrorText & vbCr & "Windows: " & Err.Description, vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub OrthoTravelMovesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrthoTravelMovesToolStripMenuItem.Click
        Call FormsModule.OrthoTravel
    End Sub

    Private Sub InsertAtLayerChangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertAtLayerChangeToolStripMenuItem.Click
        Call InsertAtLayerChange.InsertAtLayerChangeSub()
    End Sub
End Class