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
        Else
            StartStopButton.Text = "Stop Timer"
            GlobalVariables.elapsedSeconds = 0 ' Reset the variable
            LapTimer.Enabled = True
            TimerValue.Text = "00:00:00" ' Prevents the label showing with placeholder value of "No Time Elapsed" for the first second
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

    Public Function GetEventName() ' Used to query the events table for the name of the event

        Dim operations As New DBOperations
        Return operations.SelectQuery("SELECT eventName FROM events WHERE eventID =" & GlobalVariables.eventID, False) ' Update our global var

    End Function

    Sub FetchData(ByVal eventName As String) ' Pull data from an AM event and add PM event details

        Dim operations As New DBOperations
        Dim dbReader As SQLiteDataReader
        Dim currentRow(7) As String

        dbReader = operations.SelectQuery("SELECT * FROM laps WHERE eventName = """ & eventName & """ ORDER BY totalTime ASC", _
                                          True) ' This can be updated at a later date to fetch lap data from only certain events

        While (dbReader.Read())
            ' Below placeholder will be replaced with the global eventName variable once testing is complete
            currentRow = {dbReader("eventID"), GlobalVariables.eventName, dbReader("riderID"), dbReader("riderName"), _
                          dbReader("riderClass"), dbReader("lapNumber"), "00:00:00"} ' Event name is our current event and event time is reset
            dataView.Items.Add(New ListViewItem(currentRow)) ' Update the listview
        End While

    End Sub

    Sub NewLap(ByVal riderID As String, ByVal lapTime As String)

        ' Once the event is complete, the data will simply need to be written to the SQLite DB as an "archive" ready for future printing with a query

        Dim newLap(6) As String ' The array for the row we're going to be adding
        Dim newAmendment(5) As String ' The array for our latest change listview
        Dim riderName As String = ""
        Dim riderClass As String = ""

        If findFunction(riderID, lapTime) = False Then ' Try and match the riderID to an existing entry in the listview

            ' We can't find a match so query the database to get the rider details
            Dim operations As New DBOperations
            Dim dbReader As SQLiteDataReader
            dbReader = operations.SelectQuery("SELECT * FROM riders WHERE riderID =" & riderID, True) ' Query the rider ID against the riders table

            While (dbReader.Read())
                riderName = dbReader("riderName") ' Return the value
                riderClass = dbReader("riderClass")
            End While

            If riderName = "" Then ' If the query returns blank
                MessageBox.Show("Rider ID: " & riderID & " not found in riders database table.", "Rider Not Found...", MessageBoxButtons.OK, _
                                MessageBoxIcon.Warning) ' Update the user
                riderText.Clear() ' Clear the textbox to ensure a fast workflow
                riderText.Focus() ' Helpful refocus for the user 
            Else ' If the query returns a match
                newLap = {GlobalVariables.eventID, GlobalVariables.eventName, riderID, riderName, _
                          riderClass, "1", lapTime} ' Build the array (lap number of 1)
                dataView.Items.Add(New ListViewItem(newLap)) ' Add the new lap details to the listview
                newAmendment = {"Added", riderID, 0, 1, "00:00:00", lapTime} ' We're adding a new rider with no previous times
                UpdateHistory(newAmendment) ' Push our new update to the UI
            End If
        End If ' If the function returns true then no updates or SQLite queries are required

    End Sub

    Sub UpdateHistory(ByVal latestChange()) ' Updates the UI element for our change history

        If changeList.Items.Count = 5 Then ' If we already have 5 items in our change history...
            changeList.Items.RemoveAt(4) ' ...remove our last one
        End If

        changeList.Items.Insert(0, New ListViewItem(latestChange)) ' Add our new change to the top of the listview

    End Sub

    Sub UndoChange(ByVal changeIndex As Integer)

        Dim newAmendment(5) As String ' Used for tracking amendment changes

        For Each currentRow As ListViewItem In dataView.Items ' Iterate through our laps listview
            If changeList.Items(changeIndex).SubItems(1).Text = currentRow.SubItems(2).Text Then ' If the rider ID matches
                If changeList.Items(changeIndex).SubItems(0).Text = "Added" Then ' We can just remove the value as there isn't a previous laptime
                    changeList.Items.RemoveAt(changeIndex)
                    dataView.Items.RemoveAt(currentRow.Index)
                Else
                    newAmendment = {"Updated", currentRow.SubItems(2).Text, currentRow.SubItems(5).Text, changeList.Items(changeIndex).SubItems(2).Text, _
                                    currentRow.SubItems(6).Text, changeList.Items(changeIndex).SubItems(4).Text}
                    currentRow.SubItems(5).Text = changeList.Items(changeIndex).SubItems(2).Text ' Change the lap count to the old lap count
                    currentRow.SubItems(6).Text = changeList.Items(changeIndex).SubItems(4).Text ' Change the lap time to the old time
                    UpdateHistory(newAmendment)
                End If
                Exit For
            End If
        Next

    End Sub

    Sub AmendChange(ByVal changeIndex As Integer, ByVal riderID As String)

        Dim newAmendment(5) As String ' Used for tracking amendment changes
        Dim oldTime As String = changeList.Items(changeIndex).SubItems(5).Text ' Important we pull this before deleting the changelist item

        For Each currentRow As ListViewItem In dataView.Items ' Iterate through our laps listview
            If changeList.Items(changeIndex).SubItems(1).Text = currentRow.SubItems(2).Text Then ' If the rider ID matches

                If changeList.Items(changeIndex).SubItems(0).Text = "Updated" Then ' If the amendment has old lap data associated with it
                    newAmendment = {"Updated", currentRow.SubItems(2).Text, currentRow.SubItems(5).Text, changeList.Items(changeIndex).SubItems(2).Text, _
                                    currentRow.SubItems(6).Text, changeList.Items(changeIndex).SubItems(4).Text}
                    currentRow.SubItems(5).Text = changeList.Items(changeIndex).SubItems(2).Text ' Change the lap count to the old lap count
                    currentRow.SubItems(6).Text = changeList.Items(changeIndex).SubItems(4).Text ' Change the lap time to the old time
                    UpdateHistory(newAmendment)
                    Exit For ' We can stop looping now
                Else
                    dataView.Items.RemoveAt(currentRow.Index) ' If it's a new lap we can just remove it
                    changeList.Items.RemoveAt(changeIndex) ' We don't want to be dealing with undoing deletions so just remove it
                End If

            End If
        Next
        NewLap(riderID, oldTime) ' Amend our data using the new lap function, passing rider ID and laptime

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fetchButton.Click

        dataView.Items.Clear()
        FetchEventDialog.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles addButton.Click

        If riderText.Text <> "" Then
            ' GlobalVariables.eventID = 1 ' Purely for testing purposes
            If GlobalVariables.eventName = "" Then GlobalVariables.eventName = GetEventName() ' Only query the DB if we don't have the event name already
            NewLap(riderText.Text, TimerValue.Text) ' Add the new lap (pass the timer value from here for maximum accuracy as the Sub will perform queries)
            riderText.Clear() ' Clear the textbox for the benefit of the user
        Else : MessageBox.Show("A rider number is required in order to add a lap.", "No Rider Number", MessageBoxButtons.OK, _
        MessageBoxIcon.Warning) ' An empty input here will throw an exception
        End If

    End Sub

    Public Function findFunction(ByVal searchText As String, ByVal lapTime As String)

        Dim lapCount As Integer = 0
        Dim oldTime As String
        Dim newAmendment(5) As String ' The array for our latest change listview

        For Each currentRow As ListViewItem In dataView.Items ' Iterate through our laps listview

            If searchText = currentRow.SubItems(2).Text Then ' If the riderID matches
                lapCount = CInt(currentRow.SubItems(5).Text) ' Pull the current lapcount
                oldTime = currentRow.SubItems(6).Text ' Grab the old laptime before we replace it
                currentRow.SubItems(5).Text = lapCount + 1 ' Increment the lapcount in the listview
                currentRow.SubItems(6).Text = lapTime ' Update the laptime (passed from the NewLap sub to ensure both accuracy and precision)
                newAmendment = {"Updated", searchText, lapCount, lapCount + 1, oldTime, lapTime}
                UpdateHistory(newAmendment)
                Return True
                Exit Function ' Break this statement and exit the function if we find a match as the UI update is handled here
            End If

        Next

        Return False ' If we can't find a match

    End Function

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
        GlobalVariables.eventID = My.Settings.currenteventID

    End Sub

    Private Sub pmButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        If MessageBox.Show("Are you sure you want to complete this event?", "Confirm completion...", MessageBoxButtons.YesNo, _
                          MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            ' TODO: Multithread this operation
            Dim operations As New DBOperations
            operations.WriteEventtoDatabase() ' Save our current event to the SQLite laps table
            If MessageBox.Show("Database write completed, return to the main menu?", "Event Written to Database", MessageBoxButtons.YesNo) = _
                Windows.Forms.DialogResult.Yes Then
                Me.Close()
                StartForm.Show()
            End If
        End If

    End Sub

    Private Sub amendText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles amendText.KeyPress

        ' Prevent non-numeric characters from being entered into the amend ID textbox
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub undoButton_Click(sender As Object, e As EventArgs) Handles undoButton.Click

        Try
            UndoChange(changeList.FocusedItem.Index)
        Catch ex As System.NullReferenceException ' If we don't have a valid item focused
            MessageBox.Show("No change has been selected. Please select a row to amend before continuing.", "Blank Row Selection", _
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) ' Update the user
        End Try

    End Sub

    Private Sub alterButton_Click(sender As Object, e As EventArgs) Handles alterButton.Click

        Try
            AmendChange(changeList.FocusedItem.Index, amendText.Text)
        Catch ex As System.NullReferenceException ' If we don't have a valid item focused
            MessageBox.Show("No change has been selected. Please select a row to amend before continuing.", "Blank Row Selection", _
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) ' Update the user
        End Try

    End Sub

    Private Sub amendText_TextChanged(sender As Object, e As EventArgs) Handles amendText.TextChanged

        If amendText.Text = "" Then
            alterButton.Enabled = False ' Prevent our alter button from being pressed without a valid input
        Else
            alterButton.Enabled = True
        End If

    End Sub

    Private Sub changeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles changeList.SelectedIndexChanged

        Try
            historyLabel.Text = "Last 5 Inputs: Currently selected Rider No. " & changeList.FocusedItem.SubItems(1).Text & ", lap times: " & _
            changeList.FocusedItem.SubItems(4).Text & " to " & changeList.FocusedItem.SubItems(5).Text
        Catch ex As System.NullReferenceException ' If we don't have a valid item focused
        End Try

    End Sub

    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        If MessageBox.Show("Are you sure you want to return to the main menu? All unsaved event data will be lost.", "Confirm Return", MessageBoxButtons.YesNo) = _
            Windows.Forms.DialogResult.Yes Then
            Me.Close()
            StartForm.Show()
        End If

    End Sub
End Class
