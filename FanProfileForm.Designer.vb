<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FanProfileForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FanProfileForm))
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.AddBut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateBut = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TLP1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ClearBut = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FinalLabel2 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.SpeedInterF = New System.Windows.Forms.TextBox()
        Me.FinalLabel = New System.Windows.Forms.Label()
        Me.FinalSpeedBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SpeedBridge = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TypeEndLayerBox = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TypeStartLayerBox = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CancelTypeBut = New System.Windows.Forms.Button()
        Me.SpeedFill = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SpeedSkin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SpeedSupport = New System.Windows.Forms.TextBox()
        Me.CreateTypeBut = New System.Windows.Forms.Button()
        Me.SpeedPrime = New System.Windows.Forms.TextBox()
        Me.SpeedSkirt = New System.Windows.Forms.TextBox()
        Me.SpeedWallOuter = New System.Windows.Forms.TextBox()
        Me.SpeedWallInner = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ByFeatureChk = New System.Windows.Forms.RadioButton()
        Me.ByLayerChk = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.SpecialOpt = New System.Windows.Forms.RadioButton()
        Me.PWMopt = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Khaki
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(11, 297)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(106, 40)
        Me.CancelBut.TabIndex = 0
        Me.CancelBut.Text = "Cancel"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'AddBut
        '
        Me.AddBut.BackColor = System.Drawing.Color.LightGreen
        Me.AddBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddBut.Location = New System.Drawing.Point(42, 172)
        Me.AddBut.Name = "AddBut"
        Me.AddBut.Size = New System.Drawing.Size(191, 42)
        Me.AddBut.TabIndex = 1
        Me.AddBut.Text = "Add Fan Line"
        Me.AddBut.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Layer #"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(133, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fan Speed %"
        '
        'CreateBut
        '
        Me.CreateBut.BackColor = System.Drawing.Color.Thistle
        Me.CreateBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateBut.Location = New System.Drawing.Point(162, 297)
        Me.CreateBut.Name = "CreateBut"
        Me.CreateBut.Size = New System.Drawing.Size(149, 40)
        Me.CreateBut.TabIndex = 6
        Me.CreateBut.Text = "Create"
        Me.CreateBut.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(517, 140)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(58, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(378, 43)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "NOTE:  Your last change continues through to the end of the file."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(333, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Fan Profile"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(386, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 18)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Speed%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(312, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 18)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Layer"
        '
        'TLP1
        '
        Me.TLP1.AutoScroll = True
        Me.TLP1.BackColor = System.Drawing.SystemColors.Window
        Me.TLP1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TLP1.ColumnCount = 2
        Me.TLP1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TLP1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TLP1.Location = New System.Drawing.Point(309, 72)
        Me.TLP1.Name = "TLP1"
        Me.TLP1.RowCount = 1
        Me.TLP1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP1.Size = New System.Drawing.Size(164, 204)
        Me.TLP1.TabIndex = 16
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(153, 130)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(71, 27)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.Text = "0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(42, 130)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(71, 27)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ClearBut
        '
        Me.ClearBut.BackColor = System.Drawing.Color.Khaki
        Me.ClearBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearBut.Location = New System.Drawing.Point(364, 297)
        Me.ClearBut.Name = "ClearBut"
        Me.ClearBut.Size = New System.Drawing.Size(106, 40)
        Me.ClearBut.TabIndex = 22
        Me.ClearBut.Text = "Clear"
        Me.ClearBut.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TLP1)
        Me.GroupBox1.Controls.Add(Me.ClearBut)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.CancelBut)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.AddBut)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CreateBut)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 340)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 355)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "By Layer"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 20)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "GCODE Layers start at ""0"""
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(136, 211)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(202, 20)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "Gcode Top Layer# is:  "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.FinalLabel2)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.SpeedInterF)
        Me.GroupBox2.Controls.Add(Me.FinalLabel)
        Me.GroupBox2.Controls.Add(Me.FinalSpeedBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.SpeedBridge)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.TypeEndLayerBox)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.TypeStartLayerBox)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.CancelTypeBut)
        Me.GroupBox2.Controls.Add(Me.SpeedFill)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.SpeedSkin)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.SpeedSupport)
        Me.GroupBox2.Controls.Add(Me.CreateTypeBut)
        Me.GroupBox2.Controls.Add(Me.SpeedPrime)
        Me.GroupBox2.Controls.Add(Me.SpeedSkirt)
        Me.GroupBox2.Controls.Add(Me.SpeedWallOuter)
        Me.GroupBox2.Controls.Add(Me.SpeedWallInner)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 340)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(531, 425)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "By Feature Type"
        Me.GroupBox2.Visible = False
        '
        'FinalLabel2
        '
        Me.FinalLabel2.AutoSize = True
        Me.FinalLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalLabel2.Location = New System.Drawing.Point(11, 251)
        Me.FinalLabel2.Name = "FinalLabel2"
        Me.FinalLabel2.Size = New System.Drawing.Size(152, 20)
        Me.FinalLabel2.TabIndex = 49
        Me.FinalLabel2.Text = "(If not whole file)"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(188, 253)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(207, 23)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "SUPT-INTERFACE"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SpeedInterF
        '
        Me.SpeedInterF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedInterF.Location = New System.Drawing.Point(408, 251)
        Me.SpeedInterF.Name = "SpeedInterF"
        Me.SpeedInterF.Size = New System.Drawing.Size(71, 27)
        Me.SpeedInterF.TabIndex = 47
        Me.SpeedInterF.Text = "50"
        Me.SpeedInterF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FinalLabel
        '
        Me.FinalLabel.AutoSize = True
        Me.FinalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalLabel.Location = New System.Drawing.Point(5, 224)
        Me.FinalLabel.Name = "FinalLabel"
        Me.FinalLabel.Size = New System.Drawing.Size(167, 20)
        Me.FinalLabel.TabIndex = 46
        Me.FinalLabel.Text = "Final Fan Speed %"
        '
        'FinalSpeedBox
        '
        Me.FinalSpeedBox.Enabled = False
        Me.FinalSpeedBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalSpeedBox.Location = New System.Drawing.Point(56, 279)
        Me.FinalSpeedBox.Name = "FinalSpeedBox"
        Me.FinalSpeedBox.Size = New System.Drawing.Size(71, 27)
        Me.FinalSpeedBox.TabIndex = 45
        Me.FinalSpeedBox.Text = "50"
        Me.FinalSpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 20)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "(-1 = whole file)"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(220, 323)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 20)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "BRIDGE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SpeedBridge
        '
        Me.SpeedBridge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedBridge.Location = New System.Drawing.Point(408, 320)
        Me.SpeedBridge.Name = "SpeedBridge"
        Me.SpeedBridge.Size = New System.Drawing.Size(71, 27)
        Me.SpeedBridge.TabIndex = 42
        Me.SpeedBridge.Text = "50"
        Me.SpeedBridge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(220, 289)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(175, 20)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "PRIME TOWER"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(44, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 20)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "End Layer"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(220, 219)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(175, 20)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "SUPPORT"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TypeEndLayerBox
        '
        Me.TypeEndLayerBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeEndLayerBox.Location = New System.Drawing.Point(56, 139)
        Me.TypeEndLayerBox.Name = "TypeEndLayerBox"
        Me.TypeEndLayerBox.Size = New System.Drawing.Size(71, 27)
        Me.TypeEndLayerBox.TabIndex = 27
        Me.TypeEndLayerBox.Text = "-1"
        Me.TypeEndLayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(220, 186)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(175, 20)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "SKIN"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(36, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 20)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Start at Layer:"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(220, 153)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(175, 20)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "FILL"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TypeStartLayerBox
        '
        Me.TypeStartLayerBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeStartLayerBox.Location = New System.Drawing.Point(56, 66)
        Me.TypeStartLayerBox.Name = "TypeStartLayerBox"
        Me.TypeStartLayerBox.Size = New System.Drawing.Size(71, 27)
        Me.TypeStartLayerBox.TabIndex = 25
        Me.TypeStartLayerBox.Text = "0"
        Me.TypeStartLayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(220, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(175, 20)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "WALL-OUTER"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(243, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 20)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "SKIRT"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CancelTypeBut
        '
        Me.CancelTypeBut.BackColor = System.Drawing.Color.Khaki
        Me.CancelTypeBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelTypeBut.Location = New System.Drawing.Point(21, 359)
        Me.CancelTypeBut.Name = "CancelTypeBut"
        Me.CancelTypeBut.Size = New System.Drawing.Size(106, 40)
        Me.CancelTypeBut.TabIndex = 0
        Me.CancelTypeBut.Text = "Cancel"
        Me.CancelTypeBut.UseVisualStyleBackColor = False
        '
        'SpeedFill
        '
        Me.SpeedFill.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedFill.Location = New System.Drawing.Point(408, 150)
        Me.SpeedFill.Name = "SpeedFill"
        Me.SpeedFill.Size = New System.Drawing.Size(71, 27)
        Me.SpeedFill.TabIndex = 34
        Me.SpeedFill.Text = "50"
        Me.SpeedFill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(282, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Feature"
        '
        'SpeedSkin
        '
        Me.SpeedSkin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedSkin.Location = New System.Drawing.Point(408, 183)
        Me.SpeedSkin.Name = "SpeedSkin"
        Me.SpeedSkin.Size = New System.Drawing.Size(71, 27)
        Me.SpeedSkin.TabIndex = 33
        Me.SpeedSkin.Text = "50"
        Me.SpeedSkin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(408, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Fan %"
        '
        'SpeedSupport
        '
        Me.SpeedSupport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedSupport.Location = New System.Drawing.Point(408, 216)
        Me.SpeedSupport.Name = "SpeedSupport"
        Me.SpeedSupport.Size = New System.Drawing.Size(71, 27)
        Me.SpeedSupport.TabIndex = 32
        Me.SpeedSupport.Text = "50"
        Me.SpeedSupport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CreateTypeBut
        '
        Me.CreateTypeBut.BackColor = System.Drawing.Color.Thistle
        Me.CreateTypeBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateTypeBut.Location = New System.Drawing.Point(162, 359)
        Me.CreateTypeBut.Name = "CreateTypeBut"
        Me.CreateTypeBut.Size = New System.Drawing.Size(149, 40)
        Me.CreateTypeBut.TabIndex = 6
        Me.CreateTypeBut.Text = "Create"
        Me.CreateTypeBut.UseVisualStyleBackColor = False
        '
        'SpeedPrime
        '
        Me.SpeedPrime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedPrime.Location = New System.Drawing.Point(408, 286)
        Me.SpeedPrime.Name = "SpeedPrime"
        Me.SpeedPrime.Size = New System.Drawing.Size(71, 27)
        Me.SpeedPrime.TabIndex = 31
        Me.SpeedPrime.Text = "50"
        Me.SpeedPrime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SpeedSkirt
        '
        Me.SpeedSkirt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedSkirt.Location = New System.Drawing.Point(408, 51)
        Me.SpeedSkirt.Name = "SpeedSkirt"
        Me.SpeedSkirt.Size = New System.Drawing.Size(71, 27)
        Me.SpeedSkirt.TabIndex = 28
        Me.SpeedSkirt.Text = "50"
        Me.SpeedSkirt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SpeedWallOuter
        '
        Me.SpeedWallOuter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedWallOuter.Location = New System.Drawing.Point(408, 117)
        Me.SpeedWallOuter.Name = "SpeedWallOuter"
        Me.SpeedWallOuter.Size = New System.Drawing.Size(71, 27)
        Me.SpeedWallOuter.TabIndex = 30
        Me.SpeedWallOuter.Text = "50"
        Me.SpeedWallOuter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SpeedWallInner
        '
        Me.SpeedWallInner.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedWallInner.Location = New System.Drawing.Point(408, 84)
        Me.SpeedWallInner.Name = "SpeedWallInner"
        Me.SpeedWallInner.Size = New System.Drawing.Size(71, 27)
        Me.SpeedWallInner.TabIndex = 29
        Me.SpeedWallInner.Text = "50"
        Me.SpeedWallInner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(220, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 20)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "WALL-INNER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ByFeatureChk
        '
        Me.ByFeatureChk.AutoSize = True
        Me.ByFeatureChk.Location = New System.Drawing.Point(16, 54)
        Me.ByFeatureChk.Name = "ByFeatureChk"
        Me.ByFeatureChk.Size = New System.Drawing.Size(151, 22)
        Me.ByFeatureChk.TabIndex = 25
        Me.ByFeatureChk.Text = "By Feature Type"
        Me.ByFeatureChk.UseVisualStyleBackColor = True
        '
        'ByLayerChk
        '
        Me.ByLayerChk.AutoSize = True
        Me.ByLayerChk.Checked = True
        Me.ByLayerChk.Location = New System.Drawing.Point(16, 26)
        Me.ByLayerChk.Name = "ByLayerChk"
        Me.ByLayerChk.Size = New System.Drawing.Size(158, 22)
        Me.ByLayerChk.TabIndex = 26
        Me.ByLayerChk.TabStop = True
        Me.ByLayerChk.Text = "By Layer Number"
        Me.ByLayerChk.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ByFeatureChk)
        Me.GroupBox3.Controls.Add(Me.ByLayerChk)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(45, 244)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(212, 85)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Options"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.SpecialOpt)
        Me.GroupBox4.Controls.Add(Me.PWMopt)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(276, 244)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(232, 85)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "M106 Command Mode"
        '
        'SpecialOpt
        '
        Me.SpecialOpt.AutoSize = True
        Me.SpecialOpt.Location = New System.Drawing.Point(16, 54)
        Me.SpecialOpt.Name = "SpecialOpt"
        Me.SpecialOpt.Size = New System.Drawing.Size(144, 22)
        Me.SpecialOpt.TabIndex = 25
        Me.SpecialOpt.Text = "0 to 1 (Special)"
        Me.SpecialOpt.UseVisualStyleBackColor = True
        '
        'PWMopt
        '
        Me.PWMopt.AutoSize = True
        Me.PWMopt.Checked = True
        Me.PWMopt.Location = New System.Drawing.Point(16, 26)
        Me.PWMopt.Name = "PWMopt"
        Me.PWMopt.Size = New System.Drawing.Size(162, 22)
        Me.PWMopt.TabIndex = 26
        Me.PWMopt.TabStop = True
        Me.PWMopt.Text = "0 to 255 (Normal)"
        Me.PWMopt.UseVisualStyleBackColor = True
        '
        'FanProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 777)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FanProfileForm"
        Me.Text = "Cooling Profile"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CancelBut As Button
    Friend WithEvents AddBut As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CreateBut As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TLP1 As TableLayoutPanel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ClearBut As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TypeEndLayerBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TypeStartLayerBox As TextBox
    Friend WithEvents CancelTypeBut As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents CreateTypeBut As Button
    Friend WithEvents ByFeatureChk As RadioButton
    Friend WithEvents ByLayerChk As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents SpeedFill As TextBox
    Friend WithEvents SpeedSkin As TextBox
    Friend WithEvents SpeedSupport As TextBox
    Friend WithEvents SpeedPrime As TextBox
    Friend WithEvents SpeedSkirt As TextBox
    Friend WithEvents SpeedWallOuter As TextBox
    Friend WithEvents SpeedWallInner As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SpeedBridge As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents FinalLabel As Label
    Friend WithEvents FinalSpeedBox As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents SpeedInterF As TextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents FinalLabel2 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents SpecialOpt As RadioButton
    Friend WithEvents PWMopt As RadioButton
End Class
