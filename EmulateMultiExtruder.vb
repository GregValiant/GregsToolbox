Imports System.ComponentModel

Public Class EmulateMultiExtruder
    Private Sub CancelEBut_Click(sender As Object, e As EventArgs) Handles CancelEBut.Click
        EnderMainForm.PrResponse = False
        Me.Hide()
    End Sub

    Private Sub T1But_CheckedChanged(sender As Object, e As EventArgs) Handles T1But.CheckedChanged
        With Me
            If .T1But.Checked = True Then
                .T2MessageBox.Visible = False
                .T2MessageLabel.Visible = False
                .E3PrintTemp.Visible = False
                .E3PrLab.Visible = False
                .T3MessageBox.Visible = False
                .T3MessageLabel.Visible = False
                .E4PrintTemp.Visible = False
                .E4PrLab.Visible = False
                .Preview3opt.Enabled = False
                .Preview4opt.Enabled = False
            End If
        End With
    End Sub

    Private Sub T2But_CheckedChanged(sender As Object, e As EventArgs) Handles T2But.CheckedChanged
        With Me
            If .T2But.Checked = True Then
                .T2MessageBox.Visible = True
                .T2MessageLabel.Visible = True
                .E3PrintTemp.Visible = True
                .E3PrLab.Visible = True
                .T3MessageBox.Visible = False
                .T3MessageLabel.Visible = False
                .E4PrintTemp.Visible = False
                .E4PrLab.Visible = False
                .Preview3opt.Enabled = True
                .Preview4opt.Enabled = False
            End If
        End With
    End Sub

    Private Sub T3But_CheckedChanged(sender As Object, e As EventArgs) Handles T3But.CheckedChanged
        With Me
            If .T3But.Checked = True Then
                .T2MessageBox.Visible = True
                .T2MessageLabel.Visible = True
                .E3PrLab.Visible = True
                .E3PrintTemp.Visible = True
                .T3MessageBox.Visible = True
                .T3MessageLabel.Visible = True
                .E4PrintTemp.Visible = True
                .E4PrLab.Visible = True
                .Preview3opt.Enabled = True
                .Preview4opt.Enabled = True
            End If
        End With
    End Sub

    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles CreateButton.Click
        EnderMainForm.PrResponse = True
        Me.Hide()
    End Sub

    Private Sub ParkHeadChk_CheckedChanged(sender As Object, e As EventArgs) Handles ParkHeadChk.CheckedChanged
        If Me.ParkHeadChk.Checked = True Then
            Me.ParkHeadXbox.Enabled = True
            Me.ParkHeadYbox.Enabled = True
        Else
            Me.ParkHeadXbox.Enabled = False
            Me.ParkHeadYbox.Enabled = False
        End If
    End Sub

    Private Sub AddM117MsgChk_CheckedChanged(sender As Object, e As EventArgs) Handles AddM117MsgChk.CheckedChanged
        If Me.AddM117MsgChk.Checked = True Then
            Me.T0MessageBox.Enabled = True
            Me.T1MessageBox.Enabled = True
            Me.T2MessageBox.Enabled = True
            Me.T3MessageBox.Enabled = True
        Else
            Me.T0MessageBox.Enabled = False
            Me.T1MessageBox.Enabled = False
            Me.T2MessageBox.Enabled = False
            Me.T3MessageBox.Enabled = False
        End If
    End Sub

    Private Sub PreviewBut_Click(sender As Object, e As EventArgs) Handles PreviewBut.Click
        Dim ExtruderCt As Integer = 2
        Dim M84Line As String = ""
        Dim PauseCmd As String = ""
        Dim ExtMD As String = ""
        Dim ParkHD As Boolean = False
        Dim ParkX As String = ""
        Dim ParkY As String = ""
        Dim ParkString = ""
        Dim T0msg As String = ""
        Dim T1msg As String = ""
        Dim T2msg As String = ""
        Dim T3msg As String = ""
        Dim GcodeAfterString As String = ""
        Dim ChangeTemperature As Boolean = False
        With Me
            If .T1But.Checked = True Then ExtruderCt = 2
            If .T2But.Checked = True Then ExtruderCt = 3
            If .T3But.Checked = True Then ExtruderCt = 4
            If .TimeOutBox.Text <> "" Then
                M84Line = "M84 S" & Val(.TimeOutBox.Text) * 60
            End If
            PauseCmd = .PauseCmdBox.Text
            If .M82OptBut.Checked Then
                ExtMD = "M82"
            Else
                ExtMD = "M83"
            End If
            ParkHD = .ParkHeadChk.Checked
            ParkX = .ParkHeadXbox.Text
            ParkY = .ParkHeadYbox.Text
            If ParkHD Then
                ParkString = "G0 X" & ParkX & " Y" & ParkY & " F7200 ;Move to park position"
            End If
            If .T0MessageBox.Text <> "" Then
                T0msg = "M117 " & .T0MessageBox.Text & " ;send to LCD" & vbCrLf & "M118 " & .T0MessageBox.Text & " ;send to print server"
            End If
            If .T1MessageBox.Text <> "" Then
                T1msg = "M117 " & .T1MessageBox.Text & " ;send to LCD" & vbCrLf & "M118 " & .T1MessageBox.Text & " ;send to print server"
            End If
            If .T2MessageBox.Text <> "" Then
                T2msg = "M117 " & .T2MessageBox.Text & " ;send to LCD" & vbCrLf & "M118 " & .T2MessageBox.Text & " ;To print server"
            End If
            If .T3MessageBox.Text <> "" Then
                T3msg = "M117 " & .T3MessageBox.Text & " ;send to LCD" & vbCrLf & "M118 " & .T3MessageBox.Text & " ;send to print server"
            End If
            If .GcodeAfterBox.Text <> "" Then
                GcodeAfterString = Strings.Replace(.GcodeAfterBox.Text, ",", vbCrLf, 1, -1)
                GcodeAfterString = Strings.UCase(GcodeAfterString)
            End If
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
            Dim PreviewString = ";" & vbCrLf
        If Me.Preview1opt.Checked = True Then PreviewString &= ";T0 Tool Change replacement code" & vbCrLf
        If Me.Preview2opt.Checked = True Then PreviewString &= ";T1 Tool Change replacement code" & vbCrLf
        If Me.Preview3opt.Checked = True Then PreviewString &= ";T2 Tool Change replacement code" & vbCrLf
        If Me.Preview4opt.Checked = True Then PreviewString &= ";T3 Tool Change replacement code" & vbCrLf
        PreviewString &= M84Line & ";Stepper timeout" & vbCrLf &
            "G91 ;Relative positioning" & vbCrLf &
            "M83 ;Relative extrusion" & vbCrLf
        If Me.AddRetractChk.Checked Then PreviewString &= "G1 F1800 E-" & Me.AddRetractAmountBox.Text & "    ;Retraction" & vbCrLf
        PreviewString &= "G1 F600 Z10 ;Move Up" & vbCrLf &
            "G90 ;Absolute movement" & vbCrLf &
            ParkString & vbCrLf
        If Me.AddM117MsgChk.Checked Then
            If Me.Preview1opt.Checked = True Then
                PreviewString &= T0msg & vbCrLf
            ElseIf Me.Preview2opt.Checked = True Then
                PreviewString &= T1msg & vbCrLf
            ElseIf Me.Preview3opt.Checked = True Then
                PreviewString &= T2msg & vbCrLf
            Else
                PreviewString &= T3msg & vbCrLf
            End If
        End If
        If Me.BeepBox.Checked = True Then PreviewString &= "M300 ;Beep" & vbCrLf
        If ChangeTemperature Then
            If Me.Preview1opt.Checked = True Then
                PreviewString &= "M118 Wait for temperature change" & vbCrLf &
                    "M109 R" & Me.E1PrintTemp.Text & vbCrLf
            ElseIf Me.Preview2opt.Checked = True Then
                PreviewString &= "M118 Wait for temperature change" & vbCrLf &
                    "M109 R" & Me.E2PrintTemp.Text & vbCrLf
            ElseIf Me.Preview3opt.Checked = True Then
                PreviewString &= "M118 Wait for temperature change" & vbCrLf &
                "M109 R" & Me.E3PrintTemp.Text & vbCrLf
            Else
                PreviewString &= "M118 Wait for temperature change" & vbCrLf &
                    "M109 R" & Me.E4PrintTemp.Text & vbCrLf
            End If
        End If
        PreviewString &= PauseCmd & vbCrLf
        If GcodeAfterString <> "" Then PreviewString &= GcodeAfterString & vbCrLf
        PreviewString &= ";G1 F7200 X? Y?  ;""Return To"" XY location (If required).  It's the last XY location before the pause." & vbCrLf &
            ";G1 F600 Z?   ""Return to"" Z location (if required).  It Is the last Z location before the pause." & vbCrLf &
            ExtMD & " ;Reset extrusion type (absolute Or relative)" & vbCrLf &
            ";End of Tool Change code" & vbCrLf &
            ";"
        With EnderMainForm.TextBox1
            .Text = PreviewString
            .Text &= vbCr
            .ScrollToCaret()
            .Refresh()
        End With
    End Sub

    Private Sub HelpBut_Click(sender As Object, e As EventArgs) Handles HelpBut.Click
        MsgBox("Cura Slicing Settings:" & vbCr &
"- Up to 4 extruders are allowed." & vbCr &
"- In Printer Settings ""Extruders Share Heater"" and ""Extruders Share Nozzle"" must be checked." & vbCr &
"- All extruders must have ""Nozzle Switch Retraction Distance"" set to 0." & vbCr &
"- Consider using the purge tower." & vbCr &
"- M109's and M104's past the ""Layer:0"" line will be commented out." & vbCr &
"- If the filament temperatures are different then ""M109 R"" lines will be added after parking the head." & vbCr & vbCr &
"You can use the LCD message for each extruder to indicate the filament color to change to.  (The M0 command will overwrite the LCD)." & vbCr & vbCr &
"The ""Gcode After Pause"" is comma delimited." & vbCr &
"Example: M105,M204 X8 Y8,M106 S255,M104 S205", vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub EmulateMultiExtruder_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'EnderMainForm.PrResponse = False
        e.Cancel = True
    End Sub

    Private Sub AddRetractChk_CheckedChanged(sender As Object, e As EventArgs) Handles AddRetractChk.CheckedChanged
        With Me
            If .AddRetractChk.Checked Then
                .AddRetractAmountBox.Enabled = True
                .RetractLabel.Enabled = True
            Else
                .AddRetractAmountBox.Enabled = False
                .RetractLabel.Enabled = False
            End If
        End With
    End Sub

    Private Sub TimeOutBox_TextChanged(sender As Object, e As EventArgs) Handles TimeOutBox.TextChanged
        If Val(Me.TimeOutBox.Text) > 240 Then
            MsgBox("The Maximum of most printers is 240 minutes (4 hours).", vbOKOnly, "Greg's Toolbox")
            Me.TimeOutBox.Text = "240"
        End If
    End Sub
End Class