<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomScriptDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomScriptDialog))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SaveBut = New System.Windows.Forms.Button()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.ForgetBut = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(577, 143)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(49, 162)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(573, 288)
        Me.TextBox1.TabIndex = 1
        '
        'SaveBut
        '
        Me.SaveBut.BackColor = System.Drawing.Color.PaleGreen
        Me.SaveBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBut.Location = New System.Drawing.Point(95, 494)
        Me.SaveBut.Name = "SaveBut"
        Me.SaveBut.Size = New System.Drawing.Size(137, 42)
        Me.SaveBut.TabIndex = 2
        Me.SaveBut.Text = "Save Script"
        Me.SaveBut.UseVisualStyleBackColor = False
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Khaki
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(418, 515)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(147, 41)
        Me.CancelBut.TabIndex = 3
        Me.CancelBut.Text = "Cancel"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'ForgetBut
        '
        Me.ForgetBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForgetBut.Location = New System.Drawing.Point(97, 551)
        Me.ForgetBut.Name = "ForgetBut"
        Me.ForgetBut.Size = New System.Drawing.Size(134, 40)
        Me.ForgetBut.TabIndex = 4
        Me.ForgetBut.Text = "Forget Script"
        Me.ForgetBut.UseVisualStyleBackColor = True
        '
        'CustomScriptDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 614)
        Me.Controls.Add(Me.ForgetBut)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.SaveBut)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CustomScriptDialog"
        Me.Text = "Custom Script"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents SaveBut As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents ForgetBut As Button
End Class
