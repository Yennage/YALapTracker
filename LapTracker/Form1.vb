Imports System.Data.SQLite ' System.Data.SQLite.dll - required for, you guessed it, SQLite operations
Public Class Form1

    Public Class GlobalVariables ' Declared here rather than in a separate class file as we're only using one global var anyway
        Public Shared elapsedSeconds As Double
    End Class

    Private Sub StartStopButton_Click(sender As Object, e As EventArgs) Handles StartStopButton.Click

        If LapTimer.Enabled = True Then ' Simple if statement for our dual usage start/stop button
            StartStopButton.Text = "Start Timer"
            LapTimer.Enabled = False
        Else
            StartStopButton.Text = "Stop Timer"
            GlobalVariables.elapsedSeconds = 0 ' Reset the variable
            LapTimer.Enabled = True
        End If

    End Sub

    Private Sub LapTimer_Tick(sender As Object, e As EventArgs) Handles LapTimer.Tick

        GlobalVariables.elapsedSeconds += 1 ' Increment the global var
        TimerValue.Text = String.Format("{0} seconds elapsed", Math.Round((GlobalVariables.elapsedSeconds / 100), 2)) ' Build the string

    End Sub

    Sub FetchData() ' Quick little test of pulling data from an SQLite table

        Dim dbConnection As SQLiteConnection
        Dim dbCommand As SQLiteCommand
        Dim dbReader As SQLiteDataReader
        Dim currentRow(6) As String

        dbConnection = New SQLiteConnection("URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                                            "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db")
        dbConnection.Open()

        dbCommand = dbConnection.CreateCommand()
        dbCommand.CommandText = "SELECT * FROM laps" ' This can be updated at a later date to fetch time data from only certain events
        dbReader = dbCommand.ExecuteReader

        While (dbReader.Read())
            currentRow = {dbReader("lapsID"), dbReader("eventID"), dbReader("eventName"), dbReader("riderID"), dbReader("riderName"), _
                          dbReader("lapNumber"), dbReader("totalTime")}
            dataView.Items.Add(New ListViewItem(currentRow))
        End While

        If Not IsNothing(dbConnection) Then
            dbConnection.Close()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fetchButton.Click

        dataView.Items.Clear()

        FetchData()

    End Sub
End Class
