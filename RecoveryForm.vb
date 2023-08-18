Public Class RecoveryForm

    Private Sub PrintBut_Print()
        On Error GoTo EHandler
        MsgBox("There is a 10 second wait for the initial move from HOME to complete and then the command continues.", vbOKOnly, "Greg's Toolbox")
        With Me
            If .FileLab.Text = "" Or .ByteLab.Text = "" Or .BedLab.Text = "" Or .HotLab.Text = "" _
                Or .FeedLab.Text = "" Or .FlowLab.Text = "" Or .FanLab.Text = "" Or .ZLab.Text = "" _
                Or .XLab.Text = "" Or .YLab.Text = "" Or .ELab.Text = "" Then
                MsgBox("None of these boxes can be blank.  Please provide the proper values for the boxes to load.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If .SpecialHomeLocOpt.Checked Then
                If .XHomeBox.Text = "" Or .YHomeBox.Text = "" Then
                    MsgBox("The X and Y locations to home the Z cannot be blank.", vbOKOnly, "Greg's Toolbox")
                    Exit Sub
                End If
            End If
            'Init SD card
            StrToSend = "M21"
            SendTheString(StrToSend)
            'M23 File Name
            StrToSend = "M23 " & .FileLab.Text
            SendTheString(StrToSend)
            'M26 Byte Location
            StrToSend = "M26 S" & .ByteLab.Text
            SendTheString(StrToSend)
            'set bed temp
            If My.Settings.Heated_Bed Then
                StrToSend = "M140 S" & .BedLab.Text
                SendTheString(StrToSend)
                'wait for bed temp
                StrToSend = "M190 S" & .BedLab.Text
                SendTheString(StrToSend)
            End If
            'set hotend temp
            StrToSend = "M104 S" & .HotLab.Text
            SendTheString(StrToSend)
            'wait for hotend
            StrToSend = "M109 S" & .HotLab.Text
            SendTheString(StrToSend)
            'report temps
            StrToSend = "M105"
            SendTheString(StrToSend)
            'set feedrate
            StrToSend = "M220 S" & .FeedLab.Text
            SendTheString(StrToSend)
            'set flowrate
            StrToSend = "M221 S" & .FlowLab.Text
            SendTheString(StrToSend)
            'Home
            If .NormalHomeLocOpt.Checked Then
                StrToSend = "G28"
                SendTheString(StrToSend)
            ElseIf .SpecialHomeLocOpt.Checked Then
                StrToSend = "G28 X Y"
                SendTheString(StrToSend)
                StrToSend = "G1 F2400 X" & .XHomeBox.Text & " Y" & .YHomeBox.Text
                SendTheString(StrToSend)
                Threading.Thread.Sleep(5000)
                StrToSend = "G28 Z"
                SendTheString(StrToSend)
            ElseIf .NoHomeBut.Checked Then
                'Do nothing
            End If
            'Cursor.Current = Cursors.WaitCursor
            'Threading.Thread.Sleep(15000)
            'Cursor.Current = Cursors.Default

            Do Until Me.PrintFromByteBut.Checked = False
                Application.DoEvents()
            Loop

            'Fan Speed
            StrToSend = "M106 S" & Math.Ceiling((Val(.FanLab.Text) / 100) * 255)
            SendTheString(StrToSend)
            'Z up
            StrToSend = "G0 F1200 Z" & Val(.ZLab.Text) + 10
            SendTheString(StrToSend)
            'Go to X,Y
            StrToSend = "G0 F2400 X" & .XLab.Text & " Y" & .YLab.Text
            SendTheString(StrToSend)

            'Wait
            Cursor.Current = Cursors.WaitCursor
            Threading.Thread.Sleep(10000)
            Cursor.Current = Cursors.Default

            'Reset extruder
            Dim ELocation As String
            ELocation = .ELab.Text
            StrToSend = "G92 E" & CLng(ELocation) - 6
            SendTheString(StrToSend)
            'Drop the Z
            StrToSend = "G0 F300 Z" & .ZLab.Text
            SendTheString(StrToSend)
            'extrude to catch up
            StrToSend = "G0 F1200 E" & ELocation
            SendTheString(StrToSend)
            'Print
            StrToSend = "G0 F2400"
            SendTheString(StrToSend)
            StrToSend = "M24"
            SendTheString(StrToSend)
        End With
        Exit Sub
EHandler:
        MsgBox("There was an error in ""RecoveryForm.PrintBut_Print""." & vbLf & Err.Description, CType(vbOKOnly + vbCritical, MsgBoxStyle), "Greg's Toolbox")
    End Sub

    Private Sub RefreshBut_Click(sender As Object, e As EventArgs) Handles RefreshBut.Click
        Dim ZHgt As String, ELoc As String, XLoc As String, YLoc As String, HotTemp As String, BedTemp As String
        Dim Filename As String, ByteNum As String, FanSpeed As String, FeedRate As String, FlowRate As String
        CheckDefeat = True
        With EnderMainForm
            ZHgt = .PauseZ.Text
            ELoc = .PauseE.Text
            ByteNum = .ByteCountBox.Text
            Filename = .FileListBox.Text
            XLoc = .PauseX.Text
            YLoc = .PauseY.Text
            HotTemp = .HeatBox.Text
            BedTemp = .BedBox.Text
            FlowRate = .FloBox.Text
            FeedRate = .FeedBox.Text
            FanSpeed = .FanBox.Text
        End With
        With Me
            .ByteLab.Text = ByteNum
            .FileLab.Text = Filename
            .ELab.Text = ELoc
            .ZLab.Text = ZHgt
            .XLab.Text = XLoc
            .YLab.Text = YLoc
            .BedLab.Text = BedTemp
            .HotLab.Text = HotTemp
            .FeedLab.Text = FeedRate
            .FlowLab.Text = FlowRate
            .FanLab.Text = FanSpeed
            CheckDefeat = False
        End With
    End Sub

    Private Sub CancelBut_CheckedChanged(sender As Object, e As EventArgs) Handles CancelBut.CheckedChanged
        Me.Hide()
    End Sub

    Private Sub GenerateScriptBut_CheckedChanged(sender As Object, e As EventArgs) Handles GenerateScriptBut.CheckedChanged
        With Me
            If .FileLab.Text = "" Or .ByteLab.Text = "" Or .BedLab.Text = "" Or .HotLab.Text = "" _
                Or .FeedLab.Text = "" Or .FlowLab.Text = "" Or .FanLab.Text = "" Or .ZLab.Text = "" _
                Or .XLab.Text = "" Or .YLab.Text = "" Or .ELab.Text = "" Then
                MsgBox("None of these boxes can be blank.  Please provide the proper values for the boxes to load.", CType(vbOKOnly + vbInformation, MsgBoxStyle), "Greg's Toolbox")
                Exit Sub
            End If
            Dim HotBedStr140 As String
            Dim HotBedStr190 As String
            If My.Settings.Heated_Bed Then
                HotBedStr140 = "M140 S" & .BedLab.Text & " ;Set Bed temp"
                HotBedStr190 = "M190 S" & .BedLab.Text & " ;Wait for bed"
            Else
                HotBedStr140 = ";M140 ;No bed heater"
                HotBedStr190 = ";M190 ;No bed heater"
            End If
            Dim HomeRestartLoc = ""
            If .NormalHomeLocOpt.Checked Then
                HomeRestartLoc = "G28 ;Home"
            ElseIf .NoHomeBut.Checked Then
                HomeRestartLoc = "; DO NOT Home"
            ElseIf .SpecialHomeLocOpt.Checked Then
                If .XHomeBox.Text = "" Or .YHomeBox.Text = "" Then
                    MsgBox("You must enter values for the X and Y locations to safely Home the Z", vbOKOnly, "Greg's Toolbox")
                    Exit Sub
                End If
                HomeRestartLoc = "G28 X Y" & vbCrLf &
                    "G1 F2400 X" & .XHomeBox.Text & " Y" & .YHomeBox.Text & vbCrLf &
                    "G28 Z  ;Home Z"
            End If
            Dim M82Line As String
            Dim G92Line As String
            If Not M83Box.Checked Then
                M82Line = "M82 ;Absolute Extrusion"
                G92Line = "G92 E" & CSng(.ELab.Text) - CSng(My.Settings.PrimeAmt) & " ;Set extruder -" & My.Settings.PrimeAmt & " prime"
            Else
                M82Line = "M83 ;Relative Extrusion"
                G92Line = "G92 E" & 0 - CSng(My.Settings.PrimeAmt) & ";Set extruder"
            End If
            EnderMainForm.TextBox1.Text =
                "M21 ;Initialize SD card" & vbCrLf &
                "M23 " & Trim(.FileLab.Text) & " ;DOS 8.3 FileName" & vbCrLf &
                "M26 S" & .ByteLab.Text & " ;Byte location" & vbCrLf &
                HotBedStr140 & vbCrLf &
                HotBedStr190 & vbCrLf &
                "M104 S" & .HotLab.Text & " ;Hot end temp" & vbCrLf &
                "M109 S" & .HotLab.Text & " ;Wait for hot end" & vbCrLf &
                "M105 ;Report Temps" & vbCrLf &
                "M220 S" & .FeedLab.Text & " ;Feed rate" & vbCrLf &
                "M221 S" & .FlowLab.Text & " ;Flow rate" & vbCrLf &
                HomeRestartLoc & vbCrLf &
                ";When sending as a SCRIPT split in two here and send the top half then send the bottom half" & vbCrLf &
                ";Wait for click on ""Wait for Home"" button" & vbCrLf &
                ";" & vbCrLf &
                "M106 S" & Int((Val(.FanLab.Text) / 100) * 255) & " ;Fan" & vbCrLf &
                "G0 F1200 Z" & Val(.ZLab.Text) + 10 & " ;Move the Z to restart height + 10" & vbCrLf &
                "G0 F2400 X" & .XLab.Text & " Y" & .YLab.Text & " ;Move to XY restart location" & vbCrLf &
                G92Line & vbCrLf &
                "G0 F300 Z" & .ZLab.Text & " ;Drop 10 to Resume Z" & vbCrLf &
                M82Line & vbCrLf &
                "G0 F2400 ;Set Feed rate" & vbCrLf &
                "M24 ;Resume"
        End With
    End Sub

    Private Sub PrintFromByteBut_CheckedChanged(sender As Object, e As EventArgs) Handles PrintFromByteBut.CheckedChanged
        If CheckDefeat Then Exit Sub
        If Me.PrintFromByteBut.Checked = True Then
            Me.PrintFromByteBut.Text = "Wait for Homing"
            Me.PrintFromByteBut.BackColor = Color.Gold
            Call PrintBut_Print()
            Exit Sub
        ElseIf Me.PrintFromByteBut.Checked = False Then
            Me.PrintFromByteBut.Text = "Print from Byte Location"
            Me.PrintFromByteBut.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub M83Box_CheckedChanged(sender As Object, e As EventArgs) Handles M83Box.CheckedChanged
        If M83Box.Checked Then
            ELab.Text = "0"
        Else
            ELab.Text = EnderMainForm.PauseE.Text
        End If
    End Sub
End Class