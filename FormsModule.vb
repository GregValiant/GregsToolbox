

Module FormsModule
    Public DemoVersion As Boolean = False
    Public OpenPortDiaResponse As Boolean
    Public ComPortName As String
    Public vPortFound As Boolean, AddThisPort As Boolean
    Public ComUsed As Boolean, Parity As String, StopBit As Integer, BaudRate As Long, ComOpenParameters As String
    Public StrToSend As String
    Public AllResponses As Boolean
    Public RecvStr As String
    Public LayerHgt As Single
    Public OldZHgt As Single
    Public OldLayerNum As Integer
    Public StartTime As DateTime
    Public TotalTime As String
    Public MyLay As Boolean
    Public MyZ As Boolean
    Public ButtonReset As Boolean
    Public GCODE_File_R As System.IO.StreamReader
    Public GCODE_File_W As System.IO.StreamWriter
    Public PreferredPort As String
    Public PollTemp As Boolean
    Public MatlSelection As String
    Public FinalString As String
    Public MemoryString As String
    Public CheckDefeat As Boolean
    Public TempCalled As Boolean
    Public TheSlicer As String
    Public PrintStartTime As String
    Public LayerSearchStr As String
    Public JogDistance As String
    Public MyNotePad As Process
    Public PreHeatSync As Boolean
    Public PrinterNameArray(9, 2) As String
    Public ProfileLoaded As Boolean = False
    Public ShowErrorDialog As Boolean = True
    Public Delegate Sub mydelegate(ByVal s As String)
    Public Delegate Sub getDelegate(ByVal s As String)
    Public AbsExtrusion As Boolean

    Public Function IsRunningExe(exeName As String) As Boolean
        On Error Resume Next
        IsRunningExe = False
        Dim processes() As Process
        Dim instance As Process
        Dim process As New Process()
        processes = Process.GetProcesses
        For Each instance In processes
            If instance.ProcessName = exeName Then
                IsRunningExe = True
                EnderMainForm.CuraTitleBarInfo = instance.MainWindowTitle
                Exit Function
            Else
                IsRunningExe = False
            End If
        Next
    End Function

    Sub StartUp()
        On Error Resume Next
        With EnderMainForm.Vcomm
            If .IsOpen = False Then
                EnderMainForm.ComOpenBut.Text = "Com Port is Closed"
                EnderMainForm.ComOpenBut.Checked = False
                EnderMainForm.ComOpenBut.BackColor = Color.Red
                EnderMainForm.AvailablePortsBox.Items.Clear()
                Call CheckPossiblePorts()
            Else
                EnderMainForm.SendCmdBut.Enabled = True
                If EnderMainForm.Vcomm.PortName <> "" Then EnderMainForm.Text = "Greg's Toolbox ~ " & CStr(EnderMainForm.PrinterNameBox.SelectedItem)
            End If
            AllResponses = True
        End With
    End Sub
    Sub CheckPossiblePorts()
        Dim AResponse As MsgBoxResult
        Try
            Dim MaxPorts As Integer
            EnderMainForm.PortScanBar.Value = 0
            EnderMainForm.PortScanBar.Visible = True

            With EnderMainForm.Vcomm
                RemoveHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
                .Close()
                AddHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
                EnderMainForm.AvailablePortsBox.Items.Clear()
                EnderMainForm.AvailablePortsBox.ResetText()
                EnderMainForm.PrinterNameBox.Items.Clear()
                EnderMainForm.PrinterNameBox.ResetText()
                For Each portCOMname In My.Computer.Ports.SerialPortNames
                    EnderMainForm.AvailablePortsBox.Items.Add(portCOMname)
                Next

                RemoveHandler EnderMainForm.AvailablePortsBox.SelectedIndexChanged, AddressOf EnderMainForm.AvailablePortsBox_SelectedIndexChanged
                If EnderMainForm.AvailablePortsBox.Items.Count > 0 Then
                    EnderMainForm.AvailablePortsBox.SelectedIndex = 0
                    AddThisPort = True
                Else
                    AddThisPort = False
                End If
                AddHandler EnderMainForm.AvailablePortsBox.SelectedIndexChanged, AddressOf EnderMainForm.AvailablePortsBox_SelectedIndexChanged
                vPortFound = False
                MaxPorts = CInt(My.Settings.MaxPorts)
                'AddThisPort = True
                Call FillPrinterArray()
            End With
            Dim P As String
            Dim q = 0
            If vPortFound = True Then
                RemoveHandler EnderMainForm.AvailablePortsBox.SelectedIndexChanged, AddressOf EnderMainForm.AvailablePortsBox_SelectedIndexChanged
                For Each P In EnderMainForm.AvailablePortsBox.Items.ToString
                    If Right(P, Len(P) - 3) = My.Settings.DefaultPort Then
                        EnderMainForm.AvailablePortsBox.SelectedIndex = q
                        If EnderMainForm.PrinterNameBox.Items.Count > 0 And EnderMainForm.PrinterNameBox.Items.Count <= q Then
                            EnderMainForm.PrinterNameBox.SelectedIndex = q
                        End If
                        Exit For
                    Else
                        EnderMainForm.AvailablePortsBox.SelectedIndex = 0
                        If EnderMainForm.PrinterNameBox.Items.Count > 0 Then
                            EnderMainForm.PrinterNameBox.SelectedIndex = 0
                        End If
                    End If
                    q += 1
                Next
                AddHandler EnderMainForm.AvailablePortsBox.SelectedIndexChanged, AddressOf EnderMainForm.AvailablePortsBox_SelectedIndexChanged
            End If
            If vPortFound = False And AddThisPort = False Then
                AResponse = MsgBox("Device Manager is not listing any Serial Ports.  Do you want to do a full search?" & vbCr & vbCr & "The highest port number to be searched will be COM" & My.Settings.MaxPorts & " as listed in ""Settings | Application Settings | Max Ports""", vbYesNo, "Greg's Toolbox")
                If AResponse = vbYes Then
                    For Po = 1 To Val(My.Settings.MaxPorts)
                        Try
                            EnderMainForm.Vcomm.PortName = "COM" & Po
                            EnderMainForm.Vcomm.Open()
                            Threading.Thread.Sleep(500)
                            If EnderMainForm.Vcomm.IsOpen = True Then
                                RemoveHandler EnderMainForm.AvailablePortsBox.SelectedIndexChanged, AddressOf EnderMainForm.AvailablePortsBox_SelectedIndexChanged
                                EnderMainForm.AvailablePortsBox.Items.Add("COM" & Po)
                                EnderMainForm.AvailablePortsBox.SelectedIndex = 0
                                EnderMainForm.Vcomm.Close()
                                AddHandler EnderMainForm.AvailablePortsBox.SelectedIndexChanged, AddressOf EnderMainForm.AvailablePortsBox_SelectedIndexChanged
                            End If
                        Catch ex As Exception
                        End Try
                        EnderMainForm.PortScanBar.Value += 5
                        If EnderMainForm.PortScanBar.Value >= EnderMainForm.PortScanBar.Maximum Then EnderMainForm.PortScanBar.Value = 0
                        EnderMainForm.PortScanBar.Refresh()
                    Next
                End If
            End If
            EnderMainForm.PortScanBar.Value = 0
            EnderMainForm.PortScanBar.Visible = False
            EnderMainForm.Refresh()
        Catch ex As Exception
            MsgBox("Error in CheckPossiblePorts:  " & Err.Description, vbOKOnly)
        End Try
        If vPortFound = False And EnderMainForm.AvailablePortsBox.Items.Count = 0 Then
            If ShowErrorDialog = True Then
                MsgBox("Unable to find an available Com port.  This can be caused by:" & Chr(10) &
            "~ Another program has control of the Com port." & Chr(10) &
            "(Close all other programs that might be communicating with the printer USB port.)" & Chr(10) &
            "~ Your computer has assigned a port number higher than Com " & My.Settings.MaxPorts & " as set in the Settings|App Settings dialog box in ""Max Ports""." & Chr(10) &
            "You can set Max Ports higher (up to 99).  If that doesn't work then refer to Windows Help and the Device Manager.  In the Device Manager under ""Ports (Com & LPT)"" with the printer connected to the computer - there should be one with a name like ""USB-Serial CH340 (COMx)""" & Chr(10) &
            "USB to Serial drivers must be loaded. Make sure the drivers have been loaded for the particular USB port you are using.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            End If
            AResponse = MsgBox("Do you want to enable Port Polling at 5 second intervals?", vbYesNo, "Greg's Toolbox")
            If AResponse = vbYes Then
                Call EnderMainForm.FifeenSecondTimer()
            Else
                EnderMainForm.PortTimer.Enabled = False
            End If
            ShowErrorDialog = True
        End If
    End Sub

    Sub OpenAPort()
        Dim PortToTry As String
        PortToTry = CStr(EnderMainForm.AvailablePortsBox.SelectedItem)
        If PortToTry = "" Or PortToTry = "COM" Then
            Call CheckPossiblePorts()
        End If
        Dim MyPort As String
        If EnderMainForm.AutoLinkBut.Checked = False Then
            PreferredPort = "COM" & CStr(Val(GCODE_Settings.DefaultPort.Text.ToString))
        Else
            PreferredPort = PortToTry
        End If
        For Each MyPort In EnderMainForm.AvailablePortsBox.Items
            If MyPort.ToString = PreferredPort Then
                EnderMainForm.AvailablePortsBox.SelectedItem = MyPort
            End If
        Next
SearchAgain:

        ComUsed = True
        Call ClearCommPort()
        Dim Bytes As Integer
        ComPortName = Convert.ToString(EnderMainForm.AvailablePortsBox.SelectedItem)
        If ComPortName = Nothing Or ComPortName = "" Then
            EnderMainForm.ComOpenBut.Checked = False
            Exit Sub
        End If
        With EnderMainForm.Vcomm
            RemoveHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
            Try
                If .IsOpen Then .Close()
            Catch
            End Try

            AddHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
            Threading.Thread.Sleep(250)
            .PortName = ComPortName
            BaudRate = CLng(My.Settings.PortBaud)
            If BaudRate <= 0 Then BaudRate = 9600
            Parity = My.Settings.PortParity
            Bytes = CInt(My.Settings.PortBytes)
            StopBit = CInt(My.Settings.PortStopBits)
            ComOpenParameters = BaudRate & "," & Parity & "," & Bytes & "," & StopBit
            .ReceivedBytesThreshold = 1
            .BaudRate = CInt(BaudRate)
            .PortName = ComPortName
            '.Handshake = False
            .WriteBufferSize = 1232
            Try
                .Open()
            Catch
                For Each portCOMname In My.Computer.Ports.SerialPortNames
                    If portCOMname = ComPortName And Not .IsOpen() Then
                        MsgBox("The port " & ComPortName & " cannot be opened.  Another program may be using it", vbOKOnly, "Greg's Toolbox")
                    End If
                Next
                Dim DevicePresent = False
                If My.Computer.Ports.SerialPortNames.Count > 0 Then
                    For Each portCOMname In My.Computer.Ports.SerialPortNames
                        If portCOMname = ComPortName Then
                            DevicePresent = True
                        Else
                            DevicePresent = False
                        End If
                        If DevicePresent = False Then
                            MsgBox("The port " & ComPortName & " cannot be found in Device Manager and cannot be opened.", vbOKOnly, "Greg's Toolbox")
                        End If
                    Next
                Else
                    MsgBox("The port " & ComPortName & " cannot be found in Device Manager.", vbOKOnly, "Greg's Toolbox")
                End If
            End Try

            If .IsOpen = True Then
                EnderMainForm.ComOpenBut.Text = "Com " & .PortName & " is Open"
                EnderMainForm.ComOpenBut.BackColor = Color.DarkGreen
                EnderMainForm.ComOpenBut.Checked = True
            Else
                EnderMainForm.ComOpenBut.Text = "Com is closed"
                EnderMainForm.ComOpenBut.BackColor = Color.Red
            End If

            If EnderMainForm.Vcomm.IsOpen = False Then
                'MsgBox("Unable to open " & ComPortName & vbLf & vbLf & "Do you want to try a search?", Ctype(vbYesNo + vbInformation,msgboxstyle), "Greg's Toolbox Com Test")
                If OpenPortDiaResponse = True Then
                    GoTo SearchAgain
                End If
                EnderMainForm.ComOpenBut.Checked = False
                Exit Sub
            End If
        End With
        Call ClearCommPort()
    End Sub

    Sub AutoOpenAPort(PortToTry As String)

SearchAgain:
        If PortToTry = "" Or PortToTry = Nothing Then Exit Sub
        ComUsed = True
        Call ClearCommPort()
        Dim Bytes As Integer
        ComPortName = PortToTry
        With EnderMainForm.Vcomm
            RemoveHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
            .Close()
            Threading.Thread.Sleep(1000)
            AddHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
            .PortName = ComPortName
            BaudRate = CInt(My.Settings.PortBaud)
            Parity = My.Settings.PortParity
            Bytes = CInt(My.Settings.PortBytes)
            StopBit = CInt(My.Settings.PortStopBits)
            ComOpenParameters = BaudRate & "," & Parity & "," & Bytes & "," & StopBit
            .ReceivedBytesThreshold = 1
            .BaudRate = CInt(BaudRate)
            .PortName = ComPortName
            '.Handshake = False
            .WriteBufferSize = 4096
            Try
                .Open()
            Catch
                MsgBox("The port " & ComPortName & " doesn't exist", vbOKOnly, "Greg's Toolbox")
            End Try

            If .IsOpen = True Then
                EnderMainForm.ComOpenBut.Text = "Com " & .PortName & " is Open"
                EnderMainForm.ComOpenBut.BackColor = Color.DarkGreen
                EnderMainForm.ComOpenBut.Checked = True
            Else
                EnderMainForm.ComOpenBut.Text = "Com is closed"
                EnderMainForm.ComOpenBut.BackColor = Color.Red
            End If

            If EnderMainForm.Vcomm.IsOpen = False Then
                'MsgBox("Unable to open " & ComPortName & vbLf & vbLf & "Do you want to try a search?", Ctype(vbYesNo + vbInformation,msgboxstyle), "Greg's Toolbox Com Test")
                If OpenPortDiaResponse = True Then
                    GoTo SearchAgain
                End If
                EnderMainForm.ComOpenBut.Checked = False
                Exit Sub
            End If
        End With
        Call ClearCommPort()
    End Sub

    Sub ClearCommPort()
        On Error Resume Next
        EnderMainForm.Vcomm.DiscardOutBuffer()
        EnderMainForm.Vcomm.DiscardInBuffer()
    End Sub

    Public Sub ClosePort()
        Try
            Call ClearCommPort()
            If EnderMainForm.Vcomm.IsOpen Then
                RemoveHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
                Threading.Thread.Sleep(1000)
                EnderMainForm.Vcomm.Close()
                AddHandler EnderMainForm.Vcomm.DataReceived, AddressOf EnderMainForm.SerialPort1_DataReceived
            End If
        Catch ex As Exception
            MsgBox("There was an error closing the port" & vbLf & ex.Message, vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Public Sub SendTheString(StrToSend As String)
        On Error GoTo ErrHandler
        EnderMainForm.Vcomm.Write(StrToSend & vbLf)
        Exit Sub
ErrHandler:
        MsgBox("Error in ""FormsModule.SendTheString"". The Message """ & StrToSend & """ caused an Error:" & vbCr & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub
    Function FormatTime(TotalTime As String) As String
        On Error Resume Next
        Dim Hrs As String = "00"
        Dim Mins As String = "00"
        Dim Secs As String = "00"

        If Val(TotalTime) >= 3600 Then
            Hrs = Format(Int(Val(TotalTime) / 3600), "00")

            TotalTime = CStr(CLng(TotalTime) - (CLng(Hrs) * 3600))

        End If
        If Val(TotalTime) >= 60 Then
            Mins = Format(Int(Val(TotalTime) / 60), "00")

            TotalTime = CStr(CLng(TotalTime) - (Val(Mins) * 60))

        End If
        Secs = Format(Val(TotalTime), "00")
        FormatTime = Hrs & ":" & Mins & ":" & Secs
        If CLng(Secs) < 0 Then
            MsgBox("The time indicated is in error.  Please enter a valid layer and Z height.", vbOKOnly, "Stooid Engineering")
        End If

    End Function

    Public Function FindSlicer(ImportFileName As String) As String
        Dim NameStr As String
        Dim FullStr As String = ""
        Try
            GCODE_File_R = My.Computer.FileSystem.OpenTextFileReader(ImportFileName)
        Catch ex As Exception
            MsgBox("There was an error finding the slicer", vbOKOnly)
            FindSlicer = ""
            Exit Function
        End Try
        For N = 1 To 100
            NameStr = GCODE_File_R.ReadLine
            FullStr &= NameStr
        Next
        GCODE_File_R.Close()

        If InStr(FullStr, "Cura") > 0 Then
            FindSlicer = "Cura"
            LayerSearchStr = ";layer:"
        ElseIf InStr(FullStr, "Simplify3D") > 0 Then
            FindSlicer = "Simplify3D"
            LayerSearchStr = "; layer "
        ElseIf InStr(FullStr, "Slic3r") > 0 Then
            FindSlicer = "Slic3r"
            LayerSearchStr = "G1 Z"
        ElseIf InStr(FullStr, "ideaMaker") > 0 Then
            FindSlicer = "ideaMaker"
            LayerSearchStr = ";layer:"
        ElseIf InStr(FullStr, "CraftWare") > 0 Then
            FindSlicer = "CraftMaker"
            LayerSearchStr = "; Layer #"
        ElseIf InStr(FullStr, "MatterSlice") > 0 Then
            FindSlicer = "MatterSlice"
            LayerSearchStr = "; LAYER:"
        ElseIf InStr(FullStr, "KISSlicer") > 0 Then
            FindSlicer = "KISSlicer"
            LayerSearchStr = "BEGIN_LAYER_OBJECT"
        Else
            FindSlicer = "Unknown"
            LayerSearchStr = ";layer:"
        End If
        Try
            If InStr(FullStr, "layer_count") > 0 Then
                Dim CountPos = InStr(FullStr, "layer_count")
                Dim LCountLine = Strings.Right(FullStr, Len(FullStr) - CountPos - 11)
                CountPos = InStr(LCountLine, ";")
                FileOnFileForm.LAYER_COUNT = CInt(Strings.Left(LCountLine, CountPos - 1))
            End If
        Catch
        End Try
    End Function

    Public Sub Load_Settings_Dialog()
        On Error Resume Next
        With GCODE_Settings
            .Lev_LFx.Text = My.Settings.Lev_LFx
            .Lev_LFy.Text = My.Settings.Lev_LFy
            .Lev_LFz.Text = My.Settings.Lev_LFz
            .Lev_LRx.Text = My.Settings.Lev_LRx
            .Lev_LRy.Text = My.Settings.Lev_LRy
            .Lev_LRz.Text = My.Settings.Lev_LRz
            .Lev_RFx.Text = My.Settings.Lev_RFx
            .Lev_RFy.Text = My.Settings.Lev_RFy
            .Lev_RFz.Text = My.Settings.Lev_RFz
            .Lev_RRx.Text = My.Settings.Lev_RRx
            .Lev_RRy.Text = My.Settings.Lev_RRy
            .LEV_RRz.Text = My.Settings.Lev_RRz
            .Lev_MIDx.Text = My.Settings.Lev_MIDx
            .Lev_MIDy.Text = My.Settings.Lev_MIDy
            .Lev_MIDz.Text = My.Settings.Lev_MIDz
            .PresPr_x.Text = My.Settings.PrePr_x
            .PresPr_y.Text = My.Settings.PrePr_y
            .PresPr_z.Text = My.Settings.PrePr_z
            .ChngNoz_x.Text = My.Settings.ChngNoz_x
            .ChngNoz_y.Text = My.Settings.ChngNoz_y
            .ChngNoz_z.Text = My.Settings.ChngNoz_z
            .Cali_E_x.Text = My.Settings.Cali_E_x
            .Cali_E_y.Text = My.Settings.Cali_E_y
            .Cali_E_z.Text = My.Settings.Cali_E_z
            .Matl1Name.Text = My.Settings.Matl1_Name
            .Matl1Hot.Text = My.Settings.Matl1_Hot
            .Matl1Bed.Text = My.Settings.Matl1_Bed
            .Matl1Fan.Text = My.Settings.Matl1_Fan
            .Matl2Name.Text = My.Settings.Matl2_Name
            .Matl2Hot.Text = My.Settings.Matl2_Hot
            .Matl2Bed.Text = My.Settings.Matl2_Bed
            .Matl2Fan.Text = My.Settings.Matl2_Fan
            .Matl3Name.Text = My.Settings.Matl3_Name
            .Matl3Hot.Text = My.Settings.Matl3_Hot
            .Matl3Bed.Text = My.Settings.Matl3_Bed
            .Matl3Fan.Text = My.Settings.Matl3_Fan
            .Matl4Name.Text = My.Settings.Matl4_Name
            .Matl4Hot.Text = My.Settings.Matl4_Hot
            .Matl4Bed.Text = My.Settings.Matl4_Bed
            .Matl4Fan.Text = My.Settings.Matl4_Fan
            .PortBaud.Text = My.Settings.PortBaud
            .PortBytes.Text = My.Settings.PortBytes
            .PortParity.Text = My.Settings.PortParity
            .DefaultPort.Text = My.Settings.DefaultPort
            .MaxPorts.Text = My.Settings.MaxPorts
            .PortStopBits.Text = My.Settings.PortStopBits
            .NumOfExtruders.Text = My.Settings.NumOfExtruders
            .RetractBox.Text = My.Settings.Retraction
            .ExtrudeBox.Text = My.Settings.ExtrudeAmt
            .PrimeBox.Text = My.Settings.PrimeAmt
            .Auto_Level.Checked = My.Settings.AutoLevel
            .AutoLevelCmdBox.Text = My.Settings.AutoLevelCMD
            .HeatedBed.Checked = My.Settings.Heated_Bed
            .HomeOffX.Text = My.Settings.HomeOffsetX
            .HomeOffY.Text = My.Settings.HomeOffsetY
            .HomeOffZ.Text = My.Settings.HomeOffsetZ
            .HeatedBuildVolume.Checked = My.Settings.Heated_Build_Volume
        End With
    End Sub

    Public Sub FillPrinterArray()
        On Error Resume Next
        PrinterNameArray(0, 0) = My.Settings.PR1Name
        PrinterNameArray(0, 1) = My.Settings.PR1Port
        PrinterNameArray(0, 2) = My.Settings.PR1Profile
        PrinterNameArray(1, 0) = My.Settings.PR2Name
        PrinterNameArray(1, 1) = My.Settings.PR2Port
        PrinterNameArray(1, 2) = My.Settings.PR2Profile
        PrinterNameArray(2, 0) = My.Settings.PR3Name
        PrinterNameArray(2, 1) = My.Settings.PR3Port
        PrinterNameArray(2, 2) = My.Settings.PR3Profile
        PrinterNameArray(3, 0) = My.Settings.PR4Name
        PrinterNameArray(3, 1) = My.Settings.PR4Port
        PrinterNameArray(3, 2) = My.Settings.PR4Profile
        PrinterNameArray(4, 0) = My.Settings.PR5Name
        PrinterNameArray(4, 1) = My.Settings.PR5Port
        PrinterNameArray(4, 2) = My.Settings.PR5Profile
        PrinterNameArray(5, 0) = My.Settings.PR6Name
        PrinterNameArray(5, 1) = My.Settings.PR6Port
        PrinterNameArray(5, 2) = My.Settings.PR6Profile
        PrinterNameArray(6, 0) = My.Settings.PR7Name
        PrinterNameArray(6, 1) = My.Settings.PR7Port
        PrinterNameArray(6, 2) = My.Settings.PR7Profile
        PrinterNameArray(7, 0) = My.Settings.PR8Name
        PrinterNameArray(7, 1) = My.Settings.PR8Port
        PrinterNameArray(7, 2) = My.Settings.PR8Profile
        PrinterNameArray(8, 0) = My.Settings.PR9Name
        PrinterNameArray(8, 1) = My.Settings.PR9Port
        PrinterNameArray(8, 2) = My.Settings.PR9Profile
        PrinterNameArray(9, 0) = My.Settings.PR10Name
        PrinterNameArray(9, 1) = My.Settings.PR10Port
        PrinterNameArray(9, 2) = My.Settings.PR10Profile
    End Sub

    Public Sub LoadProfileOnPort()
        Call FillPrinterArray()
        Dim FileResponse = "0"
        Dim NewPort = Strings.Right(Convert.ToString(EnderMainForm.AvailablePortsBox.SelectedItem), Len(EnderMainForm.AvailablePortsBox.SelectedItem.ToString) - 3)
        For M = 0 To 9
            If PrinterNameArray(M, 0) = CStr(EnderMainForm.PrinterNameBox.SelectedItem) And NewPort = PrinterNameArray(M, 1) Then
                FileResponse = PrinterNameArray(M, 2)
                Exit For
            End If
        Next

        If FileResponse = "" Or FileResponse = "0" Then
            EnderMainForm.ProfileLabel.Text = ""
            Exit Sub
        End If
        Dim INI_File As System.IO.StreamReader
        Try
            INI_File = My.Computer.FileSystem.OpenTextFileReader(FileResponse)
            'If INI_File Is Nothing Then INI_File = FileResponse
        Catch
            Exit Sub
        End Try
        Dim CurLine = ""
        Dim Index = 0
        Dim CmdArray(84) As String
        Do While INI_File.EndOfStream <> True
            CurLine = INI_File.ReadLine
            CmdArray(Index) = CurLine
            Index += 1
        Loop
        INI_File.Close()

        With My.Settings
            Dim ALvl As String = System.Text.RegularExpressions.Regex.Replace(CmdArray(0), "[^\u0000-\u007F]", "")
            .AutoLevel = CBool(ALvl)
            GCODE_Settings.Auto_Level.Checked = .AutoLevel
            .AutoPortOpen = CBool(CmdArray(1))
            EnderMainForm.AutoOpenBut.Checked = .AutoPortOpen
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
                EnderMainForm.Custom1.Text = "Custom 1"
            Else
                .Custom1 = Strings.Right(CurLine, Len(CurLine) - 1)
                EnderMainForm.Custom1.Text = Strings.Left(My.Settings.Custom1, 4)
            End If
            CurLine = CmdArray(12)
            If CurLine = ";" Then
                .Custom2 = ""
                EnderMainForm.Custom2.Text = "Custom 2"
            Else
                .Custom2 = Strings.Right(CurLine, Len(CurLine) - 1)
                EnderMainForm.Custom2.Text = Strings.Left(My.Settings.Custom2, 4)
            End If
            CurLine = CmdArray(13)
            If CurLine = ";" Then
                .Custom3 = ""
                EnderMainForm.Custom3.Text = "Custom 3"
            Else
                .Custom3 = Strings.Right(CurLine, Len(CurLine) - 1)
                EnderMainForm.Custom3.Text = Strings.Left(My.Settings.Custom3, 4)
            End If
            CurLine = CmdArray(14)
            If CurLine = ";" Then
                .Custom4 = ""
                EnderMainForm.Custom4.Text = "Custom 4"
            Else
                .Custom4 = Strings.Right(CurLine, Len(CurLine) - 1)
                EnderMainForm.Custom4.Text = Strings.Left(My.Settings.Custom4, 4)
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
            Dim NewScript1 = ""
            Dim NewScript2 = ""
            Dim NewScript3 = ""
            Dim NewScript4 = ""
            If CurLine = ";" Then
                .Script1 = ""
                EnderMainForm.Script1.Text = "Empty 1"
            Else
                NewScript1 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript1 = Replace(NewScript1, ",", vbCrLf, 1,)
                .Script1 = NewScript1
                EnderMainForm.Script1.Text = "Script #1"
            End If
            CurLine = CmdArray(68)
            If CurLine = ";" Then
                .Script2 = ""
                EnderMainForm.Script2.Text = "Empty 2"
            Else
                NewScript2 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript2 = Replace(NewScript2, ",", vbCrLf, 1,)
                .Script2 = NewScript2
                EnderMainForm.Script2.Text = "Script #2"
            End If
            CurLine = CmdArray(69)
            If CurLine = ";" Then
                .Script3 = ""
                EnderMainForm.Script3.Text = "Empty 3"
            Else
                NewScript3 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript3 = Replace(NewScript3, ",", vbCrLf, 1,)
                .Script3 = Strings.Right(CurLine, Len(CurLine) - 1)
                EnderMainForm.Script3.Text = "Script #3"
            End If
            CurLine = CmdArray(70)
            If CurLine = ";" Then
                .Script4 = ""
                EnderMainForm.Script4.Text = "Empty 4"
            Else
                NewScript4 = Strings.Right(CurLine, Len(CurLine) - 1)
                NewScript4 = Replace(NewScript4, ",", vbCrLf, 1,)
                .Script4 = NewScript4
                EnderMainForm.Script4.Text = "Script #4"
            End If
            EnderMainForm.FloBox.Text = CmdArray(71)
            EnderMainForm.FeedBox.Text = CmdArray(72)
            EnderMainForm.HeatBox.Text = CmdArray(73)
            EnderMainForm.BedBox.Text = CmdArray(74)
            EnderMainForm.FanBox.Text = CmdArray(75)
            .DefaultPAccel = CmdArray(76)
            .DefaultTAccel = CmdArray(77)
            .JunctionDeviation = CmdArray(78)
            EnderMainForm.PreHeatSyncBox.Checked = CBool(CmdArray(79))
            GCODE_Settings.AutoLevelCmdBox.Text = CmdArray(80)
            GCODE_Settings.FilDiaBox.Text = CmdArray(81)
            If CmdArray(82) = "Dark" Then
                EnderMainForm.ColorButtonD.Checked = True
            Else
                EnderMainForm.ColorButtonS.Checked = True
            End If
            'GCODE_Settings.HeatedBed.Checked = CmdArray(83)
            GCODE_Settings.HeatedBuildVolume.Checked = CBool(CmdArray(83))

        End With
        INI_File.Close()
        ProfileLoaded = True
        Dim ShortName = FileResponse
        Do Until InStr(ShortName, "\") = 0
            ShortName = Strings.Right(ShortName, Len(ShortName) - 1)
        Loop
        EnderMainForm.ProfileLabel.Text = ShortName
        Exit Sub
TheHandler:
        MsgBox("There was an Error" & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Public Sub ConvertBlackbelt()
        Dim DataLine As String
        Dim Zloc As Integer
        Dim Yloc As Integer
        Dim OriginalGcodeFile As System.IO.StreamReader
        Dim NewGcodeFile As System.IO.StreamWriter

        EnderMainForm.TextBox1.Text &= vbCrLf & vbCrLf & "Change a REGULAR Gcode to a BELT Printer gcode" & vbCrLf
        With EnderMainForm.OpenFileDialog1
            .Title = "Open your Original GCODE file"
            .Filter = "GCODE Files|*.gcode"
            .FilterIndex = 1
            .DefaultExt = "gcode"
            .FileName = ""
            Dim FileResponse = .ShowDialog() '("GCODE Files (*.gcode), *.gcode", 1, " Open a GCODE File...")
            If FileResponse = 2 Then
                EnderMainForm.TextBox1.Text &= "Canceled"
                Exit Sub
            End If
            Dim OriginalFileName = .FileName
        End With
        EnderMainForm.TextBox1.Text &= vbCrLf & "Original File Name:  " & vbCrLf & EnderMainForm.OpenFileDialog1.FileName & vbCrLf
        ' create, save, open the new file
        Dim TempName = EnderMainForm.OpenFileDialog1.FileName
        Do Until InStr(TempName, "\") = 0
            TempName = Strings.Right(TempName, Len(TempName) - InStr(TempName, "\"))
        Loop
        TempName = Strings.Left(TempName, Len(TempName) - 6)
        With EnderMainForm
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = TempName & "_Belt.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                If System.IO.File.Exists(.SaveFileDialog1.FileName) Then
                    System.IO.File.Delete(.SaveFileDialog1.FileName)
                End If
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                .TextBox1.Text &= vbCrLf & "Canceled"
                Exit Sub
            End If
            .TextBox1.Text &= vbCrLf & "New File Name:  " & vbCrLf & .SaveFileDialog1.FileName
        End With
        OriginalGcodeFile = My.Computer.FileSystem.OpenTextFileReader(EnderMainForm.OpenFileDialog1.FileName)
        DataLine = OriginalGcodeFile.ReadLine

        Do Until InStr(1, DataLine, ";LAYER:0", vbTextCompare) > 0
            If Strings.Left(DataLine, 1) = "G" Then
                Zloc = InStr(1, DataLine, "Z", vbTextCompare)
                Yloc = InStr(1, DataLine, "Y", vbTextCompare)
                If Yloc > 0 Then
                    DataLine = Strings.Replace(DataLine, "Y", "Q", 1, 2, vbTextCompare)
                End If
                If Zloc > 0 Then
                    DataLine = Strings.Replace(DataLine, "Z", "Y", 1, 2, vbTextCompare)
                End If
                If Yloc > 0 Then
                    DataLine = Strings.Replace(DataLine, "Q", "Z", 1, 2, vbTextCompare)
                End If
            End If
            NewGcodeFile.WriteLine(DataLine)
            DataLine = OriginalGcodeFile.ReadLine
        Loop
        Do Until OriginalGcodeFile.EndOfStream = True
            If Strings.Left(DataLine, 3) = "G0 " Or Strings.Left(DataLine, 3) = "G1 " Or Strings.Left(DataLine, 3) = "G2 " Or Strings.Left(DataLine, 3) = "G3 " Then
                Zloc = InStr(1, DataLine, "Z", vbTextCompare)
                Yloc = InStr(1, DataLine, "Y", vbTextCompare)
                If Yloc > 0 Then
                    DataLine = Strings.Replace(DataLine, "Y", "Q", 1, 2, vbTextCompare)
                End If
                If Zloc > 0 Then
                    DataLine = Strings.Replace(DataLine, "Z", "Y", 1, 2, vbTextCompare)
                End If
                If Yloc > 0 Then
                    DataLine = Strings.Replace(DataLine, "Q", "Z", 1, 2, vbTextCompare)
                End If
            End If
            NewGcodeFile.WriteLine(DataLine)
            DataLine = OriginalGcodeFile.ReadLine
        Loop
        OriginalGcodeFile.Close()
        NewGcodeFile.Close()
        With EnderMainForm.TextBox1
            .Text &= vbCrLf & vbCrLf & "Completed"
            .Select(.Text.Length, .Text.Length)
            .ScrollToCaret()
        End With
    End Sub

    Public Sub OrthoTravel()
        Dim Originalgcodefile As System.IO.StreamReader
        Dim NewGcodeFile As System.IO.StreamWriter
        Dim xloc As Integer = 0
        Dim yloc As Integer = 0
        Dim zloc As Integer = 0
        Dim floc As Integer = 0
        Dim XVal As String = ""
        Dim YVal As String = ""
        Dim ZVal As String = ""
        Dim FVal As String = ""
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
            .FileName = ShortName & "_Ortho.gcode"
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
                    NewGcodeFile.WriteLine(";      POSTPROCESSED Greg's Toolbox (Orthogonal Travel)")
                End If
                NewGcodeFile.WriteLine(Dataline)
                Dataline = Originalgcodefile.ReadLine
            Loop
            NewGcodeFile.WriteLine(Dataline)
            Dataline = Originalgcodefile.ReadLine
PRIMETOWER:
            Do Until Originalgcodefile.EndOfStream = True Or InStr(Dataline, ";End of Gcode") > 0
                If InStr(Dataline, "PRIME-TOWER") > 0 Or InStr(Dataline, "MESH") > 0 Then
                    NewGcodeFile.WriteLine(Dataline)
                    Dataline = Originalgcodefile.ReadLine
                    Do Until InStr(Dataline, ";") > 0
                        ZVal = ""
                        YVal = ""
                        XVal = ""
                        FVal = ""
                        If Strings.Left(Dataline, 2) = "G0" Then
                            xloc = InStr(Dataline, " X")
                            yloc = InStr(Dataline, " Y")
                            zloc = InStr(Dataline, " Z")
                            floc = InStr(Dataline, " F")
                            If xloc > 0 Then XVal = " X" & GetAnyValue(Dataline, xloc)
                            If yloc > 0 Then YVal = " Y" & GetAnyValue(Dataline, yloc)
                            If zloc > 0 Then ZVal = " Z" & GetAnyValue(Dataline, zloc)
                            If floc > 0 Then FVal = " F" & GetAnyValue(Dataline, floc)
                            NewGcodeFile.WriteLine("G0" & FVal & XVal & ZVal)
                            NewGcodeFile.WriteLine("G0" & YVal)
                            Dataline = Originalgcodefile.ReadLine
                        Else
                            NewGcodeFile.WriteLine(Dataline)
                            Dataline = Originalgcodefile.ReadLine
                        End If
                    Loop
                    If InStr(Dataline, "PRIME-TOWER") > 0 Then GoTo PRIMETOWER
                End If
                NewGcodeFile.WriteLine(Dataline)
                Dataline = Originalgcodefile.ReadLine
            Loop
            If Originalgcodefile.EndOfStream <> True Then
                Do Until Originalgcodefile.EndOfStream = True
                    NewGcodeFile.WriteLine(Dataline)
                    Dataline = Originalgcodefile.ReadLine
                Loop
            End If
        Catch
            MsgBox("The Error is " & Err.Description, vbOKOnly)
            Originalgcodefile.Close()
            NewGcodeFile.Close()
            Exit Sub
        End Try
        Originalgcodefile.Close()
        NewGcodeFile.Close()
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("The file is complete.  Do you want to open it in NotePad?", vbYesNo, "Greg's Toolbox")
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

    Function GetAnyValue(Dataline As String, Xpresent As Integer) As String
        On Error Resume Next
        Dim Xstr As String
        Dim Xspace As Integer
        Xstr = Strings.Right(Dataline, Len(Dataline) - Xpresent - 1)
        Xspace = InStr(1, Xstr, " ")
        If Xspace > 0 Then
            Xstr = Strings.Left(Xstr, Xspace - 1)
        End If
        GetAnyValue = Xstr
    End Function



End Module
