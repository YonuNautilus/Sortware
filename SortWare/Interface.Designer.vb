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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".png")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".jpeg/.jpg")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".gif")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Images", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".mp4")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".webm")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".mov")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".avi")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".mkv")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".m4v")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(".m2ts")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Videos/Animations", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.FindDirButtonToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FindRootDirButton = New System.Windows.Forms.Button()
        Me.FindPreSortedDirButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MiddleBarEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RootDirTextBox = New System.Windows.Forms.TextBox()
        Me.PreSortedDirTextBox = New System.Windows.Forms.TextBox()
        Me.OpenSortSettingsButton = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OpenPresortsButton = New System.Windows.Forms.Button()
        Me.miscControlsPanel = New System.Windows.Forms.Panel()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.PropertiesSaveStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveRatingButton = New System.Windows.Forms.Button()
        Me.StarRatingPanel = New System.Windows.Forms.Panel()
        Me.Star5 = New System.Windows.Forms.CheckBox()
        Me.Star4 = New System.Windows.Forms.CheckBox()
        Me.Star3 = New System.Windows.Forms.CheckBox()
        Me.Star2 = New System.Windows.Forms.CheckBox()
        Me.Star1 = New System.Windows.Forms.CheckBox()
        Me.PropertiesViewButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.openLogsButton = New System.Windows.Forms.Button()
        Me.autoPlay = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImagePreview = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PauseButton = New System.Windows.Forms.ToolStripButton()
        Me.PlayButton = New System.Windows.Forms.ToolStripButton()
        Me.VideoScrollBar = New System.Windows.Forms.HScrollBar()
        Me.VlcControl1 = New Vlc.DotNet.Forms.VlcControl()
        Me.PresortDirPanels = New System.Windows.Forms.TableLayoutPanel()
        Me.FilesToBeSorted = New System.Windows.Forms.ListBox()
        Me.FoldersToBeSorted = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.moveUpDir = New System.Windows.Forms.Button()
        Me.openFile = New System.Windows.Forms.Button()
        Me.enterDir = New System.Windows.Forms.Button()
        Me.DeleteDirButton = New System.Windows.Forms.Button()
        Me.PurgeAllEmptyDirsButton = New System.Windows.Forms.Button()
        Me.FileTypeCheckBox = New System.Windows.Forms.TreeView()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.RightSideTable = New System.Windows.Forms.TableLayoutPanel()
        Me.TagsSelector = New System.Windows.Forms.ListBox()
        Me.MainDirsBox = New System.Windows.Forms.ListBox()
        Me.MoveFilesButton = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
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
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PresortDirPanels.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.RightSideTable.SuspendLayout()
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.MiddleBarEmpty})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 512)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1186, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'MiddleBarEmpty
        '
        Me.MiddleBarEmpty.Name = "MiddleBarEmpty"
        Me.MiddleBarEmpty.Size = New System.Drawing.Size(1171, 17)
        Me.MiddleBarEmpty.Spring = True
        Me.MiddleBarEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1043, 512)
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
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1039, 108)
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
        Me.Panel1.Size = New System.Drawing.Size(519, 108)
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
        Me.miscControlsPanel.Controls.Add(Me.StatusStrip2)
        Me.miscControlsPanel.Controls.Add(Me.SaveRatingButton)
        Me.miscControlsPanel.Controls.Add(Me.StarRatingPanel)
        Me.miscControlsPanel.Controls.Add(Me.PropertiesViewButton)
        Me.miscControlsPanel.Controls.Add(Me.Label1)
        Me.miscControlsPanel.Controls.Add(Me.TrackBar1)
        Me.miscControlsPanel.Controls.Add(Me.openLogsButton)
        Me.miscControlsPanel.Controls.Add(Me.autoPlay)
        Me.miscControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.miscControlsPanel.Location = New System.Drawing.Point(519, 0)
        Me.miscControlsPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.miscControlsPanel.Name = "miscControlsPanel"
        Me.miscControlsPanel.Size = New System.Drawing.Size(520, 108)
        Me.miscControlsPanel.TabIndex = 1
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesSaveStatus})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 86)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(520, 22)
        Me.StatusStrip2.TabIndex = 10
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'PropertiesSaveStatus
        '
        Me.PropertiesSaveStatus.Name = "PropertiesSaveStatus"
        Me.PropertiesSaveStatus.Size = New System.Drawing.Size(0, 17)
        '
        'SaveRatingButton
        '
        Me.SaveRatingButton.Location = New System.Drawing.Point(411, 7)
        Me.SaveRatingButton.Name = "SaveRatingButton"
        Me.SaveRatingButton.Size = New System.Drawing.Size(33, 33)
        Me.SaveRatingButton.TabIndex = 9
        Me.SaveRatingButton.UseVisualStyleBackColor = True
        '
        'StarRatingPanel
        '
        Me.StarRatingPanel.Controls.Add(Me.Star5)
        Me.StarRatingPanel.Controls.Add(Me.Star4)
        Me.StarRatingPanel.Controls.Add(Me.Star3)
        Me.StarRatingPanel.Controls.Add(Me.Star2)
        Me.StarRatingPanel.Controls.Add(Me.Star1)
        Me.StarRatingPanel.Enabled = False
        Me.StarRatingPanel.Location = New System.Drawing.Point(213, 3)
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
        Me.Label1.Location = New System.Drawing.Point(285, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Volume"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(161, 63)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(310, 45)
        Me.TrackBar1.TabIndex = 6
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
        Me.autoPlay.Location = New System.Drawing.Point(3, 3)
        Me.autoPlay.Name = "autoPlay"
        Me.autoPlay.Size = New System.Drawing.Size(97, 17)
        Me.autoPlay.TabIndex = 4
        Me.autoPlay.Text = "Autoplay Video"
        Me.autoPlay.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.03279!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.9836!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.9836!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImagePreview, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PresortDirPanels, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1039, 392)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ImagePreview
        '
        Me.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePreview.Location = New System.Drawing.Point(187, 0)
        Me.ImagePreview.Margin = New System.Windows.Forms.Padding(0)
        Me.ImagePreview.Name = "ImagePreview"
        Me.ImagePreview.Size = New System.Drawing.Size(425, 392)
        Me.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagePreview.TabIndex = 1
        Me.ImagePreview.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ToolStrip1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.VideoScrollBar, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.VlcControl1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(615, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(421, 386)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PauseButton, Me.PlayButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 366)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(421, 20)
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
        Me.VideoScrollBar.Size = New System.Drawing.Size(421, 20)
        Me.VideoScrollBar.SmallChange = 5
        Me.VideoScrollBar.TabIndex = 5
        '
        'VlcControl1
        '
        Me.VlcControl1.BackColor = System.Drawing.Color.Black
        Me.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VlcControl1.Location = New System.Drawing.Point(0, 0)
        Me.VlcControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.VlcControl1.Name = "VlcControl1"
        Me.VlcControl1.Size = New System.Drawing.Size(421, 346)
        Me.VlcControl1.Spu = -1
        Me.VlcControl1.TabIndex = 2
        Me.VlcControl1.Text = "VlcControl1"
        Me.VlcControl1.VlcLibDirectory = CType(resources.GetObject("VlcControl1.VlcLibDirectory"), System.IO.DirectoryInfo)
        Me.VlcControl1.VlcMediaplayerOptions = Nothing
        '
        'PresortDirPanels
        '
        Me.PresortDirPanels.AutoSize = True
        Me.PresortDirPanels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PresortDirPanels.ColumnCount = 1
        Me.PresortDirPanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PresortDirPanels.Controls.Add(Me.FilesToBeSorted, 0, 0)
        Me.PresortDirPanels.Controls.Add(Me.FoldersToBeSorted, 0, 1)
        Me.PresortDirPanels.Controls.Add(Me.TableLayoutPanel5, 0, 2)
        Me.PresortDirPanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PresortDirPanels.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.PresortDirPanels.Location = New System.Drawing.Point(0, 0)
        Me.PresortDirPanels.Margin = New System.Windows.Forms.Padding(0)
        Me.PresortDirPanels.Name = "PresortDirPanels"
        Me.PresortDirPanels.RowCount = 3
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.PresortDirPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.PresortDirPanels.Size = New System.Drawing.Size(187, 392)
        Me.PresortDirPanels.TabIndex = 2
        '
        'FilesToBeSorted
        '
        Me.FilesToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilesToBeSorted.FormattingEnabled = True
        Me.FilesToBeSorted.Location = New System.Drawing.Point(0, 0)
        Me.FilesToBeSorted.Margin = New System.Windows.Forms.Padding(0)
        Me.FilesToBeSorted.Name = "FilesToBeSorted"
        Me.FilesToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.FilesToBeSorted.Size = New System.Drawing.Size(187, 267)
        Me.FilesToBeSorted.TabIndex = 0
        '
        'FoldersToBeSorted
        '
        Me.FoldersToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FoldersToBeSorted.FormattingEnabled = True
        Me.FoldersToBeSorted.Location = New System.Drawing.Point(0, 267)
        Me.FoldersToBeSorted.Margin = New System.Windows.Forms.Padding(0)
        Me.FoldersToBeSorted.Name = "FoldersToBeSorted"
        Me.FoldersToBeSorted.Size = New System.Drawing.Size(187, 89)
        Me.FoldersToBeSorted.TabIndex = 2
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.moveUpDir, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.openFile, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.enterDir, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.DeleteDirButton, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.PurgeAllEmptyDirsButton, 4, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 356)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(187, 36)
        Me.TableLayoutPanel5.TabIndex = 3
        '
        'moveUpDir
        '
        Me.moveUpDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.moveUpDir.Location = New System.Drawing.Point(0, 0)
        Me.moveUpDir.Margin = New System.Windows.Forms.Padding(0)
        Me.moveUpDir.Name = "moveUpDir"
        Me.moveUpDir.Size = New System.Drawing.Size(36, 36)
        Me.moveUpDir.TabIndex = 6
        Me.moveUpDir.UseVisualStyleBackColor = True
        '
        'openFile
        '
        Me.openFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.openFile.Image = Global.SortWare.My.Resources.Resources.wmploc_373
        Me.openFile.Location = New System.Drawing.Point(36, 0)
        Me.openFile.Margin = New System.Windows.Forms.Padding(0)
        Me.openFile.Name = "openFile"
        Me.openFile.Size = New System.Drawing.Size(39, 36)
        Me.openFile.TabIndex = 8
        Me.openFile.UseVisualStyleBackColor = True
        '
        'enterDir
        '
        Me.enterDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.enterDir.Location = New System.Drawing.Point(75, 0)
        Me.enterDir.Margin = New System.Windows.Forms.Padding(0)
        Me.enterDir.Name = "enterDir"
        Me.enterDir.Size = New System.Drawing.Size(36, 36)
        Me.enterDir.TabIndex = 7
        Me.enterDir.UseVisualStyleBackColor = True
        '
        'DeleteDirButton
        '
        Me.DeleteDirButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeleteDirButton.Location = New System.Drawing.Point(111, 0)
        Me.DeleteDirButton.Margin = New System.Windows.Forms.Padding(0)
        Me.DeleteDirButton.Name = "DeleteDirButton"
        Me.DeleteDirButton.Size = New System.Drawing.Size(39, 36)
        Me.DeleteDirButton.TabIndex = 9
        Me.DeleteDirButton.UseVisualStyleBackColor = True
        '
        'PurgeAllEmptyDirsButton
        '
        Me.PurgeAllEmptyDirsButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PurgeAllEmptyDirsButton.Location = New System.Drawing.Point(150, 0)
        Me.PurgeAllEmptyDirsButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PurgeAllEmptyDirsButton.Name = "PurgeAllEmptyDirsButton"
        Me.PurgeAllEmptyDirsButton.Size = New System.Drawing.Size(37, 36)
        Me.PurgeAllEmptyDirsButton.TabIndex = 10
        Me.PurgeAllEmptyDirsButton.UseVisualStyleBackColor = True
        '
        'FileTypeCheckBox
        '
        Me.FileTypeCheckBox.CheckBoxes = True
        Me.FileTypeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileTypeCheckBox.Location = New System.Drawing.Point(0, 0)
        Me.FileTypeCheckBox.Margin = New System.Windows.Forms.Padding(0)
        Me.FileTypeCheckBox.Name = "FileTypeCheckBox"
        TreeNode1.Name = "png"
        TreeNode1.Text = ".png"
        TreeNode2.Name = "jpeg jpg"
        TreeNode2.Text = ".jpeg/.jpg"
        TreeNode3.Name = "gif"
        TreeNode3.Text = ".gif"
        TreeNode4.Name = "Images"
        TreeNode4.Tag = "PARENT"
        TreeNode4.Text = "Images"
        TreeNode5.Name = "mp4"
        TreeNode5.Text = ".mp4"
        TreeNode6.Name = "webm"
        TreeNode6.Text = ".webm"
        TreeNode7.Name = "mov"
        TreeNode7.Text = ".mov"
        TreeNode8.Name = "avi"
        TreeNode8.Text = ".avi"
        TreeNode9.Name = "mkv"
        TreeNode9.Text = ".mkv"
        TreeNode10.Name = "m4v"
        TreeNode10.Text = ".m4v"
        TreeNode11.Name = "m2ts"
        TreeNode11.Text = ".m2ts"
        TreeNode12.Name = "Videos/Animations"
        TreeNode12.Tag = "PARENT"
        TreeNode12.Text = "Videos/Animations"
        Me.FileTypeCheckBox.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode12})
        Me.FileTypeCheckBox.Size = New System.Drawing.Size(143, 125)
        Me.FileTypeCheckBox.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RightSideTable, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1186, 512)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'RightSideTable
        '
        Me.RightSideTable.ColumnCount = 1
        Me.RightSideTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RightSideTable.Controls.Add(Me.TagsSelector, 0, 2)
        Me.RightSideTable.Controls.Add(Me.MainDirsBox, 0, 1)
        Me.RightSideTable.Controls.Add(Me.FileTypeCheckBox, 0, 0)
        Me.RightSideTable.Controls.Add(Me.MoveFilesButton, 0, 3)
        Me.RightSideTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightSideTable.Location = New System.Drawing.Point(1043, 0)
        Me.RightSideTable.Margin = New System.Windows.Forms.Padding(0)
        Me.RightSideTable.Name = "RightSideTable"
        Me.RightSideTable.RowCount = 4
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.RightSideTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.RightSideTable.Size = New System.Drawing.Size(143, 512)
        Me.RightSideTable.TabIndex = 1
        '
        'TagsSelector
        '
        Me.TagsSelector.ColumnWidth = 25
        Me.TagsSelector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagsSelector.FormattingEnabled = True
        Me.TagsSelector.Location = New System.Drawing.Point(0, 367)
        Me.TagsSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.TagsSelector.MultiColumn = True
        Me.TagsSelector.Name = "TagsSelector"
        Me.TagsSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.TagsSelector.Size = New System.Drawing.Size(143, 121)
        Me.TagsSelector.TabIndex = 6
        '
        'MainDirsBox
        '
        Me.MainDirsBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainDirsBox.FormattingEnabled = True
        Me.MainDirsBox.Location = New System.Drawing.Point(0, 125)
        Me.MainDirsBox.Margin = New System.Windows.Forms.Padding(0)
        Me.MainDirsBox.Name = "MainDirsBox"
        Me.MainDirsBox.Size = New System.Drawing.Size(143, 242)
        Me.MainDirsBox.TabIndex = 0
        '
        'MoveFilesButton
        '
        Me.MoveFilesButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveFilesButton.Location = New System.Drawing.Point(0, 488)
        Me.MoveFilesButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveFilesButton.Name = "MoveFilesButton"
        Me.MoveFilesButton.Size = New System.Drawing.Size(143, 24)
        Me.MoveFilesButton.TabIndex = 7
        Me.MoveFilesButton.Text = "Move File(s), Apply Tags"
        Me.MoveFilesButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'MainInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 534)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PresortDirPanels.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.RightSideTable.ResumeLayout(False)
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
    Friend WithEvents VlcControl1 As Vlc.DotNet.Forms.VlcControl
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ImagePreview As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PauseButton As ToolStripButton
    Friend WithEvents PlayButton As ToolStripButton
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents VideoScrollBar As HScrollBar
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents OpenPresortsButton As Button
    Friend WithEvents autoPlay As CheckBox
    Friend WithEvents miscControlsPanel As Panel
    Friend WithEvents openLogsButton As Button
    Friend WithEvents MainDirsBox As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RightSideTable As TableLayoutPanel
    Friend WithEvents TagsSelector As ListBox
    Friend WithEvents MoveFilesButton As Button
    Friend WithEvents PresortDirPanels As TableLayoutPanel
    Friend WithEvents moveUpDir As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents enterDir As Button
    Friend WithEvents FoldersToBeSorted As ListBox
    Friend WithEvents openFile As Button
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TrackBar1 As TrackBar
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
    Friend WithEvents Timer2 As Timer
    Friend WithEvents DeleteDirButton As Button
    Friend WithEvents PurgeAllEmptyDirsButton As Button
End Class
