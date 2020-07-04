<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DupeChecker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ControlsTable = New System.Windows.Forms.TableLayoutPanel()
        Me.ControlsPanel = New System.Windows.Forms.Panel()
        Me.MarkFilesWithDupes = New System.Windows.Forms.Button()
        Me.FindDupeNames = New System.Windows.Forms.Button()
        Me.FindDupesButton = New System.Windows.Forms.Button()
        Me.RegexFilterInput = New System.Windows.Forms.TextBox()
        Me.RegexInputLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MasterDirTextBox = New System.Windows.Forms.TextBox()
        Me.TargetDirTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SelectTargetDirButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.DoRecursiveTarget = New System.Windows.Forms.CheckBox()
        Me.TargetIsSameAsMaster = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TargetFilesView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FileRightClickContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KeepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DontKeepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearStatusMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterFilesView = New System.Windows.Forms.ListView()
        Me.FilenameHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HashHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KeepStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DoRecursiveMaster = New System.Windows.Forms.CheckBox()
        Me.ExecuteMasterDupes = New System.Windows.Forms.Button()
        Me.SelectMasterDirButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.MediaViewer1 = New SortWare.MediaViewer()
        Me.TypeSelector1 = New SortWare.TypeSelector()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ControlsTable.SuspendLayout()
        Me.ControlsPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FileRightClickContextMenu.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ControlsTable, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MasterDirTextBox, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TargetDirTextBox, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TypeSelector1, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
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
        Me.ControlsTable.Location = New System.Drawing.Point(650, 90)
        Me.ControlsTable.Margin = New System.Windows.Forms.Padding(0)
        Me.ControlsTable.Name = "ControlsTable"
        Me.ControlsTable.RowCount = 2
        Me.ControlsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ControlsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ControlsTable.Size = New System.Drawing.Size(150, 338)
        Me.ControlsTable.TabIndex = 5
        '
        'ControlsPanel
        '
        Me.ControlsPanel.Controls.Add(Me.MarkFilesWithDupes)
        Me.ControlsPanel.Controls.Add(Me.FindDupeNames)
        Me.ControlsPanel.Controls.Add(Me.FindDupesButton)
        Me.ControlsPanel.Controls.Add(Me.RegexFilterInput)
        Me.ControlsPanel.Controls.Add(Me.RegexInputLabel)
        Me.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlsPanel.Location = New System.Drawing.Point(3, 3)
        Me.ControlsPanel.Name = "ControlsPanel"
        Me.ControlsPanel.Size = New System.Drawing.Size(144, 163)
        Me.ControlsPanel.TabIndex = 0
        '
        'MarkFilesWithDupes
        '
        Me.MarkFilesWithDupes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MarkFilesWithDupes.Location = New System.Drawing.Point(0, 140)
        Me.MarkFilesWithDupes.Name = "MarkFilesWithDupes"
        Me.MarkFilesWithDupes.Size = New System.Drawing.Size(144, 23)
        Me.MarkFilesWithDupes.TabIndex = 0
        Me.MarkFilesWithDupes.Text = "Mark Files With Dupes"
        Me.MarkFilesWithDupes.UseVisualStyleBackColor = True
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
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 172)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 163)
        Me.Panel1.TabIndex = 1
        '
        'MasterDirTextBox
        '
        Me.MasterDirTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MasterDirTextBox.Location = New System.Drawing.Point(3, 63)
        Me.MasterDirTextBox.Name = "MasterDirTextBox"
        Me.MasterDirTextBox.Size = New System.Drawing.Size(319, 20)
        Me.MasterDirTextBox.TabIndex = 8
        '
        'TargetDirTextBox
        '
        Me.TargetDirTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TargetDirTextBox.Location = New System.Drawing.Point(328, 63)
        Me.TargetDirTextBox.Name = "TargetDirTextBox"
        Me.TargetDirTextBox.Size = New System.Drawing.Size(319, 20)
        Me.TargetDirTextBox.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SelectTargetDirButton)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(325, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 60)
        Me.Panel2.TabIndex = 10
        '
        'SelectTargetDirButton
        '
        Me.SelectTargetDirButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SelectTargetDirButton.Location = New System.Drawing.Point(0, 0)
        Me.SelectTargetDirButton.Name = "SelectTargetDirButton"
        Me.SelectTargetDirButton.Size = New System.Drawing.Size(80, 60)
        Me.SelectTargetDirButton.TabIndex = 7
        Me.SelectTargetDirButton.Text = "Select Target Directory"
        Me.SelectTargetDirButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.DoRecursiveTarget, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TargetIsSameAsMaster, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(157, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(168, 60)
        Me.TableLayoutPanel4.TabIndex = 9
        '
        'DoRecursiveTarget
        '
        Me.DoRecursiveTarget.AutoSize = True
        Me.DoRecursiveTarget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DoRecursiveTarget.Location = New System.Drawing.Point(3, 33)
        Me.DoRecursiveTarget.Name = "DoRecursiveTarget"
        Me.DoRecursiveTarget.Size = New System.Drawing.Size(162, 24)
        Me.DoRecursiveTarget.TabIndex = 9
        Me.DoRecursiveTarget.Text = "Search recursively?"
        Me.DoRecursiveTarget.UseVisualStyleBackColor = True
        '
        'TargetIsSameAsMaster
        '
        Me.TargetIsSameAsMaster.AutoSize = True
        Me.TargetIsSameAsMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TargetIsSameAsMaster.Location = New System.Drawing.Point(3, 3)
        Me.TargetIsSameAsMaster.Name = "TargetIsSameAsMaster"
        Me.TargetIsSameAsMaster.Size = New System.Drawing.Size(162, 24)
        Me.TargetIsSameAsMaster.TabIndex = 8
        Me.TargetIsSameAsMaster.Text = "Same as master directory?"
        Me.TargetIsSameAsMaster.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TargetFilesView, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.MasterFilesView, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.MediaViewer1, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 93)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(644, 332)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'TargetFilesView
        '
        Me.TargetFilesView.CheckBoxes = True
        Me.TargetFilesView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.TargetFilesView.ContextMenuStrip = Me.FileRightClickContextMenu
        Me.TargetFilesView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TargetFilesView.HideSelection = False
        Me.TargetFilesView.Location = New System.Drawing.Point(325, 3)
        Me.TargetFilesView.Name = "TargetFilesView"
        Me.TargetFilesView.Size = New System.Drawing.Size(316, 164)
        Me.TargetFilesView.TabIndex = 2
        Me.TargetFilesView.UseCompatibleStateImageBehavior = False
        Me.TargetFilesView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Filename"
        Me.ColumnHeader1.Width = 191
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Hash"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Keeping?"
        '
        'FileRightClickContextMenu
        '
        Me.FileRightClickContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeepToolStripMenuItem, Me.DontKeepToolStripMenuItem, Me.ClearStatusMenuItem})
        Me.FileRightClickContextMenu.Name = "ContextMenuStrip1"
        Me.FileRightClickContextMenu.Size = New System.Drawing.Size(166, 70)
        '
        'KeepToolStripMenuItem
        '
        Me.KeepToolStripMenuItem.Name = "KeepToolStripMenuItem"
        Me.KeepToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.KeepToolStripMenuItem.Text = "Mark As Keep"
        '
        'DontKeepToolStripMenuItem
        '
        Me.DontKeepToolStripMenuItem.Name = "DontKeepToolStripMenuItem"
        Me.DontKeepToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DontKeepToolStripMenuItem.Text = "Mark As Discard"
        '
        'ClearStatusMenuItem
        '
        Me.ClearStatusMenuItem.Name = "ClearStatusMenuItem"
        Me.ClearStatusMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ClearStatusMenuItem.Text = "Clear Keep Status"
        '
        'MasterFilesView
        '
        Me.MasterFilesView.CheckBoxes = True
        Me.MasterFilesView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FilenameHeader, Me.HashHeader, Me.KeepStatus})
        Me.MasterFilesView.ContextMenuStrip = Me.FileRightClickContextMenu
        Me.MasterFilesView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MasterFilesView.HideSelection = False
        Me.MasterFilesView.Location = New System.Drawing.Point(3, 3)
        Me.MasterFilesView.Name = "MasterFilesView"
        Me.MasterFilesView.Size = New System.Drawing.Size(316, 164)
        Me.MasterFilesView.TabIndex = 0
        Me.MasterFilesView.UseCompatibleStateImageBehavior = False
        Me.MasterFilesView.View = System.Windows.Forms.View.Details
        '
        'FilenameHeader
        '
        Me.FilenameHeader.Text = "Filename"
        Me.FilenameHeader.Width = 191
        '
        'HashHeader
        '
        Me.HashHeader.Text = "Hash"
        '
        'KeepStatus
        '
        Me.KeepStatus.Text = "Keeping?"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DoRecursiveMaster)
        Me.Panel3.Controls.Add(Me.ExecuteMasterDupes)
        Me.Panel3.Controls.Add(Me.SelectMasterDirButton)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(325, 60)
        Me.Panel3.TabIndex = 11
        '
        'DoRecursiveMaster
        '
        Me.DoRecursiveMaster.AutoSize = True
        Me.DoRecursiveMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DoRecursiveMaster.Location = New System.Drawing.Point(80, 23)
        Me.DoRecursiveMaster.Name = "DoRecursiveMaster"
        Me.DoRecursiveMaster.Size = New System.Drawing.Size(245, 37)
        Me.DoRecursiveMaster.TabIndex = 10
        Me.DoRecursiveMaster.Text = "Search recursively?"
        Me.DoRecursiveMaster.UseVisualStyleBackColor = True
        '
        'ExecuteMasterDupes
        '
        Me.ExecuteMasterDupes.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExecuteMasterDupes.Location = New System.Drawing.Point(80, 0)
        Me.ExecuteMasterDupes.Name = "ExecuteMasterDupes"
        Me.ExecuteMasterDupes.Size = New System.Drawing.Size(245, 23)
        Me.ExecuteMasterDupes.TabIndex = 7
        Me.ExecuteMasterDupes.Text = "Execute Master Dir Decimation"
        Me.ExecuteMasterDupes.UseVisualStyleBackColor = True
        '
        'SelectMasterDirButton
        '
        Me.SelectMasterDirButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SelectMasterDirButton.Location = New System.Drawing.Point(0, 0)
        Me.SelectMasterDirButton.Name = "SelectMasterDirButton"
        Me.SelectMasterDirButton.Size = New System.Drawing.Size(80, 60)
        Me.SelectMasterDirButton.TabIndex = 6
        Me.SelectMasterDirButton.Text = "Select Master Directory"
        Me.SelectMasterDirButton.UseVisualStyleBackColor = True
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
        Me.StatusLabel.Size = New System.Drawing.Size(119, 17)
        Me.StatusLabel.Text = "ToolStripStatusLabel1"
        '
        'MediaViewer1
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.MediaViewer1, 2)
        Me.MediaViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaViewer1.Location = New System.Drawing.Point(3, 173)
        Me.MediaViewer1.Name = "MediaViewer1"
        Me.MediaViewer1.Size = New System.Drawing.Size(638, 156)
        Me.MediaViewer1.TabIndex = 3
        '
        'TypeSelector1
        '
        Me.TypeSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TypeSelector1.Location = New System.Drawing.Point(653, 3)
        Me.TypeSelector1.Name = "TypeSelector1"
        Me.TableLayoutPanel1.SetRowSpan(Me.TypeSelector1, 2)
        Me.TypeSelector1.Size = New System.Drawing.Size(144, 84)
        Me.TypeSelector1.TabIndex = 12
        '
        'DupeChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "DupeChecker"
        Me.Text = "CheckDupes"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ControlsTable.ResumeLayout(False)
        Me.ControlsPanel.ResumeLayout(False)
        Me.ControlsPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.FileRightClickContextMenu.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar As ToolStripProgressBar
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents ControlsTable As TableLayoutPanel
    Friend WithEvents ControlsPanel As Panel
    Friend WithEvents FindDupeNames As Button
    Friend WithEvents FindDupesButton As Button
    Friend WithEvents RegexFilterInput As TextBox
    Friend WithEvents RegexInputLabel As Label
    Friend WithEvents MarkFilesWithDupes As Button
    Friend WithEvents SelectTargetDirButton As Button
    Friend WithEvents SelectMasterDirButton As Button
    Friend WithEvents MasterDirTextBox As TextBox
    Friend WithEvents TargetDirTextBox As TextBox
    Friend WithEvents TargetIsSameAsMaster As CheckBox
    Friend WithEvents MasterFilesView As ListView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TargetFilesView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents DirectoryEntry1 As DirectoryServices.DirectoryEntry
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DoRecursiveTarget As CheckBox
    Friend WithEvents FilenameHeader As ColumnHeader
    Friend WithEvents HashHeader As ColumnHeader
    Friend WithEvents MediaViewer1 As MediaViewer
    Friend WithEvents KeepStatus As ColumnHeader
    Friend WithEvents FileRightClickContextMenu As ContextMenuStrip
    Friend WithEvents KeepToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ExecuteMasterDupes As Button
    Friend WithEvents TypeSelector1 As SortWare.TypeSelector
    Friend WithEvents DoRecursiveMaster As CheckBox
    Friend WithEvents ClearStatusMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents DontKeepToolStripMenuItem As ToolStripMenuItem
End Class
