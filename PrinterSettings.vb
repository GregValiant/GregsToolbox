Public Class PrinterSettings
    Private Sub CBGetSettings_Click(sender As Object, e As EventArgs) Handles CBGetSettings.Click
        EnderMainForm.ClearResponseButt.Checked = False
        StrToSend = "M503"
        EnderMainForm.TextBox1.Text = ""
        FormsModule.RecvStr = ""
        SendTheString(StrToSend)

    End Sub

    Private Sub CBSetsteps_Click(sender As Object, e As EventArgs) Handles CBSetsteps.Click
        StrToSend = "M92 X" & Me.StepsX.Text & " Y" & Me.StepsY.Text & " Z" & Me.StepsZ.Text & " E" & Me.StepsE.Text
        SendTheString(StrToSend)
    End Sub

    Private Sub CBSaveSteps_Click(sender As Object, e As EventArgs) Handles CBSaveSteps.Click
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("Are you sure you want to overwrite the Steps/mm and/or PID?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then
            Exit Sub
        Else
            StrToSend = "M500"
            SendTheString(StrToSend)
        End If
    End Sub

    Private Sub CBGetSteps_Click(sender As Object, e As EventArgs) Handles CBGetSteps.Click
        Call ParseTheStringSteps()
        With Me
            .CalcXopt.Checked = True
            .CalcStepsBox.Text = .StepsX.Text
        End With
    End Sub

    Private Sub CalcXopt_CheckedChanged(sender As Object, e As EventArgs) Handles CalcXopt.CheckedChanged
        With Me
            If .CalcXopt.Checked = True Then
                .CalcStepsBox.Text = .StepsX.Text
            End If
        End With
    End Sub

    Private Sub CalcYopt_CheckedChanged(sender As Object, e As EventArgs) Handles CalcYopt.CheckedChanged
        With Me
            If .CalcYopt.Checked = True Then
                .CalcStepsBox.Text = .StepsY.Text
            End If
        End With
    End Sub

    Private Sub CalcZopt_CheckedChanged(sender As Object, e As EventArgs) Handles CalcZopt.CheckedChanged
        With Me
            If .CalcZopt.Checked = True Then
                .CalcStepsBox.Text = .StepsZ.Text
            End If
        End With
    End Sub

    Private Sub CalcEopt_CheckedChanged(sender As Object, e As EventArgs) Handles CalcEopt.CheckedChanged
        With Me
            If .CalcEopt.Checked = True Then
                .CalcStepsBox.Text = .StepsE.Text
            End If
        End With
    End Sub

    Private Sub CalcCaliButt_Click(sender As Object, e As EventArgs) Handles CalcCaliButt.Click
        On Error GoTo EHandler
        If Me.CalcMeasureBox.Text = "" Or Me.CalcTargetBox.Text = "" Then
            MsgBox("The ""Measured"" box can't be empty", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Dim Target As Single, Measurement As Single, CurrSteps As Single, NewSteps As Single
        With Me
            Target = CSng(.CalcTargetBox.Text)
            Measurement = CSng(.CalcMeasureBox.Text)
            CurrSteps = CSng(.CalcStepsBox.Text)
            NewSteps = CSng(Format((Target / Measurement) * CurrSteps, "0.00"))
            .CalcNewStepsBox.Text = CStr(NewSteps)
        End With
        Exit Sub
EHandler:
        MsgBox("There was an error in ""PrinterSettings.CalcCaliButt_Click"".  Make sure your numbers are correct." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub CopyStepsBut_Click(sender As Object, e As EventArgs) Handles CopyStepsBut.Click
        On Error Resume Next
        Dim Aresponse = MsgBox("Are you sure you want to over-write the steps/mm?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Greg's Toolbox")
        If Aresponse = vbNo Then Exit Sub
        If Me.CalcXopt.Checked = True Then
            Me.StepsX.Text = Me.CalcNewStepsBox.Text
        ElseIf Me.CalcYopt.Checked = True Then
            Me.StepsY.Text = Me.CalcNewStepsBox.Text
        ElseIf Me.CalcZopt.Checked = True Then
            Me.StepsZ.Text = Me.CalcNewStepsBox.Text
        ElseIf Me.CalcEopt.Checked = True Then
            Me.StepsE.Text = Me.CalcNewStepsBox.Text
        End If
    End Sub

    Private Sub CBFindPID_Click(sender As Object, e As EventArgs) Handles CBFindPID.Click
        Call ParseTheStringPID()
    End Sub

    Private Sub CBSetPID_Click(sender As Object, e As EventArgs) Handles CBSetPID.Click
        Dim PIDPstr As String
        Dim PIDIstr As String
        Dim PIDDstr As String
        With Me
            If .PIDP.Text <> "" Then
                PIDPstr = " P" & .PIDP.Text
            Else
                PIDPstr = ""
            End If
            If .PIDI.Text <> "" Then
                PIDIstr = " I" & .PIDI.Text
            Else
                PIDIstr = ""
            End If
            If .PIDD.Text <> "" Then
                PIDDstr = " D" & .PIDD.Text
            Else
                PIDDstr = ""
            End If
        End With
        If PIDPstr = "" And PIDIstr = "" And PIDDstr = "" Then Exit Sub
        StrToSend = "M301" & PIDPstr & PIDIstr & PIDDstr
        SendTheString(StrToSend)
    End Sub

    Private Sub CBAutoTune_Click(sender As Object, e As EventArgs) Handles CBAutoTune.Click
        Dim AResponse = MsgBox("Auto-Tune will cycle about " & Me.AutoTuneTemp.Text & "° - " & Me.AutoTuneReps.Text & " times.  When it finishes you can copy the information from the bottom of the printer response box and paste it into the PID boxes.", vbOKCancel, "Greg's Toolbox")
        If AResponse = vbCancel Then Exit Sub
        AllResponses = False
        EnderMainForm.ClearResponseButt.Checked = True
        EnderMainForm.ClearResponseButt.Text = "Single Response"
        EnderMainForm.TextBox1.Text = ""
        StrToSend = "M303 E0 S" & Me.AutoTuneTemp.Text & " C" & Me.AutoTuneReps.Text
        SendTheString(StrToSend)
    End Sub

    Private Sub CBFindOffset_Click(sender As Object, e As EventArgs) Handles CBFindOffset.Click
        Call ParseTheStringOffset()
        My.Settings.HomeOffsetX = Me.OffsetXbox.Text
        My.Settings.HomeOffsetY = Me.OffsetYbox.Text
        My.Settings.HomeOffsetZ = Me.OffsetZbox.Text
    End Sub

    Private Sub OffsetSendButton_Click(sender As Object, e As EventArgs) Handles OffsetSendButton.Click
        Dim Xval = Me.OffsetXbox.Text
        Dim Yval = Me.OffsetYbox.Text
        Dim Zval = Me.OffsetZbox.Text
        If Xval = "" Or Yval = "" Or Zval = "" Then
            MsgBox("All three offset numbers have to be entered", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        StrToSend = "M206 X" & Xval & " Y" & Yval & " Z" & Zval
        SendTheString(StrToSend)
        My.Settings.HomeOffsetX = Xval
        My.Settings.HomeOffsetY = Yval
        My.Settings.HomeOffsetZ = Zval
    End Sub

    Private Sub M145Butt_Click(sender As Object, e As EventArgs) Handles M145Butt.Click
        Dim BedStr As String
        Dim HotStr As String
        Dim FanStr As String
        Dim MatlStr As String
        With Me
            If .OptionBedBox.Text = "" Then
                BedStr = ""
            Else
                BedStr = " B" & .OptionBedBox.Text
            End If
            If .OptionHotBox.Text = "" Then
                HotStr = ""
            Else
                HotStr = " H" & .OptionHotBox.Text
            End If
            If .OptionFanBox.Text = "" Then
                FanStr = ""
            Else
                FanStr = " F" & Val(.OptionFanBox.Text) * 2.55
            End If
            If .OptionABS.Checked = True Then
                MatlStr = " S1"
            Else
                MatlStr = " S0"
            End If
            StrToSend = "M145" & MatlStr & HotStr & BedStr & FanStr
            SendTheString(StrToSend)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CBLoadAccelJerk_Click(sender As Object, e As EventArgs) Handles CBLoadAccelJerk.Click
        If Strings.InStr(EnderMainForm.TextBox1.Text, "M503") = 0 Then
            Dim response = MsgBox("The Main Form PRINTER RESPONSE BOX must have the ""M503"" information in it.", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            Exit Sub
        End If
        Try
            'M201Str Accel X and Y
            'M204Str Accel P and T
            'M205Str Jerk X and Y or JD
            Dim M503str = EnderMainForm.TextBox1.Text
            Dim M201Str As String
            Dim M201strEnd As Integer
            Dim Location = InStr(M503str, "M201")
            If Location > 0 Then
                M201Str = Strings.Right(M503str, Len(M503str) - Location - 4)
                M201strEnd = InStr(M201Str, vbCrLf)
                M201Str = Strings.Mid(M201Str, 2, M201strEnd - 2)
            Else
                M201str = ""
            End If
            Dim M204Str As String
            Dim M204StrEnd As Integer
            Location = InStr(M503str, "M204")
            If Location > 0 Then
                M204Str = Strings.Right(M503str, Len(M503str) - Location - 4)
                M204StrEnd = InStr(M204Str, vbCrLf)
                M204Str = Strings.Mid(M204Str, 2, M204strEnd - 2)
            Else
                M204str = ""
            End If
            Dim M205Str As String
            Dim M205StrEnd As Integer
            Location = InStr(M503str, "M205")
            If Location > 0 Then
                M205Str = Strings.Right(M503str, Len(M503str) - Location - 4)
                M205StrEnd = InStr(M205Str, vbCrLf)
                M205Str = Strings.Mid(M205Str, 2, M205strEnd - 2)
            Else
                M205Str = ""
            End If
            Dim EndLoc = InStr(M201Str, " ")
            Dim DefaultXA = Strings.Mid(M201Str, 1, EndLoc - 1)

            Dim YLoc = InStr(M201Str, " Y")
            Dim Ystr = Strings.Right(M201Str, Len(M201Str) - Strings.InStr(M201Str, " ") - 1)

            EndLoc = InStr(Ystr, " ")
            Dim DefaultYA = Strings.Left(Ystr, EndLoc)


            My.Settings.DefaultXAccel = DefaultXA
            Me.XAccelBox.Text = DefaultXA
            My.Settings.DefaultYAccel = DefaultYA
            Me.YAccelBox.Text = DefaultYA

            'Location = InStr(M503str, "M205")
            'Dim M205Str As String = Strings.Right(M503str, Len(M503str) - Location - 4)
            'M205Str = Strings.Left(M205Str, InStr(M205Str, vbCrLf) - 1)
            Dim JLoc As Integer = InStr(M205Str, " J")
            Dim DefaultXJ = ""
            Dim DefaultYJ = ""
            Dim Xloc = 0
            YLoc = 0
            If JLoc > 0 Then
                Xloc = InStr(M205Str, " J")
                EndLoc = InStr(M205Str, " Z")
                M205Str = Strings.Mid(M205Str, Xloc + 2, EndLoc - Xloc - 2)
                Me.XJerkBox.Text = ""
                Me.XJerkBox.Visible = False
                Me.XJerkLab.Visible = False
                My.Settings.DefaultXJerk = ""
                Me.YJerkBox.Text = ""
                Me.YJerkBox.Visible = False
                Me.YJerkLab.Visible = False
                My.Settings.DefaultYJerk = ""
                Me.JuncDevBox.Text = M205Str
                Me.JuncLab.Visible = True
                Me.JuncDevBox.Visible = True
                Me.CBSetAccelJerk.Text = "Send Accel + Junc Dev"
                My.Settings.JunctionDeviation = M205Str
            ElseIf JLoc = 0 Then
                Xloc = InStr(M205Str, " X")
                EndLoc = InStr(M205Str, " Z")
                M205Str = Strings.Mid(M205Str, Xloc + 2, EndLoc - Xloc - 2)
                YLoc = InStr(M205Str, " Y")
                DefaultYJ = Strings.Right(M205Str, Len(M205Str) - YLoc - 1)
                DefaultXJ = Strings.Left(M205Str, YLoc - 1)
                My.Settings.DefaultXJerk = DefaultXJ
                Me.XJerkBox.Text = DefaultXJ
                Me.XJerkBox.Visible = True
                Me.XJerkLab.Visible = True
                My.Settings.DefaultYJerk = DefaultYJ
                Me.YJerkBox.Text = DefaultYJ
                Me.YJerkBox.Visible = True
                Me.YJerkLab.Visible = True
                Me.JuncDevBox.Visible = False
                Me.JuncLab.Visible = False
                Me.CBSetAccelJerk.Text = "Send Accel + Jerk"
                My.Settings.JunctionDeviation = ""
            End If
            Dim DefaultPA = ""
            Dim DefaultTA = ""
            Xloc = 0
            YLoc = 0
            If M204Str <> "" Then
                Xloc = InStr(M204Str, " R")
                DefaultPA = Strings.Left(M204Str, Xloc - 1)
                Xloc = InStr(M204Str, " T")
                DefaultTA = Strings.Right(M204Str, Len(M204Str) - Xloc - 1)
                Me.PAccelBox.Text = DefaultPA
                My.Settings.DefaultPAccel = DefaultPA
                Me.TAccelBox.Text = DefaultTA
                My.Settings.DefaultTAccel = DefaultTA
            End If
        Catch
            Dim AResponse As MsgBoxResult
            AResponse = MsgBox("There was an error attempting to retrieve the current Accel and Jerk/JD values.  The information is in the Printer Response box. _
You can transfer them to the Printer Settings manually." & vbCr & "Select YES to use ""Jerk"".  Select NO to use ""JunctionDeviation""", CType(vbYesNoCancel + vbInformation, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then
                Me.XJerkBox.Text = ""
                Me.XJerkBox.Visible = False
                Me.XJerkLab.Visible = False
                My.Settings.DefaultXJerk = ""
                Me.YJerkBox.Text = ""
                Me.YJerkBox.Visible = False
                Me.YJerkLab.Visible = False
                My.Settings.DefaultYJerk = ""
                Me.JuncDevBox.Text = ""
                Me.JuncLab.Visible = True
                Me.JuncDevBox.Visible = True
                Me.CBSetAccelJerk.Text = "Send Accel + Junc Dev"
                My.Settings.JunctionDeviation = ""
                Exit Sub
            ElseIf AResponse = vbYes Then
                Me.XJerkBox.Text = ""
                Me.XJerkBox.Visible = True
                Me.XJerkLab.Visible = True
                My.Settings.DefaultXJerk = ""
                Me.YJerkBox.Text = ""
                Me.YJerkBox.Visible = True
                Me.YJerkLab.Visible = True
                My.Settings.DefaultYJerk = ""
                Me.JuncDevBox.Text = ""
                Me.JuncLab.Visible = False
                Me.JuncDevBox.Visible = False
                Me.CBSetAccelJerk.Text = "Send Accel + Jerk"
                My.Settings.JunctionDeviation = ""
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub CBSetAccelJerk_Click(sender As Object, e As EventArgs) Handles CBSetAccelJerk.Click
        On Error Resume Next
        Dim firstStrToSend As String = ""
        Dim secondStrToSend As String = ""
        If EnderMainForm.Vcomm.IsOpen Then
            firstStrToSend = "M201 X" & Me.XAccelBox.Text & " Y" & Me.YAccelBox.Text
            SendTheString(firstStrToSend)
            If Me.JuncDevBox.Visible = False Then
                secondStrToSend = "M205 X" & Me.XJerkBox.Text & " Y" & Me.YJerkBox.Text
            Else
                secondStrToSend = "M205 J" & Me.JuncDevBox.Text
            End If
            SendTheString(secondStrToSend)
            StrToSend = "M204 P" & Me.PAccelBox.Text & " T" & Me.TAccelBox.Text
            SendTheString(StrToSend)
        Else
            MsgBox("The port is closed", CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        End If
        With My.Settings
            If Me.XAccelBox.Text <> "" Then .DefaultXAccel = Me.XAccelBox.Text
            If Me.YAccelBox.Text <> "" Then .DefaultYAccel = Me.YAccelBox.Text
            If Me.PAccelBox.Text <> "" Then .DefaultPAccel = Me.PAccelBox.Text
            If Me.TAccelBox.Text <> "" Then .DefaultTAccel = Me.TAccelBox.Text
            If Me.XJerkBox.Text <> "" Then .DefaultXJerk = Me.XJerkBox.Text
            If Me.YJerkBox.Text <> "" Then .DefaultYJerk = Me.YJerkBox.Text
            If Me.JuncDevBox.Text <> "" Then .JunctionDeviation = Me.JuncDevBox.Text
        End With
    End Sub

    Private Sub FactResetBut_Click(sender As Object, e As EventArgs) Handles FactResetBut.Click
        Dim AResponse = MsgBox("This will revert all the settings in the Printer to factory defaults.  Steps/mm, PID, etc. will be changed to the ""As Delivered"" values." & vbLf & vbLf &
                                "Are you sure you want to do this?", CType(vbYesNo + vbCritical, MsgBoxStyle), "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        StrToSend = "M502"
        SendTheString(StrToSend)
        StrToSend = "M503"
        SendTheString(StrToSend)
        MsgBox("The reset command has been sent but the changes have not yet been saved.  Review the information in the Printer Response box and if you are " &
"happy with it use the Save button to confirm the changes.  If you want to revert back to the previous settings then close the Com Port and " &
"cycle the printer OFF and ON", vbOKOnly, "Greg's Toolbox")
    End Sub

    Private Sub ExtrCalibrateEBut_Click(sender As Object, e As EventArgs) Handles ExtrCalibrateEBut.Click
        On Error GoTo EHandler
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("This will extrude the target amount { " & Me.CalcTargetBox.Text & "mm } of filament." & vbCr & vbCr & "The filament must be free to extrude (no nozzle)" &
                            vbCr & vbCr & "Do you wish to continue?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbNo Then Exit Sub
        Dim ErrAmount = (Val(Me.CalcTargetBox.Text))
        If ErrAmount = 0 Or Me.CalcTargetBox.Text = "" Then
            MsgBox("The Target amount of filament must be a number", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        SendTheString("M83")
        SendTheString("M302 S0")
        SendTheString("G1 S2100 E" & Me.CalcTargetBox.Text)
        SendTheString("M302 S175")
        SendTheString("M82")
        Exit Sub
EHandler:
        MsgBox("There was an error in ""PrinterSettings.ExtrCalibrateEBut_Click"".  " & Err.Description, vbOKOnly, "Greg's Toolbox")
    End Sub
End Class