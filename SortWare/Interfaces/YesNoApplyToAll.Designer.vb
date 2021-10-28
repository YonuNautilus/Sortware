<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YesNoApplyToAll
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
        Me.YesButton = New System.Windows.Forms.Button()
        Me.NoButton = New System.Windows.Forms.Button()
        Me.MainLabel = New System.Windows.Forms.Label()
        Me.ApplyAllChkBx = New System.Windows.Forms.CheckBox()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'YesButton
        '
        Me.YesButton.Location = New System.Drawing.Point(15, 56)
        Me.YesButton.Name = "YesButton"
        Me.YesButton.Size = New System.Drawing.Size(158, 23)
        Me.YesButton.TabIndex = 0
        Me.YesButton.Text = "Yes, Delete This Folder"
        Me.YesButton.UseVisualStyleBackColor = True
        '
        'NoButton
        '
        Me.NoButton.Location = New System.Drawing.Point(179, 56)
        Me.NoButton.Name = "NoButton"
        Me.NoButton.Size = New System.Drawing.Size(158, 23)
        Me.NoButton.TabIndex = 1
        Me.NoButton.Text = "No, Do Not Delete This Folder"
        Me.NoButton.UseVisualStyleBackColor = True
        '
        'MainLabel
        '
        Me.MainLabel.AutoSize = True
        Me.MainLabel.Location = New System.Drawing.Point(12, 9)
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(19, 13)
        Me.MainLabel.TabIndex = 2
        Me.MainLabel.Text = "__"
        '
        'ApplyAllChkBx
        '
        Me.ApplyAllChkBx.AutoSize = True
        Me.ApplyAllChkBx.Location = New System.Drawing.Point(15, 86)
        Me.ApplyAllChkBx.Name = "ApplyAllChkBx"
        Me.ApplyAllChkBx.Size = New System.Drawing.Size(191, 17)
        Me.ApplyAllChkBx.TabIndex = 3
        Me.ApplyAllChkBx.Text = "Apply To All Folders In This Batch?"
        Me.ApplyAllChkBx.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(343, 56)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(121, 23)
        Me.CancelButton.TabIndex = 4
        Me.CancelButton.Text = "Cancel, Stop Deleting"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'YesNoApplyToAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 115)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.ApplyAllChkBx)
        Me.Controls.Add(Me.MainLabel)
        Me.Controls.Add(Me.NoButton)
        Me.Controls.Add(Me.YesButton)
        Me.Name = "YesNoApplyToAll"
        Me.Text = "Folder Still Contains Files!"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents YesButton As Button
    Friend WithEvents NoButton As Button
    Friend WithEvents MainLabel As Label
    Friend WithEvents ApplyAllChkBx As CheckBox
    Friend WithEvents CancelButton As Button
End Class
