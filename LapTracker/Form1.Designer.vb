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
        Me.dataView = New System.Windows.Forms.ListView()
        Me.eventID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.eventName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.riderID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.riderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.riderClass = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lapNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.addButton = New System.Windows.Forms.Button()
        Me.riderText = New System.Windows.Forms.TextBox()
        Me.testFind = New System.Windows.Forms.Button()
        Me.disclaimerLabel = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'StartStopButton
        '
        Me.StartStopButton.Location = New System.Drawing.Point(12, 12)
        Me.StartStopButton.Name = "StartStopButton"
        Me.StartStopButton.Size = New System.Drawing.Size(75, 23)
        Me.StartStopButton.TabIndex = 5
        Me.StartStopButton.Text = "Start Timer"
        Me.StartStopButton.UseVisualStyleBackColor = True
        '
        'LapTimer
        '
        Me.LapTimer.Interval = 1000
        '
        'TimerValue
        '
        Me.TimerValue.AutoSize = True
        Me.TimerValue.Location = New System.Drawing.Point(93, 17)
        Me.TimerValue.Name = "TimerValue"
        Me.TimerValue.Size = New System.Drawing.Size(83, 13)
        Me.TimerValue.TabIndex = 1
        Me.TimerValue.Text = "No time elapsed"
        Me.TimerValue.Visible = False
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
        'dataView
        '
        Me.dataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.eventID, Me.eventName, Me.riderID, Me.riderName, Me.riderClass, Me.lapNumber, Me.totalTime})
        Me.dataView.FullRowSelect = True
        Me.dataView.GridLines = True
        Me.dataView.Location = New System.Drawing.Point(12, 41)
        Me.dataView.MultiSelect = False
        Me.dataView.Name = "dataView"
        Me.dataView.Size = New System.Drawing.Size(568, 180)
        Me.dataView.TabIndex = 3
        Me.dataView.UseCompatibleStateImageBehavior = False
        Me.dataView.View = System.Windows.Forms.View.Details
        '
        'eventID
        '
        Me.eventID.Text = "Event ID"
        Me.eventID.Width = 80
        '
        'eventName
        '
        Me.eventName.Text = "Event Name"
        Me.eventName.Width = 80
        '
        'riderID
        '
        Me.riderID.Text = "Rider No."
        Me.riderID.Width = 80
        '
        'riderName
        '
        Me.riderName.Text = "Rider Name"
        Me.riderName.Width = 80
        '
        'riderClass
        '
        Me.riderClass.Text = "Rider Class"
        Me.riderClass.Width = 80
        '
        'lapNumber
        '
        Me.lapNumber.Text = "Lap Number"
        Me.lapNumber.Width = 80
        '
        'totalTime
        '
        Me.totalTime.Text = "Total Time"
        Me.totalTime.Width = 80
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(371, 256)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 4
        Me.addButton.Text = "Add Lap"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'riderText
        '
        Me.riderText.Location = New System.Drawing.Point(12, 256)
        Me.riderText.Name = "riderText"
        Me.riderText.Size = New System.Drawing.Size(353, 21)
        Me.riderText.TabIndex = 0
        '
        'testFind
        '
        Me.testFind.Location = New System.Drawing.Point(93, 227)
        Me.testFind.Name = "testFind"
        Me.testFind.Size = New System.Drawing.Size(75, 23)
        Me.testFind.TabIndex = 6
        Me.testFind.Text = "Test Class"
        Me.testFind.UseVisualStyleBackColor = True
        '
        'disclaimerLabel
        '
        Me.disclaimerLabel.AutoSize = True
        Me.disclaimerLabel.Location = New System.Drawing.Point(174, 232)
        Me.disclaimerLabel.Name = "disclaimerLabel"
        Me.disclaimerLabel.Size = New System.Drawing.Size(410, 13)
        Me.disclaimerLabel.TabIndex = 7
        Me.disclaimerLabel.Text = "This row of buttons is for development only and will be absent from release versi" & _
    "ons"
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(452, 256)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(128, 23)
        Me.saveButton.TabIndex = 8
        Me.saveButton.Text = "Complete and Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'Form1
        '
        Me.AcceptButton = Me.addButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 286)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.disclaimerLabel)
        Me.Controls.Add(Me.testFind)
        Me.Controls.Add(Me.riderText)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.dataView)
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
    Friend WithEvents dataView As System.Windows.Forms.ListView
    Friend WithEvents eventID As System.Windows.Forms.ColumnHeader
    Friend WithEvents eventName As System.Windows.Forms.ColumnHeader
    Friend WithEvents riderID As System.Windows.Forms.ColumnHeader
    Friend WithEvents riderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents lapNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents riderText As System.Windows.Forms.TextBox
    Friend WithEvents riderClass As System.Windows.Forms.ColumnHeader
    Friend WithEvents testFind As System.Windows.Forms.Button
    Friend WithEvents disclaimerLabel As System.Windows.Forms.Label
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
