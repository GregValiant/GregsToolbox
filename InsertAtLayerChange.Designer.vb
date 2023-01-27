<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InsertAtLayerChange
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LayerStartBox = New System.Windows.Forms.TextBox()
        Me.LayerOtherOpt = New System.Windows.Forms.RadioButton()
        Me.Layer0Opt = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.L100opt = New System.Windows.Forms.RadioButton()
        Me.L50opt = New System.Windows.Forms.RadioButton()
        Me.L25opt = New System.Windows.Forms.RadioButton()
        Me.L10opt = New System.Windows.Forms.RadioButton()
        Me.L5opt = New System.Windows.Forms.RadioButton()
        Me.L3opt = New System.Windows.Forms.RadioButton()
        Me.L2opt = New System.Windows.Forms.RadioButton()
        Me.L1opt = New System.Windows.Forms.RadioButton()
        Me.GoBut = New System.Windows.Forms.Button()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.CommandBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.PeachPuff
        Me.GroupBox1.Controls.Add(Me.LayerStartBox)
        Me.GroupBox1.Controls.Add(Me.LayerOtherOpt)
        Me.GroupBox1.Controls.Add(Me.Layer0Opt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(27, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(129, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Start Layer"
        '
        'LayerStartBox
        '
        Me.LayerStartBox.Enabled = False
        Me.LayerStartBox.Location = New System.Drawing.Point(18, 80)
        Me.LayerStartBox.Name = "LayerStartBox"
        Me.LayerStartBox.Size = New System.Drawing.Size(77, 24)
        Me.LayerStartBox.TabIndex = 2
        Me.LayerStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LayerOtherOpt
        '
        Me.LayerOtherOpt.AutoSize = True
        Me.LayerOtherOpt.Location = New System.Drawing.Point(11, 49)
        Me.LayerOtherOpt.Name = "LayerOtherOpt"
        Me.LayerOtherOpt.Size = New System.Drawing.Size(71, 22)
        Me.LayerOtherOpt.TabIndex = 1
        Me.LayerOtherOpt.Text = "Other"
        Me.LayerOtherOpt.UseVisualStyleBackColor = True
        '
        'Layer0Opt
        '
        Me.Layer0Opt.AutoSize = True
        Me.Layer0Opt.Checked = True
        Me.Layer0Opt.Location = New System.Drawing.Point(11, 22)
        Me.Layer0Opt.Name = "Layer0Opt"
        Me.Layer0Opt.Size = New System.Drawing.Size(84, 22)
        Me.Layer0Opt.TabIndex = 0
        Me.Layer0Opt.TabStop = True
        Me.Layer0Opt.Text = "Layer:0"
        Me.Layer0Opt.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.PeachPuff
        Me.GroupBox2.Controls.Add(Me.L100opt)
        Me.GroupBox2.Controls.Add(Me.L50opt)
        Me.GroupBox2.Controls.Add(Me.L25opt)
        Me.GroupBox2.Controls.Add(Me.L10opt)
        Me.GroupBox2.Controls.Add(Me.L5opt)
        Me.GroupBox2.Controls.Add(Me.L3opt)
        Me.GroupBox2.Controls.Add(Me.L2opt)
        Me.GroupBox2.Controls.Add(Me.L1opt)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(183, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 246)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Every__Layers"
        '
        'L100opt
        '
        Me.L100opt.AutoSize = True
        Me.L100opt.Location = New System.Drawing.Point(11, 210)
        Me.L100opt.Name = "L100opt"
        Me.L100opt.Size = New System.Drawing.Size(70, 22)
        Me.L100opt.TabIndex = 7
        Me.L100opt.Text = "100th"
        Me.L100opt.UseVisualStyleBackColor = True
        '
        'L50opt
        '
        Me.L50opt.AutoSize = True
        Me.L50opt.Location = New System.Drawing.Point(11, 183)
        Me.L50opt.Name = "L50opt"
        Me.L50opt.Size = New System.Drawing.Size(61, 22)
        Me.L50opt.TabIndex = 6
        Me.L50opt.Text = "50th"
        Me.L50opt.UseVisualStyleBackColor = True
        '
        'L25opt
        '
        Me.L25opt.AutoSize = True
        Me.L25opt.Location = New System.Drawing.Point(11, 159)
        Me.L25opt.Name = "L25opt"
        Me.L25opt.Size = New System.Drawing.Size(61, 22)
        Me.L25opt.TabIndex = 5
        Me.L25opt.Text = "25th"
        Me.L25opt.UseVisualStyleBackColor = True
        '
        'L10opt
        '
        Me.L10opt.AutoSize = True
        Me.L10opt.Location = New System.Drawing.Point(11, 132)
        Me.L10opt.Name = "L10opt"
        Me.L10opt.Size = New System.Drawing.Size(61, 22)
        Me.L10opt.TabIndex = 4
        Me.L10opt.Text = "10th"
        Me.L10opt.UseVisualStyleBackColor = True
        '
        'L5opt
        '
        Me.L5opt.AutoSize = True
        Me.L5opt.Location = New System.Drawing.Point(11, 104)
        Me.L5opt.Name = "L5opt"
        Me.L5opt.Size = New System.Drawing.Size(52, 22)
        Me.L5opt.TabIndex = 3
        Me.L5opt.Text = "5th"
        Me.L5opt.UseVisualStyleBackColor = True
        '
        'L3opt
        '
        Me.L3opt.AutoSize = True
        Me.L3opt.Location = New System.Drawing.Point(11, 77)
        Me.L3opt.Name = "L3opt"
        Me.L3opt.Size = New System.Drawing.Size(53, 22)
        Me.L3opt.TabIndex = 2
        Me.L3opt.Text = "3rd"
        Me.L3opt.UseVisualStyleBackColor = True
        '
        'L2opt
        '
        Me.L2opt.AutoSize = True
        Me.L2opt.Location = New System.Drawing.Point(11, 49)
        Me.L2opt.Name = "L2opt"
        Me.L2opt.Size = New System.Drawing.Size(56, 22)
        Me.L2opt.TabIndex = 1
        Me.L2opt.Text = "2nd"
        Me.L2opt.UseVisualStyleBackColor = True
        '
        'L1opt
        '
        Me.L1opt.AutoSize = True
        Me.L1opt.Checked = True
        Me.L1opt.Location = New System.Drawing.Point(11, 22)
        Me.L1opt.Name = "L1opt"
        Me.L1opt.Size = New System.Drawing.Size(38, 22)
        Me.L1opt.TabIndex = 0
        Me.L1opt.TabStop = True
        Me.L1opt.Text = "1"
        Me.L1opt.UseVisualStyleBackColor = True
        '
        'GoBut
        '
        Me.GoBut.BackColor = System.Drawing.Color.LightGreen
        Me.GoBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoBut.Location = New System.Drawing.Point(35, 292)
        Me.GoBut.Name = "GoBut"
        Me.GoBut.Size = New System.Drawing.Size(112, 45)
        Me.GoBut.TabIndex = 2
        Me.GoBut.Text = "Start"
        Me.GoBut.UseVisualStyleBackColor = False
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Cornsilk
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(183, 292)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(112, 45)
        Me.CancelBut.TabIndex = 3
        Me.CancelBut.Text = "Cancel"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'CommandBox
        '
        Me.CommandBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CommandBox.Location = New System.Drawing.Point(349, 54)
        Me.CommandBox.Multiline = True
        Me.CommandBox.Name = "CommandBox"
        Me.CommandBox.Size = New System.Drawing.Size(221, 283)
        Me.CommandBox.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(365, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Commands to Insert"
        '
        'InsertAtLayerChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 353)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CommandBox)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.GoBut)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "InsertAtLayerChange"
        Me.Text = "Insert At Layer Change"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LayerStartBox As TextBox
    Friend WithEvents LayerOtherOpt As RadioButton
    Friend WithEvents Layer0Opt As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents L100opt As RadioButton
    Friend WithEvents L50opt As RadioButton
    Friend WithEvents L25opt As RadioButton
    Friend WithEvents L10opt As RadioButton
    Friend WithEvents L5opt As RadioButton
    Friend WithEvents L3opt As RadioButton
    Friend WithEvents L2opt As RadioButton
    Friend WithEvents L1opt As RadioButton
    Friend WithEvents GoBut As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents CommandBox As TextBox
    Friend WithEvents Label1 As Label
End Class
