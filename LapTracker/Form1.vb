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

        ' Define our connection and array
        Dim liteCS As String = "URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db"
        Dim currentLine() As String

        Using liteConnection As New SQLiteConnection(liteCS)
            liteConnection.Open() ' Open a connection

            Using liteCommand As New SQLiteCommand(liteConnection) ' Define our command

                liteCommand.CommandText = "SELECT * FROM laps LIMIT 5" ' Build our query
                Dim liteReader As SQLiteDataReader = liteCommand.ExecuteReader()

                Using liteReader
                    While (liteReader.Read()) ' Iterate through the results
                        currentLine = {liteReader.GetValue(0), liteReader.GetValue(1), liteReader.GetValue(2), liteReader.GetValue(3), _
                                       liteReader.GetValue(4)} ' Build our array
                        testList.Items.Add("Lap time: " & currentLine(4)) ' Update the listbox
                    End While
                End Using
            End Using

            liteConnection.Close() ' Close the SQLite connection
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fetchButton.Click

        testList.Items.Clear()
        FetchData()

    End Sub
End Class
