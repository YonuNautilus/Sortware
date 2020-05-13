<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileConversion
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FilesToBeConverted = New System.Windows.Forms.ListView()
        Me.ConversionFolders = New System.Windows.Forms.ListView()
        Me.FolderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FolderLocation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ScriptLocation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.ButtonsGroup = New System.Windows.Forms.GroupBox()
        Me.ClearDone = New System.Windows.Forms.Button()
        Me.ConvAll = New System.Windows.Forms.Button()
        Me.ConvSelected = New System.Windows.Forms.Button()
        Me.Filename = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.ButtonsGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.FilesToBeConverted, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ConversionFolders, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ControlPanel, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FilesToBeConverted
        '
        Me.FilesToBeConverted.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.FilesToBeConverted.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Filename})
        Me.FilesToBeConverted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilesToBeConverted.HideSelection = False
        Me.FilesToBeConverted.Location = New System.Drawing.Point(269, 3)
        Me.FilesToBeConverted.Name = "FilesToBeConverted"
        Me.FilesToBeConverted.Size = New System.Drawing.Size(260, 444)
        Me.FilesToBeConverted.TabIndex = 3
        Me.FilesToBeConverted.UseCompatibleStateImageBehavior = False
        Me.FilesToBeConverted.View = System.Windows.Forms.View.Details
        '
        'ConversionFolders
        '
        Me.ConversionFolders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FolderName, Me.FolderLocation, Me.ScriptLocation})
        Me.ConversionFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConversionFolders.HideSelection = False
        Me.ConversionFolders.Location = New System.Drawing.Point(3, 3)
        Me.ConversionFolders.MultiSelect = False
        Me.ConversionFolders.Name = "ConversionFolders"
        Me.ConversionFolders.Size = New System.Drawing.Size(260, 444)
        Me.ConversionFolders.TabIndex = 0
        Me.ConversionFolders.UseCompatibleStateImageBehavior = False
        Me.ConversionFolders.View = System.Windows.Forms.View.Details
        '
        'FolderName
        '
        Me.FolderName.Text = "Name"
        '
        'FolderLocation
        '
        Me.FolderLocation.Text = "Location"
        '
        'ScriptLocation
        '
        Me.ScriptLocation.Text = "Script"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.ButtonsGroup)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlPanel.Location = New System.Drawing.Point(535, 3)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(262, 444)
        Me.ControlPanel.TabIndex = 2
        '
        'ButtonsGroup
        '
        Me.ButtonsGroup.Controls.Add(Me.ClearDone)
        Me.ButtonsGroup.Controls.Add(Me.ConvAll)
        Me.ButtonsGroup.Controls.Add(Me.ConvSelected)
        Me.ButtonsGroup.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonsGroup.Location = New System.Drawing.Point(0, 0)
        Me.ButtonsGroup.Name = "ButtonsGroup"
        Me.ButtonsGroup.Size = New System.Drawing.Size(262, 164)
        Me.ButtonsGroup.TabIndex = 1
        Me.ButtonsGroup.TabStop = False
        Me.ButtonsGroup.Text = "GroupBox1"
        '
        'ClearDone
        '
        Me.ClearDone.Dock = System.Windows.Forms.DockStyle.Top
        Me.ClearDone.Location = New System.Drawing.Point(3, 62)
        Me.ClearDone.Name = "ClearDone"
        Me.ClearDone.Size = New System.Drawing.Size(256, 23)
        Me.ClearDone.TabIndex = 2
        Me.ClearDone.Text = "Delete Finished Files"
        Me.ClearDone.UseVisualStyleBackColor = True
        '
        'ConvAll
        '
        Me.ConvAll.Dock = System.Windows.Forms.DockStyle.Top
        Me.ConvAll.Location = New System.Drawing.Point(3, 39)
        Me.ConvAll.Name = "ConvAll"
        Me.ConvAll.Size = New System.Drawing.Size(256, 23)
        Me.ConvAll.TabIndex = 1
        Me.ConvAll.Text = "Convert All Files In Folder"
        Me.ConvAll.UseVisualStyleBackColor = True
        '
        'ConvSelected
        '
        Me.ConvSelected.Dock = System.Windows.Forms.DockStyle.Top
        Me.ConvSelected.Location = New System.Drawing.Point(3, 16)
        Me.ConvSelected.Name = "ConvSelected"
        Me.ConvSelected.Size = New System.Drawing.Size(256, 23)
        Me.ConvSelected.TabIndex = 0
        Me.ConvSelected.Text = "Convert Selected Files"
        Me.ConvSelected.UseVisualStyleBackColor = True
        '
        'Filename
        '
        Me.Filename.Text = "Name"
        Me.Filename.Width = 256
        '
        'FileConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FileConversion"
        Me.Text = "FileConversion"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        Me.ButtonsGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ConversionFolders As ListView
    Friend WithEvents ControlPanel As Panel
    Friend WithEvents ButtonsGroup As GroupBox
    Friend WithEvents FilesToBeConverted As ListView
    Friend WithEvents ClearDone As Button
    Friend WithEvents ConvAll As Button
    Friend WithEvents ConvSelected As Button
    Friend WithEvents FolderName As ColumnHeader
    Friend WithEvents FolderLocation As ColumnHeader
    Friend WithEvents ScriptLocation As ColumnHeader
    Friend WithEvents Filename As ColumnHeader
End Class
