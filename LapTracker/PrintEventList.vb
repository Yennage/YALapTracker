Imports System.Data.SQLite

Public Class PrintEventList

    Private Sub PrintEventList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim operations As New DBOperations
        Dim dbReader As SQLiteDataReader
        Dim currentRow As String

        dbReader = operations.SelectQuery("SELECT * FROM events ORDER BY eventName ASC", True) ' Pull our events and sort alphabetically

        While (dbReader.Read()) ' Update the listbox
            currentRow = dbReader("eventName")
            eventList.Items.Add(currentRow)
        End While

    End Sub

    Private Sub eventList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eventList.SelectedIndexChanged

        If amTextbox.Text = "" Then ' Quick and imperfect way to choose our AM and PM events
            amTextbox.Text = eventList.SelectedItem
        Else
            pmTextbox.Text = eventList.SelectedItem
        End If

    End Sub

    Private Sub amClear_Click(sender As Object, e As EventArgs) Handles amClear.Click

        amTextbox.Text = ""

    End Sub

    Private Sub pmClear_Click(sender As Object, e As EventArgs) Handles pmClear.Click

        pmTextbox.Text = ""

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        Me.Close()
        StartForm.Show()

    End Sub

    Public Function CheckText() ' Super simple function to check we have both an AM and PM event selected

        If amTextbox.Text <> "" And pmTextbox.Text <> "" And venueName.Text <> "" Then ' Make sure that none of our textboxes are empty
            Return True
        Else : Return False
        End If

    End Function

    Private Sub amTextbox_TextChanged(sender As Object, e As EventArgs) Handles amTextbox.TextChanged

        printButton.Enabled = CheckText()

    End Sub

    Private Sub pmTextbox_TextChanged(sender As Object, e As EventArgs) Handles pmTextbox.TextChanged

        printButton.Enabled = CheckText()

    End Sub

    Private Sub venueName_TextChanged(sender As Object, e As EventArgs) Handles venueName.TextChanged

        printButton.Enabled = CheckText()

    End Sub
End Class