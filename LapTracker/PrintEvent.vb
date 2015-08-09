Imports System.Data.SQLite
Public Class PrintEvent

    Public Class CurrentState
        Public rowsPrinted As Integer ' The number of rows we've printed so far
        Public totalRows As Integer ' The total number of rows we need to print
    End Class

    Public Sub CommencePrinting(ByVal venueName As String, ByVal amID As String, ByVal pmID As String, ByVal printLocation As String, ByVal amPreload As Boolean, _
                                ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs)
        ' Handles printing event details to HTML and CSV

        Dim operations As New DBOperations
        Dim dbReader As SQLiteDataReader
        Dim state As New CurrentState ' Used to push our current progress back to the UI thread
        Dim currentRow(4) As String
        Dim csvRow(10) As String
        Dim htmlOutput As String = My.Resources.tableHeader & Date.Today & "&emsp;&emsp;&emsp;Venue: " & venueName & "</br></br>" ' Add date and venue name to the table header
        Dim csvOutput As String = "Banovallum Motorcycle Club Results," & Date.Today & ",Venue: " & venueName
        Dim tableHtml As String = "<table border=""1""style=""width:75%"">"
        Dim tableColumns As String = "<tr><td>Rider No.</td><td>Rider Name</td><td>Morning Laps</td><td>Time</td><td>Afternoon Laps</td>" & _
"<td>Time</td><td>Total Laps</td><td>Time</td><td>Final Position</td><td>Final Points</td></tr>" ' Our columns
        Dim positionCounter As Integer
        Dim pointsCounter As Integer
        Dim amLaps As Integer = 0 ' The AM lap count
        Dim amTime As TimeSpan ' The AM total time
        Dim pmTime As TimeSpan ' The PM total time

        state.totalRows = operations.SelectQuery("SELECT COUNT(*) FROM laps WHERE eventName = """ & pmID & """", False) ' Find our total number of rows
        state.rowsPrinted = 0
        worker.ReportProgress(0, state) ' Report the total number of rows we'll have to work through

        For Each currentClass As String In My.Settings.riderClasses ' Iterate through all of our available rider classes

            positionCounter = 0 ' Reset the positon variable
            pointsCounter = My.Settings.pointsAllocation ' Reset the points counter variable
            htmlOutput &= Chr(10) & tableHtml
            htmlOutput &= Chr(10) & "<tr>Class: " & currentClass & "</tr>"
            htmlOutput &= Chr(10) & tableColumns
            csvOutput &= Chr(10) & currentClass

            dbReader = operations.SelectQuery("SELECT * FROM laps WHERE eventName = """ & pmID & """ AND riderClass = """ & currentClass & _
                                              """ORDER BY lapNumber DESC", True)
            While (dbReader.Read()) ' Iterate through all values returned by the current class
                positionCounter += 1 ' Increment the position counter
                currentRow = {dbReader("riderID"), dbReader("riderName"), dbReader("lapNumber"), dbReader("totalTime")}
                Try
                    amLaps = operations.SelectQuery("SELECT lapNumber FROM laps WHERE eventName = """ & amID & _
                                                                            """ AND riderID = " & currentRow(0), False)
                Catch ' We have a database error
                    MessageBox.Show("Database connection error, lap results for eventID: " & amID & " could not be returned.", "Database Error", _
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                End Try
                amTime = TimeSpan.Parse(operations.SelectQuery("SELECT totalTime FROM laps WHERE eventName = """ & amID & _
                                                                        """ AND riderID = " & currentRow(0), False))
                pmTime = TimeSpan.Parse(currentRow(3))
                htmlOutput &= Chr(10) & "<tr><td>" & Chr(10) & currentRow(0) & "</td>" ' Rider No
                htmlOutput &= Chr(10) & "<td>" & currentRow(1) & "</td>" ' Rider Name
                htmlOutput &= Chr(10) & "<td>" & amLaps & "</td>" ' Morning Laps
                htmlOutput &= Chr(10) & "<td>" & amTime.ToString & "</td>" ' Morning Time
                If amPreload = False Then ' The user loaded AM event data correctly, calculate as standard
                    htmlOutput &= Chr(10) & "<td>" & CInt(currentRow(2)) - amLaps & "</td>" ' Afternoon Laps (Total - Morning Laps)
                Else : htmlOutput &= Chr(10) & "<td>" & currentRow(2) & "</td>" ' The user forgot to load AM event data so don't perform a subtraction
                End If
                htmlOutput &= Chr(10) & "<td>" & pmTime.ToString & "</td>" ' Afternoon Time
                If amPreload = False Then
                    htmlOutput &= Chr(10) & "<td>" & currentRow(2) & "</td>" ' Total Laps (note that this total assumes the user remembered to load AM event data)
                Else : htmlOutput &= Chr(10) & "<td>" & amLaps + CInt(currentRow(2)) & "</td>" ' Calculate Total Laps a different way
                End If
                htmlOutput &= Chr(10) & "<td>" & (amTime + pmTime).ToString & "</td>" ' Total Time
                htmlOutput &= Chr(10) & "<td>" & positionCounter & "</td>" ' Final Position
                htmlOutput &= Chr(10) & "<td>" & pointsCounter & "</td></tr>" ' Final Points
                csvRow = {currentRow(0), currentRow(1), amLaps, amTime.ToString, CInt(currentRow(2)) - amLaps, pmTime.ToString, _
                          currentRow(2), (amTime + pmTime).ToString, positionCounter, pointsCounter} ' Build an array for our CSV row
                csvOutput &= Chr(10) & String.Join(",", csvRow) ' Delimit our array
                If pointsCounter >= 1 Then pointsCounter -= 1 ' Decrement the points counter if it won't create a negative value
                state.rowsPrinted += 1
                worker.ReportProgress(0, state)
            End While

            htmlOutput &= Chr(10) & "</table></br></br>" ' Close the table tag for this class
        Next

        My.Computer.FileSystem.WriteAllText(printLocation & venueName & ".html", htmlOutput, False)
        My.Computer.FileSystem.WriteAllText(printLocation & venueName & ".csv", csvOutput, False)
        MessageBox.Show("Files successfully printed, your printable HTML and CSV files are available in: " & printLocation & _
                        " click OK to open this file location.", "Print Successful", MessageBoxButtons.OK)
        Process.Start(printLocation)

    End Sub
End Class
