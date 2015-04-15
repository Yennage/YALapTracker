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
        Me.saveButton = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.historyLabel = New System.Windows.Forms.Label()
        Me.changeList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.undoButton = New System.Windows.Forms.Button()
        Me.alterButton = New System.Windows.Forms.Button()
        Me.amendText = New System.Windows.Forms.TextBox()
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
        Me.TimerValue.Size = New System.Drawing.Size(51, 13)
        Me.TimerValue.TabIndex = 1
        Me.TimerValue.Text = "00:00:00"
        '
        'fetchButton
        '
        Me.fetchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fetchButton.Location = New System.Drawing.Point(12, 260)
        Me.fetchButton.Name = "fetchButton"
        Me.fetchButton.Size = New System.Drawing.Size(131, 23)
        Me.fetchButton.TabIndex = 2
        Me.fetchButton.Text = "Load AM Event Data"
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
        Me.dataView.Size = New System.Drawing.Size(568, 213)
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
        Me.addButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addButton.Location = New System.Drawing.Point(371, 287)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 4
        Me.addButton.Text = "Add Lap"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'riderText
        '
        Me.riderText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.riderText.Location = New System.Drawing.Point(12, 289)
        Me.riderText.Name = "riderText"
        Me.riderText.Size = New System.Drawing.Size(353, 21)
        Me.riderText.TabIndex = 0
        '
        'saveButton
        '
        Me.saveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveButton.Location = New System.Drawing.Point(452, 287)
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
        'historyLabel
        '
        Me.historyLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.historyLabel.AutoSize = True
        Me.historyLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.historyLabel.Location = New System.Drawing.Point(12, 325)
        Me.historyLabel.Name = "historyLabel"
        Me.historyLabel.Size = New System.Drawing.Size(84, 13)
        Me.historyLabel.TabIndex = 9
        Me.historyLabel.Text = "Last 5 Inputs:"
        '
        'changeList
        '
        Me.changeList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.changeList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.changeList.FullRowSelect = True
        Me.changeList.GridLines = True
        Me.changeList.Location = New System.Drawing.Point(12, 341)
        Me.changeList.MultiSelect = False
        Me.changeList.Name = "changeList"
        Me.changeList.Size = New System.Drawing.Size(568, 117)
        Me.changeList.TabIndex = 10
        Me.changeList.UseCompatibleStateImageBehavior = False
        Me.changeList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Action"
        Me.ColumnHeader1.Width = 94
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Rider No."
        Me.ColumnHeader2.Width = 94
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Old Lap Count"
        Me.ColumnHeader3.Width = 94
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "New Lap Count"
        Me.ColumnHeader4.Width = 94
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Old Lap Time"
        Me.ColumnHeader5.Width = 94
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "New Lap Time"
        Me.ColumnHeader6.Width = 94
        '
        'undoButton
        '
        Me.undoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.undoButton.Location = New System.Drawing.Point(452, 464)
        Me.undoButton.Name = "undoButton"
        Me.undoButton.Size = New System.Drawing.Size(128, 23)
        Me.undoButton.TabIndex = 11
        Me.undoButton.Text = "Undo Selected"
        Me.undoButton.UseVisualStyleBackColor = True
        '
        'alterButton
        '
        Me.alterButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.alterButton.Enabled = False
        Me.alterButton.Location = New System.Drawing.Point(371, 464)
        Me.alterButton.Name = "alterButton"
        Me.alterButton.Size = New System.Drawing.Size(75, 23)
        Me.alterButton.TabIndex = 12
        Me.alterButton.Text = "Alter Rider"
        Me.alterButton.UseVisualStyleBackColor = True
        '
        'amendText
        '
        Me.amendText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.amendText.Location = New System.Drawing.Point(12, 466)
        Me.amendText.Name = "amendText"
        Me.amendText.Size = New System.Drawing.Size(353, 21)
        Me.amendText.TabIndex = 13
        '
        'Form1
        '
        Me.AcceptButton = Me.addButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 496)
        Me.Controls.Add(Me.amendText)
        Me.Controls.Add(Me.alterButton)
        Me.Controls.Add(Me.undoButton)
        Me.Controls.Add(Me.changeList)
        Me.Controls.Add(Me.historyLabel)
        Me.Controls.Add(Me.saveButton)
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
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents historyLabel As System.Windows.Forms.Label
    Friend WithEvents changeList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents undoButton As System.Windows.Forms.Button
    Friend WithEvents alterButton As System.Windows.Forms.Button
    Friend WithEvents amendText As System.Windows.Forms.TextBox

End Class
