Public Class frmMain
    Private Sub btnAddPassenger_Click(sender As Object, e As EventArgs) Handles btnAddPassenger.Click
        Dim frm As New frmAddPassenger()
        frm.ShowDialog()
    End Sub

    Private Sub btnShowPassenger_Click(sender As Object, e As EventArgs) Handles btnShowPassenger.Click
        Dim frm As New frmShowPassenger()
        frm.ShowDialog()
    End Sub

    Private Sub btnUpdatePassenger_Click(sender As Object, e As EventArgs) Handles btnUpdatePassenger.Click
        Dim frm As New frmUpdatePassenger()
        frm.ShowDialog()
    End Sub
End Class
