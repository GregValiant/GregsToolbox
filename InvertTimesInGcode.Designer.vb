<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvertTimesInGcode
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
        Me.SelectGcodeBut = New System.Windows.Forms.Button()
        Me.GcodeFileNameLabel = New System.Windows.Forms.Label()
        Me.SaveAsBut = New System.Windows.Forms.Button()
        Me.SaveAsFileNameLabel = New System.Windows.Forms.Label()
        Me.WriteNewFileBut = New System.Windows.Forms.Button()
        Me.OpenNewFileBut = New System.Windows.Forms.Button()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'SelectGcodeBut
        '
        Me.SelectGcodeBut.BackColor = System.Drawing.Color.LightGreen
        Me.SelectGcodeBut.Location = New System.Drawing.Point(29, 28)
        Me.SelectGcodeBut.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SelectGcodeBut.Name = "SelectGcodeBut"
        Me.SelectGcodeBut.Size = New System.Drawing.Size(359, 55)
        Me.SelectGcodeBut.TabIndex = 0
        Me.SelectGcodeBut.Text = "Select a Gcode File to Alter"
        Me.SelectGcodeBut.UseVisualStyleBackColor = False
        '
        'GcodeFileNameLabel
        '
        Me.GcodeFileNameLabel.AutoSize = True
        Me.GcodeFileNameLabel.Location = New System.Drawing.Point(31, 95)
        Me.GcodeFileNameLabel.Name = "GcodeFileNameLabel"
        Me.GcodeFileNameLabel.Size = New System.Drawing.Size(260, 20)
        Me.GcodeFileNameLabel.TabIndex = 1
        Me.GcodeFileNameLabel.Text = "{Selected GCODE File Name}"
        '
        'SaveAsBut
        '
        Me.SaveAsBut.BackColor = System.Drawing.Color.LightGreen
        Me.SaveAsBut.Location = New System.Drawing.Point(29, 160)
        Me.SaveAsBut.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveAsBut.Name = "SaveAsBut"
        Me.SaveAsBut.Size = New System.Drawing.Size(359, 55)
        Me.SaveAsBut.TabIndex = 2
        Me.SaveAsBut.Text = "SaveAS (New File Name)"
        Me.SaveAsBut.UseVisualStyleBackColor = False
        '
        'SaveAsFileNameLabel
        '
        Me.SaveAsFileNameLabel.AutoSize = True
        Me.SaveAsFileNameLabel.Location = New System.Drawing.Point(31, 232)
        Me.SaveAsFileNameLabel.Name = "SaveAsFileNameLabel"
        Me.SaveAsFileNameLabel.Size = New System.Drawing.Size(150, 20)
        Me.SaveAsFileNameLabel.TabIndex = 3
        Me.SaveAsFileNameLabel.Text = "{New File Name}"
        '
        'WriteNewFileBut
        '
        Me.WriteNewFileBut.BackColor = System.Drawing.Color.SkyBlue
        Me.WriteNewFileBut.Location = New System.Drawing.Point(29, 285)
        Me.WriteNewFileBut.Margin = New System.Windows.Forms.Padding(4)
        Me.WriteNewFileBut.Name = "WriteNewFileBut"
        Me.WriteNewFileBut.Size = New System.Drawing.Size(359, 55)
        Me.WriteNewFileBut.TabIndex = 4
        Me.WriteNewFileBut.Text = "Write the New File"
        Me.WriteNewFileBut.UseVisualStyleBackColor = False
        '
        'OpenNewFileBut
        '
        Me.OpenNewFileBut.BackColor = System.Drawing.Color.MediumPurple
        Me.OpenNewFileBut.Location = New System.Drawing.Point(29, 382)
        Me.OpenNewFileBut.Margin = New System.Windows.Forms.Padding(4)
        Me.OpenNewFileBut.Name = "OpenNewFileBut"
        Me.OpenNewFileBut.Size = New System.Drawing.Size(359, 55)
        Me.OpenNewFileBut.TabIndex = 5
        Me.OpenNewFileBut.Text = "Open New File in Notepad"
        Me.OpenNewFileBut.UseVisualStyleBackColor = False
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Khaki
        Me.CancelBut.Location = New System.Drawing.Point(29, 476)
        Me.CancelBut.Margin = New System.Windows.Forms.Padding(4)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(359, 55)
        Me.CancelBut.TabIndex = 6
        Me.CancelBut.Text = "All Done"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.Location = New System.Drawing.Point(69, 347)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(281, 16)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 128
        Me.ProgressBar1.Visible = False
        '
        'InvertTimesInGcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 562)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.OpenNewFileBut)
        Me.Controls.Add(Me.WriteNewFileBut)
        Me.Controls.Add(Me.SaveAsFileNameLabel)
        Me.Controls.Add(Me.SaveAsBut)
        Me.Controls.Add(Me.GcodeFileNameLabel)
        Me.Controls.Add(Me.SelectGcodeBut)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "InvertTimesInGcode"
        Me.Text = "Add a Countdown"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelectGcodeBut As Button
    Friend WithEvents GcodeFileNameLabel As Label
    Friend WithEvents SaveAsBut As Button
    Friend WithEvents SaveAsFileNameLabel As Label
    Friend WithEvents WriteNewFileBut As Button
    Friend WithEvents OpenNewFileBut As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
