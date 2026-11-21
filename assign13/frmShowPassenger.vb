Imports System.Data.SQLite
Imports System.IO
Public Class frmShowPassenger

    Private Sub frmShowPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim databasePath As String =
        Path.GetFullPath(Path.Combine(Application.StartupPath,
                                     "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
        "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)

            conn.Open()

            Dim strQuery As String =
            "SELECT TPassengers.*, TStates.strState " &
            "FROM TPassengers " &
            "LEFT JOIN TStates ON TPassengers.intStateID = TStates.intStateID"

            Using command As New SQLiteCommand(strQuery, conn)

                Using reader As SQLiteDataReader = command.ExecuteReader()

                    lstPassengers.Items.Clear()

                    While reader.Read()

                        Dim passengerInfo As String =
                        reader("strFirstName").ToString() & " " &
                        reader("strLastName").ToString() & " | " &
                        reader("strAddress").ToString() & " | " &
                        reader("strCity").ToString() & " | " &
                        reader("strState").ToString() & " | " &
                        reader("strZip").ToString() & " | " &
                        reader("strPhoneNumber").ToString() & " | " &
                        reader("strEmail").ToString()

                        lstPassengers.Items.Add(passengerInfo)

                    End While

                End Using
            End Using
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class