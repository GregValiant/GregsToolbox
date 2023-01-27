<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.NameLab = New System.Windows.Forms.Label()
        Me.CompanyLab = New System.Windows.Forms.Label()
        Me.VersionLab = New System.Windows.Forms.Label()
        Me.ItsLab = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NameLab
        '
        Me.NameLab.AutoSize = True
        Me.NameLab.BackColor = System.Drawing.Color.Transparent
        Me.NameLab.Font = New System.Drawing.Font("Monotype Corsiva", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLab.ForeColor = System.Drawing.Color.White
        Me.NameLab.Location = New System.Drawing.Point(223, 130)
        Me.NameLab.Name = "NameLab"
        Me.NameLab.Size = New System.Drawing.Size(172, 34)
        Me.NameLab.TabIndex = 2
        Me.NameLab.Text = "Greg's Toolbox"
        '
        'CompanyLab
        '
        Me.CompanyLab.AutoSize = True
        Me.CompanyLab.BackColor = System.Drawing.Color.Transparent
        Me.CompanyLab.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyLab.ForeColor = System.Drawing.Color.White
        Me.CompanyLab.Location = New System.Drawing.Point(263, 137)
        Me.CompanyLab.Name = "CompanyLab"
        Me.CompanyLab.Size = New System.Drawing.Size(0, 24)
        Me.CompanyLab.TabIndex = 3
        '
        'VersionLab
        '
        Me.VersionLab.AutoSize = True
        Me.VersionLab.BackColor = System.Drawing.Color.Transparent
        Me.VersionLab.Font = New System.Drawing.Font("Monotype Corsiva", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLab.ForeColor = System.Drawing.Color.White
        Me.VersionLab.Location = New System.Drawing.Point(223, 9)
        Me.VersionLab.Name = "VersionLab"
        Me.VersionLab.Size = New System.Drawing.Size(61, 34)
        Me.VersionLab.TabIndex = 4
        Me.VersionLab.Text = "v2.0"
        '
        'ItsLab
        '
        Me.ItsLab.AutoSize = True
        Me.ItsLab.BackColor = System.Drawing.Color.Transparent
        Me.ItsLab.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItsLab.ForeColor = System.Drawing.Color.White
        Me.ItsLab.Location = New System.Drawing.Point(329, 111)
        Me.ItsLab.Name = "ItsLab"
        Me.ItsLab.Size = New System.Drawing.Size(0, 24)
        Me.ItsLab.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Monotype Corsiva", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(-8, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(422, 81)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Keep on Truckin'"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Red
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.ForeColor = System.Drawing.Color.Aquamarine
        Me.CancelBut.Location = New System.Drawing.Point(22, 137)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(119, 57)
        Me.CancelBut.TabIndex = 7
        Me.CancelBut.Text = "Cancel"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'AboutForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.EnderApp.My.Resources.Resources.mrnaturalTN
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(404, 352)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ItsLab)
        Me.Controls.Add(Me.VersionLab)
        Me.Controls.Add(Me.CompanyLab)
        Me.Controls.Add(Me.NameLab)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(422, 399)
        Me.MinimumSize = New System.Drawing.Size(422, 399)
        Me.Name = "AboutForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NameLab As Label
    Friend WithEvents CompanyLab As Label
    Friend WithEvents VersionLab As Label
    Friend WithEvents ItsLab As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CancelBut As Button
End Class
