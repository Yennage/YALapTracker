Imports System.Data.SQLite

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

    End Function
End Class
