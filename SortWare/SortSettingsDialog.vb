Public Class SortSettingsDialog

    Private _sortSettings As SortSettings
    Private _rootDir As String
    Private _rootDirObj As SortDirectory
    Private _sortSettingsReader As IO.StreamReader
    Private _sortSettingsWriter As IO.StreamWriter

    Private _mainsSettings As New List(Of SortDirectory)
    Private _presortSettings As New List(Of SortDirectory)
    Private _blockedSettings As New List(Of SortDirectory)

    Private _changedNotSaved As Boolean = False

    Private Const TWOLINE As String = vbNewLine + vbNewLine

    Private Class TreeNodeContextMenu
        Inherits ContextMenu

    End Class

    Public Sub New(ByVal path As String)
        Debug.AutoFlush = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TagsSaveButton.Image = My.Resources.Resources.shell32_16761.ToBitmap

        _rootDir = path

        If IO.File.Exists(_rootDir & "\.sortSettings.txt") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If

        refreshDirs()
        initSettings()
    End Sub

    Private Sub SortSettingsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dirs
    End Sub

#Region "REFRESH"
    Private Sub initSettings()
        If IO.File.Exists(_rootDir + "\.sortSettings.txt") Then
            '_sortSettingsReader = New IO.StreamReader(_rootDir + "\.sortSettings.txt")
            _sortSettings = New SortSettings(_rootDir)
            SettingsViewer.Text = _sortSettings.toString
            '_sortSettingsReader.Close()

            initSettingsList()
        End If
    End Sub

    Private Sub initSettingsList()
        _rootDirObj = New SortDirectory(_rootDir, 3)
        _mainsSettings = _sortSettings.getList(SortSettings.dirType.MAINDIR)
        _presortSettings = _sortSettings.getList(SortSettings.dirType.PRESORTDIR)
        _blockedSettings = _sortSettings.getList(SortSettings.dirType.BLOCKEDDIR)
        refreshDirView()
    End Sub
    Private Sub refreshSettings()
        refreshDirView()
        SettingsViewer.Text = _sortSettings.toString()
    End Sub

    Private Sub refreshDirView()
        SettingsDirView.Items.Clear()
        SettingsDirView.Items.Add("Root")
        SettingsDirView.Items.Add(_rootDirObj)

        SettingsDirView.Items.Add("Main Directories:")
        For Each m In _mainsSettings
            SettingsDirView.Items.Add(m)
            If m.hasSubs Then
                SettingsDirView.Items.AddRange(m.getSubs.ToArray)
            End If
        Next
        'SettingsDirView.Items.AddRange(_mainsSettings.ToArray)

        SettingsDirView.Items.Add("Presorted Directories:")
        SettingsDirView.Items.AddRange(_presortSettings.ToArray)

        SettingsDirView.Items.Add("Blocked Directories:")
        SettingsDirView.Items.AddRange(_blockedSettings.ToArray)
    End Sub

    Public Sub refreshTagsViewer()
        TagsViewer.Items.Clear()
        If SettingsDirView.SelectedItem IsNot Nothing AndAlso TypeOf SettingsDirView.SelectedItem Is SortDirectory AndAlso DirectCast(SettingsDirView.SelectedItem, SortDirectory).type = SortSettings.dirType.MAINDIR Then
            If DirectCast(SettingsDirView.SelectedItem, SortDirectory).hasTags Then
                Dim tagArr = DirectCast(SettingsDirView.SelectedItem, SortDirectory).getTags
                For t As Integer = 0 To tagArr.Length - 1
                    'Dim tagStr = Split(tagArr(t), vbTab)
                    'If tagStr.Length = 2 Then
                    '    TagsViewer.Items.Add(tagStr(0))
                    '    TagsViewer.Items.Item(t).SubItems.Add(tagStr(1))
                    'End If
                    TagsViewer.Items.Add(tagArr(t))
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Calls the recursive populateDirs routine
    ''' </summary>
    Private Sub refreshDirs()
        RootDirViewTree.Nodes.Clear()
        For Each Dir As String In IO.Directory.GetDirectories(_rootDir)
            populateDirs(Dir)

            Dim currentNode As TreeNode = RootDirViewTree.Nodes.Add(New SortDirectory(Dir).getName())
            currentNode.Tag = New SortDirectory(Dir)
            populateDirs(currentNode, Dir)
        Next
    End Sub

    Private Sub populateDirs(ByRef node As TreeNode, ByVal _dir As String)
        For Each Dir As String In IO.Directory.GetDirectories(_dir)
            Dim currentNode As TreeNode = node.Nodes.Add(New SortDirectory(Dir).getName())
            currentNode.Tag = New SortDirectory(Dir)
            populateDirs(currentNode, Dir)
        Next
    End Sub

    Private Sub populateDirs(ByVal _dir As String, Optional ByVal _indent As Integer = 0)
        RootDirView.Items.Add(New SortDirectory(_dir, _indent + 1))
        For Each Dir As String In IO.Directory.GetDirectories(_dir)
            populateDirs(Dir, _indent + 1)
        Next
    End Sub

    Private Sub RefreshCreateButton()
        If IO.File.Exists(_rootDir & "\.sortSettings.txt") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If
    End Sub

    Private Sub RefreshAddButtons(sender As Object, e As EventArgs) Handles RootDirView.SelectedIndexChanged, SettingsDirView.SelectedIndexChanged
        If TypeOf sender Is Control Then
            Select Case DirectCast(sender, Control).Name
                Case RootDirView.Name
                    addRootDir.Enabled = True
                    addMainDir.Enabled = True
                    addPresortDir.Enabled = True
                    addBlockedDir.Enabled = True
                    removeDir.Enabled = False
                Case SettingsDirView.Name
                    addRootDir.Enabled = False
                    addMainDir.Enabled = False
                    addPresortDir.Enabled = False
                    addBlockedDir.Enabled = False
                    removeDir.Enabled = True
                    refreshTagsViewer()
                Case Else
                    addRootDir.Enabled = False
                    addMainDir.Enabled = False
                    addPresortDir.Enabled = False
                    addBlockedDir.Enabled = False
                    removeDir.Enabled = False
            End Select
        End If
    End Sub
#End Region

    Private Sub TurnOffWarnings()
        StatusLabel.Text = ""
        For Each button In AddButtonGroup.Controls
            If TypeOf button Is Button Then
                DirectCast(button, Button).BackColor = SystemColors.Control
            End If
        Next
    End Sub

    Public Shared Function getTags(ByVal directory As SortDirectory) As List(Of ListViewItem)
        If directory.hasTags Then

        End If
    End Function

#Region "Handlers"
    Private Sub AddRootDir_Click(sender As Object, e As EventArgs) Handles addRootDir.Click
        'If RootDirView.SelectedItem Is Nothing Then
        '    Return
        'End If

        'If RootDirView.SelectedItems.Count > 1 Then
        '    StatusLabel.Text = "You can only select one root directory"
        '    Dim c As Control = AddButtonGroup.Controls.Item("addRootDir")
        '    DirectCast(AddButtonGroup.Controls.Item("addRootDir"), Button).BackColor = Color.Maroon
        '    ErrorTimer.Start()
        'ElseIf TypeOf RootDirView.SelectedItem Is SortDirectory AndAlso DirectCast(RootDirView.SelectedItem, SortDirectory).exists Then
        '    _sortSettings.rootDir = DirectCast(RootDirView.SelectedItem, SortDirectory).fullName
        'End If

        If RootDirViewTree.SelectedNode Is Nothing Then
            Return
        End If

        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.rootDir = DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName
        End If

        refreshSettings()
    End Sub

    Private Sub AddMainDir_Click(sender As Object, e As EventArgs) Handles addMainDir.Click
        'If RootDirView.SelectedItem Is Nothing Then
        '    Return
        'End If

        'If RootDirView.SelectedItems.Count > 1 Then
        '    For Each d In RootDirView.SelectedItems
        '        If TypeOf d Is SortDirectory AndAlso DirectCast(d, SortDirectory).exists Then
        '            _sortSettings.addToDirList(DirectCast(d, SortDirectory).fullName, SortSettings.dirType.MAINDIR)
        '            _mainsSettings.Add(DirectCast(d, SortDirectory))
        '        End If
        '    Next
        'ElseIf TypeOf RootDirView.SelectedItem Is SortDirectory AndAlso DirectCast(RootDirView.SelectedItem, SortDirectory).exists Then
        '    _sortSettings.addToDirList(DirectCast(RootDirView.SelectedItem, SortDirectory).fullName, SortSettings.dirType.MAINDIR)
        '    _mainsSettings.Add(DirectCast(RootDirView.SelectedItem, SortDirectory))
        'End If

        If RootDirViewTree.SelectedNode Is Nothing Then
            Return
        End If

        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.addToDirList(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, SortSettings.dirType.MAINDIR)
            _mainsSettings.Add(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory))
        End If

        refreshSettings()
    End Sub

    Private Sub AddMainSubdir_Click(sender As Object, e As EventArgs) Handles addMainSubdir.Click
        'First check those both selected items are sortDirectories...
        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso SettingsDirView.SelectedItem IsNot Nothing AndAlso TypeOf SettingsDirView.SelectedItem Is SortDirectory Then
            'Then check that the selected settingsDir is a main Dir, and that the rootDir item contains the path of the selected MainDirectory
            If DirectCast(SettingsDirView.SelectedItem, SortDirectory).type = SortSettings.dirType.MAINDIR AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName.Contains(DirectCast(SettingsDirView.SelectedItem, SortDirectory).fullName) Then
                Dim ind = _mainsSettings.IndexOf(DirectCast(SettingsDirView.SelectedItem, SortDirectory))
                _mainsSettings.Item(ind).addSubDir(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName)
            End If
        End If
        refreshSettings()
    End Sub

    Private Sub AddPresortDir_Click(sender As Object, e As EventArgs) Handles addPresortDir.Click
        'If RootDirView.SelectedItem Is Nothing Then
        '    Return
        'End If

        'If RootDirView.SelectedItems.Count > 1 Then
        '    For Each d In RootDirView.SelectedItems
        '        If TypeOf d Is SortDirectory AndAlso DirectCast(d, SortDirectory).exists Then
        '            _sortSettings.addToDirList(DirectCast(d, SortDirectory).fullName, SortSettings.dirType.PRESORTDIR)
        '            _presortSettings.Add(DirectCast(d, SortDirectory))
        '        End If
        '    Next
        'ElseIf TypeOf RootDirView.SelectedItem Is SortDirectory AndAlso DirectCast(RootDirView.SelectedItem, SortDirectory).exists Then
        '    _sortSettings.addToDirList(DirectCast(RootDirView.SelectedItem, SortDirectory).fullName, SortSettings.dirType.PRESORTDIR)
        '    _presortSettings.Add(DirectCast(RootDirView.SelectedItem, SortDirectory))
        'End If

        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.addToDirList(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, SortSettings.dirType.PRESORTDIR)
            _presortSettings.Add(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory))
        End If

        refreshSettings()
    End Sub

    Private Sub AddBlockedDir_Click(sender As Object, e As EventArgs) Handles addBlockedDir.Click
        'If RootDirView.SelectedItem Is Nothing Then
        '    Return
        'End If

        'If RootDirView.SelectedItems.Count > 1 Then
        '    For Each d In RootDirView.SelectedItems
        '        If TypeOf d Is SortDirectory AndAlso DirectCast(d, SortDirectory).exists Then
        '            _sortSettings.addToDirList(DirectCast(d, SortDirectory).fullName, SortSettings.dirType.BLOCKEDDIR)
        '            _blockedSettings.Add(DirectCast(d, SortDirectory))
        '        End If
        '    Next
        'ElseIf TypeOf RootDirView.SelectedItem Is SortDirectory AndAlso DirectCast(RootDirView.SelectedItem, SortDirectory).exists Then
        '    _sortSettings.addToDirList(DirectCast(RootDirView.SelectedItem, SortDirectory).fullName, SortSettings.dirType.BLOCKEDDIR)
        '    _blockedSettings.Add(DirectCast(RootDirView.SelectedItem, SortDirectory))
        'End If


        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.addToDirList(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, SortSettings.dirType.BLOCKEDDIR)
            _blockedSettings.Add(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory))
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

        RefreshCreateButton()
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
        Dim tempSortSettings = New SortSettings(_rootDirObj, _mainsSettings, _presortSettings, _blockedSettings)
        If Not tempSortSettings.IsValidSettings Then
            Dim result = MessageBox.Show("There was an error with one of the directories. Do you want to close and save with potential errors?", "Saving with errors!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.No Or result = DialogResult.Cancel Then
                Return
            End If
        End If
        Using _sortSettingsWriter = New IO.StreamWriter(_rootDir + "\.sortSettings.txt")
            _sortSettingsWriter.Write(tempSortSettings.toString)
            For Each m In _mainsSettings
                m.saveSubs()
            Next
        End Using
        _changedNotSaved = False
    End Sub

    Private Sub SettingsViewer_TextChanged(sender As Object, e As EventArgs) Handles SettingsViewer.TextChanged
        _changedNotSaved = True
    End Sub

    Private Sub ErrorTimer_Tick(sender As Object, e As EventArgs) Handles ErrorTimer.Tick
        ErrorTimer.Stop()
        TurnOffWarnings()
    End Sub

    Private Sub AddTagButton_Click(sender As Object, e As EventArgs) Handles AddTagButton.Click
        If TagIDEntry.Text IsNot Nothing AndAlso TagIDEntry.Text.Trim.Chars(TagIDEntry.Text.Length - 1) = "."c Then
            If TagsViewer.Items.Contains((TagIDEntry.Text & vbTab & TagDescEntry.Text.Trim).Trim) Then
                StatusLabel.Text = "This tag already exists"
                ErrorTimer.Start()
                Return
            Else
                TagsViewer.Items.Add((TagIDEntry.Text & vbTab & TagDescEntry.Text.Trim).Trim)
            End If
        End If
    End Sub

    Private Sub RemoveTagButton_Click(sender As Object, e As EventArgs) Handles RemoveTagButton.Click
        If TagsViewer.SelectedItem IsNot Nothing Then
            TagsViewer.Items.Remove(TagsViewer.SelectedItem)
        End If
    End Sub

    Private Sub TagsSaveButton_Click(sender As Object, e As EventArgs) Handles TagsSaveButton.Click
        Dim out = ""
        For Each item In TagsViewer.Items
            out = out & item.ToString & vbNewLine
        Next
        If TypeOf SettingsDirView.SelectedItem Is SortDirectory AndAlso DirectCast(SettingsDirView.SelectedItem, SortDirectory).type = SortSettings.dirType.MAINDIR Then
            DirectCast(SettingsDirView.SelectedItem, SortDirectory).saveTags(out)
        End If
    End Sub

    Private Sub TagsViewer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagsViewer.SelectedIndexChanged

    End Sub

    Private Sub RemoveDir_Click(sender As Object, e As EventArgs) Handles removeDir.Click
        Dim thing = SettingsDirView.SelectedItem
    End Sub

    Private Sub AddNewDir(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RootDirViewTree.Click
        Try
            If e.Button = MouseButtons.Right Then
                RootDirViewTree.SelectedNode = RootDirViewTree.GetNodeAt(e.X, e.Y)

                If RootDirViewTree.SelectedNode IsNot Nothing Then
                    Dim newName As String = InputBox("Add New Folder in: " + RootDirViewTree.SelectedNode.Text)
                    If newName IsNot Nothing AndAlso Not newName.Equals("") Then

                        Dim newFolder As String = IO.Directory.CreateDirectory(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName + "\" + newName).FullName
                        Dim curNode As TreeNode = RootDirViewTree.SelectedNode.Nodes.Add(New SortDirectory(newFolder).getName)
                        curNode.Tag = New SortDirectory(newFolder)
                    End If
                End If

            End If
        Catch ex As Exception
            StatusLabel.Text = "Problem making new folder: " + ex.Message
            ErrorTimer.Start()
        End Try

    End Sub
#End Region

End Class