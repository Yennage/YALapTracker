Imports System.Data.SQLite ' System.Data.SQLite.dll - required for, you guessed it, SQLite operations
Public Class Form1

    Public Class GlobalVariables ' Declared here rather than in a separate class file as we're only using a few global vars
        Public Shared elapsedSeconds As UInt64 ' We're counting in seconds so better safe than sorry
        Public Shared eventName As String ' The queried name of the current event
        Public Shared eventID As String ' The event ID, this can be removed after testing is fully completed as the event ID doesn't need to be displayed to the user
    End Class

    Private Sub StartStopButton_Click(sender As Object, e As EventArgs) Handles StartStopButton.Click

        If LapTimer.Enabled = True Then ' Simple if statement for our dual usage start/stop button
            StartStopButton.Text = "Start Timer"
            LapTimer.Enabled = False
            TimerValue.Visible = False ' Hide the time counter label
        Else
            StartStopButton.Text = "Stop Timer"
            GlobalVariables.elapsedSeconds = 0 ' Reset the variable
            LapTimer.Enabled = True
            TimerValue.Text = "00:00:00" ' Prevents the label showing with placeholder value of "No Time Elapsed" for the first second
            TimerValue.Visible = True ' Show the time counter label
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

    Public Sub GetEventName()

        Dim dbConnection As SQLiteConnection
        Dim dbCommand As SQLiteCommand
        Dim dbReader As SQLiteDataReader

        dbConnection = New SQLiteConnection("URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                                            "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db")
        dbConnection.Open()

        dbCommand = dbConnection.CreateCommand()
        dbCommand.CommandText = "SELECT * FROM events WHERE eventID =" & GlobalVariables.eventID ' Query the events table to grab the name
        dbReader = dbCommand.ExecuteReader

        While (dbReader.Read())
            GlobalVariables.eventName = dbReader("eventName") ' Set our global variable to the queried event name
        End While

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
        dbCommand.CommandText = "SELECT * FROM laps" ' This can be updated at a later date to fetch lap data from only certain events
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
        ' Will also need code to find and iterate the "current lap" value for each rider, as well as finding the right row to update based on rider ID ## DONE
        ' Once the event is complete, the data will simply need to be written to the SQLite DB as an "archive" ready for future printing with a query

        Dim dbConnection As SQLiteConnection
        Dim dbCommand As SQLiteCommand
        Dim dbReader As SQLiteDataReader
        Dim newLap(6) As String ' The array for the row we're going to be adding
        Dim riderName As String = ""
        Dim riderClass As String = ""

        If findFunction(riderText.Text, lapTime) = False Then ' Try and match the riderID to an existing entry in the listview

            ' We can't find a match so query the database to get the rider details
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
            If riderName = "" Then ' If the query returns blank
                MessageBox.Show("Rider ID: " & riderID & " not found in riders database table.", "Rider Not Found...", MessageBoxButtons.OK, _
                                MessageBoxIcon.Warning) ' Update the user
                riderText.Clear() ' Clear the textbox to ensure a fast workflow
            Else
                newLap = {GlobalVariables.eventID, GlobalVariables.eventName, riderID, riderName, _
                          riderClass, "1", lapTime} ' Build the array (lap number of 1)
                dataView.Items.Add(New ListViewItem(newLap)) ' Add the new lap details to the listview
            End If
        End If ' If the functions returns true then no updates or SQLite queries are required

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fetchButton.Click

        dataView.Items.Clear()
        FetchData()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles addButton.Click

        GlobalVariables.eventID = 1
        GetEventName() ' This is purely placeholder as we don't have a "starter" form yet to handle event names
        NewLap(riderText.Text, TimerValue.Text) ' Add the new lap (pass the timer value from here for maximum accuracy as the Sub will perform queries)

    End Sub

    Public Function findFunction(ByVal searchText As String, ByVal lapTime As String)

        Dim lapCount As Integer = 0
        Dim matchFound As Boolean = False

        For Each currentRow As ListViewItem In dataView.Items ' Iterate through our laps listview

            If searchText = currentRow.SubItems(2).Text Then ' If the riderID matches
                lapCount = CInt(currentRow.SubItems(5).Text) ' Pull the current lapcount
                currentRow.SubItems(5).Text = lapCount + 1 ' Increment the lapcount in the listview
                currentRow.SubItems(6).Text = lapTime ' Update the laptime (passed from the NewLap sub to ensure both accuracy and precision)
                Return True
                Exit Function ' Break this statement and exit the function if we find a match as the UI update is handled here
            End If

        Next

        Return False ' If we can't find a match

    End Function

    Private Sub testFind_Click(sender As Object, e As EventArgs) Handles testFind.Click

        findFunction("test2", "99:59:59")

    End Sub

    Private Sub riderText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles riderText.KeyPress

        ' Prevent non-numeric characters from being entered into the riderID textbox
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        riderText.Focus()

    End Sub
End Class
