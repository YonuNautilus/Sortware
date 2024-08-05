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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaViewer));
            PictureBox1 = new PictureBox();
            MediaPanel = new TableLayoutPanel();
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            ToolStripMenuItem2 = new ToolStripMenuItem();
            ToolStripMenuItem2.Click += new EventHandler(ToolStripMenuItem2_Click);
            ToolStripMenuItem3 = new ToolStripMenuItem();
            ToolStripMenuItem3.Click += new EventHandler(ToolStripMenuItem3_Click);
            ImagePreview = new PictureBox();
            VideoPlayerPanel = new TableLayoutPanel();
            VideoHolderPanel = new Panel();
            _VlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            _VlcControl1.LengthChanged += new EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs>(VlcControl1_LengthChanged);
            _VlcControl1.MediaChanged += new EventHandler<Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs>(VlcControl1_MediaChanged);
            _VlcControl1.EndReached += new EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs>(Timer1_Tick);
            _VlcControl1.Playing += new EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(VlcControl1_MediaPlaying);
            _VideoScrollBar = new HScrollBar();
            _VideoScrollBar.Click += new EventHandler(test);
            _VideoScrollBar.Scroll += new ScrollEventHandler(VideoScrollBar_Scroll);
            TableLayoutPanel1 = new TableLayoutPanel();
            autoPlay = new CheckBox();
            PauseButton = new Button();
            PauseButton.Click += new EventHandler(PauseButton_Click);
            PlayButton = new Button();
            PlayButton.Click += new EventHandler(PlayButton_Click);
            TimeLabel = new Label();
            TimeLabel.Click += new EventHandler(TimeLabel_Click);
            NormalTimer = new Timer(components);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            MediaPanel.SuspendLayout();
            ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImagePreview).BeginInit();
            VideoPlayerPanel.SuspendLayout();
            VideoHolderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_VlcControl1).BeginInit();
            TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.Dock = DockStyle.Fill;
            PictureBox1.Location = new Point(0, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(706, 376);
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // MediaPanel
            // 
            MediaPanel.ColumnCount = 2;
            MediaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            MediaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            MediaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0f));
            MediaPanel.ContextMenuStrip = ContextMenuStrip1;
            MediaPanel.Controls.Add(ImagePreview, 0, 0);
            MediaPanel.Controls.Add(VideoPlayerPanel, 1, 0);
            MediaPanel.Dock = DockStyle.Fill;
            MediaPanel.Location = new Point(0, 0);
            MediaPanel.Margin = new Padding(0);
            MediaPanel.Name = "MediaPanel";
            MediaPanel.RowCount = 1;
            MediaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            MediaPanel.Size = new Size(706, 376);
            MediaPanel.TabIndex = 3;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3 });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size(154, 70);
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size(153, 22);
            ToolStripMenuItem1.Text = "Remove Image";
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size(153, 22);
            ToolStripMenuItem2.Text = "Remove Video";
            // 
            // ToolStripMenuItem3
            // 
            ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            ToolStripMenuItem3.Size = new Size(153, 22);
            ToolStripMenuItem3.Text = "Remove Media";
            // 
            // ImagePreview
            // 
            ImagePreview.BackColor = Color.Transparent;
            ImagePreview.Dock = DockStyle.Fill;
            ImagePreview.Location = new Point(0, 0);
            ImagePreview.Margin = new Padding(0);
            ImagePreview.Name = "ImagePreview";
            ImagePreview.Size = new Size(353, 376);
            ImagePreview.SizeMode = PictureBoxSizeMode.Zoom;
            ImagePreview.TabIndex = 1;
            ImagePreview.TabStop = false;
            // 
            // VideoPlayerPanel
            // 
            VideoPlayerPanel.ColumnCount = 1;
            VideoPlayerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            VideoPlayerPanel.Controls.Add(VideoHolderPanel, 0, 0);
            VideoPlayerPanel.Controls.Add(_VideoScrollBar, 0, 1);
            VideoPlayerPanel.Controls.Add(TableLayoutPanel1, 0, 2);
            VideoPlayerPanel.Dock = DockStyle.Fill;
            VideoPlayerPanel.Location = new Point(353, 0);
            VideoPlayerPanel.Margin = new Padding(0);
            VideoPlayerPanel.Name = "VideoPlayerPanel";
            VideoPlayerPanel.RowCount = 3;
            VideoPlayerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            VideoPlayerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            VideoPlayerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.0f));
            VideoPlayerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            VideoPlayerPanel.Size = new Size(353, 376);
            VideoPlayerPanel.TabIndex = 0;
            // 
            // VideoHolderPanel
            // 
            VideoHolderPanel.Controls.Add(_VlcControl1);
            VideoHolderPanel.Dock = DockStyle.Fill;
            VideoHolderPanel.Location = new Point(0, 0);
            VideoHolderPanel.Margin = new Padding(0);
            VideoHolderPanel.Name = "VideoHolderPanel";
            VideoHolderPanel.Size = new Size(353, 326);
            VideoHolderPanel.TabIndex = 11;
            // 
            // VlcControl1
            // 
            _VlcControl1.BackColor = Color.Black;
            _VlcControl1.ContextMenuStrip = ContextMenuStrip1;
            _VlcControl1.Dock = DockStyle.Fill;
            _VlcControl1.Location = new Point(0, 0);
            _VlcControl1.Margin = new Padding(0);
            _VlcControl1.Name = "_VlcControl1";
            _VlcControl1.Size = new Size(353, 326);
            _VlcControl1.Spu = -1;
            _VlcControl1.TabIndex = 2;
            _VlcControl1.Text = "VlcControl1";
            _VlcControl1.VlcLibDirectory = (System.IO.DirectoryInfo)resources.GetObject("VlcControl1.VlcLibDirectory");
            _VlcControl1.VlcMediaplayerOptions = null;
            // 
            // VideoScrollBar
            // 
            _VideoScrollBar.Dock = DockStyle.Fill;
            _VideoScrollBar.LargeChange = 50;
            _VideoScrollBar.Location = new Point(0, 326);
            _VideoScrollBar.Maximum = 1000;
            _VideoScrollBar.Name = "_VideoScrollBar";
            _VideoScrollBar.Size = new Size(353, 20);
            _VideoScrollBar.SmallChange = 5;
            _VideoScrollBar.TabIndex = 5;
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 5;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            TableLayoutPanel1.Controls.Add(autoPlay, 2, 0);
            TableLayoutPanel1.Controls.Add(PauseButton, 0, 0);
            TableLayoutPanel1.Controls.Add(PlayButton, 1, 0);
            TableLayoutPanel1.Controls.Add(TimeLabel, 4, 0);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 346);
            TableLayoutPanel1.Margin = new Padding(0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Size = new Size(353, 30);
            TableLayoutPanel1.TabIndex = 14;
            // 
            // autoPlay
            // 
            autoPlay.AutoSize = true;
            autoPlay.Checked = true;
            autoPlay.CheckState = CheckState.Checked;
            autoPlay.Dock = DockStyle.Fill;
            autoPlay.Location = new Point(63, 3);
            autoPlay.Name = "autoPlay";
            autoPlay.Size = new Size(97, 24);
            autoPlay.TabIndex = 5;
            autoPlay.Text = "Autoplay Video";
            autoPlay.TextAlign = ContentAlignment.MiddleCenter;
            autoPlay.UseVisualStyleBackColor = true;
            // 
            // PauseButton
            // 
            PauseButton.Dock = DockStyle.Fill;
            PauseButton.FlatAppearance.BorderSize = 0;
            PauseButton.Font = new Font("Microsoft Sans Serif", 8.25f);
            PauseButton.Location = new Point(0, 0);
            PauseButton.Margin = new Padding(0);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(30, 30);
            PauseButton.TabIndex = 0;
            PauseButton.Text = "⏸";
            PauseButton.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            PlayButton.Dock = DockStyle.Fill;
            PlayButton.Location = new Point(30, 0);
            PlayButton.Margin = new Padding(0);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(30, 30);
            PlayButton.TabIndex = 1;
            PlayButton.Text = "▶";
            PlayButton.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Dock = DockStyle.Fill;
            TimeLabel.Location = new Point(289, 0);
            TimeLabel.Margin = new Padding(0);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(64, 30);
            TimeLabel.TabIndex = 2;
            TimeLabel.Text = "0:00:00.000" + '\r' + '\n' + "0:00:00.000";
            TimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NormalTimer
            // 
            NormalTimer.Enabled = true;
            // 
            // MediaViewer
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = ContextMenuStrip1;
            Controls.Add(MediaPanel);
            Controls.Add(PictureBox1);
            Name = "MediaViewer";
            Size = new Size(706, 376);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            MediaPanel.ResumeLayout(false);
            ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ImagePreview).EndInit();
            VideoPlayerPanel.ResumeLayout(false);
            VideoHolderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_VlcControl1).EndInit();
            TableLayoutPanel1.ResumeLayout(false);
            TableLayoutPanel1.PerformLayout();
            Load += new EventHandler(MediaViewer_Load);
            ResumeLayout(false);

        }

        internal PictureBox PictureBox1;
        internal TableLayoutPanel MediaPanel;
        internal PictureBox ImagePreview;
        internal TableLayoutPanel VideoPlayerPanel;
        internal Panel VideoHolderPanel;
        private Vlc.DotNet.Forms.VlcControl _VlcControl1;

        public virtual Vlc.DotNet.Forms.VlcControl VlcControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _VlcControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_VlcControl1 != null)
                {
                    _VlcControl1.LengthChanged -= VlcControl1_LengthChanged;
                    _VlcControl1.MediaChanged -= VlcControl1_MediaChanged;
                    _VlcControl1.EndReached -= Timer1_Tick;
                    _VlcControl1.Playing -= VlcControl1_MediaPlaying;
                }

                _VlcControl1 = value;
                if (_VlcControl1 != null)
                {
                    _VlcControl1.LengthChanged += VlcControl1_LengthChanged;
                    _VlcControl1.MediaChanged += VlcControl1_MediaChanged;
                    _VlcControl1.EndReached += Timer1_Tick;
                    _VlcControl1.Playing += VlcControl1_MediaPlaying;
                }
            }
        }
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
    }
}