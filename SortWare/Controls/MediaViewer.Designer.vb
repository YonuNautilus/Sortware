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
        Me.ImagePreview = New System.Windows.Forms.PictureBox()
        Me.VideoPlayerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.VideoHolderPanel = New System.Windows.Forms.Panel()
        Me.VlcControl1 = New Vlc.DotNet.Forms.VlcControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PauseButton = New System.Windows.Forms.ToolStripButton()
        Me.PlayButton = New System.Windows.Forms.ToolStripButton()
        Me.VideoScrollBar = New System.Windows.Forms.HScrollBar()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MediaPanel.SuspendLayout()
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VideoPlayerPanel.SuspendLayout()
        Me.VideoHolderPanel.SuspendLayout()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(500, 276)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MediaPanel
        '
        Me.MediaPanel.ColumnCount = 2
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.MediaPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MediaPanel.Controls.Add(Me.ImagePreview, 0, 0)
        Me.MediaPanel.Controls.Add(Me.VideoPlayerPanel, 1, 0)
        Me.MediaPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaPanel.Location = New System.Drawing.Point(0, 0)
        Me.MediaPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MediaPanel.Name = "MediaPanel"
        Me.MediaPanel.RowCount = 1
        Me.MediaPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MediaPanel.Size = New System.Drawing.Size(500, 276)
        Me.MediaPanel.TabIndex = 3
        '
        'ImagePreview
        '
        Me.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePreview.Location = New System.Drawing.Point(0, 0)
        Me.ImagePreview.Margin = New System.Windows.Forms.Padding(0)
        Me.ImagePreview.Name = "ImagePreview"
        Me.ImagePreview.Size = New System.Drawing.Size(250, 276)
        Me.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagePreview.TabIndex = 1
        Me.ImagePreview.TabStop = False
        '
        'VideoPlayerPanel
        '
        Me.VideoPlayerPanel.ColumnCount = 1
        Me.VideoPlayerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.VideoPlayerPanel.Controls.Add(Me.VideoHolderPanel, 0, 0)
        Me.VideoPlayerPanel.Controls.Add(Me.ToolStrip1, 0, 2)
        Me.VideoPlayerPanel.Controls.Add(Me.VideoScrollBar, 0, 1)
        Me.VideoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoPlayerPanel.Location = New System.Drawing.Point(253, 3)
        Me.VideoPlayerPanel.Name = "VideoPlayerPanel"
        Me.VideoPlayerPanel.RowCount = 3
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.VideoPlayerPanel.Size = New System.Drawing.Size(244, 270)
        Me.VideoPlayerPanel.TabIndex = 0
        '
        'VideoHolderPanel
        '
        Me.VideoHolderPanel.Controls.Add(Me.VlcControl1)
        Me.VideoHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VideoHolderPanel.Location = New System.Drawing.Point(0, 0)
        Me.VideoHolderPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.VideoHolderPanel.Name = "VideoHolderPanel"
        Me.VideoHolderPanel.Size = New System.Drawing.Size(244, 230)
        Me.VideoHolderPanel.TabIndex = 11
        '
        'VlcControl1
        '
        Me.VlcControl1.BackColor = System.Drawing.Color.Black
        Me.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VlcControl1.Location = New System.Drawing.Point(0, 0)
        Me.VlcControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.VlcControl1.Name = "VlcControl1"
        Me.VlcControl1.Size = New System.Drawing.Size(244, 230)
        Me.VlcControl1.Spu = -1
        Me.VlcControl1.TabIndex = 2
        Me.VlcControl1.Text = "VlcControl1"
        Me.VlcControl1.VlcLibDirectory = CType(resources.GetObject("VlcControl1.VlcLibDirectory"), System.IO.DirectoryInfo)
        Me.VlcControl1.VlcMediaplayerOptions = Nothing
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PauseButton, Me.PlayButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 250)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(244, 20)
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
        Me.VideoScrollBar.Location = New System.Drawing.Point(0, 230)
        Me.VideoScrollBar.Maximum = 1000
        Me.VideoScrollBar.Name = "VideoScrollBar"
        Me.VideoScrollBar.Size = New System.Drawing.Size(244, 20)
        Me.VideoScrollBar.SmallChange = 5
        Me.VideoScrollBar.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem1.Text = "Remove Image"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "Remove Video"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem3.Text = "Remove Media"
        '
        'MediaViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.MediaPanel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "MediaViewer"
        Me.Size = New System.Drawing.Size(500, 276)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MediaPanel.ResumeLayout(False)
        CType(Me.ImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VideoPlayerPanel.ResumeLayout(False)
        Me.VideoPlayerPanel.PerformLayout()
        Me.VideoHolderPanel.ResumeLayout(False)
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MediaPanel As TableLayoutPanel
    Friend WithEvents ImagePreview As PictureBox
    Friend WithEvents VideoPlayerPanel As TableLayoutPanel
    Friend WithEvents VideoHolderPanel As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PauseButton As ToolStripButton
    Friend WithEvents PlayButton As ToolStripButton
    Public WithEvents VlcControl1 As Vlc.DotNet.Forms.VlcControl
    Public WithEvents VideoScrollBar As HScrollBar
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class
