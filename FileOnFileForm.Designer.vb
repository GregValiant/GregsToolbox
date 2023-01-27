<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileOnFileForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileOnFileForm))
        Me.GetFile2But = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SecondFilePathNameBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FirstFilePathNameBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TransitionBox = New System.Windows.Forms.TextBox()
        Me.GetFile1But = New System.Windows.Forms.Button()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.NewDOS83Box = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.NewFileNameBox = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.FinishBut = New System.Windows.Forms.Button()
        Me.ClearFormBut = New System.Windows.Forms.Button()
        Me.OpenGcode = New System.Windows.Forms.Button()
        Me.GenerateTransitionBut = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.RemoveSupts = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CreateNewBut = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgLabel = New System.Windows.Forms.Label()
        Me.CombineToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PauseLayerBox = New System.Windows.Forms.TextBox()
        Me.StartModeOpt2 = New System.Windows.Forms.RadioButton()
        Me.StartModeOpt1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PauseLayerBox2 = New System.Windows.Forms.TextBox()
        Me.ContModeOpt2 = New System.Windows.Forms.RadioButton()
        Me.ContModeOpt1 = New System.Windows.Forms.RadioButton()
        Me.File1OpenBut = New System.Windows.Forms.Button()
        Me.File2OpenBut = New System.Windows.Forms.Button()
        Me.GetFirstPauseLayerBut = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GetFile2But
        '
        Me.GetFile2But.BackColor = System.Drawing.Color.SandyBrown
        Me.GetFile2But.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetFile2But.Location = New System.Drawing.Point(15, 475)
        Me.GetFile2But.Name = "GetFile2But"
        Me.GetFile2But.Size = New System.Drawing.Size(506, 46)
        Me.GetFile2But.TabIndex = 5
        Me.GetFile2But.Text = "Get the ""Second File"" Name"
        Me.GetFile2But.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 525)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Second FIle Path and Name"
        '
        'SecondFilePathNameBox
        '
        Me.SecondFilePathNameBox.BackColor = System.Drawing.SystemColors.Window
        Me.SecondFilePathNameBox.Enabled = False
        Me.SecondFilePathNameBox.Location = New System.Drawing.Point(17, 563)
        Me.SecondFilePathNameBox.Name = "SecondFilePathNameBox"
        Me.SecondFilePathNameBox.Size = New System.Drawing.Size(598, 22)
        Me.SecondFilePathNameBox.TabIndex = 3
        Me.CombineToolTip.SetToolTip(Me.SecondFilePathNameBox, "Use the button")
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(658, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(443, 96)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Please Note:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Layer numbers in the GCODE file are assumed to start at ""0""." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The t" &
    "op file cannot be on a RAFT."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(221, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 17)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "First FIle Path and Name"
        '
        'FirstFilePathNameBox
        '
        Me.FirstFilePathNameBox.BackColor = System.Drawing.SystemColors.Window
        Me.FirstFilePathNameBox.Enabled = False
        Me.FirstFilePathNameBox.Location = New System.Drawing.Point(16, 208)
        Me.FirstFilePathNameBox.Name = "FirstFilePathNameBox"
        Me.FirstFilePathNameBox.Size = New System.Drawing.Size(595, 22)
        Me.FirstFilePathNameBox.TabIndex = 44
        Me.CombineToolTip.SetToolTip(Me.FirstFilePathNameBox, "Use the button")
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(675, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(399, 65)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Transition Code (editable)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The code in this text box will be the transition code" &
    ""
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TransitionBox
        '
        Me.TransitionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransitionBox.Location = New System.Drawing.Point(739, 252)
        Me.TransitionBox.Multiline = True
        Me.TransitionBox.Name = "TransitionBox"
        Me.TransitionBox.Size = New System.Drawing.Size(285, 219)
        Me.TransitionBox.TabIndex = 4
        Me.CombineToolTip.SetToolTip(Me.TransitionBox, "The code in the box is that code that will be used.  You may add commands but not" &
        " remove any.")
        '
        'GetFile1But
        '
        Me.GetFile1But.BackColor = System.Drawing.Color.Tan
        Me.GetFile1But.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetFile1But.Location = New System.Drawing.Point(15, 115)
        Me.GetFile1But.Name = "GetFile1But"
        Me.GetFile1But.Size = New System.Drawing.Size(506, 46)
        Me.GetFile1But.TabIndex = 64
        Me.GetFile1But.Text = "Get the ""First File"" Name"
        Me.CombineToolTip.SetToolTip(Me.GetFile1But, "When the file opens you can search for the data you need")
        Me.GetFile1But.UseVisualStyleBackColor = False
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.LemonChiffon
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(890, 702)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(131, 43)
        Me.CancelBut.TabIndex = 68
        Me.CancelBut.Text = "Exit"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(253, 732)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(212, 17)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "New File DOS 8.3 File Name"
        '
        'NewDOS83Box
        '
        Me.NewDOS83Box.BackColor = System.Drawing.SystemColors.Window
        Me.NewDOS83Box.Enabled = False
        Me.NewDOS83Box.Location = New System.Drawing.Point(99, 729)
        Me.NewDOS83Box.Name = "NewDOS83Box"
        Me.NewDOS83Box.Size = New System.Drawing.Size(144, 22)
        Me.NewDOS83Box.TabIndex = 71
        Me.NewDOS83Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CombineToolTip.SetToolTip(Me.NewDOS83Box, "DOS 8.3 names are used internally on many printers")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(205, 679)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(237, 17)
        Me.Label20.TabIndex = 70
        Me.Label20.Text = "New Gcode FIle Path and Name"
        '
        'NewFileNameBox
        '
        Me.NewFileNameBox.BackColor = System.Drawing.SystemColors.Window
        Me.NewFileNameBox.Enabled = False
        Me.NewFileNameBox.Location = New System.Drawing.Point(67, 701)
        Me.NewFileNameBox.Name = "NewFileNameBox"
        Me.NewFileNameBox.Size = New System.Drawing.Size(493, 22)
        Me.NewFileNameBox.TabIndex = 69
        Me.CombineToolTip.SetToolTip(Me.NewFileNameBox, "Use the button")
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(20, 594)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(595, 4)
        Me.Label23.TabIndex = 77
        '
        'FinishBut
        '
        Me.FinishBut.BackColor = System.Drawing.Color.GreenYellow
        Me.FinishBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinishBut.Location = New System.Drawing.Point(737, 498)
        Me.FinishBut.Name = "FinishBut"
        Me.FinishBut.Size = New System.Drawing.Size(285, 53)
        Me.FinishBut.TabIndex = 84
        Me.FinishBut.Text = "Write the New GCODE File"
        Me.FinishBut.UseVisualStyleBackColor = False
        '
        'ClearFormBut
        '
        Me.ClearFormBut.BackColor = System.Drawing.Color.PaleGreen
        Me.ClearFormBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearFormBut.Location = New System.Drawing.Point(737, 702)
        Me.ClearFormBut.Name = "ClearFormBut"
        Me.ClearFormBut.Size = New System.Drawing.Size(131, 43)
        Me.ClearFormBut.TabIndex = 86
        Me.ClearFormBut.Text = "Clear Form"
        Me.ClearFormBut.UseVisualStyleBackColor = False
        '
        'OpenGcode
        '
        Me.OpenGcode.BackColor = System.Drawing.Color.Aquamarine
        Me.OpenGcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenGcode.Location = New System.Drawing.Point(737, 626)
        Me.OpenGcode.Name = "OpenGcode"
        Me.OpenGcode.Size = New System.Drawing.Size(285, 58)
        Me.OpenGcode.TabIndex = 87
        Me.OpenGcode.Text = "Open the New Gcode File"
        Me.CombineToolTip.SetToolTip(Me.OpenGcode, "Open the new Gcode file you created.")
        Me.OpenGcode.UseVisualStyleBackColor = False
        '
        'GenerateTransitionBut
        '
        Me.GenerateTransitionBut.BackColor = System.Drawing.Color.Tan
        Me.GenerateTransitionBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GenerateTransitionBut.Location = New System.Drawing.Point(693, 127)
        Me.GenerateTransitionBut.Name = "GenerateTransitionBut"
        Me.GenerateTransitionBut.Size = New System.Drawing.Size(370, 46)
        Me.GenerateTransitionBut.TabIndex = 104
        Me.GenerateTransitionBut.Text = "Generate the Transition Code"
        Me.GenerateTransitionBut.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(14, 242)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(595, 4)
        Me.Label14.TabIndex = 105
        '
        'RemoveSupts
        '
        Me.RemoveSupts.AutoSize = True
        Me.RemoveSupts.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveSupts.Location = New System.Drawing.Point(110, 62)
        Me.RemoveSupts.Name = "RemoveSupts"
        Me.RemoveSupts.Size = New System.Drawing.Size(281, 21)
        Me.RemoveSupts.TabIndex = 116
        Me.RemoveSupts.Text = "Remove ALL Second File Supports"
        Me.CombineToolTip.SetToolTip(Me.RemoveSupts, "If the second file is in Relative Extrusion Mode then un-check this box.")
        Me.RemoveSupts.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(124, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(341, 25)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "First File (prints on the build plate)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(107, 256)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(417, 25)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Second File (prints on top of the First File)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CreateNewBut
        '
        Me.CreateNewBut.BackColor = System.Drawing.Color.Salmon
        Me.CreateNewBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateNewBut.Location = New System.Drawing.Point(67, 619)
        Me.CreateNewBut.Name = "CreateNewBut"
        Me.CreateNewBut.Size = New System.Drawing.Size(493, 53)
        Me.CreateNewBut.TabIndex = 121
        Me.CreateNewBut.Text = "Create and Save the New GCODE File"
        Me.CreateNewBut.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(17, 284)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(592, 84)
        Me.Label29.TabIndex = 126
        Me.Label29.Text = resources.GetString("Label29.Text")
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.Location = New System.Drawing.Point(739, 584)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(281, 16)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 127
        Me.ProgressBar1.Visible = False
        '
        'ProgLabel
        '
        Me.ProgLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgLabel.Location = New System.Drawing.Point(739, 564)
        Me.ProgLabel.Name = "ProgLabel"
        Me.ProgLabel.Size = New System.Drawing.Size(282, 17)
        Me.ProgLabel.TabIndex = 128
        Me.ProgLabel.Text = "Writing File"
        Me.ProgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgLabel.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PauseLayerBox)
        Me.GroupBox1.Controls.Add(Me.StartModeOpt2)
        Me.GroupBox1.Controls.Add(Me.StartModeOpt1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(34, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 63)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "How much of the file to include:"
        '
        'PauseLayerBox
        '
        Me.PauseLayerBox.Location = New System.Drawing.Point(196, 26)
        Me.PauseLayerBox.Name = "PauseLayerBox"
        Me.PauseLayerBox.Size = New System.Drawing.Size(94, 24)
        Me.PauseLayerBox.TabIndex = 2
        Me.PauseLayerBox.Text = "1"
        Me.PauseLayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StartModeOpt2
        '
        Me.StartModeOpt2.AutoSize = True
        Me.StartModeOpt2.Location = New System.Drawing.Point(345, 28)
        Me.StartModeOpt2.Name = "StartModeOpt2"
        Me.StartModeOpt2.Size = New System.Drawing.Size(142, 22)
        Me.StartModeOpt2.TabIndex = 1
        Me.StartModeOpt2.Text = "The Whole File"
        Me.StartModeOpt2.UseVisualStyleBackColor = True
        '
        'StartModeOpt1
        '
        Me.StartModeOpt1.AutoSize = True
        Me.StartModeOpt1.Checked = True
        Me.StartModeOpt1.Location = New System.Drawing.Point(16, 28)
        Me.StartModeOpt1.Name = "StartModeOpt1"
        Me.StartModeOpt1.Size = New System.Drawing.Size(163, 22)
        Me.StartModeOpt1.TabIndex = 0
        Me.StartModeOpt1.TabStop = True
        Me.StartModeOpt1.Text = "Up to Pause layer"
        Me.StartModeOpt1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PauseLayerBox2)
        Me.GroupBox2.Controls.Add(Me.ContModeOpt2)
        Me.GroupBox2.Controls.Add(Me.ContModeOpt1)
        Me.GroupBox2.Controls.Add(Me.RemoveSupts)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(34, 371)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(557, 89)
        Me.GroupBox2.TabIndex = 130
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Start the Second File at:"
        '
        'PauseLayerBox2
        '
        Me.PauseLayerBox2.Location = New System.Drawing.Point(222, 26)
        Me.PauseLayerBox2.Name = "PauseLayerBox2"
        Me.PauseLayerBox2.Size = New System.Drawing.Size(94, 24)
        Me.PauseLayerBox2.TabIndex = 117
        Me.PauseLayerBox2.Text = "1"
        Me.PauseLayerBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ContModeOpt2
        '
        Me.ContModeOpt2.AutoSize = True
        Me.ContModeOpt2.Location = New System.Drawing.Point(356, 28)
        Me.ContModeOpt2.Name = "ContModeOpt2"
        Me.ContModeOpt2.Size = New System.Drawing.Size(155, 22)
        Me.ContModeOpt2.TabIndex = 1
        Me.ContModeOpt2.Text = "Start at LAYER:0"
        Me.ContModeOpt2.UseVisualStyleBackColor = True
        '
        'ContModeOpt1
        '
        Me.ContModeOpt1.AutoSize = True
        Me.ContModeOpt1.Checked = True
        Me.ContModeOpt1.Location = New System.Drawing.Point(22, 28)
        Me.ContModeOpt1.Name = "ContModeOpt1"
        Me.ContModeOpt1.Size = New System.Drawing.Size(177, 22)
        Me.ContModeOpt1.TabIndex = 0
        Me.ContModeOpt1.TabStop = True
        Me.ContModeOpt1.Text = "Start at Pause layer"
        Me.ContModeOpt1.UseVisualStyleBackColor = True
        '
        'File1OpenBut
        '
        Me.File1OpenBut.BackColor = System.Drawing.Color.Aquamarine
        Me.File1OpenBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.File1OpenBut.Location = New System.Drawing.Point(531, 115)
        Me.File1OpenBut.Name = "File1OpenBut"
        Me.File1OpenBut.Size = New System.Drawing.Size(77, 46)
        Me.File1OpenBut.TabIndex = 132
        Me.File1OpenBut.Text = "Open"
        Me.File1OpenBut.UseVisualStyleBackColor = False
        '
        'File2OpenBut
        '
        Me.File2OpenBut.BackColor = System.Drawing.Color.Aquamarine
        Me.File2OpenBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.File2OpenBut.Location = New System.Drawing.Point(531, 475)
        Me.File2OpenBut.Name = "File2OpenBut"
        Me.File2OpenBut.Size = New System.Drawing.Size(77, 46)
        Me.File2OpenBut.TabIndex = 133
        Me.File2OpenBut.Text = "Open"
        Me.File2OpenBut.UseVisualStyleBackColor = False
        '
        'GetFirstPauseLayerBut
        '
        Me.GetFirstPauseLayerBut.BackColor = System.Drawing.Color.Aquamarine
        Me.GetFirstPauseLayerBut.Location = New System.Drawing.Point(16, 171)
        Me.GetFirstPauseLayerBut.Name = "GetFirstPauseLayerBut"
        Me.GetFirstPauseLayerBut.Size = New System.Drawing.Size(106, 31)
        Me.GetFirstPauseLayerBut.TabIndex = 134
        Me.GetFirstPauseLayerBut.Text = "Pauses 1st"
        Me.GetFirstPauseLayerBut.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Aquamarine
        Me.Button1.Location = New System.Drawing.Point(20, 527)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 31)
        Me.Button1.TabIndex = 135
        Me.Button1.Text = "Pauses 2nd"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FileOnFileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 813)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GetFirstPauseLayerBut)
        Me.Controls.Add(Me.File2OpenBut)
        Me.Controls.Add(Me.File1OpenBut)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgLabel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.CreateNewBut)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GenerateTransitionBut)
        Me.Controls.Add(Me.OpenGcode)
        Me.Controls.Add(Me.ClearFormBut)
        Me.Controls.Add(Me.FinishBut)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.NewDOS83Box)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.NewFileNameBox)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.GetFile1But)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TransitionBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FirstFilePathNameBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GetFile2But)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SecondFilePathNameBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FileOnFileForm"
        Me.Text = "Combine CURA GCODE Files"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub FileOnFileForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.StartModeOpt1.Checked = True Then
            Me.PauseLayerBox.Enabled = True
        Else
            Me.PauseLayerBox.Enabled = False
        End If
        If Me.ContModeOpt1.Checked = True Then
            Me.PauseLayerBox2.Enabled = True
        Else
            Me.PauseLayerBox2.Enabled = False
        End If
    End Sub

    Friend WithEvents GetFile2But As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents SecondFilePathNameBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents FirstFilePathNameBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TransitionBox As TextBox
    Friend WithEvents GetFile1But As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents NewDOS83Box As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents NewFileNameBox As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents FinishBut As Button
    Friend WithEvents ClearFormBut As Button
    Friend WithEvents OpenGcode As Button
    Friend WithEvents GenerateTransitionBut As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents RemoveSupts As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents CreateNewBut As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ProgLabel As Label
    Friend WithEvents CombineToolTip As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents StartModeOpt2 As RadioButton
    Friend WithEvents StartModeOpt1 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ContModeOpt2 As RadioButton
    Friend WithEvents ContModeOpt1 As RadioButton
    Friend WithEvents PauseLayerBox As TextBox
    Friend WithEvents PauseLayerBox2 As TextBox
    Friend WithEvents File1OpenBut As Button
    Friend WithEvents File2OpenBut As Button
    Friend WithEvents GetFirstPauseLayerBut As Button
    Friend WithEvents Button1 As Button
End Class
