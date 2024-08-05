using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class MainInterface : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            DirectoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            DirectorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            FindDirButtonToolTip = new ToolTip(components);
            FindRootDirButton = new Button();
            FindRootDirButton.Click += new EventHandler(FindRootDirButton_Click);
            FindPreSortedDirButton = new Button();
            FindPreSortedDirButton.Click += new EventHandler(FindPreSortedDirButton_Click);
            SaveRatingButton = new Button();
            SaveRatingButton.Click += new EventHandler(SaveRatingButton_Click);
            moveUpDir = new Button();
            moveUpDir.Click += new EventHandler(MoveUpDir_Click);
            enterDir = new Button();
            enterDir.Click += new EventHandler(EnterDir_Click);
            DeleteDirButton = new Button();
            DeleteDirButton.Click += new EventHandler(DeleteDirButton_Click);
            PurgeAllEmptyDirsButton = new Button();
            PurgeAllEmptyDirsButton.Click += new EventHandler(PurgeAllEmptyDirsButton_Click);
            MoveFolderButton = new Button();
            MoveFolderButton.Click += new EventHandler(MoveFolderButton_Click);
            MoveFilesButton = new Button();
            MoveFilesButton.Click += new EventHandler(MoveFilesButton_Click);
            AddUnderScoreButton = new Button();
            AddUnderScoreButton.Click += new EventHandler(AddUnderScoreButton_Click);
            MoveFolderSubDirButton = new Button();
            MoveFolderSubDirButton.Click += new EventHandler(MoveFolderSubDir_Click);
            StatusStrip1 = new StatusStrip();
            MiddleBarEmpty = new ToolStripStatusLabel();
            StatusLabel = new ToolStripStatusLabel();
            RootDirTextBox = new TextBox();
            PreSortedDirTextBox = new TextBox();
            OpenSortSettingsButton = new Button();
            OpenSortSettingsButton.Click += new EventHandler(OpenSortSettingsButton_Click);
            SplitContainer1 = new SplitContainer();
            TopBarTable = new TableLayoutPanel();
            Panel1 = new Panel();
            OpenPresortsButton = new Button();
            OpenPresortsButton.Click += new EventHandler(OpenPresortsButton_Click);
            miscControlsPanel = new Panel();
            FileSizeLabel = new Label();
            conversionsButton = new Button();
            conversionsButton.Click += new EventHandler(ConversionsButton_Click);
            VideoCheck = new CheckBox();
            VideoCheck.CheckedChanged += new EventHandler(Views_CheckedChanged);
            ImageCheck = new CheckBox();
            ImageCheck.CheckedChanged += new EventHandler(Views_CheckedChanged);
            DupeCheckerButton = new Button();
            DupeCheckerButton.Click += new EventHandler(DupeCheckerButton_Click);
            StatusStrip2 = new StatusStrip();
            PropertiesSaveStatus = new ToolStripStatusLabel();
            PropertiesViewButton = new Button();
            StarRatingPanel = new Panel();
            Star5 = new CheckBox();
            Star5.CheckedChanged += new EventHandler(StarRatingChanged);
            Star4 = new CheckBox();
            Star4.CheckedChanged += new EventHandler(StarRatingChanged);
            Star3 = new CheckBox();
            Star3.CheckedChanged += new EventHandler(StarRatingChanged);
            Star2 = new CheckBox();
            Star2.CheckedChanged += new EventHandler(StarRatingChanged);
            Star1 = new CheckBox();
            Star1.CheckedChanged += new EventHandler(StarRatingChanged);
            Label1 = new Label();
            VolumeBar = new TrackBar();
            VolumeBar.Scroll += new EventHandler(TrackBar1_Scroll);
            openLogsButton = new Button();
            openLogsButton.Click += new EventHandler(OpenLogsButton_Click);
            MediaAndPresortsSplit = new SplitContainer();
            PresortDirPanels = new TableLayoutPanel();
            TableLayoutPanel3 = new TableLayoutPanel();
            ClearFoldersFilterBtn = new Button();
            ClearFoldersFilterBtn.Click += new EventHandler(ClearFoldersFilterBtn_Click);
            ToBeSortedFoldersFilter = new TextBox();
            ToBeSortedFoldersFilter.TextChanged += new EventHandler(ToBeSortedFoldersFilter_TextChanged);
            Label3 = new Label();
            PresortFolderButtonsTable = new TableLayoutPanel();
            PresortFileToPresortFolderButton = new Button();
            PresortFileToPresortFolderButton.Click += new EventHandler(PresortFileToPresortFolderButton_Click);
            EmptyFoldersUpButton = new Button();
            EmptyFoldersUpButton.Click += new EventHandler(EmptyFoldersUpButton_Click);
            PresortTableLayout = new TableLayoutPanel();
            SortByComboBox = new ComboBox();
            SortByComboBox.SelectedIndexChanged += new EventHandler(SortByComboBox_SelectedIndexChanged);
            TableLayoutPanel2 = new TableLayoutPanel();
            ClearFilesFilterBtn = new Button();
            ClearFilesFilterBtn.Click += new EventHandler(ClearFilesFilterBtn_Click);
            ToBeSortedFilter = new TextBox();
            ToBeSortedFilter.TextChanged += new EventHandler(ToBeSortedFilter_TextChanged);
            SortByLabel = new Label();
            ToBeSortedFilterLabel = new Label();
            FilesToBeSorted = new ListBox();
            FilesToBeSorted.SelectedIndexChanged += new EventHandler(FilesToBeSorted_SelectedIndexChanged);
            FilesToBeSorted.MouseDown += new MouseEventHandler(FilesToBeSorted_MouseDown);
            FilesToBeSorted.GotFocus += new EventHandler(FilesToBeSorted_GotFocus);
            FilesToBeSorted.SelectedIndexChanged += new EventHandler(FilesToBeSorted_GotFocus);
            ToBeSortedLabel = new Label();
            FoldersToBeSorted = new ListBox();
            FoldersToBeSorted.GotFocus += new EventHandler(FoldersToBeSorted_GotFocus);
            FoldersToBeSorted.SelectedIndexChanged += new EventHandler(FoldersToBeSorted_GotFocus);
            MainDirsButtonsTable = new TableLayoutPanel();
            openFile = new Button();
            openFile.MouseDown += new MouseEventHandler(OpenFile_Click);
            TableLayoutPanel1 = new TableLayoutPanel();
            MainDirsFilter = new TextBox();
            MainDirsFilter.TextChanged += new EventHandler(MainDirsFilter_TextChanged);
            ClearDirFilterBtn = new Button();
            ClearDirFilterBtn.Click += new EventHandler(ClearDirFilterBtn_Click);
            ColorDialog1 = new ColorDialog();
            RightSideTable = new TableLayoutPanel();
            MainDirsTable = new TableLayoutPanel();
            Label2 = new Label();
            MainDirsTree = new TreeView();
            MainDirsTree.AfterSelect += new TreeViewEventHandler(MainDirsTree_SelectedNodeChanged);
            MainDirsLabel = new Label();
            TagsSelector = new ListBox();
            TagsSelector.SelectedIndexChanged += new EventHandler(TagsSelector_SelectedIndexChanged);
            UnderScoreManagerTable = new TableLayoutPanel();
            UnderScoreAddUpDown = new NumericUpDown();
            UnderScoreAddUpDown.ValueChanged += new EventHandler(UnderScoreAddUpDown_ValueChanged);
            ImageList1 = new ImageList(components);
            AlertTimer = new Timer(components);
            AlertTimer.Tick += new EventHandler(AlertTimer_Tick);
            SplitContainer2 = new SplitContainer();
            FileRightClickContextMenu = new ContextMenuStrip(components);
            RenameToolStripMenuItem = new ToolStripMenuItem();
            RenameToolStripMenuItem.Click += new EventHandler(RenameToolStripMenuItem_Click);
            GroupToolStripMenuItem1 = new ToolStripMenuItem();
            GroupToolStripMenuItem1.Click += new EventHandler(GroupToolStripMenuItem1_Click);
            MediaViewer1 = new MediaViewer();
            MediaViewer1.VlcMediaChanged += new MediaViewer.VlcMediaChangedEventHandler(VlcControl1_MediaChanged);
            TypeSelector1 = new TypeSelector();
            TypeSelector1.CheckChanged += new TypeSelector.CheckChangedEventHandler(TypeSelector1_CheckChangeded);
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer1).BeginInit();
            SplitContainer1.Panel1.SuspendLayout();
            SplitContainer1.Panel2.SuspendLayout();
            SplitContainer1.SuspendLayout();
            TopBarTable.SuspendLayout();
            Panel1.SuspendLayout();
            miscControlsPanel.SuspendLayout();
            StatusStrip2.SuspendLayout();
            StarRatingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MediaAndPresortsSplit).BeginInit();
            MediaAndPresortsSplit.Panel1.SuspendLayout();
            MediaAndPresortsSplit.Panel2.SuspendLayout();
            MediaAndPresortsSplit.SuspendLayout();
            PresortDirPanels.SuspendLayout();
            TableLayoutPanel3.SuspendLayout();
            PresortFolderButtonsTable.SuspendLayout();
            PresortTableLayout.SuspendLayout();
            TableLayoutPanel2.SuspendLayout();
            MainDirsButtonsTable.SuspendLayout();
            TableLayoutPanel1.SuspendLayout();
            RightSideTable.SuspendLayout();
            MainDirsTable.SuspendLayout();
            UnderScoreManagerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UnderScoreAddUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SplitContainer2).BeginInit();
            SplitContainer2.Panel1.SuspendLayout();
            SplitContainer2.Panel2.SuspendLayout();
            SplitContainer2.SuspendLayout();
            FileRightClickContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // DirectorySearcher1
            // 
            DirectorySearcher1.ClientTimeout = TimeSpan.Parse("-00:00:01");
            DirectorySearcher1.ServerPageTimeLimit = TimeSpan.Parse("-00:00:01");
            DirectorySearcher1.ServerTimeLimit = TimeSpan.Parse("-00:00:01");
            // 
            // FindDirButtonToolTip
            // 
            FindDirButtonToolTip.BackColor = Color.Khaki;
            // 
            // FindRootDirButton
            // 
            FindRootDirButton.Location = new Point(0, 0);
            FindRootDirButton.Name = "FindRootDirButton";
            FindRootDirButton.Size = new Size(96, 47);
            FindRootDirButton.TabIndex = 1;
            FindRootDirButton.Text = "Choose Root Directory";
            FindDirButtonToolTip.SetToolTip(FindRootDirButton, "The Root directory is your earliest single folder where all files and other direc" + "tories are located.");
            FindRootDirButton.UseVisualStyleBackColor = true;
            // 
            // FindPreSortedDirButton
            // 
            FindPreSortedDirButton.Location = new Point(0, 53);
            FindPreSortedDirButton.Name = "FindPreSortedDirButton";
            FindPreSortedDirButton.Size = new Size(96, 47);
            FindPreSortedDirButton.TabIndex = 2;
            FindPreSortedDirButton.Text = "Choose Pre-sorted Directory";
            FindDirButtonToolTip.SetToolTip(FindPreSortedDirButton, "The Root directory is your earliest single folder where all files and other direc" + "tories are located.");
            FindPreSortedDirButton.UseVisualStyleBackColor = true;
            // 
            // SaveRatingButton
            // 
            SaveRatingButton.Location = new Point(325, 4);
            SaveRatingButton.Name = "SaveRatingButton";
            SaveRatingButton.Size = new Size(33, 33);
            SaveRatingButton.TabIndex = 9;
            FindDirButtonToolTip.SetToolTip(SaveRatingButton, "Save the rating of the current file");
            SaveRatingButton.UseVisualStyleBackColor = true;
            // 
            // moveUpDir
            // 
            moveUpDir.Dock = DockStyle.Fill;
            moveUpDir.Location = new Point(0, 0);
            moveUpDir.Margin = new Padding(0);
            moveUpDir.Name = "moveUpDir";
            moveUpDir.Size = new Size(36, 37);
            moveUpDir.TabIndex = 6;
            FindDirButtonToolTip.SetToolTip(moveUpDir, "Exit the current folder-to-be-sorted");
            moveUpDir.UseVisualStyleBackColor = true;
            // 
            // enterDir
            // 
            enterDir.Dock = DockStyle.Fill;
            enterDir.Location = new Point(72, 0);
            enterDir.Margin = new Padding(0);
            enterDir.Name = "enterDir";
            enterDir.Size = new Size(36, 37);
            enterDir.TabIndex = 8;
            FindDirButtonToolTip.SetToolTip(enterDir, "Enter the selected folder-to-be-sorted");
            enterDir.UseVisualStyleBackColor = true;
            // 
            // DeleteDirButton
            // 
            DeleteDirButton.Dock = DockStyle.Fill;
            DeleteDirButton.Location = new Point(108, 0);
            DeleteDirButton.Margin = new Padding(0);
            DeleteDirButton.Name = "DeleteDirButton";
            DeleteDirButton.Size = new Size(36, 37);
            DeleteDirButton.TabIndex = 9;
            FindDirButtonToolTip.SetToolTip(DeleteDirButton, "Delete the selected folder-to-be-sorted");
            DeleteDirButton.UseVisualStyleBackColor = true;
            // 
            // PurgeAllEmptyDirsButton
            // 
            PurgeAllEmptyDirsButton.Dock = DockStyle.Fill;
            PurgeAllEmptyDirsButton.Location = new Point(144, 0);
            PurgeAllEmptyDirsButton.Margin = new Padding(0);
            PurgeAllEmptyDirsButton.Name = "PurgeAllEmptyDirsButton";
            PurgeAllEmptyDirsButton.Size = new Size(38, 37);
            PurgeAllEmptyDirsButton.TabIndex = 10;
            FindDirButtonToolTip.SetToolTip(PurgeAllEmptyDirsButton, " Deletes all empty folders in the presort directory");
            PurgeAllEmptyDirsButton.UseVisualStyleBackColor = true;
            // 
            // MoveFolderButton
            // 
            MoveFolderButton.Dock = DockStyle.Fill;
            MoveFolderButton.Location = new Point(0, 465);
            MoveFolderButton.Margin = new Padding(0);
            MoveFolderButton.Name = "MoveFolderButton";
            MoveFolderButton.Size = new Size(236, 23);
            MoveFolderButton.TabIndex = 5;
            MoveFolderButton.Text = "Move Folder, Apply Tags";
            FindDirButtonToolTip.SetToolTip(MoveFolderButton, "Move the selected folder to the selected folder and apply the selected tags to th" + "e start of the folder name");
            MoveFolderButton.UseVisualStyleBackColor = true;
            // 
            // MoveFilesButton
            // 
            MoveFilesButton.Dock = DockStyle.Fill;
            MoveFilesButton.Location = new Point(0, 442);
            MoveFilesButton.Margin = new Padding(0);
            MoveFilesButton.Name = "MoveFilesButton";
            MoveFilesButton.Size = new Size(236, 23);
            MoveFilesButton.TabIndex = 4;
            MoveFilesButton.Text = "Move File(s), Apply Tags";
            FindDirButtonToolTip.SetToolTip(MoveFilesButton, "Move the selected file(s) to the selected folder and apply the selected tags to t" + "he start of the filename(s)");
            MoveFilesButton.UseVisualStyleBackColor = true;
            // 
            // AddUnderScoreButton
            // 
            AddUnderScoreButton.Dock = DockStyle.Fill;
            AddUnderScoreButton.Location = new Point(118, 0);
            AddUnderScoreButton.Margin = new Padding(0);
            AddUnderScoreButton.Name = "AddUnderScoreButton";
            AddUnderScoreButton.Size = new Size(118, 23);
            AddUnderScoreButton.TabIndex = 1;
            AddUnderScoreButton.Text = "Add x \"_\"";
            FindDirButtonToolTip.SetToolTip(AddUnderScoreButton, "Add the specified number of underscores to the start of the filename (useful if f" + "ile is unratable or numeric tagging is unavailable)");
            AddUnderScoreButton.UseVisualStyleBackColor = true;
            // 
            // MoveFolderSubDirButton
            // 
            MoveFolderSubDirButton.Dock = DockStyle.Fill;
            MoveFolderSubDirButton.Location = new Point(0, 488);
            MoveFolderSubDirButton.Margin = new Padding(0);
            MoveFolderSubDirButton.Name = "MoveFolderSubDirButton";
            MoveFolderSubDirButton.Size = new Size(236, 24);
            MoveFolderSubDirButton.TabIndex = 16;
            MoveFolderSubDirButton.Text = "Move Folder, Add As Main Subdirectory";
            FindDirButtonToolTip.SetToolTip(MoveFolderSubDirButton, "Add the specified number of underscores to the start of the filename (useful if f" + "ile is unratable or numeric tagging is unavailable)");
            MoveFolderSubDirButton.UseVisualStyleBackColor = true;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { MiddleBarEmpty, StatusLabel });
            StatusStrip1.Location = new Point(0, 512);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(1186, 22);
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // MiddleBarEmpty
            // 
            MiddleBarEmpty.Name = "MiddleBarEmpty";
            MiddleBarEmpty.Size = new Size(1171, 17);
            MiddleBarEmpty.Spring = true;
            MiddleBarEmpty.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 17);
            // 
            // RootDirTextBox
            // 
            RootDirTextBox.Location = new Point(102, 0);
            RootDirTextBox.Name = "RootDirTextBox";
            RootDirTextBox.Size = new Size(355, 20);
            RootDirTextBox.TabIndex = 1;
            // 
            // PreSortedDirTextBox
            // 
            PreSortedDirTextBox.Location = new Point(102, 53);
            PreSortedDirTextBox.Name = "PreSortedDirTextBox";
            PreSortedDirTextBox.Size = new Size(355, 20);
            PreSortedDirTextBox.TabIndex = 3;
            // 
            // OpenSortSettingsButton
            // 
            OpenSortSettingsButton.AutoSize = true;
            OpenSortSettingsButton.FlatStyle = FlatStyle.Flat;
            OpenSortSettingsButton.Location = new Point(102, 22);
            OpenSortSettingsButton.Name = "OpenSortSettingsButton";
            OpenSortSettingsButton.Size = new Size(144, 25);
            OpenSortSettingsButton.TabIndex = 4;
            OpenSortSettingsButton.Text = "Open Folder Settings";
            OpenSortSettingsButton.UseVisualStyleBackColor = true;
            // 
            // SplitContainer1
            // 
            SplitContainer1.BorderStyle = BorderStyle.Fixed3D;
            SplitContainer1.Dock = DockStyle.Fill;
            SplitContainer1.FixedPanel = FixedPanel.Panel1;
            SplitContainer1.IsSplitterFixed = true;
            SplitContainer1.Location = new Point(0, 0);
            SplitContainer1.Margin = new Padding(0);
            SplitContainer1.Name = "SplitContainer1";
            SplitContainer1.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            SplitContainer1.Panel1.Controls.Add(TopBarTable);
            // 
            // SplitContainer1.Panel2
            // 
            SplitContainer1.Panel2.Controls.Add(MediaAndPresortsSplit);
            SplitContainer1.Size = new Size(946, 512);
            SplitContainer1.SplitterDistance = 105;
            SplitContainer1.TabIndex = 0;
            // 
            // TopBarTable
            // 
            TopBarTable.ColumnCount = 2;
            TopBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TopBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TopBarTable.Controls.Add(Panel1, 0, 0);
            TopBarTable.Controls.Add(miscControlsPanel, 1, 0);
            TopBarTable.Dock = DockStyle.Fill;
            TopBarTable.Location = new Point(0, 0);
            TopBarTable.Margin = new Padding(0);
            TopBarTable.Name = "TopBarTable";
            TopBarTable.RowCount = 1;
            TopBarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TopBarTable.Size = new Size(942, 101);
            TopBarTable.TabIndex = 5;
            // 
            // Panel1
            // 
            Panel1.Controls.Add(OpenPresortsButton);
            Panel1.Controls.Add(PreSortedDirTextBox);
            Panel1.Controls.Add(RootDirTextBox);
            Panel1.Controls.Add(FindPreSortedDirButton);
            Panel1.Controls.Add(FindRootDirButton);
            Panel1.Controls.Add(OpenSortSettingsButton);
            Panel1.Dock = DockStyle.Fill;
            Panel1.Location = new Point(0, 0);
            Panel1.Margin = new Padding(0);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(471, 101);
            Panel1.TabIndex = 0;
            // 
            // OpenPresortsButton
            // 
            OpenPresortsButton.AutoSize = true;
            OpenPresortsButton.FlatStyle = FlatStyle.Flat;
            OpenPresortsButton.Location = new Point(102, 75);
            OpenPresortsButton.Name = "OpenPresortsButton";
            OpenPresortsButton.Size = new Size(207, 25);
            OpenPresortsButton.TabIndex = 5;
            OpenPresortsButton.Text = "Select Pre-sorted Directory from settings";
            OpenPresortsButton.UseVisualStyleBackColor = true;
            // 
            // miscControlsPanel
            // 
            miscControlsPanel.Controls.Add(FileSizeLabel);
            miscControlsPanel.Controls.Add(conversionsButton);
            miscControlsPanel.Controls.Add(VideoCheck);
            miscControlsPanel.Controls.Add(ImageCheck);
            miscControlsPanel.Controls.Add(DupeCheckerButton);
            miscControlsPanel.Controls.Add(StatusStrip2);
            miscControlsPanel.Controls.Add(SaveRatingButton);
            miscControlsPanel.Controls.Add(PropertiesViewButton);
            miscControlsPanel.Controls.Add(StarRatingPanel);
            miscControlsPanel.Controls.Add(Label1);
            miscControlsPanel.Controls.Add(VolumeBar);
            miscControlsPanel.Controls.Add(openLogsButton);
            miscControlsPanel.Dock = DockStyle.Fill;
            miscControlsPanel.Location = new Point(471, 0);
            miscControlsPanel.Margin = new Padding(0);
            miscControlsPanel.Name = "miscControlsPanel";
            miscControlsPanel.Size = new Size(471, 101);
            miscControlsPanel.TabIndex = 1;
            // 
            // FileSizeLabel
            // 
            FileSizeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FileSizeLabel.AutoSize = true;
            FileSizeLabel.Location = new Point(120, 66);
            FileSizeLabel.Name = "FileSizeLabel";
            FileSizeLabel.RightToLeft = RightToLeft.No;
            FileSizeLabel.Size = new Size(25, 13);
            FileSizeLabel.TabIndex = 15;
            FileSizeLabel.Text = "------";
            FileSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // conversionsButton
            // 
            conversionsButton.Location = new Point(6, 27);
            conversionsButton.Name = "conversionsButton";
            conversionsButton.Size = new Size(108, 23);
            conversionsButton.TabIndex = 14;
            conversionsButton.Text = "File Conversion";
            conversionsButton.UseVisualStyleBackColor = true;
            // 
            // VideoCheck
            // 
            VideoCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            VideoCheck.AutoSize = true;
            VideoCheck.Checked = true;
            VideoCheck.CheckState = CheckState.Checked;
            VideoCheck.Location = new Point(364, 58);
            VideoCheck.Name = "VideoCheck";
            VideoCheck.Size = new Size(84, 17);
            VideoCheck.TabIndex = 13;
            VideoCheck.Text = "View Videos";
            VideoCheck.UseVisualStyleBackColor = true;
            // 
            // ImageCheck
            // 
            ImageCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImageCheck.AutoSize = true;
            ImageCheck.Checked = true;
            ImageCheck.CheckState = CheckState.Checked;
            ImageCheck.Location = new Point(364, 43);
            ImageCheck.Name = "ImageCheck";
            ImageCheck.Size = new Size(86, 17);
            ImageCheck.TabIndex = 12;
            ImageCheck.Text = "View Images";
            ImageCheck.UseVisualStyleBackColor = true;
            // 
            // DupeCheckerButton
            // 
            DupeCheckerButton.Location = new Point(364, 3);
            DupeCheckerButton.Name = "DupeCheckerButton";
            DupeCheckerButton.Size = new Size(104, 34);
            DupeCheckerButton.TabIndex = 11;
            DupeCheckerButton.Text = "Open Dupe Checker";
            DupeCheckerButton.UseVisualStyleBackColor = true;
            // 
            // StatusStrip2
            // 
            StatusStrip2.Items.AddRange(new ToolStripItem[] { PropertiesSaveStatus });
            StatusStrip2.Location = new Point(0, 79);
            StatusStrip2.Name = "StatusStrip2";
            StatusStrip2.Size = new Size(471, 22);
            StatusStrip2.TabIndex = 10;
            StatusStrip2.Text = "StatusStrip2";
            // 
            // PropertiesSaveStatus
            // 
            PropertiesSaveStatus.Name = "PropertiesSaveStatus";
            PropertiesSaveStatus.Size = new Size(0, 17);
            // 
            // PropertiesViewButton
            // 
            PropertiesViewButton.Location = new Point(6, 50);
            PropertiesViewButton.Name = "PropertiesViewButton";
            PropertiesViewButton.Size = new Size(108, 25);
            PropertiesViewButton.TabIndex = 7;
            PropertiesViewButton.Text = "View File Properties";
            PropertiesViewButton.UseVisualStyleBackColor = true;
            // 
            // StarRatingPanel
            // 
            StarRatingPanel.Controls.Add(Star5);
            StarRatingPanel.Controls.Add(Star4);
            StarRatingPanel.Controls.Add(Star3);
            StarRatingPanel.Controls.Add(Star2);
            StarRatingPanel.Controls.Add(Star1);
            StarRatingPanel.Enabled = false;
            StarRatingPanel.Location = new Point(120, 3);
            StarRatingPanel.Name = "StarRatingPanel";
            StarRatingPanel.Size = new Size(199, 38);
            StarRatingPanel.TabIndex = 8;
            // 
            // Star5
            // 
            Star5.AutoSize = true;
            Star5.Location = new Point(155, 13);
            Star5.Name = "Star5";
            Star5.Size = new Size(32, 17);
            Star5.TabIndex = 4;
            Star5.Text = "5";
            Star5.UseVisualStyleBackColor = true;
            // 
            // Star4
            // 
            Star4.AutoSize = true;
            Star4.Location = new Point(117, 13);
            Star4.Name = "Star4";
            Star4.Size = new Size(32, 17);
            Star4.TabIndex = 3;
            Star4.Text = "4";
            Star4.UseVisualStyleBackColor = true;
            // 
            // Star3
            // 
            Star3.AutoSize = true;
            Star3.Location = new Point(79, 13);
            Star3.Name = "Star3";
            Star3.Size = new Size(32, 17);
            Star3.TabIndex = 2;
            Star3.Text = "3";
            Star3.UseVisualStyleBackColor = true;
            // 
            // Star2
            // 
            Star2.AutoSize = true;
            Star2.Location = new Point(41, 13);
            Star2.Name = "Star2";
            Star2.Size = new Size(32, 17);
            Star2.TabIndex = 1;
            Star2.Text = "2";
            Star2.UseVisualStyleBackColor = true;
            // 
            // Star1
            // 
            Star1.AutoSize = true;
            Star1.Location = new Point(3, 13);
            Star1.Name = "Star1";
            Star1.Size = new Size(32, 17);
            Star1.TabIndex = 0;
            Star1.Text = "1";
            Star1.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.Cursor = Cursors.Cross;
            Label1.Location = new Point(203, 57);
            Label1.Name = "Label1";
            Label1.Size = new Size(52, 16);
            Label1.TabIndex = 0;
            Label1.Text = "Volume";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VolumeBar
            // 
            VolumeBar.Location = new Point(120, 44);
            VolumeBar.Maximum = 100;
            VolumeBar.Name = "VolumeBar";
            VolumeBar.Size = new Size(238, 45);
            VolumeBar.TabIndex = 6;
            VolumeBar.TickFrequency = 5;
            VolumeBar.TickStyle = TickStyle.None;
            // 
            // openLogsButton
            // 
            openLogsButton.Enabled = false;
            openLogsButton.Location = new Point(6, 4);
            openLogsButton.Name = "openLogsButton";
            openLogsButton.Size = new Size(108, 23);
            openLogsButton.TabIndex = 5;
            openLogsButton.Text = "Open Move Logs";
            openLogsButton.UseVisualStyleBackColor = true;
            // 
            // MediaAndPresortsSplit
            // 
            MediaAndPresortsSplit.Dock = DockStyle.Fill;
            MediaAndPresortsSplit.Location = new Point(0, 0);
            MediaAndPresortsSplit.Margin = new Padding(0);
            MediaAndPresortsSplit.Name = "MediaAndPresortsSplit";
            // 
            // MediaAndPresortsSplit.Panel1
            // 
            MediaAndPresortsSplit.Panel1.Controls.Add(PresortDirPanels);
            // 
            // MediaAndPresortsSplit.Panel2
            // 
            MediaAndPresortsSplit.Panel2.Controls.Add(MediaViewer1);
            MediaAndPresortsSplit.Size = new Size(942, 399);
            MediaAndPresortsSplit.SplitterDistance = 182;
            MediaAndPresortsSplit.TabIndex = 0;
            // 
            // PresortDirPanels
            // 
            PresortDirPanels.AutoSize = true;
            PresortDirPanels.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PresortDirPanels.ColumnCount = 1;
            PresortDirPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            PresortDirPanels.Controls.Add(TableLayoutPanel3, 0, 3);
            PresortDirPanels.Controls.Add(Label3, 0, 2);
            PresortDirPanels.Controls.Add(PresortFolderButtonsTable, 0, 1);
            PresortDirPanels.Controls.Add(PresortTableLayout, 0, 0);
            PresortDirPanels.Controls.Add(FoldersToBeSorted, 0, 4);
            PresortDirPanels.Controls.Add(MainDirsButtonsTable, 0, 5);
            PresortDirPanels.Dock = DockStyle.Fill;
            PresortDirPanels.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            PresortDirPanels.Location = new Point(0, 0);
            PresortDirPanels.Margin = new Padding(0);
            PresortDirPanels.Name = "PresortDirPanels";
            PresortDirPanels.RowCount = 6;
            PresortDirPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 75.0f));
            PresortDirPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 56.0f));
            PresortDirPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            PresortDirPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            PresortDirPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 25.0f));
            PresortDirPanels.RowStyles.Add(new RowStyle(SizeType.Absolute, 36.0f));
            PresortDirPanels.Size = new Size(182, 399);
            PresortDirPanels.TabIndex = 0;
            // 
            // TableLayoutPanel3
            // 
            TableLayoutPanel3.ColumnCount = 2;
            TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel3.Controls.Add(ClearFoldersFilterBtn, 1, 0);
            TableLayoutPanel3.Controls.Add(ToBeSortedFoldersFilter, 0, 0);
            TableLayoutPanel3.Dock = DockStyle.Fill;
            TableLayoutPanel3.Location = new Point(0, 276);
            TableLayoutPanel3.Margin = new Padding(0);
            TableLayoutPanel3.Name = "TableLayoutPanel3";
            TableLayoutPanel3.RowCount = 1;
            TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel3.Size = new Size(182, 20);
            TableLayoutPanel3.TabIndex = 8;
            // 
            // ClearFoldersFilterBtn
            // 
            ClearFoldersFilterBtn.Dock = DockStyle.Fill;
            ClearFoldersFilterBtn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearFoldersFilterBtn.Location = new Point(162, 0);
            ClearFoldersFilterBtn.Margin = new Padding(0);
            ClearFoldersFilterBtn.Name = "ClearFoldersFilterBtn";
            ClearFoldersFilterBtn.Size = new Size(20, 20);
            ClearFoldersFilterBtn.TabIndex = 0;
            ClearFoldersFilterBtn.Text = "X";
            ClearFoldersFilterBtn.UseVisualStyleBackColor = true;
            // 
            // ToBeSortedFoldersFilter
            // 
            ToBeSortedFoldersFilter.Dock = DockStyle.Fill;
            ToBeSortedFoldersFilter.Location = new Point(0, 0);
            ToBeSortedFoldersFilter.Margin = new Padding(0);
            ToBeSortedFoldersFilter.Name = "ToBeSortedFoldersFilter";
            ToBeSortedFoldersFilter.Size = new Size(162, 20);
            ToBeSortedFoldersFilter.TabIndex = 1;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Dock = DockStyle.Fill;
            Label3.Location = new Point(3, 256);
            Label3.Name = "Label3";
            Label3.Size = new Size(176, 20);
            Label3.TabIndex = 7;
            Label3.Text = "Filter folders by name";
            // 
            // PresortFolderButtonsTable
            // 
            PresortFolderButtonsTable.ColumnCount = 2;
            PresortFolderButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.45454f));
            PresortFolderButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.54546f));
            PresortFolderButtonsTable.Controls.Add(PresortFileToPresortFolderButton, 0, 0);
            PresortFolderButtonsTable.Controls.Add(EmptyFoldersUpButton, 1, 0);
            PresortFolderButtonsTable.Dock = DockStyle.Fill;
            PresortFolderButtonsTable.Location = new Point(0, 200);
            PresortFolderButtonsTable.Margin = new Padding(0);
            PresortFolderButtonsTable.Name = "PresortFolderButtonsTable";
            PresortFolderButtonsTable.RowCount = 1;
            PresortFolderButtonsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            PresortFolderButtonsTable.Size = new Size(182, 56);
            PresortFolderButtonsTable.TabIndex = 6;
            // 
            // PresortFileToPresortFolderButton
            // 
            PresortFileToPresortFolderButton.Dock = DockStyle.Fill;
            PresortFileToPresortFolderButton.Location = new Point(0, 0);
            PresortFileToPresortFolderButton.Margin = new Padding(0);
            PresortFileToPresortFolderButton.Name = "PresortFileToPresortFolderButton";
            PresortFileToPresortFolderButton.Size = new Size(82, 56);
            PresortFileToPresortFolderButton.TabIndex = 5;
            PresortFileToPresortFolderButton.Text = "Move File to Presort Folder" + '\r' + '\n' + "⇓";
            PresortFileToPresortFolderButton.UseVisualStyleBackColor = true;
            // 
            // EmptyFoldersUpButton
            // 
            EmptyFoldersUpButton.Dock = DockStyle.Fill;
            EmptyFoldersUpButton.Location = new Point(82, 0);
            EmptyFoldersUpButton.Margin = new Padding(0);
            EmptyFoldersUpButton.Name = "EmptyFoldersUpButton";
            EmptyFoldersUpButton.Size = new Size(100, 56);
            EmptyFoldersUpButton.TabIndex = 6;
            EmptyFoldersUpButton.Text = "⇑" + '\r' + '\n' + "Move Up Files In Selected Folders";
            EmptyFoldersUpButton.UseVisualStyleBackColor = true;
            // 
            // PresortTableLayout
            // 
            PresortTableLayout.ColumnCount = 1;
            PresortTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            PresortTableLayout.Controls.Add(SortByComboBox, 0, 1);
            PresortTableLayout.Controls.Add(TableLayoutPanel2, 0, 3);
            PresortTableLayout.Controls.Add(SortByLabel, 0, 0);
            PresortTableLayout.Controls.Add(ToBeSortedFilterLabel, 0, 2);
            PresortTableLayout.Controls.Add(FilesToBeSorted, 0, 5);
            PresortTableLayout.Controls.Add(ToBeSortedLabel, 0, 4);
            PresortTableLayout.Dock = DockStyle.Fill;
            PresortTableLayout.Location = new Point(0, 0);
            PresortTableLayout.Margin = new Padding(0);
            PresortTableLayout.Name = "PresortTableLayout";
            PresortTableLayout.RowCount = 6;
            PresortTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 13.0f));
            PresortTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 21.0f));
            PresortTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 13.0f));
            PresortTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            PresortTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 13.0f));
            PresortTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            PresortTableLayout.Size = new Size(182, 200);
            PresortTableLayout.TabIndex = 0;
            // 
            // SortByComboBox
            // 
            SortByComboBox.Dock = DockStyle.Fill;
            SortByComboBox.FormattingEnabled = true;
            SortByComboBox.Items.AddRange(new object[] { "----", "Date", "Name", "Size", "Filetype" });
            SortByComboBox.Location = new Point(0, 13);
            SortByComboBox.Margin = new Padding(0);
            SortByComboBox.Name = "SortByComboBox";
            SortByComboBox.Size = new Size(182, 21);
            SortByComboBox.TabIndex = 6;
            SortByComboBox.Text = "----";
            // 
            // TableLayoutPanel2
            // 
            TableLayoutPanel2.ColumnCount = 2;
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel2.Controls.Add(ClearFilesFilterBtn, 1, 0);
            TableLayoutPanel2.Controls.Add(ToBeSortedFilter, 0, 0);
            TableLayoutPanel2.Dock = DockStyle.Fill;
            TableLayoutPanel2.Location = new Point(0, 47);
            TableLayoutPanel2.Margin = new Padding(0);
            TableLayoutPanel2.Name = "TableLayoutPanel2";
            TableLayoutPanel2.RowCount = 1;
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel2.Size = new Size(182, 20);
            TableLayoutPanel2.TabIndex = 1;
            // 
            // ClearFilesFilterBtn
            // 
            ClearFilesFilterBtn.Dock = DockStyle.Fill;
            ClearFilesFilterBtn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearFilesFilterBtn.Location = new Point(162, 0);
            ClearFilesFilterBtn.Margin = new Padding(0);
            ClearFilesFilterBtn.Name = "ClearFilesFilterBtn";
            ClearFilesFilterBtn.Size = new Size(20, 20);
            ClearFilesFilterBtn.TabIndex = 0;
            ClearFilesFilterBtn.Text = "X";
            ClearFilesFilterBtn.UseVisualStyleBackColor = true;
            // 
            // ToBeSortedFilter
            // 
            ToBeSortedFilter.Dock = DockStyle.Fill;
            ToBeSortedFilter.Location = new Point(0, 0);
            ToBeSortedFilter.Margin = new Padding(0);
            ToBeSortedFilter.Name = "ToBeSortedFilter";
            ToBeSortedFilter.Size = new Size(162, 20);
            ToBeSortedFilter.TabIndex = 1;
            // 
            // SortByLabel
            // 
            SortByLabel.AutoSize = true;
            SortByLabel.Dock = DockStyle.Fill;
            SortByLabel.Location = new Point(3, 0);
            SortByLabel.Name = "SortByLabel";
            SortByLabel.Size = new Size(176, 13);
            SortByLabel.TabIndex = 7;
            SortByLabel.Text = "Sort By";
            // 
            // ToBeSortedFilterLabel
            // 
            ToBeSortedFilterLabel.AutoSize = true;
            ToBeSortedFilterLabel.Dock = DockStyle.Fill;
            ToBeSortedFilterLabel.Location = new Point(3, 34);
            ToBeSortedFilterLabel.Name = "ToBeSortedFilterLabel";
            ToBeSortedFilterLabel.Size = new Size(176, 13);
            ToBeSortedFilterLabel.TabIndex = 3;
            ToBeSortedFilterLabel.Text = "Filter files by name";
            // 
            // FilesToBeSorted
            // 
            FilesToBeSorted.Dock = DockStyle.Fill;
            FilesToBeSorted.FormattingEnabled = true;
            FilesToBeSorted.Location = new Point(0, 80);
            FilesToBeSorted.Margin = new Padding(0);
            FilesToBeSorted.Name = "FilesToBeSorted";
            FilesToBeSorted.SelectionMode = SelectionMode.MultiExtended;
            FilesToBeSorted.Size = new Size(182, 120);
            FilesToBeSorted.TabIndex = 0;
            // 
            // ToBeSortedLabel
            // 
            ToBeSortedLabel.AutoSize = true;
            ToBeSortedLabel.Dock = DockStyle.Fill;
            ToBeSortedLabel.Location = new Point(3, 67);
            ToBeSortedLabel.Name = "ToBeSortedLabel";
            ToBeSortedLabel.Size = new Size(176, 13);
            ToBeSortedLabel.TabIndex = 2;
            ToBeSortedLabel.Text = "Files To Be Sorted";
            // 
            // FoldersToBeSorted
            // 
            FoldersToBeSorted.Dock = DockStyle.Fill;
            FoldersToBeSorted.FormattingEnabled = true;
            FoldersToBeSorted.Location = new Point(0, 296);
            FoldersToBeSorted.Margin = new Padding(0);
            FoldersToBeSorted.Name = "FoldersToBeSorted";
            FoldersToBeSorted.SelectionMode = SelectionMode.MultiExtended;
            FoldersToBeSorted.Size = new Size(182, 66);
            FoldersToBeSorted.TabIndex = 1;
            // 
            // MainDirsButtonsTable
            // 
            MainDirsButtonsTable.ColumnCount = 5;
            MainDirsButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0f));
            MainDirsButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0f));
            MainDirsButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0f));
            MainDirsButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0f));
            MainDirsButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0f));
            MainDirsButtonsTable.Controls.Add(moveUpDir, 0, 0);
            MainDirsButtonsTable.Controls.Add(openFile, 1, 0);
            MainDirsButtonsTable.Controls.Add(enterDir, 2, 0);
            MainDirsButtonsTable.Controls.Add(DeleteDirButton, 3, 0);
            MainDirsButtonsTable.Controls.Add(PurgeAllEmptyDirsButton, 4, 0);
            MainDirsButtonsTable.Dock = DockStyle.Fill;
            MainDirsButtonsTable.Location = new Point(0, 362);
            MainDirsButtonsTable.Margin = new Padding(0);
            MainDirsButtonsTable.Name = "MainDirsButtonsTable";
            MainDirsButtonsTable.RowCount = 1;
            MainDirsButtonsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            MainDirsButtonsTable.Size = new Size(182, 37);
            MainDirsButtonsTable.TabIndex = 3;
            // 
            // openFile
            // 
            openFile.Dock = DockStyle.Fill;
            openFile.Image = (Image)resources.GetObject("openFile.Image");
            openFile.Location = new Point(36, 0);
            openFile.Margin = new Padding(0);
            openFile.Name = "openFile";
            openFile.Size = new Size(36, 37);
            openFile.TabIndex = 7;
            openFile.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel1.Controls.Add(MainDirsFilter, 0, 0);
            TableLayoutPanel1.Controls.Add(ClearDirFilterBtn, 1, 0);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 13);
            TableLayoutPanel1.Margin = new Padding(0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Size = new Size(236, 20);
            TableLayoutPanel1.TabIndex = 1;
            // 
            // MainDirsFilter
            // 
            MainDirsFilter.Dock = DockStyle.Fill;
            MainDirsFilter.Location = new Point(0, 0);
            MainDirsFilter.Margin = new Padding(0);
            MainDirsFilter.Name = "MainDirsFilter";
            MainDirsFilter.Size = new Size(216, 20);
            MainDirsFilter.TabIndex = 1;
            // 
            // ClearDirFilterBtn
            // 
            ClearDirFilterBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClearDirFilterBtn.Dock = DockStyle.Fill;
            ClearDirFilterBtn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearDirFilterBtn.Location = new Point(216, 0);
            ClearDirFilterBtn.Margin = new Padding(0);
            ClearDirFilterBtn.Name = "ClearDirFilterBtn";
            ClearDirFilterBtn.Size = new Size(20, 20);
            ClearDirFilterBtn.TabIndex = 2;
            ClearDirFilterBtn.Text = "X";
            ClearDirFilterBtn.UseVisualStyleBackColor = true;
            // 
            // RightSideTable
            // 
            RightSideTable.ColumnCount = 1;
            RightSideTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            RightSideTable.Controls.Add(MainDirsTable, 0, 1);
            RightSideTable.Controls.Add(MoveFolderSubDirButton, 0, 6);
            RightSideTable.Controls.Add(MoveFolderButton, 0, 5);
            RightSideTable.Controls.Add(TagsSelector, 0, 2);
            RightSideTable.Controls.Add(MoveFilesButton, 0, 4);
            RightSideTable.Controls.Add(UnderScoreManagerTable, 0, 3);
            RightSideTable.Controls.Add(TypeSelector1, 0, 0);
            RightSideTable.Dock = DockStyle.Fill;
            RightSideTable.Location = new Point(0, 0);
            RightSideTable.Margin = new Padding(0);
            RightSideTable.Name = "RightSideTable";
            RightSideTable.RowCount = 7;
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 113.0f));
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Percent, 69.30091f));
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Percent, 30.69909f));
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 23.0f));
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 23.0f));
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 23.0f));
            RightSideTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 23.0f));
            RightSideTable.Size = new Size(236, 512);
            RightSideTable.TabIndex = 1;
            // 
            // MainDirsTable
            // 
            MainDirsTable.ColumnCount = 1;
            MainDirsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            MainDirsTable.Controls.Add(TableLayoutPanel1, 0, 1);
            MainDirsTable.Controls.Add(Label2, 0, 0);
            MainDirsTable.Controls.Add(MainDirsTree, 0, 3);
            MainDirsTable.Controls.Add(MainDirsLabel, 0, 2);
            MainDirsTable.Dock = DockStyle.Fill;
            MainDirsTable.Location = new Point(0, 113);
            MainDirsTable.Margin = new Padding(0);
            MainDirsTable.Name = "MainDirsTable";
            MainDirsTable.RowCount = 4;
            MainDirsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 13.0f));
            MainDirsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            MainDirsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 13.0f));
            MainDirsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            MainDirsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            MainDirsTable.Size = new Size(236, 212);
            MainDirsTable.TabIndex = 1;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Dock = DockStyle.Fill;
            Label2.Location = new Point(3, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(230, 13);
            Label2.TabIndex = 3;
            Label2.Text = "Filter dirs by name";
            // 
            // MainDirsTree
            // 
            MainDirsTree.Dock = DockStyle.Fill;
            MainDirsTree.Location = new Point(0, 46);
            MainDirsTree.Margin = new Padding(0);
            MainDirsTree.Name = "MainDirsTree";
            MainDirsTree.Size = new Size(236, 166);
            MainDirsTree.TabIndex = 15;
            // 
            // MainDirsLabel
            // 
            MainDirsLabel.AutoSize = true;
            MainDirsLabel.Dock = DockStyle.Fill;
            MainDirsLabel.Location = new Point(3, 33);
            MainDirsLabel.Name = "MainDirsLabel";
            MainDirsLabel.Size = new Size(230, 13);
            MainDirsLabel.TabIndex = 2;
            MainDirsLabel.Text = "Main Directories";
            // 
            // TagsSelector
            // 
            TagsSelector.ColumnWidth = 25;
            TagsSelector.Dock = DockStyle.Fill;
            TagsSelector.FormattingEnabled = true;
            TagsSelector.Location = new Point(0, 325);
            TagsSelector.Margin = new Padding(0);
            TagsSelector.MultiColumn = true;
            TagsSelector.Name = "TagsSelector";
            TagsSelector.SelectionMode = SelectionMode.MultiExtended;
            TagsSelector.Size = new Size(236, 94);
            TagsSelector.TabIndex = 3;
            // 
            // UnderScoreManagerTable
            // 
            UnderScoreManagerTable.ColumnCount = 2;
            UnderScoreManagerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            UnderScoreManagerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            UnderScoreManagerTable.Controls.Add(UnderScoreAddUpDown, 0, 0);
            UnderScoreManagerTable.Controls.Add(AddUnderScoreButton, 1, 0);
            UnderScoreManagerTable.Dock = DockStyle.Fill;
            UnderScoreManagerTable.Location = new Point(0, 419);
            UnderScoreManagerTable.Margin = new Padding(0);
            UnderScoreManagerTable.Name = "UnderScoreManagerTable";
            UnderScoreManagerTable.RowCount = 1;
            UnderScoreManagerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            UnderScoreManagerTable.Size = new Size(236, 23);
            UnderScoreManagerTable.TabIndex = 6;
            // 
            // UnderScoreAddUpDown
            // 
            UnderScoreAddUpDown.Dock = DockStyle.Fill;
            UnderScoreAddUpDown.Location = new Point(0, 0);
            UnderScoreAddUpDown.Margin = new Padding(0);
            UnderScoreAddUpDown.Name = "UnderScoreAddUpDown";
            UnderScoreAddUpDown.Size = new Size(118, 20);
            UnderScoreAddUpDown.TabIndex = 0;
            // 
            // ImageList1
            // 
            ImageList1.ColorDepth = ColorDepth.Depth8Bit;
            ImageList1.ImageSize = new Size(24, 24);
            ImageList1.TransparentColor = Color.Transparent;
            // 
            // AlertTimer
            // 
            AlertTimer.Interval = 3000;
            // 
            // SplitContainer2
            // 
            SplitContainer2.Dock = DockStyle.Fill;
            SplitContainer2.Location = new Point(0, 0);
            SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            SplitContainer2.Panel1.Controls.Add(SplitContainer1);
            // 
            // SplitContainer2.Panel2
            // 
            SplitContainer2.Panel2.Controls.Add(RightSideTable);
            SplitContainer2.Size = new Size(1186, 512);
            SplitContainer2.SplitterDistance = 946;
            SplitContainer2.TabIndex = 2;
            // 
            // FileRightClickContextMenu
            // 
            FileRightClickContextMenu.Items.AddRange(new ToolStripItem[] { RenameToolStripMenuItem, GroupToolStripMenuItem1 });
            FileRightClickContextMenu.Name = "ContextMenuStrip1";
            FileRightClickContextMenu.Size = new Size(200, 48);
            // 
            // RenameToolStripMenuItem
            // 
            RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            RenameToolStripMenuItem.Size = new Size(199, 22);
            RenameToolStripMenuItem.Text = "Rename";
            // 
            // GroupToolStripMenuItem1
            // 
            GroupToolStripMenuItem1.Name = "GroupToolStripMenuItem1";
            GroupToolStripMenuItem1.Size = new Size(199, 22);
            GroupToolStripMenuItem1.Text = "Group Items Into Folder";
            // 
            // MediaViewer1
            // 
            MediaViewer1.Dock = DockStyle.Fill;
            MediaViewer1.Location = new Point(0, 0);
            MediaViewer1.Name = "MediaViewer1";
            MediaViewer1.Size = new Size(756, 399);
            MediaViewer1.TabIndex = 0;
            // 
            // TypeSelector1
            // 
            TypeSelector1.Dock = DockStyle.Fill;
            TypeSelector1.Location = new Point(3, 3);
            TypeSelector1.Name = "TypeSelector1";
            TypeSelector1.Size = new Size(230, 107);
            TypeSelector1.TabIndex = 7;
            // 
            // MainInterface
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 534);
            Controls.Add(SplitContainer2);
            Controls.Add(StatusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MainInterface";
            Text = "SortWare";
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            SplitContainer1.Panel1.ResumeLayout(false);
            SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer1).EndInit();
            SplitContainer1.ResumeLayout(false);
            TopBarTable.ResumeLayout(false);
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            miscControlsPanel.ResumeLayout(false);
            miscControlsPanel.PerformLayout();
            StatusStrip2.ResumeLayout(false);
            StatusStrip2.PerformLayout();
            StarRatingPanel.ResumeLayout(false);
            StarRatingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).EndInit();
            MediaAndPresortsSplit.Panel1.ResumeLayout(false);
            MediaAndPresortsSplit.Panel1.PerformLayout();
            MediaAndPresortsSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MediaAndPresortsSplit).EndInit();
            MediaAndPresortsSplit.ResumeLayout(false);
            PresortDirPanels.ResumeLayout(false);
            PresortDirPanels.PerformLayout();
            TableLayoutPanel3.ResumeLayout(false);
            TableLayoutPanel3.PerformLayout();
            PresortFolderButtonsTable.ResumeLayout(false);
            PresortTableLayout.ResumeLayout(false);
            PresortTableLayout.PerformLayout();
            TableLayoutPanel2.ResumeLayout(false);
            TableLayoutPanel2.PerformLayout();
            MainDirsButtonsTable.ResumeLayout(false);
            TableLayoutPanel1.ResumeLayout(false);
            TableLayoutPanel1.PerformLayout();
            RightSideTable.ResumeLayout(false);
            MainDirsTable.ResumeLayout(false);
            MainDirsTable.PerformLayout();
            UnderScoreManagerTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UnderScoreAddUpDown).EndInit();
            SplitContainer2.Panel1.ResumeLayout(false);
            SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer2).EndInit();
            SplitContainer2.ResumeLayout(false);
            FileRightClickContextMenu.ResumeLayout(false);
            Load += new EventHandler(MainInterface_Load);
            KeyDown += new KeyEventHandler(HandleKeys);
            ResumeLayout(false);
            PerformLayout();

        }
        internal System.DirectoryServices.DirectoryEntry DirectoryEntry1;
        internal System.DirectoryServices.DirectorySearcher DirectorySearcher1;
        internal ToolTip FindDirButtonToolTip;
        internal StatusStrip StatusStrip1;
        internal SplitContainer SplitContainer1;
        internal Button OpenSortSettingsButton;
        internal TextBox PreSortedDirTextBox;
        internal Button FindPreSortedDirButton;
        internal TextBox RootDirTextBox;
        internal Button FindRootDirButton;
        internal ToolStripStatusLabel StatusLabel;
        internal ListBox FilesToBeSorted;
        internal ColorDialog ColorDialog1;
        internal TableLayoutPanel TopBarTable;
        internal Button OpenPresortsButton;
        internal Panel miscControlsPanel;
        internal Button openLogsButton;
        internal TableLayoutPanel RightSideTable;
        internal ListBox TagsSelector;
        internal Button MoveFilesButton;
        internal TableLayoutPanel PresortDirPanels;
        internal Button moveUpDir;
        internal ImageList ImageList1;
        internal Button enterDir;
        internal ListBox FoldersToBeSorted;
        internal Button openFile;
        internal TableLayoutPanel MainDirsButtonsTable;
        internal Label Label1;
        internal TrackBar VolumeBar;
        internal Button PropertiesViewButton;
        internal Panel StarRatingPanel;
        internal CheckBox Star5;
        internal CheckBox Star4;
        internal CheckBox Star3;
        internal CheckBox Star2;
        internal CheckBox Star1;
        internal Button SaveRatingButton;
        internal ToolStripStatusLabel MiddleBarEmpty;
        internal StatusStrip StatusStrip2;
        internal ToolStripStatusLabel PropertiesSaveStatus;
        internal Timer AlertTimer;
        internal Button DeleteDirButton;
        internal Button PurgeAllEmptyDirsButton;
        internal NumericUpDown UnderScoreAddUpDown;
        internal TableLayoutPanel UnderScoreManagerTable;
        internal Button AddUnderScoreButton;
        internal Button MoveFolderButton;
        internal SplitContainer SplitContainer2;
        internal SplitContainer MediaAndPresortsSplit;
        internal Button DupeCheckerButton;
        internal CheckBox VideoCheck;
        internal CheckBox ImageCheck;
        internal ContextMenuStrip FileRightClickContextMenu;
        internal ToolStripMenuItem RenameToolStripMenuItem;
        internal ToolStripMenuItem GroupToolStripMenuItem1;
        internal Button PresortFileToPresortFolderButton;
        internal ComboBox SortByComboBox;
        internal Label SortByLabel;
        internal MediaViewer MediaViewer1;
        internal TypeSelector TypeSelector1;
        internal Button conversionsButton;
        internal Button EmptyFoldersUpButton;
        internal TreeView MainDirsTree;
        internal Button MoveFolderSubDirButton;
        internal Panel Panel1;
        internal TableLayoutPanel PresortTableLayout;
        internal Label ToBeSortedLabel;
        internal TextBox ToBeSortedFilter;
        internal Label ToBeSortedFilterLabel;
        internal TableLayoutPanel MainDirsTable;
        internal Label MainDirsLabel;
        internal TableLayoutPanel TableLayoutPanel1;
        internal Label Label2;
        internal TextBox MainDirsFilter;
        internal Button ClearDirFilterBtn;
        internal TableLayoutPanel TableLayoutPanel2;
        internal Button ClearFilesFilterBtn;
        internal Label FileSizeLabel;
        internal TableLayoutPanel PresortFolderButtonsTable;
        internal TableLayoutPanel TableLayoutPanel3;
        internal Button ClearFoldersFilterBtn;
        internal TextBox ToBeSortedFoldersFilter;
        internal Label Label3;
    }
}