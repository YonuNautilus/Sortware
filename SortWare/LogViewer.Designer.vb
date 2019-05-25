<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogViewer))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LogsBox = New System.Windows.Forms.ListView()
        Me.File = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Original = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Final = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tags = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OpenFileButton = New System.Windows.Forms.Button()
        Me.UndoActionButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LogsBox, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LogsBox
        '
        Me.LogsBox.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.File, Me.Time, Me.Original, Me.Final, Me.Tags})
        Me.LogsBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogsBox.Location = New System.Drawing.Point(3, 3)
        Me.LogsBox.Name = "LogsBox"
        Me.LogsBox.Size = New System.Drawing.Size(794, 414)
        Me.LogsBox.TabIndex = 0
        Me.LogsBox.UseCompatibleStateImageBehavior = False
        Me.LogsBox.View = System.Windows.Forms.View.Details
        '
        'File
        '
        Me.File.Text = "File Name"
        Me.File.Width = 175
        '
        'Time
        '
        Me.Time.Text = "Time"
        Me.Time.Width = 71
        '
        'Original
        '
        Me.Original.Text = "Original File"
        Me.Original.Width = 243
        '
        'Final
        '
        Me.Final.Text = "Final File"
        Me.Final.Width = 236
        '
        'Tags
        '
        Me.Tags.Text = "Tags"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UndoActionButton)
        Me.Panel1.Controls.Add(Me.OpenFileButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 420)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 30)
        Me.Panel1.TabIndex = 1
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Location = New System.Drawing.Point(3, 4)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(75, 23)
        Me.OpenFileButton.TabIndex = 0
        Me.OpenFileButton.Text = "Open File"
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'UndoActionButton
        '
        Me.UndoActionButton.Location = New System.Drawing.Point(722, 4)
        Me.UndoActionButton.Name = "UndoActionButton"
        Me.UndoActionButton.Size = New System.Drawing.Size(75, 23)
        Me.UndoActionButton.TabIndex = 1
        Me.UndoActionButton.Text = "Undo Move"
        Me.UndoActionButton.UseVisualStyleBackColor = True
        '
        'LogViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LogViewer"
        Me.Text = "LogViewer"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LogsBox As ListView
    Friend WithEvents File As ColumnHeader
    Friend WithEvents Time As ColumnHeader
    Friend WithEvents Original As ColumnHeader
    Friend WithEvents Final As ColumnHeader
    Friend WithEvents Tags As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents OpenFileButton As Button
    Friend WithEvents UndoActionButton As Button
End Class
