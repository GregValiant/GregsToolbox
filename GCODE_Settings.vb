
Imports System.ComponentModel

Public Class GCODE_Settings
    Friend WithEvents Vcomm As IO.Ports.SerialPort

    Private Sub GCODE_Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.PrePr_y = My.Settings.Bed_Ymax
        My.Settings.Save()
        With EnderMainForm
            .BedBox.Enabled = My.Settings.Heated_Bed
            .BedDnBut.Enabled = My.Settings.Heated_Bed
            .BedUpBut.Enabled = My.Settings.Heated_Bed
            .BedSend.Enabled = My.Settings.Heated_Bed
            .BedLabel.Visible = My.Settings.Heated_Bed
        End With

    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        My.Settings.Save()
        With EnderMainForm
            .BedBox.Enabled = My.Settings.Heated_Bed
            .BedDnBut.Enabled = My.Settings.Heated_Bed
            .BedUpBut.Enabled = My.Settings.Heated_Bed
            .BedSend.Enabled = My.Settings.Heated_Bed
            .BedLabel.Visible = My.Settings.Heated_Bed
        End With
        Me.Hide()
    End Sub

    Public Sub NumOfExtruders_TextChanged(sender As Object, e As EventArgs) Handles NumOfExtruders.TextChanged
        On Error Resume Next
        With Me.NumOfExtruders
            If Val(.Text) < 1 Then .Text = "1"
            If Val(.Text) > 4 Then .Text = "4"
            Dim ExtNum = Val(.Text)
        End With
        With EnderMainForm
            Select Case CInt(Me.NumOfExtruders.Text)
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
                    .HotEnd1Check.Visible = True
                    .HotEnd2Check.Checked = False
                    .HotEnd2Check.Enabled = True
                    .HotEnd2Check.Visible = True
                    .HotEnd3Check.Checked = False
                    .HotEnd3Check.Enabled = True
                    .HotEnd3Check.Visible = True
                    .HotEnd4Check.Checked = False
                    .HotEnd4Check.Enabled = True
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
            '.HotEndActiveChk.Checked = True
        End With
    End Sub

    Private Sub HeatedBed_CheckedChanged(sender As Object, e As EventArgs) Handles HeatedBed.CheckedChanged
        With EnderMainForm
            .BedUpBut.Enabled = Me.HeatedBed.Checked
            .BedDnBut.Enabled = Me.HeatedBed.Checked
            .BedBox.Enabled = Me.HeatedBed.Checked
            .BedSend.Enabled = Me.HeatedBed.Checked
        End With
    End Sub

    Private Sub Auto_Level_CheckedChanged(sender As Object, e As EventArgs) Handles Auto_Level.CheckedChanged
        If Me.Auto_Level.Checked = True Then
            EnderMainForm.G29But.Enabled = True
            EnderMainForm.G29But.Visible = True
            EnderMainForm.G29But.Text = "Auto Level" & vbCr & My.Settings.AutoLevelCMD
            Me.AutoLevelCmdBox.Visible = True
            Me.AutoLevLab.Visible = True
            EnderMainForm.SetAutoLevBut.Visible = True
        Else
            EnderMainForm.G29But.Enabled = False
            EnderMainForm.G29But.Visible = False
            Me.AutoLevelCmdBox.Visible = False
            Me.AutoLevLab.Visible = False
            EnderMainForm.SetAutoLevBut.Visible = False
        End If
    End Sub

    Private Sub BedMaxY_TextChanged(sender As Object, e As EventArgs) Handles BedMaxY.TextChanged
        Me.PresPr_y.Text = Me.BedMaxY.Text
    End Sub

    Private Sub AutoLevelCmdBox_TextChanged(sender As Object, e As EventArgs) Handles AutoLevelCmdBox.TextChanged
        EnderMainForm.G29But.Text = "Auto Level" & vbLf & UCase(Me.AutoLevelCmdBox.Text)
        Me.AutoLevelCmdBox.Text = UCase(Me.AutoLevelCmdBox.Text)
        Me.AutoLevelCmdBox.Select(Me.AutoLevelCmdBox.Text.Length, Me.AutoLevelCmdBox.Text.Length)
        Me.AutoLevelCmdBox.ScrollToCaret()
    End Sub

    Private Sub AutoLevelCmdBox_Leave(sender As Object, e As EventArgs) Handles AutoLevelCmdBox.Leave
        Me.AutoLevelCmdBox.Text = UCase(Me.AutoLevelCmdBox.Text)
    End Sub

    Private Sub MaxPorts_TextChanged(sender As Object, e As EventArgs) Handles MaxPorts.TextChanged
        If Val(Me.MaxPorts.Text) > 256 Then Me.MaxPorts.Text = CStr(256)
    End Sub

    Public Sub HeatedBuildVolume_CheckedChanged(sender As Object, e As EventArgs) Handles HeatedBuildVolume.CheckedChanged
        On Error Resume Next
        If Me.HeatedBuildVolume.Checked = True Then
            EnderMainForm.TuneButtonPanel.Width = 713
            EnderMainForm.HBVLabel.Visible = True
            EnderMainForm.HBVBox.Visible = True
            EnderMainForm.HBVBox.Text = "25"
            EnderMainForm.HBVSendBut.Visible = True
        ElseIf Me.HeatedBuildVolume.Checked = False Then
            EnderMainForm.TuneButtonPanel.Width = 632
            EnderMainForm.HBVLabel.Visible = False
            EnderMainForm.HBVBox.Visible = False
            EnderMainForm.HBVBox.Text = "0"
            EnderMainForm.HBVSendBut.Visible = False
        End If
    End Sub

    Private Sub PortBaud_TextChanged(sender As Object, e As EventArgs) Handles PortBaud.TextChanged
        If Val(Me.PortBaud.Text) <= 0 Then Me.PortBaud.Text = "9600"
    End Sub

    Private Sub RetractBox_TextChanged(sender As Object, e As EventArgs) Handles RetractBox.TextChanged
        EnderMainForm.Box_E_Retract.Text = Me.RetractBox.Text
    End Sub
End Class