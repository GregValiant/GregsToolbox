<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeToPauseFudgeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeToPauseFudgeForm))
        Me.FudgeBar1 = New System.Windows.Forms.HScrollBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EnterBut = New System.Windows.Forms.Button()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CuraHrBox = New System.Windows.Forms.TextBox()
        Me.CuraMinBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ActHrBox = New System.Windows.Forms.TextBox()
        Me.ActMinBox = New System.Windows.Forms.TextBox()
        Me.CalculateBut = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FudgeBar1
        '
        Me.FudgeBar1.LargeChange = 5
        Me.FudgeBar1.Location = New System.Drawing.Point(100, 414)
        Me.FudgeBar1.Maximum = 200
        Me.FudgeBar1.Name = "FudgeBar1"
        Me.FudgeBar1.Size = New System.Drawing.Size(350, 38)
        Me.FudgeBar1.TabIndex = 0
        Me.FudgeBar1.TabStop = True
        Me.FudgeBar1.Value = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(231, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "100%"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnterBut
        '
        Me.EnterBut.BackColor = System.Drawing.Color.LightGreen
        Me.EnterBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnterBut.Location = New System.Drawing.Point(98, 484)
        Me.EnterBut.Name = "EnterBut"
        Me.EnterBut.Size = New System.Drawing.Size(140, 49)
        Me.EnterBut.TabIndex = 2
        Me.EnterBut.Text = "Continue"
        Me.EnterBut.UseVisualStyleBackColor = False
        '
        'CancelBut
        '
        Me.CancelBut.BackColor = System.Drawing.Color.Khaki
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(310, 484)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(140, 49)
        Me.CancelBut.TabIndex = 3
        Me.CancelBut.Text = "Cancel"
        Me.CancelBut.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(503, 149)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 392)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 69)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(476, 392)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 69)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "+"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CuraHrBox
        '
        Me.CuraHrBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CuraHrBox.Location = New System.Drawing.Point(22, 97)
        Me.CuraHrBox.Name = "CuraHrBox"
        Me.CuraHrBox.Size = New System.Drawing.Size(55, 27)
        Me.CuraHrBox.TabIndex = 7
        Me.CuraHrBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CuraMinBox
        '
        Me.CuraMinBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CuraMinBox.Location = New System.Drawing.Point(103, 97)
        Me.CuraMinBox.Name = "CuraMinBox"
        Me.CuraMinBox.Size = New System.Drawing.Size(55, 27)
        Me.CuraMinBox.TabIndex = 8
        Me.CuraMinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hr"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(110, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Min"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(80, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 32)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = ":"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Cura Estimate"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox1.Controls.Add(Me.ActHrBox)
        Me.GroupBox1.Controls.Add(Me.ActMinBox)
        Me.GroupBox1.Controls.Add(Me.CuraHrBox)
        Me.GroupBox1.Controls.Add(Me.CuraMinBox)
        Me.GroupBox1.Controls.Add(Me.CalculateBut)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(63, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 178)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Calculate"
        '
        'ActHrBox
        '
        Me.ActHrBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActHrBox.Location = New System.Drawing.Point(247, 97)
        Me.ActHrBox.Name = "ActHrBox"
        Me.ActHrBox.Size = New System.Drawing.Size(55, 27)
        Me.ActHrBox.TabIndex = 13
        Me.ActHrBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ActMinBox
        '
        Me.ActMinBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActMinBox.Location = New System.Drawing.Point(328, 97)
        Me.ActMinBox.Name = "ActMinBox"
        Me.ActMinBox.Size = New System.Drawing.Size(55, 27)
        Me.ActMinBox.TabIndex = 14
        Me.ActMinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CalculateBut
        '
        Me.CalculateBut.BackColor = System.Drawing.Color.SkyBlue
        Me.CalculateBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalculateBut.Location = New System.Drawing.Point(136, 137)
        Me.CalculateBut.Name = "CalculateBut"
        Me.CalculateBut.Size = New System.Drawing.Size(151, 35)
        Me.CalculateBut.TabIndex = 19
        Me.CalculateBut.Text = "Calculate"
        Me.CalculateBut.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(233, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Actual Print Time"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(335, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Min"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(258, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 20)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Hr"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(304, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 32)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = ":"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimeToPauseFudgeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.ClientSize = New System.Drawing.Size(550, 561)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.EnterBut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FudgeBar1)
        Me.Name = "TimeToPauseFudgeForm"
        Me.Text = "Time To Pause Fudge Factor Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FudgeBar1 As HScrollBar
    Friend WithEvents Label1 As Label
    Friend WithEvents EnterBut As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CuraHrBox As TextBox
    Friend WithEvents CuraMinBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CalculateBut As Button
    Friend WithEvents ActHrBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ActMinBox As TextBox
    Friend WithEvents Label12 As Label
End Class
