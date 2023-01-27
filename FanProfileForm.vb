Public Class FanProfileForm
    Public FanProfileArray(1, 0) As String
    Public FanFeatureArray(0 To 8, 0 To 1) As String
    Public FanArrayIndex As String
    Public FanOriginalFile As System.IO.StreamReader
    Public FanNewGcodeFile As System.IO.StreamWriter
    Public FanDataline As String
    Public Counter As Integer = -1
    Public MaxLayer As Integer

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        With Me
            .TextBox1.Text = ""
            .TextBox2.Text = ""
            FanNewGcodeFile.Close()
            Call Me.ClearBut_Click(sender, e)
        End With
        Try
            My.Computer.FileSystem.DeleteFile(EnderMainForm.SaveFileDialog1.FileName,
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Catch ex As Exception
        End Try
        Me.Hide()
    End Sub

    Private Sub AddBut_Click(sender As Object, e As EventArgs) Handles AddBut.Click
        On Error Resume Next
        Counter += 1
        ReDim Preserve FanProfileArray(1, Counter)
        With Me
            If .TextBox1.Text = "" And .TextBox2.Text = "" Then
                MsgBox("The Layer and Speed boxes can't be blank", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If Val(.TextBox1.Text) < 0 Then
                MsgBox("The Layer number cannot be below 0", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If Val(.TextBox2.Text) < 0 Or Val(.TextBox2.Text) > 100 Then
                MsgBox("There is an error in the fan speed box.  The speed must be from 0 and 100 inclusive.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            TLP1.RowStyles.Clear()
            TLP1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26))
            TLP1.ColumnStyles.Clear()
            TLP1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50))
            Dim MyLabelLayer = New TextBox()
            With MyLabelLayer
                MyLabelLayer.TextAlign = HorizontalAlignment.Center
                MyLabelLayer.Multiline = True
                MyLabelLayer.Width = 40
                MyLabelLayer.Name = "Layer" & Counter
                MyLabelLayer.Text = Me.TextBox1.Text
            End With
            Dim MyLabelSpeed = New TextBox()
            With MyLabelSpeed
                MyLabelSpeed.TextAlign = HorizontalAlignment.Center
                MyLabelSpeed.Multiline = True
                MyLabelSpeed.Width = 40
                MyLabelSpeed.Name = "Speed" & Counter
                MyLabelSpeed.Text = Me.TextBox2.Text
            End With
            FanProfileArray(0, Counter) = MyLabelLayer.Text
            FanProfileArray(1, Counter) = MyLabelSpeed.Text
            .TLP1.Controls.Add(MyLabelLayer, 0, Me.TLP1.RowCount)
            .TLP1.Controls.Add(MyLabelSpeed, 1, Me.TLP1.RowCount)
            AddHandler MyLabelLayer.Leave, AddressOf MyClickHandler
            AddHandler MyLabelSpeed.Leave, AddressOf MyClickHandler
            TLP1.RowCount += 1
            Me.TextBox1.Text = CStr(Val(Me.TextBox1.Text) + 1)
            Me.TextBox2.Text = ""
        End With
    End Sub

    Private Sub MyClickHandler(sender As Object, e As EventArgs)
        Dim MyControl As Control
        MyControl = Nothing
        Try
            MyControl = CType(sender, Control)
        Catch ex As Exception

        End Try
        Dim TheBox = Me.TLP1.GetPositionFromControl(MyControl)
        Dim ActiveName = ""
        If TheBox.Column = 0 Then
            ActiveName = "Layer" & TheBox.Row
        ElseIf TheBox.Column = 1 Then
            ActiveName = "Speed" & TheBox.Row
        End If
        FanProfileArray(TheBox.Column, TheBox.Row) = Me.TLP1.Controls(ActiveName).Text
    End Sub

    Private Sub CreateBut_Click(sender As Object, e As EventArgs) Handles CreateBut.Click
        On Error Resume Next
        EnderMainForm.PrResponse = True
        For N = 0 To UBound(FanProfileArray, 2)
            FanProfileArray(0, N) = LayerSearchStr & FanProfileArray(0, N)
            If Me.PWMopt.Checked = True Then
                FanProfileArray(1, N) = "M106 S" & Math.Ceiling((Val(FanProfileArray(1, N)) / 100) * 255)
            Else
                FanProfileArray(1, N) = "M106 S" & Format(Val(CInt(FanProfileArray(1, N)) / 100), "0.0")
            End If
        Next N
        Me.Hide()
        EnderMainForm.BringToFront()
        Call EnderMainForm.ContinueFanProfile()
    End Sub

    Private Sub FanProfileForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As Control
        Do Until Me.TLP1.Controls.Count = 0
            For Each c In TLP1.Controls
                c.Dispose()
            Next
        Loop
        Try
            Me.TLP1.RowCount = 0
            ReDim FanProfileArray(1, 0)
        Catch
        End Try

    End Sub

    Private Sub ClearBut_Click(sender As Object, e As EventArgs) Handles ClearBut.Click
        Try
            Dim c As Control
            Do Until Me.TLP1.Controls.Count = 0
                For Each c In TLP1.Controls
                    c.dispose
                Next
            Loop
            ReDim FanProfileArray(1, 0)
            Me.TLP1.RowCount = 0
            Counter = -1
        Catch
        End Try
    End Sub

    Private Sub ByLayerChk_CheckedChanged(sender As Object, e As EventArgs) Handles ByLayerChk.CheckedChanged
        On Error Resume Next
        If Me.ByLayerChk.Checked Then
            Me.GroupBox1.Visible = True
            Me.GroupBox2.Visible = False
            Me.Label6.Text = "NOTE: Your last change continues through to the end of the file."
        Else
            Me.GroupBox2.Visible = True
            Me.GroupBox1.Visible = False
            Me.Label6.Text = "NOTE:  If you name the last layer you need to adjust the ""Final Speed""."
        End If
    End Sub

    Private Sub ByFeatureChk_CheckedChanged(sender As Object, e As EventArgs) Handles ByFeatureChk.CheckedChanged
        On Error Resume Next
        If Me.ByFeatureChk.Checked Then
            Me.GroupBox1.Visible = False
            Me.GroupBox2.Visible = True
            Me.Label6.Text = "NOTE:  If you name the last layer you need to adjust the ""Final Speed""."
        Else
            Me.GroupBox2.Visible = False
            Me.GroupBox1.Visible = True
            Me.Label6.Text = "NOTE:  Your last change continues through to the end of the file."
        End If
    End Sub

    Private Sub CancelTypeBut_Click(sender As Object, e As EventArgs) Handles CancelTypeBut.Click
        EnderMainForm.PrResponse = False
        With Me
            .TypeStartLayerBox.Text = "0"
            .TypeEndLayerBox.Text = "1"
            FanNewGcodeFile.Close()
        End With
        Try
            My.Computer.FileSystem.DeleteFile(EnderMainForm.SaveFileDialog1.FileName,
        Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
        Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Catch ex As Exception

        End Try
        Me.Hide()
    End Sub

    Private Sub CreateTypeBut_Click(sender As Object, e As EventArgs) Handles CreateTypeBut.Click
        EnderMainForm.PrResponse = True
        LayerSearchStr = ";LAYER:" & Me.TypeStartLayerBox.Text
        ReDim FanFeatureArray(8, 1)
        Dim CurrentFanSpeed As String
        CurrentFanSpeed = "0"
        FanFeatureArray(0, 0) = ";TYPE:SKIRT"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(0, 1) = CStr(Math.Ceiling(Val(Me.SpeedSkirt.Text) / 100 * 255))
        Else
            FanFeatureArray(0, 1) = Format(Val(Me.SpeedSkirt.Text) / 100, "0.0")
        End If
        FanFeatureArray(1, 0) = ";TYPE:WALL-INNER"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(1, 1) = CStr(Math.Ceiling(Val(Me.SpeedWallInner.Text) / 100 * 255))
        Else
            FanFeatureArray(1, 1) = Format(Val(Me.SpeedWallInner.Text) / 100, "0.0")
        End If
        FanFeatureArray(2, 0) = ";TYPE:WALL-OUTER"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(2, 1) = CStr(Math.Ceiling(Val(Me.SpeedWallOuter.Text) / 100 * 255))
        Else
            FanFeatureArray(2, 1) = Format(Val(Me.SpeedWallOuter.Text) / 100, "0.0")
        End If
        FanFeatureArray(3, 0) = ";TYPE:FILL"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(3, 1) = CStr(Math.Ceiling(Val(Me.SpeedFill.Text) / 100 * 255))
        Else
            FanFeatureArray(3, 1) = Format(Val(Me.SpeedFill.Text) / 100, "0.0")
        End If
        FanFeatureArray(4, 0) = ";TYPE:SKIN"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(4, 1) = CStr(Math.Ceiling(Val(Me.SpeedSkin.Text) / 100 * 255))
        Else
            FanFeatureArray(4, 1) = Format(Val(Me.SpeedSkin.Text) / 100, "0.0")
        End If
        FanFeatureArray(5, 0) = ";TYPE:SUPPORT-INTERFACE"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(5, 1) = CStr(Math.Ceiling(Val(Me.SpeedInterF.Text) / 100 * 255))
        Else
            FanFeatureArray(5, 1) = Format(Val(Me.SpeedInterF.Text) / 100, "0.0")
        End If
        FanFeatureArray(6, 0) = ";TYPE:SUPPORT"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(6, 1) = CStr(Math.Ceiling(Val(Me.SpeedSupport.Text) / 100 * 255))
        Else
            FanFeatureArray(6, 1) = Format(Val(Me.SpeedSupport.Text) / 100, "0.0")
        End If
        FanFeatureArray(7, 0) = ";TYPE:PRIME TOWER"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(7, 1) = CStr(Math.Ceiling(Val(Me.SpeedPrime.Text) / 100 * 255))
        Else
            FanFeatureArray(7, 1) = Format(Val(Me.SpeedPrime.Text) / 100, "0.0")
        End If
        FanFeatureArray(8, 0) = ";BRIDGE"
        If Me.PWMopt.Checked = True Then
            FanFeatureArray(8, 1) = CStr(Math.Ceiling(Val(Me.SpeedBridge.Text) / 100 * 255))
        Else
            FanFeatureArray(8, 1) = Format(Val(Me.SpeedBridge.Text) / 100, "0.0")
        End If
        Me.Hide()
        EnderMainForm.BringToFront()
        Dim NewFanString = ""
        If EnderMainForm.PrResponse = False Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim DataLine As String
        DataLine = Me.FanOriginalFile.readline
        DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
        If Me.FanFeatureArray(0, 0) = "" Then
            MsgBox("There is no Fan Feature profile.  The process will end now.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Do Until InStr(DataLine, ";Generated") > 0
            Me.FanNewGcodeFile.WriteLine(DataLine)
            DataLine = Me.FanOriginalFile.readline
        Loop
        Me.FanNewGcodeFile.WriteLine(";POSTPROCESSED by Greg's Toolbox (Cooling by Feature)")
        Me.FanNewGcodeFile.WriteLine(DataLine)
        DataLine = Me.FanOriginalFile.ReadLine
        Do Until Me.FanOriginalFile.EndOfStream = True
            Try
                Do Until DataLine = ";LAYER:" & Me.TypeStartLayerBox.Text
                    If Strings.Left(DataLine, 6) = "M106 S" Or Strings.Left(DataLine, 4) = "M107" Then
                        DataLine = FanOriginalFile.ReadLine
                    End If
                    Me.FanNewGcodeFile.WriteLine(DataLine)
                    DataLine = Me.FanOriginalFile.ReadLine
                    If Val(Me.TypeStartLayerBox.Text) > 0 Then
                        If Strings.Left(DataLine, 8) = ";LAYER:0" Then
                            FanNewGcodeFile.WriteLine("M106 S0")
                        End If
                    End If
                Loop
                Me.FanNewGcodeFile.WriteLine(DataLine)
                DataLine = Me.FanOriginalFile.ReadLine
                Do Until DataLine = ";LAYER:" & Me.TypeEndLayerBox.Text Or Me.FanOriginalFile.EndOfStream = True
                    If InStr(DataLine, "M107") > 0 Or InStr(DataLine, "M106") > 0 Then
                        If InStr(DataLine, "M106 S0") > 0 Then
                            DataLine = DataLine
                        Else
                            DataLine = ""
                        End If
                    End If
                    If Strings.Left(DataLine, 1) = ";" Then
                        With Me
                            NewFanString = ""
                            If InStr(DataLine, .FanFeatureArray(0, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(0, 1) 'SKIRT
                                CurrentFanSpeed = .FanFeatureArray(0, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(1, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(1, 1) 'Wall-Inner
                                CurrentFanSpeed = .FanFeatureArray(1, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(2, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(2, 1) 'Wall-Outer
                                CurrentFanSpeed = .FanFeatureArray(2, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(3, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(3, 1) 'fill
                                CurrentFanSpeed = .FanFeatureArray(3, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(4, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(4, 1) 'skin
                                CurrentFanSpeed = .FanFeatureArray(4, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(5, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(5, 1) 'supt interface
                                CurrentFanSpeed = .FanFeatureArray(5, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(6, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(6, 1) 'Supt
                                CurrentFanSpeed = .FanFeatureArray(6, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(7, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(7, 1) 'prime Tower
                                CurrentFanSpeed = .FanFeatureArray(7, 1)
                            ElseIf InStr(DataLine, .FanFeatureArray(8, 0)) > 0 Then
                                NewFanString = "M106 S" & .FanFeatureArray(8, 1) 'bridge
                                CurrentFanSpeed = .FanFeatureArray(8, 1)
                            End If
                        End With
                    End If
                    If DataLine <> "" Then
                        FanNewGcodeFile.WriteLine(DataLine)
                    End If
                    If NewFanString <> "" Then
                        FanNewGcodeFile.WriteLine(NewFanString)
                        NewFanString = ""
                    End If
                    DataLine = Me.FanOriginalFile.ReadLine
                    If InStr(DataLine, "End of Gcode") > 0 Then
                        FanNewGcodeFile.WriteLine("M106 S0 ;turn off fan")
                    End If
                Loop
                If DataLine = ";LAYER:" & Me.TypeEndLayerBox.Text Then
                    FanNewGcodeFile.WriteLine(DataLine)
                    FanNewGcodeFile.WriteLine("M106 S" & Math.Ceiling(Val(FinalSpeedBox.Text) / 100 * 255))
                    DataLine = FanOriginalFile.ReadLine
                    'GO THROUGH AND REMOVE THE REST OF THE M106 LINES
                    Do Until FanOriginalFile.EndOfStream = True
                        If InStr(DataLine, "M107") > 0 Or InStr(DataLine, "M106") > 0 Then
                            DataLine = ""
                        End If
                        If InStr(DataLine, "M104 S0") > 0 Then
                            FanNewGcodeFile.WriteLine("M106 S0 ;turn off fan")
                        End If
                        FanNewGcodeFile.WriteLine(DataLine)
                        DataLine = FanOriginalFile.ReadLine
                    Loop

                    GoTo SkipOut
                End If
            Catch ex As Exception
                Exit Do
            End Try
        Loop
SkipOut:
        Do Until Me.FanOriginalFile.EndOfStream = True
            Me.FanNewGcodeFile.WriteLine(DataLine)
            If Me.FanOriginalFile.EndOfStream = True Then GoTo SkipOut2
            DataLine = Me.FanOriginalFile.ReadLine
        Loop
SkipOut2:
        FanOriginalFile.Close
        FanNewGcodeFile.Close()
        EnderMainForm.TextBox1.Text &= vbCrLf & vbCrLf & "Cooling file completed"
        EnderMainForm.Refresh()
        Dim AResponse As MsgBoxResult
        AResponse = MsgBox("The file Is complete" & vbCr & vbCr & "Do you want to open the New file?", vbYesNo, "Greg's Toolbox")
        If AResponse = vbYes Then Call OpenCoolingFile(EnderMainForm.SaveFileDialog1.FileName)
    End Sub

    Private Sub SpeedSkirt_leave(sender As Object, e As EventArgs) Handles SpeedSkirt.Leave
        If Not IsNumeric(Val(Me.SpeedSkirt.Text)) Then
            MsgBox("The Skirt Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedSkirt.Text) > 100 Then Me.SpeedSkirt.Text = "100"
        If Val(Me.SpeedSkirt.Text) < 0 Then Me.SpeedSkirt.Text = "0"
    End Sub

    Private Sub SpeedWallInner_leave(sender As Object, e As EventArgs) Handles SpeedWallInner.Leave
        If Not IsNumeric(Val(Me.SpeedWallInner.Text)) Then
            MsgBox("The Wall-Inner Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedWallInner.Text) > 100 Then Me.SpeedWallInner.Text = "100"
        If Val(Me.SpeedWallInner.Text) < 0 Then Me.SpeedWallInner.Text = "0"
    End Sub

    Private Sub SpeedWallOuter_leave(sender As Object, e As EventArgs) Handles SpeedWallOuter.Leave
        If Not IsNumeric(Val(Me.SpeedWallOuter.Text)) Then
            MsgBox("The Wall-Outer Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedWallOuter.Text) > 100 Then Me.SpeedWallOuter.Text = "100"
        If Val(Me.SpeedWallOuter.Text) < 0 Then Me.SpeedWallOuter.Text = "0"
    End Sub

    Private Sub SpeedFill_leave(sender As Object, e As EventArgs) Handles SpeedFill.Leave
        If Not IsNumeric(Val(Me.SpeedFill.Text)) Then
            MsgBox("The Fill Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedFill.Text) > 100 Then Me.SpeedFill.Text = "100"
        If Val(Me.SpeedFill.Text) < 0 Then Me.SpeedFill.Text = "0"
    End Sub

    Private Sub SpeedSkin_leave(sender As Object, e As EventArgs) Handles SpeedSkin.Leave
        If Not IsNumeric(Val(Me.SpeedSkin.Text)) Then
            MsgBox("The Skin Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedSkin.Text) > 100 Then Me.SpeedSkin.Text = "100"
        If Val(Me.SpeedSkin.Text) < 0 Then Me.SpeedSkin.Text = "0"
    End Sub

    Private Sub SpeedSupport_leave(sender As Object, e As EventArgs) Handles SpeedSupport.Leave
        If Not IsNumeric(Val(Me.SpeedSupport.Text)) Then
            MsgBox("The Support Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedSupport.Text) > 100 Then Me.SpeedSupport.Text = "100"
        If Val(Me.SpeedSupport.Text) < 0 Then Me.SpeedSupport.Text = "0"
    End Sub

    Private Sub SpeedPrime_leave(sender As Object, e As EventArgs) Handles SpeedPrime.Leave
        If Not IsNumeric(Val(Me.SpeedPrime.Text)) Then
            MsgBox("The Prime Tower Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedPrime.Text) > 100 Then Me.SpeedPrime.Text = "100"
        If Val(Me.SpeedPrime.Text) < 0 Then Me.SpeedPrime.Text = "0"
    End Sub

    Private Sub SpeedBridge_leave(sender As Object, e As EventArgs) Handles SpeedBridge.Leave
        If Not IsNumeric(Val(Me.SpeedBridge.Text)) Then
            MsgBox("The Bridge Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedBridge.Text) > 100 Then Me.SpeedBridge.Text = "100"
        If Val(Me.SpeedBridge.Text) < 0 Then Me.SpeedBridge.Text = "0"
    End Sub

    Private Sub SpeedInterF_leave(sender As Object, e As EventArgs) Handles SpeedInterF.Leave
        If Not IsNumeric(Val(Me.SpeedInterF.Text)) Then
            MsgBox("The Bridge Speed Value must be a number from 0 to 100")
        End If
        If Val(Me.SpeedInterF.Text) > 100 Then Me.SpeedInterF.Text = "100"
        If Val(Me.SpeedInterF.Text) < 0 Then Me.SpeedInterF.Text = "0"
    End Sub

    Private Sub TypeEndLayerBox_TextChanged(sender As Object, e As EventArgs) Handles TypeEndLayerBox.TextChanged
        With Me
            If Val(.TypeEndLayerBox.Text) = -1 Then
                .FinalLabel.Enabled = False
                .FinalLabel2.Enabled = False
                .FinalSpeedBox.Enabled = False
            ElseIf Val(Me.TypeEndLayerBox.Text) <= Val(Me.TypeStartLayerBox.Text) Then
                .FinalLabel.Enabled = False
                .FinalLabel2.Enabled = False
                .FinalSpeedBox.Enabled = False
            ElseIf Val(Me.TypeEndLayerBox.Text) > Val(Me.TypeStartLayerBox.Text) And Val(Me.TypeEndLayerBox.Text) <> -1 Then
                .FinalLabel.Enabled = True
                .FinalLabel2.Enabled = True
                .FinalSpeedBox.Enabled = True
            End If
        End With
    End Sub

    Private Sub TypeEndLayerBox_Leave(sender As Object, e As EventArgs) Handles TypeEndLayerBox.Leave
        If Me.TypeEndLayerBox.Text <> "-1" Then
            If Val(Me.TypeEndLayerBox.Text) <= Val(Me.TypeStartLayerBox.Text) Then
                MsgBox("The END LAYER must be greater than the START LAYER.", vbOKOnly, "Greg's SD Print Tool")
                Me.TypeEndLayerBox.Text = CStr(Val(Me.TypeStartLayerBox.Text) + 1)
            End If
        End If
    End Sub

    Public Sub OpenCoolingFile(TheCoolingFile As String)
        Try
            If IsRunningExe("notepad.exe") Then
                Dim MyGcodeFile = TheCoolingFile
                Do Until InStr(MyGcodeFile, "\") = 0
                    MyGcodeFile = Strings.Right(MyGcodeFile, Len(MyGcodeFile) - InStr(1, MyGcodeFile, "\"))
                Loop
                AppActivate(MyGcodeFile & " - Notepad")
                If Err.Number <> 0 Then
                    System.Diagnostics.Process.Start("notepad.exe", TheCoolingFile)
                    Err.Clear()
                End If
                Exit Sub
            End If
            System.Diagnostics.Process.Start("notepad.exe", TheCoolingFile)
        Catch
            MsgBox("There was an error attempting to open the file in NotePad.", vbOKOnly, "Greg's Toolbox")
        End Try
    End Sub

    Public Sub ContinueFanProfile()
        Dim LineToEnter As String
        Dim ArrayIndex As Integer = 0
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim DataLine As String
        DataLine = Me.FanOriginalFile.ReadLine
        DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
        If Me.FanProfileArray(0, 0) = "" Then
            MsgBox("There is no fan profile.  The process will end now.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Do Until InStr(DataLine, ";Generated", vbTextCompare) > 0
            Me.FanNewGcodeFile.WriteLine(DataLine)
            DataLine = Me.FanOriginalFile.ReadLine
        Loop
        Me.FanNewGcodeFile.WriteLine(";POSTPROCESSED Greg's Toolbox (Cooling by Layer)")
        Me.FanNewGcodeFile.WriteLine(DataLine)
        DataLine = Me.FanOriginalFile.ReadLine
        Do Until Me.FanOriginalFile.EndOfStream = True
            Try
                Do Until InStr(DataLine, Me.FanProfileArray(0, ArrayIndex), vbTextCompare) > 0 And Len(DataLine) = Len(Me.FanProfileArray(0, ArrayIndex))
                    If InStr(DataLine, "M107", vbTextCompare) > 0 Or InStr(DataLine, "M106", vbTextCompare) > 0 Then
                        If InStr(DataLine, "M106 S0 ;Turn-off fan") > 0 Then
                            DataLine = DataLine
                        Else
                            DataLine = ""
                        End If
                    End If
                    If DataLine <> "" Then
                        Me.FanNewGcodeFile.WriteLine(DataLine)
                    End If
                    If Me.FanOriginalFile.EndOfStream = True Then Exit Do
                    DataLine = Me.FanOriginalFile.ReadLine
                Loop
                LineToEnter = Me.FanProfileArray(1, ArrayIndex)
                ArrayIndex += 1
                If ArrayIndex <= UBound(Me.FanProfileArray, 2) Then
                    Me.FanNewGcodeFile.WriteLine(DataLine)
                    Me.FanNewGcodeFile.WriteLine(LineToEnter)
                    DataLine = Me.FanOriginalFile.ReadLine
                ElseIf ArrayIndex > UBound(Me.FanProfileArray, 2) Then
                    Me.FanNewGcodeFile.WriteLine(DataLine)
                    Me.FanNewGcodeFile.WriteLine(LineToEnter)
                    DataLine = Me.FanOriginalFile.ReadLine
                    GoTo SkipOut
                End If
            Catch ex As Exception
                Exit Do
            End Try
        Loop
SkipOut:
        Do Until Me.FanOriginalFile.EndOfStream = True
            If InStr(DataLine, "M106", vbTextCompare) > 0 And Len(DataLine) < 10 Then
                DataLine = Me.FanOriginalFile.ReadLine
            End If
            Me.FanNewGcodeFile.WriteLine(DataLine)
            If Me.FanOriginalFile.EndOfStream = True Then GoTo SkipOut2
            DataLine = Me.FanOriginalFile.ReadLine
        Loop
SkipOut2:
        Me.FanOriginalFile.Close()
        Me.FanNewGcodeFile.Close()
        EnderMainForm.TextBox1.Text &= vbCrLf & "Completed"
        EnderMainForm.Refresh()
        Dim MsgResponse As MsgBoxResult = MsgBox("The file is complete" & vbCr & vbCr & "Do you want to open the new file?", vbYesNo, "Greg's Toolbox")
        If MsgResponse = vbYes Then Call Me.OpenCoolingFile(EnderMainForm.SaveFileDialog1.FileName)
    End Sub

    Private Sub TypeStartLayerBox_TextChanged(sender As Object, e As EventArgs) Handles TypeStartLayerBox.TextChanged
        If Val(Me.TypeStartLayerBox.Text) < 0 Then Me.TypeStartLayerBox.Text = "0"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Val(Me.TextBox1.Text) < 0 Then Me.TextBox1.Text = "0"
    End Sub

    Private Sub SpecialOpt_CheckedChanged(sender As Object, e As EventArgs) Handles SpecialOpt.CheckedChanged
        If Me.SpecialOpt.Checked = True Then
            Dim Aresponse = MsgBox("This option is used by very few printers.  Are you sure you want to enable it?", vbYesNo, "Greg's Toolbox)")
            If Aresponse = vbNo Then
                Me.PWMopt.Checked = True
            End If
        End If
    End Sub
End Class