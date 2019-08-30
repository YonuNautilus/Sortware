<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckDupes
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ControlsTable = New System.Windows.Forms.TableLayoutPanel()
        Me.ControlsPanel = New System.Windows.Forms.Panel()
        Me.FindDupeNames = New System.Windows.Forms.Button()
        Me.FindDupesButton = New System.Windows.Forms.Button()
        Me.RegexFilterInput = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RegexInputLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MarkFilesWithDupes = New System.Windows.Forms.Button()
        Me.DelFilesView = New System.Windows.Forms.ListView()
        Me.Filename = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Hash = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KeepFilesView = New System.Windows.Forms.ListView()
        Me.File = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MD5Hash = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ControlsTable.SuspendLayout()
        Me.ControlsPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ControlsTable, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DelFilesView, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.KeepFilesView, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 428)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ControlsTable
        '
        Me.ControlsTable.ColumnCount = 1
        Me.ControlsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ControlsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ControlsTable.Controls.Add(Me.ControlsPanel, 0, 0)
        Me.ControlsTable.Controls.Add(Me.Panel1, 0, 1)
        Me.ControlsTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlsTable.Location = New System.Drawing.Point(650, 0)
        Me.ControlsTable.Margin = New System.Windows.Forms.Padding(0)
        Me.ControlsTable.Name = "ControlsTable"
        Me.ControlsTable.RowCount = 2
        Me.ControlsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ControlsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ControlsTable.Size = New System.Drawing.Size(150, 428)
        Me.ControlsTable.TabIndex = 5
        '
        'ControlsPanel
        '
        Me.ControlsPanel.Controls.Add(Me.FindDupeNames)
        Me.ControlsPanel.Controls.Add(Me.FindDupesButton)
        Me.ControlsPanel.Controls.Add(Me.RegexFilterInput)
        Me.ControlsPanel.Controls.Add(Me.Button1)
        Me.ControlsPanel.Controls.Add(Me.RegexInputLabel)
        Me.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlsPanel.Location = New System.Drawing.Point(3, 3)
        Me.ControlsPanel.Name = "ControlsPanel"
        Me.ControlsPanel.Size = New System.Drawing.Size(144, 208)
        Me.ControlsPanel.TabIndex = 0
        '
        'FindDupeNames
        '
        Me.FindDupeNames.Dock = System.Windows.Forms.DockStyle.Top
        Me.FindDupeNames.Location = New System.Drawing.Point(0, 62)
        Me.FindDupeNames.Name = "FindDupeNames"
        Me.FindDupeNames.Size = New System.Drawing.Size(144, 23)
        Me.FindDupeNames.TabIndex = 4
        Me.FindDupeNames.Text = "Find Dupes By Name"
        Me.FindDupeNames.UseVisualStyleBackColor = True
        '
        'FindDupesButton
        '
        Me.FindDupesButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.FindDupesButton.Location = New System.Drawing.Point(0, 39)
        Me.FindDupesButton.Name = "FindDupesButton"
        Me.FindDupesButton.Size = New System.Drawing.Size(144, 23)
        Me.FindDupesButton.TabIndex = 3
        Me.FindDupesButton.Text = "Find Dupes"
        Me.FindDupesButton.UseVisualStyleBackColor = True
        '
        'RegexFilterInput
        '
        Me.RegexFilterInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.RegexFilterInput.Location = New System.Drawing.Point(0, 19)
        Me.RegexFilterInput.Name = "RegexFilterInput"
        Me.RegexFilterInput.Size = New System.Drawing.Size(144, 20)
        Me.RegexFilterInput.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button1.Location = New System.Drawing.Point(0, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RegexInputLabel
        '
        Me.RegexInputLabel.AutoSize = True
        Me.RegexInputLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.RegexInputLabel.Location = New System.Drawing.Point(0, 0)
        Me.RegexInputLabel.Name = "RegexInputLabel"
        Me.RegexInputLabel.Padding = New System.Windows.Forms.Padding(3)
        Me.RegexInputLabel.Size = New System.Drawing.Size(120, 19)
        Me.RegexInputLabel.TabIndex = 2
        Me.RegexInputLabel.Text = "Filename Filter (Regex)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MarkFilesWithDupes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 217)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 208)
        Me.Panel1.TabIndex = 1
        '
        'MarkFilesWithDupes
        '
        Me.MarkFilesWithDupes.Dock = System.Windows.Forms.DockStyle.Top
        Me.MarkFilesWithDupes.Location = New System.Drawing.Point(0, 0)
        Me.MarkFilesWithDupes.Name = "MarkFilesWithDupes"
        Me.MarkFilesWithDupes.Size = New System.Drawing.Size(144, 23)
        Me.MarkFilesWithDupes.TabIndex = 0
        Me.MarkFilesWithDupes.Text = "Mark Files With Dupes"
        Me.MarkFilesWithDupes.UseVisualStyleBackColor = True
        '
        'DelFilesView
        '
        Me.DelFilesView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Filename, Me.Hash})
        Me.DelFilesView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DelFilesView.Location = New System.Drawing.Point(328, 3)
        Me.DelFilesView.Name = "DelFilesView"
        Me.DelFilesView.Size = New System.Drawing.Size(319, 422)
        Me.DelFilesView.TabIndex = 2
        Me.DelFilesView.UseCompatibleStateImageBehavior = False
        Me.DelFilesView.View = System.Windows.Forms.View.Details
        '
        'Filename
        '
        Me.Filename.Text = "Filename"
        Me.Filename.Width = 255
        '
        'Hash
        '
        Me.Hash.Text = "Hash"
        '
        'KeepFilesView
        '
        Me.KeepFilesView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.File, Me.MD5Hash})
        Me.KeepFilesView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KeepFilesView.Location = New System.Drawing.Point(3, 3)
        Me.KeepFilesView.Name = "KeepFilesView"
        Me.KeepFilesView.Size = New System.Drawing.Size(319, 422)
        Me.KeepFilesView.TabIndex = 1
        Me.KeepFilesView.UseCompatibleStateImageBehavior = False
        Me.KeepFilesView.View = System.Windows.Forms.View.Details
        '
        'File
        '
        Me.File.Text = "Filename"
        Me.File.Width = 255
        '
        'MD5Hash
        '
        Me.MD5Hash.Text = "Hash"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(120, 17)
        Me.StatusLabel.Text = "ToolStripStatusLabel1"
        '
        'CheckDupes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "CheckDupes"
        Me.Text = "CheckDupes"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ControlsTable.ResumeLayout(False)
        Me.ControlsPanel.ResumeLayout(False)
        Me.ControlsPanel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DelFilesView As ListView
    Friend WithEvents KeepFilesView As ListView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar As ToolStripProgressBar
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents File As ColumnHeader
    Friend WithEvents MD5Hash As ColumnHeader
    Friend WithEvents Filename As ColumnHeader
    Friend WithEvents Hash As ColumnHeader
    Friend WithEvents ControlsTable As TableLayoutPanel
    Friend WithEvents ControlsPanel As Panel
    Friend WithEvents FindDupeNames As Button
    Friend WithEvents FindDupesButton As Button
    Friend WithEvents RegexFilterInput As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents RegexInputLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MarkFilesWithDupes As Button
End Class
