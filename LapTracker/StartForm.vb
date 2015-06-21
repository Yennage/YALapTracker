﻿Public Class StartForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        EventDialog.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If My.Computer.Keyboard.CtrlKeyDown = True Then ' Ctrl key functionality for testing purposes only
            Me.Hide()
            Form1.Show()
        Else
            Me.Hide()
            PrintEventList.Show()
        End If

    End Sub

    Private Sub addRider_Click(sender As Object, e As EventArgs) Handles addRider.Click

        Me.Hide()
        ManageRiders.Show()

    End Sub

    Private Sub manageEvents_Click(sender As Object, e As EventArgs) Handles deleteEvents.Click

        Me.Hide()
        ManageEvents.Show()

    End Sub
End Class