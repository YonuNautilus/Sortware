<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SortSettingsDialog
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
        Me.components = New System.ComponentModel.Container()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.FinishedButton = New System.Windows.Forms.Button()
        Me.SettingsViewer = New System.Windows.Forms.RichTextBox()
        Me.InitializeSettings = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RootDirView = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(441, 321)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 1
        '
        'FinishedButton
        '
        Me.FinishedButton.Location = New System.Drawing.Point(715, 422)
        Me.FinishedButton.Name = "FinishedButton"
        Me.FinishedButton.Size = New System.Drawing.Size(73, 23)
        Me.FinishedButton.TabIndex = 2
        Me.FinishedButton.Text = "Done"
        Me.FinishedButton.UseVisualStyleBackColor = True
        '
        'SettingsViewer
        '
        Me.SettingsViewer.Location = New System.Drawing.Point(576, 12)
        Me.SettingsViewer.Name = "SettingsViewer"
        Me.SettingsViewer.Size = New System.Drawing.Size(212, 404)
        Me.SettingsViewer.TabIndex = 3
        Me.SettingsViewer.Text = ""
        '
        'InitializeSettings
        '
        Me.InitializeSettings.Enabled = False
        Me.InitializeSettings.Location = New System.Drawing.Point(476, 12)
        Me.InitializeSettings.Name = "InitializeSettings"
        Me.InitializeSettings.Size = New System.Drawing.Size(94, 41)
        Me.InitializeSettings.TabIndex = 4
        Me.InitializeSettings.Text = "Initialize .sortSettings File"
        Me.ToolTip1.SetToolTip(Me.InitializeSettings, "If no .sortSettings file is found, clicking this button will create one in the se" &
        "lected root directory")
        Me.InitializeSettings.UseVisualStyleBackColor = True
        '
        'RootDirView
        '
        Me.RootDirView.FormattingEnabled = True
        Me.RootDirView.Location = New System.Drawing.Point(12, 12)
        Me.RootDirView.Name = "RootDirView"
        Me.RootDirView.Size = New System.Drawing.Size(235, 433)
        Me.RootDirView.TabIndex = 5
        '
        'SortSettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RootDirView)
        Me.Controls.Add(Me.InitializeSettings)
        Me.Controls.Add(Me.SettingsViewer)
        Me.Controls.Add(Me.FinishedButton)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "SortSettingsDialog"
        Me.Text = "DirectoryFinder"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents FinishedButton As Button
    Friend WithEvents SettingsViewer As RichTextBox
    Friend WithEvents InitializeSettings As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RootDirView As ListBox
End Class
