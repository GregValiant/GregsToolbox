Public Class CustomScriptDialog
    Private Sub SaveBut_Click(sender As Object, e As EventArgs) Handles SaveBut.Click
        EnderMainForm.ScriptResponse = "Save"
        Me.Hide()
    End Sub

    Private Sub ForgetBut_Click(sender As Object, e As EventArgs) Handles ForgetBut.Click
        EnderMainForm.ScriptResponse = "Forget"
        Me.Hide()
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        EnderMainForm.ScriptResponse = "Cancel"
        Me.Hide()
    End Sub


    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        TextBox1.Text = UCase(TextBox1.Text)
    End Sub
End Class