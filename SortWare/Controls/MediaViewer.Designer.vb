<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MediaViewer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaViewer))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MediaPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImagePreview = New System.Windows.Forms.PictureBox()
        Me.VideoPlayerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.VideoHolderPanel = New System.Windows.Forms.Panel()
        Me.VlcControl1 = New Vlc.DotNet.Forms.VlcControl()
        Me.VideoScrollBar = New System.Windows.Forms.HScrollBar()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.autoPlay = New System.Windows.Forms.CheckBox()
        Me.PauseButton = New System.Windows.Forms.Button()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.NormalTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MediaPanel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VideoPlayerPanel.SuspendLayout()
        Me.VideoHolderPanel.SuspendLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(706, 376)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MediaPanel
        '
        Me.MediaPanel.ColumnCount = 2
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MediaPanel.ContextMenuStrip = Me.ContextMenuStrip1
        Me.MediaPanel.Controls.Add(Me.ImagePreview, 0, 0)
        Me.MediaPanel.Controls.Add(Me.VideoPlayerPanel, 1, 0)
        Me.MediaPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaPanel.Location = New System.Drawing.Point(0, 0)
        Me.MediaPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MediaPanel.Name = "MediaPanel"
        Me.MediaPanel.RowCount = 1
        Me.MediaPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MediaPanel.Size = New System.Drawing.Size(706, 376)
        Me.MediaPanel.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(154, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.ToolStripMenuItem1.Text = "Remove Image"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(153, 22)
        Me.ToolStripMenuItem2.Text = "Remove Video"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(153, 22)
        Me.ToolStripMenuItem3.Text = "Remove Media"
        '
        'ImagePreview
        '
        Me.ImagePreview.BackColor = System.Drawing.Color.Transparent
        Me.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePreview.Location = New System.Drawing.Point(0, 0)
        Me.ImagePreview.Margin = New System.Windows.Forms.Padding(0)
        Me.ImagePreview.Name = "ImagePreview"
        Me.ImagePreview.Size = New System.Drawing.Size(353, 376)
        Me.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagePreview.TabIndex = 1
        Me.ImagePreview.TabStop = False
        '
        'VideoPlayerPanel
        '
        Me.VideoPlayerPanel.ColumnCount = 1
        Me.VideoPlayerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.VideoPlayerPanel.Controls.Add(Me.VideoHolderPanel, 0, 0)
        Me.VideoPlayerPanel.Controls.Add(Me.VideoScrollBar, 0, 1)
        Me.VideoPlayerPanel.Controls.Add(Me.TableLayoutPanel1, 0, 2)
        Me.VideoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoPlayerPanel.Location = New System.Drawing.Point(353, 0)
        Me.VideoPlayerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.VideoPlayerPanel.Name = "VideoPlayerPanel"
        Me.VideoPlayerPanel.RowCount = 3
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.Size = New System.Drawing.Size(353, 376)
        Me.VideoPlayerPanel.TabIndex = 0
        '
        'VideoHolderPanel
        '
        Me.VideoHolderPanel.Controls.Add(Me.VlcControl1)
        Me.VideoHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoHolderPanel.Location = New System.Drawing.Point(0, 0)
        Me.VideoHolderPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.VideoHolderPanel.Name = "VideoHolderPanel"
        Me.VideoHolderPanel.Size = New System.Drawing.Size(353, 326)
        Me.VideoHolderPanel.TabIndex = 11
        '
        'VlcControl1
        '
        Me.VlcControl1.BackColor = System.Drawing.Color.Black
        Me.VlcControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VlcControl1.Location = New System.Drawing.Point(0, 0)
        Me.VlcControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.VlcControl1.Name = "VlcControl1"
        Me.VlcControl1.Size = New System.Drawing.Size(353, 326)
        Me.VlcControl1.Spu = -1
        Me.VlcControl1.TabIndex = 2
        Me.VlcControl1.Text = "VlcControl1"
        Me.VlcControl1.VlcLibDirectory = CType(resources.GetObject("VlcControl1.VlcLibDirectory"), System.IO.DirectoryInfo)
        Me.VlcControl1.VlcMediaplayerOptions = Nothing
        '
        'VideoScrollBar
        '
        Me.VideoScrollBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoScrollBar.LargeChange = 50
        Me.VideoScrollBar.Location = New System.Drawing.Point(0, 326)
        Me.VideoScrollBar.Maximum = 1000
        Me.VideoScrollBar.Name = "VideoScrollBar"
        Me.VideoScrollBar.Size = New System.Drawing.Size(353, 20)
        Me.VideoScrollBar.SmallChange = 5
        Me.VideoScrollBar.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.autoPlay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PauseButton, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PlayButton, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TimeLabel, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 346)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(353, 30)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'autoPlay
        '
        Me.autoPlay.AutoSize = True
        Me.autoPlay.Checked = True
        Me.autoPlay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoPlay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.autoPlay.Location = New System.Drawing.Point(63, 3)
        Me.autoPlay.Name = "autoPlay"
        Me.autoPlay.Size = New System.Drawing.Size(97, 24)
        Me.autoPlay.TabIndex = 5
        Me.autoPlay.Text = "Autoplay Video"
        Me.autoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.autoPlay.UseVisualStyleBackColor = True
        '
        'PauseButton
        '
        Me.PauseButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PauseButton.FlatAppearance.BorderSize = 0
        Me.PauseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PauseButton.Location = New System.Drawing.Point(0, 0)
        Me.PauseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(30, 30)
        Me.PauseButton.TabIndex = 0
        Me.PauseButton.Text = "⏸"
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'PlayButton
        '
        Me.PlayButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlayButton.Location = New System.Drawing.Point(30, 0)
        Me.PlayButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(30, 30)
        Me.PlayButton.TabIndex = 1
        Me.PlayButton.Text = "▶"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeLabel.Location = New System.Drawing.Point(289, 0)
        Me.TimeLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(64, 30)
        Me.TimeLabel.TabIndex = 2
        Me.TimeLabel.Text = "0:00:00.000" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0:00:00.000"
        Me.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NormalTimer
        '
        Me.NormalTimer.Enabled = True
        '
        'MediaViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.MediaPanel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "MediaViewer"
        Me.Size = New System.Drawing.Size(706, 376)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MediaPanel.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VideoPlayerPanel.ResumeLayout(False)
        Me.VideoHolderPanel.ResumeLayout(False)
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MediaPanel As TableLayoutPanel
    Friend WithEvents ImagePreview As PictureBox
    Friend WithEvents VideoPlayerPanel As TableLayoutPanel
    Friend WithEvents VideoHolderPanel As Panel
    Public WithEvents VlcControl1 As Vlc.DotNet.Forms.VlcControl
    Public WithEvents VideoScrollBar As HScrollBar
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PauseButton As Button
    Friend WithEvents PlayButton As Button
    Friend WithEvents TimeLabel As Label
    Friend WithEvents NormalTimer As Timer
    Friend WithEvents autoPlay As CheckBox
End Class
