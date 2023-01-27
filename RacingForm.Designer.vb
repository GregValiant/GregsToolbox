<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RacingForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RacingForm))
        Me.GoBut = New System.Windows.Forms.Button()
        Me.MaxX = New System.Windows.Forms.TextBox()
        Me.MaxY = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SpeedBox = New System.Windows.Forms.TextBox()
        Me.ETBox = New System.Windows.Forms.TextBox()
        Me.CloseBut = New System.Windows.Forms.Button()
        Me.StagedBut = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CourseLength = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Figure8 = New System.Windows.Forms.RadioButton()
        Me.GreatCircle = New System.Windows.Forms.RadioButton()
        Me.F1Race = New System.Windows.Forms.RadioButton()
        Me.DemoRace = New System.Windows.Forms.RadioButton()
        Me.NascarRace = New System.Windows.Forms.RadioButton()
        Me.DragRace = New System.Windows.Forms.RadioButton()
        Me.MMperMIN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.JerkXlab = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.AccelXBox = New System.Windows.Forms.NumericUpDown()
        Me.JerkXBox = New System.Windows.Forms.NumericUpDown()
        Me.BeepControl = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.StartsStops = New System.Windows.Forms.TextBox()
        Me.VelocityBox = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RacingTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.JerkYBox = New System.Windows.Forms.NumericUpDown()
        Me.AccelYBox = New System.Windows.Forms.NumericUpDown()
        Me.DoubleDistBox = New System.Windows.Forms.CheckBox()
        Me.M503RaceBut = New System.Windows.Forms.Button()
        Me.JerkAccelSaveBut = New System.Windows.Forms.Button()
        Me.JerkYLab = New System.Windows.Forms.Label()
        Me.SyncAccel = New System.Windows.Forms.CheckBox()
        Me.SyncJerk = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.HomeBut = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AccelXBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JerkXBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VelocityBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JerkYBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccelYBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GoBut
        '
        Me.GoBut.BackColor = System.Drawing.Color.Red
        Me.GoBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoBut.ForeColor = System.Drawing.Color.Black
        Me.GoBut.Location = New System.Drawing.Point(247, 511)
        Me.GoBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GoBut.Name = "GoBut"
        Me.GoBut.Size = New System.Drawing.Size(160, 46)
        Me.GoBut.TabIndex = 0
        Me.GoBut.Text = "Red FLag"
        Me.RacingTip.SetToolTip(Me.GoBut, "Start the Race")
        Me.GoBut.UseVisualStyleBackColor = False
        '
        'MaxX
        '
        Me.MaxX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxX.Location = New System.Drawing.Point(59, 82)
        Me.MaxX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaxX.Name = "MaxX"
        Me.MaxX.Size = New System.Drawing.Size(59, 27)
        Me.MaxX.TabIndex = 1
        Me.MaxX.Text = "100"
        Me.MaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.MaxX, "Up to Max X")
        '
        'MaxY
        '
        Me.MaxY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxY.Location = New System.Drawing.Point(163, 82)
        Me.MaxY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaxY.Name = "MaxY"
        Me.MaxY.Size = New System.Drawing.Size(55, 27)
        Me.MaxY.TabIndex = 2
        Me.MaxY.Text = "100"
        Me.MaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.MaxY, "Up to Max Y")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 57)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter up to the Max X and Max Y of your build area"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(158, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Max Y"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Max X"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(201, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(275, 30)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Enter the Travel Speed"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(121, 560)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 48)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Elapsed Time" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in sec's"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(259, 560)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 48)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Average Speed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in mm/sec"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SpeedBox
        '
        Me.SpeedBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedBox.Location = New System.Drawing.Point(271, 610)
        Me.SpeedBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SpeedBox.Name = "SpeedBox"
        Me.SpeedBox.Size = New System.Drawing.Size(105, 27)
        Me.SpeedBox.TabIndex = 9
        Me.SpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.SpeedBox, "Numbers you would see in Cura")
        '
        'ETBox
        '
        Me.ETBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETBox.Location = New System.Drawing.Point(118, 610)
        Me.ETBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ETBox.Name = "ETBox"
        Me.ETBox.Size = New System.Drawing.Size(116, 27)
        Me.ETBox.TabIndex = 8
        Me.ETBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.ETBox, "Lowest time is the most accurate for any given configuration")
        '
        'CloseBut
        '
        Me.CloseBut.BackColor = System.Drawing.Color.Yellow
        Me.CloseBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBut.Location = New System.Drawing.Point(271, 647)
        Me.CloseBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CloseBut.Name = "CloseBut"
        Me.CloseBut.Size = New System.Drawing.Size(107, 33)
        Me.CloseBut.TabIndex = 12
        Me.CloseBut.Text = "Close"
        Me.RacingTip.SetToolTip(Me.CloseBut, "If you need a TooTip for this you should give up.")
        Me.CloseBut.UseVisualStyleBackColor = False
        '
        'StagedBut
        '
        Me.StagedBut.BackColor = System.Drawing.Color.Red
        Me.StagedBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StagedBut.ForeColor = System.Drawing.Color.White
        Me.StagedBut.Location = New System.Drawing.Point(183, 459)
        Me.StagedBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StagedBut.Name = "StagedBut"
        Me.StagedBut.Size = New System.Drawing.Size(293, 46)
        Me.StagedBut.TabIndex = 13
        Me.StagedBut.Text = "Staged - Prepare to Race"
        Me.RacingTip.SetToolTip(Me.StagedBut, "Send Accel and Jerk to the printer")
        Me.StagedBut.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(160, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 23)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Course Length in mm's"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CourseLength
        '
        Me.CourseLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CourseLength.Location = New System.Drawing.Point(177, 426)
        Me.CourseLength.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CourseLength.Name = "CourseLength"
        Me.CourseLength.Size = New System.Drawing.Size(151, 27)
        Me.CourseLength.TabIndex = 14
        Me.CourseLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox1.Controls.Add(Me.Figure8)
        Me.GroupBox1.Controls.Add(Me.GreatCircle)
        Me.GroupBox1.Controls.Add(Me.F1Race)
        Me.GroupBox1.Controls.Add(Me.DemoRace)
        Me.GroupBox1.Controls.Add(Me.NascarRace)
        Me.GroupBox1.Controls.Add(Me.DragRace)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(226, 197)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(216, 187)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select a Course"
        '
        'Figure8
        '
        Me.Figure8.AutoSize = True
        Me.Figure8.Location = New System.Drawing.Point(19, 148)
        Me.Figure8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Figure8.Name = "Figure8"
        Me.Figure8.Size = New System.Drawing.Size(86, 24)
        Me.Figure8.TabIndex = 5
        Me.Figure8.Text = "Infinity"
        Me.RacingTip.SetToolTip(Me.Figure8, "A Figure 8 laying on its side")
        Me.Figure8.UseVisualStyleBackColor = True
        '
        'GreatCircle
        '
        Me.GreatCircle.AutoSize = True
        Me.GreatCircle.Location = New System.Drawing.Point(19, 123)
        Me.GreatCircle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GreatCircle.Name = "GreatCircle"
        Me.GreatCircle.Size = New System.Drawing.Size(146, 24)
        Me.GreatCircle.TabIndex = 4
        Me.GreatCircle.Text = "Round-a-Bout"
        Me.RacingTip.SetToolTip(Me.GreatCircle, "2 laps around a max circle")
        Me.GreatCircle.UseVisualStyleBackColor = True
        '
        'F1Race
        '
        Me.F1Race.AutoSize = True
        Me.F1Race.Location = New System.Drawing.Point(19, 98)
        Me.F1Race.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.F1Race.Name = "F1Race"
        Me.F1Race.Size = New System.Drawing.Size(156, 24)
        Me.F1Race.TabIndex = 3
        Me.F1Race.Text = "F1 Nurburgring"
        Me.RacingTip.SetToolTip(Me.F1Race, "Lots of turns")
        Me.F1Race.UseVisualStyleBackColor = True
        '
        'DemoRace
        '
        Me.DemoRace.AutoSize = True
        Me.DemoRace.Location = New System.Drawing.Point(19, 73)
        Me.DemoRace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DemoRace.Name = "DemoRace"
        Me.DemoRace.Size = New System.Drawing.Size(176, 24)
        Me.DemoRace.TabIndex = 2
        Me.DemoRace.Text = "Demolition Derby"
        Me.RacingTip.SetToolTip(Me.DemoRace, "Figure 8")
        Me.DemoRace.UseVisualStyleBackColor = True
        '
        'NascarRace
        '
        Me.NascarRace.AutoSize = True
        Me.NascarRace.Location = New System.Drawing.Point(19, 48)
        Me.NascarRace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NascarRace.Name = "NascarRace"
        Me.NascarRace.Size = New System.Drawing.Size(154, 24)
        Me.NascarRace.TabIndex = 1
        Me.NascarRace.Text = "NASCAR Race"
        Me.RacingTip.SetToolTip(Me.NascarRace, "Race around the periphery - all left turns")
        Me.NascarRace.UseVisualStyleBackColor = True
        '
        'DragRace
        '
        Me.DragRace.AutoSize = True
        Me.DragRace.Checked = True
        Me.DragRace.Location = New System.Drawing.Point(19, 23)
        Me.DragRace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DragRace.Name = "DragRace"
        Me.DragRace.Size = New System.Drawing.Size(120, 24)
        Me.DragRace.TabIndex = 0
        Me.DragRace.TabStop = True
        Me.DragRace.Text = "Drag Race"
        Me.RacingTip.SetToolTip(Me.DragRace, "0 to Max XY and back")
        Me.DragRace.UseVisualStyleBackColor = True
        '
        'MMperMIN
        '
        Me.MMperMIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MMperMIN.Location = New System.Drawing.Point(421, 610)
        Me.MMperMIN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MMperMIN.Name = "MMperMIN"
        Me.MMperMIN.Size = New System.Drawing.Size(105, 27)
        Me.MMperMIN.TabIndex = 17
        Me.MMperMIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.MMperMIN, "Numbers as in a GCODE file")
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(405, 560)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 48)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Average Speed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in mm/min"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(280, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "X"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'JerkXlab
        '
        Me.JerkXlab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JerkXlab.Location = New System.Drawing.Point(455, 55)
        Me.JerkXlab.Name = "JerkXlab"
        Me.JerkXlab.Size = New System.Drawing.Size(59, 16)
        Me.JerkXlab.TabIndex = 21
        Me.JerkXlab.Text = "X"
        Me.JerkXlab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(331, -2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(203, 30)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Accel and Jerk 0 = Off"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AccelXBox
        '
        Me.AccelXBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccelXBox.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.AccelXBox.Location = New System.Drawing.Point(276, 82)
        Me.AccelXBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AccelXBox.Maximum = New Decimal(New Integer() {6000, 0, 0, 0})
        Me.AccelXBox.Name = "AccelXBox"
        Me.AccelXBox.Size = New System.Drawing.Size(76, 27)
        Me.AccelXBox.TabIndex = 24
        Me.AccelXBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.AccelXBox, "0 = Off | 6000 = Max")
        Me.AccelXBox.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'JerkXBox
        '
        Me.JerkXBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JerkXBox.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.JerkXBox.Location = New System.Drawing.Point(460, 82)
        Me.JerkXBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.JerkXBox.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.JerkXBox.Name = "JerkXBox"
        Me.JerkXBox.Size = New System.Drawing.Size(59, 27)
        Me.JerkXBox.TabIndex = 25
        Me.JerkXBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.JerkXBox, "0 = Off | 30 = Max")
        Me.JerkXBox.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'BeepControl
        '
        Me.BeepControl.AutoSize = True
        Me.BeepControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BeepControl.Location = New System.Drawing.Point(50, 149)
        Me.BeepControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BeepControl.Name = "BeepControl"
        Me.BeepControl.Size = New System.Drawing.Size(137, 24)
        Me.BeepControl.TabIndex = 26
        Me.BeepControl.Text = "Starting Gun"
        Me.RacingTip.SetToolTip(Me.BeepControl, "Annoying buzzer")
        Me.BeepControl.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(358, 400)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(177, 23)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Stops and Starts"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StartsStops
        '
        Me.StartsStops.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartsStops.Location = New System.Drawing.Point(406, 426)
        Me.StartsStops.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartsStops.Name = "StartsStops"
        Me.StartsStops.Size = New System.Drawing.Size(75, 27)
        Me.StartsStops.TabIndex = 27
        Me.StartsStops.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'VelocityBox
        '
        Me.VelocityBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VelocityBox.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.VelocityBox.Location = New System.Drawing.Point(306, 154)
        Me.VelocityBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.VelocityBox.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.VelocityBox.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.VelocityBox.Name = "VelocityBox"
        Me.VelocityBox.Size = New System.Drawing.Size(76, 27)
        Me.VelocityBox.TabIndex = 30
        Me.VelocityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.VelocityBox, "10 = Min | 400 = Max")
        Me.VelocityBox.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(389, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 23)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "mm/sec"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'JerkYBox
        '
        Me.JerkYBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JerkYBox.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.JerkYBox.Location = New System.Drawing.Point(540, 82)
        Me.JerkYBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.JerkYBox.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.JerkYBox.Name = "JerkYBox"
        Me.JerkYBox.Size = New System.Drawing.Size(59, 27)
        Me.JerkYBox.TabIndex = 35
        Me.JerkYBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.JerkYBox, "0 = Off | 30 = Max")
        Me.JerkYBox.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'AccelYBox
        '
        Me.AccelYBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccelYBox.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.AccelYBox.Location = New System.Drawing.Point(358, 82)
        Me.AccelYBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AccelYBox.Maximum = New Decimal(New Integer() {6000, 0, 0, 0})
        Me.AccelYBox.Name = "AccelYBox"
        Me.AccelYBox.Size = New System.Drawing.Size(76, 27)
        Me.AccelYBox.TabIndex = 39
        Me.AccelYBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RacingTip.SetToolTip(Me.AccelYBox, "0 = Off | 6000 = Max")
        Me.AccelYBox.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'DoubleDistBox
        '
        Me.DoubleDistBox.AutoSize = True
        Me.DoubleDistBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoubleDistBox.Location = New System.Drawing.Point(50, 186)
        Me.DoubleDistBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DoubleDistBox.Name = "DoubleDistBox"
        Me.DoubleDistBox.Size = New System.Drawing.Size(106, 44)
        Me.DoubleDistBox.TabIndex = 31
        Me.DoubleDistBox.Text = "Double" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Distance"
        Me.DoubleDistBox.UseVisualStyleBackColor = True
        '
        'M503RaceBut
        '
        Me.M503RaceBut.BackColor = System.Drawing.Color.PeachPuff
        Me.M503RaceBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M503RaceBut.Location = New System.Drawing.Point(24, 242)
        Me.M503RaceBut.Name = "M503RaceBut"
        Me.M503RaceBut.Size = New System.Drawing.Size(106, 33)
        Me.M503RaceBut.TabIndex = 32
        Me.M503RaceBut.Text = "M503"
        Me.M503RaceBut.UseVisualStyleBackColor = False
        '
        'JerkAccelSaveBut
        '
        Me.JerkAccelSaveBut.BackColor = System.Drawing.Color.LightSalmon
        Me.JerkAccelSaveBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JerkAccelSaveBut.Location = New System.Drawing.Point(24, 304)
        Me.JerkAccelSaveBut.Name = "JerkAccelSaveBut"
        Me.JerkAccelSaveBut.Size = New System.Drawing.Size(106, 56)
        Me.JerkAccelSaveBut.TabIndex = 33
        Me.JerkAccelSaveBut.Text = "Save to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Printer"
        Me.JerkAccelSaveBut.UseVisualStyleBackColor = False
        '
        'JerkYLab
        '
        Me.JerkYLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JerkYLab.Location = New System.Drawing.Point(535, 55)
        Me.JerkYLab.Name = "JerkYLab"
        Me.JerkYLab.Size = New System.Drawing.Size(64, 16)
        Me.JerkYLab.TabIndex = 34
        Me.JerkYLab.Text = "Y"
        Me.JerkYLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SyncAccel
        '
        Me.SyncAccel.AutoSize = True
        Me.SyncAccel.Checked = True
        Me.SyncAccel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SyncAccel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SyncAccel.Location = New System.Drawing.Point(293, 30)
        Me.SyncAccel.Name = "SyncAccel"
        Me.SyncAccel.Size = New System.Drawing.Size(113, 22)
        Me.SyncAccel.TabIndex = 36
        Me.SyncAccel.Text = "Sync Accel"
        Me.SyncAccel.UseVisualStyleBackColor = True
        '
        'SyncJerk
        '
        Me.SyncJerk.AutoSize = True
        Me.SyncJerk.Checked = True
        Me.SyncJerk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SyncJerk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SyncJerk.Location = New System.Drawing.Point(477, 30)
        Me.SyncJerk.Name = "SyncJerk"
        Me.SyncJerk.Size = New System.Drawing.Size(105, 22)
        Me.SyncJerk.TabIndex = 37
        Me.SyncJerk.Text = "Sync Jerk"
        Me.SyncJerk.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(362, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 16)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Y"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HomeBut
        '
        Me.HomeBut.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HomeBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeBut.Location = New System.Drawing.Point(24, 390)
        Me.HomeBut.Name = "HomeBut"
        Me.HomeBut.Size = New System.Drawing.Size(106, 33)
        Me.HomeBut.TabIndex = 40
        Me.HomeBut.Text = "Home"
        Me.HomeBut.UseVisualStyleBackColor = False
        '
        'RacingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 703)
        Me.Controls.Add(Me.HomeBut)
        Me.Controls.Add(Me.AccelYBox)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.SyncJerk)
        Me.Controls.Add(Me.SyncAccel)
        Me.Controls.Add(Me.JerkYBox)
        Me.Controls.Add(Me.JerkYLab)
        Me.Controls.Add(Me.JerkAccelSaveBut)
        Me.Controls.Add(Me.M503RaceBut)
        Me.Controls.Add(Me.DoubleDistBox)
        Me.Controls.Add(Me.VelocityBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.StartsStops)
        Me.Controls.Add(Me.BeepControl)
        Me.Controls.Add(Me.JerkXBox)
        Me.Controls.Add(Me.AccelXBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.JerkXlab)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.MMperMIN)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CourseLength)
        Me.Controls.Add(Me.StagedBut)
        Me.Controls.Add(Me.CloseBut)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SpeedBox)
        Me.Controls.Add(Me.ETBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaxY)
        Me.Controls.Add(Me.MaxX)
        Me.Controls.Add(Me.GoBut)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(650, 750)
        Me.MinimumSize = New System.Drawing.Size(650, 750)
        Me.Name = "RacingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valiant Racing Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AccelXBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JerkXBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VelocityBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JerkYBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccelYBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GoBut As Button
    Friend WithEvents MaxX As TextBox
    Friend WithEvents MaxY As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SpeedBox As TextBox
    Friend WithEvents ETBox As TextBox
    Friend WithEvents CloseBut As Button
    Friend WithEvents StagedBut As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents CourseLength As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DemoRace As RadioButton
    Friend WithEvents NascarRace As RadioButton
    Friend WithEvents DragRace As RadioButton
    Friend WithEvents MMperMIN As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents JerkXlab As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents AccelXBox As NumericUpDown
    Friend WithEvents JerkXBox As NumericUpDown
    Friend WithEvents BeepControl As CheckBox
    Friend WithEvents F1Race As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents StartsStops As TextBox
    Friend WithEvents GreatCircle As RadioButton
    Friend WithEvents VelocityBox As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents RacingTip As ToolTip
    Friend WithEvents Figure8 As RadioButton
    Friend WithEvents DoubleDistBox As CheckBox
    Friend WithEvents M503RaceBut As Button
    Friend WithEvents JerkAccelSaveBut As Button
    Friend WithEvents JerkYBox As NumericUpDown
    Friend WithEvents JerkYLab As Label
    Friend WithEvents SyncAccel As CheckBox
    Friend WithEvents SyncJerk As CheckBox
    Friend WithEvents AccelYBox As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents HomeBut As Button
End Class
