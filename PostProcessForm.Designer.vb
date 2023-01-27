<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PostProcessForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PostProcessForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SearchBut = New System.Windows.Forms.Button()
        Me.MicroLayerBut = New System.Windows.Forms.Button()
        Me.MirrorXBut = New System.Windows.Forms.Button()
        Me.MirrorYBut = New System.Windows.Forms.Button()
        Me.CoolingProfileBut = New System.Windows.Forms.Button()
        Me.ChangeZhopBut = New System.Windows.Forms.Button()
        Me.FIleOnFIleBut = New System.Windows.Forms.Button()
        Me.FilBigToLittleBut = New System.Windows.Forms.Button()
        Me.ChangRetractBut = New System.Windows.Forms.Button()
        Me.FilLittleToBigBut = New System.Windows.Forms.Button()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ScaleGcodeBut = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightCoral
        Me.Panel1.Controls.Add(Me.ScaleGcodeBut)
        Me.Panel1.Controls.Add(Me.SearchBut)
        Me.Panel1.Controls.Add(Me.MicroLayerBut)
        Me.Panel1.Controls.Add(Me.MirrorXBut)
        Me.Panel1.Controls.Add(Me.MirrorYBut)
        Me.Panel1.Controls.Add(Me.CoolingProfileBut)
        Me.Panel1.Controls.Add(Me.ChangeZhopBut)
        Me.Panel1.Controls.Add(Me.FIleOnFIleBut)
        Me.Panel1.Controls.Add(Me.FilBigToLittleBut)
        Me.Panel1.Controls.Add(Me.ChangRetractBut)
        Me.Panel1.Controls.Add(Me.FilLittleToBigBut)
        Me.Panel1.Location = New System.Drawing.Point(104, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 466)
        Me.Panel1.TabIndex = 41
        '
        'SearchBut
        '
        Me.SearchBut.BackColor = System.Drawing.Color.Yellow
        Me.SearchBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBut.Location = New System.Drawing.Point(26, 15)
        Me.SearchBut.Name = "SearchBut"
        Me.SearchBut.Size = New System.Drawing.Size(255, 36)
        Me.SearchBut.TabIndex = 45
        Me.SearchBut.Text = "Search and Replace"
        Me.SearchBut.UseVisualStyleBackColor = False
        '
        'MicroLayerBut
        '
        Me.MicroLayerBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MicroLayerBut.Location = New System.Drawing.Point(26, 375)
        Me.MicroLayerBut.Name = "MicroLayerBut"
        Me.MicroLayerBut.Size = New System.Drawing.Size(255, 36)
        Me.MicroLayerBut.TabIndex = 44
        Me.MicroLayerBut.Text = "Micro-Layers"
        Me.MicroLayerBut.UseVisualStyleBackColor = True
        '
        'MirrorXBut
        '
        Me.MirrorXBut.BackColor = System.Drawing.Color.LimeGreen
        Me.MirrorXBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MirrorXBut.Location = New System.Drawing.Point(26, 335)
        Me.MirrorXBut.Name = "MirrorXBut"
        Me.MirrorXBut.Size = New System.Drawing.Size(255, 36)
        Me.MirrorXBut.TabIndex = 43
        Me.MirrorXBut.Text = "Mirror about the ""Y"" axis"
        Me.MirrorXBut.UseVisualStyleBackColor = False
        '
        'MirrorYBut
        '
        Me.MirrorYBut.BackColor = System.Drawing.Color.Magenta
        Me.MirrorYBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MirrorYBut.Location = New System.Drawing.Point(26, 295)
        Me.MirrorYBut.Name = "MirrorYBut"
        Me.MirrorYBut.Size = New System.Drawing.Size(255, 36)
        Me.MirrorYBut.TabIndex = 42
        Me.MirrorYBut.Text = "Mirror about the ""X"" axis"
        Me.MirrorYBut.UseVisualStyleBackColor = False
        '
        'CoolingProfileBut
        '
        Me.CoolingProfileBut.BackColor = System.Drawing.Color.LightSkyBlue
        Me.CoolingProfileBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CoolingProfileBut.Location = New System.Drawing.Point(26, 55)
        Me.CoolingProfileBut.Name = "CoolingProfileBut"
        Me.CoolingProfileBut.Size = New System.Drawing.Size(255, 36)
        Me.CoolingProfileBut.TabIndex = 41
        Me.CoolingProfileBut.Text = "Add a Cooling Profile"
        Me.CoolingProfileBut.UseVisualStyleBackColor = False
        '
        'ChangeZhopBut
        '
        Me.ChangeZhopBut.BackColor = System.Drawing.Color.Bisque
        Me.ChangeZhopBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeZhopBut.Location = New System.Drawing.Point(26, 175)
        Me.ChangeZhopBut.Name = "ChangeZhopBut"
        Me.ChangeZhopBut.Size = New System.Drawing.Size(255, 36)
        Me.ChangeZhopBut.TabIndex = 40
        Me.ChangeZhopBut.Text = "Change Z-hops"
        Me.ChangeZhopBut.UseVisualStyleBackColor = False
        '
        'FIleOnFIleBut
        '
        Me.FIleOnFIleBut.BackColor = System.Drawing.Color.DarkGreen
        Me.FIleOnFIleBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FIleOnFIleBut.ForeColor = System.Drawing.Color.White
        Me.FIleOnFIleBut.Location = New System.Drawing.Point(26, 95)
        Me.FIleOnFIleBut.Name = "FIleOnFIleBut"
        Me.FIleOnFIleBut.Size = New System.Drawing.Size(255, 36)
        Me.FIleOnFIleBut.TabIndex = 33
        Me.FIleOnFIleBut.Text = "Combine Gode Files"
        Me.FIleOnFIleBut.UseVisualStyleBackColor = False
        '
        'FilBigToLittleBut
        '
        Me.FilBigToLittleBut.BackColor = System.Drawing.Color.LightPink
        Me.FilBigToLittleBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilBigToLittleBut.Location = New System.Drawing.Point(26, 255)
        Me.FilBigToLittleBut.Name = "FilBigToLittleBut"
        Me.FilBigToLittleBut.Size = New System.Drawing.Size(255, 36)
        Me.FilBigToLittleBut.TabIndex = 36
        Me.FilBigToLittleBut.Text = "2.85 to 1.75 Filament"
        Me.FilBigToLittleBut.UseVisualStyleBackColor = False
        '
        'ChangRetractBut
        '
        Me.ChangRetractBut.BackColor = System.Drawing.Color.Bisque
        Me.ChangRetractBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangRetractBut.Location = New System.Drawing.Point(26, 135)
        Me.ChangRetractBut.Name = "ChangRetractBut"
        Me.ChangRetractBut.Size = New System.Drawing.Size(255, 36)
        Me.ChangRetractBut.TabIndex = 39
        Me.ChangRetractBut.Text = "Change Retract Distance"
        Me.ChangRetractBut.UseVisualStyleBackColor = False
        '
        'FilLittleToBigBut
        '
        Me.FilLittleToBigBut.BackColor = System.Drawing.Color.LightPink
        Me.FilLittleToBigBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilLittleToBigBut.Location = New System.Drawing.Point(26, 215)
        Me.FilLittleToBigBut.Name = "FilLittleToBigBut"
        Me.FilLittleToBigBut.Size = New System.Drawing.Size(255, 36)
        Me.FilLittleToBigBut.TabIndex = 38
        Me.FilLittleToBigBut.Text = "1.75 to 2.85 Filament"
        Me.FilLittleToBigBut.UseVisualStyleBackColor = False
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(86, 90)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(345, 20)
        Me.Label61.TabIndex = 37
        Me.Label61.Text = "CURA G-Code Post Processing Utilities"
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Aqua
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(190, 629)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(127, 38)
        Me.CancelBut.TabIndex = 42
        Me.CancelBut.Text = "Finished"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(481, 42)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "When creating and saving the new file you cannot overwrite an existing file.  Sor" &
    "ry."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScaleGcodeBut
        '
        Me.ScaleGcodeBut.BackColor = System.Drawing.Color.Yellow
        Me.ScaleGcodeBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleGcodeBut.Location = New System.Drawing.Point(26, 415)
        Me.ScaleGcodeBut.Name = "ScaleGcodeBut"
        Me.ScaleGcodeBut.Size = New System.Drawing.Size(255, 36)
        Me.ScaleGcodeBut.TabIndex = 46
        Me.ScaleGcodeBut.Text = "Scale a Gcode File"
        Me.ScaleGcodeBut.UseVisualStyleBackColor = False
        '
        'PostProcessForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCoral
        Me.ClientSize = New System.Drawing.Size(505, 679)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label61)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PostProcessForm"
        Me.Text = "Post Processing Utilities"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents CoolingProfileBut As Button
    Friend WithEvents ChangeZhopBut As Button
    Friend WithEvents Label61 As Label
    Friend WithEvents FIleOnFIleBut As Button
    Friend WithEvents FilBigToLittleBut As Button
    Friend WithEvents ChangRetractBut As Button
    Friend WithEvents FilLittleToBigBut As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents MirrorYBut As Button
    Friend WithEvents MirrorXBut As Button
    Friend WithEvents MicroLayerBut As Button
    Friend WithEvents SearchBut As Button
    Friend WithEvents ScaleGcodeBut As Button
End Class
