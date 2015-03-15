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
                          dbReader("lapNumber"), dbReader("totalTime")} ' Build an array for the current row
            dataView.Items.Add(New ListViewItem(currentRow)) ' Update the listview
        End While

        If Not IsNothing(dbConnection) Then
            dbConnection.Close()
        End If

    End Sub

    Sub NewLap(ByVal riderID As String, ByVal lapTime As String)

        Dim newLap(6) As String ' The array for the row we're going to be adding

        ' Will need to insert an SQLite query here to pull rider and event names
        ' Will also need code to find and iterate the "current lap" value for each rider, as well as finding the right row to update based on rider ID

        newLap = {"Do we still need this column?", "Placeholder", "Queried Result", riderID, "Queried Result", "Previous value += 1", lapTime}
        dataView.Items.Add(New ListViewItem(newLap))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fetchButton.Click

        dataView.Items.Clear()
        FetchData()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        NewLap(riderText.Text, TimerValue.Text) ' Add the new lap (pass the timer value from here for maximum accuracy as the Sub will perform queries)

    End Sub
End Class
