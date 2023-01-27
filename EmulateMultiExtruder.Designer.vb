<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmulateMultiExtruder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmulateMultiExtruder))
        Me.ParkHeadChk = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CreateButton = New System.Windows.Forms.Button()
        Me.TimeOutBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PauseCmdBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ParkHeadXbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ParkHeadYbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T0MessageBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AddM117MsgChk = New System.Windows.Forms.CheckBox()
        Me.T1MessageBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T3MessageBox = New System.Windows.Forms.TextBox()
        Me.T3MessageLabel = New System.Windows.Forms.Label()
        Me.T2MessageBox = New System.Windows.Forms.TextBox()
        Me.T2MessageLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.T3But = New System.Windows.Forms.RadioButton()
        Me.T2But = New System.Windows.Forms.RadioButton()
        Me.T1But = New System.Windows.Forms.RadioButton()
        Me.CancelEBut = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.M83OptBut = New System.Windows.Forms.RadioButton()
        Me.M82OptBut = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GcodeAfterBox = New System.Windows.Forms.TextBox()
        Me.PreviewBut = New System.Windows.Forms.Button()
        Me.HelpBut = New System.Windows.Forms.Button()
        Me.BeepBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Preview1opt = New System.Windows.Forms.RadioButton()
        Me.Preview4opt = New System.Windows.Forms.RadioButton()
        Me.Preview3opt = New System.Windows.Forms.RadioButton()
        Me.Preview2opt = New System.Windows.Forms.RadioButton()
        Me.AddRetractChk = New System.Windows.Forms.CheckBox()
        Me.AddRetractAmountBox = New System.Windows.Forms.TextBox()
        Me.RetractLabel = New System.Windows.Forms.Label()
        Me.E1PrLab = New System.Windows.Forms.Label()
        Me.E1PrintTemp = New System.Windows.Forms.TextBox()
        Me.E2PrLab = New System.Windows.Forms.Label()
        Me.E2PrintTemp = New System.Windows.Forms.TextBox()
        Me.E3PrLab = New System.Windows.Forms.Label()
        Me.E3PrintTemp = New System.Windows.Forms.TextBox()
        Me.E4PrLab = New System.Windows.Forms.Label()
        Me.E4PrintTemp = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ParkHeadChk
        '
        Me.ParkHeadChk.AutoSize = True
        Me.ParkHeadChk.Checked = True
        Me.ParkHeadChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ParkHeadChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParkHeadChk.Location = New System.Drawing.Point(302, 257)
        Me.ParkHeadChk.Name = "ParkHeadChk"
        Me.ParkHeadChk.Size = New System.Drawing.Size(161, 24)
        Me.ParkHeadChk.TabIndex = 0
        Me.ParkHeadChk.Text = "Park the Head?"
        Me.ParkHeadChk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(194, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(383, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "How many extruders are used in the Gcode?"
        '
        'CreateButton
        '
        Me.CreateButton.BackColor = System.Drawing.Color.GreenYellow
        Me.CreateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateButton.Location = New System.Drawing.Point(122, 615)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(199, 45)
        Me.CreateButton.TabIndex = 3
        Me.CreateButton.Text = "Create the File"
        Me.CreateButton.UseVisualStyleBackColor = False
        '
        'TimeOutBox
        '
        Me.TimeOutBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeOutBox.Location = New System.Drawing.Point(229, 108)
        Me.TimeOutBox.Name = "TimeOutBox"
        Me.TimeOutBox.Size = New System.Drawing.Size(63, 27)
        Me.TimeOutBox.TabIndex = 5
        Me.TimeOutBox.Text = "30"
        Me.TimeOutBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(313, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(254, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Stepper Timeout (in minutes)"
        '
        'PauseCmdBox
        '
        Me.PauseCmdBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PauseCmdBox.Location = New System.Drawing.Point(284, 382)
        Me.PauseCmdBox.Name = "PauseCmdBox"
        Me.PauseCmdBox.Size = New System.Drawing.Size(63, 27)
        Me.PauseCmdBox.TabIndex = 7
        Me.PauseCmdBox.Text = "M0"
        Me.PauseCmdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(368, 387)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(278, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "The Pause Command (M0, M25)"
        '
        'ParkHeadXbox
        '
        Me.ParkHeadXbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParkHeadXbox.Location = New System.Drawing.Point(235, 288)
        Me.ParkHeadXbox.Name = "ParkHeadXbox"
        Me.ParkHeadXbox.Size = New System.Drawing.Size(60, 27)
        Me.ParkHeadXbox.TabIndex = 9
        Me.ParkHeadXbox.Text = "0"
        Me.ParkHeadXbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(309, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Park ""X"""
        '
        'ParkHeadYbox
        '
        Me.ParkHeadYbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParkHeadYbox.Location = New System.Drawing.Point(419, 288)
        Me.ParkHeadYbox.Name = "ParkHeadYbox"
        Me.ParkHeadYbox.Size = New System.Drawing.Size(60, 27)
        Me.ParkHeadYbox.TabIndex = 11
        Me.ParkHeadYbox.Text = "0"
        Me.ParkHeadYbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(493, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Park ""Y"""
        '
        'T0MessageBox
        '
        Me.T0MessageBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T0MessageBox.Location = New System.Drawing.Point(148, 426)
        Me.T0MessageBox.Name = "T0MessageBox"
        Me.T0MessageBox.Size = New System.Drawing.Size(277, 27)
        Me.T0MessageBox.TabIndex = 14
        Me.T0MessageBox.Text = "Red"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(108, 430)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "T0"
        '
        'AddM117MsgChk
        '
        Me.AddM117MsgChk.AutoSize = True
        Me.AddM117MsgChk.Checked = True
        Me.AddM117MsgChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AddM117MsgChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddM117MsgChk.Location = New System.Drawing.Point(168, 321)
        Me.AddM117MsgChk.Name = "AddM117MsgChk"
        Me.AddM117MsgChk.Size = New System.Drawing.Size(507, 24)
        Me.AddM117MsgChk.TabIndex = 12
        Me.AddM117MsgChk.Text = "Message to LCD and Greg's Toolbox (20 character max)"
        Me.AddM117MsgChk.UseVisualStyleBackColor = True
        '
        'T1MessageBox
        '
        Me.T1MessageBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T1MessageBox.Location = New System.Drawing.Point(493, 426)
        Me.T1MessageBox.Name = "T1MessageBox"
        Me.T1MessageBox.Size = New System.Drawing.Size(277, 27)
        Me.T1MessageBox.TabIndex = 16
        Me.T1MessageBox.Text = "White"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(454, 430)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "T1"
        '
        'T3MessageBox
        '
        Me.T3MessageBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T3MessageBox.Location = New System.Drawing.Point(493, 466)
        Me.T3MessageBox.Name = "T3MessageBox"
        Me.T3MessageBox.Size = New System.Drawing.Size(277, 27)
        Me.T3MessageBox.TabIndex = 20
        Me.T3MessageBox.Text = "Green"
        '
        'T3MessageLabel
        '
        Me.T3MessageLabel.AutoSize = True
        Me.T3MessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T3MessageLabel.Location = New System.Drawing.Point(454, 469)
        Me.T3MessageLabel.Name = "T3MessageLabel"
        Me.T3MessageLabel.Size = New System.Drawing.Size(30, 20)
        Me.T3MessageLabel.TabIndex = 19
        Me.T3MessageLabel.Text = "T3"
        '
        'T2MessageBox
        '
        Me.T2MessageBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T2MessageBox.Location = New System.Drawing.Point(148, 466)
        Me.T2MessageBox.Name = "T2MessageBox"
        Me.T2MessageBox.Size = New System.Drawing.Size(277, 27)
        Me.T2MessageBox.TabIndex = 18
        Me.T2MessageBox.Text = "Blue"
        '
        'T2MessageLabel
        '
        Me.T2MessageLabel.AutoSize = True
        Me.T2MessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T2MessageLabel.Location = New System.Drawing.Point(107, 469)
        Me.T2MessageLabel.Name = "T2MessageLabel"
        Me.T2MessageLabel.Size = New System.Drawing.Size(30, 20)
        Me.T2MessageLabel.TabIndex = 17
        Me.T2MessageLabel.Text = "T2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(248, 146)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(285, 20)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Extrusion Mode of the Gcode file"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.T3But)
        Me.GroupBox1.Controls.Add(Me.T2But)
        Me.GroupBox1.Controls.Add(Me.T1But)
        Me.GroupBox1.Location = New System.Drawing.Point(284, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 53)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'T3But
        '
        Me.T3But.AutoSize = True
        Me.T3But.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T3But.Location = New System.Drawing.Point(137, 18)
        Me.T3But.Name = "T3But"
        Me.T3But.Size = New System.Drawing.Size(40, 24)
        Me.T3But.TabIndex = 3
        Me.T3But.Text = "4"
        Me.T3But.UseVisualStyleBackColor = True
        '
        'T2But
        '
        Me.T2But.AutoSize = True
        Me.T2But.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T2But.Location = New System.Drawing.Point(75, 18)
        Me.T2But.Name = "T2But"
        Me.T2But.Size = New System.Drawing.Size(40, 24)
        Me.T2But.TabIndex = 2
        Me.T2But.Text = "3"
        Me.T2But.UseVisualStyleBackColor = True
        '
        'T1But
        '
        Me.T1But.AutoSize = True
        Me.T1But.Checked = True
        Me.T1But.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T1But.Location = New System.Drawing.Point(16, 18)
        Me.T1But.Name = "T1But"
        Me.T1But.Size = New System.Drawing.Size(40, 24)
        Me.T1But.TabIndex = 1
        Me.T1But.TabStop = True
        Me.T1But.Text = "2"
        Me.T1But.UseVisualStyleBackColor = True
        '
        'CancelEBut
        '
        Me.CancelEBut.BackColor = System.Drawing.Color.Khaki
        Me.CancelEBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelEBut.Location = New System.Drawing.Point(573, 615)
        Me.CancelEBut.Name = "CancelEBut"
        Me.CancelEBut.Size = New System.Drawing.Size(199, 45)
        Me.CancelEBut.TabIndex = 25
        Me.CancelEBut.Text = "Cancel"
        Me.CancelEBut.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.M83OptBut)
        Me.GroupBox2.Controls.Add(Me.M82OptBut)
        Me.GroupBox2.Location = New System.Drawing.Point(205, 169)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 52)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'M83OptBut
        '
        Me.M83OptBut.AutoSize = True
        Me.M83OptBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M83OptBut.Location = New System.Drawing.Point(201, 14)
        Me.M83OptBut.Name = "M83OptBut"
        Me.M83OptBut.Size = New System.Drawing.Size(153, 24)
        Me.M83OptBut.TabIndex = 2
        Me.M83OptBut.Text = "Relative (M83)"
        Me.M83OptBut.UseVisualStyleBackColor = True
        '
        'M82OptBut
        '
        Me.M82OptBut.AutoSize = True
        Me.M82OptBut.Checked = True
        Me.M82OptBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M82OptBut.Location = New System.Drawing.Point(16, 14)
        Me.M82OptBut.Name = "M82OptBut"
        Me.M82OptBut.Size = New System.Drawing.Size(158, 24)
        Me.M82OptBut.TabIndex = 1
        Me.M82OptBut.TabStop = True
        Me.M82OptBut.Text = "Absolute (M82)"
        Me.M82OptBut.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(97, 538)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(178, 40)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "(For multi-line use" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a comma separator)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(109, 518)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 20)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Gcode after Pause"
        '
        'GcodeAfterBox
        '
        Me.GcodeAfterBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GcodeAfterBox.Location = New System.Drawing.Point(300, 511)
        Me.GcodeAfterBox.Multiline = True
        Me.GcodeAfterBox.Name = "GcodeAfterBox"
        Me.GcodeAfterBox.Size = New System.Drawing.Size(472, 78)
        Me.GcodeAfterBox.TabIndex = 30
        '
        'PreviewBut
        '
        Me.PreviewBut.BackColor = System.Drawing.Color.Gold
        Me.PreviewBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviewBut.Location = New System.Drawing.Point(372, 609)
        Me.PreviewBut.Name = "PreviewBut"
        Me.PreviewBut.Size = New System.Drawing.Size(148, 32)
        Me.PreviewBut.TabIndex = 32
        Me.PreviewBut.Text = "Preview"
        Me.PreviewBut.UseVisualStyleBackColor = False
        '
        'HelpBut
        '
        Me.HelpBut.BackColor = System.Drawing.Color.LightSkyBlue
        Me.HelpBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpBut.Location = New System.Drawing.Point(41, 59)
        Me.HelpBut.Name = "HelpBut"
        Me.HelpBut.Size = New System.Drawing.Size(99, 39)
        Me.HelpBut.TabIndex = 33
        Me.HelpBut.Text = "Help"
        Me.HelpBut.UseVisualStyleBackColor = False
        '
        'BeepBox
        '
        Me.BeepBox.AutoSize = True
        Me.BeepBox.Checked = True
        Me.BeepBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BeepBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BeepBox.Location = New System.Drawing.Point(284, 350)
        Me.BeepBox.Name = "BeepBox"
        Me.BeepBox.Size = New System.Drawing.Size(112, 24)
        Me.BeepBox.TabIndex = 34
        Me.BeepBox.Text = "Add Beep"
        Me.BeepBox.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Preview1opt)
        Me.GroupBox3.Controls.Add(Me.Preview4opt)
        Me.GroupBox3.Controls.Add(Me.Preview3opt)
        Me.GroupBox3.Controls.Add(Me.Preview2opt)
        Me.GroupBox3.Location = New System.Drawing.Point(344, 640)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 41)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        '
        'Preview1opt
        '
        Me.Preview1opt.AutoSize = True
        Me.Preview1opt.Checked = True
        Me.Preview1opt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview1opt.Location = New System.Drawing.Point(11, 15)
        Me.Preview1opt.Name = "Preview1opt"
        Me.Preview1opt.Size = New System.Drawing.Size(40, 24)
        Me.Preview1opt.TabIndex = 4
        Me.Preview1opt.TabStop = True
        Me.Preview1opt.Text = "1"
        Me.Preview1opt.UseVisualStyleBackColor = True
        '
        'Preview4opt
        '
        Me.Preview4opt.AutoSize = True
        Me.Preview4opt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview4opt.Location = New System.Drawing.Point(160, 15)
        Me.Preview4opt.Name = "Preview4opt"
        Me.Preview4opt.Size = New System.Drawing.Size(40, 24)
        Me.Preview4opt.TabIndex = 3
        Me.Preview4opt.Text = "4"
        Me.Preview4opt.UseVisualStyleBackColor = True
        '
        'Preview3opt
        '
        Me.Preview3opt.AutoSize = True
        Me.Preview3opt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview3opt.Location = New System.Drawing.Point(110, 15)
        Me.Preview3opt.Name = "Preview3opt"
        Me.Preview3opt.Size = New System.Drawing.Size(40, 24)
        Me.Preview3opt.TabIndex = 2
        Me.Preview3opt.Text = "3"
        Me.Preview3opt.UseVisualStyleBackColor = True
        '
        'Preview2opt
        '
        Me.Preview2opt.AutoSize = True
        Me.Preview2opt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview2opt.Location = New System.Drawing.Point(63, 15)
        Me.Preview2opt.Name = "Preview2opt"
        Me.Preview2opt.Size = New System.Drawing.Size(40, 24)
        Me.Preview2opt.TabIndex = 1
        Me.Preview2opt.Text = "2"
        Me.Preview2opt.UseVisualStyleBackColor = True
        '
        'AddRetractChk
        '
        Me.AddRetractChk.AutoSize = True
        Me.AddRetractChk.Checked = True
        Me.AddRetractChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AddRetractChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddRetractChk.Location = New System.Drawing.Point(168, 227)
        Me.AddRetractChk.Name = "AddRetractChk"
        Me.AddRetractChk.Size = New System.Drawing.Size(247, 24)
        Me.AddRetractChk.TabIndex = 37
        Me.AddRetractChk.Text = "Add'l retract before lifting"
        Me.AddRetractChk.UseVisualStyleBackColor = True
        '
        'AddRetractAmountBox
        '
        Me.AddRetractAmountBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddRetractAmountBox.Location = New System.Drawing.Point(433, 225)
        Me.AddRetractAmountBox.Name = "AddRetractAmountBox"
        Me.AddRetractAmountBox.Size = New System.Drawing.Size(52, 27)
        Me.AddRetractAmountBox.TabIndex = 36
        Me.AddRetractAmountBox.Text = "6"
        Me.AddRetractAmountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RetractLabel
        '
        Me.RetractLabel.AutoSize = True
        Me.RetractLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RetractLabel.Location = New System.Drawing.Point(500, 228)
        Me.RetractLabel.Name = "RetractLabel"
        Me.RetractLabel.Size = New System.Drawing.Size(140, 20)
        Me.RetractLabel.TabIndex = 38
        Me.RetractLabel.Text = "Retract Amount"
        '
        'E1PrLab
        '
        Me.E1PrLab.AutoSize = True
        Me.E1PrLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E1PrLab.Location = New System.Drawing.Point(735, 59)
        Me.E1PrLab.Name = "E1PrLab"
        Me.E1PrLab.Size = New System.Drawing.Size(96, 20)
        Me.E1PrLab.TabIndex = 40
        Me.E1PrLab.Text = "Extruder 1"
        '
        'E1PrintTemp
        '
        Me.E1PrintTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E1PrintTemp.Location = New System.Drawing.Point(665, 56)
        Me.E1PrintTemp.Name = "E1PrintTemp"
        Me.E1PrintTemp.Size = New System.Drawing.Size(52, 27)
        Me.E1PrintTemp.TabIndex = 39
        Me.E1PrintTemp.Text = "205"
        Me.E1PrintTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'E2PrLab
        '
        Me.E2PrLab.AutoSize = True
        Me.E2PrLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E2PrLab.Location = New System.Drawing.Point(735, 99)
        Me.E2PrLab.Name = "E2PrLab"
        Me.E2PrLab.Size = New System.Drawing.Size(96, 20)
        Me.E2PrLab.TabIndex = 42
        Me.E2PrLab.Text = "Extruder 2"
        '
        'E2PrintTemp
        '
        Me.E2PrintTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E2PrintTemp.Location = New System.Drawing.Point(665, 96)
        Me.E2PrintTemp.Name = "E2PrintTemp"
        Me.E2PrintTemp.Size = New System.Drawing.Size(52, 27)
        Me.E2PrintTemp.TabIndex = 41
        Me.E2PrintTemp.Text = "205"
        Me.E2PrintTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'E3PrLab
        '
        Me.E3PrLab.AutoSize = True
        Me.E3PrLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E3PrLab.Location = New System.Drawing.Point(735, 140)
        Me.E3PrLab.Name = "E3PrLab"
        Me.E3PrLab.Size = New System.Drawing.Size(96, 20)
        Me.E3PrLab.TabIndex = 44
        Me.E3PrLab.Text = "Extruder 3"
        '
        'E3PrintTemp
        '
        Me.E3PrintTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E3PrintTemp.Location = New System.Drawing.Point(665, 137)
        Me.E3PrintTemp.Name = "E3PrintTemp"
        Me.E3PrintTemp.Size = New System.Drawing.Size(52, 27)
        Me.E3PrintTemp.TabIndex = 43
        Me.E3PrintTemp.Text = "205"
        Me.E3PrintTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'E4PrLab
        '
        Me.E4PrLab.AutoSize = True
        Me.E4PrLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E4PrLab.Location = New System.Drawing.Point(735, 178)
        Me.E4PrLab.Name = "E4PrLab"
        Me.E4PrLab.Size = New System.Drawing.Size(96, 20)
        Me.E4PrLab.TabIndex = 46
        Me.E4PrLab.Text = "Extruder 4"
        '
        'E4PrintTemp
        '
        Me.E4PrintTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E4PrintTemp.Location = New System.Drawing.Point(665, 175)
        Me.E4PrintTemp.Name = "E4PrintTemp"
        Me.E4PrintTemp.Size = New System.Drawing.Size(52, 27)
        Me.E4PrintTemp.TabIndex = 45
        Me.E4PrintTemp.Text = "205"
        Me.E4PrintTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(653, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(188, 20)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Extruder Print Temps"
        '
        'EmulateMultiExtruder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 711)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.E4PrLab)
        Me.Controls.Add(Me.E4PrintTemp)
        Me.Controls.Add(Me.E3PrLab)
        Me.Controls.Add(Me.E3PrintTemp)
        Me.Controls.Add(Me.E2PrLab)
        Me.Controls.Add(Me.E2PrintTemp)
        Me.Controls.Add(Me.E1PrLab)
        Me.Controls.Add(Me.E1PrintTemp)
        Me.Controls.Add(Me.RetractLabel)
        Me.Controls.Add(Me.AddRetractChk)
        Me.Controls.Add(Me.AddRetractAmountBox)
        Me.Controls.Add(Me.PreviewBut)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BeepBox)
        Me.Controls.Add(Me.HelpBut)
        Me.Controls.Add(Me.GcodeAfterBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CancelEBut)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.T3MessageBox)
        Me.Controls.Add(Me.T3MessageLabel)
        Me.Controls.Add(Me.T2MessageBox)
        Me.Controls.Add(Me.T2MessageLabel)
        Me.Controls.Add(Me.T1MessageBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T0MessageBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.AddM117MsgChk)
        Me.Controls.Add(Me.ParkHeadYbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ParkHeadXbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PauseCmdBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TimeOutBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CreateButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ParkHeadChk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EmulateMultiExtruder"
        Me.Text = "Single Extruder as a Multi Extruder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ParkHeadChk As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CreateButton As Button
    Friend WithEvents TimeOutBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PauseCmdBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ParkHeadXbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ParkHeadYbox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents T0MessageBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents AddM117MsgChk As CheckBox
    Friend WithEvents T1MessageBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents T3MessageBox As TextBox
    Friend WithEvents T3MessageLabel As Label
    Friend WithEvents T2MessageBox As TextBox
    Friend WithEvents T2MessageLabel As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents T3But As RadioButton
    Friend WithEvents T2But As RadioButton
    Friend WithEvents T1But As RadioButton
    Friend WithEvents CancelEBut As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents M83OptBut As RadioButton
    Friend WithEvents M82OptBut As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GcodeAfterBox As TextBox
    Friend WithEvents PreviewBut As Button
    Friend WithEvents HelpBut As Button
    Friend WithEvents BeepBox As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Preview1opt As RadioButton
    Friend WithEvents Preview4opt As RadioButton
    Friend WithEvents Preview3opt As RadioButton
    Friend WithEvents Preview2opt As RadioButton
    Friend WithEvents AddRetractChk As CheckBox
    Friend WithEvents AddRetractAmountBox As TextBox
    Friend WithEvents RetractLabel As Label
    Friend WithEvents E1PrLab As Label
    Friend WithEvents E1PrintTemp As TextBox
    Friend WithEvents E2PrLab As Label
    Friend WithEvents E2PrintTemp As TextBox
    Friend WithEvents E3PrLab As Label
    Friend WithEvents E3PrintTemp As TextBox
    Friend WithEvents E4PrLab As Label
    Friend WithEvents E4PrintTemp As TextBox
    Friend WithEvents Label15 As Label
End Class
