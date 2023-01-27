Imports System.ComponentModel

Public Class RacingForm
    Public Staged As Boolean
    Public PreStart As Boolean = False
    Public DoubleDist As Integer = 1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles StagedBut.Click
        On Error Resume Next
        If Not EnderMainForm.Vcomm.IsOpen Then
            MsgBox("The port is closed.  This command will end.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        If PreStart Then
            If InStr(EnderMainForm.TextBox1.Text, "M201") > 0 Then
                Call GetJerk()
                PreStart = False
            Else
                MsgBox("The Printer Response box must contain ""M503"" information", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
        End If
        If (Me.AccelXBox.Value = 0 Or Me.AccelYBox.Value = 0) And Me.VelocityBox.Value >= 100 Then
            Dim AResponse = MsgBox("You have elected to operate at HIGH SPEED with NO ACCELERATION CONTROL.  The machine will hit hard at each direction change.  Running the printer this HARD and FAST can cause damage to the printer.  High end printers may handle it.  Others may not." & vbLf & vbLf &
                                    "Do you want to continue?", CType(vbYesNo + vbCritical, MsgBoxStyle), "Greg's Toolbox")
            If AResponse = vbNo Then Exit Sub
        End If
        StrToSend = "G0 Z15 F1200"
        SendTheString(StrToSend)
        StrToSend = "G0 X0 Y0 F3000"
        SendTheString(StrToSend)
        If My.Settings.JunctionDeviation = "" Then
            SendTheString("M205 X" & Me.JerkXBox.Value & " Y" & Me.JerkYBox.Value)
        Else
            SendTheString("M205 J" & Me.JerkXBox.Value)
        End If
        If Me.AccelXBox.Value >= Me.AccelYBox.Value Then
            StrToSend = CStr(Me.AccelXBox.Value)
        Else
            StrToSend = CStr(Me.AccelYBox.Value)
        End If
        SendTheString("M204 P" & StrToSend & " T" & StrToSend)
        SendTheString("M201 X" & Me.AccelXBox.Value & " Y" & Me.AccelYBox.Value)
        Staged = True
        If Me.DoubleDistBox.Checked Then DoubleDist = 2
        Me.GoBut.Enabled = True
        Me.GoBut.Text = "Green Flag"
        Me.GoBut.BackColor = Color.LawnGreen
        Me.StagedBut.Text = "Qualified"
    End Sub

    Private Sub CloseBut_Click(sender As Object, e As EventArgs) Handles CloseBut.Click
        If EnderMainForm.Vcomm.IsOpen Then
            StrToSend = "M201 X" & My.Settings.DefaultXAccel & " Y" & My.Settings.DefaultYAccel
            SendTheString(StrToSend)
            If My.Settings.JunctionDeviation = "" Then
                StrToSend = "M205 X" & My.Settings.DefaultXJerk & " Y" & My.Settings.DefaultYJerk
                SendTheString(StrToSend)
            Else
                StrToSend = "M205 J" & My.Settings.DefaultXJerk
                SendTheString(StrToSend)
            End If
            StrToSend = "M204 P" & My.Settings.DefaultPAccel & " T" & My.Settings.DefaultTAccel
            SendTheString(StrToSend)
        End If
        Me.Hide()
    End Sub

    Private Sub GoBut_Click(sender As Object, e As EventArgs) Handles GoBut.Click
        On Error Resume Next
        Dim L As Integer
        EnderMainForm.TextBox1.Text = ""
        If Staged = False Then
            MsgBox("Use the ""Staged - Prepare to Race"" button to move the print head to X0, Y0, Z15 and to send the Acceleration and Jerk settings to the printer.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        If Me.VelocityBox.Text = "" Or Me.MaxX.Text = "" Or Me.MaxY.Text = "" Then
            MsgBox("The Speed, MaxX and MaxY cannot be empty.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim Trap As New Stopwatch
        EnderMainForm.TextBox1.Text = ""
        Dim MyV = Val(Me.VelocityBox.Value) * 60
        If Me.DragRace.Checked = True Then
            Trap.Reset()
            If Me.BeepControl.Checked Then SendTheString("M300")
            Trap.Start()
            For Lap = 1 To DoubleDist
                SendTheString("G0 X" & Me.MaxX.Text & " Y" & Me.MaxY.Text & " F" & MyV)
                SendTheString("G0 X0 Y0")
                SendTheString("M400")
            Next Lap
            SendTheString("End Race")
            Do Until InStr(1, EnderMainForm.TextBox1.Text, "End Race") > 0
                Application.DoEvents()
            Loop
            Trap.Stop()
            Dim ET = Trap.ElapsedMilliseconds
            Dim CourseLength = Me.CourseLength.Text
            Me.ETBox.Text = Format(ET / 1000, "0.00")
            Me.SpeedBox.Text = Format(CDbl(CourseLength) / (ET / 1000), "0.0")
            Me.MMperMIN.Text = CStr(Int(60 * Val(Me.SpeedBox.Text)))
            Exit Sub
        ElseIf Me.NascarRace.Checked = True Then
            Trap.Reset()
            If Me.BeepControl.Checked Then SendTheString("M300")
            Trap.Start()
            For Lap = 1 To DoubleDist
                StrToSend = "G0 X" & Me.MaxX.Text & " F" & MyV
                SendTheString(StrToSend)
                StrToSend = "G0 Y" & Me.MaxY.Text
                SendTheString(StrToSend)
                StrToSend = "G0 X0"
                SendTheString(StrToSend)
                StrToSend = "G0 Y0"
                SendTheString(StrToSend)
                SendTheString("M400")
            Next Lap
            SendTheString("End Race")
            Do Until InStr(1, EnderMainForm.TextBox1.Text, "End Race") > 0
                Application.DoEvents()
            Loop
            Trap.Stop()
            Dim ET = Trap.ElapsedMilliseconds
            Dim CourseLength = Val(Me.CourseLength.Text)
            Dim AvgSpeed = CourseLength / (ET / 1000)
            Me.CourseLength.Text = Format(CourseLength, "0.00")
            Me.ETBox.Text = Format(ET / 1000, "0.00")
            Me.SpeedBox.Text = Format(CourseLength / (ET / 1000), "0.00")
            Me.MMperMIN.Text = CStr(Int(60 * Val(Me.SpeedBox.Text)))
            Exit Sub
        ElseIf Me.DemoRace.Checked = True Then
            Trap.Reset()
            If Me.BeepControl.Checked Then SendTheString("M300")
            Trap.Start()
            For Lap = 1 To DoubleDist
                SendTheString("G0 X" & Me.MaxX.Text & " F" & MyV)
                SendTheString("G0 X0 Y" & Me.MaxY.Text)
                SendTheString("G0 X" & MaxX.Text)
                SendTheString("G0 X0 Y0")
                SendTheString("M400")
            Next Lap
            SendTheString("End Race")
            Do Until InStr(1, EnderMainForm.TextBox1.Text, "End Race") > 0
                Application.DoEvents()
            Loop
            Trap.Stop()
            Dim ET = Trap.ElapsedMilliseconds
            Dim CourseLength = Val(Me.CourseLength.Text)
            Me.ETBox.Text = Format(ET / 1000, "0.00")
            Me.SpeedBox.Text = Format(CourseLength / (ET / 1000), "0.00")
            Me.MMperMIN.Text = CStr(Int(60 * Val(Me.SpeedBox.Text)))
            Exit Sub
        ElseIf Me.F1Race.Checked = True Then
            'For N = 1 To DoubleDist Step 1
            Dim HalfY = Val(MaxY.Text) * 0.5
            Dim X1 = Val(MaxX.Text) * 0.125
            Dim X2 = Val(MaxX.Text) * 0.25
            Dim X3 = Val(MaxX.Text) * 0.375
            Dim X4 = Val(MaxX.Text) * 0.5
            Dim X5 = Val(MaxX.Text) * 0.625
            Dim X6 = Val(MaxX.Text) * 0.75
            Dim X7 = Val(MaxX.Text) * 0.875
            Dim X8 = Val(MaxX.Text)
            Dim Speed = Me.VelocityBox.Value
            Dim Accel = Me.AccelXBox.Value
            Dim SWait = Int((((Speed / Accel) * 2) + (((Math.Sqrt((Val(MaxX.Text) * 0.125) ^ 2 + (Val(MaxY.Text) / 2) ^ 2)) - (((Speed / Accel) * Speed / 2) * 2)) / Speed)) * 1000 * 0.8)
            Dim LWait = Int((((Speed / Accel) * 2) + (((Math.Sqrt((Val(MaxX.Text) * 0.5) ^ 2 + (Val(MaxY.Text) / 2) ^ 2)) - (((Speed / Accel) * Speed / 2) * 2)) / Speed)) * 1000 * 0.8)
            Trap.Reset()
            If Me.BeepControl.Checked Then SendTheString("M300")
            Trap.Start()
            SendTheString("G0 X" & X1 & " Y" & HalfY & " F" & MyV)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X2 & " Y0")
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X3 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X4 & " Y0")
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X5 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X6 & " Y0")
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X7 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X8 & " Y0")
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X4 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait * 1.3))
            SendTheString("G0 X" & Me.MaxX.Text & " Y" & Me.MaxY.Text)
            SendTheString("M400")
            SendTheString("G0 X" & X7 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X6 & " Y" & MaxY.Text)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X5 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X4 & " Y" & MaxY.Text)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X3 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X2 & " Y" & MaxY.Text)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X1 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X0 Y" & MaxY.Text)
            Threading.Thread.Sleep(CInt(SWait))
            SendTheString("G0 X" & X4 & " Y" & HalfY)
            Threading.Thread.Sleep(CInt(LWait * 1.3))
            SendTheString("G0 X0 Y0")
            SendTheString("M400")
            'Next N
            SendTheString("End Race")
            Do Until InStr(1, EnderMainForm.TextBox1.Text, "End Race") > 0
                Application.DoEvents()
            Loop
            Trap.Stop()
            Dim ET = Trap.ElapsedMilliseconds
            Dim CourseLength = Val(Me.CourseLength.Text)
            Me.ETBox.Text = Format(ET / 1000, "0.00")
            Me.SpeedBox.Text = Format(CourseLength / (ET / 1000), "0.00")
            Me.MMperMIN.Text = CStr(Int(60 * Val(Me.SpeedBox.Text)))
            Exit Sub
        ElseIf Me.GreatCircle.Checked = True Then
            Dim TheRadius As Double = 0
            Dim CenX = Val(Me.MaxX.Text) * 0.5
            Dim CenY = Val(Me.MaxY.Text) * 0.5
            If Val(Me.MaxX.Text) > Val(Me.MaxY.Text) Then
                TheRadius = Val(Me.MaxY.Text) * 0.5
            Else
                TheRadius = Val(Me.MaxX.Text) * 0.5
            End If
            Dim StX = CenX - TheRadius
            Trap.Reset()
            If Me.BeepControl.Checked Then SendTheString("M300")
            Trap.Start()
            StrToSend = "G0 X" & StX & " Y" & CenY & " F" & MyV
            SendTheString(StrToSend)
            For Lap = 1 To DoubleDist
                StrToSend = "G2 I" & TheRadius & " J0"
                SendTheString(StrToSend)
                SendTheString(StrToSend)
                'SendTheString("M400")
            Next Lap
            SendTheString("End Race")
            Do Until InStr(1, EnderMainForm.TextBox1.Text, "End Race") > 0
                Application.DoEvents()
            Loop
            Trap.Stop()
            SendTheString("G0 X0 Y0")
            Dim ET = Trap.ElapsedMilliseconds
            Me.ETBox.Text = Format(ET / 1000, "0.00")
            Me.SpeedBox.Text = Format(TheCourseLength("GreatCircle") / (ET / 1000), "0.00")
            Me.MMperMIN.Text = CStr(Int(60 * Val(Me.SpeedBox.Text)))
            Exit Sub
        ElseIf Me.Figure8.Checked = True Then
            Dim TheRadius As Double = 0
            Dim CenX = Val(Me.MaxX.Text) * 0.5
            Dim CenY = Val(Me.MaxY.Text) * 0.5
            If Val(Me.MaxX.Text) > Val(Me.MaxY.Text) Then
                TheRadius = Val(Me.MaxY.Text) * 0.25
            Else
                TheRadius = Val(Me.MaxX.Text) * 0.25
            End If
            Dim StX = CenX - (TheRadius * 2)
            Trap.Reset()
            If Me.BeepControl.Checked Then SendTheString("M300")
            Trap.Start()
            'For Lap = 1 To DoubleDist
            StrToSend = "G0 X0 Y" & CenY & " F" & MyV
            SendTheString(StrToSend)
            StrToSend = "G2 I" & CenX * 0.5 & " J0 X" & CenX & " Y" & CenY
            SendTheString(StrToSend)
            StrToSend = "G3 I" & CenX * 0.5 & " J0"
            SendTheString(StrToSend)
            StrToSend = "G2 I-" & CenX * 0.5 & " J0"
            SendTheString(StrToSend)
            StrToSend = "G3 I" & CenX * 0.5 & " J0"
            SendTheString(StrToSend)
            StrToSend = "G2 I-" & CenX * 0.5 & " J0 X0 Y" & CenY
            SendTheString(StrToSend)
            Threading.Thread.Sleep(5000)
            'SendTheString("M400")
            'Next Lap
            SendTheString("End Race")
            Do Until InStr(1, EnderMainForm.TextBox1.Text, "End Race") > 0
                Application.DoEvents()
            Loop
            Trap.Stop()
            StrToSend = "G0 X0 Y0"
            SendTheString(StrToSend)
            Dim ET = Trap.ElapsedMilliseconds
            Me.ETBox.Text = Format(ET / 1000, "0.00")
            Me.SpeedBox.Text = Format(TheCourseLength("GreatCircle") / (ET / 1000), "0.00")
            Me.MMperMIN.Text = CStr(Int(60 * Val(Me.SpeedBox.Text)))
            Exit Sub
        End If
    End Sub

    Public Function TheCourseLength(CourseName As String) As Double
        On Error Resume Next
        If CourseName = "DragRace" Then
            TheCourseLength = (2 * Math.Sqrt(Val(Me.MaxX.Text) ^ 2 + CDbl(CDbl(Me.MaxY.Text) ^ 2))) * DoubleDist
            Me.StartsStops.Text = CStr(4 * DoubleDist)
        ElseIf CourseName = "NASCAR" Then
            TheCourseLength = ((2 * Val(Me.MaxX.Text)) + (2 * Val(Me.MaxY.Text))) * DoubleDist
            Me.StartsStops.Text = CStr(8 * DoubleDist)
        ElseIf CourseName = "DemoDerby" Then
            TheCourseLength = (Val(Me.MaxX.Text) ^ 2) + (Val(CDbl(Me.MaxY.Text) ^ 2))
            TheCourseLength = Math.Sqrt(TheCourseLength)
            TheCourseLength += Val(Me.MaxX.Text)
            TheCourseLength *= 2 * DoubleDist
            Me.StartsStops.Text = CStr(8 * DoubleDist)
        ElseIf CourseName = "F1" Then
            TheCourseLength = ((Val(Me.MaxX.Text) * 0.125) ^ 2) + ((Val(Me.MaxY.Text) / 2) ^ 2)
            TheCourseLength = Math.Sqrt(TheCourseLength)
            TheCourseLength *= 16
            TheCourseLength += ((Math.Sqrt((((Val(Me.MaxY.Text) * 0.5) ^ 2) + ((Val(Me.MaxX.Text) * 0.5) ^ 2)))) * 4) * DoubleDist
            Me.StartsStops.Text = CStr(40 * DoubleDist)
        ElseIf CourseName = "GreatCircle" Then
            Dim TheRadius = 0
            If Val(Me.MaxX.Text) > Val(Me.MaxY.Text) Then
                TheRadius = CInt(CDbl(Me.MaxY.Text) * 0.5)
            Else
                TheRadius = CInt(CDbl(Me.MaxX.Text) * 0.5)
            End If
            TheCourseLength = (TheRadius * Math.PI) * 2 * 2 * DoubleDist
            Me.StartsStops.Text = CStr(2 * CInt(TheCourseLength) * DoubleDist)
        ElseIf CourseName = "Infinity" Then
            Dim TheRadius = 0
            TheRadius = CInt(CDbl(Me.MaxX.Text) * 0.25)
            TheCourseLength = (TheRadius * Math.PI) * 8 * DoubleDist
            Me.StartsStops.Text = CStr(2 * CInt(TheCourseLength) * DoubleDist)
        End If
        Me.CourseLength.Text = Format(TheCourseLength, "0.00")
    End Function

    Private Sub RacingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Ucontrol As Control
        Staged = False
        Me.StagedBut.Text = "Prepare to Qualify"
        Me.GoBut.Text = "Red Flag"
        Me.GoBut.BackColor = Color.Red
        Me.GoBut.Enabled = False
        Me.MaxX.Text = My.Settings.Bed_Xmax
        Me.MaxY.Text = My.Settings.Bed_Ymax
        If EnderMainForm.Vcomm.IsOpen Then
            SendTheString("M503")
            For Each Ucontrol In Me.Controls
                Ucontrol.enabled = False
            Next
            Me.HomeBut.Enabled = True
            Me.M503RaceBut.Enabled = True
            Me.StagedBut.Enabled = True
            Me.CloseBut.Enabled = True
            PreStart = True
        Else
            MsgBox("The COM Port is closed and the form did not get set up correctly.  Please <Close> the form, Open the Port, and try again.", vbOKOnly, "Greg's Toolbox")
            PreStart = False
        End If

    End Sub

    Private Sub DragRace_CheckedChanged(sender As Object, e As EventArgs) Handles DragRace.CheckedChanged
        Me.DoubleDistBox.Enabled = True
        If Me.DoubleDistBox.Checked Then
            DoubleDist = 2
        Else
            DoubleDist = 1
        End If
        TheCourseLength("DragRace")
    End Sub

    Private Sub NascarRace_CheckedChanged(sender As Object, e As EventArgs) Handles NascarRace.CheckedChanged
        Me.DoubleDistBox.Enabled = True
        If Me.DoubleDistBox.Checked Then
            DoubleDist = 2
        Else
            DoubleDist = 1
        End If
        TheCourseLength("NASCAR")
    End Sub

    Private Sub DemoRace_CheckedChanged(sender As Object, e As EventArgs) Handles DemoRace.CheckedChanged
        Me.DoubleDistBox.Enabled = True
        If Me.DoubleDistBox.Checked Then
            DoubleDist = 2
        Else
            DoubleDist = 1
        End If
        TheCourseLength("DemoDerby")
    End Sub

    Private Sub F1Race_CheckedChanged(sender As Object, e As EventArgs) Handles F1Race.CheckedChanged
        Me.DoubleDistBox.Enabled = False
        DoubleDist = 1
        TheCourseLength("F1")
    End Sub

    Private Sub GreatCircle_CheckedChanged(sender As Object, e As EventArgs) Handles GreatCircle.CheckedChanged
        Me.DoubleDistBox.Enabled = True
        If Me.DoubleDistBox.Checked Then
            DoubleDist = 2
        Else
            DoubleDist = 1
        End If
        TheCourseLength("GreatCircle")
    End Sub

    Private Sub Figure8_CheckedChanged(sender As Object, e As EventArgs) Handles Figure8.CheckedChanged
        Me.DoubleDistBox.Enabled = False
        DoubleDist = 1
        TheCourseLength("Infinity")
    End Sub

    Private Sub MaxX_TextChanged(sender As Object, e As EventArgs) Handles MaxX.TextChanged
        On Error Resume Next
        Dim CourseName As String = ""
        If Me.DragRace.Checked = True Then CourseName = "DragRace"
        If Me.NascarRace.Checked = True Then CourseName = "NASCAR"
        If Me.DemoRace.Checked = True Then CourseName = "DemoDerby"
        If Me.F1Race.Checked = True Then CourseName = "F1"
        If Me.GreatCircle.Checked = True Then CourseName = "GreatCircle"
        If Me.Figure8.Checked = True Then CourseName = "Infinity"
        TheCourseLength(CourseName)
    End Sub

    Private Sub MaxY_TextChanged(sender As Object, e As EventArgs) Handles MaxY.TextChanged
        On Error Resume Next
        Dim CourseName As String = ""
        If Me.DragRace.Checked = True Then CourseName = "DragRace"
        If Me.NascarRace.Checked = True Then CourseName = "NASCAR"
        If Me.DemoRace.Checked = True Then CourseName = "DemoDerby"
        If Me.F1Race.Checked = True Then CourseName = "F1"
        If Me.GreatCircle.Checked = True Then CourseName = "GreatCircle"
        If Me.Figure8.Checked = True Then CourseName = "Infinity"
        TheCourseLength(CourseName)
    End Sub

    Private Sub AccelXBox_ValueChanged(sender As Object, e As EventArgs) Handles AccelXBox.ValueChanged
        On Error Resume Next
        Staged = False
        If Me.AccelXBox.Value > 6000 Then Me.AccelXBox.Value = 6000
        If Me.AccelXBox.Value < 0 Then Me.AccelXBox.Value = 0
        If Me.SyncAccel.Checked Then Me.AccelYBox.Value = Me.AccelXBox.Value
        Me.GoBut.Enabled = False
        Me.StagedBut.Text = "Prepare to Qualify"
        Me.GoBut.Text = "Red Flag"
        Me.GoBut.BackColor = Color.Red
        Me.Refresh()
    End Sub

    Private Sub JerkXBox_ValueChanged(sender As Object, e As EventArgs) Handles JerkXBox.ValueChanged
        On Error Resume Next
        Dim MaxJ As Single
        Dim MinJ As Single
        If My.Settings.JunctionDeviation <> "" Then
            MaxJ = CSng(1)
            MinJ = CSng(0.01)
        Else
            MaxJ = 30
            MinJ = 0
        End If
        If Me.JerkXBox.Value > MaxJ Then Me.JerkXBox.Value = CDec(MaxJ)
        If Me.JerkXBox.Value < MinJ Then Me.JerkXBox.Value = CDec(MinJ)
        If Me.SyncJerk.Checked Then Me.JerkYBox.Value = Me.JerkXBox.Value
        Staged = False
        Me.GoBut.Enabled = False
        Me.StagedBut.Text = "Prepare to Qualify"
        Me.GoBut.Text = "Red Flag"
        Me.GoBut.BackColor = Color.Red
        Me.Refresh()
    End Sub

    Private Sub RacingForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If EnderMainForm.Vcomm.IsOpen Then
            StrToSend = "M201 X" & My.Settings.DefaultXAccel & " Y" & My.Settings.DefaultYAccel
            SendTheString(StrToSend)
            If My.Settings.JunctionDeviation = "" Then
                StrToSend = "M205 X" & My.Settings.DefaultXJerk & " Y" & My.Settings.DefaultYJerk
                SendTheString(StrToSend)
            Else
                StrToSend = "M205 J" & My.Settings.JunctionDeviation
                SendTheString(StrToSend)
            End If
            StrToSend = "M204 P" & My.Settings.DefaultPAccel & " T" & My.Settings.DefaultTAccel
            SendTheString(StrToSend)
        Else
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
        End If
    End Sub

    Public Sub GetJerk()
        On Error Resume Next
        Dim M503str = EnderMainForm.TextBox1.Text
        Dim Location = InStr(M503str, "M201")
        Dim NewStr = Strings.Right(M503str, Len(M503str) - Location - 4)
        Dim EndLoc = InStr(NewStr, " Z")
        Dim M201str = Strings.Left(NewStr, EndLoc - 1)
        Dim YLoc = InStr(M201str, " Y")
        Dim DefaultYA = Strings.Right(M201str, Len(M201str) - YLoc - 1)
        Dim DefaultXA = Strings.Mid(M201str, 2, YLoc - 2)
        Dim Jstr = ""
        My.Settings.DefaultXAccel = DefaultXA
        My.Settings.DefaultYAccel = DefaultYA

        Location = InStr(M503str, "M205")
        NewStr = Strings.Right(M503str, Len(M503str) - Location - 4)
        Dim JLoc = InStr(NewStr, " J")
        If JLoc > 0 Then
            Me.JerkYBox.Visible = False
            Me.JerkYLab.Visible = False
            Me.JerkXBox.Width = 124
            Me.JerkXBox.Minimum = CDec(0.01)
            Me.JerkXBox.DecimalPlaces = 2
            Me.JerkXBox.Increment = CDec(0.02)
            Me.JerkXBox.Maximum = 1
            Me.JerkXlab.Text = "Junc Dev"
            Me.JerkXlab.Width = 124
            Jstr = Strings.Right(NewStr, Len(NewStr) - JLoc)
            JLoc = InStr(Jstr, " ")
            Jstr = Strings.Mid(Jstr, 2, JLoc - 2)
            Me.JerkXBox.Value = CDec(Jstr)
            My.Settings.JunctionDeviation = Jstr
            Me.SyncJerk.Checked = False
            Me.SyncJerk.Visible = False
            My.Settings.DefaultXJerk = ""
            My.Settings.DefaultYJerk = ""
        Else
            Dim XLoc = InStr(NewStr, " X")
            EndLoc = InStr(NewStr, " Z")
            Dim M205str = Strings.Mid(NewStr, XLoc + 2, EndLoc - XLoc - 2)
            YLoc = InStr(M205str, " Y")
            Dim DefaultYJ = Strings.Right(M205str, Len(M205str) - YLoc - 1)
            Dim DefaultXJ = Strings.Left(M205str, YLoc - 1)
            My.Settings.DefaultXJerk = DefaultXJ
            Me.JerkXBox.Value = CDec(DefaultXJ)
            My.Settings.DefaultYJerk = DefaultYJ
            Me.JerkYBox.Value = CDec(DefaultYJ)
            My.Settings.JunctionDeviation = ""
            Me.JerkYBox.Visible = True
            Me.JerkYLab.Visible = True
            Me.JerkXBox.Width = 59
            Me.JerkXlab.Text = "X"
            Me.JerkXlab.Width = 59
            Me.JerkXBox.Minimum = 0
            Me.JerkXBox.DecimalPlaces = 0
            Me.JerkXBox.Increment = 2
            Me.JerkXBox.Maximum = 30
            Me.SyncJerk.Checked = True
            Me.SyncJerk.Visible = True
        End If
        Dim Ucontrol As Control
        For Each Ucontrol In Me.Controls
            Ucontrol.enabled = True
        Next
    End Sub

    Private Sub DoubleDistBox_CheckedChanged(sender As Object, e As EventArgs) Handles DoubleDistBox.CheckedChanged
        If Me.DoubleDistBox.Checked Then
            DoubleDist = 2
        Else
            DoubleDist = 1
        End If
        If Me.DragRace.Checked Then TheCourseLength("DragRace")
        If Me.NascarRace.Checked Then TheCourseLength("NASCAR")
        If Me.DemoRace.Checked Then TheCourseLength("DemoDerby")
        If Me.F1Race.Checked Or Me.Figure8.Checked Then DoubleDist = 1
        If Me.F1Race.Checked Then TheCourseLength("F1")
        If Me.GreatCircle.Checked Then TheCourseLength("GreatCircle")
        If Me.Figure8.Checked Then TheCourseLength("Infinity")
    End Sub

    Private Sub M503RaceBut_Click(sender As Object, e As EventArgs) Handles M503RaceBut.Click
        If EnderMainForm.Vcomm.IsOpen Then
            StrToSend = "M503"
            SendTheString(StrToSend)
        Else
            MsgBox("The port is closed", vbOKOnly, "Greg's Toolbox")
        End If
    End Sub

    Private Sub JerkAccelSaveBut_Click(sender As Object, e As EventArgs) Handles JerkAccelSaveBut.Click
        On Error Resume Next
        Dim AResponse As MsgBoxResult
        If My.Settings.JunctionDeviation = "" Then
            AResponse = MsgBox("The current settings are:" & vbLf &
               "Max Accel: X=" & My.Settings.DefaultXAccel & "  Y=" & My.Settings.DefaultYAccel & vbLf &
               "     Jerk: X=" & My.Settings.DefaultXJerk & "  Y=" & My.Settings.DefaultYJerk & vbLf & vbLf &
               "New Settings for Jerk and Max Accel (can be set lower in the slicer):" & vbLf &
               "Max Accel: X=" & Me.AccelXBox.Value & "  Y=" & Me.AccelYBox.Value & vbLf &
               "     Jerk: X=" & Me.JerkXBox.Value & "  Y=" & Me.JerkYBox.Value & vbLf & vbLf & "Do you want to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        Else
            AResponse = MsgBox("The current settings are:" & vbLf &
               "         Max Accel: X= " & My.Settings.DefaultXAccel & "  Y=" & My.Settings.DefaultYAccel & vbLf &
               "Junction Deviation: J= " & My.Settings.JunctionDeviation &
               "New Settings for Junction Deviation and Max Accel (can be set lower in the slicer):" & vbLf &
               "         Max Accel: X= " & Me.AccelXBox.Value & "  Y= " & Me.AccelYBox.Value & vbLf &
               "Junction Deviation: J=" & Me.JerkXBox.Value & vbLf & vbLf & "Do you want to continue?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Greg's Toolbox")
        End If

        If AResponse = vbNo Then Exit Sub
        StrToSend = "M201 X" & Me.AccelXBox.Value & " Y" & Me.AccelYBox.Value
        SendTheString(StrToSend)
        If My.Settings.JunctionDeviation = "" Then
            StrToSend = "M205 X" & Me.JerkXBox.Value & " Y" & Me.JerkYBox.Value
            SendTheString(StrToSend)
        Else
            StrToSend = "M205 J" & Me.JerkXBox.Text
            SendTheString(StrToSend)
        End If
        StrToSend = "M204 P" & Me.AccelXBox.Value & " T" & Me.AccelYBox.Value
        SendTheString(StrToSend)
        With My.Settings
            .DefaultXAccel = CStr(Me.AccelXBox.Value)
            .DefaultYAccel = CStr(Me.AccelYBox.Value)
            .DefaultPAccel = .DefaultXAccel
            .DefaultTAccel = .DefaultPAccel
            If .JunctionDeviation = "" Then
                .DefaultXJerk = CStr(Me.JerkXBox.Value)
                .DefaultYJerk = CStr(Me.JerkYBox.Value)
                .JunctionDeviation = ""
            Else
                .DefaultXJerk = ""
                .DefaultYJerk = ""
                .JunctionDeviation = CStr(Me.JerkXBox.Value)
            End If
        End With
        StrToSend = "M500"
        SendTheString(StrToSend)
    End Sub

    Private Sub SyncAccel_CheckedChanged(sender As Object, e As EventArgs) Handles SyncAccel.CheckedChanged
        If Me.SyncAccel.Checked Then Me.AccelYBox.Value = Me.AccelXBox.Value
    End Sub

    Private Sub SyncJerk_CheckedChanged(sender As Object, e As EventArgs) Handles SyncJerk.CheckedChanged
        If Me.SyncJerk.Checked Then Me.JerkYBox.Value = Me.JerkXBox.Value
    End Sub

    Private Sub AccelYBox_ValueChanged(sender As Object, e As EventArgs) Handles AccelYBox.ValueChanged
        On Error Resume Next
        Staged = False
        If Me.AccelYBox.Value > 6000 Then Me.AccelYBox.Value = 6000
        If Me.AccelYBox.Value < 0 Then Me.AccelYBox.Value = 0
        If Me.SyncAccel.Checked Then Me.AccelXBox.Value = Me.AccelYBox.Value
        Me.GoBut.Enabled = False
        Me.StagedBut.Text = "Prepare to Qualify"
        Me.GoBut.Text = "Red Flag"
        Me.GoBut.BackColor = Color.Red
        Me.Refresh()
    End Sub

    Private Sub JerkYBox_ValueChanged(sender As Object, e As EventArgs) Handles JerkYBox.ValueChanged
        On Error Resume Next
        Dim MaxJ As Single
        Dim MinJ As Single
        If My.Settings.JunctionDeviation <> "" Then
            MaxJ = CSng(1)
            MinJ = CSng(0.01)
        Else
            MaxJ = 30
            MinJ = 0
        End If
        If Me.JerkYBox.Value > MaxJ Then Me.JerkYBox.Value = CDec(MaxJ)
        If Me.JerkYBox.Value < MinJ Then Me.JerkYBox.Value = CDec(MinJ)
        If Me.SyncJerk.Checked Then Me.JerkXBox.Value = Me.JerkYBox.Value
        Staged = False
        Me.GoBut.Enabled = False
        Me.StagedBut.Text = "Prepare to Qualify"
        Me.GoBut.Text = "Red Flag"
        Me.GoBut.BackColor = Color.Red
        Me.Refresh()
    End Sub

    Private Sub HomeBut_Click(sender As Object, e As EventArgs) Handles HomeBut.Click
        If EnderMainForm.Vcomm.IsOpen Then
            StrToSend = "G28"
            SendTheString(StrToSend)
        Else
            MsgBox("The Port is Closed", vbOKOnly, "Greg's Toolbox")
        End If
    End Sub
End Class