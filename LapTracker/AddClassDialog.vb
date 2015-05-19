Imports System.Windows.Forms

Public Class AddClassDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.riderClasses.Add(className.Text) ' Add our new rider class and save the setting
        My.Settings.Save()
        ManageRiders.FetchClasses() ' Update the Manage Riders UI
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub className_TextChanged(sender As Object, e As EventArgs) Handles className.TextChanged

        If className.Text <> "" Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If

    End Sub
End Class
