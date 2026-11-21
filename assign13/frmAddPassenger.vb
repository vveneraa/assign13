Imports System.Data.SQLite
Imports System.IO
Public Class frmAddPassenger
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmAddPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim databasePath As String =
    Path.GetFullPath(Path.Combine(Application.StartupPath,
                                 "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
    "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)

            conn.Open()

            Dim strQuery As String =
        "SELECT intStateID, strState FROM TStates"

            Using command As New SQLiteCommand(strQuery, conn)

                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()

                adapter.Fill(dataTable)

                cboStates.DataSource = dataTable
                cboStates.DisplayMember = "strState"
                cboStates.ValueMember = "intStateID"
            End Using
        End Using

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtFirstName.Text.Trim() = "" OrElse
   txtLastName.Text.Trim() = "" OrElse
   txtAddress.Text.Trim() = "" OrElse
   txtCity.Text.Trim() = "" OrElse
   txtZip.Text.Trim() = "" OrElse
   txtPhoneNumber.Text.Trim() = "" OrElse
   txtEmail.Text.Trim() = "" OrElse
   cboStates.SelectedValue Is Nothing Then

            MessageBox.Show("Please fill in all fields.")
            Exit Sub

        End If

        Dim databasePath As String =
    Path.GetFullPath(Path.Combine(Application.StartupPath,
                                 "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
    "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)

            conn.Open()

            Dim strQuery As String =
        "INSERT INTO TPassengers " &
        "(strFirstName, strLastName, strAddress, strCity, " &
        "intStateID, strZip, strPhoneNumber, strEmail) " &
        "VALUES (@FirstName, @LastName, @Address, @City, " &
        "@StateID, @Zip, @Phone, @Email)"

            Using command As New SQLiteCommand(strQuery, conn)

                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                command.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                command.Parameters.AddWithValue("@StateID", cboStates.SelectedValue)
                command.Parameters.AddWithValue("@Zip", txtZip.Text.Trim())
                command.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text.Trim())
                command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())

                command.ExecuteNonQuery()

            End Using
        End Using

        MessageBox.Show("Passenger added successfully!")
        Me.Close()
    End Sub
End Class