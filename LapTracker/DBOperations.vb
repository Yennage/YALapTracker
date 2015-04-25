Imports System.Data.SQLite

Public Class DBOperations

    Public Function SelectQuery(ByVal command As String, ByVal returnReader As Boolean) ' Used to run simple SQLite queries on specific table columns

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Settings.databasePath) ' Build the database connection
        dbConnection.Open() ' Open the connection
        Dim dbCommand As SQLiteCommand = dbConnection.CreateCommand ' Create the command string
        Dim resultReader As SQLiteDataReader
        Dim queryResult As String = ""

        dbCommand.CommandText = command ' Set the command text to the string we've been passed
        If returnReader = False Then ' If we're querying a specific column
            queryResult = dbCommand.ExecuteScalar.ToString ' Execute the query and return the command value
            Return queryResult
        Else
            resultReader = dbCommand.ExecuteReader ' Execute the query and return the command reader
            Return resultReader
        End If

        If Not IsNothing(dbConnection) Then
            dbConnection.Close()
        End If

    End Function

    Public Sub DeleteValue(ByVal command As String)

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Settings.databasePath) ' Build the database connection
        dbConnection.Open() ' Open the connection
        Dim dbCommand As SQLiteCommand = dbConnection.CreateCommand ' Create the command string
        dbCommand.CommandText = command ' Set the command text to the string we've been passed
        dbCommand.ExecuteNonQuery()
        dbConnection.Close()

    End Sub

    Public Sub WriteEventtoDatabase() ' Writes the data from a completed event to the SQLite laps table (move SQLite stuff over to a separate class)

        ' This needs to iterate through the list of laps and save each record to the laps table

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Settings.databasePath)
        dbConnection.Open()
        Dim insertCommand As SQLiteCommand = New SQLiteCommand("INSERT INTO laps (eventID, eventName, riderID, riderName, riderClass, lapNumber, " & _
                                                               "totalTime) VALUES (@eventID, @eventName, @riderID, @riderName, @riderClass, @lapNumber, " & _
                                                               "@totalTime)", dbConnection) ' Build our query

        For Each currentRow As ListViewItem In Form1.dataView.Items

            insertCommand.Parameters.AddWithValue("@eventID", currentRow.SubItems(0).Text) ' Add parameters
            insertCommand.Parameters.AddWithValue("@eventName", currentRow.SubItems(1).Text)
            insertCommand.Parameters.AddWithValue("@riderID", currentRow.SubItems(2).Text)
            insertCommand.Parameters.AddWithValue("@riderName", currentRow.SubItems(3).Text)
            insertCommand.Parameters.AddWithValue("@riderClass", currentRow.SubItems(4).Text)
            insertCommand.Parameters.AddWithValue("@lapNumber", currentRow.SubItems(5).Text)
            insertCommand.Parameters.AddWithValue("@totalTime", currentRow.SubItems(6).Text)
            insertCommand.ExecuteNonQuery() ' Execute the query

        Next

        dbConnection.Close()

    End Sub

    Public Sub AddRider(ByVal riderNumber As Integer, ByVal riderName As String, ByVal riderClass As String) ' Add a new rider to the riders table

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Settings.databasePath)
        Dim insertCommand As SQLiteCommand = New SQLiteCommand("INSERT INTO riders (riderID, riderName, riderClass)" & _
                                                               "VALUES (@riderID, @riderName, @riderClass)", dbConnection) ' Build our query

        insertCommand.Parameters.AddWithValue("@riderID", riderNumber)
        insertCommand.Parameters.AddWithValue("@riderName", riderName)
        insertCommand.Parameters.AddWithValue("@riderClass", riderClass)
        dbConnection.Open()
        insertCommand.ExecuteNonQuery()
        dbConnection.Close()

    End Sub
End Class
