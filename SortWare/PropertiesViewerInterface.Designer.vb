<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesViewerInterface
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PropertiesViewerInterface))
        Me.PropertiesViewer = New System.Windows.Forms.TabControl()
        Me.BasicTab = New System.Windows.Forms.TabPage()
        Me.DocumentTab = New System.Windows.Forms.TabPage()
        Me.ImageTab = New System.Windows.Forms.TabPage()
        Me.MusicTab = New System.Windows.Forms.TabPage()
        Me.StorageTab = New System.Windows.Forms.TabPage()
        Me.VideoTab = New System.Windows.Forms.TabPage()
        Me.BasicPropertiesList = New System.Windows.Forms.ListBox()
        Me.PropertiesViewer.SuspendLayout()
        Me.BasicTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'PropertiesViewer
        '
        Me.PropertiesViewer.Controls.Add(Me.BasicTab)
        Me.PropertiesViewer.Controls.Add(Me.DocumentTab)
        Me.PropertiesViewer.Controls.Add(Me.ImageTab)
        Me.PropertiesViewer.Controls.Add(Me.MusicTab)
        Me.PropertiesViewer.Controls.Add(Me.StorageTab)
        Me.PropertiesViewer.Controls.Add(Me.VideoTab)
        Me.PropertiesViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertiesViewer.Location = New System.Drawing.Point(0, 0)
        Me.PropertiesViewer.Name = "PropertiesViewer"
        Me.PropertiesViewer.SelectedIndex = 0
        Me.PropertiesViewer.Size = New System.Drawing.Size(800, 450)
        Me.PropertiesViewer.TabIndex = 0
        '
        'BasicTab
        '
        Me.BasicTab.Controls.Add(Me.BasicPropertiesList)
        Me.BasicTab.Location = New System.Drawing.Point(4, 22)
        Me.BasicTab.Name = "BasicTab"
        Me.BasicTab.Padding = New System.Windows.Forms.Padding(3)
        Me.BasicTab.Size = New System.Drawing.Size(792, 424)
        Me.BasicTab.TabIndex = 0
        Me.BasicTab.Text = "Basic"
        Me.BasicTab.UseVisualStyleBackColor = True
        '
        'DocumentTab
        '
        Me.DocumentTab.Location = New System.Drawing.Point(4, 22)
        Me.DocumentTab.Name = "DocumentTab"
        Me.DocumentTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DocumentTab.Size = New System.Drawing.Size(792, 424)
        Me.DocumentTab.TabIndex = 1
        Me.DocumentTab.Text = "Document"
        Me.DocumentTab.UseVisualStyleBackColor = True
        '
        'ImageTab
        '
        Me.ImageTab.Location = New System.Drawing.Point(4, 22)
        Me.ImageTab.Name = "ImageTab"
        Me.ImageTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ImageTab.Size = New System.Drawing.Size(792, 424)
        Me.ImageTab.TabIndex = 2
        Me.ImageTab.Text = "Image"
        Me.ImageTab.UseVisualStyleBackColor = True
        '
        'MusicTab
        '
        Me.MusicTab.Location = New System.Drawing.Point(4, 22)
        Me.MusicTab.Name = "MusicTab"
        Me.MusicTab.Padding = New System.Windows.Forms.Padding(3)
        Me.MusicTab.Size = New System.Drawing.Size(792, 424)
        Me.MusicTab.TabIndex = 3
        Me.MusicTab.Text = "Music"
        Me.MusicTab.UseVisualStyleBackColor = True
        '
        'StorageTab
        '
        Me.StorageTab.Location = New System.Drawing.Point(4, 22)
        Me.StorageTab.Name = "StorageTab"
        Me.StorageTab.Padding = New System.Windows.Forms.Padding(3)
        Me.StorageTab.Size = New System.Drawing.Size(792, 424)
        Me.StorageTab.TabIndex = 4
        Me.StorageTab.Text = "Storage"
        Me.StorageTab.UseVisualStyleBackColor = True
        '
        'VideoTab
        '
        Me.VideoTab.Location = New System.Drawing.Point(4, 22)
        Me.VideoTab.Name = "VideoTab"
        Me.VideoTab.Padding = New System.Windows.Forms.Padding(3)
        Me.VideoTab.Size = New System.Drawing.Size(792, 424)
        Me.VideoTab.TabIndex = 5
        Me.VideoTab.Text = "Video"
        Me.VideoTab.UseVisualStyleBackColor = True
        '
        'BasicPropertiesList
        '
        Me.BasicPropertiesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BasicPropertiesList.FormattingEnabled = True
        Me.BasicPropertiesList.Location = New System.Drawing.Point(3, 3)
        Me.BasicPropertiesList.Name = "BasicPropertiesList"
        Me.BasicPropertiesList.Size = New System.Drawing.Size(786, 418)
        Me.BasicPropertiesList.TabIndex = 0
        '
        'PropertiesViewerInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PropertiesViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PropertiesViewerInterface"
        Me.Text = "PropertiesViewerInterface"
        Me.PropertiesViewer.ResumeLayout(False)
        Me.BasicTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PropertiesViewer As TabControl
    Friend WithEvents BasicTab As TabPage
    Friend WithEvents DocumentTab As TabPage
    Friend WithEvents ImageTab As TabPage
    Friend WithEvents MusicTab As TabPage
    Friend WithEvents StorageTab As TabPage
    Friend WithEvents VideoTab As TabPage
    Friend WithEvents BasicPropertiesList As ListBox
End Class
