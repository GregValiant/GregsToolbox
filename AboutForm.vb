Public Class AboutForm

    Private Sub AboutForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Hide()
    End Sub

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Me
            .NameLab.Text = Application.ProductName
            .VersionLab.Text = "v" & Application.ProductVersion
        End With
    End Sub

    Private Sub CancelBut_MouseEnter(sender As Object, e As EventArgs) Handles CancelBut.MouseEnter
        With Me.CancelBut
            If .Location.X = 22 And .Location.Y = 137 Then
                .Location = New Point(267, 51)
            ElseIf .Location.X = 267 And .Location.Y = 51 Then
                .Location = New Point(22, 221)
            ElseIf .Location.X = 22 And .Location.Y = 221 Then
                .Location = New Point(273, 197)
            ElseIf .Location.X = 273 And .Location.Y = 197 Then
                .Location = New Point(22, 137)
                '267, 51
                '273, 197
            End If
        End With
    End Sub
End Class