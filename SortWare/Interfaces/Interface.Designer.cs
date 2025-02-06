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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
      this.DirectoryEntry1 = new System.DirectoryServices.DirectoryEntry();
      this.DirectorySearcher1 = new System.DirectoryServices.DirectorySearcher();
      this.FindDirButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
      this.FindRootDirButton = new System.Windows.Forms.Button();
      this.FindPreSortedDirButton = new System.Windows.Forms.Button();
      this.SaveRatingButton = new System.Windows.Forms.Button();
      this.moveUpDir = new System.Windows.Forms.Button();
      this.enterDir = new System.Windows.Forms.Button();
      this.DeleteDirButton = new System.Windows.Forms.Button();
      this.PurgeAllEmptyDirsButton = new System.Windows.Forms.Button();
      this.MoveFolderButton = new System.Windows.Forms.Button();
      this.MoveFilesButton = new System.Windows.Forms.Button();
      this.AddUnderScoreButton = new System.Windows.Forms.Button();
      this.MoveFolderSubDirButton = new System.Windows.Forms.Button();
      this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
      this.MiddleBarEmpty = new System.Windows.Forms.ToolStripStatusLabel();
      this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.RootDirTextBox = new System.Windows.Forms.TextBox();
      this.PreSortedDirTextBox = new System.Windows.Forms.TextBox();
      this.OpenSortSettingsButton = new System.Windows.Forms.Button();
      this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
      this.TopBarTable = new System.Windows.Forms.TableLayoutPanel();
      this.Panel1 = new System.Windows.Forms.Panel();
      this.OpenPresortsButton = new System.Windows.Forms.Button();
      this.miscControlsPanel = new System.Windows.Forms.Panel();
      this.FileSizeLabel = new System.Windows.Forms.Label();
      this.conversionsButton = new System.Windows.Forms.Button();
      this.VideoCheck = new System.Windows.Forms.CheckBox();
      this.ImageCheck = new System.Windows.Forms.CheckBox();
      this.DupeCheckerButton = new System.Windows.Forms.Button();
      this.StatusStrip2 = new System.Windows.Forms.StatusStrip();
      this.PropertiesSaveStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.PropertiesViewButton = new System.Windows.Forms.Button();
      this.StarRatingPanel = new System.Windows.Forms.Panel();
      this.Star5 = new System.Windows.Forms.CheckBox();
      this.Star4 = new System.Windows.Forms.CheckBox();
      this.Star3 = new System.Windows.Forms.CheckBox();
      this.Star2 = new System.Windows.Forms.CheckBox();
      this.Star1 = new System.Windows.Forms.CheckBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.VolumeBar = new System.Windows.Forms.TrackBar();
      this.openLogsButton = new System.Windows.Forms.Button();
      this.MediaAndPresortsSplit = new System.Windows.Forms.SplitContainer();
      this.PresortDirPanels = new System.Windows.Forms.TableLayoutPanel();
      this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.ClearFoldersFilterBtn = new System.Windows.Forms.Button();
      this.ToBeSortedFoldersFilter = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.PresortFolderButtonsTable = new System.Windows.Forms.TableLayoutPanel();
      this.PresortFileToPresortFolderButton = new System.Windows.Forms.Button();
      this.EmptyFoldersUpButton = new System.Windows.Forms.Button();
      this.PresortTableLayout = new System.Windows.Forms.TableLayoutPanel();
      this.SortByComboBox = new System.Windows.Forms.ComboBox();
      this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.ClearFilesFilterBtn = new System.Windows.Forms.Button();
      this.ToBeSortedFilter = new System.Windows.Forms.TextBox();
      this.SortByLabel = new System.Windows.Forms.Label();
      this.ToBeSortedFilterLabel = new System.Windows.Forms.Label();
      this.FilesToBeSorted = new System.Windows.Forms.ListBox();
      this.ToBeSortedLabel = new System.Windows.Forms.Label();
      this.FoldersToBeSorted = new System.Windows.Forms.ListBox();
      this.MainDirsButtonsTable = new System.Windows.Forms.TableLayoutPanel();
      this.openFile = new System.Windows.Forms.Button();
      this.MediaViewer1 = new SortWare.MediaViewer();
      this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.MainDirsFilter = new System.Windows.Forms.TextBox();
      this.ClearDirFilterBtn = new System.Windows.Forms.Button();
      this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
      this.RightSideTable = new System.Windows.Forms.TableLayoutPanel();
      this.MainDirsTable = new System.Windows.Forms.TableLayoutPanel();
      this.Label2 = new System.Windows.Forms.Label();
      this.MainDirsTree = new System.Windows.Forms.TreeView();
      this.MainDirsLabel = new System.Windows.Forms.Label();
      this.TagsSelector = new System.Windows.Forms.ListBox();
      this.UnderScoreManagerTable = new System.Windows.Forms.TableLayoutPanel();
      this.UnderScoreAddUpDown = new System.Windows.Forms.NumericUpDown();
      this.TypeSelector1 = new SortWare.TypeSelector();
      this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
      this.AlertTimer = new System.Windows.Forms.Timer(this.components);
      this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
      this.FileRightClickContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.GroupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.StatusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
      this.SplitContainer1.Panel1.SuspendLayout();
      this.SplitContainer1.Panel2.SuspendLayout();
      this.SplitContainer1.SuspendLayout();
      this.TopBarTable.SuspendLayout();
      this.Panel1.SuspendLayout();
      this.miscControlsPanel.SuspendLayout();
      this.StatusStrip2.SuspendLayout();
      this.StarRatingPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MediaAndPresortsSplit)).BeginInit();
      this.MediaAndPresortsSplit.Panel1.SuspendLayout();
      this.MediaAndPresortsSplit.Panel2.SuspendLayout();
      this.MediaAndPresortsSplit.SuspendLayout();
      this.PresortDirPanels.SuspendLayout();
      this.TableLayoutPanel3.SuspendLayout();
      this.PresortFolderButtonsTable.SuspendLayout();
      this.PresortTableLayout.SuspendLayout();
      this.TableLayoutPanel2.SuspendLayout();
      this.MainDirsButtonsTable.SuspendLayout();
      this.TableLayoutPanel1.SuspendLayout();
      this.RightSideTable.SuspendLayout();
      this.MainDirsTable.SuspendLayout();
      this.UnderScoreManagerTable.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UnderScoreAddUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
      this.SplitContainer2.Panel1.SuspendLayout();
      this.SplitContainer2.Panel2.SuspendLayout();
      this.SplitContainer2.SuspendLayout();
      this.FileRightClickContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // DirectorySearcher1
      // 
      this.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
      this.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
      this.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
      // 
      // FindDirButtonToolTip
      // 
      this.FindDirButtonToolTip.BackColor = System.Drawing.Color.Khaki;
      // 
      // FindRootDirButton
      // 
      this.FindRootDirButton.Location = new System.Drawing.Point(0, 0);
      this.FindRootDirButton.Name = "FindRootDirButton";
      this.FindRootDirButton.Size = new System.Drawing.Size(96, 47);
      this.FindRootDirButton.TabIndex = 1;
      this.FindRootDirButton.Text = "Choose Root Directory";
      this.FindDirButtonToolTip.SetToolTip(this.FindRootDirButton, "The Root directory is your earliest single folder where all files and other direc" +
        "tories are located.");
      this.FindRootDirButton.UseVisualStyleBackColor = true;
      this.FindRootDirButton.Click += new System.EventHandler(this.FindRootDirButton_Click);
      // 
      // FindPreSortedDirButton
      // 
      this.FindPreSortedDirButton.Location = new System.Drawing.Point(0, 53);
      this.FindPreSortedDirButton.Name = "FindPreSortedDirButton";
      this.FindPreSortedDirButton.Size = new System.Drawing.Size(96, 47);
      this.FindPreSortedDirButton.TabIndex = 2;
      this.FindPreSortedDirButton.Text = "Choose Pre-sorted Directory";
      this.FindDirButtonToolTip.SetToolTip(this.FindPreSortedDirButton, "The Root directory is your earliest single folder where all files and other direc" +
        "tories are located.");
      this.FindPreSortedDirButton.UseVisualStyleBackColor = true;
      this.FindPreSortedDirButton.Click += new System.EventHandler(this.FindPreSortedDirButton_Click);
      // 
      // SaveRatingButton
      // 
      this.SaveRatingButton.Location = new System.Drawing.Point(325, 4);
      this.SaveRatingButton.Name = "SaveRatingButton";
      this.SaveRatingButton.Size = new System.Drawing.Size(33, 33);
      this.SaveRatingButton.TabIndex = 9;
      this.FindDirButtonToolTip.SetToolTip(this.SaveRatingButton, "Save the rating of the current file");
      this.SaveRatingButton.UseVisualStyleBackColor = true;
      this.SaveRatingButton.Click += new System.EventHandler(this.SaveRatingButton_Click);
      // 
      // moveUpDir
      // 
      this.moveUpDir.Dock = System.Windows.Forms.DockStyle.Fill;
      this.moveUpDir.Location = new System.Drawing.Point(0, 0);
      this.moveUpDir.Margin = new System.Windows.Forms.Padding(0);
      this.moveUpDir.Name = "moveUpDir";
      this.moveUpDir.Size = new System.Drawing.Size(38, 37);
      this.moveUpDir.TabIndex = 6;
      this.FindDirButtonToolTip.SetToolTip(this.moveUpDir, "Exit the current folder-to-be-sorted");
      this.moveUpDir.UseVisualStyleBackColor = true;
      this.moveUpDir.Click += new System.EventHandler(this.MoveUpDir_Click);
      // 
      // enterDir
      // 
      this.enterDir.Dock = System.Windows.Forms.DockStyle.Fill;
      this.enterDir.Location = new System.Drawing.Point(76, 0);
      this.enterDir.Margin = new System.Windows.Forms.Padding(0);
      this.enterDir.Name = "enterDir";
      this.enterDir.Size = new System.Drawing.Size(38, 37);
      this.enterDir.TabIndex = 8;
      this.FindDirButtonToolTip.SetToolTip(this.enterDir, "Enter the selected folder-to-be-sorted");
      this.enterDir.UseVisualStyleBackColor = true;
      this.enterDir.Click += new System.EventHandler(this.EnterDir_Click);
      // 
      // DeleteDirButton
      // 
      this.DeleteDirButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DeleteDirButton.Location = new System.Drawing.Point(114, 0);
      this.DeleteDirButton.Margin = new System.Windows.Forms.Padding(0);
      this.DeleteDirButton.Name = "DeleteDirButton";
      this.DeleteDirButton.Size = new System.Drawing.Size(38, 37);
      this.DeleteDirButton.TabIndex = 9;
      this.FindDirButtonToolTip.SetToolTip(this.DeleteDirButton, "Delete the selected folder-to-be-sorted");
      this.DeleteDirButton.UseVisualStyleBackColor = true;
      this.DeleteDirButton.Click += new System.EventHandler(this.DeleteDirButton_Click);
      // 
      // PurgeAllEmptyDirsButton
      // 
      this.PurgeAllEmptyDirsButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PurgeAllEmptyDirsButton.Location = new System.Drawing.Point(152, 0);
      this.PurgeAllEmptyDirsButton.Margin = new System.Windows.Forms.Padding(0);
      this.PurgeAllEmptyDirsButton.Name = "PurgeAllEmptyDirsButton";
      this.PurgeAllEmptyDirsButton.Size = new System.Drawing.Size(41, 37);
      this.PurgeAllEmptyDirsButton.TabIndex = 10;
      this.FindDirButtonToolTip.SetToolTip(this.PurgeAllEmptyDirsButton, " Deletes all empty folders in the presort directory");
      this.PurgeAllEmptyDirsButton.UseVisualStyleBackColor = true;
      this.PurgeAllEmptyDirsButton.Click += new System.EventHandler(this.PurgeAllEmptyDirsButton_Click);
      // 
      // MoveFolderButton
      // 
      this.MoveFolderButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveFolderButton.Location = new System.Drawing.Point(0, 465);
      this.MoveFolderButton.Margin = new System.Windows.Forms.Padding(0);
      this.MoveFolderButton.Name = "MoveFolderButton";
      this.MoveFolderButton.Size = new System.Drawing.Size(259, 23);
      this.MoveFolderButton.TabIndex = 5;
      this.MoveFolderButton.Text = "Move Folder, Apply Tags";
      this.FindDirButtonToolTip.SetToolTip(this.MoveFolderButton, "Move the selected folder to the selected folder and apply the selected tags to th" +
        "e start of the folder name");
      this.MoveFolderButton.UseVisualStyleBackColor = true;
      this.MoveFolderButton.Click += new System.EventHandler(this.MoveFolderButton_Click);
      // 
      // MoveFilesButton
      // 
      this.MoveFilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveFilesButton.Location = new System.Drawing.Point(0, 442);
      this.MoveFilesButton.Margin = new System.Windows.Forms.Padding(0);
      this.MoveFilesButton.Name = "MoveFilesButton";
      this.MoveFilesButton.Size = new System.Drawing.Size(259, 23);
      this.MoveFilesButton.TabIndex = 4;
      this.MoveFilesButton.Text = "Move File(s), Apply Tags";
      this.FindDirButtonToolTip.SetToolTip(this.MoveFilesButton, "Move the selected file(s) to the selected folder and apply the selected tags to t" +
        "he start of the filename(s)");
      this.MoveFilesButton.UseVisualStyleBackColor = true;
      this.MoveFilesButton.Click += new System.EventHandler(this.MoveFilesButton_Click);
      // 
      // AddUnderScoreButton
      // 
      this.AddUnderScoreButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AddUnderScoreButton.Location = new System.Drawing.Point(129, 0);
      this.AddUnderScoreButton.Margin = new System.Windows.Forms.Padding(0);
      this.AddUnderScoreButton.Name = "AddUnderScoreButton";
      this.AddUnderScoreButton.Size = new System.Drawing.Size(130, 23);
      this.AddUnderScoreButton.TabIndex = 1;
      this.AddUnderScoreButton.Text = "Add x \"_\"";
      this.FindDirButtonToolTip.SetToolTip(this.AddUnderScoreButton, "Add the specified number of underscores to the start of the filename (useful if f" +
        "ile is unratable or numeric tagging is unavailable)");
      this.AddUnderScoreButton.UseVisualStyleBackColor = true;
      this.AddUnderScoreButton.Click += new System.EventHandler(this.AddUnderScoreButton_Click);
      // 
      // MoveFolderSubDirButton
      // 
      this.MoveFolderSubDirButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveFolderSubDirButton.Location = new System.Drawing.Point(0, 488);
      this.MoveFolderSubDirButton.Margin = new System.Windows.Forms.Padding(0);
      this.MoveFolderSubDirButton.Name = "MoveFolderSubDirButton";
      this.MoveFolderSubDirButton.Size = new System.Drawing.Size(259, 24);
      this.MoveFolderSubDirButton.TabIndex = 16;
      this.MoveFolderSubDirButton.Text = "Move Folder, Add As Main Subdirectory";
      this.FindDirButtonToolTip.SetToolTip(this.MoveFolderSubDirButton, "Add the specified number of underscores to the start of the filename (useful if f" +
        "ile is unratable or numeric tagging is unavailable)");
      this.MoveFolderSubDirButton.UseVisualStyleBackColor = true;
      this.MoveFolderSubDirButton.Click += new System.EventHandler(this.MoveFolderSubDir_Click);
      // 
      // StatusStrip1
      // 
      this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiddleBarEmpty,
            this.StatusLabel});
      this.StatusStrip1.Location = new System.Drawing.Point(0, 512);
      this.StatusStrip1.Name = "StatusStrip1";
      this.StatusStrip1.Size = new System.Drawing.Size(1196, 22);
      this.StatusStrip1.TabIndex = 1;
      this.StatusStrip1.Text = "StatusStrip1";
      // 
      // MiddleBarEmpty
      // 
      this.MiddleBarEmpty.Name = "MiddleBarEmpty";
      this.MiddleBarEmpty.Size = new System.Drawing.Size(1181, 17);
      this.MiddleBarEmpty.Spring = true;
      this.MiddleBarEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // StatusLabel
      // 
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // RootDirTextBox
      // 
      this.RootDirTextBox.Location = new System.Drawing.Point(102, 0);
      this.RootDirTextBox.Name = "RootDirTextBox";
      this.RootDirTextBox.Size = new System.Drawing.Size(355, 20);
      this.RootDirTextBox.TabIndex = 1;
      // 
      // PreSortedDirTextBox
      // 
      this.PreSortedDirTextBox.Location = new System.Drawing.Point(102, 53);
      this.PreSortedDirTextBox.Name = "PreSortedDirTextBox";
      this.PreSortedDirTextBox.Size = new System.Drawing.Size(355, 20);
      this.PreSortedDirTextBox.TabIndex = 3;
      // 
      // OpenSortSettingsButton
      // 
      this.OpenSortSettingsButton.AutoSize = true;
      this.OpenSortSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.OpenSortSettingsButton.Location = new System.Drawing.Point(102, 22);
      this.OpenSortSettingsButton.Name = "OpenSortSettingsButton";
      this.OpenSortSettingsButton.Size = new System.Drawing.Size(144, 25);
      this.OpenSortSettingsButton.TabIndex = 4;
      this.OpenSortSettingsButton.Text = "Open Folder Settings";
      this.OpenSortSettingsButton.UseVisualStyleBackColor = true;
      this.OpenSortSettingsButton.Click += new System.EventHandler(this.OpenSortSettingsButton_Click);
      // 
      // SplitContainer1
      // 
      this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.SplitContainer1.IsSplitterFixed = true;
      this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer1.Margin = new System.Windows.Forms.Padding(0);
      this.SplitContainer1.Name = "SplitContainer1";
      this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // SplitContainer1.Panel1
      // 
      this.SplitContainer1.Panel1.Controls.Add(this.TopBarTable);
      // 
      // SplitContainer1.Panel2
      // 
      this.SplitContainer1.Panel2.Controls.Add(this.MediaAndPresortsSplit);
      this.SplitContainer1.Size = new System.Drawing.Size(933, 512);
      this.SplitContainer1.SplitterDistance = 105;
      this.SplitContainer1.TabIndex = 0;
      // 
      // TopBarTable
      // 
      this.TopBarTable.ColumnCount = 2;
      this.TopBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TopBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TopBarTable.Controls.Add(this.Panel1, 0, 0);
      this.TopBarTable.Controls.Add(this.miscControlsPanel, 1, 0);
      this.TopBarTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TopBarTable.Location = new System.Drawing.Point(0, 0);
      this.TopBarTable.Margin = new System.Windows.Forms.Padding(0);
      this.TopBarTable.Name = "TopBarTable";
      this.TopBarTable.RowCount = 1;
      this.TopBarTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TopBarTable.Size = new System.Drawing.Size(929, 101);
      this.TopBarTable.TabIndex = 5;
      // 
      // Panel1
      // 
      this.Panel1.Controls.Add(this.OpenPresortsButton);
      this.Panel1.Controls.Add(this.PreSortedDirTextBox);
      this.Panel1.Controls.Add(this.RootDirTextBox);
      this.Panel1.Controls.Add(this.FindPreSortedDirButton);
      this.Panel1.Controls.Add(this.FindRootDirButton);
      this.Panel1.Controls.Add(this.OpenSortSettingsButton);
      this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel1.Location = new System.Drawing.Point(0, 0);
      this.Panel1.Margin = new System.Windows.Forms.Padding(0);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new System.Drawing.Size(464, 101);
      this.Panel1.TabIndex = 0;
      // 
      // OpenPresortsButton
      // 
      this.OpenPresortsButton.AutoSize = true;
      this.OpenPresortsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.OpenPresortsButton.Location = new System.Drawing.Point(102, 75);
      this.OpenPresortsButton.Name = "OpenPresortsButton";
      this.OpenPresortsButton.Size = new System.Drawing.Size(207, 25);
      this.OpenPresortsButton.TabIndex = 5;
      this.OpenPresortsButton.Text = "Select Pre-sorted Directory from settings";
      this.OpenPresortsButton.UseVisualStyleBackColor = true;
      this.OpenPresortsButton.Click += new System.EventHandler(this.OpenPresortsButton_Click);
      // 
      // miscControlsPanel
      // 
      this.miscControlsPanel.Controls.Add(this.FileSizeLabel);
      this.miscControlsPanel.Controls.Add(this.conversionsButton);
      this.miscControlsPanel.Controls.Add(this.VideoCheck);
      this.miscControlsPanel.Controls.Add(this.ImageCheck);
      this.miscControlsPanel.Controls.Add(this.DupeCheckerButton);
      this.miscControlsPanel.Controls.Add(this.StatusStrip2);
      this.miscControlsPanel.Controls.Add(this.SaveRatingButton);
      this.miscControlsPanel.Controls.Add(this.PropertiesViewButton);
      this.miscControlsPanel.Controls.Add(this.StarRatingPanel);
      this.miscControlsPanel.Controls.Add(this.Label1);
      this.miscControlsPanel.Controls.Add(this.VolumeBar);
      this.miscControlsPanel.Controls.Add(this.openLogsButton);
      this.miscControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.miscControlsPanel.Location = new System.Drawing.Point(464, 0);
      this.miscControlsPanel.Margin = new System.Windows.Forms.Padding(0);
      this.miscControlsPanel.Name = "miscControlsPanel";
      this.miscControlsPanel.Size = new System.Drawing.Size(465, 101);
      this.miscControlsPanel.TabIndex = 1;
      // 
      // FileSizeLabel
      // 
      this.FileSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.FileSizeLabel.AutoSize = true;
      this.FileSizeLabel.Location = new System.Drawing.Point(120, 66);
      this.FileSizeLabel.Name = "FileSizeLabel";
      this.FileSizeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.FileSizeLabel.Size = new System.Drawing.Size(25, 13);
      this.FileSizeLabel.TabIndex = 15;
      this.FileSizeLabel.Text = "------";
      this.FileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // conversionsButton
      // 
      this.conversionsButton.Location = new System.Drawing.Point(6, 27);
      this.conversionsButton.Name = "conversionsButton";
      this.conversionsButton.Size = new System.Drawing.Size(108, 23);
      this.conversionsButton.TabIndex = 14;
      this.conversionsButton.Text = "File Conversion";
      this.conversionsButton.UseVisualStyleBackColor = true;
      this.conversionsButton.Click += new System.EventHandler(this.ConversionsButton_Click);
      // 
      // VideoCheck
      // 
      this.VideoCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.VideoCheck.AutoSize = true;
      this.VideoCheck.Checked = true;
      this.VideoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.VideoCheck.Location = new System.Drawing.Point(468, 58);
      this.VideoCheck.Name = "VideoCheck";
      this.VideoCheck.Size = new System.Drawing.Size(84, 17);
      this.VideoCheck.TabIndex = 13;
      this.VideoCheck.Text = "View Videos";
      this.VideoCheck.UseVisualStyleBackColor = true;
      this.VideoCheck.CheckedChanged += new System.EventHandler(this.Views_CheckedChanged);
      // 
      // ImageCheck
      // 
      this.ImageCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ImageCheck.AutoSize = true;
      this.ImageCheck.Checked = true;
      this.ImageCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ImageCheck.Location = new System.Drawing.Point(468, 43);
      this.ImageCheck.Name = "ImageCheck";
      this.ImageCheck.Size = new System.Drawing.Size(86, 17);
      this.ImageCheck.TabIndex = 12;
      this.ImageCheck.Text = "View Images";
      this.ImageCheck.UseVisualStyleBackColor = true;
      this.ImageCheck.CheckedChanged += new System.EventHandler(this.Views_CheckedChanged);
      // 
      // DupeCheckerButton
      // 
      this.DupeCheckerButton.Location = new System.Drawing.Point(364, 3);
      this.DupeCheckerButton.Name = "DupeCheckerButton";
      this.DupeCheckerButton.Size = new System.Drawing.Size(104, 34);
      this.DupeCheckerButton.TabIndex = 11;
      this.DupeCheckerButton.Text = "Open Dupe Checker";
      this.DupeCheckerButton.UseVisualStyleBackColor = true;
      this.DupeCheckerButton.Click += new System.EventHandler(this.DupeCheckerButton_Click);
      // 
      // StatusStrip2
      // 
      this.StatusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PropertiesSaveStatus});
      this.StatusStrip2.Location = new System.Drawing.Point(0, 79);
      this.StatusStrip2.Name = "StatusStrip2";
      this.StatusStrip2.Size = new System.Drawing.Size(465, 22);
      this.StatusStrip2.TabIndex = 10;
      this.StatusStrip2.Text = "StatusStrip2";
      // 
      // PropertiesSaveStatus
      // 
      this.PropertiesSaveStatus.Name = "PropertiesSaveStatus";
      this.PropertiesSaveStatus.Size = new System.Drawing.Size(450, 17);
      this.PropertiesSaveStatus.Spring = true;
      this.PropertiesSaveStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // PropertiesViewButton
      // 
      this.PropertiesViewButton.Location = new System.Drawing.Point(6, 50);
      this.PropertiesViewButton.Name = "PropertiesViewButton";
      this.PropertiesViewButton.Size = new System.Drawing.Size(108, 25);
      this.PropertiesViewButton.TabIndex = 7;
      this.PropertiesViewButton.Text = "View File Properties";
      this.PropertiesViewButton.UseVisualStyleBackColor = true;
      // 
      // StarRatingPanel
      // 
      this.StarRatingPanel.Controls.Add(this.Star5);
      this.StarRatingPanel.Controls.Add(this.Star4);
      this.StarRatingPanel.Controls.Add(this.Star3);
      this.StarRatingPanel.Controls.Add(this.Star2);
      this.StarRatingPanel.Controls.Add(this.Star1);
      this.StarRatingPanel.Enabled = false;
      this.StarRatingPanel.Location = new System.Drawing.Point(120, 3);
      this.StarRatingPanel.Name = "StarRatingPanel";
      this.StarRatingPanel.Size = new System.Drawing.Size(199, 38);
      this.StarRatingPanel.TabIndex = 8;
      // 
      // Star5
      // 
      this.Star5.AutoSize = true;
      this.Star5.Location = new System.Drawing.Point(155, 13);
      this.Star5.Name = "Star5";
      this.Star5.Size = new System.Drawing.Size(32, 17);
      this.Star5.TabIndex = 4;
      this.Star5.Text = "5";
      this.Star5.UseVisualStyleBackColor = true;
      this.Star5.CheckedChanged += new System.EventHandler(this.StarRatingChanged);
      // 
      // Star4
      // 
      this.Star4.AutoSize = true;
      this.Star4.Location = new System.Drawing.Point(117, 13);
      this.Star4.Name = "Star4";
      this.Star4.Size = new System.Drawing.Size(32, 17);
      this.Star4.TabIndex = 3;
      this.Star4.Text = "4";
      this.Star4.UseVisualStyleBackColor = true;
      this.Star4.CheckedChanged += new System.EventHandler(this.StarRatingChanged);
      // 
      // Star3
      // 
      this.Star3.AutoSize = true;
      this.Star3.Location = new System.Drawing.Point(79, 13);
      this.Star3.Name = "Star3";
      this.Star3.Size = new System.Drawing.Size(32, 17);
      this.Star3.TabIndex = 2;
      this.Star3.Text = "3";
      this.Star3.UseVisualStyleBackColor = true;
      this.Star3.CheckedChanged += new System.EventHandler(this.StarRatingChanged);
      // 
      // Star2
      // 
      this.Star2.AutoSize = true;
      this.Star2.Location = new System.Drawing.Point(41, 13);
      this.Star2.Name = "Star2";
      this.Star2.Size = new System.Drawing.Size(32, 17);
      this.Star2.TabIndex = 1;
      this.Star2.Text = "2";
      this.Star2.UseVisualStyleBackColor = true;
      this.Star2.CheckedChanged += new System.EventHandler(this.StarRatingChanged);
      // 
      // Star1
      // 
      this.Star1.AutoSize = true;
      this.Star1.Location = new System.Drawing.Point(3, 13);
      this.Star1.Name = "Star1";
      this.Star1.Size = new System.Drawing.Size(32, 17);
      this.Star1.TabIndex = 0;
      this.Star1.Text = "1";
      this.Star1.UseVisualStyleBackColor = true;
      this.Star1.CheckedChanged += new System.EventHandler(this.StarRatingChanged);
      // 
      // Label1
      // 
      this.Label1.Cursor = System.Windows.Forms.Cursors.Cross;
      this.Label1.Location = new System.Drawing.Point(203, 57);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(52, 16);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Volume";
      this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // VolumeBar
      // 
      this.VolumeBar.Location = new System.Drawing.Point(120, 44);
      this.VolumeBar.Maximum = 100;
      this.VolumeBar.Name = "VolumeBar";
      this.VolumeBar.Size = new System.Drawing.Size(238, 45);
      this.VolumeBar.TabIndex = 6;
      this.VolumeBar.TickFrequency = 5;
      this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
      this.VolumeBar.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
      // 
      // openLogsButton
      // 
      this.openLogsButton.Enabled = false;
      this.openLogsButton.Location = new System.Drawing.Point(6, 4);
      this.openLogsButton.Name = "openLogsButton";
      this.openLogsButton.Size = new System.Drawing.Size(108, 23);
      this.openLogsButton.TabIndex = 5;
      this.openLogsButton.Text = "Open Move Logs";
      this.openLogsButton.UseVisualStyleBackColor = true;
      this.openLogsButton.Click += new System.EventHandler(this.OpenLogsButton_Click);
      // 
      // MediaAndPresortsSplit
      // 
      this.MediaAndPresortsSplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MediaAndPresortsSplit.Location = new System.Drawing.Point(0, 0);
      this.MediaAndPresortsSplit.Margin = new System.Windows.Forms.Padding(0);
      this.MediaAndPresortsSplit.Name = "MediaAndPresortsSplit";
      // 
      // MediaAndPresortsSplit.Panel1
      // 
      this.MediaAndPresortsSplit.Panel1.Controls.Add(this.PresortDirPanels);
      // 
      // MediaAndPresortsSplit.Panel2
      // 
      this.MediaAndPresortsSplit.Panel2.Controls.Add(this.MediaViewer1);
      this.MediaAndPresortsSplit.Size = new System.Drawing.Size(929, 399);
      this.MediaAndPresortsSplit.SplitterDistance = 193;
      this.MediaAndPresortsSplit.TabIndex = 0;
      // 
      // PresortDirPanels
      // 
      this.PresortDirPanels.AutoSize = true;
      this.PresortDirPanels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.PresortDirPanels.ColumnCount = 1;
      this.PresortDirPanels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.PresortDirPanels.Controls.Add(this.TableLayoutPanel3, 0, 3);
      this.PresortDirPanels.Controls.Add(this.Label3, 0, 2);
      this.PresortDirPanels.Controls.Add(this.PresortFolderButtonsTable, 0, 1);
      this.PresortDirPanels.Controls.Add(this.PresortTableLayout, 0, 0);
      this.PresortDirPanels.Controls.Add(this.FoldersToBeSorted, 0, 4);
      this.PresortDirPanels.Controls.Add(this.MainDirsButtonsTable, 0, 5);
      this.PresortDirPanels.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PresortDirPanels.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
      this.PresortDirPanels.Location = new System.Drawing.Point(0, 0);
      this.PresortDirPanels.Margin = new System.Windows.Forms.Padding(0);
      this.PresortDirPanels.Name = "PresortDirPanels";
      this.PresortDirPanels.RowCount = 6;
      this.PresortDirPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
      this.PresortDirPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
      this.PresortDirPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.PresortDirPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.PresortDirPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.PresortDirPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
      this.PresortDirPanels.Size = new System.Drawing.Size(193, 399);
      this.PresortDirPanels.TabIndex = 0;
      // 
      // TableLayoutPanel3
      // 
      this.TableLayoutPanel3.ColumnCount = 2;
      this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.TableLayoutPanel3.Controls.Add(this.ClearFoldersFilterBtn, 1, 0);
      this.TableLayoutPanel3.Controls.Add(this.ToBeSortedFoldersFilter, 0, 0);
      this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 276);
      this.TableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
      this.TableLayoutPanel3.Name = "TableLayoutPanel3";
      this.TableLayoutPanel3.RowCount = 1;
      this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel3.Size = new System.Drawing.Size(193, 20);
      this.TableLayoutPanel3.TabIndex = 8;
      // 
      // ClearFoldersFilterBtn
      // 
      this.ClearFoldersFilterBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClearFoldersFilterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ClearFoldersFilterBtn.Location = new System.Drawing.Point(173, 0);
      this.ClearFoldersFilterBtn.Margin = new System.Windows.Forms.Padding(0);
      this.ClearFoldersFilterBtn.Name = "ClearFoldersFilterBtn";
      this.ClearFoldersFilterBtn.Size = new System.Drawing.Size(20, 20);
      this.ClearFoldersFilterBtn.TabIndex = 0;
      this.ClearFoldersFilterBtn.Text = "X";
      this.ClearFoldersFilterBtn.UseVisualStyleBackColor = true;
      this.ClearFoldersFilterBtn.Click += new System.EventHandler(this.ClearFoldersFilterBtn_Click);
      // 
      // ToBeSortedFoldersFilter
      // 
      this.ToBeSortedFoldersFilter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ToBeSortedFoldersFilter.Location = new System.Drawing.Point(0, 0);
      this.ToBeSortedFoldersFilter.Margin = new System.Windows.Forms.Padding(0);
      this.ToBeSortedFoldersFilter.Name = "ToBeSortedFoldersFilter";
      this.ToBeSortedFoldersFilter.Size = new System.Drawing.Size(173, 20);
      this.ToBeSortedFoldersFilter.TabIndex = 1;
      this.ToBeSortedFoldersFilter.TextChanged += new System.EventHandler(this.ToBeSortedFoldersFilter_TextChanged);
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Label3.Location = new System.Drawing.Point(3, 256);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(187, 20);
      this.Label3.TabIndex = 7;
      this.Label3.Text = "Filter folders by name";
      // 
      // PresortFolderButtonsTable
      // 
      this.PresortFolderButtonsTable.ColumnCount = 2;
      this.PresortFolderButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
      this.PresortFolderButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
      this.PresortFolderButtonsTable.Controls.Add(this.PresortFileToPresortFolderButton, 0, 0);
      this.PresortFolderButtonsTable.Controls.Add(this.EmptyFoldersUpButton, 1, 0);
      this.PresortFolderButtonsTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PresortFolderButtonsTable.Location = new System.Drawing.Point(0, 200);
      this.PresortFolderButtonsTable.Margin = new System.Windows.Forms.Padding(0);
      this.PresortFolderButtonsTable.Name = "PresortFolderButtonsTable";
      this.PresortFolderButtonsTable.RowCount = 1;
      this.PresortFolderButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.PresortFolderButtonsTable.Size = new System.Drawing.Size(193, 56);
      this.PresortFolderButtonsTable.TabIndex = 6;
      // 
      // PresortFileToPresortFolderButton
      // 
      this.PresortFileToPresortFolderButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PresortFileToPresortFolderButton.Location = new System.Drawing.Point(0, 0);
      this.PresortFileToPresortFolderButton.Margin = new System.Windows.Forms.Padding(0);
      this.PresortFileToPresortFolderButton.Name = "PresortFileToPresortFolderButton";
      this.PresortFileToPresortFolderButton.Size = new System.Drawing.Size(87, 56);
      this.PresortFileToPresortFolderButton.TabIndex = 5;
      this.PresortFileToPresortFolderButton.Text = "Move File to Presort Folder\r\n⇓";
      this.PresortFileToPresortFolderButton.UseVisualStyleBackColor = true;
      this.PresortFileToPresortFolderButton.Click += new System.EventHandler(this.PresortFileToPresortFolderButton_Click);
      // 
      // EmptyFoldersUpButton
      // 
      this.EmptyFoldersUpButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EmptyFoldersUpButton.Location = new System.Drawing.Point(87, 0);
      this.EmptyFoldersUpButton.Margin = new System.Windows.Forms.Padding(0);
      this.EmptyFoldersUpButton.Name = "EmptyFoldersUpButton";
      this.EmptyFoldersUpButton.Size = new System.Drawing.Size(106, 56);
      this.EmptyFoldersUpButton.TabIndex = 6;
      this.EmptyFoldersUpButton.Text = "⇑\r\nMove Up Files In Selected Folders";
      this.EmptyFoldersUpButton.UseVisualStyleBackColor = true;
      this.EmptyFoldersUpButton.Click += new System.EventHandler(this.EmptyFoldersUpButton_Click);
      // 
      // PresortTableLayout
      // 
      this.PresortTableLayout.ColumnCount = 1;
      this.PresortTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.PresortTableLayout.Controls.Add(this.SortByComboBox, 0, 1);
      this.PresortTableLayout.Controls.Add(this.TableLayoutPanel2, 0, 3);
      this.PresortTableLayout.Controls.Add(this.SortByLabel, 0, 0);
      this.PresortTableLayout.Controls.Add(this.ToBeSortedFilterLabel, 0, 2);
      this.PresortTableLayout.Controls.Add(this.FilesToBeSorted, 0, 5);
      this.PresortTableLayout.Controls.Add(this.ToBeSortedLabel, 0, 4);
      this.PresortTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PresortTableLayout.Location = new System.Drawing.Point(0, 0);
      this.PresortTableLayout.Margin = new System.Windows.Forms.Padding(0);
      this.PresortTableLayout.Name = "PresortTableLayout";
      this.PresortTableLayout.RowCount = 6;
      this.PresortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
      this.PresortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
      this.PresortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
      this.PresortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.PresortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
      this.PresortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.PresortTableLayout.Size = new System.Drawing.Size(193, 200);
      this.PresortTableLayout.TabIndex = 0;
      // 
      // SortByComboBox
      // 
      this.SortByComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SortByComboBox.FormattingEnabled = true;
      this.SortByComboBox.Items.AddRange(new object[] {
            "----",
            "Date",
            "Name",
            "Size",
            "Filetype"});
      this.SortByComboBox.Location = new System.Drawing.Point(0, 13);
      this.SortByComboBox.Margin = new System.Windows.Forms.Padding(0);
      this.SortByComboBox.Name = "SortByComboBox";
      this.SortByComboBox.Size = new System.Drawing.Size(193, 21);
      this.SortByComboBox.TabIndex = 6;
      this.SortByComboBox.Text = "----";
      this.SortByComboBox.SelectedIndexChanged += new System.EventHandler(this.SortByComboBox_SelectedIndexChanged);
      // 
      // TableLayoutPanel2
      // 
      this.TableLayoutPanel2.ColumnCount = 2;
      this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.TableLayoutPanel2.Controls.Add(this.ClearFilesFilterBtn, 1, 0);
      this.TableLayoutPanel2.Controls.Add(this.ToBeSortedFilter, 0, 0);
      this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 47);
      this.TableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.TableLayoutPanel2.Name = "TableLayoutPanel2";
      this.TableLayoutPanel2.RowCount = 1;
      this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel2.Size = new System.Drawing.Size(193, 20);
      this.TableLayoutPanel2.TabIndex = 1;
      // 
      // ClearFilesFilterBtn
      // 
      this.ClearFilesFilterBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClearFilesFilterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ClearFilesFilterBtn.Location = new System.Drawing.Point(173, 0);
      this.ClearFilesFilterBtn.Margin = new System.Windows.Forms.Padding(0);
      this.ClearFilesFilterBtn.Name = "ClearFilesFilterBtn";
      this.ClearFilesFilterBtn.Size = new System.Drawing.Size(20, 20);
      this.ClearFilesFilterBtn.TabIndex = 0;
      this.ClearFilesFilterBtn.Text = "X";
      this.ClearFilesFilterBtn.UseVisualStyleBackColor = true;
      this.ClearFilesFilterBtn.Click += new System.EventHandler(this.ClearFilesFilterBtn_Click);
      // 
      // ToBeSortedFilter
      // 
      this.ToBeSortedFilter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ToBeSortedFilter.Location = new System.Drawing.Point(0, 0);
      this.ToBeSortedFilter.Margin = new System.Windows.Forms.Padding(0);
      this.ToBeSortedFilter.Name = "ToBeSortedFilter";
      this.ToBeSortedFilter.Size = new System.Drawing.Size(173, 20);
      this.ToBeSortedFilter.TabIndex = 1;
      this.ToBeSortedFilter.TextChanged += new System.EventHandler(this.ToBeSortedFilter_TextChanged);
      // 
      // SortByLabel
      // 
      this.SortByLabel.AutoSize = true;
      this.SortByLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SortByLabel.Location = new System.Drawing.Point(3, 0);
      this.SortByLabel.Name = "SortByLabel";
      this.SortByLabel.Size = new System.Drawing.Size(187, 13);
      this.SortByLabel.TabIndex = 7;
      this.SortByLabel.Text = "Sort By";
      // 
      // ToBeSortedFilterLabel
      // 
      this.ToBeSortedFilterLabel.AutoSize = true;
      this.ToBeSortedFilterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ToBeSortedFilterLabel.Location = new System.Drawing.Point(3, 34);
      this.ToBeSortedFilterLabel.Name = "ToBeSortedFilterLabel";
      this.ToBeSortedFilterLabel.Size = new System.Drawing.Size(187, 13);
      this.ToBeSortedFilterLabel.TabIndex = 3;
      this.ToBeSortedFilterLabel.Text = "Filter files by name";
      // 
      // FilesToBeSorted
      // 
      this.FilesToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FilesToBeSorted.FormattingEnabled = true;
      this.FilesToBeSorted.Location = new System.Drawing.Point(0, 80);
      this.FilesToBeSorted.Margin = new System.Windows.Forms.Padding(0);
      this.FilesToBeSorted.Name = "FilesToBeSorted";
      this.FilesToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.FilesToBeSorted.Size = new System.Drawing.Size(193, 120);
      this.FilesToBeSorted.TabIndex = 0;
      this.FilesToBeSorted.SelectedIndexChanged += new System.EventHandler(this.FilesToBeSorted_SelectedIndexChanged);
      this.FilesToBeSorted.GotFocus += new System.EventHandler(this.FilesToBeSorted_GotFocus);
      this.FilesToBeSorted.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FilesToBeSorted_MouseDown);
      // 
      // ToBeSortedLabel
      // 
      this.ToBeSortedLabel.AutoSize = true;
      this.ToBeSortedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ToBeSortedLabel.Location = new System.Drawing.Point(3, 67);
      this.ToBeSortedLabel.Name = "ToBeSortedLabel";
      this.ToBeSortedLabel.Size = new System.Drawing.Size(187, 13);
      this.ToBeSortedLabel.TabIndex = 2;
      this.ToBeSortedLabel.Text = "Files To Be Sorted";
      // 
      // FoldersToBeSorted
      // 
      this.FoldersToBeSorted.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FoldersToBeSorted.FormattingEnabled = true;
      this.FoldersToBeSorted.Location = new System.Drawing.Point(0, 296);
      this.FoldersToBeSorted.Margin = new System.Windows.Forms.Padding(0);
      this.FoldersToBeSorted.Name = "FoldersToBeSorted";
      this.FoldersToBeSorted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.FoldersToBeSorted.Size = new System.Drawing.Size(193, 66);
      this.FoldersToBeSorted.TabIndex = 1;
      this.FoldersToBeSorted.SelectedIndexChanged += new System.EventHandler(this.FoldersToBeSorted_GotFocus);
      this.FoldersToBeSorted.GotFocus += new System.EventHandler(this.FoldersToBeSorted_GotFocus);
      // 
      // MainDirsButtonsTable
      // 
      this.MainDirsButtonsTable.ColumnCount = 5;
      this.MainDirsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.MainDirsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.MainDirsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.MainDirsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.MainDirsButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.MainDirsButtonsTable.Controls.Add(this.moveUpDir, 0, 0);
      this.MainDirsButtonsTable.Controls.Add(this.openFile, 1, 0);
      this.MainDirsButtonsTable.Controls.Add(this.enterDir, 2, 0);
      this.MainDirsButtonsTable.Controls.Add(this.DeleteDirButton, 3, 0);
      this.MainDirsButtonsTable.Controls.Add(this.PurgeAllEmptyDirsButton, 4, 0);
      this.MainDirsButtonsTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainDirsButtonsTable.Location = new System.Drawing.Point(0, 362);
      this.MainDirsButtonsTable.Margin = new System.Windows.Forms.Padding(0);
      this.MainDirsButtonsTable.Name = "MainDirsButtonsTable";
      this.MainDirsButtonsTable.RowCount = 1;
      this.MainDirsButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainDirsButtonsTable.Size = new System.Drawing.Size(193, 37);
      this.MainDirsButtonsTable.TabIndex = 3;
      // 
      // openFile
      // 
      this.openFile.Dock = System.Windows.Forms.DockStyle.Fill;
      this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
      this.openFile.Location = new System.Drawing.Point(38, 0);
      this.openFile.Margin = new System.Windows.Forms.Padding(0);
      this.openFile.Name = "openFile";
      this.openFile.Size = new System.Drawing.Size(38, 37);
      this.openFile.TabIndex = 7;
      this.openFile.UseVisualStyleBackColor = true;
      this.openFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenFile_Click);
      // 
      // MediaViewer1
      // 
      this.MediaViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MediaViewer1.Location = new System.Drawing.Point(0, 0);
      this.MediaViewer1.Name = "MediaViewer1";
      this.MediaViewer1.Size = new System.Drawing.Size(732, 399);
      this.MediaViewer1.TabIndex = 0;
      this.MediaViewer1.VlcMediaChanged += new SortWare.MediaViewer.VlcMediaChangedEventHandler(this.VlcControl1_MediaChanged);
      // 
      // TableLayoutPanel1
      // 
      this.TableLayoutPanel1.ColumnCount = 2;
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.TableLayoutPanel1.Controls.Add(this.MainDirsFilter, 0, 0);
      this.TableLayoutPanel1.Controls.Add(this.ClearDirFilterBtn, 1, 0);
      this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 13);
      this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 1;
      this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel1.Size = new System.Drawing.Size(259, 20);
      this.TableLayoutPanel1.TabIndex = 1;
      // 
      // MainDirsFilter
      // 
      this.MainDirsFilter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainDirsFilter.Location = new System.Drawing.Point(0, 0);
      this.MainDirsFilter.Margin = new System.Windows.Forms.Padding(0);
      this.MainDirsFilter.Name = "MainDirsFilter";
      this.MainDirsFilter.Size = new System.Drawing.Size(239, 20);
      this.MainDirsFilter.TabIndex = 1;
      this.MainDirsFilter.TextChanged += new System.EventHandler(this.MainDirsFilter_TextChanged);
      // 
      // ClearDirFilterBtn
      // 
      this.ClearDirFilterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClearDirFilterBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClearDirFilterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ClearDirFilterBtn.Location = new System.Drawing.Point(239, 0);
      this.ClearDirFilterBtn.Margin = new System.Windows.Forms.Padding(0);
      this.ClearDirFilterBtn.Name = "ClearDirFilterBtn";
      this.ClearDirFilterBtn.Size = new System.Drawing.Size(20, 20);
      this.ClearDirFilterBtn.TabIndex = 2;
      this.ClearDirFilterBtn.Text = "X";
      this.ClearDirFilterBtn.UseVisualStyleBackColor = true;
      this.ClearDirFilterBtn.Click += new System.EventHandler(this.ClearDirFilterBtn_Click);
      // 
      // RightSideTable
      // 
      this.RightSideTable.ColumnCount = 1;
      this.RightSideTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.RightSideTable.Controls.Add(this.MainDirsTable, 0, 1);
      this.RightSideTable.Controls.Add(this.MoveFolderSubDirButton, 0, 6);
      this.RightSideTable.Controls.Add(this.MoveFolderButton, 0, 5);
      this.RightSideTable.Controls.Add(this.TagsSelector, 0, 2);
      this.RightSideTable.Controls.Add(this.MoveFilesButton, 0, 4);
      this.RightSideTable.Controls.Add(this.UnderScoreManagerTable, 0, 3);
      this.RightSideTable.Controls.Add(this.TypeSelector1, 0, 0);
      this.RightSideTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RightSideTable.Location = new System.Drawing.Point(0, 0);
      this.RightSideTable.Margin = new System.Windows.Forms.Padding(0);
      this.RightSideTable.Name = "RightSideTable";
      this.RightSideTable.RowCount = 7;
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.30091F));
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.69909F));
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
      this.RightSideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
      this.RightSideTable.Size = new System.Drawing.Size(259, 512);
      this.RightSideTable.TabIndex = 1;
      // 
      // MainDirsTable
      // 
      this.MainDirsTable.ColumnCount = 1;
      this.MainDirsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainDirsTable.Controls.Add(this.TableLayoutPanel1, 0, 1);
      this.MainDirsTable.Controls.Add(this.Label2, 0, 0);
      this.MainDirsTable.Controls.Add(this.MainDirsTree, 0, 3);
      this.MainDirsTable.Controls.Add(this.MainDirsLabel, 0, 2);
      this.MainDirsTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainDirsTable.Location = new System.Drawing.Point(0, 113);
      this.MainDirsTable.Margin = new System.Windows.Forms.Padding(0);
      this.MainDirsTable.Name = "MainDirsTable";
      this.MainDirsTable.RowCount = 4;
      this.MainDirsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
      this.MainDirsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.MainDirsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
      this.MainDirsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainDirsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.MainDirsTable.Size = new System.Drawing.Size(259, 212);
      this.MainDirsTable.TabIndex = 1;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Label2.Location = new System.Drawing.Point(3, 0);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(253, 13);
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Filter dirs by name";
      // 
      // MainDirsTree
      // 
      this.MainDirsTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainDirsTree.Location = new System.Drawing.Point(0, 46);
      this.MainDirsTree.Margin = new System.Windows.Forms.Padding(0);
      this.MainDirsTree.Name = "MainDirsTree";
      this.MainDirsTree.Size = new System.Drawing.Size(259, 166);
      this.MainDirsTree.TabIndex = 15;
      this.MainDirsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainDirsTree_SelectedNodeChanged);
      // 
      // MainDirsLabel
      // 
      this.MainDirsLabel.AutoSize = true;
      this.MainDirsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainDirsLabel.Location = new System.Drawing.Point(3, 33);
      this.MainDirsLabel.Name = "MainDirsLabel";
      this.MainDirsLabel.Size = new System.Drawing.Size(253, 13);
      this.MainDirsLabel.TabIndex = 2;
      this.MainDirsLabel.Text = "Main Directories";
      // 
      // TagsSelector
      // 
      this.TagsSelector.ColumnWidth = 25;
      this.TagsSelector.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TagsSelector.FormattingEnabled = true;
      this.TagsSelector.Location = new System.Drawing.Point(0, 325);
      this.TagsSelector.Margin = new System.Windows.Forms.Padding(0);
      this.TagsSelector.MultiColumn = true;
      this.TagsSelector.Name = "TagsSelector";
      this.TagsSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.TagsSelector.Size = new System.Drawing.Size(259, 94);
      this.TagsSelector.TabIndex = 3;
      this.TagsSelector.SelectedIndexChanged += new System.EventHandler(this.TagsSelector_SelectedIndexChanged);
      // 
      // UnderScoreManagerTable
      // 
      this.UnderScoreManagerTable.ColumnCount = 2;
      this.UnderScoreManagerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.UnderScoreManagerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.UnderScoreManagerTable.Controls.Add(this.UnderScoreAddUpDown, 0, 0);
      this.UnderScoreManagerTable.Controls.Add(this.AddUnderScoreButton, 1, 0);
      this.UnderScoreManagerTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UnderScoreManagerTable.Location = new System.Drawing.Point(0, 419);
      this.UnderScoreManagerTable.Margin = new System.Windows.Forms.Padding(0);
      this.UnderScoreManagerTable.Name = "UnderScoreManagerTable";
      this.UnderScoreManagerTable.RowCount = 1;
      this.UnderScoreManagerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.UnderScoreManagerTable.Size = new System.Drawing.Size(259, 23);
      this.UnderScoreManagerTable.TabIndex = 6;
      // 
      // UnderScoreAddUpDown
      // 
      this.UnderScoreAddUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UnderScoreAddUpDown.Location = new System.Drawing.Point(0, 0);
      this.UnderScoreAddUpDown.Margin = new System.Windows.Forms.Padding(0);
      this.UnderScoreAddUpDown.Name = "UnderScoreAddUpDown";
      this.UnderScoreAddUpDown.Size = new System.Drawing.Size(129, 20);
      this.UnderScoreAddUpDown.TabIndex = 0;
      this.UnderScoreAddUpDown.ValueChanged += new System.EventHandler(this.UnderScoreAddUpDown_ValueChanged);
      // 
      // TypeSelector1
      // 
      this.TypeSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TypeSelector1.Location = new System.Drawing.Point(3, 3);
      this.TypeSelector1.Name = "TypeSelector1";
      this.TypeSelector1.Size = new System.Drawing.Size(253, 107);
      this.TypeSelector1.TabIndex = 7;
      this.TypeSelector1.CheckChanged += new SortWare.TypeSelector.CheckChangedEventHandler(this.TypeSelector1_CheckChangeded);
      // 
      // ImageList1
      // 
      this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.ImageList1.ImageSize = new System.Drawing.Size(24, 24);
      this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // AlertTimer
      // 
      this.AlertTimer.Interval = 3000;
      this.AlertTimer.Tick += new System.EventHandler(this.AlertTimer_Tick);
      // 
      // SplitContainer2
      // 
      this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer2.Name = "SplitContainer2";
      // 
      // SplitContainer2.Panel1
      // 
      this.SplitContainer2.Panel1.Controls.Add(this.SplitContainer1);
      // 
      // SplitContainer2.Panel2
      // 
      this.SplitContainer2.Panel2.Controls.Add(this.RightSideTable);
      this.SplitContainer2.Size = new System.Drawing.Size(1196, 512);
      this.SplitContainer2.SplitterDistance = 933;
      this.SplitContainer2.TabIndex = 2;
      // 
      // FileRightClickContextMenu
      // 
      this.FileRightClickContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameToolStripMenuItem,
            this.GroupToolStripMenuItem1});
      this.FileRightClickContextMenu.Name = "ContextMenuStrip1";
      this.FileRightClickContextMenu.Size = new System.Drawing.Size(200, 48);
      // 
      // RenameToolStripMenuItem
      // 
      this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
      this.RenameToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
      this.RenameToolStripMenuItem.Text = "Rename";
      this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
      // 
      // GroupToolStripMenuItem1
      // 
      this.GroupToolStripMenuItem1.Name = "GroupToolStripMenuItem1";
      this.GroupToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
      this.GroupToolStripMenuItem1.Text = "Group Items Into Folder";
      this.GroupToolStripMenuItem1.Click += new System.EventHandler(this.GroupToolStripMenuItem1_Click);
      // 
      // MainInterface
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1196, 534);
      this.Controls.Add(this.SplitContainer2);
      this.Controls.Add(this.StatusStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "MainInterface";
      this.Text = "SortWare";
      this.Load += new System.EventHandler(this.MainInterface_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleKeys);
      this.StatusStrip1.ResumeLayout(false);
      this.StatusStrip1.PerformLayout();
      this.SplitContainer1.Panel1.ResumeLayout(false);
      this.SplitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
      this.SplitContainer1.ResumeLayout(false);
      this.TopBarTable.ResumeLayout(false);
      this.Panel1.ResumeLayout(false);
      this.Panel1.PerformLayout();
      this.miscControlsPanel.ResumeLayout(false);
      this.miscControlsPanel.PerformLayout();
      this.StatusStrip2.ResumeLayout(false);
      this.StatusStrip2.PerformLayout();
      this.StarRatingPanel.ResumeLayout(false);
      this.StarRatingPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
      this.MediaAndPresortsSplit.Panel1.ResumeLayout(false);
      this.MediaAndPresortsSplit.Panel1.PerformLayout();
      this.MediaAndPresortsSplit.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.MediaAndPresortsSplit)).EndInit();
      this.MediaAndPresortsSplit.ResumeLayout(false);
      this.PresortDirPanels.ResumeLayout(false);
      this.PresortDirPanels.PerformLayout();
      this.TableLayoutPanel3.ResumeLayout(false);
      this.TableLayoutPanel3.PerformLayout();
      this.PresortFolderButtonsTable.ResumeLayout(false);
      this.PresortTableLayout.ResumeLayout(false);
      this.PresortTableLayout.PerformLayout();
      this.TableLayoutPanel2.ResumeLayout(false);
      this.TableLayoutPanel2.PerformLayout();
      this.MainDirsButtonsTable.ResumeLayout(false);
      this.TableLayoutPanel1.ResumeLayout(false);
      this.TableLayoutPanel1.PerformLayout();
      this.RightSideTable.ResumeLayout(false);
      this.MainDirsTable.ResumeLayout(false);
      this.MainDirsTable.PerformLayout();
      this.UnderScoreManagerTable.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.UnderScoreAddUpDown)).EndInit();
      this.SplitContainer2.Panel1.ResumeLayout(false);
      this.SplitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
      this.SplitContainer2.ResumeLayout(false);
      this.FileRightClickContextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

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
    internal StatusStrip StatusStrip2;
    internal ToolStripStatusLabel PropertiesSaveStatus;
  }
}