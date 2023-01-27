Public Class PrintersToPortNames
    Public Function GetProfileName() As String
        Dim FileResponse As DialogResult
        Me.LinkProfileDialog.Title = "Link a Printer Profile to the Name and Port"
        Me.LinkProfileDialog.Filter = "Profile Files|*.pro"
        Me.LinkProfileDialog.FilterIndex = 1
        Me.LinkProfileDialog.DefaultExt = "pro"
        Me.LinkProfileDialog.FileName = "*.pro"
        FileResponse = Me.LinkProfileDialog.ShowDialog()
        If FileResponse = 2 Then
            GetProfileName = ""
            Exit Function
        End If
        GetProfileName = Me.LinkProfileDialog.FileName
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles FinishBut.Click
        EnderMainForm.PrResponse = True
        My.Settings.Save()
        Me.Hide()
    End Sub

    Private Sub Pr1LinkBut_Click(sender As Object, e As EventArgs) Handles Pr1LinkBut.Click
        Me.Pr1Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr2LinkBut_Click(sender As Object, e As EventArgs) Handles Pr2LinkBut.Click
        Me.Pr2Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr3LinkBut_Click(sender As Object, e As EventArgs) Handles Pr3LinkBut.Click
        Me.Pr3Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr4LinkBut_Click(sender As Object, e As EventArgs) Handles Pr4LinkBut.Click
        Me.Pr4Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr5LinkBut_Click(sender As Object, e As EventArgs) Handles Pr5LinkBut.Click
        Me.Pr5Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr6LinkBut_Click(sender As Object, e As EventArgs) Handles Pr6LinkBut.Click
        Me.Pr6Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr7LinkBut_Click(sender As Object, e As EventArgs) Handles Pr7LinkBut.Click
        Me.Pr7Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr8LinkBut_Click(sender As Object, e As EventArgs) Handles Pr8LinkBut.Click
        Me.Pr8Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr9LinkBut_Click(sender As Object, e As EventArgs) Handles Pr9LinkBut.Click
        Me.Pr9Profile.Text = GetProfileName()
    End Sub

    Private Sub Pr10LinkBut_Click(sender As Object, e As EventArgs) Handles Pr10LinkBut.Click
        Me.Pr10Profile.Text = GetProfileName()
    End Sub

    Private Sub CancelBut_Click(sender As Object, e As EventArgs) Handles CancelBut.Click
        EnderMainForm.PrResponse = False
        My.Settings.Reload()
        Me.Hide()
    End Sub

    Private Sub ClearBut_Click(sender As Object, e As EventArgs) Handles ClearBut.Click
        Try
            For Each TextBoxCntrol As Control In Me.Controls
                If TypeOf TextBoxCntrol Is TextBox Then
                    TextBoxCntrol.Text = ""
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UnlinkBut_Click(sender As Object, e As EventArgs) Handles UnlinkBut.Click
        EnderMainForm.PrinterNameBox.Items.Clear()
        EnderMainForm.PrinterNameBox.ResetText()
        EnderMainForm.AvailablePortsBox.Items.Clear()
        EnderMainForm.AvailablePortsBox.ResetText()
        RemoveHandler EnderMainForm.ComOpenBut.CheckedChanged, AddressOf EnderMainForm.ComOpenBut_CheckedChanged
        EnderMainForm.ComOpenBut.Checked = False
        EnderMainForm.ComOpenBut.Text = "Com Port Is Closed"
        EnderMainForm.ComOpenBut.BackColor = Color.Red
        EnderMainForm.ComOpenLab.Text = "Com Port Closed"
        EnderMainForm.ComOpenLab.BackColor = Color.Red
        AddHandler EnderMainForm.ComOpenBut.CheckedChanged, AddressOf EnderMainForm.ComOpenBut_CheckedChanged
        Me.Hide()
        Try
            EnderMainForm.Vcomm.Close()
        Catch ex As Exception
        End Try
        EnderMainForm.AutoLinkBut.Checked = False
        My.Settings.Reload()
        My.Settings.AutoLink = False
    End Sub
End Class
