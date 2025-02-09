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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Root Directory");
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Main Directories");
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Presorted Directories");
      System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Blocked Directories");
      System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Conversion Directories");
      System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Finished Conversions Directory");
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortSettingsDialog));
      this.FinishedButton = new System.Windows.Forms.Button();
      this.SettingsViewer = new System.Windows.Forms.RichTextBox();
      this.InitializeSettings = new System.Windows.Forms.Button();
      this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.TagsButtonGroup = new System.Windows.Forms.GroupBox();
      this.TagsViewer = new System.Windows.Forms.ListBox();
      this.RemoveTagButton = new System.Windows.Forms.Button();
      this.TagEntryTable = new System.Windows.Forms.TableLayoutPanel();
      this.TagDescEntry = new System.Windows.Forms.TextBox();
      this.TagIDEntry = new System.Windows.Forms.TextBox();
      this.AddTagButton = new System.Windows.Forms.Button();
      this.AddButtonGroup = new System.Windows.Forms.GroupBox();
      this.removeDir = new System.Windows.Forms.Button();
      this.addFinishedDir = new System.Windows.Forms.Button();
      this.addConvertDir = new System.Windows.Forms.Button();
      this.addPresortDir = new System.Windows.Forms.Button();
      this.addBlockedDir = new System.Windows.Forms.Button();
      this.addMainSubdir = new System.Windows.Forms.Button();
      this.addMainDir = new System.Windows.Forms.Button();
      this.addRootDir = new System.Windows.Forms.Button();
      this.SaveButton = new System.Windows.Forms.Button();
      this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
      this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.ErrorTimer = new System.Windows.Forms.Timer(this.components);
      this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.Panel1 = new System.Windows.Forms.Panel();
      this.DirErrorGroup = new System.Windows.Forms.GroupBox();
      this.NextErrorButton = new System.Windows.Forms.Button();
      this.PrevErrorButton = new System.Windows.Forms.Button();
      this.Panel2 = new System.Windows.Forms.Panel();
      this.RootDirViewTree = new System.Windows.Forms.TreeView();
      this.SettingsTreeView = new System.Windows.Forms.TreeView();
      this.TagsButtonGroup.SuspendLayout();
      this.TagEntryTable.SuspendLayout();
      this.AddButtonGroup.SuspendLayout();
      this.StatusStrip1.SuspendLayout();
      this.TableLayoutPanel2.SuspendLayout();
      this.Panel1.SuspendLayout();
      this.DirErrorGroup.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // FinishedButton
      // 
      this.FinishedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.FinishedButton.Location = new System.Drawing.Point(108, 479);
      this.FinishedButton.Name = "FinishedButton";
      this.FinishedButton.Size = new System.Drawing.Size(73, 23);
      this.FinishedButton.TabIndex = 2;
      this.FinishedButton.Text = "Done";
      this.FinishedButton.UseVisualStyleBackColor = true;
      this.FinishedButton.Click += new System.EventHandler(this.FinishedButton_Click);
      // 
      // SettingsViewer
      // 
      this.SettingsViewer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SettingsViewer.Location = new System.Drawing.Point(650, 3);
      this.SettingsViewer.Name = "SettingsViewer";
      this.SettingsViewer.Size = new System.Drawing.Size(147, 505);
      this.SettingsViewer.TabIndex = 3;
      this.SettingsViewer.Text = "";
      this.SettingsViewer.TextChanged += new System.EventHandler(this.SettingsViewer_TextChanged);
      // 
      // InitializeSettings
      // 
      this.InitializeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.InitializeSettings.Enabled = false;
      this.InitializeSettings.Location = new System.Drawing.Point(3, 450);
      this.InitializeSettings.Name = "InitializeSettings";
      this.InitializeSettings.Size = new System.Drawing.Size(92, 52);
      this.InitializeSettings.TabIndex = 4;
      this.InitializeSettings.Text = "Initialize .sortSettings File";
      this.ToolTip1.SetToolTip(this.InitializeSettings, "If no .sortSettings file is found, clicking this button will create one in the se" +
        "lected root directory");
      this.InitializeSettings.UseVisualStyleBackColor = true;
      this.InitializeSettings.Click += new System.EventHandler(this.InitializeSettings_Click);
      // 
      // TagsButtonGroup
      // 
      this.TagsButtonGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.TagsButtonGroup.AutoSize = true;
      this.TagsButtonGroup.Controls.Add(this.TagsViewer);
      this.TagsButtonGroup.Controls.Add(this.RemoveTagButton);
      this.TagsButtonGroup.Controls.Add(this.TagEntryTable);
      this.TagsButtonGroup.Controls.Add(this.AddTagButton);
      this.TagsButtonGroup.Location = new System.Drawing.Point(5, 212);
      this.TagsButtonGroup.Name = "TagsButtonGroup";
      this.TagsButtonGroup.Size = new System.Drawing.Size(176, 146);
      this.TagsButtonGroup.TabIndex = 13;
      this.TagsButtonGroup.TabStop = false;
      this.TagsButtonGroup.Text = "Add Tags to Sort Directory";
      // 
      // TagsViewer
      // 
      this.TagsViewer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TagsViewer.FormattingEnabled = true;
      this.TagsViewer.Location = new System.Drawing.Point(3, 82);
      this.TagsViewer.Name = "TagsViewer";
      this.TagsViewer.Size = new System.Drawing.Size(170, 61);
      this.TagsViewer.TabIndex = 2;
      this.TagsViewer.SelectedIndexChanged += new System.EventHandler(this.TagsViewer_SelectedIndexChanged);
      // 
      // RemoveTagButton
      // 
      this.RemoveTagButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.RemoveTagButton.Location = new System.Drawing.Point(3, 59);
      this.RemoveTagButton.Name = "RemoveTagButton";
      this.RemoveTagButton.Size = new System.Drawing.Size(170, 23);
      this.RemoveTagButton.TabIndex = 12;
      this.RemoveTagButton.Text = "<< Remove Tag";
      this.RemoveTagButton.UseVisualStyleBackColor = true;
      this.RemoveTagButton.Click += new System.EventHandler(this.RemoveTagButton_Click);
      // 
      // TagEntryTable
      // 
      this.TagEntryTable.ColumnCount = 2;
      this.TagEntryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.63743F));
      this.TagEntryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.36257F));
      this.TagEntryTable.Controls.Add(this.TagDescEntry, 1, 0);
      this.TagEntryTable.Controls.Add(this.TagIDEntry, 0, 0);
      this.TagEntryTable.Dock = System.Windows.Forms.DockStyle.Top;
      this.TagEntryTable.Location = new System.Drawing.Point(3, 39);
      this.TagEntryTable.Name = "TagEntryTable";
      this.TagEntryTable.RowCount = 1;
      this.TagEntryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TagEntryTable.Size = new System.Drawing.Size(170, 20);
      this.TagEntryTable.TabIndex = 13;
      // 
      // TagDescEntry
      // 
      this.TagDescEntry.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TagDescEntry.Location = new System.Drawing.Point(36, 0);
      this.TagDescEntry.Margin = new System.Windows.Forms.Padding(0);
      this.TagDescEntry.Name = "TagDescEntry";
      this.TagDescEntry.Size = new System.Drawing.Size(134, 20);
      this.TagDescEntry.TabIndex = 1;
      // 
      // TagIDEntry
      // 
      this.TagIDEntry.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TagIDEntry.Location = new System.Drawing.Point(0, 0);
      this.TagIDEntry.Margin = new System.Windows.Forms.Padding(0);
      this.TagIDEntry.Name = "TagIDEntry";
      this.TagIDEntry.Size = new System.Drawing.Size(36, 20);
      this.TagIDEntry.TabIndex = 0;
      // 
      // AddTagButton
      // 
      this.AddTagButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.AddTagButton.Location = new System.Drawing.Point(3, 16);
      this.AddTagButton.Name = "AddTagButton";
      this.AddTagButton.Size = new System.Drawing.Size(170, 23);
      this.AddTagButton.TabIndex = 8;
      this.AddTagButton.Text = "Add Tag >>";
      this.AddTagButton.UseVisualStyleBackColor = true;
      this.AddTagButton.Click += new System.EventHandler(this.AddTagButton_Click);
      // 
      // AddButtonGroup
      // 
      this.AddButtonGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.AddButtonGroup.AutoSize = true;
      this.AddButtonGroup.Controls.Add(this.removeDir);
      this.AddButtonGroup.Controls.Add(this.addFinishedDir);
      this.AddButtonGroup.Controls.Add(this.addConvertDir);
      this.AddButtonGroup.Controls.Add(this.addPresortDir);
      this.AddButtonGroup.Controls.Add(this.addBlockedDir);
      this.AddButtonGroup.Controls.Add(this.addMainSubdir);
      this.AddButtonGroup.Controls.Add(this.addMainDir);
      this.AddButtonGroup.Controls.Add(this.addRootDir);
      this.AddButtonGroup.Location = new System.Drawing.Point(5, 3);
      this.AddButtonGroup.Name = "AddButtonGroup";
      this.AddButtonGroup.Size = new System.Drawing.Size(177, 203);
      this.AddButtonGroup.TabIndex = 12;
      this.AddButtonGroup.TabStop = false;
      this.AddButtonGroup.Text = "Add Directories to Sort Settings";
      // 
      // removeDir
      // 
      this.removeDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.removeDir.Location = new System.Drawing.Point(3, 177);
      this.removeDir.Name = "removeDir";
      this.removeDir.Size = new System.Drawing.Size(171, 23);
      this.removeDir.TabIndex = 12;
      this.removeDir.Text = "<< Remove Directory";
      this.removeDir.UseVisualStyleBackColor = true;
      this.removeDir.Click += new System.EventHandler(this.RemoveDir_Click);
      // 
      // addFinishedDir
      // 
      this.addFinishedDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addFinishedDir.Location = new System.Drawing.Point(3, 154);
      this.addFinishedDir.Name = "addFinishedDir";
      this.addFinishedDir.Size = new System.Drawing.Size(171, 23);
      this.addFinishedDir.TabIndex = 15;
      this.addFinishedDir.Text = "Finished Files Directory >>";
      this.addFinishedDir.UseVisualStyleBackColor = true;
      this.addFinishedDir.Click += new System.EventHandler(this.AddFinishedDir_Click);
      // 
      // addConvertDir
      // 
      this.addConvertDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addConvertDir.Location = new System.Drawing.Point(3, 131);
      this.addConvertDir.Name = "addConvertDir";
      this.addConvertDir.Size = new System.Drawing.Size(171, 23);
      this.addConvertDir.TabIndex = 14;
      this.addConvertDir.Text = "Convert Directory >>";
      this.addConvertDir.UseVisualStyleBackColor = true;
      this.addConvertDir.Click += new System.EventHandler(this.AddConvertDir_Click);
      // 
      // addPresortDir
      // 
      this.addPresortDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addPresortDir.Location = new System.Drawing.Point(3, 108);
      this.addPresortDir.Name = "addPresortDir";
      this.addPresortDir.Size = new System.Drawing.Size(171, 23);
      this.addPresortDir.TabIndex = 11;
      this.addPresortDir.Text = "Pre-sort Directory >>";
      this.addPresortDir.UseVisualStyleBackColor = true;
      this.addPresortDir.Click += new System.EventHandler(this.AddPresortDir_Click);
      // 
      // addBlockedDir
      // 
      this.addBlockedDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addBlockedDir.Location = new System.Drawing.Point(3, 85);
      this.addBlockedDir.Name = "addBlockedDir";
      this.addBlockedDir.Size = new System.Drawing.Size(171, 23);
      this.addBlockedDir.TabIndex = 10;
      this.addBlockedDir.Text = "Blocked Directory >>";
      this.addBlockedDir.UseVisualStyleBackColor = true;
      // 
      // addMainSubdir
      // 
      this.addMainSubdir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addMainSubdir.Location = new System.Drawing.Point(3, 62);
      this.addMainSubdir.Name = "addMainSubdir";
      this.addMainSubdir.Size = new System.Drawing.Size(171, 23);
      this.addMainSubdir.TabIndex = 13;
      this.addMainSubdir.Text = "Main Subdirectory >>";
      this.addMainSubdir.UseVisualStyleBackColor = true;
      this.addMainSubdir.Click += new System.EventHandler(this.AddMainSubdir_Click);
      // 
      // addMainDir
      // 
      this.addMainDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addMainDir.Location = new System.Drawing.Point(3, 39);
      this.addMainDir.Name = "addMainDir";
      this.addMainDir.Size = new System.Drawing.Size(171, 23);
      this.addMainDir.TabIndex = 9;
      this.addMainDir.Text = "Main Directory >>";
      this.addMainDir.UseVisualStyleBackColor = true;
      this.addMainDir.Click += new System.EventHandler(this.AddMainDir_Click);
      // 
      // addRootDir
      // 
      this.addRootDir.Dock = System.Windows.Forms.DockStyle.Top;
      this.addRootDir.Location = new System.Drawing.Point(3, 16);
      this.addRootDir.Name = "addRootDir";
      this.addRootDir.Size = new System.Drawing.Size(171, 23);
      this.addRootDir.TabIndex = 8;
      this.addRootDir.Text = "Root Directory >>";
      this.addRootDir.UseVisualStyleBackColor = true;
      this.addRootDir.Click += new System.EventHandler(this.AddRootDir_Click);
      // 
      // SaveButton
      // 
      this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.SaveButton.Location = new System.Drawing.Point(108, 450);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(73, 23);
      this.SaveButton.TabIndex = 7;
      this.SaveButton.Text = "Save";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // StatusStrip1
      // 
      this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
      this.StatusStrip1.Location = new System.Drawing.Point(0, 511);
      this.StatusStrip1.Name = "StatusStrip1";
      this.StatusStrip1.Size = new System.Drawing.Size(800, 22);
      this.StatusStrip1.TabIndex = 7;
      this.StatusStrip1.Text = "StatusStrip1";
      // 
      // StatusLabel
      // 
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // ErrorTimer
      // 
      this.ErrorTimer.Interval = 5000;
      this.ErrorTimer.Tick += new System.EventHandler(this.ErrorTimer_Tick);
      // 
      // TableLayoutPanel2
      // 
      this.TableLayoutPanel2.ColumnCount = 4;
      this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
      this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.TableLayoutPanel2.Controls.Add(this.SettingsViewer, 3, 0);
      this.TableLayoutPanel2.Controls.Add(this.Panel1, 1, 0);
      this.TableLayoutPanel2.Controls.Add(this.Panel2, 0, 0);
      this.TableLayoutPanel2.Controls.Add(this.SettingsTreeView, 2, 0);
      this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.TableLayoutPanel2.Name = "TableLayoutPanel2";
      this.TableLayoutPanel2.RowCount = 1;
      this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel2.Size = new System.Drawing.Size(800, 511);
      this.TableLayoutPanel2.TabIndex = 14;
      // 
      // Panel1
      // 
      this.Panel1.Controls.Add(this.DirErrorGroup);
      this.Panel1.Controls.Add(this.SaveButton);
      this.Panel1.Controls.Add(this.TagsButtonGroup);
      this.Panel1.Controls.Add(this.FinishedButton);
      this.Panel1.Controls.Add(this.InitializeSettings);
      this.Panel1.Controls.Add(this.AddButtonGroup);
      this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel1.Location = new System.Drawing.Point(308, 3);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new System.Drawing.Size(184, 505);
      this.Panel1.TabIndex = 6;
      // 
      // DirErrorGroup
      // 
      this.DirErrorGroup.Controls.Add(this.NextErrorButton);
      this.DirErrorGroup.Controls.Add(this.PrevErrorButton);
      this.DirErrorGroup.Location = new System.Drawing.Point(3, 361);
      this.DirErrorGroup.Name = "DirErrorGroup";
      this.DirErrorGroup.Size = new System.Drawing.Size(178, 66);
      this.DirErrorGroup.TabIndex = 14;
      this.DirErrorGroup.TabStop = false;
      this.DirErrorGroup.Text = "Directory Errors: 0";
      // 
      // NextErrorButton
      // 
      this.NextErrorButton.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.NextErrorButton.Location = new System.Drawing.Point(3, 40);
      this.NextErrorButton.Name = "NextErrorButton";
      this.NextErrorButton.Size = new System.Drawing.Size(172, 23);
      this.NextErrorButton.TabIndex = 1;
      this.NextErrorButton.Text = "Next Error";
      this.NextErrorButton.UseVisualStyleBackColor = true;
      this.NextErrorButton.Click += new System.EventHandler(this.NextErrorButton_Click);
      // 
      // PrevErrorButton
      // 
      this.PrevErrorButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.PrevErrorButton.Location = new System.Drawing.Point(3, 16);
      this.PrevErrorButton.Name = "PrevErrorButton";
      this.PrevErrorButton.Size = new System.Drawing.Size(172, 23);
      this.PrevErrorButton.TabIndex = 0;
      this.PrevErrorButton.Text = "Previous Error";
      this.PrevErrorButton.UseVisualStyleBackColor = true;
      this.PrevErrorButton.Click += new System.EventHandler(this.PrevErrorButton_Click);
      // 
      // Panel2
      // 
      this.Panel2.Controls.Add(this.RootDirViewTree);
      this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel2.Location = new System.Drawing.Point(3, 3);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new System.Drawing.Size(299, 505);
      this.Panel2.TabIndex = 7;
      // 
      // RootDirViewTree
      // 
      this.RootDirViewTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RootDirViewTree.Location = new System.Drawing.Point(0, 0);
      this.RootDirViewTree.Name = "RootDirViewTree";
      this.RootDirViewTree.Size = new System.Drawing.Size(299, 505);
      this.RootDirViewTree.TabIndex = 6;
      this.RootDirViewTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RefreshAddButtons);
      this.RootDirViewTree.Click += new System.EventHandler(this.AddNewDir);
      // 
      // SettingsTreeView
      // 
      this.SettingsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SettingsTreeView.Location = new System.Drawing.Point(498, 3);
      this.SettingsTreeView.Name = "SettingsTreeView";
      treeNode1.Name = "rootDirNode";
      treeNode1.Text = "Root Directory";
      treeNode2.Name = "mainDirsNode";
      treeNode2.Text = "Main Directories";
      treeNode3.Name = "presortDirsNode";
      treeNode3.Text = "Presorted Directories";
      treeNode4.Name = "blockedDirsNode";
      treeNode4.Text = "Blocked Directories";
      treeNode5.Name = "convDirsNode";
      treeNode5.Text = "Conversion Directories";
      treeNode6.Name = "finishedDirNode";
      treeNode6.Text = "Finished Conversions Directory";
      this.SettingsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
      this.SettingsTreeView.Size = new System.Drawing.Size(146, 505);
      this.SettingsTreeView.TabIndex = 8;
      this.SettingsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RefreshAddButtons);
      this.SettingsTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingsTreeView_MouseDown);
      // 
      // SortSettingsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 533);
      this.Controls.Add(this.TableLayoutPanel2);
      this.Controls.Add(this.StatusStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "SortSettingsDialog";
      this.Text = "Sort Settings Editor";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.SortSettingsDialog_Closing);
      this.Load += new System.EventHandler(this.SortSettingsDialog_Load);
      this.TagsButtonGroup.ResumeLayout(false);
      this.TagEntryTable.ResumeLayout(false);
      this.TagEntryTable.PerformLayout();
      this.AddButtonGroup.ResumeLayout(false);
      this.StatusStrip1.ResumeLayout(false);
      this.StatusStrip1.PerformLayout();
      this.TableLayoutPanel2.ResumeLayout(false);
      this.Panel1.ResumeLayout(false);
      this.Panel1.PerformLayout();
      this.DirErrorGroup.ResumeLayout(false);
      this.Panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

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
        internal TableLayoutPanel TagEntryTable;
        internal TextBox TagDescEntry;
        internal TextBox TagIDEntry;
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