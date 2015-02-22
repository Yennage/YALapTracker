<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StartStopButton = New System.Windows.Forms.Button()
        Me.LapTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimerValue = New System.Windows.Forms.Label()
        Me.fetchButton = New System.Windows.Forms.Button()
        Me.testList = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'StartStopButton
        '
        Me.StartStopButton.Location = New System.Drawing.Point(12, 12)
        Me.StartStopButton.Name = "StartStopButton"
        Me.StartStopButton.Size = New System.Drawing.Size(75, 23)
        Me.StartStopButton.TabIndex = 0
        Me.StartStopButton.Text = "Start Timer"
        Me.StartStopButton.UseVisualStyleBackColor = True
        '
        'LapTimer
        '
        Me.LapTimer.Interval = 10
        '
        'TimerValue
        '
        Me.TimerValue.AutoSize = True
        Me.TimerValue.Location = New System.Drawing.Point(93, 17)
        Me.TimerValue.Name = "TimerValue"
        Me.TimerValue.Size = New System.Drawing.Size(83, 13)
        Me.TimerValue.TabIndex = 1
        Me.TimerValue.Text = "No time elapsed"
        '
        'fetchButton
        '
        Me.fetchButton.Location = New System.Drawing.Point(12, 227)
        Me.fetchButton.Name = "fetchButton"
        Me.fetchButton.Size = New System.Drawing.Size(75, 23)
        Me.fetchButton.TabIndex = 2
        Me.fetchButton.Text = "Fetch Data"
        Me.fetchButton.UseVisualStyleBackColor = True
        '
        'testList
        '
        Me.testList.FormattingEnabled = True
        Me.testList.Location = New System.Drawing.Point(12, 41)
        Me.testList.Name = "testList"
        Me.testList.Size = New System.Drawing.Size(260, 173)
        Me.testList.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.testList)
        Me.Controls.Add(Me.fetchButton)
        Me.Controls.Add(Me.TimerValue)
        Me.Controls.Add(Me.StartStopButton)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "LapTracker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartStopButton As System.Windows.Forms.Button
    Friend WithEvents LapTimer As System.Windows.Forms.Timer
    Friend WithEvents TimerValue As System.Windows.Forms.Label
    Friend WithEvents fetchButton As System.Windows.Forms.Button
    Friend WithEvents testList As System.Windows.Forms.ListBox

End Class
