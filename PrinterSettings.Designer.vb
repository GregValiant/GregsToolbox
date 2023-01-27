<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrinterSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrinterSettings))
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.CopyStepsBut = New System.Windows.Forms.Button()
        Me.CalcNewStepsBox = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.CalcEopt = New System.Windows.Forms.RadioButton()
        Me.CalcCaliButt = New System.Windows.Forms.Button()
        Me.CalcZopt = New System.Windows.Forms.RadioButton()
        Me.CalcYopt = New System.Windows.Forms.RadioButton()
        Me.CalcXopt = New System.Windows.Forms.RadioButton()
        Me.CalcTargetBox = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.CalcStepsBox = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.CalcMeasureBox = New System.Windows.Forms.TextBox()
        Me.CBSaveSteps = New System.Windows.Forms.Button()
        Me.CBGetSettings = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.StepsE = New System.Windows.Forms.TextBox()
        Me.CBSetsteps = New System.Windows.Forms.Button()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.StepsZ = New System.Windows.Forms.TextBox()
        Me.StepsY = New System.Windows.Forms.TextBox()
        Me.StepsX = New System.Windows.Forms.TextBox()
        Me.CBGetSteps = New System.Windows.Forms.Button()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.AutoTuneReps = New System.Windows.Forms.TextBox()
        Me.AutoTuneTemp = New System.Windows.Forms.TextBox()
        Me.CBAutoTune = New System.Windows.Forms.Button()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.CBSetPID = New System.Windows.Forms.Button()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.PIDD = New System.Windows.Forms.TextBox()
        Me.PIDI = New System.Windows.Forms.TextBox()
        Me.PIDP = New System.Windows.Forms.TextBox()
        Me.CBFindPID = New System.Windows.Forms.Button()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.M145Butt = New System.Windows.Forms.Button()
        Me.OptionHotBox = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.OptionFanBox = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.OptionBedBox = New System.Windows.Forms.TextBox()
        Me.OptionABS = New System.Windows.Forms.RadioButton()
        Me.OptionPLA = New System.Windows.Forms.RadioButton()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.OffsetSendButton = New System.Windows.Forms.Button()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.OffsetZbox = New System.Windows.Forms.TextBox()
        Me.OffsetYbox = New System.Windows.Forms.TextBox()
        Me.OffsetXbox = New System.Windows.Forms.TextBox()
        Me.CBFindOffset = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TAccelLab = New System.Windows.Forms.Label()
        Me.TAccelBox = New System.Windows.Forms.TextBox()
        Me.PAccelLab = New System.Windows.Forms.Label()
        Me.PAccelBox = New System.Windows.Forms.TextBox()
        Me.JuncLab = New System.Windows.Forms.Label()
        Me.JuncDevBox = New System.Windows.Forms.TextBox()
        Me.YJerkLab = New System.Windows.Forms.Label()
        Me.YJerkBox = New System.Windows.Forms.TextBox()
        Me.CBSetAccelJerk = New System.Windows.Forms.Button()
        Me.XJerkLab = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.XJerkBox = New System.Windows.Forms.TextBox()
        Me.YAccelBox = New System.Windows.Forms.TextBox()
        Me.XAccelBox = New System.Windows.Forms.TextBox()
        Me.CBLoadAccelJerk = New System.Windows.Forms.Button()
        Me.FactResetBut = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ExtrCalibrateEBut = New System.Windows.Forms.Button()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox17.Controls.Add(Me.CopyStepsBut)
        Me.GroupBox17.Controls.Add(Me.CalcNewStepsBox)
        Me.GroupBox17.Controls.Add(Me.Label58)
        Me.GroupBox17.Controls.Add(Me.CalcEopt)
        Me.GroupBox17.Controls.Add(Me.CalcCaliButt)
        Me.GroupBox17.Controls.Add(Me.CalcZopt)
        Me.GroupBox17.Controls.Add(Me.CalcYopt)
        Me.GroupBox17.Controls.Add(Me.CalcXopt)
        Me.GroupBox17.Controls.Add(Me.CalcTargetBox)
        Me.GroupBox17.Controls.Add(Me.Label57)
        Me.GroupBox17.Controls.Add(Me.Label56)
        Me.GroupBox17.Controls.Add(Me.CalcStepsBox)
        Me.GroupBox17.Controls.Add(Me.Label55)
        Me.GroupBox17.Controls.Add(Me.CalcMeasureBox)
        Me.GroupBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.Location = New System.Drawing.Point(188, 82)
        Me.GroupBox17.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox17.Size = New System.Drawing.Size(188, 370)
        Me.GroupBox17.TabIndex = 4
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Calibration Calc."
        '
        'CopyStepsBut
        '
        Me.CopyStepsBut.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CopyStepsBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyStepsBut.Location = New System.Drawing.Point(13, 315)
        Me.CopyStepsBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CopyStepsBut.Name = "CopyStepsBut"
        Me.CopyStepsBut.Size = New System.Drawing.Size(167, 36)
        Me.CopyStepsBut.TabIndex = 14
        Me.CopyStepsBut.Text = "Copy to Steps/mm"
        Me.CopyStepsBut.UseVisualStyleBackColor = False
        '
        'CalcNewStepsBox
        '
        Me.CalcNewStepsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcNewStepsBox.Location = New System.Drawing.Point(43, 279)
        Me.CalcNewStepsBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcNewStepsBox.Name = "CalcNewStepsBox"
        Me.CalcNewStepsBox.Size = New System.Drawing.Size(98, 24)
        Me.CalcNewStepsBox.TabIndex = 5
        Me.CalcNewStepsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label58
        '
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(28, 256)
        Me.Label58.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(131, 19)
        Me.Label58.TabIndex = 9
        Me.Label58.Text = "New Steps"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalcEopt
        '
        Me.CalcEopt.AutoSize = True
        Me.CalcEopt.Location = New System.Drawing.Point(143, 24)
        Me.CalcEopt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcEopt.Name = "CalcEopt"
        Me.CalcEopt.Size = New System.Drawing.Size(39, 22)
        Me.CalcEopt.TabIndex = 13
        Me.CalcEopt.TabStop = True
        Me.CalcEopt.Text = "E"
        Me.CalcEopt.UseVisualStyleBackColor = True
        '
        'CalcCaliButt
        '
        Me.CalcCaliButt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CalcCaliButt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcCaliButt.Location = New System.Drawing.Point(43, 213)
        Me.CalcCaliButt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcCaliButt.Name = "CalcCaliButt"
        Me.CalcCaliButt.Size = New System.Drawing.Size(99, 38)
        Me.CalcCaliButt.TabIndex = 1
        Me.CalcCaliButt.Text = "Calc"
        Me.CalcCaliButt.UseVisualStyleBackColor = False
        '
        'CalcZopt
        '
        Me.CalcZopt.AutoSize = True
        Me.CalcZopt.Location = New System.Drawing.Point(99, 24)
        Me.CalcZopt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcZopt.Name = "CalcZopt"
        Me.CalcZopt.Size = New System.Drawing.Size(38, 22)
        Me.CalcZopt.TabIndex = 12
        Me.CalcZopt.TabStop = True
        Me.CalcZopt.Text = "Z"
        Me.CalcZopt.UseVisualStyleBackColor = True
        '
        'CalcYopt
        '
        Me.CalcYopt.AutoSize = True
        Me.CalcYopt.Location = New System.Drawing.Point(56, 24)
        Me.CalcYopt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcYopt.Name = "CalcYopt"
        Me.CalcYopt.Size = New System.Drawing.Size(38, 22)
        Me.CalcYopt.TabIndex = 11
        Me.CalcYopt.TabStop = True
        Me.CalcYopt.Text = "Y"
        Me.CalcYopt.UseVisualStyleBackColor = True
        '
        'CalcXopt
        '
        Me.CalcXopt.AutoSize = True
        Me.CalcXopt.Location = New System.Drawing.Point(13, 24)
        Me.CalcXopt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcXopt.Name = "CalcXopt"
        Me.CalcXopt.Size = New System.Drawing.Size(39, 22)
        Me.CalcXopt.TabIndex = 10
        Me.CalcXopt.TabStop = True
        Me.CalcXopt.Text = "X"
        Me.CalcXopt.UseVisualStyleBackColor = True
        '
        'CalcTargetBox
        '
        Me.CalcTargetBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcTargetBox.Location = New System.Drawing.Point(52, 78)
        Me.CalcTargetBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcTargetBox.Name = "CalcTargetBox"
        Me.CalcTargetBox.Size = New System.Drawing.Size(80, 24)
        Me.CalcTargetBox.TabIndex = 3
        Me.CalcTargetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(28, 108)
        Me.Label57.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(131, 19)
        Me.Label57.TabIndex = 8
        Me.Label57.Text = "Measured"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(28, 55)
        Me.Label56.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(131, 19)
        Me.Label56.TabIndex = 7
        Me.Label56.Text = "Target"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalcStepsBox
        '
        Me.CalcStepsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcStepsBox.Location = New System.Drawing.Point(52, 184)
        Me.CalcStepsBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcStepsBox.Name = "CalcStepsBox"
        Me.CalcStepsBox.Size = New System.Drawing.Size(80, 24)
        Me.CalcStepsBox.TabIndex = 2
        Me.CalcStepsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(28, 162)
        Me.Label55.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(131, 19)
        Me.Label55.TabIndex = 6
        Me.Label55.Text = "Current Steps"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalcMeasureBox
        '
        Me.CalcMeasureBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcMeasureBox.Location = New System.Drawing.Point(52, 131)
        Me.CalcMeasureBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CalcMeasureBox.Name = "CalcMeasureBox"
        Me.CalcMeasureBox.Size = New System.Drawing.Size(80, 24)
        Me.CalcMeasureBox.TabIndex = 4
        Me.CalcMeasureBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBSaveSteps
        '
        Me.CBSaveSteps.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CBSaveSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSaveSteps.Location = New System.Drawing.Point(296, 548)
        Me.CBSaveSteps.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBSaveSteps.Name = "CBSaveSteps"
        Me.CBSaveSteps.Size = New System.Drawing.Size(403, 55)
        Me.CBSaveSteps.TabIndex = 10
        Me.CBSaveSteps.Text = "Save Settings to the Printer (M500)"
        Me.CBSaveSteps.UseVisualStyleBackColor = False
        '
        'CBGetSettings
        '
        Me.CBGetSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CBGetSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGetSettings.Location = New System.Drawing.Point(296, 14)
        Me.CBGetSettings.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBGetSettings.Name = "CBGetSettings"
        Me.CBGetSettings.Size = New System.Drawing.Size(403, 55)
        Me.CBGetSettings.TabIndex = 9
        Me.CBGetSettings.Text = "Get Settings from Printer (M503)"
        Me.CBGetSettings.UseVisualStyleBackColor = False
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox14.Controls.Add(Me.Label74)
        Me.GroupBox14.Controls.Add(Me.StepsE)
        Me.GroupBox14.Controls.Add(Me.CBSetsteps)
        Me.GroupBox14.Controls.Add(Me.Label71)
        Me.GroupBox14.Controls.Add(Me.Label72)
        Me.GroupBox14.Controls.Add(Me.Label73)
        Me.GroupBox14.Controls.Add(Me.StepsZ)
        Me.GroupBox14.Controls.Add(Me.StepsY)
        Me.GroupBox14.Controls.Add(Me.StepsX)
        Me.GroupBox14.Controls.Add(Me.CBGetSteps)
        Me.GroupBox14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.Location = New System.Drawing.Point(13, 82)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox14.Size = New System.Drawing.Size(159, 370)
        Me.GroupBox14.TabIndex = 1
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Steps/mm"
        '
        'Label74
        '
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(32, 250)
        Me.Label74.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(95, 19)
        Me.Label74.TabIndex = 25
        Me.Label74.Text = """E"""
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StepsE
        '
        Me.StepsE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StepsE.Location = New System.Drawing.Point(32, 274)
        Me.StepsE.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.StepsE.Name = "StepsE"
        Me.StepsE.Size = New System.Drawing.Size(94, 24)
        Me.StepsE.TabIndex = 24
        Me.StepsE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBSetsteps
        '
        Me.CBSetsteps.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CBSetsteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSetsteps.Location = New System.Drawing.Point(16, 315)
        Me.CBSetsteps.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBSetsteps.Name = "CBSetsteps"
        Me.CBSetsteps.Size = New System.Drawing.Size(125, 36)
        Me.CBSetsteps.TabIndex = 23
        Me.CBSetsteps.Text = "Send Steps"
        Me.CBSetsteps.UseVisualStyleBackColor = False
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(32, 192)
        Me.Label71.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(95, 19)
        Me.Label71.TabIndex = 22
        Me.Label71.Text = """Z"""
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(34, 133)
        Me.Label72.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(93, 19)
        Me.Label72.TabIndex = 21
        Me.Label72.Text = """Y"""
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(32, 77)
        Me.Label73.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(95, 19)
        Me.Label73.TabIndex = 20
        Me.Label73.Text = """X"""
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StepsZ
        '
        Me.StepsZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StepsZ.Location = New System.Drawing.Point(32, 216)
        Me.StepsZ.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.StepsZ.Name = "StepsZ"
        Me.StepsZ.Size = New System.Drawing.Size(94, 24)
        Me.StepsZ.TabIndex = 19
        Me.StepsZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StepsY
        '
        Me.StepsY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StepsY.Location = New System.Drawing.Point(32, 156)
        Me.StepsY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.StepsY.Name = "StepsY"
        Me.StepsY.Size = New System.Drawing.Size(94, 24)
        Me.StepsY.TabIndex = 18
        Me.StepsY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StepsX
        '
        Me.StepsX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StepsX.Location = New System.Drawing.Point(32, 101)
        Me.StepsX.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.StepsX.Name = "StepsX"
        Me.StepsX.Size = New System.Drawing.Size(94, 24)
        Me.StepsX.TabIndex = 17
        Me.StepsX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBGetSteps
        '
        Me.CBGetSteps.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CBGetSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGetSteps.Location = New System.Drawing.Point(16, 23)
        Me.CBGetSteps.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBGetSteps.Name = "CBGetSteps"
        Me.CBGetSteps.Size = New System.Drawing.Size(125, 51)
        Me.CBGetSteps.TabIndex = 0
        Me.CBGetSteps.Text = "Load Steps/mm"
        Me.CBGetSteps.UseVisualStyleBackColor = False
        '
        'GroupBox20
        '
        Me.GroupBox20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox20.Controls.Add(Me.Label66)
        Me.GroupBox20.Controls.Add(Me.Label67)
        Me.GroupBox20.Controls.Add(Me.AutoTuneReps)
        Me.GroupBox20.Controls.Add(Me.AutoTuneTemp)
        Me.GroupBox20.Controls.Add(Me.CBAutoTune)
        Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(536, 82)
        Me.GroupBox20.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox20.Size = New System.Drawing.Size(133, 195)
        Me.GroupBox20.TabIndex = 8
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Auto-Tune HE"
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(-17, 129)
        Me.Label66.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(162, 19)
        Me.Label66.TabIndex = 14
        Me.Label66.Text = "Repititions"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label67
        '
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(-12, 73)
        Me.Label67.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(156, 22)
        Me.Label67.TabIndex = 13
        Me.Label67.Text = "Target Temp"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'AutoTuneReps
        '
        Me.AutoTuneReps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoTuneReps.Location = New System.Drawing.Point(39, 152)
        Me.AutoTuneReps.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AutoTuneReps.Name = "AutoTuneReps"
        Me.AutoTuneReps.Size = New System.Drawing.Size(48, 24)
        Me.AutoTuneReps.TabIndex = 11
        Me.AutoTuneReps.Text = "8"
        Me.AutoTuneReps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AutoTuneTemp
        '
        Me.AutoTuneTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoTuneTemp.Location = New System.Drawing.Point(24, 99)
        Me.AutoTuneTemp.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AutoTuneTemp.Name = "AutoTuneTemp"
        Me.AutoTuneTemp.Size = New System.Drawing.Size(75, 24)
        Me.AutoTuneTemp.TabIndex = 10
        Me.AutoTuneTemp.Text = "200"
        Me.AutoTuneTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBAutoTune
        '
        Me.CBAutoTune.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBAutoTune.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBAutoTune.Location = New System.Drawing.Point(15, 33)
        Me.CBAutoTune.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBAutoTune.Name = "CBAutoTune"
        Me.CBAutoTune.Size = New System.Drawing.Size(89, 36)
        Me.CBAutoTune.TabIndex = 9
        Me.CBAutoTune.Text = "Run"
        Me.CBAutoTune.UseVisualStyleBackColor = False
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox16.Controls.Add(Me.CBSetPID)
        Me.GroupBox16.Controls.Add(Me.Label62)
        Me.GroupBox16.Controls.Add(Me.Label63)
        Me.GroupBox16.Controls.Add(Me.Label64)
        Me.GroupBox16.Controls.Add(Me.PIDD)
        Me.GroupBox16.Controls.Add(Me.PIDI)
        Me.GroupBox16.Controls.Add(Me.PIDP)
        Me.GroupBox16.Controls.Add(Me.CBFindPID)
        Me.GroupBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.Location = New System.Drawing.Point(392, 82)
        Me.GroupBox16.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox16.Size = New System.Drawing.Size(130, 282)
        Me.GroupBox16.TabIndex = 7
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Hot End PID"
        '
        'CBSetPID
        '
        Me.CBSetPID.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CBSetPID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSetPID.Location = New System.Drawing.Point(16, 232)
        Me.CBSetPID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBSetPID.Name = "CBSetPID"
        Me.CBSetPID.Size = New System.Drawing.Size(97, 36)
        Me.CBSetPID.TabIndex = 16
        Me.CBSetPID.Text = "Send PID"
        Me.CBSetPID.UseVisualStyleBackColor = False
        '
        'Label62
        '
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(20, 177)
        Me.Label62.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(88, 19)
        Me.Label62.TabIndex = 15
        Me.Label62.Text = """D"""
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label63
        '
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(20, 126)
        Me.Label63.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(88, 19)
        Me.Label63.TabIndex = 14
        Me.Label63.Text = """I"""
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label64
        '
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(20, 74)
        Me.Label64.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(88, 19)
        Me.Label64.TabIndex = 13
        Me.Label64.Text = """P"""
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PIDD
        '
        Me.PIDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIDD.Location = New System.Drawing.Point(20, 199)
        Me.PIDD.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PIDD.Name = "PIDD"
        Me.PIDD.Size = New System.Drawing.Size(87, 24)
        Me.PIDD.TabIndex = 12
        Me.PIDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PIDI
        '
        Me.PIDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIDI.Location = New System.Drawing.Point(20, 148)
        Me.PIDI.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PIDI.Name = "PIDI"
        Me.PIDI.Size = New System.Drawing.Size(88, 24)
        Me.PIDI.TabIndex = 11
        Me.PIDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PIDP
        '
        Me.PIDP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIDP.Location = New System.Drawing.Point(20, 96)
        Me.PIDP.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PIDP.Name = "PIDP"
        Me.PIDP.Size = New System.Drawing.Size(88, 24)
        Me.PIDP.TabIndex = 10
        Me.PIDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBFindPID
        '
        Me.CBFindPID.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CBFindPID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBFindPID.Location = New System.Drawing.Point(15, 23)
        Me.CBFindPID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBFindPID.Name = "CBFindPID"
        Me.CBFindPID.Size = New System.Drawing.Size(98, 47)
        Me.CBFindPID.TabIndex = 9
        Me.CBFindPID.Text = "Load P.I.D."
        Me.CBFindPID.UseVisualStyleBackColor = False
        '
        'GroupBox19
        '
        Me.GroupBox19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox19.Controls.Add(Me.Label70)
        Me.GroupBox19.Controls.Add(Me.M145Butt)
        Me.GroupBox19.Controls.Add(Me.OptionHotBox)
        Me.GroupBox19.Controls.Add(Me.Label65)
        Me.GroupBox19.Controls.Add(Me.Label68)
        Me.GroupBox19.Controls.Add(Me.OptionFanBox)
        Me.GroupBox19.Controls.Add(Me.Label69)
        Me.GroupBox19.Controls.Add(Me.OptionBedBox)
        Me.GroupBox19.Controls.Add(Me.OptionABS)
        Me.GroupBox19.Controls.Add(Me.OptionPLA)
        Me.GroupBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox19.Location = New System.Drawing.Point(392, 375)
        Me.GroupBox19.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox19.Size = New System.Drawing.Size(424, 114)
        Me.GroupBox19.TabIndex = 6
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Printer Material Presets"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(49, 93)
        Me.Label70.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(302, 18)
        Me.Label70.TabIndex = 23
        Me.Label70.Text = "(Mat'l names cannot be changed via Gcode.)"
        '
        'M145Butt
        '
        Me.M145Butt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.M145Butt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M145Butt.Location = New System.Drawing.Point(272, 53)
        Me.M145Butt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.M145Butt.Name = "M145Butt"
        Me.M145Butt.Size = New System.Drawing.Size(142, 38)
        Me.M145Butt.TabIndex = 16
        Me.M145Butt.Text = "Send Material"
        Me.M145Butt.UseVisualStyleBackColor = False
        '
        'OptionHotBox
        '
        Me.OptionHotBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionHotBox.Location = New System.Drawing.Point(17, 64)
        Me.OptionHotBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OptionHotBox.Name = "OptionHotBox"
        Me.OptionHotBox.Size = New System.Drawing.Size(74, 24)
        Me.OptionHotBox.TabIndex = 18
        Me.OptionHotBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label65
        '
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(108, 41)
        Me.Label65.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(70, 19)
        Me.Label65.TabIndex = 22
        Me.Label65.Text = "Bed"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label68
        '
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(17, 41)
        Me.Label68.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(74, 19)
        Me.Label68.TabIndex = 21
        Me.Label68.Text = "Hot End"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OptionFanBox
        '
        Me.OptionFanBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionFanBox.Location = New System.Drawing.Point(193, 64)
        Me.OptionFanBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OptionFanBox.Name = "OptionFanBox"
        Me.OptionFanBox.Size = New System.Drawing.Size(71, 24)
        Me.OptionFanBox.TabIndex = 17
        Me.OptionFanBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label69
        '
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(193, 41)
        Me.Label69.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(71, 19)
        Me.Label69.TabIndex = 20
        Me.Label69.Text = "Fan %"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OptionBedBox
        '
        Me.OptionBedBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionBedBox.Location = New System.Drawing.Point(108, 64)
        Me.OptionBedBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OptionBedBox.Name = "OptionBedBox"
        Me.OptionBedBox.Size = New System.Drawing.Size(69, 24)
        Me.OptionBedBox.TabIndex = 19
        Me.OptionBedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OptionABS
        '
        Me.OptionABS.AutoSize = True
        Me.OptionABS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionABS.Location = New System.Drawing.Point(308, 11)
        Me.OptionABS.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OptionABS.Name = "OptionABS"
        Me.OptionABS.Size = New System.Drawing.Size(91, 22)
        Me.OptionABS.TabIndex = 15
        Me.OptionABS.Text = "Mat'l (1)"
        Me.OptionABS.UseVisualStyleBackColor = True
        '
        'OptionPLA
        '
        Me.OptionPLA.AutoSize = True
        Me.OptionPLA.Checked = True
        Me.OptionPLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionPLA.Location = New System.Drawing.Point(175, 11)
        Me.OptionPLA.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OptionPLA.Name = "OptionPLA"
        Me.OptionPLA.Size = New System.Drawing.Size(91, 22)
        Me.OptionPLA.TabIndex = 14
        Me.OptionPLA.TabStop = True
        Me.OptionPLA.Text = "Mat'l (0)"
        Me.OptionPLA.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox15.Controls.Add(Me.OffsetSendButton)
        Me.GroupBox15.Controls.Add(Me.Label59)
        Me.GroupBox15.Controls.Add(Me.Label60)
        Me.GroupBox15.Controls.Add(Me.Label61)
        Me.GroupBox15.Controls.Add(Me.OffsetZbox)
        Me.GroupBox15.Controls.Add(Me.OffsetYbox)
        Me.GroupBox15.Controls.Add(Me.OffsetXbox)
        Me.GroupBox15.Controls.Add(Me.CBFindOffset)
        Me.GroupBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.Location = New System.Drawing.Point(683, 82)
        Me.GroupBox15.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox15.Size = New System.Drawing.Size(133, 282)
        Me.GroupBox15.TabIndex = 2
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Home Offsets"
        '
        'OffsetSendButton
        '
        Me.OffsetSendButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.OffsetSendButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsetSendButton.Location = New System.Drawing.Point(13, 229)
        Me.OffsetSendButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OffsetSendButton.Name = "OffsetSendButton"
        Me.OffsetSendButton.Size = New System.Drawing.Size(108, 46)
        Me.OffsetSendButton.TabIndex = 16
        Me.OffsetSendButton.Text = "Send Offsets"
        Me.OffsetSendButton.UseVisualStyleBackColor = False
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(27, 177)
        Me.Label59.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(80, 18)
        Me.Label59.TabIndex = 15
        Me.Label59.Text = """Z"""
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(27, 123)
        Me.Label60.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(80, 18)
        Me.Label60.TabIndex = 14
        Me.Label60.Text = """Y"""
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(27, 70)
        Me.Label61.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(80, 18)
        Me.Label61.TabIndex = 13
        Me.Label61.Text = """X"""
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OffsetZbox
        '
        Me.OffsetZbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsetZbox.Location = New System.Drawing.Point(27, 199)
        Me.OffsetZbox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OffsetZbox.Name = "OffsetZbox"
        Me.OffsetZbox.Size = New System.Drawing.Size(80, 24)
        Me.OffsetZbox.TabIndex = 12
        Me.OffsetZbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OffsetYbox
        '
        Me.OffsetYbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsetYbox.Location = New System.Drawing.Point(27, 145)
        Me.OffsetYbox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OffsetYbox.Name = "OffsetYbox"
        Me.OffsetYbox.Size = New System.Drawing.Size(80, 24)
        Me.OffsetYbox.TabIndex = 11
        Me.OffsetYbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OffsetXbox
        '
        Me.OffsetXbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsetXbox.Location = New System.Drawing.Point(27, 92)
        Me.OffsetXbox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OffsetXbox.Name = "OffsetXbox"
        Me.OffsetXbox.Size = New System.Drawing.Size(80, 24)
        Me.OffsetXbox.TabIndex = 10
        Me.OffsetXbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBFindOffset
        '
        Me.CBFindOffset.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CBFindOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBFindOffset.Location = New System.Drawing.Point(16, 24)
        Me.CBFindOffset.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBFindOffset.Name = "CBFindOffset"
        Me.CBFindOffset.Size = New System.Drawing.Size(100, 46)
        Me.CBFindOffset.TabIndex = 9
        Me.CBFindOffset.Text = "Load Offsets"
        Me.CBFindOffset.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(88, 548)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 54)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Close Dialog"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(230, 610)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(533, 43)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "You must SEND any settings to the printer for the changes to take effect." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Settin" &
    "gs are temporary until you SAVE the settings in the printer."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.TAccelLab)
        Me.GroupBox1.Controls.Add(Me.TAccelBox)
        Me.GroupBox1.Controls.Add(Me.PAccelLab)
        Me.GroupBox1.Controls.Add(Me.PAccelBox)
        Me.GroupBox1.Controls.Add(Me.JuncLab)
        Me.GroupBox1.Controls.Add(Me.JuncDevBox)
        Me.GroupBox1.Controls.Add(Me.YJerkLab)
        Me.GroupBox1.Controls.Add(Me.YJerkBox)
        Me.GroupBox1.Controls.Add(Me.CBSetAccelJerk)
        Me.GroupBox1.Controls.Add(Me.XJerkLab)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.XJerkBox)
        Me.GroupBox1.Controls.Add(Me.YAccelBox)
        Me.GroupBox1.Controls.Add(Me.XAccelBox)
        Me.GroupBox1.Controls.Add(Me.CBLoadAccelJerk)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(824, 82)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(163, 407)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accel and Jerk"
        '
        'TAccelLab
        '
        Me.TAccelLab.AutoSize = True
        Me.TAccelLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TAccelLab.Location = New System.Drawing.Point(34, 221)
        Me.TAccelLab.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TAccelLab.Name = "TAccelLab"
        Me.TAccelLab.Size = New System.Drawing.Size(100, 18)
        Me.TAccelLab.TabIndex = 31
        Me.TAccelLab.Text = "Travel Accel"
        Me.TAccelLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TAccelBox
        '
        Me.TAccelBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TAccelBox.Location = New System.Drawing.Point(35, 243)
        Me.TAccelBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TAccelBox.Name = "TAccelBox"
        Me.TAccelBox.Size = New System.Drawing.Size(95, 24)
        Me.TAccelBox.TabIndex = 30
        Me.TAccelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TAccelBox, "Travel Jerk")
        '
        'PAccelLab
        '
        Me.PAccelLab.AutoSize = True
        Me.PAccelLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAccelLab.Location = New System.Drawing.Point(33, 171)
        Me.PAccelLab.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PAccelLab.Name = "PAccelLab"
        Me.PAccelLab.Size = New System.Drawing.Size(89, 18)
        Me.PAccelLab.TabIndex = 29
        Me.PAccelLab.Text = "Print Accel"
        Me.PAccelLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PAccelBox
        '
        Me.PAccelBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAccelBox.Location = New System.Drawing.Point(35, 192)
        Me.PAccelBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PAccelBox.Name = "PAccelBox"
        Me.PAccelBox.Size = New System.Drawing.Size(95, 24)
        Me.PAccelBox.TabIndex = 28
        Me.PAccelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.PAccelBox, "Print Jerk")
        '
        'JuncLab
        '
        Me.JuncLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JuncLab.Location = New System.Drawing.Point(2, 283)
        Me.JuncLab.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.JuncLab.Name = "JuncLab"
        Me.JuncLab.Size = New System.Drawing.Size(162, 19)
        Me.JuncLab.TabIndex = 27
        Me.JuncLab.Text = "Junction Deviation"
        Me.JuncLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.JuncLab.Visible = False
        '
        'JuncDevBox
        '
        Me.JuncDevBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EnderApp.My.MySettings.Default, "JunctionDeviation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.JuncDevBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JuncDevBox.Location = New System.Drawing.Point(35, 303)
        Me.JuncDevBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.JuncDevBox.Name = "JuncDevBox"
        Me.JuncDevBox.Size = New System.Drawing.Size(94, 24)
        Me.JuncDevBox.TabIndex = 26
        Me.JuncDevBox.Text = Global.EnderApp.My.MySettings.Default.JunctionDeviation
        Me.JuncDevBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.JuncDevBox.Visible = False
        '
        'YJerkLab
        '
        Me.YJerkLab.AutoSize = True
        Me.YJerkLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YJerkLab.Location = New System.Drawing.Point(88, 283)
        Me.YJerkLab.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.YJerkLab.Name = "YJerkLab"
        Me.YJerkLab.Size = New System.Drawing.Size(56, 18)
        Me.YJerkLab.TabIndex = 25
        Me.YJerkLab.Text = "Y Jerk"
        Me.YJerkLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'YJerkBox
        '
        Me.YJerkBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YJerkBox.Location = New System.Drawing.Point(94, 303)
        Me.YJerkBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.YJerkBox.Name = "YJerkBox"
        Me.YJerkBox.Size = New System.Drawing.Size(47, 24)
        Me.YJerkBox.TabIndex = 24
        Me.YJerkBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.YJerkBox, "Jerk Y Axis")
        '
        'CBSetAccelJerk
        '
        Me.CBSetAccelJerk.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CBSetAccelJerk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSetAccelJerk.Location = New System.Drawing.Point(13, 340)
        Me.CBSetAccelJerk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBSetAccelJerk.Name = "CBSetAccelJerk"
        Me.CBSetAccelJerk.Size = New System.Drawing.Size(133, 56)
        Me.CBSetAccelJerk.TabIndex = 23
        Me.CBSetAccelJerk.Text = "Send Accel+Jerk"
        Me.CBSetAccelJerk.UseVisualStyleBackColor = False
        '
        'XJerkLab
        '
        Me.XJerkLab.AutoSize = True
        Me.XJerkLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XJerkLab.Location = New System.Drawing.Point(17, 283)
        Me.XJerkLab.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.XJerkLab.Name = "XJerkLab"
        Me.XJerkLab.Size = New System.Drawing.Size(57, 18)
        Me.XJerkLab.TabIndex = 22
        Me.XJerkLab.Text = "X Jerk"
        Me.XJerkLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 125)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 19)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Y Accel Max"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 76)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 19)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "X Accel Max"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XJerkBox
        '
        Me.XJerkBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XJerkBox.Location = New System.Drawing.Point(23, 303)
        Me.XJerkBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.XJerkBox.Name = "XJerkBox"
        Me.XJerkBox.Size = New System.Drawing.Size(47, 24)
        Me.XJerkBox.TabIndex = 19
        Me.XJerkBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.XJerkBox, "Jerk X Axis")
        '
        'YAccelBox
        '
        Me.YAccelBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YAccelBox.Location = New System.Drawing.Point(35, 144)
        Me.YAccelBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.YAccelBox.Name = "YAccelBox"
        Me.YAccelBox.Size = New System.Drawing.Size(94, 24)
        Me.YAccelBox.TabIndex = 18
        Me.YAccelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'XAccelBox
        '
        Me.XAccelBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XAccelBox.Location = New System.Drawing.Point(35, 97)
        Me.XAccelBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.XAccelBox.Name = "XAccelBox"
        Me.XAccelBox.Size = New System.Drawing.Size(94, 24)
        Me.XAccelBox.TabIndex = 17
        Me.XAccelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBLoadAccelJerk
        '
        Me.CBLoadAccelJerk.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CBLoadAccelJerk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBLoadAccelJerk.Location = New System.Drawing.Point(13, 22)
        Me.CBLoadAccelJerk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CBLoadAccelJerk.Name = "CBLoadAccelJerk"
        Me.CBLoadAccelJerk.Size = New System.Drawing.Size(133, 51)
        Me.CBLoadAccelJerk.TabIndex = 0
        Me.CBLoadAccelJerk.Text = "Load" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Accel / Jerk"
        Me.CBLoadAccelJerk.UseVisualStyleBackColor = False
        '
        'FactResetBut
        '
        Me.FactResetBut.BackColor = System.Drawing.Color.Red
        Me.FactResetBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FactResetBut.ForeColor = System.Drawing.Color.White
        Me.FactResetBut.Location = New System.Drawing.Point(779, 548)
        Me.FactResetBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.FactResetBut.Name = "FactResetBut"
        Me.FactResetBut.Size = New System.Drawing.Size(160, 54)
        Me.FactResetBut.TabIndex = 14
        Me.FactResetBut.Text = "Factory Reset"
        Me.FactResetBut.UseVisualStyleBackColor = False
        '
        'ExtrCalibrateEBut
        '
        Me.ExtrCalibrateEBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtrCalibrateEBut.Location = New System.Drawing.Point(194, 461)
        Me.ExtrCalibrateEBut.Name = "ExtrCalibrateEBut"
        Me.ExtrCalibrateEBut.Size = New System.Drawing.Size(181, 27)
        Me.ExtrCalibrateEBut.TabIndex = 15
        Me.ExtrCalibrateEBut.Text = "Extrude Target Amt"
        Me.ExtrCalibrateEBut.UseVisualStyleBackColor = True
        '
        'PrinterSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 673)
        Me.Controls.Add(Me.ExtrCalibrateEBut)
        Me.Controls.Add(Me.FactResetBut)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox20)
        Me.Controls.Add(Me.CBSaveSteps)
        Me.Controls.Add(Me.GroupBox16)
        Me.Controls.Add(Me.CBGetSettings)
        Me.Controls.Add(Me.GroupBox17)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.GroupBox19)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1018, 720)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1018, 720)
        Me.Name = "PrinterSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valiant Printer Settings"
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox17 As GroupBox
    Friend WithEvents CopyStepsBut As Button
    Friend WithEvents CalcNewStepsBox As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents CalcEopt As RadioButton
    Friend WithEvents CalcCaliButt As Button
    Friend WithEvents CalcZopt As RadioButton
    Friend WithEvents CalcYopt As RadioButton
    Friend WithEvents CalcXopt As RadioButton
    Friend WithEvents CalcTargetBox As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents CalcStepsBox As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents CalcMeasureBox As TextBox
    Friend WithEvents CBSaveSteps As Button
    Friend WithEvents CBGetSettings As Button
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents Label74 As Label
    Friend WithEvents StepsE As TextBox
    Friend WithEvents CBSetsteps As Button
    Friend WithEvents Label71 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents StepsZ As TextBox
    Friend WithEvents StepsY As TextBox
    Friend WithEvents StepsX As TextBox
    Friend WithEvents CBGetSteps As Button
    Friend WithEvents GroupBox20 As GroupBox
    Friend WithEvents Label66 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents AutoTuneReps As TextBox
    Friend WithEvents AutoTuneTemp As TextBox
    Friend WithEvents CBAutoTune As Button
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents CBSetPID As Button
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents PIDD As TextBox
    Friend WithEvents PIDI As TextBox
    Friend WithEvents PIDP As TextBox
    Friend WithEvents CBFindPID As Button
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents Label70 As Label
    Friend WithEvents M145Butt As Button
    Friend WithEvents OptionHotBox As TextBox
    Friend WithEvents Label65 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents OptionFanBox As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents OptionBedBox As TextBox
    Friend WithEvents OptionABS As RadioButton
    Friend WithEvents OptionPLA As RadioButton
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents OffsetSendButton As Button
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents OffsetZbox As TextBox
    Friend WithEvents OffsetYbox As TextBox
    Friend WithEvents OffsetXbox As TextBox
    Friend WithEvents CBFindOffset As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents YJerkLab As Label
    Friend WithEvents YJerkBox As TextBox
    Friend WithEvents CBSetAccelJerk As Button
    Friend WithEvents XJerkLab As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents XJerkBox As TextBox
    Friend WithEvents YAccelBox As TextBox
    Friend WithEvents XAccelBox As TextBox
    Friend WithEvents CBLoadAccelJerk As Button
    Friend WithEvents FactResetBut As Button
    Friend WithEvents JuncLab As Label
    Friend WithEvents JuncDevBox As TextBox
    Friend WithEvents TAccelLab As Label
    Friend WithEvents TAccelBox As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PAccelLab As Label
    Friend WithEvents PAccelBox As TextBox
    Friend WithEvents ExtrCalibrateEBut As Button
End Class
