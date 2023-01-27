Public Class TimeToPauseFudgeForm
    Private Sub EnterBut_Click(sender As Object, e As EventArgs) Handles EnterBut.Click
        Me.Hide()
        Me.DialogResult = CType(1, DialogResult)
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        Me.Hide()
        Me.DialogResult = CType(2, DialogResult)
    End Sub

    Private Sub FudgeBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles FudgeBar1.Scroll
        Me.Label1.Text = CStr(Me.FudgeBar1.Value & "%")
    End Sub

    Private Sub CalculateBut_Click(sender As Object, e As EventArgs) Handles CalculateBut.Click
        On Error Resume Next
        Dim CuraTime As Long
        Dim ActualTime As Long
        Dim FudgeFactor As Single
        With Me
            If .CuraHrBox.Text = "" Or .CuraMinBox.Text = "" Or .ActHrBox.Text = "" Or .ActMinBox.Text = "" Then
                MsgBox("You must have numbers entered into all 4 boxes to continue", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            If Val(.CuraMinBox.Text) > 59 Or Val(.CuraMinBox.Text) < 0 Or Val(.ActMinBox.Text) > 59 Or Val(.ActMinBox.Text) < 0 Then
                MsgBox("There is an error in the ""Minutes"" box.", vbOKOnly, "Greg's Toolbox")
                Exit Sub
            End If
            CuraTime = CLng((Val(.CuraHrBox.Text) * 60 + Val(.CuraMinBox.Text)))
            ActualTime = CLng((Val(.ActHrBox.Text) * 60 + Val(.ActMinBox.Text)))
            FudgeFactor = CSng((ActualTime / CuraTime) * 100)
            .FudgeBar1.Value = CInt(FudgeFactor)
            .Label1.Text = .FudgeBar1.Value & "%"
        End With
    End Sub
End Class