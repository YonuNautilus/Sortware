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
        Me.MoveFolderSubDirButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MiddleBarEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RootDirTextBox = New System.Windows.Forms.TextBox()
        Me.PreSortedDirTextBox = New System.Windows.Forms.TextBox()
        Me.OpenSortSettingsButton = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TopBarTable = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SortByComboBox = New System.Windows.Forms.ComboBox()
        Me.SortByLabel = New System.Windows.Forms.Label()
        Me.OpenPresortsButton = New System.Windows.Forms.Button()
        Me.miscControlsPanel = New System.Windows.Forms.Panel()
        Me.FileSizeLabel = New System.Windows.Forms.Label()
        Me.conversionsButton = New System.Windows.Forms.Button()
        Me.VideoCheck = New System.Windows.Forms.CheckBox()
        Me.ImageCheck = New System.Windows.Forms.CheckBox()
        Me.DupeCheckerButton = New System.Windows.Forms.Button()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.PropertiesSaveStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PropertiesViewButton = New System.Windows.Forms.Button()
        Me.StarRatingPanel = New System.Windows.Forms.Panel()
        Me.Star5 = New System.Windows.Forms.CheckBox()
        Me.Star4 = New System.Windows.Forms.CheckBox()
        Me.Star3 = New System.Windows.Forms.CheckBox()
        Me.Star2 = New System.Windows.Forms.CheckBox()
        Me.Star1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VolumeBar = New System.Windows.Forms.TrackBar()
        Me.openLogsButton = New System.Windows.Forms.Button()
        Me.MediaAndPresortsSplit = New System.Windows.Forms.SplitContainer()
        Me.PresortDirPanels = New System.Windows.Forms.TableLayoutPanel()
        Me.EmptyFoldersUpButton = New System.Windows.Forms.Button()
        Me.FoldersToBeSorted = New System.Windows.Forms.ListBox()
        Me.MainDirsButtonsTable = New System.Windows.Forms.TableLayoutPanel()
        Me.openFile = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PresortTableLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ClearFilesFilterBtn = New System.Windows.Forms.Button()
        Me.ToBeSortedFilter = New System.Windows.Forms.TextBox()
        Me.ToBeSortedFilterLabel = New System.Windows.Forms.Label()
        Me.FilesToBeSorted = New System.Windows.Forms.ListBox()
        Me.ToBeSortedLabel = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FilesToBeMovedView = New System.Windows.Forms.ListView()
        Me.PresortFileToPresortFolderButton = New System.Windows.Forms.Button()
        Me.MediaViewer1 = New SortWare.MediaViewer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MainDirsFilter = New System.Windows.Forms.TextBox()
        Me.ClearDirFilterBtn = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.RightSideTable = New System.Windows.Forms.TableLayoutPanel()
        Me.MainDirsTable = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MainDirsTree = New System.Windows.Forms.TreeView()
        Me.MainDirsLabel = New System.Windows.Forms.Label()
        Me.TagsSelector = New System.Windows.Forms.ListBox()
        Me.UnderScoreManagerTable = New System.Windows.Forms.TableLayoutPanel()
        Me.UnderScoreAddUpDown = New System.Windows.Forms.NumericUpDown()
        Me.TypeSelector1 = New SortWare.TypeSelector()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.AlertTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.FileRightClickContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TopBarTable.SuspendLayout()
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
        Me.PresortTableLayout.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.RightSideTable.SuspendLayout()
        Me.MainDirsTable.SuspendLayout()
        Me.UnderScoreManagerTable.SuspendLayout()
        CType(Me.UnderScoreAddUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.FileRightClickContextMenu.SuspendLayout()
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
        Me.FindRootDirButton.TabIndex = 1
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
        Me.SaveRatingButton.Location = New System.Drawing.Point(325, 4)
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
        Me.moveUpDir.Size = New System.Drawing.Size(36, 36)
        Me.moveUpDir.TabIndex = 6
        Me.FindDirButtonToolTip.SetToolTip(Me.moveUpDir, "Exit the current folder-to-be-sorted")
        Me.moveUpDir.UseVisualStyleBackColor = True
        '
        'enterDir
        '
        Me.enterDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.enterDir.Location = New System.Drawing.Point(72, 0)
        Me.enterDir.Margin = New System.Windows.Forms.Padding(0)
        Me.enterDir.Name = "enterDir"
        Me.enterDir.Size = New System.Drawing.Size(36, 36)
        Me.enterDir.TabIndex = 8
        Me.FindDirButtonToolTip.SetToolTip(Me.enterDir, "Enter the selected folder-to-be-sorted")
        Me.enterDir.UseVisualStyleBackColor = True
        '
        'DeleteDirButton
        '
        Me.DeleteDirButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeleteDirButton.Location = New System.Drawing.Point(108, 0)
        Me.DeleteDirButton.Margin = New System.Windows.Forms.Padding(0)
        Me.DeleteDirButton.Name = "DeleteDirButton"
        Me.DeleteDirButton.Size = New System.Drawing.Size(36, 36)
        Me.DeleteDirButton.TabIndex = 9
        Me.FindDirButtonToolTip.SetToolTip(Me.DeleteDirButton, "Delete the selected folder-to-be-sorted")
        Me.DeleteDirButton.UseVisualStyleBackColor = True
        '
        'PurgeAllEmptyDirsButton
        '
        Me.PurgeAllEmptyDirsButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PurgeAllEmptyDirsButton.Location = New System.Drawing.Point(144, 0)
        Me.PurgeAllEmptyDirsButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PurgeAllEmptyDirsButton.Name = "PurgeAllEmptyDirsButton"
        Me.PurgeAllEmptyDirsButton.Size = New System.Drawing.Size(38, 36)
        Me.PurgeAllEmptyDirsButton.TabIndex = 10
        Me.FindDirButtonToolTip.SetToolTip(Me.PurgeAllEmptyDirsButton, " Deletes all empty folders in the presort directory")
        Me.PurgeAllEmptyDirsButton.UseVisualStyleBackColor = True
        '
        'MoveFolderButton
        '
        Me.MoveFolderButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveFolderButton.Location = New System.Drawing.Point(0, 465)
        Me.MoveFolderButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveFolderButton.Name = "MoveFolderButton"
        Me.MoveFolderButton.Size = New System.Drawing.Size(236, 23)
        Me.MoveFolderButton.TabIndex = 5
        Me.MoveFolderButton.Text = "Move Folder, Apply Tags"
        Me.FindDirButtonToolTip.SetToolTip(Me.MoveFolderButton, "Move the selected folder to the selected folder and apply the selected tags to th" &
        "e start of the folder name")
        Me.MoveFolderButton.UseVisualStyleBackColor = True
        '
        'MoveFilesButton
        '
        Me.MoveFilesButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveFilesButton.Location = New System.Drawing.Point(0, 442)
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
        'MoveFolderSubDirButton
        '
        Me.MoveFolderSubDirButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveFolderSubDirButton.Location = New System.Drawing.Point(0, 488)
        Me.MoveFolderSubDirButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveFolderSubDirButton.Name = "MoveFolderSubDirButton"
        Me.MoveFolderSubDirButton.Size = New System.Drawing.Size(236, 24)
        Me.MoveFolderSubDirButton.TabIndex = 16
        Me.MoveFolderSubDirButton.Text = "Move Folder, Add As Main Subdirectory"
        Me.FindDirButtonToolTip.SetToolTip(Me.MoveFolderSubDirButton, "Add the specified number of underscores to the start of the filename (useful if f" &
        "ile is unratable or numeric tagging is unavailable)")
        Me.MoveFolderSubDirButton.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TopBarTable)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.MediaAndPresortsSplit)
        Me.SplitContainer1.Size = New System.Drawing.Size(946, 512)
        Me.SplitContainer1.SplitterDistance = 132
        Me.SplitContainer1.TabIndex = 0
        '
        'TopBarTable
        '
        Me.TopBarTable.ColumnCount = 2
        Me.TopBarTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TopBarTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TopBarTable.Controls.Add(Me.Panel1, 0, 0)
        Me.TopBarTable.Controls.Add(Me.miscControlsPanel, 1, 0)
        Me.TopBarTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TopBarTable.Location = New System.Drawing.Point(0, 0)
        Me.TopBarTable.Margin = New System.Windows.Forms.Padding(0)
        Me.TopBarTable.Name = "TopBarTable"
        Me.TopBarTable.RowCount = 1
        Me.TopBarTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TopBarTable.Size = New System.Drawing.Size(942, 128)
        Me.TopBarTable.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SortByComboBox)
        Me.Panel1.Controls.Add(Me.SortByLabel)
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
        Me.Panel1.Size = New System.Drawing.Size(471, 128)
        Me.Panel1.TabIndex = 0
        '
        'SortByComboBox
        '
        Me.SortByComboBox.FormattingEnabled = True
        Me.SortByComboBox.Items.AddRange(New Object() {"----", "Date", "Name", "Size", "Filetype"})
        Me.SortByComboBox.Location = New System.Drawing.Point(380, 84)
        Me.SortByComboBox.Name = "SortByComboBox"
        Me.SortByComboBox.Size = New System.Drawing.Size(88, 21)
        Me.SortByComboBox.TabIndex = 6
        Me.SortByComboBox.Text = "----"
        '
        'SortByLabel
        '
        Me.SortByLabel.AutoSize = True
        Me.SortByLabel.Location = New System.Drawing.Point(340, 88)
        Me.SortByLabel.Name = "SortByLabel"
        Me.SortByLabel.Size = New System.Drawing.Size(41, 13)
        Me.SortByLabel.TabIndex = 7
        Me.SortByLabel.Text = "Sort By"
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
        Me.miscControlsPanel.Controls.Add(Me.FileSizeLabel)
        Me.miscControlsPanel.Controls.Add(Me.conversionsButton)
        Me.miscControlsPanel.Controls.Add(Me.VideoCheck)
        Me.miscControlsPanel.Controls.Add(Me.ImageCheck)
        Me.miscControlsPanel.Controls.Add(Me.DupeCheckerButton)
        Me.miscControlsPanel.Controls.Add(Me.StatusStrip2)
        Me.miscControlsPanel.Controls.Add(Me.SaveRatingButton)
        Me.miscControlsPanel.Controls.Add(Me.PropertiesViewButton)
        Me.miscControlsPanel.Controls.Add(Me.StarRatingPanel)
        Me.miscControlsPanel.Controls.Add(Me.Label1)
        Me.miscControlsPanel.Controls.Add(Me.VolumeBar)
        Me.miscControlsPanel.Controls.Add(Me.openLogsButton)
        Me.miscControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.miscControlsPanel.Location = New System.Drawing.Point(471, 0)
        Me.miscControlsPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.miscControlsPanel.Name = "miscControlsPanel"
        Me.miscControlsPanel.Size = New System.Drawing.Size(471, 128)
        Me.miscControlsPanel.TabIndex = 1
        '
        'FileSizeLabel
        '
        Me.FileSizeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FileSizeLabel.AutoSize = True
        Me.FileSizeLabel.Location = New System.Drawing.Point(3, 93)
        Me.FileSizeLabel.Name = "FileSizeLabel"
        Me.FileSizeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileSizeLabel.Size = New System.Drawing.Size(25, 13)
        Me.FileSizeLabel.TabIndex = 15
        Me.FileSizeLabel.Text = "------"
        Me.FileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'conversionsButton
        '
        Me.conversionsButton.Location = New System.Drawing.Point(3, 41)
        Me.conversionsButton.Name = "conversionsButton"
        Me.conversionsButton.Size = New System.Drawing.Size(108, 23)
        Me.conversionsButton.TabIndex = 14
        Me.conversionsButton.Text = "File Conversion"
        Me.conversionsButton.UseVisualStyleBackColor = True
        '
        'VideoCheck
        '
        Me.VideoCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VideoCheck.AutoSize = True
        Me.VideoCheck.Checked = True
        Me.VideoCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VideoCheck.Location = New System.Drawing.Point(362, 63)
        Me.VideoCheck.Name = "VideoCheck"
        Me.VideoCheck.Size = New System.Drawing.Size(84, 17)
        Me.VideoCheck.TabIndex = 13
        Me.VideoCheck.Text = "View Videos"
        Me.VideoCheck.UseVisualStyleBackColor = True
        '
        'ImageCheck
        '
        Me.ImageCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageCheck.AutoSize = True
        Me.ImageCheck.Checked = True
        Me.ImageCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ImageCheck.Location = New System.Drawing.Point(362, 43)
        Me.ImageCheck.Name = "ImageCheck"
        Me.ImageCheck.Size = New System.Drawing.Size(86, 17)
        Me.ImageCheck.TabIndex = 12
        Me.ImageCheck.Text = "View Images"
        Me.ImageCheck.UseVisualStyleBackColor = True
        '
        'DupeCheckerButton
        '
        Me.DupeCheckerButton.Location = New System.Drawing.Point(364, 3)
        Me.DupeCheckerButton.Name = "DupeCheckerButton"
        Me.DupeCheckerButton.Size = New System.Drawing.Size(104, 34)
        Me.DupeCheckerButton.TabIndex = 11
        Me.DupeCheckerButton.Text = "Open Dupe Checker"
        Me.DupeCheckerButton.UseVisualStyleBackColor = True
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesSaveStatus})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 106)
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
        'PropertiesViewButton
        '
        Me.PropertiesViewButton.Location = New System.Drawing.Point(3, 64)
        Me.PropertiesViewButton.Name = "PropertiesViewButton"
        Me.PropertiesViewButton.Size = New System.Drawing.Size(108, 25)
        Me.PropertiesViewButton.TabIndex = 7
        Me.PropertiesViewButton.Text = "View File Properties"
        Me.PropertiesViewButton.UseVisualStyleBackColor = True
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
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Cross
        Me.Label1.Location = New System.Drawing.Point(203, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Volume"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VolumeBar
        '
        Me.VolumeBar.Location = New System.Drawing.Point(108, 44)
        Me.VolumeBar.Maximum = 100
        Me.VolumeBar.Name = "VolumeBar"
        Me.VolumeBar.Size = New System.Drawing.Size(250, 45)
        Me.VolumeBar.TabIndex = 6
        Me.VolumeBar.TickFrequency = 5
        Me.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'openLogsButton
        '
        Me.openLogsButton.Enabled = False
        Me.openLogsButton.Location = New System.Drawing.Point(3, 18)
        Me.openLogsButton.Name = "openLogsButton"
        Me.openLogsButton.Size = New System.Drawing.Size(108, 23)
        Me.openLogsButton.TabIndex = 5
        Me.openLogsButton.Text = "Open Move Logs"
        Me.openLogsButton.UseVisualStyleBackColor = True
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
        Me.MediaAndPresortsSplit.Panel2.Controls.Add(Me.MediaViewer1)
        Me.MediaAndPresortsSplit.Size = New System.Drawing.Size(942, 372)
        Me.MediaAndPresortsSplit.SplitterDistance = 182
        Me.MediaAndPresortsSplit.TabIndex = 0
        '
        'PresortDirPanels
        '
        Me.PresortDirPanels.AutoSize = True
        Me.PresortDirPanels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PresortDirPanels.ColumnCount = 1
        Me.PresortDirPanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PresortDirPanels.Controls.Add(Me.EmptyFoldersUpButton, 0, 2)
        Me.PresortDirPanels.Controls.Add(Me.FoldersToBeSorted, 0, 3)
        Me.PresortDirPanels.Controls.Add(Me.MainDirsButtonsTable, 0, 4)
        Me.PresortDirPanels.Controls.Add(Me.TabControl1, 0, 0)
        Me.PresortDirPanels.Controls.Add(Me.PresortFileToPresortFolderButton, 0, 1)
        Me.PresortDirPanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PresortDirPanels.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.PresortDirPanels.Location = New System.Drawing.Point(0, 0)
        Me.PresortDirPanels.Margin = New System.Windows.Forms.Padding(0)
        Me.PresortDirPanels.Name = "PresortDirPanels"
        Me.PresortDirPanels.RowCount = 5
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.PresortDirPanels.Size = New System.Drawing.Size(182, 372)
        Me.PresortDirPanels.TabIndex = 0
        '
        'EmptyFoldersUpButton
        '
        Me.EmptyFoldersUpButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EmptyFoldersUpButton.Location = New System.Drawing.Point(0, 238)
        Me.EmptyFoldersUpButton.Margin = New System.Windows.Forms.Padding(0)
        Me.EmptyFoldersUpButton.Name = "EmptyFoldersUpButton"
        Me.EmptyFoldersUpButton.Size = New System.Drawing.Size(182, 28)
        Me.EmptyFoldersUpButton.TabIndex = 6
        Me.EmptyFoldersUpButton.Text = "Move Up Files In Selected Folders"
        Me.EmptyFoldersUpButton.UseVisualStyleBackColor = True
        '
        'FoldersToBeSorted
        '
        Me.FoldersToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FoldersToBeSorted.FormattingEnabled = True
        Me.FoldersToBeSorted.Location = New System.Drawing.Point(0, 266)
        Me.FoldersToBeSorted.Margin = New System.Windows.Forms.Padding(0)
        Me.FoldersToBeSorted.Name = "FoldersToBeSorted"
        Me.FoldersToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.FoldersToBeSorted.Size = New System.Drawing.Size(182, 70)
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
        Me.MainDirsButtonsTable.Location = New System.Drawing.Point(0, 336)
        Me.MainDirsButtonsTable.Margin = New System.Windows.Forms.Padding(0)
        Me.MainDirsButtonsTable.Name = "MainDirsButtonsTable"
        Me.MainDirsButtonsTable.RowCount = 1
        Me.MainDirsButtonsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainDirsButtonsTable.Size = New System.Drawing.Size(182, 36)
        Me.MainDirsButtonsTable.TabIndex = 3
        '
        'openFile
        '
        Me.openFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.openFile.Image = CType(resources.GetObject("openFile.Image"), System.Drawing.Image)
        Me.openFile.Location = New System.Drawing.Point(36, 0)
        Me.openFile.Margin = New System.Windows.Forms.Padding(0)
        Me.openFile.Name = "openFile"
        Me.openFile.Size = New System.Drawing.Size(36, 36)
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
        Me.TabControl1.Size = New System.Drawing.Size(176, 204)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PresortTableLayout)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(168, 178)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PresortTableLayout
        '
        Me.PresortTableLayout.ColumnCount = 1
        Me.PresortTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PresortTableLayout.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.PresortTableLayout.Controls.Add(Me.ToBeSortedFilterLabel, 0, 0)
        Me.PresortTableLayout.Controls.Add(Me.FilesToBeSorted, 0, 3)
        Me.PresortTableLayout.Controls.Add(Me.ToBeSortedLabel, 0, 2)
        Me.PresortTableLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PresortTableLayout.Location = New System.Drawing.Point(0, 0)
        Me.PresortTableLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.PresortTableLayout.Name = "PresortTableLayout"
        Me.PresortTableLayout.RowCount = 4
        Me.PresortTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.PresortTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.PresortTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.PresortTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PresortTableLayout.Size = New System.Drawing.Size(168, 178)
        Me.PresortTableLayout.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ClearFilesFilterBtn, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ToBeSortedFilter, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 13)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(168, 20)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'ClearFilesFilterBtn
        '
        Me.ClearFilesFilterBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClearFilesFilterBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearFilesFilterBtn.Location = New System.Drawing.Point(148, 0)
        Me.ClearFilesFilterBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.ClearFilesFilterBtn.Name = "ClearFilesFilterBtn"
        Me.ClearFilesFilterBtn.Size = New System.Drawing.Size(20, 20)
        Me.ClearFilesFilterBtn.TabIndex = 0
        Me.ClearFilesFilterBtn.Text = "X"
        Me.ClearFilesFilterBtn.UseVisualStyleBackColor = True
        '
        'ToBeSortedFilter
        '
        Me.ToBeSortedFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToBeSortedFilter.Location = New System.Drawing.Point(0, 0)
        Me.ToBeSortedFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.ToBeSortedFilter.Name = "ToBeSortedFilter"
        Me.ToBeSortedFilter.Size = New System.Drawing.Size(148, 20)
        Me.ToBeSortedFilter.TabIndex = 1
        '
        'ToBeSortedFilterLabel
        '
        Me.ToBeSortedFilterLabel.AutoSize = True
        Me.ToBeSortedFilterLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToBeSortedFilterLabel.Location = New System.Drawing.Point(3, 0)
        Me.ToBeSortedFilterLabel.Name = "ToBeSortedFilterLabel"
        Me.ToBeSortedFilterLabel.Size = New System.Drawing.Size(162, 13)
        Me.ToBeSortedFilterLabel.TabIndex = 3
        Me.ToBeSortedFilterLabel.Text = "Filter files by name"
        '
        'FilesToBeSorted
        '
        Me.FilesToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilesToBeSorted.FormattingEnabled = True
        Me.FilesToBeSorted.Location = New System.Drawing.Point(0, 46)
        Me.FilesToBeSorted.Margin = New System.Windows.Forms.Padding(0)
        Me.FilesToBeSorted.Name = "FilesToBeSorted"
        Me.FilesToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.FilesToBeSorted.Size = New System.Drawing.Size(168, 132)
        Me.FilesToBeSorted.TabIndex = 0
        '
        'ToBeSortedLabel
        '
        Me.ToBeSortedLabel.AutoSize = True
        Me.ToBeSortedLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToBeSortedLabel.Location = New System.Drawing.Point(3, 33)
        Me.ToBeSortedLabel.Name = "ToBeSortedLabel"
        Me.ToBeSortedLabel.Size = New System.Drawing.Size(162, 13)
        Me.ToBeSortedLabel.TabIndex = 2
        Me.ToBeSortedLabel.Text = "Files To Be Sorted"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FilesToBeMovedView)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(168, 178)
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
        Me.FilesToBeMovedView.Size = New System.Drawing.Size(162, 172)
        Me.FilesToBeMovedView.TabIndex = 0
        Me.FilesToBeMovedView.UseCompatibleStateImageBehavior = False
        Me.FilesToBeMovedView.View = System.Windows.Forms.View.List
        '
        'PresortFileToPresortFolderButton
        '
        Me.PresortFileToPresortFolderButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PresortFileToPresortFolderButton.Location = New System.Drawing.Point(0, 210)
        Me.PresortFileToPresortFolderButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PresortFileToPresortFolderButton.Name = "PresortFileToPresortFolderButton"
        Me.PresortFileToPresortFolderButton.Size = New System.Drawing.Size(182, 28)
        Me.PresortFileToPresortFolderButton.TabIndex = 5
        Me.PresortFileToPresortFolderButton.Text = "Move File to Presort Folder"
        Me.PresortFileToPresortFolderButton.UseVisualStyleBackColor = True
        '
        'MediaViewer1
        '
        Me.MediaViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaViewer1.Location = New System.Drawing.Point(0, 0)
        Me.MediaViewer1.Name = "MediaViewer1"
        Me.MediaViewer1.Size = New System.Drawing.Size(756, 372)
        Me.MediaViewer1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MainDirsFilter, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ClearDirFilterBtn, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 13)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(236, 20)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'MainDirsFilter
        '
        Me.MainDirsFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsFilter.Location = New System.Drawing.Point(0, 0)
        Me.MainDirsFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.MainDirsFilter.Name = "MainDirsFilter"
        Me.MainDirsFilter.Size = New System.Drawing.Size(216, 20)
        Me.MainDirsFilter.TabIndex = 1
        '
        'ClearDirFilterBtn
        '
        Me.ClearDirFilterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClearDirFilterBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClearDirFilterBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearDirFilterBtn.Location = New System.Drawing.Point(216, 0)
        Me.ClearDirFilterBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.ClearDirFilterBtn.Name = "ClearDirFilterBtn"
        Me.ClearDirFilterBtn.Size = New System.Drawing.Size(20, 20)
        Me.ClearDirFilterBtn.TabIndex = 2
        Me.ClearDirFilterBtn.Text = "X"
        Me.ClearDirFilterBtn.UseVisualStyleBackColor = True
        '
        'RightSideTable
        '
        Me.RightSideTable.ColumnCount = 1
        Me.RightSideTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RightSideTable.Controls.Add(Me.MainDirsTable, 0, 1)
        Me.RightSideTable.Controls.Add(Me.MoveFolderSubDirButton, 0, 6)
        Me.RightSideTable.Controls.Add(Me.MoveFolderButton, 0, 5)
        Me.RightSideTable.Controls.Add(Me.TagsSelector, 0, 2)
        Me.RightSideTable.Controls.Add(Me.MoveFilesButton, 0, 4)
        Me.RightSideTable.Controls.Add(Me.UnderScoreManagerTable, 0, 3)
        Me.RightSideTable.Controls.Add(Me.TypeSelector1, 0, 0)
        Me.RightSideTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightSideTable.Location = New System.Drawing.Point(0, 0)
        Me.RightSideTable.Margin = New System.Windows.Forms.Padding(0)
        Me.RightSideTable.Name = "RightSideTable"
        Me.RightSideTable.RowCount = 7
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.30091!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.69909!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.Size = New System.Drawing.Size(236, 512)
        Me.RightSideTable.TabIndex = 1
        '
        'MainDirsTable
        '
        Me.MainDirsTable.ColumnCount = 1
        Me.MainDirsTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainDirsTable.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.MainDirsTable.Controls.Add(Me.Label2, 0, 0)
        Me.MainDirsTable.Controls.Add(Me.MainDirsTree, 0, 3)
        Me.MainDirsTable.Controls.Add(Me.MainDirsLabel, 0, 2)
        Me.MainDirsTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsTable.Location = New System.Drawing.Point(0, 113)
        Me.MainDirsTable.Margin = New System.Windows.Forms.Padding(0)
        Me.MainDirsTable.Name = "MainDirsTable"
        Me.MainDirsTable.RowCount = 4
        Me.MainDirsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.MainDirsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainDirsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.MainDirsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainDirsTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainDirsTable.Size = New System.Drawing.Size(236, 212)
        Me.MainDirsTable.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Filter dirs by name"
        '
        'MainDirsTree
        '
        Me.MainDirsTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsTree.Location = New System.Drawing.Point(3, 49)
        Me.MainDirsTree.Name = "MainDirsTree"
        Me.MainDirsTree.Size = New System.Drawing.Size(230, 160)
        Me.MainDirsTree.TabIndex = 15
        '
        'MainDirsLabel
        '
        Me.MainDirsLabel.AutoSize = True
        Me.MainDirsLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsLabel.Location = New System.Drawing.Point(3, 33)
        Me.MainDirsLabel.Name = "MainDirsLabel"
        Me.MainDirsLabel.Size = New System.Drawing.Size(230, 13)
        Me.MainDirsLabel.TabIndex = 2
        Me.MainDirsLabel.Text = "Main Directories"
        '
        'TagsSelector
        '
        Me.TagsSelector.ColumnWidth = 25
        Me.TagsSelector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagsSelector.FormattingEnabled = True
        Me.TagsSelector.Location = New System.Drawing.Point(0, 325)
        Me.TagsSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.TagsSelector.MultiColumn = True
        Me.TagsSelector.Name = "TagsSelector"
        Me.TagsSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.TagsSelector.Size = New System.Drawing.Size(236, 94)
        Me.TagsSelector.TabIndex = 3
        '
        'UnderScoreManagerTable
        '
        Me.UnderScoreManagerTable.ColumnCount = 2
        Me.UnderScoreManagerTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.UnderScoreManagerTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.UnderScoreManagerTable.Controls.Add(Me.UnderScoreAddUpDown, 0, 0)
        Me.UnderScoreManagerTable.Controls.Add(Me.AddUnderScoreButton, 1, 0)
        Me.UnderScoreManagerTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnderScoreManagerTable.Location = New System.Drawing.Point(0, 419)
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
        'TypeSelector1
        '
        Me.TypeSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TypeSelector1.Location = New System.Drawing.Point(3, 3)
        Me.TypeSelector1.Name = "TypeSelector1"
        Me.TypeSelector1.Size = New System.Drawing.Size(230, 107)
        Me.TypeSelector1.TabIndex = 7
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
        'FileRightClickContextMenu
        '
        Me.FileRightClickContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenameToolStripMenuItem, Me.GroupToolStripMenuItem1})
        Me.FileRightClickContextMenu.Name = "ContextMenuStrip1"
        Me.FileRightClickContextMenu.Size = New System.Drawing.Size(200, 48)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'GroupToolStripMenuItem1
        '
        Me.GroupToolStripMenuItem1.Name = "GroupToolStripMenuItem1"
        Me.GroupToolStripMenuItem1.Size = New System.Drawing.Size(199, 22)
        Me.GroupToolStripMenuItem1.Text = "Group Items Into Folder"
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
        Me.TopBarTable.ResumeLayout(False)
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
        Me.PresortTableLayout.ResumeLayout(False)
        Me.PresortTableLayout.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.RightSideTable.ResumeLayout(False)
        Me.MainDirsTable.ResumeLayout(False)
        Me.MainDirsTable.PerformLayout()
        Me.UnderScoreManagerTable.ResumeLayout(False)
        CType(Me.UnderScoreAddUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.FileRightClickContextMenu.ResumeLayout(False)
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
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents TopBarTable As TableLayoutPanel
    Friend WithEvents OpenPresortsButton As Button
    Friend WithEvents miscControlsPanel As Panel
    Friend WithEvents openLogsButton As Button
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
    Friend WithEvents UnderScoreManagerTable As TableLayoutPanel
    Friend WithEvents AddUnderScoreButton As Button
    Friend WithEvents MoveFolderButton As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents MediaAndPresortsSplit As SplitContainer
    Friend WithEvents DupeCheckerButton As Button
    Friend WithEvents VideoCheck As CheckBox
    Friend WithEvents ImageCheck As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FilesToBeMovedView As ListView
    Friend WithEvents FileRightClickContextMenu As ContextMenuStrip
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PresortFileToPresortFolderButton As Button
    Friend WithEvents SortByComboBox As ComboBox
    Friend WithEvents SortByLabel As Label
    Friend WithEvents MediaViewer1 As MediaViewer
    Friend WithEvents TypeSelector1 As TypeSelector
    Friend WithEvents conversionsButton As Button
    Friend WithEvents EmptyFoldersUpButton As Button
    Friend WithEvents MainDirsTree As TreeView
    Friend WithEvents MoveFolderSubDirButton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PresortTableLayout As TableLayoutPanel
    Friend WithEvents ToBeSortedLabel As Label
    Friend WithEvents ToBeSortedFilter As TextBox
    Friend WithEvents ToBeSortedFilterLabel As Label
    Friend WithEvents MainDirsTable As TableLayoutPanel
    Friend WithEvents MainDirsLabel As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents MainDirsFilter As TextBox
    Friend WithEvents ClearDirFilterBtn As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ClearFilesFilterBtn As Button
    Friend WithEvents FileSizeLabel As Label
End Class
