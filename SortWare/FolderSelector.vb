Public Class FolderSelector
    Private settings As SortSettings
    Private returnDirectory As SortDirectory
    Public Sub New(ByVal _settings As SortSettings)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        settings = _settings
        For Each f In settings.getList(SortSettings.dirType.PRESORTDIR)
            FoldersListBox.Items.Add(f)
        Next
    End Sub

    Public Function getSelectedDir() As SortDirectory
        Return returnDirectory
    End Function

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles doneButton.Click
        returnDirectory = DirectCast(FoldersListBox.SelectedItem, SortDirectory)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class