Imports System.Windows.Forms
Imports System.Data.SQLite

Public Class EventDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Settings.databasePath)
        dbConnection.Open()
        Dim insertCommand As SQLiteCommand = New SQLiteCommand("INSERT INTO events (eventName) VALUES (@eventName)", dbConnection) ' Build our query

        insertCommand.Parameters.AddWithValue("@eventName", nameTextbox.Text) ' Add the inputted event name
        insertCommand.ExecuteNonQuery() ' Add the new event to the table
        insertCommand = New SQLiteCommand("SELECT last_insert_rowID()", dbConnection) ' Retrieve the eventID of the event we've just created
        My.Settings.currenteventID = insertCommand.ExecuteScalar ' Set our current event ID to the one we've just created
        My.Settings.Save()
        Form1.Show()
        Form1.Text = "LapTracker -- Event: " & nameTextbox.Text ' Update the main laptracker form title
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        StartForm.Show()
        Me.Close()

    End Sub

    Private Sub nameTextbox_TextChanged(sender As Object, e As EventArgs) Handles nameTextbox.TextChanged

        If nameTextbox.Text <> "" Then OK_Button.Enabled = True Else OK_Button.Enabled = False ' Make sure we can't have a blank event name

    End Sub

    Private Sub EventDialog_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        nameTextbox.Focus()

    End Sub
End Class
