﻿Imports System.Data.SQLite ' System.Data.SQLite.dll - required for, you guessed it, SQLite operations
Public Class Form1

    Public Class GlobalVariables ' Declared here rather than in a separate class file as we're only using one global var anyway
        Public Shared elapsedSeconds As UInt64 ' We're counting in milliseconds so better safe than sorry
    End Class

    Private Sub StartStopButton_Click(sender As Object, e As EventArgs) Handles StartStopButton.Click

        ' MessageBox.Show(1002 Mod 1000)

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

        ' Variables for second conversions
        Dim secondCount As Integer = 0
        Dim minuteCount As Integer = 0
        Dim hourCount As Integer = 0

        GlobalVariables.elapsedSeconds += 1 ' Increment the global var

        secondCount = GlobalVariables.elapsedSeconds Mod 60 ' Second count
        minuteCount = ((GlobalVariables.elapsedSeconds - secondCount) / 60) Mod 60 ' Minute count
        hourCount = ((GlobalVariables.elapsedSeconds - (secondCount + (minuteCount * 60))) / 3600) Mod 60 ' Hour count

        TimerValue.Text = hourCount.ToString("D2") & ":" & minuteCount.ToString("D2") & ":" & secondCount.ToString("D2") ' Build the label text string

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

        ' Will need to insert an SQLite query here to pull rider and event names
        ' Will also need code to find and iterate the "current lap" value for each rider, as well as finding the right row to update based on rider ID
        ' Once the event is complete, the data will simply need to be written to the SQLite DB as an "archive" ready for future printing with a query

        Dim dbConnection As SQLiteConnection
        Dim dbCommand As SQLiteCommand
        Dim dbReader As SQLiteDataReader
        Dim newLap(6) As String ' The array for the row we're going to be adding
        Dim riderName As String = ""
        Dim riderClass As String = ""

        dbConnection = New SQLiteConnection("URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                                            "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db")
        dbConnection.Open()

        dbCommand = dbConnection.CreateCommand()
        dbCommand.CommandText = "SELECT * FROM riders WHERE riderID =" & riderText.Text ' Query the rider ID against the riders table
        dbReader = dbCommand.ExecuteReader
        While (dbReader.Read())
            riderName = dbReader("riderName") ' Return the value
            riderClass = dbReader("riderClass")
        End While

        newLap = {"Placeholder", "Queried Result", riderID, riderName, riderClass, "Previous value += 1", lapTime}
        dataView.Items.Add(New ListViewItem(newLap))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fetchButton.Click

        dataView.Items.Clear()
        FetchData()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles addButton.Click

        NewLap(riderText.Text, TimerValue.Text) ' Add the new lap (pass the timer value from here for maximum accuracy as the Sub will perform queries)

    End Sub

    Private Sub findFunction(ByVal searchText As String)

        Dim lapCount As Integer = 0

        For Each currentRow As ListViewItem In dataView.Items ' Iterate through our laps listview

            If searchText = currentRow.SubItems(2).Text Then ' If the riderID matches
                lapCount = CInt(currentRow.SubItems(5).Text)
                currentRow.SubItems(5).Text = lapCount + 1
            End If

        Next

    End Sub

    Private Sub testFind_Click(sender As Object, e As EventArgs) Handles testFind.Click

        findFunction("test2")

    End Sub
End Class
