Imports System.Text.RegularExpressions
Imports System.Diagnostics
Imports Windows.Storage
Public Class MainInterface
    Public Const _imgExtensions = ".png .jpg .jpeg .gif .bmp"
    Public Const _vidExtensions = ".mov .webm .wmv .mp4 .avi .mkv .m4v .m2ts .mpg .flv"
    Public Const _miscExtensions = ".zip .rar"

    Public Const SORTLOGFILENAME As String = "\SortWareMoveLogs.log"
    Public Const _1STAR = 1
    Public Const _2STAR = 25
    Public Const _3STAR = 50
    Public Const _4STAR = 75
    Public Const _5STAR = 99

    Private Const TAGIDREGEX = "^[^\t]+"

    Private _rating As UInteger = 0

    Private _extensions As List(Of String)
    Private selectedTags As String = ""

    Private _selectedFolderStack As Stack(Of SortDirectory) = New Stack(Of SortDirectory)
    Private _selectedFileStack As Stack(Of List(Of String)) = New Stack(Of List(Of String))

    Protected _innerDir As SortDirectory
    Protected _allowedExtensions As String = ""
    Protected _settings As SortSettings

    Private imgStream As IO.FileStream

    Private _logReader As IO.StreamReader
    Private _logWriter As IO.StreamWriter

    Private DataFolderDir As String = ""

    Public tempGif As IO.FileStream

    Public shortcut0, shortcut1, shortcut2, shortcut3, shortcut4, shortcut5, shortcut6, shortcut7, shortcut8, shortcut9 As String

    Private Sub MainInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ImageList1.Images.AddStrip(Global.SortWare.My.Resources.Resources.comctl32_125)
        'Me.moveUpDir.Image = ImageList1.Images(8)
        Me.moveUpDir.Image = My.Resources.Resources.shell32_255.ToBitmap
        Me.enterDir.Image = My.Resources.Resources.shell32_16805.ToBitmap
        Me.SaveRatingButton.Image = My.Resources.Resources.shell32_16761.ToBitmap
        Me.DeleteDirButton.Image = My.Resources.Resources.imageres_54.ToBitmap
        Me.PurgeAllEmptyDirsButton.Image = My.Resources.Resources.imageres_5305.ToBitmap

        Dim _settings As New SortSettings
        NormalTimer.Start()

        Dim itypes = _imgExtensions.Split(" "c)
        Dim vtypes = _vidExtensions.Split(" "c)
        Dim misctypes = _miscExtensions.Split(" "c)
        For Each i In itypes
            FileTypeCheckBox.Nodes.Item(0).Nodes.Add(i)
        Next
        For Each t In vtypes
            FileTypeCheckBox.Nodes.Item(1).Nodes.Add(t)
        Next
        For Each m In misctypes
            FileTypeCheckBox.Nodes.Item(2).Nodes.Add(m)
        Next
        FileTypeCheckBox.ExpandAll()
        Try
            getLogFile()
        Catch ex As Exception

        End Try
        TrackBar1_Scroll(Nothing, Nothing)

        DataFolderDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SortWare"
    End Sub

    Private Sub ButtonOnOff(ByRef button As Button, ByVal enable As Boolean)
        button.Enabled = enable
    End Sub

    Private Sub refreshPresortedFiles()
        FilesToBeSorted.Items.Clear()
        If _innerDir IsNot Nothing AndAlso IO.Directory.Exists(_innerDir.fullName) Then
            'Add the contents of the folder to Listbox1
            For Each file As String In IO.Directory.GetFiles(_innerDir.fullName, "*.*")
                If _allowedExtensions.Contains(IO.Path.GetExtension(file).ToLower) Then
                    FilesToBeSorted.Items.Add(file.Replace(PreSortedDirTextBox.Text, ""))
                End If
            Next
        End If
    End Sub

    Private Sub refreshPresortedFolders()
        FoldersToBeSorted.Items.Clear()
        If IO.Directory.Exists(_innerDir.fullName) Then
            For Each directory In IO.Directory.GetDirectories(_innerDir.fullName)
                FoldersToBeSorted.Items.Add(New SortDirectory(directory, 0))
            Next
        End If
    End Sub

    Private Sub refreshMainDirs()
        MainDirsBox.Items.Clear()
        addMains(_settings.getList(SortSettings.dirType.MAINDIR))
        'For Each m In _settings.getList(SortSettings.dirType.MAINDIR)
        '    MainDirsBox.Items.Add(m)
        '    If m.hasSubs Then
        '        For Each sd In m.getSubs
        '            MainDirsBox.Items.Add(sd)
        '        Next
        '    End If
        'Next
    End Sub

    Private Sub addMains(ByVal sdl As List(Of SortDirectory))
        For Each m As SortDirectory In sdl
            MainDirsBox.Items.Add(m)
            If m.hasSubs Then
                addMains(m.getSubs)
            End If
        Next
    End Sub

    Public Sub getLogFile()
        If System.IO.File.Exists(RootDirTextBox.Text + SORTLOGFILENAME) Then
            _logWriter = New IO.StreamWriter(RootDirTextBox.Text + SORTLOGFILENAME)
        Else
            Dim fs As IO.FileStream = IO.File.Create(RootDirTextBox.Text + SORTLOGFILENAME)
            fs.Close()
        End If
    End Sub

    Public Sub doMoveFile(ByVal file As String, ByVal targetDir As String, ByVal Optional tag As String = "")
        If Not IO.File.Exists(PreSortedDirTextBox.Text & file) Then
            Throw New Exception("File does not exist!")
        End If
        If Not IO.Directory.Exists(targetDir) Then
            Throw New Exception("Target directory does not exist!")
        End If

        'Try
        While VlcControl1.IsPlaying
            VlcControl1.Stop()
        End While
        If ImagePreview.Image IsNot Nothing Then
            ImagePreview.Image.Dispose()
            ImagePreview.Image = Nothing
        End If

        'Dim tempFile = New IO.FileInfo(file)
        Dim newName = tag + IO.Path.GetFileName(file)
        Dim src = PreSortedDirTextBox.Text & file
        Dim dest = targetDir & "\" & newName

        IO.File.Move(src, dest)

        writeToLogFile(src, dest, tag)
        'Catch ex As Exception

        'End Try

        FilesToBeSorted.Select()
    End Sub

    Public Sub doMoveDir(ByVal dir As SortDirectory, ByVal targetDir As String, ByVal Optional tag As String = "")
        'Dim ret As Boolean = True
        If Not IO.Directory.Exists(dir.fullName) Then
            Throw New Exception("Directory does not exist!")
        End If
        If Not IO.Directory.Exists(targetDir) Then
            Throw New Exception("Target directory does not exist!")
        End If

        Try
            VlcControl1.Stop()
            If ImagePreview.Image IsNot Nothing Then
                ImagePreview.Image.Dispose()
                ImagePreview.Image = Nothing
            End If

            Dim newName = tag + dir.getName
            Dim dest = targetDir & "\" & newName

            imgStream.Close()

            IO.Directory.Move(dir.fullName, dest)

            writeToLogFile(dir.fullName, dest, tag)
        Catch ex As Exception
            PropertiesSaveStatus.Text = ex.Message
        End Try

    End Sub

    Public Sub writeToLogFile(ByVal src As String, ByVal dest As String, ByVal tag As String)
        _logWriter = New IO.StreamWriter(RootDirTextBox.Text + SORTLOGFILENAME, True)
        _logWriter.WriteLine(System.DateTime.Now.ToString + vbTab + src + vbTab + dest + vbTab + tag)
        _logWriter.Close()
    End Sub

    Public Async Sub setRatingFromSelection()
        Dim path As String = ""
        Try
            Dim fileType = IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString)
            path = PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString
            Dim file = Await getStorageFile(path)
            If _vidExtensions.Contains(fileType) Then
                Dim prop = Await file.Properties.GetVideoPropertiesAsync()
                setStarRating(prop.Rating)
            ElseIf _imgExtensions.Contains(fileType) Then
                Dim prop = Await file.Properties.GetImagePropertiesAsync()
                setStarRating(prop.Rating)
            End If
        Catch ex As Exception
            PropertiesSaveStatus.Text = "Something went wrong, until to get file at " + path
        End Try
    End Sub

    Public Async Function getStorageFile(ByVal p As String) As Task(Of StorageFile)
        Try
            Return Await StorageFile.GetFileFromPathAsync(p)
        Catch e As Exception
            Return Nothing
        End Try
    End Function

    Private Sub setStarRating(ByVal rating As UInteger)
        StarRatingPanel.Enabled = True
        Select Case rating
            Case 0
                Star1.Checked = False
            Case _1STAR
                Star1.Checked = True
            Case _2STAR
                Star2.Checked = True
            Case _3STAR
                Star3.Checked = True
            Case _4STAR
                Star4.Checked = True
            Case _5STAR
                Star5.Checked = True
        End Select
    End Sub

    Private Sub StarRatingChanged(sender As Object, e As EventArgs) Handles Star1.CheckedChanged, Star2.CheckedChanged, Star3.CheckedChanged, Star4.CheckedChanged, Star5.CheckedChanged
        If TypeOf sender Is CheckBox Then
            If DirectCast(sender, CheckBox).Tag Is Nothing Then
                If DirectCast(sender, CheckBox) Is Star1 Then
                    RemoveHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    Star1.Checked = True
                    Star2.Checked = False
                    Star3.Checked = False
                    Star4.Checked = False
                    Star5.Checked = False
                    Star1.Tag = "Previously Clicked"
                    Star2.Tag = Nothing
                    Star3.Tag = Nothing
                    Star4.Tag = Nothing
                    Star5.Tag = Nothing

                    AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    If Star1.Checked Then
                        _rating = 1
                    Else
                        _rating = 0
                    End If
                ElseIf DirectCast(sender, CheckBox) Is Star2 Then
                    RemoveHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    Star1.Checked = True
                    Star2.Checked = True
                    Star3.Checked = False
                    Star4.Checked = False
                    Star5.Checked = False

                    Star1.Tag = Nothing
                    Star2.Tag = "Previously Clicked"
                    Star3.Tag = Nothing
                    Star4.Tag = Nothing
                    Star5.Tag = Nothing


                    AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    If Star2.Checked Then
                        _rating = 25
                    Else
                        _rating = 0
                    End If
                ElseIf DirectCast(sender, CheckBox) Is Star3 Then
                    RemoveHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    Star1.Checked = True
                    Star2.Checked = True
                    Star3.Checked = True
                    Star4.Checked = False
                    Star5.Checked = False
                    Star2.Tag = Nothing
                    Star2.Tag = Nothing
                    Star3.Tag = "Previously Clicked"
                    Star4.Tag = Nothing
                    Star5.Tag = Nothing

                    AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    If Star3.Checked Then
                        _rating = 50
                    Else
                        _rating = 0
                    End If
                ElseIf DirectCast(sender, CheckBox) Is Star4 Then
                    RemoveHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    Star1.Checked = True
                    Star2.Checked = True
                    Star3.Checked = True
                    Star4.Checked = True
                    Star5.Checked = False
                    Star2.Tag = Nothing
                    Star2.Tag = Nothing
                    Star3.Tag = Nothing
                    Star4.Tag = "Previously Clicked"
                    Star5.Tag = Nothing

                    AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    If Star4.Checked Then
                        _rating = 75
                    Else
                        _rating = 0
                    End If
                ElseIf DirectCast(sender, CheckBox) Is Star5 Then
                    RemoveHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    Star1.Checked = True
                    Star2.Checked = True
                    Star3.Checked = True
                    Star4.Checked = True
                    Star5.Checked = True
                    Star2.Tag = Nothing
                    Star2.Tag = Nothing
                    Star3.Tag = Nothing
                    Star4.Tag = Nothing
                    Star5.Tag = "Previously Clicked"

                    AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                    AddHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                    If Star5.Checked Then
                        _rating = 99
                    Else
                        _rating = 0
                    End If
                End If
            Else
                RemoveHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                Star1.Checked = False
                Star2.Checked = False
                Star3.Checked = False
                Star4.Checked = False
                Star5.Checked = False

                Star1.Tag = Nothing
                Star2.Tag = Nothing
                Star3.Tag = Nothing
                Star4.Tag = Nothing
                Star5.Tag = Nothing

                AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star5.CheckedChanged, AddressOf StarRatingChanged
            End If
        End If
    End Sub

    Private Sub FindFindRootDirButton_Click(sender As Object, e As EventArgs) Handles FindRootDirButton.Click

        Dim fbd As New FolderBrowserDialog
        If PreSortedDirTextBox.Text = "" Then
            fbd.RootFolder = Environment.SpecialFolder.MyComputer
        Else
            'fbd.RootFolder = 
        End If

        If fbd.ShowDialog = DialogResult.OK Then
            RootDirTextBox.Text = fbd.SelectedPath
            If Not System.IO.File.Exists(RootDirTextBox.Text & "\.sortSettings.txt") Then
                Debug.WriteLine(".sortSettings file non existent")
                OpenSortSettingsButton.BackColor = Color.Red
                OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon
                OpenSortSettingsButton.Text = ".sortSettings file not found!"
                StatusLabel.Text = ".sortSettings file not found"
                openLogsButton.Enabled = False
                MainDirsBox.Items.Clear()
            Else    'A .sortSettings file does exist
                _settings = New SortSettings(RootDirTextBox.Text)
                OpenSortSettingsButton.BackColor = SystemColors.Control
                OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black
                OpenSortSettingsButton.Text = "Open Folder Settings"
                openLogsButton.Enabled = True
                refreshMainDirs()
            End If
        End If

    End Sub

    Private Sub OpenSortSettingsButton_Click(sender As Object, e As EventArgs) Handles OpenSortSettingsButton.Click
        If RootDirTextBox.Text = "" Then
            StatusLabel.Text = "No Root Directory Selected"
            Return
        End If

        Dim _sortSettings = New SortSettingsDialog(RootDirTextBox.Text)

        _sortSettings.ShowDialog()

        If IO.File.Exists(RootDirTextBox.Text & "\.sortSettings.txt") Then
            OpenSortSettingsButton.BackColor = SystemColors.Control
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black
            OpenSortSettingsButton.Text = "Open Folder Settings"
        Else
            OpenSortSettingsButton.BackColor = Color.Red
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon
        End If

        refreshMainDirs()
    End Sub

    Private Sub FindPreSortedDirButton_Click(sender As Object, e As EventArgs) Handles FindPreSortedDirButton.Click
        Dim fbd As New FolderBrowserDialog
        fbd.RootFolder = Environment.SpecialFolder.MyComputer
        If fbd.ShowDialog = DialogResult.OK Then
            PreSortedDirTextBox.Text = fbd.SelectedPath
            _innerDir = New SortDirectory(PreSortedDirTextBox.Text, 0)

            refreshPresortedFiles()
            refreshPresortedFolders()
        End If

    End Sub

    Private Sub OpenPresortsButton_Click(sender As Object, e As EventArgs) Handles OpenPresortsButton.Click
        If _settings Is Nothing Or RootDirTextBox.Text = "" Then
            Return
        End If
        Dim selectedDir = New FolderSelector(_settings)
        If selectedDir.ShowDialog() = DialogResult.OK Then
            If TypeOf selectedDir.getSelectedDir() Is SortDirectory Then
                PreSortedDirTextBox.Text = selectedDir.getSelectedDir.fullName()
                _innerDir = New SortDirectory(PreSortedDirTextBox.Text, 0)
                refreshPresortedFiles()
                refreshPresortedFolders()
            End If
        End If
    End Sub

    Private Sub FileTypeCheckBox_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FileTypeCheckBox.AfterCheck, FileTypeCheckBox.AfterSelect
        RemoveHandler FileTypeCheckBox.AfterCheck, AddressOf FileTypeCheckBox_AfterSelect

        For Each node As TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next

        If e.Node.Checked Then
            If e.Node.Parent IsNot Nothing Then
                Dim allChecked As Boolean = True

                For Each node As TreeNode In e.Node.Parent.Nodes
                    If Not node.Checked Then
                        allChecked = False
                    End If
                Next

                If allChecked Then
                    e.Node.Parent.Checked = True
                End If
            End If
        Else
            If e.Node.Parent IsNot Nothing Then
                e.Node.Parent.Checked = False
            End If
        End If

        _allowedExtensions = ""
        For Each n As TreeNode In GetCheck(FileTypeCheckBox.Nodes)
            _allowedExtensions &= n.Text.Replace("/", " ") & " "
        Next

        AddHandler FileTypeCheckBox.AfterCheck, AddressOf FileTypeCheckBox_AfterSelect
        refreshPresortedFiles()
    End Sub

    Private Function GetCheck(ByVal node As TreeNodeCollection) As List(Of TreeNode)
        Dim lN As New List(Of TreeNode)
        For Each n As TreeNode In node
            If n.Checked AndAlso n.Tag Is Nothing Then
                lN.Add(n)
            End If
            lN.AddRange(GetCheck(n.Nodes))
        Next

        Return lN
    End Function

    Private Sub FilesToBeSorted_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilesToBeSorted.SelectedIndexChanged
        Dim fileType As Integer = -1
        Dim fileName As String = ""
        Try
            If TypeOf FilesToBeSorted.SelectedItem Is String Then
                fileName = CType(FilesToBeSorted.SelectedItem, String)
                If _imgExtensions.Contains(System.IO.Path.GetExtension(fileName.ToLower)) Then
                    fileType = 0
                ElseIf _vidExtensions.Contains(System.IO.Path.GetExtension(fileName.ToLower)) Then
                    fileType = 1
                End If
            Else
                Return
            End If

            Select Case (fileType)
                Case 0
                    If imgStream IsNot Nothing Then
                        imgStream.Close()
                    End If
                    If Not IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString).ToUpper.Contains("GIF") Then
                        imgStream = New IO.FileStream(PreSortedDirTextBox.Text & fileName, IO.FileMode.Open, IO.FileAccess.Read)
                        ImagePreview.Image = Image.FromStream(imgStream)
                        'imgStream.Close()
                    Else
                        'ImagePreview.Image = Image.FromFile(PreSortedDirTextBox.Text & fileName)'
                        Dim data() As Byte = IO.File.ReadAllBytes(PreSortedDirTextBox.Text & fileName)
                        IO.File.WriteAllBytes(RootDirTextBox.Text + "\temp.gif", data)
                        imgStream = New IO.FileStream(RootDirTextBox.Text + "\temp.gif", IO.FileMode.Open, IO.FileAccess.Read)
                        ImagePreview.Image = Image.FromStream(imgStream)
                        'imgStream.Close()
                    End If
                Case 1
                    Dim file As IO.FileInfo = New IO.FileInfo(PreSortedDirTextBox.Text & fileName)
                    VideoScrollBar.Value = 0
                    VlcControl1.SetMedia(file)
            End Select

            If Not IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString).ToUpper.Contains("GIF") Then
                setRatingFromSelection()
            End If

        Catch Ex As Exception
            MsgBox("Cannot Load File!", vbCritical, "Problem enountered while loading file!")
        End Try

    End Sub

    Private Sub FilesToBeSorted_MouseDown(sender As Object, e As MouseEventArgs) Handles FilesToBeSorted.MouseDown
        If e.Button = MouseButtons.Right Then
            FilesToBeSorted.ContextMenuStrip = ContextMenuStrip1
            FilesToBeSorted.SelectedIndices.Clear()
            FilesToBeSorted.SelectedIndex = FilesToBeSorted.IndexFromPoint(e.X, e.Y)
        End If
    End Sub

    Private Sub FilesToBeSorted_GotFocus(Sender As Object, e As EventArgs) Handles FilesToBeSorted.GotFocus
        MoveFilesButton.Enabled = True
        MoveFolderButton.Enabled = False
    End Sub

    Private Sub FoldersToBeSorted_GotFocus(Sender As Object, e As EventArgs) Handles FoldersToBeSorted.GotFocus
        MoveFilesButton.Enabled = False
        MoveFolderButton.Enabled = True
    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        VlcControl1.SetPause(VlcControl1.IsPlaying)
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        VlcControl1.Play()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles NormalTimer.Tick
        'If MouseButtons = MouseButtons.Left Then
        '    VlcControl1.Pause()
        'End If
        Try
            If VlcControl1.Length > 0 Then
                VideoScrollBar.Value = CInt((VlcControl1.Time / VlcControl1.Length) * 1000)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            VlcControl1.SetPause(Not VlcControl1.IsPlaying)
        End Try
    End Sub

    Private Sub VideoScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles VideoScrollBar.Scroll
        VlcControl1.Time = CInt((VideoScrollBar.Value * VlcControl1.Length) / 1000)
        'If VideoScrollBar.ClientRectangle.Contains(VlcControl1.PointToClient(Control.MousePosition)) Then
        '    Debug.WriteLine("here")
        '    Dim I As Integer = 0
        '    I = CInt(6 + VlcControl1.Time)
        'End If
    End Sub

    Private Sub VideoScrollBar_MouseDown(sender As Object, e As EventArgs) Handles VideoScrollBar.MouseHover
        Debug.WriteLine("down")
        VlcControl1.SetPause(True)
    End Sub
    Private Sub VideoScrollBar_MouseUp(sender As Object, e As EventArgs) Handles VideoScrollBar.MouseLeave
        Debug.WriteLine("up")
        VlcControl1.SetPause(False)
    End Sub

    Private Sub OpenLogsButton_Click(sender As Object, e As EventArgs) Handles openLogsButton.Click
        If System.IO.File.Exists(RootDirTextBox.Text & SORTLOGFILENAME) Then
            Dim reader As IO.TextReader = New IO.StreamReader(RootDirTextBox.Text & SORTLOGFILENAME)
            Dim logArr = Split(reader.ReadToEnd.Trim, vbNewLine)
            reader.Dispose()
            Dim lviewer As New LogViewer(logArr, Me)
            lviewer.Show()
        End If
    End Sub

    Private Sub MoveFilesButton_Click(sender As Object, e As EventArgs) Handles MoveFilesButton.Click
        If FilesToBeSorted.SelectedItems.Count > 0 AndAlso MainDirsBox.SelectedItem IsNot Nothing AndAlso TypeOf MainDirsBox.SelectedItem Is SortDirectory Then
            'Beep()
            Dim toResel = FilesToBeSorted.SelectedIndex
            Dim tagsToAdd = ""
            For Each t In TagsSelector.SelectedItems
                Dim m = Regex.Match(t, TAGIDREGEX)
                tagsToAdd = tagsToAdd & m.ToString
            Next

            Try
                imgStream.Close()
            Catch ex As Exception
                Beep()
            End Try

            For Each s In FilesToBeSorted.SelectedItems
                Try
                    doMoveFile(s, DirectCast(MainDirsBox.SelectedItem, SortDirectory).fullName, selectedTags)
                Catch ex As Exception
                    Beep()
                    If ex.Message.Contains("Cannot create a file When that file already exists.") Then
                        PropertiesSaveStatus.Text = "Something went wrong while attempting to move file"
                    Else
                        PropertiesSaveStatus.Text = ex.Message.Trim
                    End If
                End Try
            Next
            refreshPresortedFiles()
            If Not toResel >= FilesToBeSorted.Items.Count Then
                FilesToBeSorted.SelectedIndex = toResel
            End If
            FilesToBeSorted.Select()
        End If
    End Sub

    Private Sub MoveFolderButton_Click(sender As Object, e As EventArgs) Handles MoveFolderButton.Click
        If FoldersToBeSorted.SelectedItems.Count > 0 AndAlso MainDirsBox.SelectedItem IsNot Nothing AndAlso TypeOf MainDirsBox.SelectedItem Is SortDirectory Then
            Dim tagsToAdd = ""
            For Each t In TagsSelector.SelectedItems
                Dim m = Regex.Match(t, TAGIDREGEX)
                tagsToAdd = tagsToAdd & m.ToString
            Next
            For Each s In FoldersToBeSorted.SelectedItems
                doMoveDir(s, DirectCast(MainDirsBox.SelectedItem, SortDirectory).fullName, selectedTags)
            Next
            refreshPresortedFolders()
        End If
    End Sub

    Private Sub MoveUpDir_Click(sender As Object, e As EventArgs) Handles moveUpDir.Click
        If _innerDir IsNot Nothing AndAlso Not _innerDir.fullName = PreSortedDirTextBox.Text Then
            _innerDir = _innerDir.getParent
            refreshPresortedFiles()
            refreshPresortedFolders()
        End If
    End Sub

    Private Sub EnterDir_Click(sender As Object, e As EventArgs) Handles enterDir.Click
        If FoldersToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FoldersToBeSorted.SelectedItem Is SortDirectory Then
            _innerDir = DirectCast(FoldersToBeSorted.SelectedItem, SortDirectory)
            refreshPresortedFiles()
            refreshPresortedFolders()
        End If
    End Sub

    Private Sub OpenFile_Click(sender As Object, e As EventArgs) Handles openFile.MouseDown
        Dim mouseE = TryCast(e, MouseEventArgs)
        If mouseE IsNot Nothing Then
            If mouseE.Button = MouseButtons.Left AndAlso FilesToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FilesToBeSorted.SelectedItem Is String Then
                If System.IO.File.Exists(PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString) = True Then
                    Process.Start(PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString)
                Else
                    MsgBox("File Does Not Exist")
                End If
            ElseIf mouseE.Button = MouseButtons.Right AndAlso FilesToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FilesToBeSorted.SelectedItem Is String Then
                If System.IO.File.Exists(PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString) = True Then
                    Process.Start("explorer.exe", "/select, " + PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString)
                Else
                    MsgBox("File Does Not Exist")
                End If
            End If
        End If

    End Sub

    Private Sub MainDirsBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MainDirsBox.SelectedIndexChanged
        selectedTags = ""
        TagsSelector.Items.Clear()
        If TypeOf MainDirsBox.SelectedItem Is SortDirectory AndAlso DirectCast(MainDirsBox.SelectedItem, SortDirectory).hasTags Then
            TagsSelector.Items.AddRange(DirectCast(MainDirsBox.SelectedItem, SortDirectory).getTags)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles VolumeBar.Scroll
        VlcControl1.Audio.Volume = VolumeBar.Value
    End Sub

    Private Sub TagsSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagsSelector.SelectedIndexChanged
        If TagsSelector.SelectedItems.Count = 1 Then
            selectedTags = Regex.Match(TagsSelector.SelectedItem, TAGIDREGEX).ToString
        ElseIf TagsSelector.SelectedItems.Count > 1 Then
            selectedTags = selectedTags + Regex.Match(TagsSelector.SelectedItem, TAGIDREGEX).ToString
        Else    'Nothing was selected
            selectedTags = ""
        End If
    End Sub

    Private Sub SaveRatingButton_Click(sender As Object, e As EventArgs) Handles SaveRatingButton.Click
        saveRating()
    End Sub

    Private Async Sub saveRating()
        Dim path As String = ""
        Try
            path = PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString
        Catch ex As Exception
            Return
        End Try

        PropertiesSaveStatus.Text = ""

        Dim playHeadLoc = VideoScrollBar.Value
        VlcControl1.Stop()

        Try
            Dim fileType = IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString)
            Dim file = Await getStorageFile(path)

            Dim prop As FileProperties.IStorageItemExtraProperties
            If _vidExtensions.Contains(fileType) Then
                prop = Await file.Properties.GetVideoPropertiesAsync()
                DirectCast(prop, FileProperties.VideoProperties).Rating = _rating
                Await DirectCast(prop, FileProperties.VideoProperties).SavePropertiesAsync()
            ElseIf Not fileType.Equals(".gif") And Not fileType.Equals(".png") AndAlso _imgExtensions.Contains(fileType) Then

                Try
                    imgStream.Close()
                Catch ex2 As Exception
                    Throw New Exception("Error Closing imgStream")
                End Try

                prop = Await file.Properties.GetImagePropertiesAsync()
                DirectCast(prop, FileProperties.ImageProperties).Rating = _rating
                Await DirectCast(prop, FileProperties.ImageProperties).SavePropertiesAsync()
            ElseIf fileType.Equals(".gif") Or fileType.Equals(".png") Then
                Throw New Exception("This file type is NOT ratable!!!")
            End If

            PropertiesSaveStatus.Text = "Rating Successfully applied to " + IO.Path.GetFileName(path) + " | in directory " + IO.Path.GetDirectoryName(path)
        Catch ex As Exception
            PropertiesSaveStatus.Text = "File " + IO.Path.GetFileName(path) + " Is NOT ratable!"
            SaveRatingButton.BackColor = Color.Red
            AlertTimer.Start()
        Finally
            VlcControl1.SetMedia(path)
            VlcControl1.Play()
            VideoScrollBar.Value = playHeadLoc
        End Try

    End Sub

    Private Sub DeleteDirButton_Click(sender As Object, e As EventArgs) Handles DeleteDirButton.Click
        If FoldersToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FoldersToBeSorted.SelectedItem Is SortDirectory Then
            Dim path = DirectCast(FoldersToBeSorted.SelectedItem, SortDirectory).fullName
            If getFiles(path).Count > 0 Then
                'There are still files that exist!
                Dim result As Integer = MessageBox.Show("There are still files that exist in this folder or in its directories! Are you sure you want to delete this directory and lose all of the files in it?", "WARNING", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Or result = DialogResult.No Then
                    Return
                Else
                    If ImagePreview.Image IsNot Nothing AndAlso ImagePreview.ImageLocation.Contains(path) Then
                        ImagePreview.Image.Dispose()
                        ImagePreview.Image = Nothing
                    End If
                    Dim s As String = New Uri(VlcControl1.GetCurrentMedia.Mrl).LocalPath
                    If VlcControl1.IsPlaying AndAlso s.Contains(path) Then
                        VlcControl1.Stop()
                    End If
                End If
            End If
            Try
                IO.Directory.Delete(path, True)
                refreshPresortedFolders()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub PurgeAllEmptyDirsButton_Click(sender As Object, e As EventArgs) Handles PurgeAllEmptyDirsButton.Click
        If _innerDir IsNot Nothing Then
            For Each d In IO.Directory.GetDirectories(_innerDir.fullName)
                If getFiles(d).Count = 0 Then
                    Try
                        IO.Directory.Delete(d, True)
                    Catch ex As Exception
                        StatusStrip1.Text = "Could not delete folder: " + d
                    End Try
                Else
                    'There are still files that exist!
                End If
            Next
            refreshPresortedFolders()
        End If
    End Sub
    Private Sub VlcControl1_Click(sender As Object, e As EventArgs) Handles VlcControl1.MouseClick, VlcControl1.Click

    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        Try
            Dim rename As New RenameDialog(PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString)
            If ImagePreview.Image IsNot Nothing Then
                ImagePreview.Image.Dispose()
                ImagePreview.Image = Nothing
                imgStream.Close()
            End If
            VlcControl1.Stop()
            rename.ShowDialog()
            refreshPresortedFiles()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VlcControl1_MediaChanged(sender As Object, e As EventArgs) Handles VlcControl1.MediaChanged
        VlcControl1.Audio.Volume = VolumeBar.Value
        VlcControl1.Time = 0
        If Not autoPlay.Checked Then
            VlcControl1.SetPause(True)
        Else
            'VlcControl1.SetPause(False)
            VlcControl1.Play()

        End If

    End Sub

    Private Sub UnderScoreAddUpDown_ValueChanged(sender As Object, e As EventArgs) Handles UnderScoreAddUpDown.ValueChanged
        AddUnderScoreButton.Text = "Add " + CType(UnderScoreAddUpDown.Value, String) + " ""_"""
    End Sub

    Private Sub AddUnderScoreButton_Click(sender As Object, e As EventArgs) Handles AddUnderScoreButton.Click
        If MoveFilesButton.Enabled AndAlso Not MoveFolderButton.Enabled Then    'This means that a file was last selected
            If FilesToBeSorted.SelectedItems.Count > 0 Then
                Dim toResel As Integer = FilesToBeSorted.SelectedIndex
                Try
                    If imgStream IsNot Nothing Then
                        Try
                            imgStream.Close()
                        Catch ex2 As Exception
                            Throw New Exception("Error Closing imgStream")
                        End Try
                    End If


                    VlcControl1.Stop()
                    For Each f In FilesToBeSorted.SelectedItems
                        If TypeOf f Is String Then
                            Dim fi As New IO.FileInfo(PreSortedDirTextBox.Text + DirectCast(f, String)) 'Get the fileInfo object for the file in question so renaming will be easier
                            Dim tag = New String("_"c, CType(UnderScoreAddUpDown.Value, Integer))
                            Dim newName = tag + fi.Name
                            My.Computer.FileSystem.RenameFile(fi.FullName, newName)
                        End If
                    Next
                Catch ex As Exception

                End Try
                refreshPresortedFiles()
                FilesToBeSorted.SelectedItem = FilesToBeSorted.Items.Item(toResel)
            End If
        End If

    End Sub

    Public Shared Function getFiles(ByVal path As String) As List(Of String)
        Dim ret As List(Of String)
        ret = IO.Directory.GetFiles(path).ToList
        For Each d In IO.Directory.GetDirectories(path)
            Dim Temp = getFiles(d)
            ret.AddRange(Temp)
        Next

        Return ret
    End Function

    Private Sub AlertTimer_Tick(sender As Object, e As EventArgs) Handles AlertTimer.Tick
        SaveRatingButton.BackColor = SystemColors.Control
        AlertTimer.Stop()
    End Sub

    Private Sub HandleKeys(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete ', Keys.Back
                VlcControl1.Stop()
                Dim indMax As UInteger = UInteger.MinValue
                Dim indMin As UInteger = UInteger.MaxValue
                For Each s As String In FilesToBeSorted.SelectedItems

                    'Find the min and max indices (this will help us select which item to reselect when the listview is refreshed.
                    If FilesToBeSorted.Items.IndexOf(s) > indMax Then
                        indMax = CUInt(FilesToBeSorted.Items.IndexOf(s))
                    End If
                    If FilesToBeSorted.Items.IndexOf(s) < indMin Then
                        indMin = CUInt(FilesToBeSorted.Items.IndexOf(s))
                    End If

                    doDelete(PreSortedDirTextBox.Text + s)
                Next
                refreshPresortedFiles()

                If FilesToBeSorted.Items.Count = 0 Then

                ElseIf indMax >= FilesToBeSorted.Items.Count Then
                    FilesToBeSorted.SelectedIndex = FilesToBeSorted.Items.Count - 1
                ElseIf indMax <= FIlesToBeSorted.Items.Count Then
                    FilesToBeSorted.SelectedIndex = CInt(indMax)
                ElseIf indMin <= FilesToBeSorted.Items.Count Then
                    FilesToBeSorted.SelectedIndex = CInt(indMin)
                End If

            Case Keys.Space
                VlcControl1.Pause()
            Case Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9
                If MainDirsBox.Focused Then
                    If Not MainDirsBox.SelectedIndex = -1 And MainDirsBox.SelectedItems.Count = 1 Then
                        Select Case e.KeyCode
                            Case Keys.D0
                                'MainDir Keys.D1
                                'sBox.SelectedIndex
                            Case Keys.D1

                            Case Keys.D2

                            Case Keys.D3

                            Case Keys.D4

                            Case Keys.D5

                            Case Keys.D6

                            Case Keys.D7

                            Case Keys.D8

                            Case Keys.D9
                        End Select
                    Else
                        Beep()
                    End If
                End If
            Case Keys.Enter
                MoveFilesButton_Click(Nothing, Nothing)
                FilesToBeSorted.Select()
        End Select

    End Sub

    Private Sub doDelete(ByVal path As String)
        Try
            'IO.File.Delete(path)
            Dim dest = New IO.FileInfo(RootDirTextBox.Text + "\toBeDeleted\" + IO.Path.GetFileName(path))
            If _imgExtensions.Contains(dest.Extension) Then
                If ImagePreview.Image IsNot Nothing Then
                    ImagePreview.Image.Dispose()
                    ImagePreview.Image = Nothing
                End If

                If imgStream IsNot Nothing Then
                    imgStream.Close()
                End If

            End If
            dest.Directory.Create()

            IO.File.Move(path, dest.FullName)
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Sub DupeCheckerButton_Click(sender As Object, e As EventArgs) Handles DupeCheckerButton.Click
        Dim cd As CheckDupes
        If ActiveControl IsNot Nothing AndAlso ActiveControl Is MainDirsBox AndAlso MainDirsBox.SelectedItem IsNot Nothing Then
            cd = New CheckDupes(DirectCast(MainDirsBox.SelectedItem, SortDirectory))
        End If

        If FoldersToBeSorted.SelectedItem IsNot Nothing Then
            cd = New CheckDupes(DirectCast(FoldersToBeSorted.SelectedItem, SortDirectory))
        ElseIf PreSortedDirTextBox.Text IsNot Nothing AndAlso Not PreSortedDirTextBox.Text.Equals("") Then
            cd = New CheckDupes(New SortDirectory(PreSortedDirTextBox.Text))
        End If

        If cd IsNot Nothing Then
            cd.ShowDialog()
            cd.Dispose()
        End If
    End Sub

    Private Sub Views_CheckedChanged(sender As Object, e As EventArgs) Handles ImageCheck.CheckedChanged, VideoCheck.CheckedChanged
        Dim styles As TableLayoutColumnStyleCollection = MediaPanel.ColumnStyles

        If styles.Count < 2 Then Return

        If ImageCheck.Checked And VideoCheck.Checked Then
            For Each style As ColumnStyle In styles
                style.SizeType = SizeType.Percent
                style.Width = 50
            Next
        ElseIf ImageCheck.Checked And Not VideoCheck.Checked Then
            styles.Item(0).SizeType = SizeType.Percent
            styles.Item(0).Width = 100
            styles.Item(1).SizeType = SizeType.Absolute
            styles.Item(1).Width = 0
        ElseIf Not ImageCheck.Checked And VideoCheck.Checked Then
            ImagePreview.Image = Nothing
            styles.Item(1).SizeType = SizeType.Percent
            styles.Item(1).Width = 100
            styles.Item(0).SizeType = SizeType.Absolute
            styles.Item(0).Width = 0
        ElseIf Not ImageCheck.Checked And Not VideoCheck.Checked Then
            ImagePreview.Image = Nothing
            styles.Item(0).SizeType = SizeType.Absolute
            styles.Item(0).Width = 0
            styles.Item(1).SizeType = SizeType.Absolute
            styles.Item(1).Width = 0
        End If

    End Sub

    'Private Sub markFilesForMove()
    '    For Each s As String In FilesToBeSorted.SelectedItems
    '        For Each lvi As ListViewItem In FilesToBeMovedView.Items
    '            If lvi.
    '        Next
    '    Next
    'End Sub
End Class
