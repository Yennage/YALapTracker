<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageRiders
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.riderNumber = New System.Windows.Forms.TextBox()
        Me.riderName = New System.Windows.Forms.TextBox()
        Me.riderClass = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.addClass = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.deleteRider = New System.Windows.Forms.Button()
        Me.riderList = New System.Windows.Forms.ListView()
        Me.riderNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ridersName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ridersClass = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.textTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Rider No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 345)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Rider Name:"
        '
        'riderNumber
        '
        Me.riderNumber.Location = New System.Drawing.Point(84, 315)
        Me.riderNumber.Name = "riderNumber"
        Me.riderNumber.Size = New System.Drawing.Size(496, 21)
        Me.riderNumber.TabIndex = 12
        '
        'riderName
        '
        Me.riderName.Location = New System.Drawing.Point(84, 342)
        Me.riderName.Name = "riderName"
        Me.riderName.Size = New System.Drawing.Size(496, 21)
        Me.riderName.TabIndex = 13
        '
        'riderClass
        '
        Me.riderClass.FormattingEnabled = True
        Me.riderClass.Location = New System.Drawing.Point(84, 369)
        Me.riderClass.Name = "riderClass"
        Me.riderClass.Size = New System.Drawing.Size(384, 21)
        Me.riderClass.TabIndex = 14
        Me.riderClass.Text = "Select a rider class..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Class:"
        '
        'addClass
        '
        Me.addClass.Location = New System.Drawing.Point(474, 367)
        Me.addClass.Name = "addClass"
        Me.addClass.Size = New System.Drawing.Size(106, 23)
        Me.addClass.TabIndex = 16
        Me.addClass.Text = "Add New Class"
        Me.addClass.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(505, 407)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 17
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'addButton
        '
        Me.addButton.Enabled = False
        Me.addButton.Location = New System.Drawing.Point(424, 407)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 18
        Me.addButton.Text = "Add Rider"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'deleteRider
        '
        Me.deleteRider.Location = New System.Drawing.Point(12, 407)
        Me.deleteRider.Name = "deleteRider"
        Me.deleteRider.Size = New System.Drawing.Size(115, 23)
        Me.deleteRider.TabIndex = 19
        Me.deleteRider.Text = "Remove Selected"
        Me.deleteRider.UseVisualStyleBackColor = True
        '
        'riderList
        '
        Me.riderList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.riderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.riderNo, Me.ridersName, Me.ridersClass})
        Me.riderList.FullRowSelect = True
        Me.riderList.GridLines = True
        Me.riderList.Location = New System.Drawing.Point(12, 12)
        Me.riderList.MultiSelect = False
        Me.riderList.Name = "riderList"
        Me.riderList.Size = New System.Drawing.Size(568, 297)
        Me.riderList.TabIndex = 20
        Me.riderList.UseCompatibleStateImageBehavior = False
        Me.riderList.View = System.Windows.Forms.View.Details
        '
        'riderNo
        '
        Me.riderNo.Text = "Rider No."
        Me.riderNo.Width = 80
        '
        'ridersName
        '
        Me.ridersName.Text = "Rider Name"
        Me.ridersName.Width = 250
        '
        'ridersClass
        '
        Me.ridersClass.Text = "Rider Class"
        Me.ridersClass.Width = 200
        '
        'textTooltip
        '
        Me.textTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.textTooltip.ToolTipTitle = "Invalid Character"
        '
        'ManageRiders
        '
        Me.AcceptButton = Me.addButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 440)
        Me.Controls.Add(Me.riderList)
        Me.Controls.Add(Me.deleteRider)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.addClass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.riderClass)
        Me.Controls.Add(Me.riderName)
        Me.Controls.Add(Me.riderNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ManageRiders"
        Me.Text = "Add or remove riders..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents riderNumber As System.Windows.Forms.TextBox
    Friend WithEvents riderName As System.Windows.Forms.TextBox
    Friend WithEvents riderClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents addClass As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents deleteRider As System.Windows.Forms.Button
    Friend WithEvents riderList As System.Windows.Forms.ListView
    Friend WithEvents riderNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ridersName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ridersClass As System.Windows.Forms.ColumnHeader
    Friend WithEvents textTooltip As System.Windows.Forms.ToolTip
End Class
