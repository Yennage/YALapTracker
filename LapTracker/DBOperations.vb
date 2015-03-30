﻿Imports System.Data.SQLite

Public Class DBOperations

    Public Function SelectQuery(ByVal command As String, ByVal returnReader As Boolean) ' Used to run simple SQLite queries on specific table columns

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                                                "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db") ' Build the database connection
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

    Public Sub WriteEventtoDatabase() ' Writes the data from a completed event to the SQLite laps table (move SQLite stuff over to a separate class)

        ' This needs to iterate through the list of laps and save each record to the laps table

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                                               "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db")
        Dim insertCommand As SQLiteCommand = New SQLiteCommand("INSERT INTO laps (eventID, eventName, riderID, riderName, lapNumber, " & _
                                                               "totalTime) VALUES (@eventID, @eventName, @riderID, @riderName, @lapNumber, " & _
                                                               "@totalTime)", dbConnection) ' Build our query
        insertCommand.Parameters.AddWithValue("@eventID", 1337) ' Add parameters
        insertCommand.Parameters.AddWithValue("@eventName", "test event")
        insertCommand.Parameters.AddWithValue("@riderID", 1337)
        insertCommand.Parameters.AddWithValue("@riderName", "Yen Nage")
        insertCommand.Parameters.AddWithValue("@lapNumber", 100)
        insertCommand.Parameters.AddWithValue("@totalTime", 1000)
        dbConnection.Open()
        insertCommand.ExecuteNonQuery() ' Execute the query
        MessageBox.Show("Write Completed")

    End Sub
End Class
