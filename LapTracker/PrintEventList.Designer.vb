<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintEventList
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
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.printButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.amTextbox = New System.Windows.Forms.TextBox()
        Me.pmTextbox = New System.Windows.Forms.TextBox()
        Me.eventList = New System.Windows.Forms.ListBox()
        Me.amClear = New System.Windows.Forms.Button()
        Me.pmClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(505, 396)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 1
        Me.cancelButton.Text = "&Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'printButton
        '
        Me.printButton.Enabled = False
        Me.printButton.Location = New System.Drawing.Point(407, 396)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(92, 23)
        Me.printButton.TabIndex = 2
        Me.printButton.Text = "Print Results"
        Me.printButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Please select the AM and PM events that you would like to print:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 333)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "AM Event:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "PM Event:"
        '
        'amTextbox
        '
        Me.amTextbox.Location = New System.Drawing.Point(75, 330)
        Me.amTextbox.Name = "amTextbox"
        Me.amTextbox.ReadOnly = True
        Me.amTextbox.Size = New System.Drawing.Size(424, 21)
        Me.amTextbox.TabIndex = 6
        '
        'pmTextbox
        '
        Me.pmTextbox.Location = New System.Drawing.Point(75, 369)
        Me.pmTextbox.Name = "pmTextbox"
        Me.pmTextbox.ReadOnly = True
        Me.pmTextbox.Size = New System.Drawing.Size(424, 21)
        Me.pmTextbox.TabIndex = 7
        '
        'eventList
        '
        Me.eventList.FormattingEnabled = True
        Me.eventList.Location = New System.Drawing.Point(12, 25)
        Me.eventList.Name = "eventList"
        Me.eventList.Size = New System.Drawing.Size(568, 290)
        Me.eventList.TabIndex = 8
        '
        'amClear
        '
        Me.amClear.Location = New System.Drawing.Point(505, 328)
        Me.amClear.Name = "amClear"
        Me.amClear.Size = New System.Drawing.Size(75, 23)
        Me.amClear.TabIndex = 9
        Me.amClear.Text = "Clear"
        Me.amClear.UseVisualStyleBackColor = True
        '
        'pmClear
        '
        Me.pmClear.Location = New System.Drawing.Point(505, 367)
        Me.pmClear.Name = "pmClear"
        Me.pmClear.Size = New System.Drawing.Size(75, 23)
        Me.pmClear.TabIndex = 10
        Me.pmClear.Text = "Clear"
        Me.pmClear.UseVisualStyleBackColor = True
        '
        'PrintEventList
        '
        Me.AcceptButton = Me.printButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 426)
        Me.Controls.Add(Me.pmClear)
        Me.Controls.Add(Me.amClear)
        Me.Controls.Add(Me.eventList)
        Me.Controls.Add(Me.pmTextbox)
        Me.Controls.Add(Me.amTextbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PrintEventList"
        Me.Text = "Select the events you wish to print..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents printButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents amTextbox As System.Windows.Forms.TextBox
    Friend WithEvents pmTextbox As System.Windows.Forms.TextBox
    Friend WithEvents eventList As System.Windows.Forms.ListBox
    Friend WithEvents amClear As System.Windows.Forms.Button
    Friend WithEvents pmClear As System.Windows.Forms.Button
End Class
