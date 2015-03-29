Imports System.Data.SQLite

Public Class DBOperations

    Public Function SelectQuery(ByVal command As String) ' Used to run SQLite queries

        Dim dbConnection As SQLiteConnection = New SQLiteConnection("URI=file:" & My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                                                "\Visual Studio 2013\Projects\LapTracker\LaptrackerDB.s3db") ' Build the database connection
        dbConnection.Open() ' Open the connection
        Dim dbCommand As SQLiteCommand = dbConnection.CreateCommand ' Create the command string
        Dim dbReader As SQLiteDataReader
        dbCommand.CommandText = command ' Set the command text to the string we've been passed
        dbReader = dbCommand.ExecuteReader ' Execute and return the command value
        Return dbReader

    End Function

End Class
