Public Class Form1

    Public Class GlobalVariables
        Public Shared elapsedSeconds As Double
    End Class

    Private Sub StartStopButton_Click(sender As Object, e As EventArgs) Handles StartStopButton.Click

        If LapTimer.Enabled = True Then ' Simple if statement for our dual usage start/stop button
            StartStopButton.Text = "Start Timer"
            LapTimer.Enabled = False
        Else
            StartStopButton.Text = "Stop Timer"
            GlobalVariables.elapsedSeconds = 0 ' Reset the variable
            LapTimer.Enabled = True
        End If

    End Sub

    Private Sub LapTimer_Tick(sender As Object, e As EventArgs) Handles LapTimer.Tick

        GlobalVariables.elapsedSeconds += 1
        TimerValue.Text = String.Format("{0} seconds elapsed", Math.Round((GlobalVariables.elapsedSeconds / 100), 2))

    End Sub
End Class
