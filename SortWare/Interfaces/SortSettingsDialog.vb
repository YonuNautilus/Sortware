Imports System.Xml

Public Class SortSettingsDialog

    Private _sortSettings As SortSettings
    Private _rootDir As String
    Private _rootDirObj As SortDirectory
    Private _sortSettingsReader As IO.StreamReader
    Private _sortSettingsWriter As IO.StreamWriter

    Private _mainsSettings As New List(Of SortDirectory)
    Private _presortSettings As New List(Of SortDirectory)
    Private _blockedSettings As New List(Of SortDirectory)
    Private _convertSettings As New List(Of SortDirectory)
    Private _finished As SortDirectory

    Private _changedNotSaved As Boolean = False

    Private _rootNode As TreeNode
    Private _mainNode As TreeNode
    Private _presortNode As TreeNode
    Private _blockedNode As TreeNode
    Private _convNode As TreeNode
    Private _finishedNode As TreeNode

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

        If IO.File.Exists(_rootDir & "\sortSettings.xml") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If

        SettingsTreeView.Nodes.Clear()

        _rootNode = SettingsTreeView.Nodes.Add("Root Directory")
        _mainNode = SettingsTreeView.Nodes.Add("Main Directories")
        _presortNode = SettingsTreeView.Nodes.Add("Presorted Directories")
        _blockedNode = SettingsTreeView.Nodes.Add("Blocked Directories")
        _convNode = SettingsTreeView.Nodes.Add("Conversion Directories")
        _finishedNode = SettingsTreeView.Nodes.Add("Finished Conversion Directories")

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
            refreshDirView()
        End If
    End Sub

    Private Sub initSettingsList()
        _rootDirObj = _sortSettings.rootDir
        _mainsSettings = _sortSettings.getList(SortSettings.dirType.MAINDIR)
        _presortSettings = _sortSettings.getList(SortSettings.dirType.PRESORTDIR)
        _convertSettings = _sortSettings.getList(SortSettings.dirType.CONVERTDIR)
        If (_sortSettings.getFinished IsNot Nothing) Then
            _finished = _sortSettings.getFinished
        End If
        _blockedSettings = _sortSettings.getList(SortSettings.dirType.BLOCKEDDIR)
    End Sub
    Private Sub refreshSettings()
        refreshDirView()
        SettingsViewer.Text = _sortSettings.toString()
    End Sub

    Private Sub refreshDirView()
        For Each n As TreeNode In SettingsTreeView.Nodes
            n.Nodes.Clear()
        Next

        initSettingsList()

        Dim tempNode = _rootNode.Nodes.Add(_rootDirObj.fullName)
        tempNode.Tag = _rootDirObj

        tempNode = _finishedNode.Nodes.Add(_finished.fullName)
        tempNode.Tag = _finished

        addDirs(_mainNode, _mainsSettings)
        addDirs(_presortNode, _presortSettings)
        addDirs(_blockedNode, _blockedSettings)
        addDirs(_convNode, _convertSettings)
    End Sub

    Private Sub addDirs(ByRef parent As TreeNode, ByVal _list As List(Of SortDirectory))
        For Each sd As SortDirectory In _list
            Dim currentNew As TreeNode = parent.Nodes.Add(sd.fullName)
            currentNew.Tag = sd
            If sd.hasSubs Then
                addDirs(currentNew, sd.getSubs)
            End If
        Next
    End Sub

    Public Sub refreshTagsViewer()
        TagsViewer.Items.Clear()
        If SettingsTreeView.SelectedNode.Tag IsNot Nothing AndAlso TypeOf SettingsTreeView.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).type = SortSettings.dirType.MAINDIR Then
            If DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).hasTags Then
                Dim tagArr = DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).getTags
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

            Dim currentNode As TreeNode = RootDirViewTree.Nodes.Add(New SortDirectory(Dir).getName())
            currentNode.Tag = New SortDirectory(Dir)
            populateDirs(currentNode, Dir)
        Next
    End Sub

    Private Sub populateDirs(ByRef node As TreeNode, ByVal _dir As String)
        Try
            For Each Dir As String In IO.Directory.GetDirectories(_dir)
                Dim currentNode As TreeNode = node.Nodes.Add(New SortDirectory(Dir).getName())
                currentNode.Tag = New SortDirectory(Dir)
                populateDirs(currentNode, Dir)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshCreateButton()
        If IO.File.Exists(_rootDir & "\.sortSettings.txt") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If
    End Sub

    Private Sub RefreshAddButtons(sender As Object, e As EventArgs) Handles SettingsTreeView.AfterSelect, RootDirViewTree.NodeMouseClick
        If TypeOf sender Is Control Then
            Select Case DirectCast(sender, Control).Name
                Case RootDirViewTree.Name
                    addRootDir.Enabled = True
                    addMainDir.Enabled = True
                    addMainSubdir.Enabled = True
                    addPresortDir.Enabled = True
                    addBlockedDir.Enabled = True
                    removeDir.Enabled = False
                Case SettingsTreeView.Name
                    addRootDir.Enabled = False
                    addMainDir.Enabled = False
                    addMainSubdir.Enabled = False
                    addPresortDir.Enabled = False
                    addBlockedDir.Enabled = False
                    removeDir.Enabled = True
                    refreshTagsViewer()
                Case Else
                    addRootDir.Enabled = False
                    addMainDir.Enabled = False
                    addMainSubdir.Enabled = False
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
        If RootDirViewTree.SelectedNode Is Nothing Then
            Return
        End If

        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.setDir(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName)
        End If

        refreshSettings()
    End Sub

    Private Sub AddMainDir_Click(sender As Object, e As EventArgs) Handles addMainDir.Click
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
        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso SettingsTreeView.SelectedNode.Tag IsNot Nothing AndAlso TypeOf SettingsTreeView.SelectedNode.Tag Is SortDirectory Then
            'Then check that the selected settingsDir is a main Dir, and that the rootDir item contains the path of the selected MainDirectory
            If DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).type = SortSettings.dirType.MAINDIR AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName.Contains(DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).fullName) Then
                DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).addSubDir(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName)
            End If
        End If
        refreshSettings()
    End Sub

    Private Sub AddPresortDir_Click(sender As Object, e As EventArgs) Handles addPresortDir.Click
        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.addToDirList(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, SortSettings.dirType.PRESORTDIR)
            _presortSettings.Add(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory))
        End If

        refreshSettings()
    End Sub

    Private Sub AddConvertDir_Click(sender As Object, e As EventArgs) Handles addConvertDir.Click
        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            Dim name As String = InputBox("Enter a Title for this Conversion Folder")

            Dim ofd As New OpenFileDialog
            ofd.InitialDirectory = DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName
            ofd.Filter = "Bat Files (*.bat)|*.bat|All Files (*.*)|(*.*)"

            Dim scriptPath As String

            If ofd.ShowDialog = DialogResult.OK Then
                scriptPath = ofd.FileName
            Else
                Return
            End If

            Dim cdts = New ConvDirTypeSelector
            cdts.ShowDialog(Me)
            Dim type As String = cdts.Tag

            If name IsNot Nothing OrElse Not name.Equals("") Then
                _sortSettings.addToDirList(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, SortSettings.dirType.CONVERTDIR, name, scriptPath)
                _convertSettings.Add(New SortDirectory(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, 3, SortSettings.dirType.CONVERTDIR, False, name, scriptPath))
            End If

            refreshSettings()
        End If
    End Sub

    Private Sub AddFinishedDir_Click(sender As Object, e As EventArgs) Handles addFinishedDir.Click
        If RootDirViewTree.SelectedNode.Tag IsNot Nothing AndAlso TypeOf RootDirViewTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).exists Then
            _sortSettings.addToDirList(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, SortSettings.dirType.FINISHEDDIR)
            _finished = New SortDirectory(DirectCast(RootDirViewTree.SelectedNode.Tag, SortDirectory).fullName, 3)
        End If

        refreshSettings()
    End Sub

    Private Sub RemoveDir_Click(sender As Object, e As EventArgs) Handles removeDir.Click
        Dim thing = SettingsTreeView.SelectedNode.Tag

        If thing IsNot Nothing AndAlso TypeOf thing Is SortDirectory Then
            Dim selSortDir As SortDirectory = DirectCast(thing, SortDirectory)
            _sortSettings.removeFromDirList(selSortDir.fullName, selSortDir.type)
        End If

        'If SettingsTreeView.SelectedItem IsNot Nothing AndAlso TypeOf SettingsTreeView.SelectedItem Is SortDirectory Then
        '    _sortSettings.removeFromDirList(DirectCast(thing, SortDirectory).fullName, DirectCast()
        '    If DirectCast(thing, SortDirectory).type = SortSettings.dirType.MAINDIR Then
        '        If DirectCast(thing, SortDirectory).isSubDir Then
        '            searchAndDestroySub
        '        End If
        '    Else

        '    End If
        'End If

        refreshSettings()
    End Sub

    Private Sub InitializeSettings_Click(sender As Object, e As EventArgs) Handles InitializeSettings.Click
        Dim xws As XmlWriterSettings = New XmlWriterSettings
        xws.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(_rootDir + "\sortSettings.xml", xws)
            writer.WriteStartDocument()
            writer.WriteStartElement("rootDir")
            writer.WriteAttributeString("dir", _rootDir)

            writer.WriteStartElement("mains")
            writer.WriteFullEndElement()

            writer.WriteStartElement("presorts")
            writer.WriteFullEndElement()

            writer.WriteStartElement("convert")
            writer.WriteFullEndElement()

            writer.WriteStartElement("finished")
            writer.WriteFullEndElement()

            writer.WriteFullEndElement()
            writer.Close()
        End Using



        'Dim fs As IO.FileStream = IO.File.Create(_rootDir & "\.sortSettings.txt")
        'fs.Close()
        ''IO.File.Create(_rootDir & "\.sortSettings.txt", IO.FileMode.CreateNew)
        ''IO.File.SetAttributes(_rootDir & "\.sortSettings.txt", IO.FileAttributes.Hidden)

        'Using _sortSettingsWriter = New IO.StreamWriter(_rootDir + "\.sortSettings.txt")
        '    _sortSettingsWriter.Write("Root: " + _rootDir + vbNewLine + "#" + TWOLINE + "Mains:" + vbNewLine + "#" + TWOLINE + "Presorts:" + vbNewLine + "#" + TWOLINE + "Blocked:" + vbNewLine + "#")
        'End Using

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
        Dim tempSortSettings = New SortSettings(_rootDirObj, _mainsSettings, _presortSettings, _blockedSettings, _convertSettings, _finished)
        If Not tempSortSettings.IsValidSettings Then
            Dim result = MessageBox.Show("There was an error with one of the directories. Do you want to close and save with potential errors?", "Saving with errors!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.No Or result = DialogResult.Cancel Then
                Return
            End If
        End If

        _sortSettings.SaveSettingsXML()

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
        If TypeOf SettingsTreeView.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).type = SortSettings.dirType.MAINDIR Then
            DirectCast(SettingsTreeView.SelectedNode.Tag, SortDirectory).saveTags(out)
        End If
    End Sub

    Private Sub TagsViewer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagsViewer.SelectedIndexChanged

    End Sub

    Private Sub AddNewDir(ByVal sender As System.Object, ByVal e As EventArgs) Handles RootDirViewTree.Click
        Try
            If TypeOf e Is MouseEventArgs AndAlso DirectCast(e, MouseEventArgs).Button = MouseButtons.Right Then
                RootDirViewTree.SelectedNode = RootDirViewTree.GetNodeAt(DirectCast(e, MouseEventArgs).X, DirectCast(e, MouseEventArgs).Y)

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