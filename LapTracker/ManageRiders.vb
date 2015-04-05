Imports System.Data.SQLite

Public Class ManageRiders

    Private Sub ManageRiders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        StartForm.Show()

    End Sub

    Private Sub ManageRiders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FetchRiders() ' Update our listview with all riders
        FetchClasses() ' Populate our classes combobox

    End Sub

    Sub FetchRiders()

        riderList.Items.Clear()
        Dim operations As New DBOperations
        Dim dbReader As SQLiteDataReader
        Dim currentRow(3) As String

        dbReader = operations.SelectQuery("SELECT * FROM riders ORDER BY riderName ASC", True) ' Retrieve all riders

        While (dbReader.Read())
            currentRow = {dbReader("riderID"), dbReader("riderName"), dbReader("riderClass")} ' Build an array for the current row
            riderList.Items.Add(New ListViewItem(currentRow)) ' Update the listview
        End While

    End Sub

    Sub FetchClasses() ' Populate our combobox with all of our available classes

        riderClass.Items.Clear() ' Clear our combobox before beginning

        For Each currentClass As String In My.Settings.riderClasses
            riderClass.Items.Add(currentClass) ' Add each class from our class list
        Next currentClass

    End Sub

    Private Sub riderNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles riderNumber.KeyPress

        ' Prevent non-numeric characters from being entered into the rider no. textbox
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Public Function CheckText()

        If riderNumber.Text <> "" And riderName.Text <> "" And riderClass.SelectedIndex >= 0 Then ' Make sure that none of our selections are empty
            Return True
        Else : Return False
        End If

    End Function

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        Me.Close()

    End Sub

    Private Sub riderNumber_TextChanged(sender As Object, e As EventArgs) Handles riderNumber.TextChanged

        addButton.Enabled = CheckText()

    End Sub

    Private Sub riderName_TextChanged(sender As Object, e As EventArgs) Handles riderName.TextChanged

        If riderName.Text.Contains("'") Or riderName.Text.Contains("""") Then ' Make sure we can't enter characters that will throw an SQLite error
            textTooltip.Show("Characters ' and """" are invalid.", Label2, 1500)
            riderName.Text = riderName.Text.Replace("'", "")
            riderName.Text = riderName.Text.Replace("""", "")
        End If

        addButton.Enabled = CheckText()

    End Sub

    Private Sub riderClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles riderClass.SelectedIndexChanged

        addButton.Enabled = CheckText()

    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click

        Dim matchedRider As String = "" ' The name of the rider who matches the ID check (for user output purposes only)
        Dim operations As New DBOperations

        If CheckRiders(riderNumber.Text, matchedRider) = False Then
            operations.AddRider(CInt(riderNumber.Text), riderName.Text, riderClass.SelectedItem) ' Add our new rider to the database
            FetchRiders() ' Refresh the list
            riderNumber.Clear()
            riderName.Clear()
        Else
            MessageBox.Show("Rider No: " & riderNumber.Text & " already exists in the database as: " & matchedRider & "." & Chr(10) & _
                            Chr(10) & "Please select a different rider number.", "Rider No Already Exists...", MessageBoxButtons.OK)
            riderNumber.Clear()
            riderNumber.Focus()
        End If

    End Sub

    Public Function CheckRiders(ByVal riderID As String, ByRef riderName As String) ' Check to make sure the rider ID we're trying to add doesn't already exist

        For Each currentRow As ListViewItem In riderList.Items ' Iterate through our riders list
            If riderID = currentRow.SubItems(0).Text Then ' We've found a match
                riderName = currentRow.SubItems(1).Text
                Return True
                Exit Function
            End If
        Next

        Return False

    End Function

    Private Sub deleteRider_Click(sender As Object, e As EventArgs) Handles deleteRider.Click

        Dim riderID As Integer = CInt(riderList.FocusedItem.SubItems(0).Text) ' Get our currently selected riderID
        Dim operations As New DBOperations

        If MessageBox.Show("Are you sure you want to remove " & riderList.FocusedItem.SubItems(1).Text & " from the riders database?" _
                           , "Confirm Deletion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            operations.DeleteValue("DELETE FROM riders WHERE riderID = " & riderID) ' Confirm the deletion, then carry it out
            FetchRiders() ' Update the UI
        End If

    End Sub

    Private Sub addClass_Click(sender As Object, e As EventArgs) Handles addClass.Click

        AddClassDialog.Show()

    End Sub
End Class