Public Class SearchAndReplaceForm
    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        EnderMainForm.PrResponse = False
        Me.Hide()
    End Sub

    Private Sub SearchBut_Click(sender As Object, e As EventArgs) Handles SearchBut.Click
        EnderMainForm.PrResponse = True
        Me.Hide()
    End Sub
End Class