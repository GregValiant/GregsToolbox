<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchAndReplaceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchAndReplaceForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchStringBox = New System.Windows.Forms.TextBox()
        Me.ReplaceStringBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AnyMatchOpt = New System.Windows.Forms.RadioButton()
        Me.ExactMatchOpt = New System.Windows.Forms.RadioButton()
        Me.SearchBut = New System.Windows.Forms.Button()
        Me.CancelBut = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LeaveSearchChk = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search String:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 54)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Replace String:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Multi-Line is" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "acceptable)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SearchStringBox
        '
        Me.SearchStringBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchStringBox.Location = New System.Drawing.Point(159, 66)
        Me.SearchStringBox.Name = "SearchStringBox"
        Me.SearchStringBox.Size = New System.Drawing.Size(334, 24)
        Me.SearchStringBox.TabIndex = 1
        '
        'ReplaceStringBox
        '
        Me.ReplaceStringBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReplaceStringBox.Location = New System.Drawing.Point(159, 184)
        Me.ReplaceStringBox.Multiline = True
        Me.ReplaceStringBox.Name = "ReplaceStringBox"
        Me.ReplaceStringBox.Size = New System.Drawing.Size(334, 191)
        Me.ReplaceStringBox.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AnyMatchOpt)
        Me.GroupBox1.Controls.Add(Me.ExactMatchOpt)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(159, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 46)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'AnyMatchOpt
        '
        Me.AnyMatchOpt.AutoSize = True
        Me.AnyMatchOpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnyMatchOpt.Location = New System.Drawing.Point(196, 16)
        Me.AnyMatchOpt.Name = "AnyMatchOpt"
        Me.AnyMatchOpt.Size = New System.Drawing.Size(107, 22)
        Me.AnyMatchOpt.TabIndex = 3
        Me.AnyMatchOpt.Text = "Any Match"
        Me.AnyMatchOpt.UseVisualStyleBackColor = True
        '
        'ExactMatchOpt
        '
        Me.ExactMatchOpt.AutoSize = True
        Me.ExactMatchOpt.Checked = True
        Me.ExactMatchOpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExactMatchOpt.Location = New System.Drawing.Point(31, 16)
        Me.ExactMatchOpt.Name = "ExactMatchOpt"
        Me.ExactMatchOpt.Size = New System.Drawing.Size(122, 22)
        Me.ExactMatchOpt.TabIndex = 2
        Me.ExactMatchOpt.TabStop = True
        Me.ExactMatchOpt.Text = "Exact Match"
        Me.ExactMatchOpt.UseVisualStyleBackColor = True
        '
        'SearchBut
        '
        Me.SearchBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBut.Location = New System.Drawing.Point(88, 438)
        Me.SearchBut.Name = "SearchBut"
        Me.SearchBut.Size = New System.Drawing.Size(147, 44)
        Me.SearchBut.TabIndex = 5
        Me.SearchBut.Text = "Replace"
        Me.SearchBut.UseVisualStyleBackColor = True
        '
        'CancelBut
        '
        Me.CancelBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBut.Location = New System.Drawing.Point(355, 438)
        Me.CancelBut.Name = "CancelBut"
        Me.CancelBut.Size = New System.Drawing.Size(147, 44)
        Me.CancelBut.TabIndex = 6
        Me.CancelBut.Text = "Cancel"
        Me.CancelBut.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(156, 383)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(341, 36)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "The ""Replace String"" should always end with" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a semi-colon.  Ex:  M106 S0 ;"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(169, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(282, 36)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "You must match the Case of the text" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(UPPER, lower, or MiXed)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LeaveSearchChk
        '
        Me.LeaveSearchChk.AutoSize = True
        Me.LeaveSearchChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeaveSearchChk.Location = New System.Drawing.Point(219, 153)
        Me.LeaveSearchChk.Name = "LeaveSearchChk"
        Me.LeaveSearchChk.Size = New System.Drawing.Size(209, 22)
        Me.LeaveSearchChk.TabIndex = 9
        Me.LeaveSearchChk.Text = "Leave the Search String"
        Me.LeaveSearchChk.UseVisualStyleBackColor = True
        '
        'SearchAndReplaceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 513)
        Me.Controls.Add(Me.LeaveSearchChk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CancelBut)
        Me.Controls.Add(Me.SearchBut)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReplaceStringBox)
        Me.Controls.Add(Me.SearchStringBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SearchAndReplaceForm"
        Me.Text = "Search And Replace"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SearchStringBox As TextBox
    Friend WithEvents ReplaceStringBox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents AnyMatchOpt As RadioButton
    Friend WithEvents ExactMatchOpt As RadioButton
    Friend WithEvents SearchBut As Button
    Friend WithEvents CancelBut As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LeaveSearchChk As CheckBox
End Class
