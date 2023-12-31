﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SortSettingsDialog
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Root Directory")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Main Directories")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Presorted Directories")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Blocked Directories")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Conversion Directories")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finished Conversions Directory")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SortSettingsDialog))
        Me.FinishedButton = New System.Windows.Forms.Button()
        Me.SettingsViewer = New System.Windows.Forms.RichTextBox()
        Me.InitializeSettings = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TagsButtonGroup = New System.Windows.Forms.GroupBox()
        Me.TagViewerPanel = New System.Windows.Forms.Panel()
        Me.TagsViewer = New System.Windows.Forms.ListBox()
        Me.TagsSaveButton = New System.Windows.Forms.Button()
        Me.RemoveTagButton = New System.Windows.Forms.Button()
        Me.TagEntryTable = New System.Windows.Forms.TableLayoutPanel()
        Me.TagDescEntry = New System.Windows.Forms.TextBox()
        Me.TagIDEntry = New System.Windows.Forms.TextBox()
        Me.AddTagButton = New System.Windows.Forms.Button()
        Me.AddButtonGroup = New System.Windows.Forms.GroupBox()
        Me.removeDir = New System.Windows.Forms.Button()
        Me.addFinishedDir = New System.Windows.Forms.Button()
        Me.addConvertDir = New System.Windows.Forms.Button()
        Me.addPresortDir = New System.Windows.Forms.Button()
        Me.addBlockedDir = New System.Windows.Forms.Button()
        Me.addMainSubdir = New System.Windows.Forms.Button()
        Me.addMainDir = New System.Windows.Forms.Button()
        Me.addRootDir = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ErrorTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RootDirViewTree = New System.Windows.Forms.TreeView()
        Me.SettingsTreeView = New System.Windows.Forms.TreeView()
        Me.DirErrorGroup = New System.Windows.Forms.GroupBox()
        Me.PrevErrorButton = New System.Windows.Forms.Button()
        Me.NextErrorButton = New System.Windows.Forms.Button()
        Me.TagsButtonGroup.SuspendLayout()
        Me.TagViewerPanel.SuspendLayout()
        Me.TagEntryTable.SuspendLayout()
        Me.AddButtonGroup.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.DirErrorGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'FinishedButton
        '
        Me.FinishedButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FinishedButton.Location = New System.Drawing.Point(108, 479)
        Me.FinishedButton.Name = "FinishedButton"
        Me.FinishedButton.Size = New System.Drawing.Size(73, 23)
        Me.FinishedButton.TabIndex = 2
        Me.FinishedButton.Text = "Done"
        Me.FinishedButton.UseVisualStyleBackColor = True
        '
        'SettingsViewer
        '
        Me.SettingsViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsViewer.Location = New System.Drawing.Point(650, 3)
        Me.SettingsViewer.Name = "SettingsViewer"
        Me.SettingsViewer.Size = New System.Drawing.Size(147, 505)
        Me.SettingsViewer.TabIndex = 3
        Me.SettingsViewer.Text = ""
        '
        'InitializeSettings
        '
        Me.InitializeSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.InitializeSettings.Enabled = False
        Me.InitializeSettings.Location = New System.Drawing.Point(3, 450)
        Me.InitializeSettings.Name = "InitializeSettings"
        Me.InitializeSettings.Size = New System.Drawing.Size(92, 52)
        Me.InitializeSettings.TabIndex = 4
        Me.InitializeSettings.Text = "Initialize .sortSettings File"
        Me.ToolTip1.SetToolTip(Me.InitializeSettings, "If no .sortSettings file is found, clicking this button will create one in the se" &
        "lected root directory")
        Me.InitializeSettings.UseVisualStyleBackColor = True
        '
        'TagsButtonGroup
        '
        Me.TagsButtonGroup.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TagsButtonGroup.AutoSize = True
        Me.TagsButtonGroup.Controls.Add(Me.TagViewerPanel)
        Me.TagsButtonGroup.Controls.Add(Me.RemoveTagButton)
        Me.TagsButtonGroup.Controls.Add(Me.TagEntryTable)
        Me.TagsButtonGroup.Controls.Add(Me.AddTagButton)
        Me.TagsButtonGroup.Location = New System.Drawing.Point(5, 212)
        Me.TagsButtonGroup.Name = "TagsButtonGroup"
        Me.TagsButtonGroup.Size = New System.Drawing.Size(176, 146)
        Me.TagsButtonGroup.TabIndex = 13
        Me.TagsButtonGroup.TabStop = False
        Me.TagsButtonGroup.Text = "Add Tags to Sort Directory"
        '
        'TagViewerPanel
        '
        Me.TagViewerPanel.Controls.Add(Me.TagsViewer)
        Me.TagViewerPanel.Controls.Add(Me.TagsSaveButton)
        Me.TagViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagViewerPanel.Location = New System.Drawing.Point(3, 82)
        Me.TagViewerPanel.Name = "TagViewerPanel"
        Me.TagViewerPanel.Size = New System.Drawing.Size(170, 61)
        Me.TagViewerPanel.TabIndex = 14
        '
        'TagsViewer
        '
        Me.TagsViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagsViewer.FormattingEnabled = True
        Me.TagsViewer.Location = New System.Drawing.Point(0, 0)
        Me.TagsViewer.Name = "TagsViewer"
        Me.TagsViewer.Size = New System.Drawing.Size(120, 61)
        Me.TagsViewer.TabIndex = 2
        '
        'TagsSaveButton
        '
        Me.TagsSaveButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.TagsSaveButton.Location = New System.Drawing.Point(120, 0)
        Me.TagsSaveButton.Name = "TagsSaveButton"
        Me.TagsSaveButton.Size = New System.Drawing.Size(50, 61)
        Me.TagsSaveButton.TabIndex = 1
        Me.TagsSaveButton.UseVisualStyleBackColor = True
        '
        'RemoveTagButton
        '
        Me.RemoveTagButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.RemoveTagButton.Location = New System.Drawing.Point(3, 59)
        Me.RemoveTagButton.Name = "RemoveTagButton"
        Me.RemoveTagButton.Size = New System.Drawing.Size(170, 23)
        Me.RemoveTagButton.TabIndex = 12
        Me.RemoveTagButton.Text = "<< Remove Tag"
        Me.RemoveTagButton.UseVisualStyleBackColor = True
        '
        'TagEntryTable
        '
        Me.TagEntryTable.ColumnCount = 2
        Me.TagEntryTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.63743!))
        Me.TagEntryTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.36257!))
        Me.TagEntryTable.Controls.Add(Me.TagDescEntry, 1, 0)
        Me.TagEntryTable.Controls.Add(Me.TagIDEntry, 0, 0)
        Me.TagEntryTable.Dock = System.Windows.Forms.DockStyle.Top
        Me.TagEntryTable.Location = New System.Drawing.Point(3, 39)
        Me.TagEntryTable.Name = "TagEntryTable"
        Me.TagEntryTable.RowCount = 1
        Me.TagEntryTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TagEntryTable.Size = New System.Drawing.Size(170, 20)
        Me.TagEntryTable.TabIndex = 13
        '
        'TagDescEntry
        '
        Me.TagDescEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagDescEntry.Location = New System.Drawing.Point(36, 0)
        Me.TagDescEntry.Margin = New System.Windows.Forms.Padding(0)
        Me.TagDescEntry.Name = "TagDescEntry"
        Me.TagDescEntry.Size = New System.Drawing.Size(134, 20)
        Me.TagDescEntry.TabIndex = 1
        '
        'TagIDEntry
        '
        Me.TagIDEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagIDEntry.Location = New System.Drawing.Point(0, 0)
        Me.TagIDEntry.Margin = New System.Windows.Forms.Padding(0)
        Me.TagIDEntry.Name = "TagIDEntry"
        Me.TagIDEntry.Size = New System.Drawing.Size(36, 20)
        Me.TagIDEntry.TabIndex = 0
        '
        'AddTagButton
        '
        Me.AddTagButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.AddTagButton.Location = New System.Drawing.Point(3, 16)
        Me.AddTagButton.Name = "AddTagButton"
        Me.AddTagButton.Size = New System.Drawing.Size(170, 23)
        Me.AddTagButton.TabIndex = 8
        Me.AddTagButton.Text = "Add Tag >>"
        Me.AddTagButton.UseVisualStyleBackColor = True
        '
        'AddButtonGroup
        '
        Me.AddButtonGroup.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.AddButtonGroup.AutoSize = True
        Me.AddButtonGroup.Controls.Add(Me.removeDir)
        Me.AddButtonGroup.Controls.Add(Me.addFinishedDir)
        Me.AddButtonGroup.Controls.Add(Me.addConvertDir)
        Me.AddButtonGroup.Controls.Add(Me.addPresortDir)
        Me.AddButtonGroup.Controls.Add(Me.addBlockedDir)
        Me.AddButtonGroup.Controls.Add(Me.addMainSubdir)
        Me.AddButtonGroup.Controls.Add(Me.addMainDir)
        Me.AddButtonGroup.Controls.Add(Me.addRootDir)
        Me.AddButtonGroup.Location = New System.Drawing.Point(5, 3)
        Me.AddButtonGroup.Name = "AddButtonGroup"
        Me.AddButtonGroup.Size = New System.Drawing.Size(177, 203)
        Me.AddButtonGroup.TabIndex = 12
        Me.AddButtonGroup.TabStop = False
        Me.AddButtonGroup.Text = "Add Directories to Sort Settings"
        '
        'removeDir
        '
        Me.removeDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.removeDir.Location = New System.Drawing.Point(3, 177)
        Me.removeDir.Name = "removeDir"
        Me.removeDir.Size = New System.Drawing.Size(171, 23)
        Me.removeDir.TabIndex = 12
        Me.removeDir.Text = "<< Remove Directory"
        Me.removeDir.UseVisualStyleBackColor = True
        '
        'addFinishedDir
        '
        Me.addFinishedDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addFinishedDir.Location = New System.Drawing.Point(3, 154)
        Me.addFinishedDir.Name = "addFinishedDir"
        Me.addFinishedDir.Size = New System.Drawing.Size(171, 23)
        Me.addFinishedDir.TabIndex = 15
        Me.addFinishedDir.Text = "Finished Files Directory >>"
        Me.addFinishedDir.UseVisualStyleBackColor = True
        '
        'addConvertDir
        '
        Me.addConvertDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addConvertDir.Location = New System.Drawing.Point(3, 131)
        Me.addConvertDir.Name = "addConvertDir"
        Me.addConvertDir.Size = New System.Drawing.Size(171, 23)
        Me.addConvertDir.TabIndex = 14
        Me.addConvertDir.Text = "Convert Directory >>"
        Me.addConvertDir.UseVisualStyleBackColor = True
        '
        'addPresortDir
        '
        Me.addPresortDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addPresortDir.Location = New System.Drawing.Point(3, 108)
        Me.addPresortDir.Name = "addPresortDir"
        Me.addPresortDir.Size = New System.Drawing.Size(171, 23)
        Me.addPresortDir.TabIndex = 11
        Me.addPresortDir.Text = "Pre-sort Directory >>"
        Me.addPresortDir.UseVisualStyleBackColor = True
        '
        'addBlockedDir
        '
        Me.addBlockedDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addBlockedDir.Location = New System.Drawing.Point(3, 85)
        Me.addBlockedDir.Name = "addBlockedDir"
        Me.addBlockedDir.Size = New System.Drawing.Size(171, 23)
        Me.addBlockedDir.TabIndex = 10
        Me.addBlockedDir.Text = "Blocked Directory >>"
        Me.addBlockedDir.UseVisualStyleBackColor = True
        '
        'addMainSubdir
        '
        Me.addMainSubdir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addMainSubdir.Location = New System.Drawing.Point(3, 62)
        Me.addMainSubdir.Name = "addMainSubdir"
        Me.addMainSubdir.Size = New System.Drawing.Size(171, 23)
        Me.addMainSubdir.TabIndex = 13
        Me.addMainSubdir.Text = "Main Subdirectory >>"
        Me.addMainSubdir.UseVisualStyleBackColor = True
        '
        'addMainDir
        '
        Me.addMainDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addMainDir.Location = New System.Drawing.Point(3, 39)
        Me.addMainDir.Name = "addMainDir"
        Me.addMainDir.Size = New System.Drawing.Size(171, 23)
        Me.addMainDir.TabIndex = 9
        Me.addMainDir.Text = "Main Directory >>"
        Me.addMainDir.UseVisualStyleBackColor = True
        '
        'addRootDir
        '
        Me.addRootDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addRootDir.Location = New System.Drawing.Point(3, 16)
        Me.addRootDir.Name = "addRootDir"
        Me.addRootDir.Size = New System.Drawing.Size(171, 23)
        Me.addRootDir.TabIndex = 8
        Me.addRootDir.Text = "Root Directory >>"
        Me.addRootDir.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveButton.Location = New System.Drawing.Point(108, 450)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(73, 23)
        Me.SaveButton.TabIndex = 7
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 511)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'ErrorTimer
        '
        Me.ErrorTimer.Interval = 5000
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.SettingsViewer, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.SettingsTreeView, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(800, 511)
        Me.TableLayoutPanel2.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DirErrorGroup)
        Me.Panel1.Controls.Add(Me.SaveButton)
        Me.Panel1.Controls.Add(Me.TagsButtonGroup)
        Me.Panel1.Controls.Add(Me.FinishedButton)
        Me.Panel1.Controls.Add(Me.InitializeSettings)
        Me.Panel1.Controls.Add(Me.AddButtonGroup)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(308, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 505)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RootDirViewTree)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(299, 505)
        Me.Panel2.TabIndex = 7
        '
        'RootDirViewTree
        '
        Me.RootDirViewTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootDirViewTree.Location = New System.Drawing.Point(0, 0)
        Me.RootDirViewTree.Name = "RootDirViewTree"
        Me.RootDirViewTree.Size = New System.Drawing.Size(299, 505)
        Me.RootDirViewTree.TabIndex = 6
        '
        'SettingsTreeView
        '
        Me.SettingsTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsTreeView.Location = New System.Drawing.Point(498, 3)
        Me.SettingsTreeView.Name = "SettingsTreeView"
        TreeNode1.Name = "rootDirNode"
        TreeNode1.Text = "Root Directory"
        TreeNode2.Name = "mainDirsNode"
        TreeNode2.Text = "Main Directories"
        TreeNode3.Name = "presortDirsNode"
        TreeNode3.Text = "Presorted Directories"
        TreeNode4.Name = "blockedDirsNode"
        TreeNode4.Text = "Blocked Directories"
        TreeNode5.Name = "convDirsNode"
        TreeNode5.Text = "Conversion Directories"
        TreeNode6.Name = "finishedDirNode"
        TreeNode6.Text = "Finished Conversions Directory"
        Me.SettingsTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Me.SettingsTreeView.Size = New System.Drawing.Size(146, 505)
        Me.SettingsTreeView.TabIndex = 8
        '
        'DirErrorGroup
        '
        Me.DirErrorGroup.Controls.Add(Me.NextErrorButton)
        Me.DirErrorGroup.Controls.Add(Me.PrevErrorButton)
        Me.DirErrorGroup.Location = New System.Drawing.Point(3, 361)
        Me.DirErrorGroup.Name = "DirErrorGroup"
        Me.DirErrorGroup.Size = New System.Drawing.Size(178, 66)
        Me.DirErrorGroup.TabIndex = 14
        Me.DirErrorGroup.TabStop = False
        Me.DirErrorGroup.Text = "Directory Errors: 0"
        '
        'PrevErrorButton
        '
        Me.PrevErrorButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.PrevErrorButton.Location = New System.Drawing.Point(3, 16)
        Me.PrevErrorButton.Name = "PrevErrorButton"
        Me.PrevErrorButton.Size = New System.Drawing.Size(172, 23)
        Me.PrevErrorButton.TabIndex = 0
        Me.PrevErrorButton.Text = "Previous Error"
        Me.PrevErrorButton.UseVisualStyleBackColor = True
        '
        'NextErrorButton
        '
        Me.NextErrorButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NextErrorButton.Location = New System.Drawing.Point(3, 40)
        Me.NextErrorButton.Name = "NextErrorButton"
        Me.NextErrorButton.Size = New System.Drawing.Size(172, 23)
        Me.NextErrorButton.TabIndex = 1
        Me.NextErrorButton.Text = "Next Error"
        Me.NextErrorButton.UseVisualStyleBackColor = True
        '
        'SortSettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 533)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SortSettingsDialog"
        Me.Text = "Sort Settings Editor"
        Me.TagsButtonGroup.ResumeLayout(False)
        Me.TagViewerPanel.ResumeLayout(False)
        Me.TagEntryTable.ResumeLayout(False)
        Me.TagEntryTable.PerformLayout()
        Me.AddButtonGroup.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.DirErrorGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FinishedButton As Button
    Friend WithEvents SettingsViewer As RichTextBox
    Friend WithEvents InitializeSettings As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SaveButton As Button
    Friend WithEvents addBlockedDir As Button
    Friend WithEvents addMainDir As Button
    Friend WithEvents addRootDir As Button
    Friend WithEvents addPresortDir As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents AddButtonGroup As GroupBox
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents ErrorTimer As Timer
    Friend WithEvents removeDir As Button
    Friend WithEvents TagsButtonGroup As GroupBox
    Friend WithEvents RemoveTagButton As Button
    Friend WithEvents AddTagButton As Button
    Friend WithEvents TagsSaveButton As Button
    Friend WithEvents TagEntryTable As TableLayoutPanel
    Friend WithEvents TagDescEntry As TextBox
    Friend WithEvents TagIDEntry As TextBox
    Friend WithEvents TagViewerPanel As Panel
    Friend WithEvents addMainSubdir As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RootDirViewTree As TreeView
    Friend WithEvents addFinishedDir As Button
    Friend WithEvents addConvertDir As Button
    Friend WithEvents SettingsTreeView As TreeView
    Friend WithEvents TagsViewer As ListBox
    Friend WithEvents DirErrorGroup As GroupBox
    Friend WithEvents NextErrorButton As Button
    Friend WithEvents PrevErrorButton As Button
End Class
