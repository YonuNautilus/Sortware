Public Class MainInterface
    Protected Class SortSettings
        Protected _filePath As String
        Protected _file As System.IO.File
        Public Sub New()

        End Sub
        Public Sub New(ByVal filePath As String)

        End Sub
    End Class

    Protected _settings As SortSettings
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _settings As New SortSettings
    End Sub

    Private Sub ButtonOnOff(ByRef button As Button, ByVal enable As Boolean)
        button.Enabled = enable
    End Sub

    Private Sub FindFindRootDirButton_Click(sender As Object, e As EventArgs) Handles FindRootDirButton.Click
        Dim fbd As New FolderBrowserDialog
        fbd.RootFolder = Environment.SpecialFolder.MyComputer
        If fbd.ShowDialog = DialogResult.OK Then
            RootDirTextBox.Text = fbd.SelectedPath
        End If

        If Not System.IO.File.Exists(RootDirTextBox.Text & ".sortSettings") Then
            Debug.WriteLine(".sortSettings file non existent")
            OpenSortSettingsButton.BackColor = Color.Red
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon
            OpenSortSettingsButton.Text = ".sortSettings file not found!"
        Else    'A .sortSettings file does exist
            _settings = New SortSettings(RootDirTextBox.Text)
        End If
    End Sub

    Private Sub OpenSortSettingsButton_Click(sender As Object, e As EventArgs) Handles OpenSortSettingsButton.Click
        Dim _sortSettings = New SortSettingsDialog(RootDirTextBox.Text)

        _sortSettings.Show()

    End Sub

End Class
