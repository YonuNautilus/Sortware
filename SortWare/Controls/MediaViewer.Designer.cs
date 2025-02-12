using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SortWare
{
  [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
  public partial class MediaViewer : UserControl
  {

    // UserControl overrides dispose to clean up the component list.
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
      this.PictureBox1 = new System.Windows.Forms.PictureBox();
      this.MediaPanel = new System.Windows.Forms.TableLayoutPanel();
      this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.ImagePreview = new System.Windows.Forms.PictureBox();
      this.VideoPlayerPanel = new System.Windows.Forms.TableLayoutPanel();
      this.VideoHolderPanel = new System.Windows.Forms.Panel();
      this.VlcControl1 = new LibVLCSharp.WinForms.VideoView();
      this._VideoScrollBar = new System.Windows.Forms.HScrollBar();
      this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.autoPlay = new System.Windows.Forms.CheckBox();
      this.PauseButton = new System.Windows.Forms.Button();
      this.PlayButton = new System.Windows.Forms.Button();
      this.TimeLabel = new System.Windows.Forms.Label();
      this.NormalTimer = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.ImageCheckBox = new System.Windows.Forms.CheckBox();
      this.RemoveImageBtn = new System.Windows.Forms.Button();
      this.ClearAllMediaBtn = new System.Windows.Forms.Button();
      this.VideoCheckBox = new System.Windows.Forms.CheckBox();
      this.ClearVideoBtn = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
      this.MediaPanel.SuspendLayout();
      this.ContextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
      this.VideoPlayerPanel.SuspendLayout();
      this.VideoHolderPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.VlcControl1)).BeginInit();
      this.TableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // PictureBox1
      // 
      this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PictureBox1.Location = new System.Drawing.Point(0, 0);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new System.Drawing.Size(706, 376);
      this.PictureBox1.TabIndex = 0;
      this.PictureBox1.TabStop = false;
      // 
      // MediaPanel
      // 
      this.MediaPanel.ColumnCount = 2;
      this.MediaPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.MediaPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.MediaPanel.ContextMenuStrip = this.ContextMenuStrip1;
      this.MediaPanel.Controls.Add(this.ImagePreview, 0, 1);
      this.MediaPanel.Controls.Add(this.VideoPlayerPanel, 1, 1);
      this.MediaPanel.Controls.Add(this.tableLayoutPanel2, 0, 0);
      this.MediaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MediaPanel.Location = new System.Drawing.Point(0, 0);
      this.MediaPanel.Margin = new System.Windows.Forms.Padding(0);
      this.MediaPanel.Name = "MediaPanel";
      this.MediaPanel.RowCount = 2;
      this.MediaPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.MediaPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MediaPanel.Size = new System.Drawing.Size(706, 376);
      this.MediaPanel.TabIndex = 3;
      // 
      // ContextMenuStrip1
      // 
      this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ToolStripMenuItem2,
            this.ToolStripMenuItem3});
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new System.Drawing.Size(154, 70);
      // 
      // ToolStripMenuItem1
      // 
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
      this.ToolStripMenuItem1.Text = "Remove Image";
      this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
      // 
      // ToolStripMenuItem2
      // 
      this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      this.ToolStripMenuItem2.Size = new System.Drawing.Size(153, 22);
      this.ToolStripMenuItem2.Text = "Remove Video";
      this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
      // 
      // ToolStripMenuItem3
      // 
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new System.Drawing.Size(153, 22);
      this.ToolStripMenuItem3.Text = "Remove Media";
      this.ToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
      // 
      // ImagePreview
      // 
      this.ImagePreview.BackColor = System.Drawing.Color.Transparent;
      this.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ImagePreview.Location = new System.Drawing.Point(0, 25);
      this.ImagePreview.Margin = new System.Windows.Forms.Padding(0);
      this.ImagePreview.Name = "ImagePreview";
      this.ImagePreview.Size = new System.Drawing.Size(353, 351);
      this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.ImagePreview.TabIndex = 1;
      this.ImagePreview.TabStop = false;
      // 
      // VideoPlayerPanel
      // 
      this.VideoPlayerPanel.ColumnCount = 1;
      this.VideoPlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.VideoPlayerPanel.Controls.Add(this.VideoHolderPanel, 0, 0);
      this.VideoPlayerPanel.Controls.Add(this._VideoScrollBar, 0, 1);
      this.VideoPlayerPanel.Controls.Add(this.TableLayoutPanel1, 0, 2);
      this.VideoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.VideoPlayerPanel.Location = new System.Drawing.Point(353, 25);
      this.VideoPlayerPanel.Margin = new System.Windows.Forms.Padding(0);
      this.VideoPlayerPanel.Name = "VideoPlayerPanel";
      this.VideoPlayerPanel.RowCount = 3;
      this.VideoPlayerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.VideoPlayerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.VideoPlayerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.VideoPlayerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.VideoPlayerPanel.Size = new System.Drawing.Size(353, 351);
      this.VideoPlayerPanel.TabIndex = 0;
      // 
      // VideoHolderPanel
      // 
      this.VideoHolderPanel.Controls.Add(this.VlcControl1);
      this.VideoHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.VideoHolderPanel.Location = new System.Drawing.Point(0, 0);
      this.VideoHolderPanel.Margin = new System.Windows.Forms.Padding(0);
      this.VideoHolderPanel.Name = "VideoHolderPanel";
      this.VideoHolderPanel.Size = new System.Drawing.Size(353, 301);
      this.VideoHolderPanel.TabIndex = 11;
      // 
      // VlcControl1
      // 
      this.VlcControl1.BackColor = System.Drawing.Color.Black;
      this.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.VlcControl1.Location = new System.Drawing.Point(0, 0);
      this.VlcControl1.MediaPlayer = null;
      this.VlcControl1.Name = "VlcControl1";
      this.VlcControl1.Size = new System.Drawing.Size(353, 301);
      this.VlcControl1.TabIndex = 3;
      // 
      // _VideoScrollBar
      // 
      this._VideoScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
      this._VideoScrollBar.LargeChange = 50;
      this._VideoScrollBar.Location = new System.Drawing.Point(0, 301);
      this._VideoScrollBar.Maximum = 1000;
      this._VideoScrollBar.Name = "_VideoScrollBar";
      this._VideoScrollBar.Size = new System.Drawing.Size(353, 20);
      this._VideoScrollBar.SmallChange = 5;
      this._VideoScrollBar.TabIndex = 5;
      this._VideoScrollBar.Click += new System.EventHandler(this.test);
      this._VideoScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VideoScrollBar_Scroll);
      // 
      // TableLayoutPanel1
      // 
      this.TableLayoutPanel1.ColumnCount = 5;
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.TableLayoutPanel1.Controls.Add(this.autoPlay, 2, 0);
      this.TableLayoutPanel1.Controls.Add(this.PauseButton, 0, 0);
      this.TableLayoutPanel1.Controls.Add(this.PlayButton, 1, 0);
      this.TableLayoutPanel1.Controls.Add(this.TimeLabel, 4, 0);
      this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 321);
      this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 1;
      this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayoutPanel1.Size = new System.Drawing.Size(353, 30);
      this.TableLayoutPanel1.TabIndex = 14;
      // 
      // autoPlay
      // 
      this.autoPlay.AutoSize = true;
      this.autoPlay.Checked = true;
      this.autoPlay.CheckState = System.Windows.Forms.CheckState.Checked;
      this.autoPlay.Dock = System.Windows.Forms.DockStyle.Fill;
      this.autoPlay.Location = new System.Drawing.Point(63, 3);
      this.autoPlay.Name = "autoPlay";
      this.autoPlay.Size = new System.Drawing.Size(97, 24);
      this.autoPlay.TabIndex = 5;
      this.autoPlay.Text = "Autoplay Video";
      this.autoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.autoPlay.UseVisualStyleBackColor = true;
      // 
      // PauseButton
      // 
      this.PauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PauseButton.FlatAppearance.BorderSize = 0;
      this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.PauseButton.Location = new System.Drawing.Point(0, 0);
      this.PauseButton.Margin = new System.Windows.Forms.Padding(0);
      this.PauseButton.Name = "PauseButton";
      this.PauseButton.Size = new System.Drawing.Size(30, 30);
      this.PauseButton.TabIndex = 0;
      this.PauseButton.Text = "⏸";
      this.PauseButton.UseVisualStyleBackColor = true;
      this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
      // 
      // PlayButton
      // 
      this.PlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PlayButton.Location = new System.Drawing.Point(30, 0);
      this.PlayButton.Margin = new System.Windows.Forms.Padding(0);
      this.PlayButton.Name = "PlayButton";
      this.PlayButton.Size = new System.Drawing.Size(30, 30);
      this.PlayButton.TabIndex = 1;
      this.PlayButton.Text = "▶";
      this.PlayButton.UseVisualStyleBackColor = true;
      this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
      // 
      // TimeLabel
      // 
      this.TimeLabel.AutoSize = true;
      this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TimeLabel.Location = new System.Drawing.Point(289, 0);
      this.TimeLabel.Margin = new System.Windows.Forms.Padding(0);
      this.TimeLabel.Name = "TimeLabel";
      this.TimeLabel.Size = new System.Drawing.Size(64, 30);
      this.TimeLabel.TabIndex = 2;
      this.TimeLabel.Text = "0:00:00.000\r\n0:00:00.000";
      this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.TimeLabel.Click += new System.EventHandler(this.TimeLabel_Click);
      // 
      // NormalTimer
      // 
      this.NormalTimer.Enabled = true;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 5;
      this.MediaPanel.SetColumnSpan(this.tableLayoutPanel2, 2);
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.Controls.Add(this.ImageCheckBox, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.RemoveImageBtn, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.ClearAllMediaBtn, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.VideoCheckBox, 4, 0);
      this.tableLayoutPanel2.Controls.Add(this.ClearVideoBtn, 3, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 25);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(706, 25);
      this.tableLayoutPanel2.TabIndex = 2;
      // 
      // ImageCheckBox
      // 
      this.ImageCheckBox.AutoSize = true;
      this.ImageCheckBox.Checked = true;
      this.ImageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ImageCheckBox.Location = new System.Drawing.Point(3, 3);
      this.ImageCheckBox.Name = "ImageCheckBox";
      this.ImageCheckBox.Size = new System.Drawing.Size(96, 17);
      this.ImageCheckBox.TabIndex = 0;
      this.ImageCheckBox.Text = "Enable Images";
      this.ImageCheckBox.UseVisualStyleBackColor = true;
      this.ImageCheckBox.CheckedChanged += new System.EventHandler(this.ImageCheckBox_CheckedChanged);
      // 
      // RemoveImageBtn
      // 
      this.RemoveImageBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RemoveImageBtn.Location = new System.Drawing.Point(144, 3);
      this.RemoveImageBtn.Name = "RemoveImageBtn";
      this.RemoveImageBtn.Size = new System.Drawing.Size(135, 19);
      this.RemoveImageBtn.TabIndex = 2;
      this.RemoveImageBtn.Text = "Clear Image";
      this.RemoveImageBtn.UseVisualStyleBackColor = true;
      this.RemoveImageBtn.Click += new System.EventHandler(this.RemoveImageBtn_Click);
      // 
      // ClearAllMediaBtn
      // 
      this.ClearAllMediaBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClearAllMediaBtn.Location = new System.Drawing.Point(285, 3);
      this.ClearAllMediaBtn.Name = "ClearAllMediaBtn";
      this.ClearAllMediaBtn.Size = new System.Drawing.Size(135, 19);
      this.ClearAllMediaBtn.TabIndex = 3;
      this.ClearAllMediaBtn.Text = "Clear All Media";
      this.ClearAllMediaBtn.UseVisualStyleBackColor = true;
      this.ClearAllMediaBtn.Click += new System.EventHandler(this.ClearAllMediaBtn_Click);
      // 
      // VideoCheckBox
      // 
      this.VideoCheckBox.AutoSize = true;
      this.VideoCheckBox.Checked = true;
      this.VideoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.VideoCheckBox.Location = new System.Drawing.Point(567, 3);
      this.VideoCheckBox.Name = "VideoCheckBox";
      this.VideoCheckBox.Size = new System.Drawing.Size(89, 17);
      this.VideoCheckBox.TabIndex = 4;
      this.VideoCheckBox.Text = "Enable Video";
      this.VideoCheckBox.UseVisualStyleBackColor = true;
      this.VideoCheckBox.CheckedChanged += new System.EventHandler(this.VideoCheckBox_CheckedChanged);
      // 
      // ClearVideoBtn
      // 
      this.ClearVideoBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClearVideoBtn.Location = new System.Drawing.Point(426, 3);
      this.ClearVideoBtn.Name = "ClearVideoBtn";
      this.ClearVideoBtn.Size = new System.Drawing.Size(135, 19);
      this.ClearVideoBtn.TabIndex = 5;
      this.ClearVideoBtn.Text = "Clear Video";
      this.ClearVideoBtn.UseVisualStyleBackColor = true;
      this.ClearVideoBtn.Click += new System.EventHandler(this.ClearVideoBtn_Click);
      // 
      // MediaViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ContextMenuStrip = this.ContextMenuStrip1;
      this.Controls.Add(this.MediaPanel);
      this.Controls.Add(this.PictureBox1);
      this.Name = "MediaViewer";
      this.Size = new System.Drawing.Size(706, 376);
      this.Load += new System.EventHandler(this.MediaViewer_Load);
      this.Disposed += new System.EventHandler(this.MediaViewer_Disposing);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
      this.MediaPanel.ResumeLayout(false);
      this.ContextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
      this.VideoPlayerPanel.ResumeLayout(false);
      this.VideoHolderPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.VlcControl1)).EndInit();
      this.TableLayoutPanel1.ResumeLayout(false);
      this.TableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);

    }

    internal PictureBox PictureBox1;
    internal TableLayoutPanel MediaPanel;
    internal PictureBox ImagePreview;
    internal TableLayoutPanel VideoPlayerPanel;
    internal Panel VideoHolderPanel;

    private HScrollBar _VideoScrollBar;

    public virtual HScrollBar VideoScrollBar
    {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get
      {
        return _VideoScrollBar;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set
      {
        if (_VideoScrollBar != null)
        {
          _VideoScrollBar.Click -= test;
          _VideoScrollBar.Scroll -= VideoScrollBar_Scroll;
        }

        _VideoScrollBar = value;
        if (_VideoScrollBar != null)
        {
          _VideoScrollBar.Click += test;
          _VideoScrollBar.Scroll += VideoScrollBar_Scroll;
        }
      }
    }
    internal ContextMenuStrip ContextMenuStrip1;
    internal ToolStripMenuItem ToolStripMenuItem1;
    internal ToolStripMenuItem ToolStripMenuItem2;
    internal ToolStripMenuItem ToolStripMenuItem3;
    internal TableLayoutPanel TableLayoutPanel1;
    internal Button PauseButton;
    internal Button PlayButton;
    internal Label TimeLabel;
    internal Timer NormalTimer;
    internal CheckBox autoPlay;
    private LibVLCSharp.WinForms.VideoView VlcControl1;
    private TableLayoutPanel tableLayoutPanel2;
    private CheckBox ImageCheckBox;
    private Button RemoveImageBtn;
    private Button ClearAllMediaBtn;
    private CheckBox VideoCheckBox;
    private Button ClearVideoBtn;
  }
}