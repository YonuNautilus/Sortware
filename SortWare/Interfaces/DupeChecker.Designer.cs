using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
  [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
  public partial class DupeChecker : Form
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
      this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.ControlsTable = new System.Windows.Forms.TableLayoutPanel();
      this.ControlsPanel = new System.Windows.Forms.Panel();
      this.IgnoreMetaDataBox = new System.Windows.Forms.CheckBox();
      this.MarkFilesWithDupes = new System.Windows.Forms.Button();
      this.FindDupeNames = new System.Windows.Forms.Button();
      this.FindDupesButton = new System.Windows.Forms.Button();
      this.RegexFilterInput = new System.Windows.Forms.TextBox();
      this.RegexInputLabel = new System.Windows.Forms.Label();
      this.Panel1 = new System.Windows.Forms.Panel();
      this.MasterDirTextBox = new System.Windows.Forms.TextBox();
      this.TargetDirTextBox = new System.Windows.Forms.TextBox();
      this.Panel2 = new System.Windows.Forms.Panel();
      this.SelectTargetDirButton = new System.Windows.Forms.Button();
      this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.DoRecursiveTarget = new System.Windows.Forms.CheckBox();
      this.TargetIsSameAsMaster = new System.Windows.Forms.CheckBox();
      this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.TargetFilesView = new System.Windows.Forms.ListView();
      this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.FileRightClickContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.KeepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.DontKeepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ClearStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MasterFilesView = new System.Windows.Forms.ListView();
      this.FilenameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.HashHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.KeepStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.MediaViewer1 = new SortWare.MediaViewer();
      this.Panel3 = new System.Windows.Forms.Panel();
      this.DoRecursiveMaster = new System.Windows.Forms.CheckBox();
      this.ExecuteMasterDupes = new System.Windows.Forms.Button();
      this.SelectMasterDirButton = new System.Windows.Forms.Button();
      this.TypeSelector1 = new SortWare.TypeSelector();
      this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
      this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.DirectoryEntry1 = new System.DirectoryServices.DirectoryEntry();
      this.TableLayoutPanel1.SuspendLayout();
      this.ControlsTable.SuspendLayout();
      this.ControlsPanel.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.TableLayoutPanel4.SuspendLayout();
      this.TableLayoutPanel3.SuspendLayout();
      this.FileRightClickContextMenu.SuspendLayout();
      this.Panel3.SuspendLayout();
      this.StatusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // TableLayoutPanel1
      // 
      this.TableLayoutPanel1.ColumnCount = 3;
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
      this.TableLayoutPanel1.Controls.Add(this.ControlsTable, 2, 2);
      this.TableLayoutPanel1.Controls.Add(this.MasterDirTextBox, 0, 1);
      this.TableLayoutPanel1.Controls.Add(this.TargetDirTextBox, 1, 1);
      this.TableLayoutPanel1.Controls.Add(this.Panel2, 1, 0);
      this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel3, 0, 2);
      this.TableLayoutPanel1.Controls.Add(this.Panel3, 0, 0);
      this.TableLayoutPanel1.Controls.Add(this.TypeSelector1, 2, 0);
      this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 3;
      this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel1.Size = new System.Drawing.Size(800, 428);
      this.TableLayoutPanel1.TabIndex = 0;
      // 
      // ControlsTable
      // 
      this.ControlsTable.ColumnCount = 1;
      this.ControlsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ControlsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.ControlsTable.Controls.Add(this.ControlsPanel, 0, 0);
      this.ControlsTable.Controls.Add(this.Panel1, 0, 1);
      this.ControlsTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ControlsTable.Location = new System.Drawing.Point(650, 90);
      this.ControlsTable.Margin = new System.Windows.Forms.Padding(0);
      this.ControlsTable.Name = "ControlsTable";
      this.ControlsTable.RowCount = 2;
      this.ControlsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ControlsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ControlsTable.Size = new System.Drawing.Size(150, 338);
      this.ControlsTable.TabIndex = 5;
      // 
      // ControlsPanel
      // 
      this.ControlsPanel.Controls.Add(this.IgnoreMetaDataBox);
      this.ControlsPanel.Controls.Add(this.MarkFilesWithDupes);
      this.ControlsPanel.Controls.Add(this.FindDupeNames);
      this.ControlsPanel.Controls.Add(this.FindDupesButton);
      this.ControlsPanel.Controls.Add(this.RegexFilterInput);
      this.ControlsPanel.Controls.Add(this.RegexInputLabel);
      this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ControlsPanel.Location = new System.Drawing.Point(3, 3);
      this.ControlsPanel.Name = "ControlsPanel";
      this.ControlsPanel.Size = new System.Drawing.Size(144, 163);
      this.ControlsPanel.TabIndex = 0;
      // 
      // IgnoreMetaDataBox
      // 
      this.IgnoreMetaDataBox.AutoSize = true;
      this.IgnoreMetaDataBox.Location = new System.Drawing.Point(3, 105);
      this.IgnoreMetaDataBox.Name = "IgnoreMetaDataBox";
      this.IgnoreMetaDataBox.Size = new System.Drawing.Size(109, 17);
      this.IgnoreMetaDataBox.TabIndex = 5;
      this.IgnoreMetaDataBox.Text = "Ignore Meta Data";
      this.IgnoreMetaDataBox.UseVisualStyleBackColor = true;
      // 
      // MarkFilesWithDupes
      // 
      this.MarkFilesWithDupes.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.MarkFilesWithDupes.Location = new System.Drawing.Point(0, 140);
      this.MarkFilesWithDupes.Name = "MarkFilesWithDupes";
      this.MarkFilesWithDupes.Size = new System.Drawing.Size(144, 23);
      this.MarkFilesWithDupes.TabIndex = 0;
      this.MarkFilesWithDupes.Text = "Mark Files With Dupes";
      this.MarkFilesWithDupes.UseVisualStyleBackColor = true;
      this.MarkFilesWithDupes.Click += new System.EventHandler(this.MarkFilesWithDupes_Click);
      // 
      // FindDupeNames
      // 
      this.FindDupeNames.Dock = System.Windows.Forms.DockStyle.Top;
      this.FindDupeNames.Location = new System.Drawing.Point(0, 62);
      this.FindDupeNames.Name = "FindDupeNames";
      this.FindDupeNames.Size = new System.Drawing.Size(144, 23);
      this.FindDupeNames.TabIndex = 4;
      this.FindDupeNames.Text = "Find Dupes By Name";
      this.FindDupeNames.UseVisualStyleBackColor = true;
      // 
      // FindDupesButton
      // 
      this.FindDupesButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.FindDupesButton.Location = new System.Drawing.Point(0, 39);
      this.FindDupesButton.Name = "FindDupesButton";
      this.FindDupesButton.Size = new System.Drawing.Size(144, 23);
      this.FindDupesButton.TabIndex = 3;
      this.FindDupesButton.Text = "Find Dupes";
      this.FindDupesButton.UseVisualStyleBackColor = true;
      this.FindDupesButton.Click += new System.EventHandler(this.FindDupesButton_Click);
      // 
      // RegexFilterInput
      // 
      this.RegexFilterInput.Dock = System.Windows.Forms.DockStyle.Top;
      this.RegexFilterInput.Location = new System.Drawing.Point(0, 19);
      this.RegexFilterInput.Name = "RegexFilterInput";
      this.RegexFilterInput.Size = new System.Drawing.Size(144, 20);
      this.RegexFilterInput.TabIndex = 1;
      // 
      // RegexInputLabel
      // 
      this.RegexInputLabel.AutoSize = true;
      this.RegexInputLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.RegexInputLabel.Location = new System.Drawing.Point(0, 0);
      this.RegexInputLabel.Name = "RegexInputLabel";
      this.RegexInputLabel.Padding = new System.Windows.Forms.Padding(3);
      this.RegexInputLabel.Size = new System.Drawing.Size(120, 19);
      this.RegexInputLabel.TabIndex = 2;
      this.RegexInputLabel.Text = "Filename Filter (Regex)";
      // 
      // Panel1
      // 
      this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel1.Location = new System.Drawing.Point(3, 172);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new System.Drawing.Size(144, 163);
      this.Panel1.TabIndex = 1;
      // 
      // MasterDirTextBox
      // 
      this.MasterDirTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MasterDirTextBox.Location = new System.Drawing.Point(3, 63);
      this.MasterDirTextBox.Name = "MasterDirTextBox";
      this.MasterDirTextBox.Size = new System.Drawing.Size(319, 20);
      this.MasterDirTextBox.TabIndex = 8;
      // 
      // TargetDirTextBox
      // 
      this.TargetDirTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TargetDirTextBox.Location = new System.Drawing.Point(328, 63);
      this.TargetDirTextBox.Name = "TargetDirTextBox";
      this.TargetDirTextBox.Size = new System.Drawing.Size(319, 20);
      this.TargetDirTextBox.TabIndex = 9;
      // 
      // Panel2
      // 
      this.Panel2.Controls.Add(this.SelectTargetDirButton);
      this.Panel2.Controls.Add(this.TableLayoutPanel4);
      this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel2.Location = new System.Drawing.Point(325, 0);
      this.Panel2.Margin = new System.Windows.Forms.Padding(0);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new System.Drawing.Size(325, 60);
      this.Panel2.TabIndex = 10;
      // 
      // SelectTargetDirButton
      // 
      this.SelectTargetDirButton.Dock = System.Windows.Forms.DockStyle.Left;
      this.SelectTargetDirButton.Location = new System.Drawing.Point(0, 0);
      this.SelectTargetDirButton.Name = "SelectTargetDirButton";
      this.SelectTargetDirButton.Size = new System.Drawing.Size(80, 60);
      this.SelectTargetDirButton.TabIndex = 7;
      this.SelectTargetDirButton.Text = "Select Target Directory";
      this.SelectTargetDirButton.UseVisualStyleBackColor = true;
      this.SelectTargetDirButton.Click += new System.EventHandler(this.SelectSearchDirButton_Click);
      // 
      // TableLayoutPanel4
      // 
      this.TableLayoutPanel4.ColumnCount = 1;
      this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel4.Controls.Add(this.DoRecursiveTarget, 0, 1);
      this.TableLayoutPanel4.Controls.Add(this.TargetIsSameAsMaster, 0, 0);
      this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
      this.TableLayoutPanel4.Location = new System.Drawing.Point(157, 0);
      this.TableLayoutPanel4.Name = "TableLayoutPanel4";
      this.TableLayoutPanel4.RowCount = 2;
      this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel4.Size = new System.Drawing.Size(168, 60);
      this.TableLayoutPanel4.TabIndex = 9;
      // 
      // DoRecursiveTarget
      // 
      this.DoRecursiveTarget.AutoSize = true;
      this.DoRecursiveTarget.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DoRecursiveTarget.Location = new System.Drawing.Point(3, 33);
      this.DoRecursiveTarget.Name = "DoRecursiveTarget";
      this.DoRecursiveTarget.Size = new System.Drawing.Size(162, 24);
      this.DoRecursiveTarget.TabIndex = 9;
      this.DoRecursiveTarget.Text = "Search recursively?";
      this.DoRecursiveTarget.UseVisualStyleBackColor = true;
      // 
      // TargetIsSameAsMaster
      // 
      this.TargetIsSameAsMaster.AutoSize = true;
      this.TargetIsSameAsMaster.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TargetIsSameAsMaster.Location = new System.Drawing.Point(3, 3);
      this.TargetIsSameAsMaster.Name = "TargetIsSameAsMaster";
      this.TargetIsSameAsMaster.Size = new System.Drawing.Size(162, 24);
      this.TargetIsSameAsMaster.TabIndex = 8;
      this.TargetIsSameAsMaster.Text = "Same as master directory?";
      this.TargetIsSameAsMaster.UseVisualStyleBackColor = true;
      // 
      // TableLayoutPanel3
      // 
      this.TableLayoutPanel3.ColumnCount = 2;
      this.TableLayoutPanel1.SetColumnSpan(this.TableLayoutPanel3, 2);
      this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TableLayoutPanel3.Controls.Add(this.TargetFilesView, 1, 0);
      this.TableLayoutPanel3.Controls.Add(this.MasterFilesView, 0, 0);
      this.TableLayoutPanel3.Controls.Add(this.MediaViewer1, 0, 1);
      this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel3.Location = new System.Drawing.Point(3, 93);
      this.TableLayoutPanel3.Name = "TableLayoutPanel3";
      this.TableLayoutPanel3.RowCount = 2;
      this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
      this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel3.Size = new System.Drawing.Size(644, 332);
      this.TableLayoutPanel3.TabIndex = 1;
      // 
      // TargetFilesView
      // 
      this.TargetFilesView.CheckBoxes = true;
      this.TargetFilesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3});
      this.TargetFilesView.ContextMenuStrip = this.FileRightClickContextMenu;
      this.TargetFilesView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TargetFilesView.HideSelection = false;
      this.TargetFilesView.Location = new System.Drawing.Point(325, 3);
      this.TargetFilesView.Name = "TargetFilesView";
      this.TargetFilesView.Size = new System.Drawing.Size(316, 164);
      this.TargetFilesView.TabIndex = 2;
      this.TargetFilesView.UseCompatibleStateImageBehavior = false;
      this.TargetFilesView.View = System.Windows.Forms.View.Details;
      this.TargetFilesView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TargetFilesView_ColumnClick);
      this.TargetFilesView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.TargetFilesView_SelectedIndexChanged);
      this.TargetFilesView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TargetFilesView_KeyDown);
      this.TargetFilesView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TargetFilesView_MouseDown);
      // 
      // ColumnHeader1
      // 
      this.ColumnHeader1.Text = "Filename";
      this.ColumnHeader1.Width = 191;
      // 
      // ColumnHeader2
      // 
      this.ColumnHeader2.Text = "Hash";
      // 
      // ColumnHeader3
      // 
      this.ColumnHeader3.Text = "Keeping?";
      // 
      // FileRightClickContextMenu
      // 
      this.FileRightClickContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeepToolStripMenuItem,
            this.DontKeepToolStripMenuItem,
            this.ClearStatusMenuItem});
      this.FileRightClickContextMenu.Name = "ContextMenuStrip1";
      this.FileRightClickContextMenu.Size = new System.Drawing.Size(166, 70);
      // 
      // KeepToolStripMenuItem
      // 
      this.KeepToolStripMenuItem.Name = "KeepToolStripMenuItem";
      this.KeepToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.KeepToolStripMenuItem.Text = "Mark As Keep";
      this.KeepToolStripMenuItem.Click += new System.EventHandler(this.KeepToolStripMenuItem_Click);
      // 
      // DontKeepToolStripMenuItem
      // 
      this.DontKeepToolStripMenuItem.Name = "DontKeepToolStripMenuItem";
      this.DontKeepToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.DontKeepToolStripMenuItem.Text = "Mark As Discard";
      this.DontKeepToolStripMenuItem.Click += new System.EventHandler(this.DontKeepToolStripMenuItem_Click);
      // 
      // ClearStatusMenuItem
      // 
      this.ClearStatusMenuItem.Name = "ClearStatusMenuItem";
      this.ClearStatusMenuItem.Size = new System.Drawing.Size(165, 22);
      this.ClearStatusMenuItem.Text = "Clear Keep Status";
      this.ClearStatusMenuItem.Click += new System.EventHandler(this.ClearStatusMenuItem_Click);
      // 
      // MasterFilesView
      // 
      this.MasterFilesView.CheckBoxes = true;
      this.MasterFilesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilenameHeader,
            this.HashHeader,
            this.KeepStatus});
      this.MasterFilesView.ContextMenuStrip = this.FileRightClickContextMenu;
      this.MasterFilesView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MasterFilesView.HideSelection = false;
      this.MasterFilesView.Location = new System.Drawing.Point(3, 3);
      this.MasterFilesView.Name = "MasterFilesView";
      this.MasterFilesView.Size = new System.Drawing.Size(316, 164);
      this.MasterFilesView.TabIndex = 0;
      this.MasterFilesView.UseCompatibleStateImageBehavior = false;
      this.MasterFilesView.View = System.Windows.Forms.View.Details;
      this.MasterFilesView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MasterFilesView_ColumnClick);
      this.MasterFilesView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.MasterFilesView_SelectedIndexChanged);
      this.MasterFilesView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterFilesView_KeyDown);
      this.MasterFilesView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MasterFilesView_MouseDown);
      // 
      // FilenameHeader
      // 
      this.FilenameHeader.Text = "Filename";
      this.FilenameHeader.Width = 191;
      // 
      // HashHeader
      // 
      this.HashHeader.Text = "Hash";
      // 
      // KeepStatus
      // 
      this.KeepStatus.Text = "Keeping?";
      // 
      // MediaViewer1
      // 
      this.TableLayoutPanel3.SetColumnSpan(this.MediaViewer1, 2);
      this.MediaViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MediaViewer1.Location = new System.Drawing.Point(3, 173);
      this.MediaViewer1.Name = "MediaViewer1";
      this.MediaViewer1.Size = new System.Drawing.Size(638, 156);
      this.MediaViewer1.TabIndex = 3;
      // 
      // Panel3
      // 
      this.Panel3.Controls.Add(this.DoRecursiveMaster);
      this.Panel3.Controls.Add(this.ExecuteMasterDupes);
      this.Panel3.Controls.Add(this.SelectMasterDirButton);
      this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel3.Location = new System.Drawing.Point(0, 0);
      this.Panel3.Margin = new System.Windows.Forms.Padding(0);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new System.Drawing.Size(325, 60);
      this.Panel3.TabIndex = 11;
      // 
      // DoRecursiveMaster
      // 
      this.DoRecursiveMaster.AutoSize = true;
      this.DoRecursiveMaster.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DoRecursiveMaster.Location = new System.Drawing.Point(80, 23);
      this.DoRecursiveMaster.Name = "DoRecursiveMaster";
      this.DoRecursiveMaster.Size = new System.Drawing.Size(245, 37);
      this.DoRecursiveMaster.TabIndex = 10;
      this.DoRecursiveMaster.Text = "Search recursively?";
      this.DoRecursiveMaster.UseVisualStyleBackColor = true;
      // 
      // ExecuteMasterDupes
      // 
      this.ExecuteMasterDupes.Dock = System.Windows.Forms.DockStyle.Top;
      this.ExecuteMasterDupes.Location = new System.Drawing.Point(80, 0);
      this.ExecuteMasterDupes.Name = "ExecuteMasterDupes";
      this.ExecuteMasterDupes.Size = new System.Drawing.Size(245, 23);
      this.ExecuteMasterDupes.TabIndex = 7;
      this.ExecuteMasterDupes.Text = "Execute Master Dir Decimation";
      this.ExecuteMasterDupes.UseVisualStyleBackColor = true;
      this.ExecuteMasterDupes.Click += new System.EventHandler(this.ExecuteMasterDupes_Click);
      // 
      // SelectMasterDirButton
      // 
      this.SelectMasterDirButton.Dock = System.Windows.Forms.DockStyle.Left;
      this.SelectMasterDirButton.Location = new System.Drawing.Point(0, 0);
      this.SelectMasterDirButton.Name = "SelectMasterDirButton";
      this.SelectMasterDirButton.Size = new System.Drawing.Size(80, 60);
      this.SelectMasterDirButton.TabIndex = 6;
      this.SelectMasterDirButton.Text = "Select Master Directory";
      this.SelectMasterDirButton.UseVisualStyleBackColor = true;
      this.SelectMasterDirButton.Click += new System.EventHandler(this.SelectMasterDirButton_Click);
      // 
      // TypeSelector1
      // 
      this.TypeSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TypeSelector1.Location = new System.Drawing.Point(653, 3);
      this.TypeSelector1.Name = "TypeSelector1";
      this.TableLayoutPanel1.SetRowSpan(this.TypeSelector1, 2);
      this.TypeSelector1.Size = new System.Drawing.Size(144, 84);
      this.TypeSelector1.TabIndex = 12;
      // 
      // StatusStrip1
      // 
      this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.StatusLabel});
      this.StatusStrip1.Location = new System.Drawing.Point(0, 428);
      this.StatusStrip1.Name = "StatusStrip1";
      this.StatusStrip1.Size = new System.Drawing.Size(800, 22);
      this.StatusStrip1.TabIndex = 1;
      this.StatusStrip1.Text = "StatusStrip1";
      // 
      // ToolStripProgressBar
      // 
      this.ToolStripProgressBar.Name = "ToolStripProgressBar";
      this.ToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
      // 
      // StatusLabel
      // 
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(120, 17);
      this.StatusLabel.Text = "ToolStripStatusLabel1";
      // 
      // DupeChecker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.TableLayoutPanel1);
      this.Controls.Add(this.StatusStrip1);
      this.Name = "DupeChecker";
      this.Text = "CheckDupes";
      this.Load += new System.EventHandler(this.DupeChecker_Load);
      this.SizeChanged += new System.EventHandler(this.DupeChecker_SizeChanged);
      this.TableLayoutPanel1.ResumeLayout(false);
      this.TableLayoutPanel1.PerformLayout();
      this.ControlsTable.ResumeLayout(false);
      this.ControlsPanel.ResumeLayout(false);
      this.ControlsPanel.PerformLayout();
      this.Panel2.ResumeLayout(false);
      this.TableLayoutPanel4.ResumeLayout(false);
      this.TableLayoutPanel4.PerformLayout();
      this.TableLayoutPanel3.ResumeLayout(false);
      this.FileRightClickContextMenu.ResumeLayout(false);
      this.Panel3.ResumeLayout(false);
      this.Panel3.PerformLayout();
      this.StatusStrip1.ResumeLayout(false);
      this.StatusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    internal TableLayoutPanel TableLayoutPanel1;
    internal StatusStrip StatusStrip1;
    internal ToolStripProgressBar ToolStripProgressBar;
    internal ToolStripStatusLabel StatusLabel;
    internal TableLayoutPanel ControlsTable;
    internal Panel ControlsPanel;
    internal Button FindDupeNames;
    internal Button FindDupesButton;
    internal TextBox RegexFilterInput;
    internal Label RegexInputLabel;
    internal Button MarkFilesWithDupes;
    internal Button SelectTargetDirButton;
    internal Button SelectMasterDirButton;
    internal TextBox MasterDirTextBox;
    internal TextBox TargetDirTextBox;
    internal CheckBox TargetIsSameAsMaster;
    internal ListView MasterFilesView;
    internal TableLayoutPanel TableLayoutPanel3;
    internal ListView TargetFilesView;
    internal ColumnHeader ColumnHeader1;
    internal ColumnHeader ColumnHeader2;
    internal System.DirectoryServices.DirectoryEntry DirectoryEntry1;
    internal TableLayoutPanel TableLayoutPanel4;
    internal Panel Panel1;
    internal Panel Panel2;
    internal CheckBox DoRecursiveTarget;
    internal ColumnHeader FilenameHeader;
    internal ColumnHeader HashHeader;
    internal MediaViewer MediaViewer1;
    internal ColumnHeader KeepStatus;
    internal ContextMenuStrip FileRightClickContextMenu;
    internal ToolStripMenuItem KeepToolStripMenuItem;
    internal Panel Panel3;
    internal Button ExecuteMasterDupes;
    internal TypeSelector TypeSelector1;
    internal CheckBox DoRecursiveMaster;
    internal ToolStripMenuItem ClearStatusMenuItem;
    internal ColumnHeader ColumnHeader3;
    internal ToolStripMenuItem DontKeepToolStripMenuItem;
    internal CheckBox IgnoreMetaDataBox;
  }
}