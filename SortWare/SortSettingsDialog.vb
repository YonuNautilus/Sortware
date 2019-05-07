Public Class SortSettingsDialog
    Private _sortSettings As SortSettings
    Private _rootDir As String
    Private _sortSettingsReader As IO.StreamReader
    Private _sortSettingsWriter As IO.StreamWriter

    Private _changedNotSaved As Boolean = False

    Private Const TWOLINE As String = vbNewLine + vbNewLine

    Public Sub New(ByVal path As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _rootDir = path

        If IO.File.Exists(_rootDir & "\.sortSettings.txt") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If

        refreshDirs()
        initSettings()
    End Sub

#Region "REFRESH"
    Private Sub initSettings()
        If IO.File.Exists(_rootDir + "\.sortSettings.txt") Then
            '_sortSettingsReader = New IO.StreamReader(_rootDir + "\.sortSettings.txt")
            _sortSettings = New SortSettings(_rootDir)
            SettingsViewer.Text = _sortSettings.toString
            '_sortSettingsReader.Close()
        End If
    End Sub

    Private Sub refreshSettings()
        SettingsViewer.Text = _sortSettings.toString()
    End Sub

    Private Sub refreshDirs()
        For Each Dir As String In IO.Directory.GetDirectories(_rootDir)
            populateDirs(Dir)
        Next
    End Sub

    Private Sub RefreshButton()
        If IO.File.Exists(_rootDir & "\.sortSettings.txt") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If
    End Sub
#End Region

    Private Sub populateDirs(ByVal _dir As String, Optional ByVal _indent As Integer = 0)
        RootDirView.Items.Add(New SortDirectory(_dir, _indent + 1))
        For Each Dir As String In IO.Directory.GetDirectories(_dir)
            populateDirs(Dir, _indent + 1)
        Next
    End Sub

    Private Sub TurnOffWarnings()
        StatusLabel.Text = ""
        For Each button In AddButtonGroup.Controls
            If TypeOf button Is Button Then
                DirectCast(button, Button).BackColor = SystemColors.Control
            End If
        Next
    End Sub

#Region "Handlers"
    Private Sub AddRootDir_Click(sender As Object, e As EventArgs) Handles addRootDir.Click
        If RootDirView.SelectedItem Is Nothing Then
            Return
        End If

        If RootDirView.SelectedItems.Count > 1 Then
            StatusLabel.Text = "You can only select one root directory"
            Dim c As Control = AddButtonGroup.Controls.Item("addRootDir")
            DirectCast(AddButtonGroup.Controls.Item("addRootDir"), Button).BackColor = Color.Maroon
            ErrorTimer.Start()
        ElseIf TypeOf RootDirView.SelectedItem Is SortDirectory AndAlso DirectCast(RootDirView.SelectedItem, SortDirectory).exists Then
            _sortSettings.rootDir = DirectCast(RootDirView.SelectedItem, SortDirectory).fullName
        End If
        refreshSettings()
    End Sub

    Private Sub AddMainDir_Click(sender As Object, e As EventArgs) Handles addMainDir.Click
        If RootDirView.SelectedItem Is Nothing Then
            Return
        End If

        If RootDirView.SelectedItems.Count > 1 Then
            For Each d In RootDirView.SelectedItems
                If TypeOf d Is SortDirectory AndAlso DirectCast(d, SortDirectory).exists Then
                    _sortSettings.addToDirList(DirectCast(d, SortDirectory).fullName, SortSettings.dirType.MAINDIR)
                End If
            Next
        ElseIf TypeOf RootDirView.SelectedItem Is SortDirectory AndAlso DirectCast(RootDirView.SelectedItem, SortDirectory).exists Then
            _sortSettings.addToDirList(DirectCast(RootDirView.SelectedItem, SortDirectory).fullName, SortSettings.dirType.MAINDIR)
        End If
        refreshSettings()
    End Sub

    Private Sub InitializeSettings_Click(sender As Object, e As EventArgs) Handles InitializeSettings.Click
        Dim fs As IO.FileStream = IO.File.Create(_rootDir & "\.sortSettings.txt")
        fs.Close()
        'IO.File.Create(_rootDir & "\.sortSettings.txt", IO.FileMode.CreateNew)
        'IO.File.SetAttributes(_rootDir & "\.sortSettings.txt", IO.FileAttributes.Hidden)

        Using _sortSettingsWriter = New IO.StreamWriter(_rootDir + "\.sortSettings.txt")
            _sortSettingsWriter.Write("Root: " + _rootDir + vbNewLine + "#" + TWOLINE + "Mains:" + vbNewLine + "#" + TWOLINE + "Presorts:" + vbNewLine + "#" + TWOLINE + "Blocked:" + vbNewLine + "#")
        End Using

        _sortSettings = New SortSettings(_rootDir)

        RefreshButton()
        initSettings()
    End Sub

    Private Sub FinishedButton_Click(sender As Object, e As EventArgs) Handles FinishedButton.Click
        Me.Close()
    End Sub

    Private Sub SortSettingsDialog_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If _changedNotSaved Then
            Dim result = MessageBox.Show("Do you want to save the sort settings before exiting?", "Closing without saving!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.No Then
            ElseIf result = DialogResult.Yes Then
                SaveButton_Click(Me, e)
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If

        End If


        Try
            _sortSettingsReader.Close()
            _sortSettingsWriter.Close()
            _sortSettings.Close()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

    End Sub

    Private Sub SettingsViewer_TextChanged(sender As Object, e As EventArgs) Handles SettingsViewer.TextChanged
        _changedNotSaved = True
    End Sub

    Private Sub ErrorTimer_Tick(sender As Object, e As EventArgs) Handles ErrorTimer.Tick
        ErrorTimer.Stop()
        TurnOffWarnings()
    End Sub

#End Region
End Class