Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            On Error GoTo EHandler
            Dim StartErrorText = "StartUp"
            AllResponses = True
            If DemoVersion Then
                MsgBox("This is a Demo Version.  Some functions and pages will not be available.", vbOKOnly, "Greg's Toolbox")
            End If
            With EnderMainForm
                Call .TuneUpToolStripMenuItem_Click(sender, e)
                .TuneUpPanel.Visible = False
                .ComPanel.Location = New Point(10, 40)
                .ComPanel.Size = New Size(900, 650)
                .ComPanel.Visible = True
                If DemoVersion Then
                    .ScriptGroupBox.Enabled = False
                    .CustomButtonGroup.Enabled = False
                    .RecoveryPanel.Enabled = False
                    .RaceBut.Enabled = False
                    .StatsPanel.Enabled = False
                    .CuraGCODEMenuItem.Enabled = False
                    .AutoLinkBut.Enabled = False
                    .LinkPrinterAndProfile.Enabled = False
                    .PrinterNameBox.Enabled = False
                    .CombineGcodeFilesToolStripMenuItem.Enabled = False
                    .MirrorAboutXToolStripMenuItem.Enabled = False
                    .MirrorAboutYToolStripMenuItem.Enabled = False
                    .AddTimeToPauseToGCODEToolStripMenuItem.Enabled = False
                    .SearchAndReplaceToolStripMenuItem.Enabled = False
                    .MicroLayersToolStripMenuItem.Enabled = False
                End If
                .G29But.Enabled = My.Settings.AutoLevel
                .G29But.Visible = My.Settings.AutoLevel
                .SetAutoLevBut.Visible = My.Settings.AutoLevel
                .JogDistLabel.Text = "Jog = 10.0"
                .JogDistLabel.BackColor = .JogDist10.BackColor
            End With
            JogDistance = "10"
            Call Load_Settings_Dialog()
            StartErrorText = "Error at ""ApplicationEvents.Load_Settings_Dialog"""
            If My.Settings.Custom1 = "" Then
                EnderMainForm.Custom1.Text = "Custom1"
                EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom1, "Empty")
            Else
                Dim TheSpace = InStr(My.Settings.Custom1, " ")
                If TheSpace = 0 Then
                    EnderMainForm.Custom1.Text = My.Settings.Custom1
                    EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom1, My.Settings.Custom1)
                Else
                    EnderMainForm.Custom1.Text = Left(My.Settings.Custom1, TheSpace - 1)
                    EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom1, My.Settings.Custom1)
                End If
            End If
            If My.Settings.Custom2 = "" Then
                EnderMainForm.Custom2.Text = "Custom2"
                EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom2, "Empty")
            Else
                Dim TheSpace = InStr(My.Settings.Custom2, " ")
                If TheSpace = 0 Then
                    EnderMainForm.Custom2.Text = My.Settings.Custom2
                    EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom2, My.Settings.Custom2)
                Else
                    EnderMainForm.Custom2.Text = Left(My.Settings.Custom2, TheSpace - 1)
                    EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom2, My.Settings.Custom2)
                End If
            End If
            If My.Settings.Custom3 = "" Then
                EnderMainForm.Custom3.Text = "Custom3"
                EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom3, "Empty")
            Else
                Dim TheSpace = InStr(My.Settings.Custom3, " ")
                If TheSpace = 0 Then
                    EnderMainForm.Custom3.Text = My.Settings.Custom3
                Else
                    EnderMainForm.Custom3.Text = Left(My.Settings.Custom3, TheSpace - 1)
                    EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom3, My.Settings.Custom3)
                End If
            End If
            If My.Settings.Custom4 = "" Then
                EnderMainForm.Custom4.Text = "Custom4"
                EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom4, "Empty")
            Else
                Dim TheSpace = InStr(My.Settings.Custom4, " ")
                If TheSpace = 0 Then
                    EnderMainForm.Custom4.Text = My.Settings.Custom4
                Else
                    EnderMainForm.Custom4.Text = Left(My.Settings.Custom4, TheSpace - 1)
                    EnderMainForm.RecoverTip.SetToolTip(EnderMainForm.Custom4, My.Settings.Custom4)
                End If
            End If
            With EnderMainForm
                If My.Settings.Script1 = "" Then
                    .Script1.Text = "Empty 1"
                    .RecoverTip.SetToolTip(.Script1, "Empty")
                Else
                    .Script1.Text = "Script #1"
                    .RecoverTip.SetToolTip(.Script1, "Script 1 attached")
                End If
                If My.Settings.Script2 = "" Then
                    .Script2.Text = "Empty 2"
                    .RecoverTip.SetToolTip(.Script2, "Empty")
                Else
                    .Script2.Text = "Script #2"
                    .RecoverTip.SetToolTip(.Script2, "Script 2 attached")
                End If
                If My.Settings.Script3 = "" Then
                    .Script3.Text = "Empty 3"
                    .RecoverTip.SetToolTip(.Script3, "Empty")
                Else
                    .Script3.Text = "Script #3"
                    .RecoverTip.SetToolTip(.Script3, "Script 3 attached")
                End If
                If My.Settings.Script4 = "" Then
                    .Script4.Text = "Empty 4"
                    .RecoverTip.SetToolTip(.Script4, "Empty")
                Else
                    .Script4.Text = "Script #4"
                    .RecoverTip.SetToolTip(.Script4, "Script 4 attached")
                End If
                StartErrorText = "ApplicationEvents.StartUp.If AutoPortOpen = true"
                If My.Settings.AutoPortOpen Then
                    .AutoOpenBut.Checked = True
                    Call OpenAPort()
                    EnderMainForm.ChkBaudBut.Text = "Baud Rate - " & My.Settings.PortBaud
                    ButtonReset = False
                    If EnderMainForm.Vcomm.IsOpen Then
                        EnderMainForm.ComOpenBut.Checked = True
                        EnderMainForm.StepOnOffBut.Checked = True
                    Else
                        EnderMainForm.ComOpenBut.Checked = False
                    End If
                    ButtonReset = True
                End If
                If My.Settings.WhatColor = "Standard" Then
                    .ColorButtonS.Checked = True
                Else
                    .ColorButtonD.Checked = True
                End If

                If My.Settings.PreHeatSync Then
                    EnderMainForm.PreHeatSyncBox.Checked = True
                    PreHeatSync = True
                Else
                    EnderMainForm.PreHeatSyncBox.Checked = False
                    PreHeatSync = False
                End If
                If My.Settings.Heated_Build_Volume Then
                    GCODE_Settings.HeatedBuildVolume.Checked = True
                Else
                    GCODE_Settings.HeatedBuildVolume.Checked = False
                End If
                Call GCODE_Settings.HeatedBuildVolume_CheckedChanged(sender, e)
                Call GCODE_Settings.NumOfExtruders_TextChanged(sender, e)
                .IgnoreResponseBut.Checked = False
            End With
            On Error Resume Next
            Dim PortNameString = ""
            StartErrorText = "Error in StartUp - PortNameString"
            For Each ThePort In My.Computer.Ports.SerialPortNames
                PortNameString += ThePort & "  "
            Next
            Err.Clear()
            EnderMainForm.TextBox1.AppendText(vbNewLine & "OS         : " & My.Computer.Info.OSFullName & vbNewLine &
                            "Win Version: " & My.Computer.Info.OSVersion & vbNewLine &
                            "Platform   : " & My.Computer.Info.OSPlatform & vbNewLine &
                            "# of Ports : " & My.Computer.Ports.SerialPortNames.Count & vbNewLine &
                            "Port Names : " & PortNameString & vbNewLine & vbNewLine &
                            "The port names may indicate just the physical Ports.  To list a virtual ""USB to Serial Port"" the printer must be connected to a port that has had the USB drivers installed (driver installation is usually by your Slicer software)." & vbCrLf & vbCrLf)
            With PrinterSettings
                .XJerkBox.Visible = True
                .XJerkLab.Visible = True
                .YJerkBox.Visible = True
                .YJerkLab.Visible = True
                .JuncDevBox.Visible = False
                .JuncLab.Visible = False
            End With
            StartErrorText = "Error in Printer Linking"
            If My.Settings.AutoLink = True And CStr(EnderMainForm.AvailablePortsBox.SelectedItem) <> "" Then
                Call EnderMainForm.LinkPrinterAndProfile_Click(sender, e)
                If My.Settings.AutoLink = True Then
                    EnderMainForm.Label59.Visible = True
                    EnderMainForm.Label60.Visible = True
                    EnderMainForm.PrinterNameBox.Visible = True
                    EnderMainForm.LinkPrinterAndProfile.Visible = True
                    EnderMainForm.ProfileLabel.Visible = True
                Else
                    EnderMainForm.Label59.Visible = False
                    EnderMainForm.Label60.Visible = False
                    EnderMainForm.PrinterNameBox.Visible = False
                    EnderMainForm.LinkPrinterAndProfile.Visible = False
                    EnderMainForm.ProfileLabel.Visible = False
                End If
            End If
            EnderMainForm.WindowState = FormWindowState.Maximized
            Exit Sub
EHandler:
            MsgBox(StartErrorText, vbOKOnly, "Greg's Toolbox")
        End Sub

    End Class
End Namespace
