Imports System.Windows.Forms
Imports System.Data.SQLite

Public Class FetchEventDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Form1.FetchData(eventBox.SelectedItem)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub FetchEventDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim operations As New DBOperations
        Dim dbReader As SQLiteDataReader
        Dim currentRow As String

        dbReader = operations.SelectQuery("SELECT * FROM events ORDER BY eventName ASC", True) ' Pull our events and sort alphabetically

        While (dbReader.Read()) ' Update the combobox
            currentRow = dbReader("eventName")
            eventBox.Items.Add(currentRow)
        End While

    End Sub
End Class
