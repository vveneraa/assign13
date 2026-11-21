Imports System.Data.SQLite
Imports System.IO
Public Class frmUpdatePassenger
    Private Sub frmUpdatePassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim databasePath As String =
    Path.GetFullPath(Path.Combine(Application.StartupPath,
                                 "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
    "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)

            conn.Open()

            'load states
            Dim stateQuery As String =
        "SELECT intStateID, strState FROM TStates"

            Dim stateAdapter As New SQLiteDataAdapter(stateQuery, conn)
            Dim stateTable As New DataTable()

            stateAdapter.Fill(stateTable)

            cboStates.DataSource = stateTable
            cboStates.DisplayMember = "strState"
            cboStates.ValueMember = "intStateID"

            'load passengers
            Dim passengerQuery As String =
        "SELECT intPassengerID, " &
        "strFirstName || ' ' || strLastName AS FullName " &
        "FROM TPassengers"

            Dim passengerAdapter As New SQLiteDataAdapter(passengerQuery, conn)
            Dim passengerTable As New DataTable()

            passengerAdapter.Fill(passengerTable)

            cboPassengers.DisplayMember = "FullName"
            cboPassengers.ValueMember = "intPassengerID"
            cboPassengers.DataSource = passengerTable
        End Using
    End Sub

    Private Sub cboPassengers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPassengers.SelectedIndexChanged
        If TypeOf cboPassengers.SelectedValue Is DataRowView OrElse
   cboPassengers.SelectedValue Is Nothing Then
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
        "SELECT * FROM TPassengers WHERE intPassengerID = @ID"

            Using command As New SQLiteCommand(strQuery, conn)

                command.Parameters.AddWithValue("@ID", cboPassengers.SelectedValue)

                Using reader As SQLiteDataReader = command.ExecuteReader()

                    If reader.Read() Then

                        txtFirstName.Text = reader("strFirstName").ToString()
                        txtLastName.Text = reader("strLastName").ToString()
                        txtAddress.Text = reader("strAddress").ToString()
                        txtCity.Text = reader("strCity").ToString()
                        cboStates.SelectedValue = reader("intStateID")
                        txtZip.Text = reader("strZip").ToString()
                        txtPhoneNumber.Text = reader("strPhoneNumber").ToString()
                        txtEmail.Text = reader("strEmail").ToString()

                    End If
                End Using
            End Using
        End Using

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtFirstName.Text.Trim() = "" OrElse
   txtLastName.Text.Trim() = "" OrElse
   txtAddress.Text.Trim() = "" OrElse
   txtCity.Text.Trim() = "" OrElse
   txtZip.Text.Trim() = "" OrElse
   txtPhoneNumber.Text.Trim() = "" OrElse
   txtEmail.Text.Trim() = "" OrElse
   cboStates.SelectedValue Is Nothing OrElse
   cboPassengers.SelectedValue Is Nothing Then

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
        "UPDATE TPassengers SET " &
        "strFirstName = @FirstName, " &
        "strLastName = @LastName, " &
        "strAddress = @Address, " &
        "strCity = @City, " &
        "intStateID = @StateID, " &
        "strZip = @Zip, " &
        "strPhoneNumber = @Phone, " &
        "strEmail = @Email " &
        "WHERE intPassengerID = @ID"

            Using command As New SQLiteCommand(strQuery, conn)

                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                command.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                command.Parameters.AddWithValue("@StateID", cboStates.SelectedValue)
                command.Parameters.AddWithValue("@Zip", txtZip.Text.Trim())
                command.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text.Trim())
                command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                command.Parameters.AddWithValue("@ID", cboPassengers.SelectedValue)

                Dim rowsUpdated As Integer = command.ExecuteNonQuery()

                If rowsUpdated = 0 Then
                    MessageBox.Show("No passenger was updated.")
                    Exit Sub
                End If

            End Using
        End Using

        MessageBox.Show("Passenger updated successfully!")
        Me.Close()
    End Sub
End Class