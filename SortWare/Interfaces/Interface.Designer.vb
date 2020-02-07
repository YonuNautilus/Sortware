<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainInterface
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainInterface))
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Images")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Videos/Animations")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Misc")
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.FindDirButtonToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FindRootDirButton = New System.Windows.Forms.Button()
        Me.FindPreSortedDirButton = New System.Windows.Forms.Button()
        Me.SaveRatingButton = New System.Windows.Forms.Button()
        Me.moveUpDir = New System.Windows.Forms.Button()
        Me.enterDir = New System.Windows.Forms.Button()
        Me.DeleteDirButton = New System.Windows.Forms.Button()
        Me.PurgeAllEmptyDirsButton = New System.Windows.Forms.Button()
        Me.MoveFolderButton = New System.Windows.Forms.Button()
        Me.MoveFilesButton = New System.Windows.Forms.Button()
        Me.AddUnderScoreButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MiddleBarEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RootDirTextBox = New System.Windows.Forms.TextBox()
        Me.PreSortedDirTextBox = New System.Windows.Forms.TextBox()
        Me.OpenSortSettingsButton = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OpenPresortsButton = New System.Windows.Forms.Button()
        Me.miscControlsPanel = New System.Windows.Forms.Panel()
        Me.VideoCheck = New System.Windows.Forms.CheckBox()
        Me.ImageCheck = New System.Windows.Forms.CheckBox()
        Me.DupeCheckerButton = New System.Windows.Forms.Button()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.PropertiesSaveStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StarRatingPanel = New System.Windows.Forms.Panel()
        Me.Star5 = New System.Windows.Forms.CheckBox()
        Me.Star4 = New System.Windows.Forms.CheckBox()
        Me.Star3 = New System.Windows.Forms.CheckBox()
        Me.Star2 = New System.Windows.Forms.CheckBox()
        Me.Star1 = New System.Windows.Forms.CheckBox()
        Me.PropertiesViewButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VolumeBar = New System.Windows.Forms.TrackBar()
        Me.openLogsButton = New System.Windows.Forms.Button()
        Me.autoPlay = New System.Windows.Forms.CheckBox()
        Me.MediaAndPresortsSplit = New System.Windows.Forms.SplitContainer()
        Me.PresortDirPanels = New System.Windows.Forms.TableLayoutPanel()
        Me.FoldersToBeSorted = New System.Windows.Forms.ListBox()
        Me.MainDirsButtonsTable = New System.Windows.Forms.TableLayoutPanel()
        Me.openFile = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FilesToBeSorted = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FilesToBeMovedView = New System.Windows.Forms.ListView()
        Me.MediaPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ImagePreview = New System.Windows.Forms.PictureBox()
        Me.VideoPlayerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.VideoHolderPanel = New System.Windows.Forms.Panel()
        Me.VlcControl1 = New Vlc.DotNet.Forms.VlcControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PauseButton = New System.Windows.Forms.ToolStripButton()
        Me.PlayButton = New System.Windows.Forms.ToolStripButton()
        Me.VideoScrollBar = New System.Windows.Forms.HScrollBar()
        Me.FileTypeCheckBox = New System.Windows.Forms.TreeView()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.RightSideTable = New System.Windows.Forms.TableLayoutPanel()
        Me.TagsSelector = New System.Windows.Forms.ListBox()
        Me.MainDirsBox = New System.Windows.Forms.ListBox()
        Me.UnderScoreManagerTable = New System.Windows.Forms.TableLayoutPanel()
        Me.UnderScoreAddUpDown = New System.Windows.Forms.NumericUpDown()
        Me.NormalTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.AlertTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.miscControlsPanel.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.StarRatingPanel.SuspendLayout()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MediaAndPresortsSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MediaAndPresortsSplit.Panel1.SuspendLayout()
        Me.MediaAndPresortsSplit.Panel2.SuspendLayout()
        Me.MediaAndPresortsSplit.SuspendLayout()
        Me.PresortDirPanels.SuspendLayout()
        Me.MainDirsButtonsTable.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.MediaPanel.SuspendLayout()
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VideoPlayerPanel.SuspendLayout()
        Me.VideoHolderPanel.SuspendLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.RightSideTable.SuspendLayout()
        Me.UnderScoreManagerTable.SuspendLayout()
        CType(Me.UnderScoreAddUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.FindRootDirButton.Location = New System.Drawing.Point(0, 0)
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
        Me.FindPreSortedDirButton.Location = New System.Drawing.Point(0, 53)
        Me.FindPreSortedDirButton.Name = "FindPreSortedDirButton"
        Me.FindPreSortedDirButton.Size = New System.Drawing.Size(96, 47)
        Me.FindPreSortedDirButton.TabIndex = 2
        Me.FindPreSortedDirButton.Text = "Choose Pre-sorted Directory"
        Me.FindDirButtonToolTip.SetToolTip(Me.FindPreSortedDirButton, "The Root directory is your earliest single folder where all files and other direc" &
        "tories are located.")
        Me.FindPreSortedDirButton.UseVisualStyleBackColor = True
        '
        'SaveRatingButton
        '
        Me.SaveRatingButton.Location = New System.Drawing.Point(325, 7)
        Me.SaveRatingButton.Name = "SaveRatingButton"
        Me.SaveRatingButton.Size = New System.Drawing.Size(33, 33)
        Me.SaveRatingButton.TabIndex = 9
        Me.FindDirButtonToolTip.SetToolTip(Me.SaveRatingButton, "Save the rating of the current file")
        Me.SaveRatingButton.UseVisualStyleBackColor = True
        '
        'moveUpDir
        '
        Me.moveUpDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.moveUpDir.Location = New System.Drawing.Point(0, 0)
        Me.moveUpDir.Margin = New System.Windows.Forms.Padding(0)
        Me.moveUpDir.Name = "moveUpDir"
        Me.moveUpDir.Size = New System.Drawing.Size(35, 36)
        Me.moveUpDir.TabIndex = 6
        Me.FindDirButtonToolTip.SetToolTip(Me.moveUpDir, "Exit the current folder-to-be-sorted")
        Me.moveUpDir.UseVisualStyleBackColor = True
        '
        'enterDir
        '
        Me.enterDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.enterDir.Location = New System.Drawing.Point(70, 0)
        Me.enterDir.Margin = New System.Windows.Forms.Padding(0)
        Me.enterDir.Name = "enterDir"
        Me.enterDir.Size = New System.Drawing.Size(35, 36)
        Me.enterDir.TabIndex = 8
        Me.FindDirButtonToolTip.SetToolTip(Me.enterDir, "Enter the selected folder-to-be-sorted")
        Me.enterDir.UseVisualStyleBackColor = True
        '
        'DeleteDirButton
        '
        Me.DeleteDirButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeleteDirButton.Location = New System.Drawing.Point(105, 0)
        Me.DeleteDirButton.Margin = New System.Windows.Forms.Padding(0)
        Me.DeleteDirButton.Name = "DeleteDirButton"
        Me.DeleteDirButton.Size = New System.Drawing.Size(35, 36)
        Me.DeleteDirButton.TabIndex = 9
        Me.FindDirButtonToolTip.SetToolTip(Me.DeleteDirButton, "Delete the selected folder-to-be-sorted")
        Me.DeleteDirButton.UseVisualStyleBackColor = True
        '
        'PurgeAllEmptyDirsButton
        '
        Me.PurgeAllEmptyDirsButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PurgeAllEmptyDirsButton.Location = New System.Drawing.Point(140, 0)
        Me.PurgeAllEmptyDirsButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PurgeAllEmptyDirsButton.Name = "PurgeAllEmptyDirsButton"
        Me.PurgeAllEmptyDirsButton.Size = New System.Drawing.Size(35, 36)
        Me.PurgeAllEmptyDirsButton.TabIndex = 10
        Me.FindDirButtonToolTip.SetToolTip(Me.PurgeAllEmptyDirsButton, " Deletes all empty folders in the presort directory")
        Me.PurgeAllEmptyDirsButton.UseVisualStyleBackColor = True
        '
        'MoveFolderButton
        '
        Me.MoveFolderButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveFolderButton.Location = New System.Drawing.Point(0, 488)
        Me.MoveFolderButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveFolderButton.Name = "MoveFolderButton"
        Me.MoveFolderButton.Size = New System.Drawing.Size(236, 24)
        Me.MoveFolderButton.TabIndex = 5
        Me.MoveFolderButton.Text = "Move Folder, Apply Tags"
        Me.FindDirButtonToolTip.SetToolTip(Me.MoveFolderButton, "Move the selected folder to the selected folder and apply the selected tags to th" &
        "e start of the folder name")
        Me.MoveFolderButton.UseVisualStyleBackColor = True
        '
        'MoveFilesButton
        '
        Me.MoveFilesButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveFilesButton.Location = New System.Drawing.Point(0, 465)
        Me.MoveFilesButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveFilesButton.Name = "MoveFilesButton"
        Me.MoveFilesButton.Size = New System.Drawing.Size(236, 23)
        Me.MoveFilesButton.TabIndex = 4
        Me.MoveFilesButton.Text = "Move File(s), Apply Tags"
        Me.FindDirButtonToolTip.SetToolTip(Me.MoveFilesButton, "Move the selected file(s) to the selected folder and apply the selected tags to t" &
        "he start of the filename(s)")
        Me.MoveFilesButton.UseVisualStyleBackColor = True
        '
        'AddUnderScoreButton
        '
        Me.AddUnderScoreButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddUnderScoreButton.Location = New System.Drawing.Point(118, 0)
        Me.AddUnderScoreButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AddUnderScoreButton.Name = "AddUnderScoreButton"
        Me.AddUnderScoreButton.Size = New System.Drawing.Size(118, 23)
        Me.AddUnderScoreButton.TabIndex = 1
        Me.AddUnderScoreButton.Text = "Add x ""_"""
        Me.FindDirButtonToolTip.SetToolTip(Me.AddUnderScoreButton, "Add the specified number of underscores to the start of the filename (useful if f" &
        "ile is unratable or numeric tagging is unavailable)")
        Me.AddUnderScoreButton.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MiddleBarEmpty, Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 512)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1186, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MiddleBarEmpty
        '
        Me.MiddleBarEmpty.Name = "MiddleBarEmpty"
        Me.MiddleBarEmpty.Size = New System.Drawing.Size(1171, 17)
        Me.MiddleBarEmpty.Spring = True
        Me.MiddleBarEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'RootDirTextBox
        '
        Me.RootDirTextBox.Location = New System.Drawing.Point(102, 0)
        Me.RootDirTextBox.Name = "RootDirTextBox"
        Me.RootDirTextBox.Size = New System.Drawing.Size(355, 20)
        Me.RootDirTextBox.TabIndex = 1
        '
        'PreSortedDirTextBox
        '
        Me.PreSortedDirTextBox.Location = New System.Drawing.Point(102, 53)
        Me.PreSortedDirTextBox.Name = "PreSortedDirTextBox"
        Me.PreSortedDirTextBox.Size = New System.Drawing.Size(355, 20)
        Me.PreSortedDirTextBox.TabIndex = 3
        '
        'OpenSortSettingsButton
        '
        Me.OpenSortSettingsButton.AutoSize = True
        Me.OpenSortSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenSortSettingsButton.Location = New System.Drawing.Point(102, 22)
        Me.OpenSortSettingsButton.Name = "OpenSortSettingsButton"
        Me.OpenSortSettingsButton.Size = New System.Drawing.Size(144, 25)
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
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.MediaAndPresortsSplit)
        Me.SplitContainer1.Size = New System.Drawing.Size(946, 512)
        Me.SplitContainer1.SplitterDistance = 112
        Me.SplitContainer1.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.miscControlsPanel, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(942, 108)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.OpenPresortsButton)
        Me.Panel1.Controls.Add(Me.PreSortedDirTextBox)
        Me.Panel1.Controls.Add(Me.RootDirTextBox)
        Me.Panel1.Controls.Add(Me.FindPreSortedDirButton)
        Me.Panel1.Controls.Add(Me.FindRootDirButton)
        Me.Panel1.Controls.Add(Me.OpenSortSettingsButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(471, 108)
        Me.Panel1.TabIndex = 0
        '
        'OpenPresortsButton
        '
        Me.OpenPresortsButton.AutoSize = True
        Me.OpenPresortsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenPresortsButton.Location = New System.Drawing.Point(102, 75)
        Me.OpenPresortsButton.Name = "OpenPresortsButton"
        Me.OpenPresortsButton.Size = New System.Drawing.Size(207, 25)
        Me.OpenPresortsButton.TabIndex = 5
        Me.OpenPresortsButton.Text = "Select Pre-sorted Directory from settings"
        Me.OpenPresortsButton.UseVisualStyleBackColor = True
        '
        'miscControlsPanel
        '
        Me.miscControlsPanel.Controls.Add(Me.VideoCheck)
        Me.miscControlsPanel.Controls.Add(Me.ImageCheck)
        Me.miscControlsPanel.Controls.Add(Me.DupeCheckerButton)
        Me.miscControlsPanel.Controls.Add(Me.StatusStrip2)
        Me.miscControlsPanel.Controls.Add(Me.SaveRatingButton)
        Me.miscControlsPanel.Controls.Add(Me.StarRatingPanel)
        Me.miscControlsPanel.Controls.Add(Me.PropertiesViewButton)
        Me.miscControlsPanel.Controls.Add(Me.Label1)
        Me.miscControlsPanel.Controls.Add(Me.VolumeBar)
        Me.miscControlsPanel.Controls.Add(Me.openLogsButton)
        Me.miscControlsPanel.Controls.Add(Me.autoPlay)
        Me.miscControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.miscControlsPanel.Location = New System.Drawing.Point(471, 0)
        Me.miscControlsPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.miscControlsPanel.Name = "miscControlsPanel"
        Me.miscControlsPanel.Size = New System.Drawing.Size(471, 108)
        Me.miscControlsPanel.TabIndex = 1
        '
        'VideoCheck
        '
        Me.VideoCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VideoCheck.AutoSize = True
        Me.VideoCheck.Checked = True
        Me.VideoCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VideoCheck.Location = New System.Drawing.Point(364, 65)
        Me.VideoCheck.Name = "VideoCheck"
        Me.VideoCheck.Size = New System.Drawing.Size(84, 17)
        Me.VideoCheck.TabIndex = 13
        Me.VideoCheck.Text = "View Videos"
        Me.VideoCheck.UseVisualStyleBackColor = True
        '
        'ImageCheck
        '
        Me.ImageCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageCheck.AutoSize = True
        Me.ImageCheck.Checked = True
        Me.ImageCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ImageCheck.Location = New System.Drawing.Point(364, 47)
        Me.ImageCheck.Name = "ImageCheck"
        Me.ImageCheck.Size = New System.Drawing.Size(86, 17)
        Me.ImageCheck.TabIndex = 12
        Me.ImageCheck.Text = "View Images"
        Me.ImageCheck.UseVisualStyleBackColor = True
        '
        'DupeCheckerButton
        '
        Me.DupeCheckerButton.Location = New System.Drawing.Point(364, 6)
        Me.DupeCheckerButton.Name = "DupeCheckerButton"
        Me.DupeCheckerButton.Size = New System.Drawing.Size(104, 34)
        Me.DupeCheckerButton.TabIndex = 11
        Me.DupeCheckerButton.Text = "Open Dupe Checker"
        Me.DupeCheckerButton.UseVisualStyleBackColor = True
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesSaveStatus})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 86)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(471, 22)
        Me.StatusStrip2.TabIndex = 10
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'PropertiesSaveStatus
        '
        Me.PropertiesSaveStatus.Name = "PropertiesSaveStatus"
        Me.PropertiesSaveStatus.Size = New System.Drawing.Size(0, 17)
        '
        'StarRatingPanel
        '
        Me.StarRatingPanel.Controls.Add(Me.Star5)
        Me.StarRatingPanel.Controls.Add(Me.Star4)
        Me.StarRatingPanel.Controls.Add(Me.Star3)
        Me.StarRatingPanel.Controls.Add(Me.Star2)
        Me.StarRatingPanel.Controls.Add(Me.Star1)
        Me.StarRatingPanel.Enabled = False
        Me.StarRatingPanel.Location = New System.Drawing.Point(127, 3)
        Me.StarRatingPanel.Name = "StarRatingPanel"
        Me.StarRatingPanel.Size = New System.Drawing.Size(192, 38)
        Me.StarRatingPanel.TabIndex = 8
        '
        'Star5
        '
        Me.Star5.AutoSize = True
        Me.Star5.Location = New System.Drawing.Point(155, 13)
        Me.Star5.Name = "Star5"
        Me.Star5.Size = New System.Drawing.Size(32, 17)
        Me.Star5.TabIndex = 4
        Me.Star5.Text = "5"
        Me.Star5.UseVisualStyleBackColor = True
        '
        'Star4
        '
        Me.Star4.AutoSize = True
        Me.Star4.Location = New System.Drawing.Point(117, 13)
        Me.Star4.Name = "Star4"
        Me.Star4.Size = New System.Drawing.Size(32, 17)
        Me.Star4.TabIndex = 3
        Me.Star4.Text = "4"
        Me.Star4.UseVisualStyleBackColor = True
        '
        'Star3
        '
        Me.Star3.AutoSize = True
        Me.Star3.Location = New System.Drawing.Point(79, 13)
        Me.Star3.Name = "Star3"
        Me.Star3.Size = New System.Drawing.Size(32, 17)
        Me.Star3.TabIndex = 2
        Me.Star3.Text = "3"
        Me.Star3.UseVisualStyleBackColor = True
        '
        'Star2
        '
        Me.Star2.AutoSize = True
        Me.Star2.Location = New System.Drawing.Point(41, 13)
        Me.Star2.Name = "Star2"
        Me.Star2.Size = New System.Drawing.Size(32, 17)
        Me.Star2.TabIndex = 1
        Me.Star2.Text = "2"
        Me.Star2.UseVisualStyleBackColor = True
        '
        'Star1
        '
        Me.Star1.AutoSize = True
        Me.Star1.Location = New System.Drawing.Point(3, 13)
        Me.Star1.Name = "Star1"
        Me.Star1.Size = New System.Drawing.Size(32, 17)
        Me.Star1.TabIndex = 0
        Me.Star1.Text = "1"
        Me.Star1.UseVisualStyleBackColor = True
        '
        'PropertiesViewButton
        '
        Me.PropertiesViewButton.Location = New System.Drawing.Point(3, 53)
        Me.PropertiesViewButton.Name = "PropertiesViewButton"
        Me.PropertiesViewButton.Size = New System.Drawing.Size(108, 30)
        Me.PropertiesViewButton.TabIndex = 7
        Me.PropertiesViewButton.Text = "View File Properties"
        Me.PropertiesViewButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Cross
        Me.Label1.Location = New System.Drawing.Point(224, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Volume"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VolumeBar
        '
        Me.VolumeBar.Location = New System.Drawing.Point(108, 63)
        Me.VolumeBar.Maximum = 100
        Me.VolumeBar.Name = "VolumeBar"
        Me.VolumeBar.Size = New System.Drawing.Size(250, 45)
        Me.VolumeBar.TabIndex = 6
        '
        'openLogsButton
        '
        Me.openLogsButton.Enabled = False
        Me.openLogsButton.Location = New System.Drawing.Point(3, 24)
        Me.openLogsButton.Name = "openLogsButton"
        Me.openLogsButton.Size = New System.Drawing.Size(108, 23)
        Me.openLogsButton.TabIndex = 5
        Me.openLogsButton.Text = "Open Move Logs"
        Me.openLogsButton.UseVisualStyleBackColor = True
        '
        'autoPlay
        '
        Me.autoPlay.AutoSize = True
        Me.autoPlay.Checked = True
        Me.autoPlay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoPlay.Location = New System.Drawing.Point(3, 3)
        Me.autoPlay.Name = "autoPlay"
        Me.autoPlay.Size = New System.Drawing.Size(97, 17)
        Me.autoPlay.TabIndex = 4
        Me.autoPlay.Text = "Autoplay Video"
        Me.autoPlay.UseVisualStyleBackColor = True
        '
        'MediaAndPresortsSplit
        '
        Me.MediaAndPresortsSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaAndPresortsSplit.Location = New System.Drawing.Point(0, 0)
        Me.MediaAndPresortsSplit.Margin = New System.Windows.Forms.Padding(0)
        Me.MediaAndPresortsSplit.Name = "MediaAndPresortsSplit"
        '
        'MediaAndPresortsSplit.Panel1
        '
        Me.MediaAndPresortsSplit.Panel1.Controls.Add(Me.PresortDirPanels)
        '
        'MediaAndPresortsSplit.Panel2
        '
        Me.MediaAndPresortsSplit.Panel2.Controls.Add(Me.MediaPanel)
        Me.MediaAndPresortsSplit.Size = New System.Drawing.Size(942, 392)
        Me.MediaAndPresortsSplit.SplitterDistance = 175
        Me.MediaAndPresortsSplit.TabIndex = 0
        '
        'PresortDirPanels
        '
        Me.PresortDirPanels.AutoSize = True
        Me.PresortDirPanels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PresortDirPanels.ColumnCount = 1
        Me.PresortDirPanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PresortDirPanels.Controls.Add(Me.FoldersToBeSorted, 0, 1)
        Me.PresortDirPanels.Controls.Add(Me.MainDirsButtonsTable, 0, 2)
        Me.PresortDirPanels.Controls.Add(Me.TabControl1, 0, 0)
        Me.PresortDirPanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PresortDirPanels.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.PresortDirPanels.Location = New System.Drawing.Point(0, 0)
        Me.PresortDirPanels.Margin = New System.Windows.Forms.Padding(0)
        Me.PresortDirPanels.Name = "PresortDirPanels"
        Me.PresortDirPanels.RowCount = 3
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.PresortDirPanels.Size = New System.Drawing.Size(175, 392)
        Me.PresortDirPanels.TabIndex = 2
        '
        'FoldersToBeSorted
        '
        Me.FoldersToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FoldersToBeSorted.FormattingEnabled = True
        Me.FoldersToBeSorted.Location = New System.Drawing.Point(0, 267)
        Me.FoldersToBeSorted.Margin = New System.Windows.Forms.Padding(0)
        Me.FoldersToBeSorted.Name = "FoldersToBeSorted"
        Me.FoldersToBeSorted.Size = New System.Drawing.Size(175, 89)
        Me.FoldersToBeSorted.TabIndex = 1
        '
        'MainDirsButtonsTable
        '
        Me.MainDirsButtonsTable.ColumnCount = 5
        Me.MainDirsButtonsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainDirsButtonsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainDirsButtonsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainDirsButtonsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainDirsButtonsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainDirsButtonsTable.Controls.Add(Me.moveUpDir, 0, 0)
        Me.MainDirsButtonsTable.Controls.Add(Me.openFile, 1, 0)
        Me.MainDirsButtonsTable.Controls.Add(Me.enterDir, 2, 0)
        Me.MainDirsButtonsTable.Controls.Add(Me.DeleteDirButton, 3, 0)
        Me.MainDirsButtonsTable.Controls.Add(Me.PurgeAllEmptyDirsButton, 4, 0)
        Me.MainDirsButtonsTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsButtonsTable.Location = New System.Drawing.Point(0, 356)
        Me.MainDirsButtonsTable.Margin = New System.Windows.Forms.Padding(0)
        Me.MainDirsButtonsTable.Name = "MainDirsButtonsTable"
        Me.MainDirsButtonsTable.RowCount = 1
        Me.MainDirsButtonsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainDirsButtonsTable.Size = New System.Drawing.Size(175, 36)
        Me.MainDirsButtonsTable.TabIndex = 3
        '
        'openFile
        '
        Me.openFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.openFile.Image = Global.SortWare.My.Resources.Resources.wmploc_373
        Me.openFile.Location = New System.Drawing.Point(35, 0)
        Me.openFile.Margin = New System.Windows.Forms.Padding(0)
        Me.openFile.Name = "openFile"
        Me.openFile.Size = New System.Drawing.Size(35, 36)
        Me.openFile.TabIndex = 7
        Me.openFile.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(169, 261)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FilesToBeSorted)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(161, 235)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FilesToBeSorted
        '
        Me.FilesToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilesToBeSorted.FormattingEnabled = True
        Me.FilesToBeSorted.Location = New System.Drawing.Point(3, 3)
        Me.FilesToBeSorted.Margin = New System.Windows.Forms.Padding(0)
        Me.FilesToBeSorted.Name = "FilesToBeSorted"
        Me.FilesToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.FilesToBeSorted.Size = New System.Drawing.Size(155, 229)
        Me.FilesToBeSorted.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FilesToBeMovedView)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(161, 235)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FilesToBeMovedView
        '
        Me.FilesToBeMovedView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilesToBeMovedView.HideSelection = False
        Me.FilesToBeMovedView.Location = New System.Drawing.Point(3, 3)
        Me.FilesToBeMovedView.Name = "FilesToBeMovedView"
        Me.FilesToBeMovedView.Size = New System.Drawing.Size(155, 229)
        Me.FilesToBeMovedView.TabIndex = 0
        Me.FilesToBeMovedView.UseCompatibleStateImageBehavior = False
        Me.FilesToBeMovedView.View = System.Windows.Forms.View.List
        '
        'MediaPanel
        '
        Me.MediaPanel.ColumnCount = 2
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MediaPanel.Controls.Add(Me.ImagePreview, 0, 0)
        Me.MediaPanel.Controls.Add(Me.VideoPlayerPanel, 1, 0)
        Me.MediaPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaPanel.Location = New System.Drawing.Point(0, 0)
        Me.MediaPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MediaPanel.Name = "MediaPanel"
        Me.MediaPanel.RowCount = 1
        Me.MediaPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MediaPanel.Size = New System.Drawing.Size(763, 392)
        Me.MediaPanel.TabIndex = 2
        '
        'ImagePreview
        '
        Me.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePreview.Location = New System.Drawing.Point(0, 0)
        Me.ImagePreview.Margin = New System.Windows.Forms.Padding(0)
        Me.ImagePreview.Name = "ImagePreview"
        Me.ImagePreview.Size = New System.Drawing.Size(381, 392)
        Me.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagePreview.TabIndex = 1
        Me.ImagePreview.TabStop = False
        '
        'VideoPlayerPanel
        '
        Me.VideoPlayerPanel.ColumnCount = 1
        Me.VideoPlayerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.VideoPlayerPanel.Controls.Add(Me.VideoHolderPanel, 0, 0)
        Me.VideoPlayerPanel.Controls.Add(Me.ToolStrip1, 0, 2)
        Me.VideoPlayerPanel.Controls.Add(Me.VideoScrollBar, 0, 1)
        Me.VideoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoPlayerPanel.Location = New System.Drawing.Point(384, 3)
        Me.VideoPlayerPanel.Name = "VideoPlayerPanel"
        Me.VideoPlayerPanel.RowCount = 3
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.Size = New System.Drawing.Size(376, 386)
        Me.VideoPlayerPanel.TabIndex = 0
        '
        'VideoHolderPanel
        '
        Me.VideoHolderPanel.Controls.Add(Me.VlcControl1)
        Me.VideoHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoHolderPanel.Location = New System.Drawing.Point(0, 0)
        Me.VideoHolderPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.VideoHolderPanel.Name = "VideoHolderPanel"
        Me.VideoHolderPanel.Size = New System.Drawing.Size(376, 346)
        Me.VideoHolderPanel.TabIndex = 11
        '
        'VlcControl1
        '
        Me.VlcControl1.BackColor = System.Drawing.Color.Black
        Me.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VlcControl1.Location = New System.Drawing.Point(0, 0)
        Me.VlcControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.VlcControl1.Name = "VlcControl1"
        Me.VlcControl1.Size = New System.Drawing.Size(376, 346)
        Me.VlcControl1.Spu = -1
        Me.VlcControl1.TabIndex = 2
        Me.VlcControl1.Text = "VlcControl1"
        Me.VlcControl1.VlcLibDirectory = CType(resources.GetObject("VlcControl1.VlcLibDirectory"), System.IO.DirectoryInfo)
        Me.VlcControl1.VlcMediaplayerOptions = Nothing
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PauseButton, Me.PlayButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 366)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(376, 20)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PauseButton
        '
        Me.PauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PauseButton.Image = Global.SortWare.My.Resources.Resources.pause
        Me.PauseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(23, 17)
        Me.PauseButton.Text = "Pause"
        '
        'PlayButton
        '
        Me.PlayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PlayButton.Image = Global.SortWare.My.Resources.Resources.play
        Me.PlayButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(23, 17)
        Me.PlayButton.Text = "Play"
        '
        'VideoScrollBar
        '
        Me.VideoScrollBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoScrollBar.LargeChange = 50
        Me.VideoScrollBar.Location = New System.Drawing.Point(0, 346)
        Me.VideoScrollBar.Maximum = 1000
        Me.VideoScrollBar.Name = "VideoScrollBar"
        Me.VideoScrollBar.Size = New System.Drawing.Size(376, 20)
        Me.VideoScrollBar.SmallChange = 5
        Me.VideoScrollBar.TabIndex = 5
        '
        'FileTypeCheckBox
        '
        Me.FileTypeCheckBox.CheckBoxes = True
        Me.FileTypeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileTypeCheckBox.Location = New System.Drawing.Point(0, 0)
        Me.FileTypeCheckBox.Margin = New System.Windows.Forms.Padding(0)
        Me.FileTypeCheckBox.Name = "FileTypeCheckBox"
        TreeNode4.Name = "Images"
        TreeNode4.Tag = "PARENT"
        TreeNode4.Text = "Images"
        TreeNode5.Name = "Videos/Animations"
        TreeNode5.Tag = "PARENT"
        TreeNode5.Text = "Videos/Animations"
        TreeNode6.Name = "Misc"
        TreeNode6.Text = "Misc"
        Me.FileTypeCheckBox.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6})
        Me.FileTypeCheckBox.Size = New System.Drawing.Size(236, 150)
        Me.FileTypeCheckBox.TabIndex = 0
        '
        'RightSideTable
        '
        Me.RightSideTable.ColumnCount = 1
        Me.RightSideTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RightSideTable.Controls.Add(Me.MoveFolderButton, 0, 5)
        Me.RightSideTable.Controls.Add(Me.TagsSelector, 0, 2)
        Me.RightSideTable.Controls.Add(Me.MainDirsBox, 0, 1)
        Me.RightSideTable.Controls.Add(Me.FileTypeCheckBox, 0, 0)
        Me.RightSideTable.Controls.Add(Me.MoveFilesButton, 0, 4)
        Me.RightSideTable.Controls.Add(Me.UnderScoreManagerTable, 0, 3)
        Me.RightSideTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightSideTable.Location = New System.Drawing.Point(0, 0)
        Me.RightSideTable.Margin = New System.Windows.Forms.Padding(0)
        Me.RightSideTable.Name = "RightSideTable"
        Me.RightSideTable.RowCount = 6
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.RightSideTable.Size = New System.Drawing.Size(236, 512)
        Me.RightSideTable.TabIndex = 1
        '
        'TagsSelector
        '
        Me.TagsSelector.ColumnWidth = 25
        Me.TagsSelector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagsSelector.FormattingEnabled = True
        Me.TagsSelector.Location = New System.Drawing.Point(0, 369)
        Me.TagsSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.TagsSelector.MultiColumn = True
        Me.TagsSelector.Name = "TagsSelector"
        Me.TagsSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.TagsSelector.Size = New System.Drawing.Size(236, 73)
        Me.TagsSelector.TabIndex = 3
        '
        'MainDirsBox
        '
        Me.MainDirsBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsBox.FormattingEnabled = True
        Me.MainDirsBox.Location = New System.Drawing.Point(0, 150)
        Me.MainDirsBox.Margin = New System.Windows.Forms.Padding(0)
        Me.MainDirsBox.Name = "MainDirsBox"
        Me.MainDirsBox.Size = New System.Drawing.Size(236, 219)
        Me.MainDirsBox.TabIndex = 2
        '
        'UnderScoreManagerTable
        '
        Me.UnderScoreManagerTable.ColumnCount = 2
        Me.UnderScoreManagerTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.UnderScoreManagerTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.UnderScoreManagerTable.Controls.Add(Me.UnderScoreAddUpDown, 0, 0)
        Me.UnderScoreManagerTable.Controls.Add(Me.AddUnderScoreButton, 1, 0)
        Me.UnderScoreManagerTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnderScoreManagerTable.Location = New System.Drawing.Point(0, 442)
        Me.UnderScoreManagerTable.Margin = New System.Windows.Forms.Padding(0)
        Me.UnderScoreManagerTable.Name = "UnderScoreManagerTable"
        Me.UnderScoreManagerTable.RowCount = 1
        Me.UnderScoreManagerTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.UnderScoreManagerTable.Size = New System.Drawing.Size(236, 23)
        Me.UnderScoreManagerTable.TabIndex = 6
        '
        'UnderScoreAddUpDown
        '
        Me.UnderScoreAddUpDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnderScoreAddUpDown.Location = New System.Drawing.Point(3, 2)
        Me.UnderScoreAddUpDown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.UnderScoreAddUpDown.Name = "UnderScoreAddUpDown"
        Me.UnderScoreAddUpDown.Size = New System.Drawing.Size(112, 20)
        Me.UnderScoreAddUpDown.TabIndex = 0
        '
        'NormalTimer
        '
        Me.NormalTimer.Interval = 10
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'AlertTimer
        '
        Me.AlertTimer.Interval = 3000
        '
        'SplitContainer2
        '
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
        Me.SplitContainer2.Panel2.Controls.Add(Me.RightSideTable)
        Me.SplitContainer2.Size = New System.Drawing.Size(1186, 512)
        Me.SplitContainer2.SplitterDistance = 946
        Me.SplitContainer2.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenameToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 48)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'MainInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 534)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MainInterface"
        Me.Text = "SortWare"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.miscControlsPanel.ResumeLayout(False)
        Me.miscControlsPanel.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.StarRatingPanel.ResumeLayout(False)
        Me.StarRatingPanel.PerformLayout()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MediaAndPresortsSplit.Panel1.ResumeLayout(False)
        Me.MediaAndPresortsSplit.Panel1.PerformLayout()
        Me.MediaAndPresortsSplit.Panel2.ResumeLayout(False)
        CType(Me.MediaAndPresortsSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MediaAndPresortsSplit.ResumeLayout(False)
        Me.PresortDirPanels.ResumeLayout(False)
        Me.MainDirsButtonsTable.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.MediaPanel.ResumeLayout(False)
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VideoPlayerPanel.ResumeLayout(False)
        Me.VideoPlayerPanel.PerformLayout()
        Me.VideoHolderPanel.ResumeLayout(False)
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.RightSideTable.ResumeLayout(False)
        Me.UnderScoreManagerTable.ResumeLayout(False)
        CType(Me.UnderScoreAddUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ImagePreview As PictureBox
    Friend WithEvents MediaPanel As TableLayoutPanel
    Friend WithEvents NormalTimer As Timer
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents OpenPresortsButton As Button
    Friend WithEvents autoPlay As CheckBox
    Friend WithEvents miscControlsPanel As Panel
    Friend WithEvents openLogsButton As Button
    Friend WithEvents MainDirsBox As ListBox
    Friend WithEvents RightSideTable As TableLayoutPanel
    Friend WithEvents TagsSelector As ListBox
    Friend WithEvents MoveFilesButton As Button
    Friend WithEvents PresortDirPanels As TableLayoutPanel
    Friend WithEvents moveUpDir As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents enterDir As Button
    Friend WithEvents FoldersToBeSorted As ListBox
    Friend WithEvents openFile As Button
    Friend WithEvents MainDirsButtonsTable As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents VolumeBar As TrackBar
    Friend WithEvents PropertiesViewButton As Button
    Friend WithEvents StarRatingPanel As Panel
    Friend WithEvents Star5 As CheckBox
    Friend WithEvents Star4 As CheckBox
    Friend WithEvents Star3 As CheckBox
    Friend WithEvents Star2 As CheckBox
    Friend WithEvents Star1 As CheckBox
    Friend WithEvents SaveRatingButton As Button
    Friend WithEvents MiddleBarEmpty As ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents PropertiesSaveStatus As ToolStripStatusLabel
    Friend WithEvents AlertTimer As Timer
    Friend WithEvents DeleteDirButton As Button
    Friend WithEvents PurgeAllEmptyDirsButton As Button
    Friend WithEvents UnderScoreAddUpDown As NumericUpDown
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UnderScoreManagerTable As TableLayoutPanel
    Friend WithEvents AddUnderScoreButton As Button
    Friend WithEvents MoveFolderButton As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents MediaAndPresortsSplit As SplitContainer
    Friend WithEvents VideoPlayerPanel As TableLayoutPanel
    Friend WithEvents VideoHolderPanel As Panel
    Friend WithEvents VlcControl1 As Vlc.DotNet.Forms.VlcControl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PauseButton As ToolStripButton
    Friend WithEvents PlayButton As ToolStripButton
    Friend WithEvents VideoScrollBar As HScrollBar
    Friend WithEvents DupeCheckerButton As Button
    Friend WithEvents VideoCheck As CheckBox
    Friend WithEvents ImageCheck As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FilesToBeMovedView As ListView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
End Class
