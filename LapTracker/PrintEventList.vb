Imports System.Data.SQLite
Imports System.Text.RegularExpressions

Public Class PrintEventList

    Private Sub PrintEventList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim operations As New DBOperations
        Dim dbReader As SQLiteDataReader
        Dim currentRow As String

        dbReader = operations.SelectQuery("SELECT * FROM events ORDER BY eventName ASC", True) ' Pull our events and sort alphabetically

        While (dbReader.Read()) ' Update the listbox
            currentRow = dbReader("eventName")
            eventList.Items.Add(currentRow)
        End While

    End Sub

    Private Sub eventList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eventList.SelectedIndexChanged

        If amTextbox.Text = "" Then ' Quick and imperfect way to choose our AM and PM events
            amTextbox.Text = eventList.SelectedItem
        Else
            pmTextbox.Text = eventList.SelectedItem
        End If

    End Sub

    Sub StartThread()

        Dim WC As New PrintEvent
        BackgroundWorker1.RunWorkerAsync(WC)

    End Sub

    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click

        If filenameCheck(venueName.Text) = False Then
            Dim result As DialogResult = printLocation.ShowDialog
            If result = Windows.Forms.DialogResult.OK Then StartThread()
        Else
            MessageBox.Show("Your venue name is invalid, please note that the following characters cannot be used: ^?:\\/:*?\""<>|", "Invalid File Name", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            venueName.Focus()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)

        Dim WC As PrintEvent = CType(e.Argument, PrintEvent)
        WC.CommencePrinting(venueName.Text, amTextbox.Text, pmTextbox.Text, printLocation.SelectedPath & "\", worker, e)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim state As PrintEvent.CurrentState = _
           CType(e.UserState, PrintEvent.CurrentState)
        printProgress.Maximum = state.totalRows ' Update our UI elements
        printProgress.Value = state.rowsPrinted

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        If e.Error IsNot Nothing Then
            MsgBox("Error: " & e.Error.Message)
        End If

    End Sub

    Private Sub amClear_Click(sender As Object, e As EventArgs) Handles amClear.Click

        amTextbox.Text = ""

    End Sub

    Private Sub pmClear_Click(sender As Object, e As EventArgs) Handles pmClear.Click

        pmTextbox.Text = ""

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        Me.Close()
        StartForm.Show()

    End Sub

    Public Function CheckText() ' Super simple function to check we have both an AM and PM event selected

        If amTextbox.Text <> "" And pmTextbox.Text <> "" And venueName.Text <> "" Then ' Make sure that none of our textboxes are empty
            Return True
        Else : Return False
        End If

    End Function

    Private Sub amTextbox_TextChanged(sender As Object, e As EventArgs) Handles amTextbox.TextChanged

        printButton.Enabled = CheckText()

    End Sub

    Private Sub pmTextbox_TextChanged(sender As Object, e As EventArgs) Handles pmTextbox.TextChanged

        printButton.Enabled = CheckText()

    End Sub

    Public Function filenameCheck(ByVal checkInput As String)

        Dim filenameRegex As New Regex("[" & Regex.Escape(New String(System.IO.Path.GetInvalidFileNameChars())) & "]")
        Return filenameRegex.IsMatch(checkInput)

    End Function

    Private Sub venueName_TextChanged(sender As Object, e As EventArgs) Handles venueName.TextChanged

        printButton.Enabled = CheckText()

    End Sub
End Class