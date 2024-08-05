using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class SortSettingsDialog : Form
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
            var TreeNode1 = new TreeNode("Root Directory");
            var TreeNode2 = new TreeNode("Main Directories");
            var TreeNode3 = new TreeNode("Presorted Directories");
            var TreeNode4 = new TreeNode("Blocked Directories");
            var TreeNode5 = new TreeNode("Conversion Directories");
            var TreeNode6 = new TreeNode("Finished Conversions Directory");
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SortSettingsDialog));
            FinishedButton = new Button();
            FinishedButton.Click += new EventHandler(FinishedButton_Click);
            SettingsViewer = new RichTextBox();
            SettingsViewer.TextChanged += new EventHandler(SettingsViewer_TextChanged);
            InitializeSettings = new Button();
            InitializeSettings.Click += new EventHandler(InitializeSettings_Click);
            ToolTip1 = new ToolTip(components);
            TagsButtonGroup = new GroupBox();
            TagViewerPanel = new Panel();
            TagsViewer = new ListBox();
            TagsViewer.SelectedIndexChanged += new EventHandler(TagsViewer_SelectedIndexChanged);
            TagsSaveButton = new Button();
            TagsSaveButton.Click += new EventHandler(TagsSaveButton_Click);
            RemoveTagButton = new Button();
            RemoveTagButton.Click += new EventHandler(RemoveTagButton_Click);
            TagEntryTable = new TableLayoutPanel();
            TagDescEntry = new TextBox();
            TagIDEntry = new TextBox();
            AddTagButton = new Button();
            AddTagButton.Click += new EventHandler(AddTagButton_Click);
            AddButtonGroup = new GroupBox();
            removeDir = new Button();
            removeDir.Click += new EventHandler(RemoveDir_Click);
            addFinishedDir = new Button();
            addFinishedDir.Click += new EventHandler(AddFinishedDir_Click);
            addConvertDir = new Button();
            addConvertDir.Click += new EventHandler(AddConvertDir_Click);
            addPresortDir = new Button();
            addPresortDir.Click += new EventHandler(AddPresortDir_Click);
            addBlockedDir = new Button();
            addMainSubdir = new Button();
            addMainSubdir.Click += new EventHandler(AddMainSubdir_Click);
            addMainDir = new Button();
            addMainDir.Click += new EventHandler(AddMainDir_Click);
            addRootDir = new Button();
            addRootDir.Click += new EventHandler(AddRootDir_Click);
            SaveButton = new Button();
            SaveButton.Click += new EventHandler(SaveButton_Click);
            StatusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            ErrorTimer = new Timer(components);
            ErrorTimer.Tick += new EventHandler(ErrorTimer_Tick);
            TableLayoutPanel2 = new TableLayoutPanel();
            Panel1 = new Panel();
            Panel2 = new Panel();
            RootDirViewTree = new TreeView();
            RootDirViewTree.NodeMouseClick += new TreeNodeMouseClickEventHandler(RefreshAddButtons);
            RootDirViewTree.Click += new EventHandler(AddNewDir);
            SettingsTreeView = new TreeView();
            SettingsTreeView.AfterSelect += new TreeViewEventHandler(RefreshAddButtons);
            SettingsTreeView.MouseDown += new MouseEventHandler(SettingsTreeView_MouseDown);
            DirErrorGroup = new GroupBox();
            PrevErrorButton = new Button();
            PrevErrorButton.Click += new EventHandler(PrevErrorButton_Click);
            NextErrorButton = new Button();
            NextErrorButton.Click += new EventHandler(NextErrorButton_Click);
            TagsButtonGroup.SuspendLayout();
            TagViewerPanel.SuspendLayout();
            TagEntryTable.SuspendLayout();
            AddButtonGroup.SuspendLayout();
            StatusStrip1.SuspendLayout();
            TableLayoutPanel2.SuspendLayout();
            Panel1.SuspendLayout();
            Panel2.SuspendLayout();
            DirErrorGroup.SuspendLayout();
            SuspendLayout();
            // 
            // FinishedButton
            // 
            FinishedButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FinishedButton.Location = new Point(108, 479);
            FinishedButton.Name = "FinishedButton";
            FinishedButton.Size = new Size(73, 23);
            FinishedButton.TabIndex = 2;
            FinishedButton.Text = "Done";
            FinishedButton.UseVisualStyleBackColor = true;
            // 
            // SettingsViewer
            // 
            SettingsViewer.Dock = DockStyle.Fill;
            SettingsViewer.Location = new Point(650, 3);
            SettingsViewer.Name = "SettingsViewer";
            SettingsViewer.Size = new Size(147, 505);
            SettingsViewer.TabIndex = 3;
            SettingsViewer.Text = "";
            // 
            // InitializeSettings
            // 
            InitializeSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            InitializeSettings.Enabled = false;
            InitializeSettings.Location = new Point(3, 450);
            InitializeSettings.Name = "InitializeSettings";
            InitializeSettings.Size = new Size(92, 52);
            InitializeSettings.TabIndex = 4;
            InitializeSettings.Text = "Initialize .sortSettings File";
            ToolTip1.SetToolTip(InitializeSettings, "If no .sortSettings file is found, clicking this button will create one in the se" + "lected root directory");
            InitializeSettings.UseVisualStyleBackColor = true;
            // 
            // TagsButtonGroup
            // 
            TagsButtonGroup.Anchor = AnchorStyles.Top;
            TagsButtonGroup.AutoSize = true;
            TagsButtonGroup.Controls.Add(TagViewerPanel);
            TagsButtonGroup.Controls.Add(RemoveTagButton);
            TagsButtonGroup.Controls.Add(TagEntryTable);
            TagsButtonGroup.Controls.Add(AddTagButton);
            TagsButtonGroup.Location = new Point(5, 212);
            TagsButtonGroup.Name = "TagsButtonGroup";
            TagsButtonGroup.Size = new Size(176, 146);
            TagsButtonGroup.TabIndex = 13;
            TagsButtonGroup.TabStop = false;
            TagsButtonGroup.Text = "Add Tags to Sort Directory";
            // 
            // TagViewerPanel
            // 
            TagViewerPanel.Controls.Add(TagsViewer);
            TagViewerPanel.Controls.Add(TagsSaveButton);
            TagViewerPanel.Dock = DockStyle.Fill;
            TagViewerPanel.Location = new Point(3, 82);
            TagViewerPanel.Name = "TagViewerPanel";
            TagViewerPanel.Size = new Size(170, 61);
            TagViewerPanel.TabIndex = 14;
            // 
            // TagsViewer
            // 
            TagsViewer.Dock = DockStyle.Fill;
            TagsViewer.FormattingEnabled = true;
            TagsViewer.Location = new Point(0, 0);
            TagsViewer.Name = "TagsViewer";
            TagsViewer.Size = new Size(120, 61);
            TagsViewer.TabIndex = 2;
            // 
            // TagsSaveButton
            // 
            TagsSaveButton.Dock = DockStyle.Right;
            TagsSaveButton.Location = new Point(120, 0);
            TagsSaveButton.Name = "TagsSaveButton";
            TagsSaveButton.Size = new Size(50, 61);
            TagsSaveButton.TabIndex = 1;
            TagsSaveButton.UseVisualStyleBackColor = true;
            // 
            // RemoveTagButton
            // 
            RemoveTagButton.Dock = DockStyle.Top;
            RemoveTagButton.Location = new Point(3, 59);
            RemoveTagButton.Name = "RemoveTagButton";
            RemoveTagButton.Size = new Size(170, 23);
            RemoveTagButton.TabIndex = 12;
            RemoveTagButton.Text = "<< Remove Tag";
            RemoveTagButton.UseVisualStyleBackColor = true;
            // 
            // TagEntryTable
            // 
            TagEntryTable.ColumnCount = 2;
            TagEntryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.63743f));
            TagEntryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.36257f));
            TagEntryTable.Controls.Add(TagDescEntry, 1, 0);
            TagEntryTable.Controls.Add(TagIDEntry, 0, 0);
            TagEntryTable.Dock = DockStyle.Top;
            TagEntryTable.Location = new Point(3, 39);
            TagEntryTable.Name = "TagEntryTable";
            TagEntryTable.RowCount = 1;
            TagEntryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TagEntryTable.Size = new Size(170, 20);
            TagEntryTable.TabIndex = 13;
            // 
            // TagDescEntry
            // 
            TagDescEntry.Dock = DockStyle.Fill;
            TagDescEntry.Location = new Point(36, 0);
            TagDescEntry.Margin = new Padding(0);
            TagDescEntry.Name = "TagDescEntry";
            TagDescEntry.Size = new Size(134, 20);
            TagDescEntry.TabIndex = 1;
            // 
            // TagIDEntry
            // 
            TagIDEntry.Dock = DockStyle.Fill;
            TagIDEntry.Location = new Point(0, 0);
            TagIDEntry.Margin = new Padding(0);
            TagIDEntry.Name = "TagIDEntry";
            TagIDEntry.Size = new Size(36, 20);
            TagIDEntry.TabIndex = 0;
            // 
            // AddTagButton
            // 
            AddTagButton.Dock = DockStyle.Top;
            AddTagButton.Location = new Point(3, 16);
            AddTagButton.Name = "AddTagButton";
            AddTagButton.Size = new Size(170, 23);
            AddTagButton.TabIndex = 8;
            AddTagButton.Text = "Add Tag >>";
            AddTagButton.UseVisualStyleBackColor = true;
            // 
            // AddButtonGroup
            // 
            AddButtonGroup.Anchor = AnchorStyles.Top;
            AddButtonGroup.AutoSize = true;
            AddButtonGroup.Controls.Add(removeDir);
            AddButtonGroup.Controls.Add(addFinishedDir);
            AddButtonGroup.Controls.Add(addConvertDir);
            AddButtonGroup.Controls.Add(addPresortDir);
            AddButtonGroup.Controls.Add(addBlockedDir);
            AddButtonGroup.Controls.Add(addMainSubdir);
            AddButtonGroup.Controls.Add(addMainDir);
            AddButtonGroup.Controls.Add(addRootDir);
            AddButtonGroup.Location = new Point(5, 3);
            AddButtonGroup.Name = "AddButtonGroup";
            AddButtonGroup.Size = new Size(177, 203);
            AddButtonGroup.TabIndex = 12;
            AddButtonGroup.TabStop = false;
            AddButtonGroup.Text = "Add Directories to Sort Settings";
            // 
            // removeDir
            // 
            removeDir.Dock = DockStyle.Top;
            removeDir.Location = new Point(3, 177);
            removeDir.Name = "removeDir";
            removeDir.Size = new Size(171, 23);
            removeDir.TabIndex = 12;
            removeDir.Text = "<< Remove Directory";
            removeDir.UseVisualStyleBackColor = true;
            // 
            // addFinishedDir
            // 
            addFinishedDir.Dock = DockStyle.Top;
            addFinishedDir.Location = new Point(3, 154);
            addFinishedDir.Name = "addFinishedDir";
            addFinishedDir.Size = new Size(171, 23);
            addFinishedDir.TabIndex = 15;
            addFinishedDir.Text = "Finished Files Directory >>";
            addFinishedDir.UseVisualStyleBackColor = true;
            // 
            // addConvertDir
            // 
            addConvertDir.Dock = DockStyle.Top;
            addConvertDir.Location = new Point(3, 131);
            addConvertDir.Name = "addConvertDir";
            addConvertDir.Size = new Size(171, 23);
            addConvertDir.TabIndex = 14;
            addConvertDir.Text = "Convert Directory >>";
            addConvertDir.UseVisualStyleBackColor = true;
            // 
            // addPresortDir
            // 
            addPresortDir.Dock = DockStyle.Top;
            addPresortDir.Location = new Point(3, 108);
            addPresortDir.Name = "addPresortDir";
            addPresortDir.Size = new Size(171, 23);
            addPresortDir.TabIndex = 11;
            addPresortDir.Text = "Pre-sort Directory >>";
            addPresortDir.UseVisualStyleBackColor = true;
            // 
            // addBlockedDir
            // 
            addBlockedDir.Dock = DockStyle.Top;
            addBlockedDir.Location = new Point(3, 85);
            addBlockedDir.Name = "addBlockedDir";
            addBlockedDir.Size = new Size(171, 23);
            addBlockedDir.TabIndex = 10;
            addBlockedDir.Text = "Blocked Directory >>";
            addBlockedDir.UseVisualStyleBackColor = true;
            // 
            // addMainSubdir
            // 
            addMainSubdir.Dock = DockStyle.Top;
            addMainSubdir.Location = new Point(3, 62);
            addMainSubdir.Name = "addMainSubdir";
            addMainSubdir.Size = new Size(171, 23);
            addMainSubdir.TabIndex = 13;
            addMainSubdir.Text = "Main Subdirectory >>";
            addMainSubdir.UseVisualStyleBackColor = true;
            // 
            // addMainDir
            // 
            addMainDir.Dock = DockStyle.Top;
            addMainDir.Location = new Point(3, 39);
            addMainDir.Name = "addMainDir";
            addMainDir.Size = new Size(171, 23);
            addMainDir.TabIndex = 9;
            addMainDir.Text = "Main Directory >>";
            addMainDir.UseVisualStyleBackColor = true;
            // 
            // addRootDir
            // 
            addRootDir.Dock = DockStyle.Top;
            addRootDir.Location = new Point(3, 16);
            addRootDir.Name = "addRootDir";
            addRootDir.Size = new Size(171, 23);
            addRootDir.TabIndex = 8;
            addRootDir.Text = "Root Directory >>";
            addRootDir.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Location = new Point(108, 450);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(73, 23);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel });
            StatusStrip1.Location = new Point(0, 511);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(800, 22);
            StatusStrip1.TabIndex = 7;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 17);
            // 
            // ErrorTimer
            // 
            ErrorTimer.Interval = 5000;
            // 
            // TableLayoutPanel2
            // 
            TableLayoutPanel2.ColumnCount = 4;
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190.0f));
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0f));
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0f));
            TableLayoutPanel2.Controls.Add(SettingsViewer, 3, 0);
            TableLayoutPanel2.Controls.Add(Panel1, 1, 0);
            TableLayoutPanel2.Controls.Add(Panel2, 0, 0);
            TableLayoutPanel2.Controls.Add(SettingsTreeView, 2, 0);
            TableLayoutPanel2.Dock = DockStyle.Fill;
            TableLayoutPanel2.Location = new Point(0, 0);
            TableLayoutPanel2.Name = "TableLayoutPanel2";
            TableLayoutPanel2.RowCount = 1;
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel2.Size = new Size(800, 511);
            TableLayoutPanel2.TabIndex = 14;
            // 
            // Panel1
            // 
            Panel1.Controls.Add(DirErrorGroup);
            Panel1.Controls.Add(SaveButton);
            Panel1.Controls.Add(TagsButtonGroup);
            Panel1.Controls.Add(FinishedButton);
            Panel1.Controls.Add(InitializeSettings);
            Panel1.Controls.Add(AddButtonGroup);
            Panel1.Dock = DockStyle.Fill;
            Panel1.Location = new Point(308, 3);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(184, 505);
            Panel1.TabIndex = 6;
            // 
            // Panel2
            // 
            Panel2.Controls.Add(RootDirViewTree);
            Panel2.Dock = DockStyle.Fill;
            Panel2.Location = new Point(3, 3);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size(299, 505);
            Panel2.TabIndex = 7;
            // 
            // RootDirViewTree
            // 
            RootDirViewTree.Dock = DockStyle.Fill;
            RootDirViewTree.Location = new Point(0, 0);
            RootDirViewTree.Name = "RootDirViewTree";
            RootDirViewTree.Size = new Size(299, 505);
            RootDirViewTree.TabIndex = 6;
            // 
            // SettingsTreeView
            // 
            SettingsTreeView.Dock = DockStyle.Fill;
            SettingsTreeView.Location = new Point(498, 3);
            SettingsTreeView.Name = "SettingsTreeView";
            TreeNode1.Name = "rootDirNode";
            TreeNode1.Text = "Root Directory";
            TreeNode2.Name = "mainDirsNode";
            TreeNode2.Text = "Main Directories";
            TreeNode3.Name = "presortDirsNode";
            TreeNode3.Text = "Presorted Directories";
            TreeNode4.Name = "blockedDirsNode";
            TreeNode4.Text = "Blocked Directories";
            TreeNode5.Name = "convDirsNode";
            TreeNode5.Text = "Conversion Directories";
            TreeNode6.Name = "finishedDirNode";
            TreeNode6.Text = "Finished Conversions Directory";
            SettingsTreeView.Nodes.AddRange(new TreeNode[] { TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6 });
            SettingsTreeView.Size = new Size(146, 505);
            SettingsTreeView.TabIndex = 8;
            // 
            // DirErrorGroup
            // 
            DirErrorGroup.Controls.Add(NextErrorButton);
            DirErrorGroup.Controls.Add(PrevErrorButton);
            DirErrorGroup.Location = new Point(3, 361);
            DirErrorGroup.Name = "DirErrorGroup";
            DirErrorGroup.Size = new Size(178, 66);
            DirErrorGroup.TabIndex = 14;
            DirErrorGroup.TabStop = false;
            DirErrorGroup.Text = "Directory Errors: 0";
            // 
            // PrevErrorButton
            // 
            PrevErrorButton.Dock = DockStyle.Top;
            PrevErrorButton.Location = new Point(3, 16);
            PrevErrorButton.Name = "PrevErrorButton";
            PrevErrorButton.Size = new Size(172, 23);
            PrevErrorButton.TabIndex = 0;
            PrevErrorButton.Text = "Previous Error";
            PrevErrorButton.UseVisualStyleBackColor = true;
            // 
            // NextErrorButton
            // 
            NextErrorButton.Dock = DockStyle.Bottom;
            NextErrorButton.Location = new Point(3, 40);
            NextErrorButton.Name = "NextErrorButton";
            NextErrorButton.Size = new Size(172, 23);
            NextErrorButton.TabIndex = 1;
            NextErrorButton.Text = "Next Error";
            NextErrorButton.UseVisualStyleBackColor = true;
            // 
            // SortSettingsDialog
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 533);
            Controls.Add(TableLayoutPanel2);
            Controls.Add(StatusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SortSettingsDialog";
            Text = "Sort Settings Editor";
            TagsButtonGroup.ResumeLayout(false);
            TagViewerPanel.ResumeLayout(false);
            TagEntryTable.ResumeLayout(false);
            TagEntryTable.PerformLayout();
            AddButtonGroup.ResumeLayout(false);
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            TableLayoutPanel2.ResumeLayout(false);
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            Panel2.ResumeLayout(false);
            DirErrorGroup.ResumeLayout(false);
            Load += new EventHandler(SortSettingsDialog_Load);
            Closing += new System.ComponentModel.CancelEventHandler(SortSettingsDialog_Closing);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button FinishedButton;
        internal RichTextBox SettingsViewer;
        internal Button InitializeSettings;
        internal ToolTip ToolTip1;
        internal Button SaveButton;
        internal Button addBlockedDir;
        internal Button addMainDir;
        internal Button addRootDir;
        internal Button addPresortDir;
        internal StatusStrip StatusStrip1;
        internal GroupBox AddButtonGroup;
        internal ToolStripStatusLabel StatusLabel;
        internal Timer ErrorTimer;
        internal Button removeDir;
        internal GroupBox TagsButtonGroup;
        internal Button RemoveTagButton;
        internal Button AddTagButton;
        internal Button TagsSaveButton;
        internal TableLayoutPanel TagEntryTable;
        internal TextBox TagDescEntry;
        internal TextBox TagIDEntry;
        internal Panel TagViewerPanel;
        internal Button addMainSubdir;
        internal TableLayoutPanel TableLayoutPanel2;
        internal Panel Panel1;
        internal Panel Panel2;
        internal TreeView RootDirViewTree;
        internal Button addFinishedDir;
        internal Button addConvertDir;
        internal TreeView SettingsTreeView;
        internal ListBox TagsViewer;
        internal GroupBox DirErrorGroup;
        internal Button NextErrorButton;
        internal Button PrevErrorButton;
    }
}