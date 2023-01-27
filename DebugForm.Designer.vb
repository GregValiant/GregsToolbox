<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebugForm))
        Me.DebugFileNameBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DebugLineBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.KillExtrudeChk = New System.Windows.Forms.CheckBox()
        Me.AirPrintChk = New System.Windows.Forms.CheckBox()
        Me.SendBut = New System.Windows.Forms.Button()
        Me.DebugCurrentLineBox = New System.Windows.Forms.TextBox()
        Me.SkipBut = New System.Windows.Forms.Button()
        Me.LabelPlus1 = New System.Windows.Forms.Label()
        Me.LabelMinus1 = New System.Windows.Forms.Label()
        Me.StartBut = New System.Windows.Forms.Button()
        Me.CloseBut = New System.Windows.Forms.Button()
        Me.LabelMinus2 = New System.Windows.Forms.Label()
        Me.LabelMinus3 = New System.Windows.Forms.Label()
        Me.LabelMinus4 = New System.Windows.Forms.Label()
        Me.LabelPlus2 = New System.Windows.Forms.Label()
        Me.LabelPlus3 = New System.Windows.Forms.Label()
        Me.LabelPlus4 = New System.Windows.Forms.Label()
        Me.LabelPlus4L = New System.Windows.Forms.Label()
        Me.LabelPlus3L = New System.Windows.Forms.Label()
        Me.LabelPlus2L = New System.Windows.Forms.Label()
        Me.LabelPlus1L = New System.Windows.Forms.Label()
        Me.LabelMinus1L = New System.Windows.Forms.Label()
        Me.LabelMinus2L = New System.Windows.Forms.Label()
        Me.LabelMinus3L = New System.Windows.Forms.Label()
        Me.LabelMinus4L = New System.Windows.Forms.Label()
        Me.LabelCurrent = New System.Windows.Forms.Label()
        Me.WarningLabel = New System.Windows.Forms.Label()
        Me.HideWarningBut = New System.Windows.Forms.Button()
        Me.InsertCmdBut = New System.Windows.Forms.Button()
        Me.RunGcodeBut = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'DebugFileNameBox
        '
        Me.DebugFileNameBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugFileNameBox.Location = New System.Drawing.Point(16, 46)
        Me.DebugFileNameBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DebugFileNameBox.Name = "DebugFileNameBox"
        Me.DebugFileNameBox.Size = New System.Drawing.Size(767, 27)
        Me.DebugFileNameBox.TabIndex = 0
        Me.DebugFileNameBox.Text = "FileName"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GCODE Path and File Name"
        '
        'DebugLineBox
        '
        Me.DebugLineBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugLineBox.Location = New System.Drawing.Point(19, 137)
        Me.DebugLineBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DebugLineBox.Name = "DebugLineBox"
        Me.DebugLineBox.Size = New System.Drawing.Size(129, 27)
        Me.DebugLineBox.TabIndex = 2
        Me.DebugLineBox.Text = "1"
        Me.DebugLineBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Line number to Start from"
        '
        'KillExtrudeChk
        '
        Me.KillExtrudeChk.BackColor = System.Drawing.Color.Wheat
        Me.KillExtrudeChk.Checked = True
        Me.KillExtrudeChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.KillExtrudeChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KillExtrudeChk.Location = New System.Drawing.Point(588, 126)
        Me.KillExtrudeChk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.KillExtrudeChk.Name = "KillExtrudeChk"
        Me.KillExtrudeChk.Size = New System.Drawing.Size(195, 39)
        Me.KillExtrudeChk.TabIndex = 4
        Me.KillExtrudeChk.Text = "Ignore Extrusion"
        Me.KillExtrudeChk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.KillExtrudeChk.UseVisualStyleBackColor = False
        '
        'AirPrintChk
        '
        Me.AirPrintChk.BackColor = System.Drawing.Color.Wheat
        Me.AirPrintChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirPrintChk.Location = New System.Drawing.Point(588, 76)
        Me.AirPrintChk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AirPrintChk.Name = "AirPrintChk"
        Me.AirPrintChk.Size = New System.Drawing.Size(195, 43)
        Me.AirPrintChk.TabIndex = 5
        Me.AirPrintChk.Text = "Air Print and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ignore Z"
        Me.AirPrintChk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AirPrintChk.UseVisualStyleBackColor = False
        '
        'SendBut
        '
        Me.SendBut.BackColor = System.Drawing.Color.Turquoise
        Me.SendBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SendBut.Location = New System.Drawing.Point(613, 300)
        Me.SendBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SendBut.Name = "SendBut"
        Me.SendBut.Size = New System.Drawing.Size(139, 54)
        Me.SendBut.TabIndex = 6
        Me.SendBut.Text = "Send Line"
        Me.SendBut.UseVisualStyleBackColor = False
        '
        'DebugCurrentLineBox
        '
        Me.DebugCurrentLineBox.BackColor = System.Drawing.Color.White
        Me.DebugCurrentLineBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugCurrentLineBox.Location = New System.Drawing.Point(117, 314)
        Me.DebugCurrentLineBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DebugCurrentLineBox.Name = "DebugCurrentLineBox"
        Me.DebugCurrentLineBox.Size = New System.Drawing.Size(489, 27)
        Me.DebugCurrentLineBox.TabIndex = 7
        Me.DebugCurrentLineBox.Text = "---"
        '
        'SkipBut
        '
        Me.SkipBut.BackColor = System.Drawing.Color.LemonChiffon
        Me.SkipBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SkipBut.Location = New System.Drawing.Point(613, 357)
        Me.SkipBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SkipBut.Name = "SkipBut"
        Me.SkipBut.Size = New System.Drawing.Size(139, 36)
        Me.SkipBut.TabIndex = 8
        Me.SkipBut.Text = "Skip Line"
        Me.SkipBut.UseVisualStyleBackColor = False
        '
        'LabelPlus1
        '
        Me.LabelPlus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus1.Location = New System.Drawing.Point(117, 357)
        Me.LabelPlus1.Name = "LabelPlus1"
        Me.LabelPlus1.Size = New System.Drawing.Size(373, 17)
        Me.LabelPlus1.TabIndex = 10
        Me.LabelPlus1.Text = "---"
        '
        'LabelMinus1
        '
        Me.LabelMinus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus1.Location = New System.Drawing.Point(117, 277)
        Me.LabelMinus1.Name = "LabelMinus1"
        Me.LabelMinus1.Size = New System.Drawing.Size(373, 17)
        Me.LabelMinus1.TabIndex = 11
        Me.LabelMinus1.Text = "---"
        '
        'StartBut
        '
        Me.StartBut.BackColor = System.Drawing.Color.Chartreuse
        Me.StartBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartBut.Location = New System.Drawing.Point(613, 199)
        Me.StartBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartBut.Name = "StartBut"
        Me.StartBut.Size = New System.Drawing.Size(139, 54)
        Me.StartBut.TabIndex = 12
        Me.StartBut.Text = "Get Started"
        Me.StartBut.UseVisualStyleBackColor = False
        '
        'CloseBut
        '
        Me.CloseBut.BackColor = System.Drawing.Color.Gold
        Me.CloseBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBut.Location = New System.Drawing.Point(606, 509)
        Me.CloseBut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CloseBut.Name = "CloseBut"
        Me.CloseBut.Size = New System.Drawing.Size(157, 54)
        Me.CloseBut.TabIndex = 13
        Me.CloseBut.Text = "Quit" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Debugger"
        Me.CloseBut.UseVisualStyleBackColor = False
        '
        'LabelMinus2
        '
        Me.LabelMinus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus2.Location = New System.Drawing.Point(117, 247)
        Me.LabelMinus2.Name = "LabelMinus2"
        Me.LabelMinus2.Size = New System.Drawing.Size(373, 17)
        Me.LabelMinus2.TabIndex = 15
        Me.LabelMinus2.Text = "---"
        '
        'LabelMinus3
        '
        Me.LabelMinus3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus3.Location = New System.Drawing.Point(117, 217)
        Me.LabelMinus3.Name = "LabelMinus3"
        Me.LabelMinus3.Size = New System.Drawing.Size(373, 17)
        Me.LabelMinus3.TabIndex = 16
        Me.LabelMinus3.Text = "---"
        '
        'LabelMinus4
        '
        Me.LabelMinus4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus4.Location = New System.Drawing.Point(117, 187)
        Me.LabelMinus4.Name = "LabelMinus4"
        Me.LabelMinus4.Size = New System.Drawing.Size(373, 17)
        Me.LabelMinus4.TabIndex = 17
        Me.LabelMinus4.Text = "---"
        '
        'LabelPlus2
        '
        Me.LabelPlus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus2.Location = New System.Drawing.Point(117, 386)
        Me.LabelPlus2.Name = "LabelPlus2"
        Me.LabelPlus2.Size = New System.Drawing.Size(373, 17)
        Me.LabelPlus2.TabIndex = 18
        Me.LabelPlus2.Text = "---"
        '
        'LabelPlus3
        '
        Me.LabelPlus3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus3.Location = New System.Drawing.Point(117, 417)
        Me.LabelPlus3.Name = "LabelPlus3"
        Me.LabelPlus3.Size = New System.Drawing.Size(373, 17)
        Me.LabelPlus3.TabIndex = 19
        Me.LabelPlus3.Text = "---"
        '
        'LabelPlus4
        '
        Me.LabelPlus4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus4.Location = New System.Drawing.Point(117, 447)
        Me.LabelPlus4.Name = "LabelPlus4"
        Me.LabelPlus4.Size = New System.Drawing.Size(373, 17)
        Me.LabelPlus4.TabIndex = 20
        Me.LabelPlus4.Text = "---"
        '
        'LabelPlus4L
        '
        Me.LabelPlus4L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus4L.Location = New System.Drawing.Point(13, 447)
        Me.LabelPlus4L.Name = "LabelPlus4L"
        Me.LabelPlus4L.Size = New System.Drawing.Size(99, 17)
        Me.LabelPlus4L.TabIndex = 24
        Me.LabelPlus4L.Text = "---"
        Me.LabelPlus4L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelPlus3L
        '
        Me.LabelPlus3L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus3L.Location = New System.Drawing.Point(13, 417)
        Me.LabelPlus3L.Name = "LabelPlus3L"
        Me.LabelPlus3L.Size = New System.Drawing.Size(99, 17)
        Me.LabelPlus3L.TabIndex = 23
        Me.LabelPlus3L.Text = "---"
        Me.LabelPlus3L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelPlus2L
        '
        Me.LabelPlus2L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus2L.Location = New System.Drawing.Point(13, 386)
        Me.LabelPlus2L.Name = "LabelPlus2L"
        Me.LabelPlus2L.Size = New System.Drawing.Size(99, 17)
        Me.LabelPlus2L.TabIndex = 22
        Me.LabelPlus2L.Text = "---"
        Me.LabelPlus2L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelPlus1L
        '
        Me.LabelPlus1L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlus1L.Location = New System.Drawing.Point(13, 357)
        Me.LabelPlus1L.Name = "LabelPlus1L"
        Me.LabelPlus1L.Size = New System.Drawing.Size(99, 17)
        Me.LabelPlus1L.TabIndex = 21
        Me.LabelPlus1L.Text = "---"
        Me.LabelPlus1L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelMinus1L
        '
        Me.LabelMinus1L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus1L.Location = New System.Drawing.Point(13, 277)
        Me.LabelMinus1L.Name = "LabelMinus1L"
        Me.LabelMinus1L.Size = New System.Drawing.Size(99, 17)
        Me.LabelMinus1L.TabIndex = 28
        Me.LabelMinus1L.Text = "---"
        Me.LabelMinus1L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelMinus2L
        '
        Me.LabelMinus2L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus2L.Location = New System.Drawing.Point(13, 247)
        Me.LabelMinus2L.Name = "LabelMinus2L"
        Me.LabelMinus2L.Size = New System.Drawing.Size(99, 17)
        Me.LabelMinus2L.TabIndex = 27
        Me.LabelMinus2L.Text = "---"
        Me.LabelMinus2L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelMinus3L
        '
        Me.LabelMinus3L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus3L.Location = New System.Drawing.Point(13, 217)
        Me.LabelMinus3L.Name = "LabelMinus3L"
        Me.LabelMinus3L.Size = New System.Drawing.Size(99, 17)
        Me.LabelMinus3L.TabIndex = 26
        Me.LabelMinus3L.Text = "---"
        Me.LabelMinus3L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelMinus4L
        '
        Me.LabelMinus4L.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMinus4L.Location = New System.Drawing.Point(13, 187)
        Me.LabelMinus4L.Name = "LabelMinus4L"
        Me.LabelMinus4L.Size = New System.Drawing.Size(99, 17)
        Me.LabelMinus4L.TabIndex = 25
        Me.LabelMinus4L.Text = "---"
        Me.LabelMinus4L.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelCurrent
        '
        Me.LabelCurrent.BackColor = System.Drawing.Color.White
        Me.LabelCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCurrent.Location = New System.Drawing.Point(4, 315)
        Me.LabelCurrent.Name = "LabelCurrent"
        Me.LabelCurrent.Size = New System.Drawing.Size(107, 25)
        Me.LabelCurrent.TabIndex = 29
        Me.LabelCurrent.Text = "---"
        Me.LabelCurrent.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'WarningLabel
        '
        Me.WarningLabel.AutoSize = True
        Me.WarningLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarningLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningLabel.Location = New System.Drawing.Point(44, 498)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(489, 64)
        Me.WarningLabel.TabIndex = 30
        Me.WarningLabel.Text = "If you are going to allow Extrusions" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "remember to set the E location"
        Me.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HideWarningBut
        '
        Me.HideWarningBut.Location = New System.Drawing.Point(9, 543)
        Me.HideWarningBut.Margin = New System.Windows.Forms.Padding(4)
        Me.HideWarningBut.Name = "HideWarningBut"
        Me.HideWarningBut.Size = New System.Drawing.Size(57, 32)
        Me.HideWarningBut.TabIndex = 31
        Me.HideWarningBut.Text = "Hide"
        Me.HideWarningBut.UseVisualStyleBackColor = True
        '
        'InsertCmdBut
        '
        Me.InsertCmdBut.BackColor = System.Drawing.Color.LightCoral
        Me.InsertCmdBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertCmdBut.Location = New System.Drawing.Point(613, 396)
        Me.InsertCmdBut.Name = "InsertCmdBut"
        Me.InsertCmdBut.Size = New System.Drawing.Size(139, 44)
        Me.InsertCmdBut.TabIndex = 32
        Me.InsertCmdBut.Text = "Insert Line"
        Me.InsertCmdBut.UseVisualStyleBackColor = False
        '
        'RunGcodeBut
        '
        Me.RunGcodeBut.Appearance = System.Windows.Forms.Appearance.Button
        Me.RunGcodeBut.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RunGcodeBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunGcodeBut.Location = New System.Drawing.Point(613, 444)
        Me.RunGcodeBut.Name = "RunGcodeBut"
        Me.RunGcodeBut.Size = New System.Drawing.Size(139, 35)
        Me.RunGcodeBut.TabIndex = 33
        Me.RunGcodeBut.Text = "Run"
        Me.RunGcodeBut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RunGcodeBut.UseVisualStyleBackColor = False
        '
        'DebugForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 572)
        Me.Controls.Add(Me.RunGcodeBut)
        Me.Controls.Add(Me.InsertCmdBut)
        Me.Controls.Add(Me.HideWarningBut)
        Me.Controls.Add(Me.WarningLabel)
        Me.Controls.Add(Me.LabelCurrent)
        Me.Controls.Add(Me.LabelMinus1L)
        Me.Controls.Add(Me.LabelMinus2L)
        Me.Controls.Add(Me.LabelMinus3L)
        Me.Controls.Add(Me.LabelMinus4L)
        Me.Controls.Add(Me.LabelPlus4L)
        Me.Controls.Add(Me.LabelPlus3L)
        Me.Controls.Add(Me.LabelPlus2L)
        Me.Controls.Add(Me.LabelPlus1L)
        Me.Controls.Add(Me.LabelPlus4)
        Me.Controls.Add(Me.LabelPlus3)
        Me.Controls.Add(Me.LabelPlus2)
        Me.Controls.Add(Me.LabelMinus4)
        Me.Controls.Add(Me.LabelMinus3)
        Me.Controls.Add(Me.LabelMinus2)
        Me.Controls.Add(Me.CloseBut)
        Me.Controls.Add(Me.StartBut)
        Me.Controls.Add(Me.LabelMinus1)
        Me.Controls.Add(Me.LabelPlus1)
        Me.Controls.Add(Me.SkipBut)
        Me.Controls.Add(Me.DebugCurrentLineBox)
        Me.Controls.Add(Me.SendBut)
        Me.Controls.Add(Me.AirPrintChk)
        Me.Controls.Add(Me.KillExtrudeChk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DebugLineBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DebugFileNameBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "DebugForm"
        Me.Text = "Greg's Toolbox GCODE Debugger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DebugFileNameBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DebugLineBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents KillExtrudeChk As CheckBox
    Friend WithEvents AirPrintChk As CheckBox
    Friend WithEvents SendBut As Button
    Friend WithEvents DebugCurrentLineBox As TextBox
    Friend WithEvents SkipBut As Button
    Friend WithEvents LabelPlus1 As Label
    Friend WithEvents LabelMinus1 As Label
    Friend WithEvents StartBut As Button
    Friend WithEvents CloseBut As Button
    Friend WithEvents LabelMinus2 As Label
    Friend WithEvents LabelMinus3 As Label
    Friend WithEvents LabelMinus4 As Label
    Friend WithEvents LabelPlus2 As Label
    Friend WithEvents LabelPlus3 As Label
    Friend WithEvents LabelPlus4 As Label
    Friend WithEvents LabelPlus4L As Label
    Friend WithEvents LabelPlus3L As Label
    Friend WithEvents LabelPlus2L As Label
    Friend WithEvents LabelPlus1L As Label
    Friend WithEvents LabelMinus1L As Label
    Friend WithEvents LabelMinus2L As Label
    Friend WithEvents LabelMinus3L As Label
    Friend WithEvents LabelMinus4L As Label
    Friend WithEvents LabelCurrent As Label
    Friend WithEvents WarningLabel As Label
    Friend WithEvents HideWarningBut As Button
    Friend WithEvents InsertCmdBut As Button
    Friend WithEvents RunGcodeBut As CheckBox
End Class
