Public Class PostProcessForm
    Public ScaleResponse As Boolean

    Private Sub CoolingProfileBut_Click(sender As Object, e As EventArgs) Handles CoolingProfileBut.Click
        myResponse = MsgBox("This command will remove all existing M106 and M107 lines in a Cura Gcode file.  New M106 lines will be added from a profile you create." & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If myResponse = vbNo Then Exit Sub
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX) 'Use Open File Dialog to get the name of the gcode file to be altered.
        If FirstFile = "" Then Exit Sub
        Dim LineToEnter = ""
        Dim ImportFileName = FirstFile
        Dim fs
        fs = CreateObject("Scripting.FileSystemObject")
        FanProfileForm.FanOriginalFile = fs.OpenTextFile(ImportFileName, 1, False)
        FanProfileForm.MaxLayer = -1
        Dim SearchLine As String
        Dim MaxLayerFound
        Do Until FanProfileForm.MaxLayer > -1
            SearchLine = FanProfileForm.FanOriginalFile.readline
            MaxLayerFound = InStr(SearchLine, ";LAYER_COUNT:")
            If MaxLayerFound > 0 Then
                FanProfileForm.MaxLayer = Strings.Right(SearchLine, Len(SearchLine) - 13) - 1
                FanProfileForm.Label22.Text = "Top Layer# is:  " & FanProfileForm.MaxLayer
                FanProfileForm.FanOriginalFile.close
                FanProfileForm.FanOriginalFile = fs.OpenTextFile(ImportFileName, 1, False)
            End If
        Loop
        With EnderMainForm
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = "*.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then 'Use Save File dialog to create a new text file the a specified name *.gcode.
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                fs = CreateObject("Scripting.FileSystemObject")
                FanProfileForm.FanNewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                FanProfileForm.FanOriginalFile.close
                Exit Sub
            End If
        End With
        Dim MySlicer = FindSlicer(ImportFileName) 'find the slicer that created the gcode file so "layers #'s" can be found.
        FanProfileForm.FanArrayIndex = 0
        ReDim FanProfileForm.FanProfileArray(1, 0)
        FanProfileForm.Counter = -1
        FanProfileForm.TextBox1.Text = 0
        FanProfileForm.TextBox2.Text = 0
        FanProfileForm.ShowDialog() 'Show the Fan Profile Form
    End Sub

    Private Sub ChangRetractBut_Click(sender As Object, e As EventArgs) Handles ChangRetractBut.Click
        On Error Resume Next
        Dim MyResponse = MsgBox("This will change all the RETRACTIONS in an existing GCODE file and create a new file.  Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
        EnderMainForm.NewRetractionDistance = InputBox("Please enter the new Retraction Distance.", "Retraction Distance", "5")
        If EnderMainForm.NewRetractionDistance = "" Then
            MsgBox("You must enter a retraction distance.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PostStr = ";POSTPROCESSED Greg's Toolbox Retract Distance Change"
        Call EnderMainForm.FilamentDiameterChange(1, EnderMainForm.NewRetractionDistance, PostStr)
    End Sub

    Private Sub ChangeZhopBut_Click(sender As Object, e As EventArgs) Handles ChangeZhopBut.Click
        Dim MyResponse = MsgBox("This will change Z-Hops in an existing GCODE file and create a new file.  You can change the Z-Hop height from certain layers.  You cannot add Z-Hops to a file that doesn't have them.  You can lower the Z-Hop height down to ""0""" & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
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
        AlterZEndLayer += 1
        Dim NewZHopHgt = InputBox("Please enter the New Z-Hop Height. (NOTE: Enter ""0"" for No Z-Hop).", "New Z-Hop Height", "0")
        If NewZHopHgt = "" Or Val(NewZHopHgt) < 0 Then
            MsgBox("You must enter a valid Z-Hop replacement height.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Call EnderMainForm.ZHOP_Change(AlterZStartLayer, AlterZEndLayer, NewZHopHgt)
    End Sub

    Private Sub FilLittleToBigBut_Click(sender As Object, e As EventArgs) Handles FilLittleToBigBut.Click
        Dim MyResponse = MsgBox("This will change all the extrusions in a GCODE file from 1.75 dia filament to 2.85 dia filament.  Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
        EnderMainForm.NewRetractionDistance = InputBox("Adjusting the retraction distance can result in extremely long retractions.  Please enter the Retraction Distance you want to use for the 2.85mm filament.", "Retraction Distance", "7")
        If EnderMainForm.NewRetractionDistance = "" Then
            MsgBox("You must enter a retraction distance.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PostStr = ";POSTPROCESSED Greg's Toolbox Filament Dia Change to 2.85"
        Call EnderMainForm.FilamentDiameterChange(0.37704, EnderMainForm.NewRetractionDistance, PostStr)
    End Sub

    Private Sub FilBigToLittleBut_Click(sender As Object, e As EventArgs) Handles FilBigToLittleBut.Click
        Dim MyResponse = MsgBox("This will change all the extrusions in a GCODE file from 2.85 dia filament to 1.75 dia filament.  Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
        EnderMainForm.NewRetractionDistance = InputBox("Adjusting the retraction distance can result in extremely long retractions.  Please enter the Retraction Distance you want to use for the 1.75mm filament.", "Retraction Distance", "5")
        If EnderMainForm.NewRetractionDistance = "" Then
            MsgBox("You must enter a retraction distance.", vbOKOnly, "Greg's Toolbox")
            Exit Sub
        End If
        Dim PostStr = ";POSTPROCESSED Greg's Toolbox Filament Dia Change to 1.75"
        Call EnderMainForm.FilamentDiameterChange(2.65225, EnderMainForm.NewRetractionDistance, PostStr)
    End Sub

    Private Sub FileOnFileBut_Click(sender As Object, e As EventArgs) Handles FIleOnFIleBut.Click
        'MsgBox("Work in Progress", vbOKOnly, "Greg's Toolbox")
        'Exit Sub
        FileOnFileForm.Show()
        FileOnFileForm.BringToFront()
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        Me.Hide()
    End Sub

    Private Sub MirrorYBut_Click(sender As Object, e As EventArgs) Handles MirrorYBut.Click
        Dim MyResponse = MsgBox("This will MIRROR a GCODE file about the X axis and create a new file.  The ""Y"" Home Offset will be adjusted and all the ""Y"" values in the file will be re-written to ""Y * -1""" & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
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

        Call EnderMainForm.MirrorAboutY(MaxBedY, HomeOffsetY)
    End Sub

    Private Sub MirrorXBut_Click(sender As Object, e As EventArgs) Handles MirrorXBut.Click
        Dim MyResponse = MsgBox("This will MIRROR a GCODE file about the Y axis and create a new file.  The ""X"" Home Offset will be adjusted and all the ""X"" values in the file will be re-written to ""X * -1""" & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
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

        Call EnderMainForm.MirrorAboutX(MaxBedX, HomeOffsetX)
    End Sub

    Private Sub MicroLayerBut_Click(sender As Object, e As EventArgs) Handles MicroLayerBut.Click
        On Error GoTo TheHandler
        Dim FileResponse
        Dim NewHeight
        Dim LayerHeight
        Dim ConversionFactor
        Dim Gcode_File
        Dim NewFileResponse
        Dim FirstFile
        Dim Dataline As String
        Dim Zprev, Zcur
        Dim ImportFileName
        Dim Start
        Dim ELoc
        Dim OldEValue
        Dim OldEstr
        Dim NewEvalue
        Dim NewEstr
        Dim Zpresent
        Dim OldZ
        Dim NewZ
        Dim Zstr
        Dim Zspace
        Dim NewZstr
        Dim LineToWrite
        Dim MyShell
        Dim LineCount
        Dim NewGcodeFile
        Dim IndX = "First"
        Dim MyResponse = MsgBox("This will alter all the Layer Height moves in a GCODE file and will also adjust the extrusion volume (if there are extrusions) and create a New file." & vbCr & vbCr &
                                "The model must have been properly scaled in the Z prior to creating the Gcode.  You cannot have used Adaptive Layers in the Gcode." & vbCr & vbCr &
                                "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
        FirstFile = FileOnFileForm.GetFileName(IndX)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim ZLoc = ""
        Dim ZVal = ""
        Dim NewZVal = ""
        Dim PrevZ As String = "0"
        Dim fs
        fs = CreateObject("Scripting.FileSystemObject")
        Dim First_GCODE_File = fs.OpenTextFile(FirstFile, 1, False)
        'Dim NewGcodeFile As System.IO.StreamWriter
        With Me
            EnderMainForm.SaveFileDialog1.Title = "Create the New File"
            EnderMainForm.SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            EnderMainForm.SaveFileDialog1.FilterIndex = 1
            EnderMainForm.SaveFileDialog1.DefaultExt = "gcode"
            EnderMainForm.SaveFileDialog1.FileName = "*.gcode"
            If EnderMainForm.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                fs = CreateObject("Scripting.FileSystemObject")
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(EnderMainForm.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.close
                Exit Sub
            End If
        End With
        LayerHeight = InputBox("Enter the Layer Height of the main gcode file.", "Old Layer Height", ".2")
        If LayerHeight = False Or LayerHeight = "" Then Exit Sub
        NewHeight = InputBox("Enter the NEW Layer Height", "New Layer Height", ".01")
        If NewHeight = False Or NewHeight = "" Then Exit Sub
        ConversionFactor = LayerHeight / NewHeight
        'FileResponse = Application.GetOpenFilename("GCODE Files (*.gcode), *.gcode", 1, " Open the Main GCODE File...")
        'If FileResponse = False Then
        'Exit Sub
        'End If
        ImportFileName = FirstFile
        Dim f, ts, s
        fs = CreateObject("Scripting.FileSystemObject")
        Gcode_File = fs.OpenTextFile(ImportFileName, 1, False)
        'NewFileResponse = Application.GetSaveAsFilename("*.gcode", "GCODE Files (*.gcode), *.gcode", 1, "  Save the NEW gcode file")
        'If NewFileResponse = False Then Exit Sub
        'Dim outputFile = fs.CreateTextFile(NewGcodeFile, True)
        'NewGcodeFile = fs.OpenTextFile(outputFile, 1, True)
        Start = False
        Do Until Start = True
            Dataline = Gcode_File.readline
            NewGcodeFile.WriteLine(Dataline)
            If InStr(1, Dataline, "layer:0", vbTextCompare) > 0 Then Start = True
        Loop
        Do While Gcode_File.atendofstream <> True
            Dataline = Gcode_File.readline
            If Strings.Left(Dataline, 2) = "G0" Or Strings.Left(Dataline, 2) = "G1" Then
                If InStr(1, Dataline, " E", vbTextCompare) > 0 Then
                    ELoc = InStr(1, Dataline, " E", vbTextCompare)
                    OldEValue = Get_E_Value(Dataline, ELoc)
                    OldEstr = "E" & OldEValue
                    NewEvalue = OldEValue / ConversionFactor
                    NewEstr = "E" & NewEvalue
                    Dataline = Strings.Replace(Dataline, OldEstr, NewEstr, 1, -1, vbTextCompare)
                End If
                If InStr(1, Dataline, " Z", vbTextCompare) = 0 Then
                    NewGcodeFile.WriteLine(Dataline)
                    GoTo Kickout
                Else
                    Zpresent = InStr(1, Dataline, " Z", vbTextCompare)
                    OldZ = Get_Z_Value(Dataline, Zpresent)
                    NewZ = OldZ / ConversionFactor
                    Zstr = Strings.Right(Dataline, Len(Dataline) - Zpresent - 0)
                    Zspace = InStr(1, Zstr, " ", vbTextCompare)
                    If Zspace > 0 Then
                        Zstr = Strings.Left(Zstr, Zspace - 0)
                    End If
                    NewZstr = "Z" & NewZ
                    LineToWrite = Strings.Replace(Dataline, Zstr, NewZstr, 1, -1, vbTextCompare)
                    NewGcodeFile.WriteLine(LineToWrite)
                End If
            Else
                If InStr(Dataline, ";LAYER:", vbTextCompare) > 0 Then
                    FormsModule.StrToSend = "M118 " & Strings.Replace(GetLayerNumber(Dataline), ";", "", 1, 1, vbTextCompare)
                    If EnderMainForm.Vcomm.IsOpen Then
                        FormsModule.SendTheString(StrToSend)
                        Threading.Thread.Sleep(250)
                    End If
                End If
                NewGcodeFile.WriteLine(Dataline)
            End If
Kickout:
        Loop
        Gcode_File.Close
        NewGcodeFile.Close()
        MyResponse = MsgBox("The transition is complete." & vbCr & "Would you like to open the file in Notepad to view?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbYes Then
            MyShell = Shell("notepad.exe " & EnderMainForm.SaveFileDialog1.FileName, vbNormalFocus)
        End If
        Exit Sub
TheHandler:
        MsgBox("An error occurred." & vbLf & Err.Description & vbCr & "In line: " & LineCount, vbOKOnly, "Stoopid Engineering")
    End Sub

    Function Get_X_Value(Dataline, Xpresent)
        On Error Resume Next
        Dim Xstr
        Dim Xspace
        Xstr = Strings.Right(Dataline, Len(Dataline) - Xpresent - 1)
        Xspace = InStr(1, Xstr, " ", vbTextCompare)
        If Xspace > 0 Then
            Xstr = Strings.Left(Xstr, Xspace - 1)
        End If
        Get_X_Value = Val(Xstr)
    End Function

    Function Get_Y_Value(Dataline, Ypresent)
        On Error Resume Next
        Dim Ystr
        Dim Yspace
        Ystr = Strings.Right(Dataline, Len(Dataline) - Ypresent - 1)
        Yspace = InStr(1, Ystr, " ", vbTextCompare)
        If Yspace > 0 Then
            Ystr = Strings.Left(Ystr, Yspace - 1)
        End If
        Get_Y_Value = Val(Ystr)
    End Function

    Function Get_Z_Value(Dataline, Zpresent)
        On Error Resume Next
        Dim Zstr
        Dim Zspace
        Zstr = Strings.Right(Dataline, Len(Dataline) - Zpresent - 1)
        Zspace = InStr(1, Zstr, " ", vbTextCompare)
        If Zspace > 0 Then
            Zstr = Strings.Left(Zstr, Zspace - 1)
        End If
        Get_Z_Value = Val(Zstr)
    End Function

    Function Get_E_Value(Dataline, Epresent)
        On Error Resume Next
        Dim Estr
        Dim Espace
        Estr = Strings.Right(Dataline, Len(Dataline) - Epresent - 1)
        Espace = InStr(1, Estr, " ", vbTextCompare)
        If Espace > 0 Then
            Estr = Strings.Left(Estr, Espace - 1)
        End If
        Get_E_Value = Val(Estr)
    End Function
    Function Get_F_Value(Dataline, Fpresent)
        On Error Resume Next
        Dim Fstr
        Dim Fspace
        Fstr = Strings.Right(Dataline, Len(Dataline) - Fpresent - 1)
        Fspace = InStr(1, Fstr, " ", vbTextCompare)
        If Fspace > 0 Then
            Fstr = Strings.Left(Fstr, Fspace - 1)
        End If
        Get_F_Value = Val(Fstr)
    End Function
    Public Function GetLayerNumber(Dataline)
        Dim TheSpace = InStr(Dataline, " ", vbTextCompare)
        If TheSpace > 0 Then
            GetLayerNumber = Strings.Left(Dataline, TheSpace)
        Else
            GetLayerNumber = Dataline
        End If
    End Function

    Private Sub SearchBut_Click(sender As Object, e As EventArgs) Handles SearchBut.Click
        On Error Resume Next
        myResponse = MsgBox("This command will find text strings and replace them with new text." & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If myResponse = vbNo Then Exit Sub
        Dim IndX = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(IndX) 'Use Open File Dialog to get the name of the gcode file to be altered.
        If FirstFile = "" Then Exit Sub
        Dim LineToEnter = ""
        Dim ImportFileName = FirstFile
        Dim fs
        Dim SearchOriginalFile
        Dim SearchMaxLayer As Integer
        fs = CreateObject("Scripting.FileSystemObject")
        SearchOriginalFile = fs.OpenTextFile(ImportFileName, 1, False)
        SearchMaxLayer = -1
        Dim ReplaceGcodeFile
        Dim SearchLine As String
        Dim MaxLayerFound
        Do Until FanProfileForm.MaxLayer > -1
            SearchLine = FanProfileForm.FanOriginalFile.readline
            MaxLayerFound = InStr(SearchLine, ";LAYER_COUNT:")
            If MaxLayerFound > 0 Then
                SearchMaxLayer = Strings.Right(SearchLine, Len(SearchLine) - 13) - 1
                SearchOriginalFile.close
                SearchOriginalFile = fs.OpenTextFile(ImportFileName, 1, False)
            End If
        Loop
        With EnderMainForm
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = "*.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then 'Use Save File dialog to create a new text file the a specified name *.gcode.
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                fs = CreateObject("Scripting.FileSystemObject")
                ReplaceGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                SearchOriginalFile.close
                Exit Sub
            End If
        End With
        Dim MySlicer = FindSlicer(ImportFileName) 'find the slicer that created the gcode file so "layers #'s" can be found.
        SearchOriginalFile.close
        ReplaceGcodeFile.close()
        Call SearchAndReplace(ImportFileName, EnderMainForm.SaveFileDialog1.FileName)
    End Sub

    Private Sub SearchAndReplace(ImportFileName, SaveAsFile)
        On Error Resume Next
        SearchAndReplaceForm.ShowDialog()
        If myResponse = False Then Exit Sub
        Dim fs
        fs = CreateObject("Scripting.FileSystemObject")
        Dim SearchOriginalFile = fs.OpenTextFile(ImportFileName, 1, False)
        Dim ReplacementFile = My.Computer.FileSystem.OpenTextFileWriter(SaveAsFile, True)
        Dim DataLine As String
        Dim ExactMatch = SearchAndReplaceForm.ExactMatchOpt.Checked
        Dim SearchString = SearchAndReplaceForm.SearchStringBox.Text
        Dim ReplacementText = SearchAndReplaceForm.ReplaceStringBox.Text
        Do Until SearchOriginalFile.atendofstream = True
            DataLine = SearchOriginalFile.readline
            If InStr(DataLine, SearchString, vbTextCompare) > 0 Then
                If Not ExactMatch Then
                    DataLine = Strings.Replace(DataLine, SearchString, ReplacementText, 1, -1, vbTextCompare)
                ElseIf ExactMatch Then
                    If DataLine = SearchString And Strings.Len(DataLine) = Strings.Len(SearchString) Then
                        DataLine = ReplacementText
                    End If
                End If
            End If
            ReplacementFile.WriteLine(DataLine)
        Loop
        SearchOriginalFile.close
        ReplacementFile.Close()
    End Sub

    Private Sub ScaleGcodeBut_Click(sender As Object, e As EventArgs) Handles ScaleGcodeBut.Click
        Dim MyResponse = MsgBox("This will Scale a GCODE file UP or DOWN and create a new file.  The ""X"", ""Y"", ""Z"", and ""E"" values in the file will be re-calculated." & vbLf & vbLf & "Do you want to continue?", vbYesNo, "Greg's Toolbox")
        If MyResponse = vbNo Then Exit Sub
        With ScaleGcodeForm
            .XScaleBox.Text = "100.00"
            .YScaleBox.Text = "100.00"
            .ZScaleBox.Text = "100.00"
            '.LineOrigBox.Text = ""
            '.LineNewBox.Text = ""
            '.LayerOrigBox.Text = ""
            '.LayerNewBox.Text = ""
            '.FilOrigBox.Text = ""
            '.FilNewBox.Text = ""
            .RetrNewBox.Text = "0.00"
            ScaleResponse = False
            .ShowDialog()
        End With
        If ScaleResponse = False Then Exit Sub

        Dim XScaleFactor = Val(ScaleGcodeForm.XScaleBox.Text) / 100
        Dim YScaleFactor = Val(ScaleGcodeForm.YScaleBox.Text) / 100
        Dim ZScaleFactor = Val(ScaleGcodeForm.ZScaleBox.Text) / 100
        Dim OrigFilDia = Val(ScaleGcodeForm.FilOrigBox.Text)
        Dim NewFilDia = Val(ScaleGcodeForm.FilNewBox.Text)
        Dim OrigLineWidth = Val(ScaleGcodeForm.LineOrigBox.Text)
        Dim NewLineWidth = Val(ScaleGcodeForm.LineNewBox.Text)
        Dim OrigLayerHgt = Val(ScaleGcodeForm.LayerOrigBox.Text)
        Dim NewLayerHgt = Val(ScaleGcodeForm.LayerNewBox.Text)
        Dim PrintSpeed = Val(ScaleGcodeForm.PrSpeedNewBox.Text) * 60
        Dim TravelSpeed = Val(ScaleGcodeForm.TravSpeedNewBox.Text) * 60
        Dim ZHop As Boolean = vbNull
        Dim ZHopHgt = Val(ScaleGcodeForm.ZHopNewBox.Text)
        Dim ZHopSpeed = Val(ScaleGcodeForm.ZHopNewSpBox.Text) * 60
        Dim Retraction = False
        Dim RetractDist = Val(ScaleGcodeForm.RetrNewBox.Text)
        Dim RetractSpeed = Val(ScaleGcodeForm.RetrNewSpBox.Text) * 60
        Dim PrevX As Double = 0
        Dim PrevY As Double = 0
        Dim PrevZ As Double = 0
        Dim PrevE As Double = 0

        If ScaleGcodeForm.RetractChk.Checked = False Then
            RetractDist = 0
            Retraction = False
        Else
            Retraction = True
        End If
        If ScaleGcodeForm.ZHopChk.Checked = False Then
            ZHopHgt = 0
            ZHop = False
        Else
            ZHopHgt = Val(ScaleGcodeForm.ZHopNewBox.Text)
            ZHopSpeed = Val(ScaleGcodeForm.ZHopNewSpBox.Text) * 60
            ZHop = True
        End If
        Dim OrigEScale = (((OrigFilDia / 2) ^ 2) * Math.PI) / (OrigLineWidth * OrigLayerHgt) '30.06602
        Dim NewEScale = (((NewFilDia / 2) ^ 2) * Math.PI) / (NewLineWidth * NewLayerHgt)
        Dim EScaleFactor = OrigEScale / NewEScale

        Dim ScaleFile = "First"
        Dim FirstFile = FileOnFileForm.GetFileName(ScaleFile)
        If FirstFile = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(500)
        Dim XLoc = 0
        Dim XVal = ""
        Dim NewXVal = ""
        Dim YLoc = 0
        Dim YVal = ""
        Dim NewYVal = ""
        Dim ZLoc = 0
        Dim ZVal = ""
        Dim NewZVal = ""
        Dim ZPrev = ""
        Dim ELoc = 0
        Dim EVal = ""
        Dim NewEVal = ""
        Dim EPrev = ""
        Dim Retracted As Boolean
        Dim FLoc = 0
        Dim FVal = ""
        Dim NewFVal = ""
        Dim GCommand As String = ""
        Dim ReplacmentLine = ""
        Dim ImportFileName = FirstFile
        Dim fs
        fs = CreateObject("Scripting.FileSystemObject")
        Dim First_GCODE_File = fs.OpenTextFile(ImportFileName, 1, False)
        Dim NewGcodeFile As System.IO.StreamWriter
        With EnderMainForm
            .SaveFileDialog1.Title = "Create the New File"
            .SaveFileDialog1.Filter = "GCODE Files|*.gcode"
            .SaveFileDialog1.FilterIndex = 1
            .SaveFileDialog1.DefaultExt = "gcode"
            .SaveFileDialog1.FileName = "*.gcode"
            If .SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Threading.Thread.Sleep(500)
                fs = CreateObject("Scripting.FileSystemObject")
                NewGcodeFile = My.Computer.FileSystem.OpenTextFileWriter(.SaveFileDialog1.FileName, True)
            Else
                First_GCODE_File.close
                Exit Sub
            End If
        End With

        Dim DataLine = ""
        Dim PrevDataline = ""
        Do Until InStr(DataLine, "LAYER:0", vbTextCompare) > 0
            DataLine = First_GCODE_File.readline
            DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
            ZLoc = InStr(DataLine, " Z", vbTextCompare)
            If ZLoc > 0 Then
                ZPrev = ZVal
                ZVal = Get_Z_Value(DataLine, ZLoc)
                If ZLoc < PrevZ Then
                    ZHop = False
                Else
                    ZHop = True
                End If
            End If
            If InStr(DataLine, ";Generated with", vbTextCompare) > 0 Then
                NewGcodeFile.WriteLine(DataLine)
                DataLine = ";POSTPROCESSED Greg's Toolbox - Scale Gcode File"
            End If
            NewGcodeFile.WriteLine(DataLine)
        Loop
        NewGcodeFile.WriteLine(DataLine)
        Do Until First_GCODE_File.atendofstream = True
            DataLine = First_GCODE_File.readline
            DataLine = System.Text.RegularExpressions.Regex.Replace(DataLine, "[^\u0000-\u007F]", "")
            If Strings.Left(DataLine, 1) = ";" Or Strings.Left(DataLine, 1) = "M" Then
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If
            'Start
            If Strings.Left(DataLine, 2) = "G0" Or Strings.Left(DataLine, 2) = "G1" Then
                GCommand = Strings.Left(DataLine, 2)
                XLoc = InStr(DataLine, " X", vbTextCompare)
                If XLoc > 0 Then XVal = Get_X_Value(DataLine, XLoc)
                YLoc = InStr(DataLine, " Y", vbTextCompare)
                If YLoc > 0 Then YVal = Get_Y_Value(DataLine, YLoc)
                ZLoc = InStr(DataLine, " Z", vbTextCompare)
                If ZLoc > 0 Then ZVal = Get_Z_Value(DataLine, ZLoc)
                ELoc = InStr(DataLine, " E", vbTextCompare)
                If ELoc > 0 Then EVal = Get_E_Value(DataLine, ELoc)
                FLoc = InStr(DataLine, " F", vbTextCompare)
                If FLoc > 0 Then FVal = Get_F_Value(DataLine, FLoc)



                'zhop has F and Z
                'extrusion might have F, will have X Y E and no Z
                'Travel will have X Y and maybe Z no E
                'Condition 1 = G0 F9000 X82.843 Y82.067 Z0.7  Move up or Combing
                'Condition 2 = G1 F3000 X82.63 Y81.291 E0.0281 regular extrusion  Working Z = current Z
                'G1 X83.57 Y81.729 E22.85441   Regular extrusion
                'G1 F600 Z0.7  Z hop up  If ZHopUp = false then Z hop up = true.  Calculate the new Z hop amount and insert it.
                'G1 F600 Z0.2  Z hop down
                'G1 F2100 E17.85441  Retraction if E < previous E then Retracted = true Calculate the new retraction amount and subtract it from
                'the previous E and make this amount the Previous E?
                'G1 F2100 E22.85441  Prime if Retracted = true then Retracted = false

                'Condition 1 Move up for next layer or Combing move
                If GCommand = "G0" And ELoc = 0 And XLoc > 0 And YLoc > 0 Then
                    DataLine = Strings.Replace(DataLine, " X" & XVal, " X" & XVal * XScaleFactor, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " F" & FVal, " F" & TravelSpeed, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " Y" & YVal, " Y" & YVal * YScaleFactor, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " Z" & ZVal, " Z" & ZVal * ZScaleFactor, 1, -1, vbTextCompare)
                    NewGcodeFile.WriteLine(DataLine)
                    ZPrev = ZVal
                    ZHop = False
                    GoTo SkipOut
                End If
                'Condition 2 - Extrusion
                If GCommand = "G1" And ELoc > 0 And XLoc > 0 And YLoc > 0 And ZLoc = 0 Then
                    DataLine = Strings.Replace(DataLine, " X" & XVal, " X" & XVal * XScaleFactor, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " F" & FVal, " F" & TravelSpeed, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " Y" & YVal, " Y" & YVal * YScaleFactor, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " E" & EVal, " E" & Format(EVal * EScaleFactor, "0.00000"), 1, -1, vbTextCompare)
                    NewGcodeFile.WriteLine(DataLine)
                    GoTo SkipOut
                ElseIf GCommand = "G1" And ELoc = 0 And XLoc > 0 And YLoc > 0 And ZLoc > 0 Then
                    DataLine = Strings.Replace(DataLine, " X" & XVal, " X" & XVal * XScaleFactor, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " F" & FVal, " F" & PrintSpeed, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " Y" & YVal, " Y" & YVal * YScaleFactor, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " Z" & ZVal, " Z" & ZVal * ZScaleFactor, 1, -1, vbTextCompare)
                    NewGcodeFile.WriteLine(DataLine)
                    ZHop = False
                    PrevZ = ZVal
                    GoTo SkipOut
                ElseIf GCommand = "G1" And ELoc = 0 And XLoc = 0 And YLoc = 0 And ZLoc > 0 Then
                    If ZHop = vbNull Then ZHop = False
                    If Not ZHop Then
                        DataLine = Strings.Replace(DataLine, " Z" & ZVal, " Z" & (ZVal * ZScaleFactor) + ZHopHgt, 1, -1, vbTextCompare)
                        ZHop = True
                    Else
                        DataLine = Strings.Replace(DataLine, " Z" & ZVal, " Z" & (ZPrev * ZScaleFactor) - ZHopHgt, 1, -1, vbTextCompare)
                        ZHop = False
                    End If
                    DataLine = Strings.Replace(DataLine, " F" & FVal, " F" & ZHopSpeed, 1, -1, vbTextCompare)
                    NewGcodeFile.WriteLine(DataLine)
                    PrevZ = ZVal
                    GoTo SkipOut
                End If

                If Retraction = True Then
                    If EVal < PrevE And Not Retracted Then
                        NewEVal = PrevE - (RetractDist / EScaleFactor)
                    ElseIf EVal > PrevE And Retracted Then
                        NewEVal = PrevE + RetractDist * EScaleFactor
                    Else
                        NewEVal = EVal
                    End If
                    'DataLine = Strings.Replace
                    DataLine = Strings.Replace(DataLine, " F" & FVal, " F" & RetractSpeed, 1, -1, vbTextCompare)
                    DataLine = Strings.Replace(DataLine, " E" & EVal, " E" & NewEVal * EVal, 1, -1, vbTextCompare)
                Else
                    DataLine = ";" & DataLine
                End If
                NewGcodeFile.WriteLine(DataLine)
                GoTo SkipOut
            End If

SkipOut:
        Loop
        First_GCODE_File.close
        NewGcodeFile.Close()
    End Sub
End Class