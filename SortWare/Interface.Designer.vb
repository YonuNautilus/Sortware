<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainInterface
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainInterface))
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".png")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".jpeg/.jpg")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".gif")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Images", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".mp4")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".webm")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Videos/Animations", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13})
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.FindDirButtonToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FindRootDirButton = New System.Windows.Forms.Button()
        Me.FindPreSortedDirButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RootDirTextBox = New System.Windows.Forms.TextBox()
        Me.PreSortedDirTextBox = New System.Windows.Forms.TextBox()
        Me.OpenSortSettingsButton = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImagePreview = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.VlcControl1 = New Vlc.DotNet.Forms.VlcControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PauseButton = New System.Windows.Forms.ToolStripButton()
        Me.PlayButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.FilesToBeSorted = New System.Windows.Forms.ListBox()
        Me.FileTypeCheckBox = New System.Windows.Forms.TreeView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'FindDirButtonToolTip
        '
        Me.FindDirButtonToolTip.BackColor = System.Drawing.Color.Khaki
        '
        'FindRootDirButton
        '
        Me.FindRootDirButton.Location = New System.Drawing.Point(3, 3)
        Me.FindRootDirButton.Name = "FindRootDirButton"
        Me.FindRootDirButton.Size = New System.Drawing.Size(96, 47)
        Me.FindRootDirButton.TabIndex = 0
        Me.FindRootDirButton.Text = "Choose Root Directory"
        Me.FindDirButtonToolTip.SetToolTip(Me.FindRootDirButton, "The Root directory is your earliest single folder where all files and other direc" &
        "tories are located.")
        Me.FindRootDirButton.UseVisualStyleBackColor = True
        '
        'FindPreSortedDirButton
        '
        Me.FindPreSortedDirButton.Location = New System.Drawing.Point(3, 56)
        Me.FindPreSortedDirButton.Name = "FindPreSortedDirButton"
        Me.FindPreSortedDirButton.Size = New System.Drawing.Size(96, 47)
        Me.FindPreSortedDirButton.TabIndex = 2
        Me.FindPreSortedDirButton.Text = "Choose Pre-sorted Directory"
        Me.FindDirButtonToolTip.SetToolTip(Me.FindPreSortedDirButton, "The Root directory is your earliest single folder where all files and other direc" &
        "tories are located.")
        Me.FindPreSortedDirButton.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(996, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'RootDirTextBox
        '
        Me.RootDirTextBox.Location = New System.Drawing.Point(105, 3)
        Me.RootDirTextBox.Name = "RootDirTextBox"
        Me.RootDirTextBox.Size = New System.Drawing.Size(355, 20)
        Me.RootDirTextBox.TabIndex = 1
        '
        'PreSortedDirTextBox
        '
        Me.PreSortedDirTextBox.Location = New System.Drawing.Point(105, 56)
        Me.PreSortedDirTextBox.Name = "PreSortedDirTextBox"
        Me.PreSortedDirTextBox.Size = New System.Drawing.Size(355, 20)
        Me.PreSortedDirTextBox.TabIndex = 3
        '
        'OpenSortSettingsButton
        '
        Me.OpenSortSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenSortSettingsButton.Location = New System.Drawing.Point(105, 27)
        Me.OpenSortSettingsButton.Name = "OpenSortSettingsButton"
        Me.OpenSortSettingsButton.Size = New System.Drawing.Size(126, 23)
        Me.OpenSortSettingsButton.TabIndex = 4
        Me.OpenSortSettingsButton.Text = "Open Folder Settings"
        Me.OpenSortSettingsButton.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FindRootDirButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.FindPreSortedDirButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.OpenSortSettingsButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PreSortedDirTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RootDirTextBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.FilesToBeSorted)
        Me.SplitContainer1.Size = New System.Drawing.Size(789, 426)
        Me.SplitContainer1.SplitterDistance = 112
        Me.SplitContainer1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImagePreview, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(221, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 306.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(564, 306)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ImagePreview
        '
        Me.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePreview.Location = New System.Drawing.Point(3, 3)
        Me.ImagePreview.Name = "ImagePreview"
        Me.ImagePreview.Size = New System.Drawing.Size(276, 300)
        Me.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagePreview.TabIndex = 1
        Me.ImagePreview.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.VlcControl1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ToolStrip1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(285, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(276, 300)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'VlcControl1
        '
        Me.VlcControl1.BackColor = System.Drawing.Color.Black
        Me.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VlcControl1.Location = New System.Drawing.Point(3, 3)
        Me.VlcControl1.Name = "VlcControl1"
        Me.VlcControl1.Size = New System.Drawing.Size(270, 274)
        Me.VlcControl1.Spu = -1
        Me.VlcControl1.TabIndex = 2
        Me.VlcControl1.Text = "VlcControl1"
        Me.VlcControl1.VlcLibDirectory = CType(resources.GetObject("VlcControl1.VlcLibDirectory"), System.IO.DirectoryInfo)
        Me.VlcControl1.VlcMediaplayerOptions = Nothing
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PauseButton, Me.PlayButton, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 280)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(276, 20)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PauseButton
        '
        Me.PauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PauseButton.Image = Global.SortWare.My.Resources.Resources.buttons
        Me.PauseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(23, 17)
        Me.PauseButton.Text = "Pause"
        '
        'PlayButton
        '
        Me.PlayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PlayButton.Image = CType(resources.GetObject("PlayButton.Image"), System.Drawing.Image)
        Me.PlayButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(23, 17)
        Me.PlayButton.Text = "Play"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 17)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'FilesToBeSorted
        '
        Me.FilesToBeSorted.Dock = System.Windows.Forms.DockStyle.Left
        Me.FilesToBeSorted.FormattingEnabled = True
        Me.FilesToBeSorted.Location = New System.Drawing.Point(0, 0)
        Me.FilesToBeSorted.Name = "FilesToBeSorted"
        Me.FilesToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.FilesToBeSorted.Size = New System.Drawing.Size(221, 306)
        Me.FilesToBeSorted.TabIndex = 0
        '
        'FileTypeCheckBox
        '
        Me.FileTypeCheckBox.CheckBoxes = True
        Me.FileTypeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileTypeCheckBox.Location = New System.Drawing.Point(0, 0)
        Me.FileTypeCheckBox.Name = "FileTypeCheckBox"
        TreeNode8.Name = "png"
        TreeNode8.Text = ".png"
        TreeNode9.Name = "jpeg jpg"
        TreeNode9.Text = ".jpeg/.jpg"
        TreeNode10.Name = "gif"
        TreeNode10.Text = ".gif"
        TreeNode11.Name = "Images"
        TreeNode11.Tag = "PARENT"
        TreeNode11.Text = "Images"
        TreeNode12.Name = "mp4"
        TreeNode12.Text = ".mp4"
        TreeNode13.Name = "webm"
        TreeNode13.Text = ".webm"
        TreeNode14.Name = "Videos/Animations"
        TreeNode14.Tag = "PARENT"
        TreeNode14.Text = "Videos/Animations"
        Me.FileTypeCheckBox.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode14})
        Me.FileTypeCheckBox.Size = New System.Drawing.Size(199, 113)
        Me.FileTypeCheckBox.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(996, 428)
        Me.SplitContainer2.SplitterDistance = 791
        Me.SplitContainer2.TabIndex = 2
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.FileTypeCheckBox)
        Me.SplitContainer3.Size = New System.Drawing.Size(199, 426)
        Me.SplitContainer3.SplitterDistance = 113
        Me.SplitContainer3.TabIndex = 0
        '
        'MainInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 450)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "MainInterface"
        Me.Text = "SortWare"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DirectoryEntry1 As DirectoryServices.DirectoryEntry
    Friend WithEvents DirectorySearcher1 As DirectoryServices.DirectorySearcher
    Friend WithEvents FindDirButtonToolTip As ToolTip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents OpenSortSettingsButton As Button
    Friend WithEvents PreSortedDirTextBox As TextBox
    Friend WithEvents FindPreSortedDirButton As Button
    Friend WithEvents RootDirTextBox As TextBox
    Friend WithEvents FindRootDirButton As Button
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents FilesToBeSorted As ListBox
    Friend WithEvents FileTypeCheckBox As TreeView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents VlcControl1 As Vlc.DotNet.Forms.VlcControl
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ImagePreview As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PauseButton As ToolStripButton
    Friend WithEvents PlayButton As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
End Class
