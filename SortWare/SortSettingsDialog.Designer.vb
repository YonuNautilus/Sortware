<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.FinishedButton = New System.Windows.Forms.Button()
        Me.SettingsViewer = New System.Windows.Forms.RichTextBox()
        Me.InitializeSettings = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RootDirView = New System.Windows.Forms.ListBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.addRootDir = New System.Windows.Forms.Button()
        Me.addMainDir = New System.Windows.Forms.Button()
        Me.addBlockedDir = New System.Windows.Forms.Button()
        Me.addPresortDir = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.AddButtonGroup = New System.Windows.Forms.GroupBox()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ErrorTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.AddButtonGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(2, 3)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(122, 82)
        Me.ListBox1.TabIndex = 1
        '
        'FinishedButton
        '
        Me.FinishedButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FinishedButton.Location = New System.Drawing.Point(199, 402)
        Me.FinishedButton.Name = "FinishedButton"
        Me.FinishedButton.Size = New System.Drawing.Size(73, 23)
        Me.FinishedButton.TabIndex = 2
        Me.FinishedButton.Text = "Done"
        Me.FinishedButton.UseVisualStyleBackColor = True
        '
        'SettingsViewer
        '
        Me.SettingsViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsViewer.Location = New System.Drawing.Point(0, 0)
        Me.SettingsViewer.Name = "SettingsViewer"
        Me.SettingsViewer.Size = New System.Drawing.Size(286, 428)
        Me.SettingsViewer.TabIndex = 3
        Me.SettingsViewer.Text = ""
        '
        'InitializeSettings
        '
        Me.InitializeSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InitializeSettings.Enabled = False
        Me.InitializeSettings.Location = New System.Drawing.Point(177, 3)
        Me.InitializeSettings.Name = "InitializeSettings"
        Me.InitializeSettings.Size = New System.Drawing.Size(94, 41)
        Me.InitializeSettings.TabIndex = 4
        Me.InitializeSettings.Text = "Initialize .sortSettings File"
        Me.ToolTip1.SetToolTip(Me.InitializeSettings, "If no .sortSettings file is found, clicking this button will create one in the se" &
        "lected root directory")
        Me.InitializeSettings.UseVisualStyleBackColor = True
        '
        'RootDirView
        '
        Me.RootDirView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootDirView.FormattingEnabled = True
        Me.RootDirView.Location = New System.Drawing.Point(0, 0)
        Me.RootDirView.Name = "RootDirView"
        Me.RootDirView.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.RootDirView.Size = New System.Drawing.Size(232, 428)
        Me.RootDirView.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RootDirView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 428)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 6
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.AddButtonGroup)
        Me.SplitContainer2.Panel1.Controls.Add(Me.SaveButton)
        Me.SplitContainer2.Panel1.Controls.Add(Me.InitializeSettings)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ListBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.FinishedButton)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SettingsViewer)
        Me.SplitContainer2.Size = New System.Drawing.Size(564, 428)
        Me.SplitContainer2.SplitterDistance = 274
        Me.SplitContainer2.TabIndex = 5
        '
        'SaveButton
        '
        Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveButton.Location = New System.Drawing.Point(199, 373)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(73, 23)
        Me.SaveButton.TabIndex = 7
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
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
        'addBlockedDir
        '
        Me.addBlockedDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addBlockedDir.Location = New System.Drawing.Point(3, 62)
        Me.addBlockedDir.Name = "addBlockedDir"
        Me.addBlockedDir.Size = New System.Drawing.Size(171, 23)
        Me.addBlockedDir.TabIndex = 10
        Me.addBlockedDir.Text = "Blocked Directory >>"
        Me.addBlockedDir.UseVisualStyleBackColor = True
        '
        'addPresortDir
        '
        Me.addPresortDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.addPresortDir.Location = New System.Drawing.Point(3, 85)
        Me.addPresortDir.Name = "addPresortDir"
        Me.addPresortDir.Size = New System.Drawing.Size(171, 23)
        Me.addPresortDir.TabIndex = 11
        Me.addPresortDir.Text = "Pre-sort Directory >>"
        Me.addPresortDir.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'AddButtonGroup
        '
        Me.AddButtonGroup.AutoSize = True
        Me.AddButtonGroup.Controls.Add(Me.addPresortDir)
        Me.AddButtonGroup.Controls.Add(Me.addBlockedDir)
        Me.AddButtonGroup.Controls.Add(Me.addMainDir)
        Me.AddButtonGroup.Controls.Add(Me.addRootDir)
        Me.AddButtonGroup.Location = New System.Drawing.Point(49, 91)
        Me.AddButtonGroup.Name = "AddButtonGroup"
        Me.AddButtonGroup.Size = New System.Drawing.Size(177, 111)
        Me.AddButtonGroup.TabIndex = 12
        Me.AddButtonGroup.TabStop = False
        Me.AddButtonGroup.Text = "Add Directories to Sort Settings"
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
        'SortSettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "SortSettingsDialog"
        Me.Text = "DirectoryFinder"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.AddButtonGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents FinishedButton As Button
    Friend WithEvents SettingsViewer As RichTextBox
    Friend WithEvents InitializeSettings As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RootDirView As ListBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SaveButton As Button
    Friend WithEvents addBlockedDir As Button
    Friend WithEvents addMainDir As Button
    Friend WithEvents addRootDir As Button
    Friend WithEvents addPresortDir As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents AddButtonGroup As GroupBox
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents ErrorTimer As Timer
End Class
