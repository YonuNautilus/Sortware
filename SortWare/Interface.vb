Imports System.Text.RegularExpressions
Imports Windows.Storage
Public Class MainInterface
    Public Const _imgExtensions = ".png .jpg .jpeg .gif"
    Public Const _vidExtensions = ".mov .webm .mp4 .avi"

    Public Const SORTLOGFILENAME = "\SortWareMoveLogs.log"
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

    Private _logReader As IO.StreamReader
    Private _logWriter As IO.StreamWriter
    Private Sub MainInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ImageList1.Images.AddStrip(Global.SortWare.My.Resources.Resources.comctl32_125)
        'Me.moveUpDir.Image = ImageList1.Images(8)
        Me.moveUpDir.Image = My.Resources.Resources.shell32_255.ToBitmap
        Me.enterDir.Image = My.Resources.Resources.shell32_16805.ToBitmap
        Me.SaveRatingButton.Image = My.Resources.Resources.shell32_16761.ToBitmap

        Dim _settings As New SortSettings
        Timer1.Start()
        FileTypeCheckBox.ExpandAll()
        getLogFile()
        TrackBar1_Scroll(Nothing, Nothing)
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
        For Each m In _settings.getList(SortSettings.dirType.MAINDIR)
            MainDirsBox.Items.Add(m)
        Next
    End Sub

    Public Sub getLogFile()
        If System.IO.File.Exists(IO.Directory.GetCurrentDirectory + SORTLOGFILENAME) Then
            _logWriter = New IO.StreamWriter(IO.Directory.GetCurrentDirectory + SORTLOGFILENAME)
        Else
            Dim fs As IO.FileStream = IO.File.Create(RootDirTextBox.Text + SORTLOGFILENAME)
            fs.Close()
        End If
    End Sub

    Public Sub doMove(ByVal file As String, ByVal targetDir As String, ByVal Optional tag As String = "")
        'Dim ret As Boolean = True
        If Not IO.File.Exists(_innerDir.fullName & file) Then
            Throw New Exception("File does not exist!")
        End If
        If Not IO.Directory.Exists(targetDir) Then
            Throw New Exception("Target directory does not exist!")
        End If

        Try
            VlcControl1.Stop()
            If ImagePreview.Image IsNot Nothing Then
                ImagePreview.Image.Dispose()
            End If

            Dim tempFile = New IO.FileInfo(file)
            Dim newName = tag + file.Substring(1)
            Dim src = _innerDir.fullName & file
            Dim dest = targetDir & "\" & newName
            IO.File.Move(src, dest)

            writeToLogFile(src, dest, tag)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub writeToLogFile(ByVal src As String, ByVal dest As String, ByVal tag As String)
        _logWriter = New IO.StreamWriter(RootDirTextBox.Text + SORTLOGFILENAME, True)
        _logWriter.WriteLine(System.DateTime.Now.ToString + vbTab + src + vbTab + dest + vbTab + tag)
        _logWriter.Close()
    End Sub

    Public Async Sub setRatingFromSelection()
        Try
            Dim fileType = IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString)
            Dim path = PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString
            Dim file = Await getStorageFile(path)
            If _vidExtensions.Contains(fileType) Then
                Dim prop = Await file.Properties.GetVideoPropertiesAsync()
                setStarRating(prop.Rating)
            ElseIf _imgExtensions.Contains(fileType) Then
                Dim prop = Await file.Properties.GetImagePropertiesAsync()
                setStarRating(prop.Rating)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Async Function getStorageFile(ByVal p As String) As Task(Of StorageFile)
        Return Await StorageFile.GetFileFromPathAsync(p)
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
            If DirectCast(sender, CheckBox) Is Star1 Then
                RemoveHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                Star2.Checked = False
                Star3.Checked = False
                Star4.Checked = False
                Star5.Checked = False

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
                RemoveHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                If Star2.Checked Then
                    Star1.Checked = True
                Else
                    Star1.Checked = False
                    Star3.Checked = False
                    Star4.Checked = False
                    Star5.Checked = False
                End If

                AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
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
                RemoveHandler Star4.CheckedChanged, AddressOf StarRatingChanged
                RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                If Star3.Checked Then
                    Star1.Checked = True
                    Star2.Checked = True
                Else
                    Star1.Checked = False
                    Star2.Checked = False
                    Star4.Checked = False
                    Star5.Checked = False
                End If

                AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
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
                RemoveHandler Star5.CheckedChanged, AddressOf StarRatingChanged

                If Star4.Checked Then
                    Star1.Checked = True
                    Star2.Checked = True
                    Star3.Checked = True
                Else
                    Star1.Checked = False
                    Star2.Checked = False
                    Star3.Checked = False
                    Star5.Checked = False
                End If

                AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
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

                If Star5.Checked Then
                    Star1.Checked = True
                    Star2.Checked = True
                    Star3.Checked = True
                    Star4.Checked = True
                Else
                    Star1.Checked = False
                    Star2.Checked = False
                    Star3.Checked = False
                    Star4.Checked = False
                End If

                AddHandler Star1.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star2.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star3.CheckedChanged, AddressOf StarRatingChanged
                AddHandler Star4.CheckedChanged, AddressOf StarRatingChanged

                If Star5.Checked Then
                    _rating = 99
                Else
                    _rating = 0
                End If
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
        If TypeOf FilesToBeSorted.SelectedItem Is String Then
            fileName = CType(FilesToBeSorted.SelectedItem, String)
            If _imgExtensions.Contains(System.IO.Path.GetExtension(fileName)) Then
                fileType = 0
            ElseIf _vidExtensions.Contains(System.IO.Path.GetExtension(fileName)) Then
                fileType = 1
            End If
        Else
            Return
        End If

        Select Case (fileType)
            Case 0
                'ImagePreview.Image = Image.FromFile(PreSortedDirTextBox.Text & fileName)
                Dim fs As IO.FileStream = New IO.FileStream(PreSortedDirTextBox.Text & fileName, IO.FileMode.Open, IO.FileAccess.Read)
                ImagePreview.Image = Image.FromStream(fs)
                fs.Close()
            Case 1
                Dim file As IO.FileInfo = New IO.FileInfo(PreSortedDirTextBox.Text & fileName)
                VideoScrollBar.Value = 0
                VlcControl1.SetMedia(file)
                VlcControl1.Time = 0
                VlcControl1.Play()
                VlcControl1.SetPause(False)
                If Not autoPlay.Checked Then
                    Threading.Thread.Sleep(100)
                    VlcControl1.SetPause(True)
                Else
                    PlayButton_Click(sender, e)
                End If
        End Select
        setRatingFromSelection()

    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        VlcControl1.SetPause(VlcControl1.IsPlaying)
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        VlcControl1.Play()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If MouseButtons = MouseButtons.Left Then
        '    VlcControl1.Pause()
        'End If
        Try
            VideoScrollBar.Value = CInt((VlcControl1.Time / VlcControl1.Length) * 1000)
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
            Dim tagsToAdd = ""
            For Each t In TagsSelector.SelectedItems
                Dim m = Regex.Match(t, TAGIDREGEX)
                tagsToAdd = tagsToAdd & m.ToString
            Next
            For Each s In FilesToBeSorted.SelectedItems
                doMove(s, DirectCast(MainDirsBox.SelectedItem, SortDirectory).fullName, tagsToAdd)
            Next
            refreshPresortedFiles()
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

    Private Sub OpenFile_Click(sender As Object, e As EventArgs) Handles openFile.Click
        If FilesToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FilesToBeSorted.SelectedItem Is String Then
            If System.IO.File.Exists(FilesToBeSorted.SelectedItem.ToString) = True Then
                Process.Start(FilesToBeSorted.SelectedItem.ToString)
            Else
                MsgBox("File Does Not Exist")
            End If
        End If
    End Sub

    Private Sub MainDirsBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MainDirsBox.SelectedIndexChanged
        TagsSelector.Items.Clear()
        If TypeOf MainDirsBox.SelectedItem Is SortDirectory AndAlso DirectCast(MainDirsBox.SelectedItem, SortDirectory).hasTags Then
            TagsSelector.Items.AddRange(DirectCast(MainDirsBox.SelectedItem, SortDirectory).getTags)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        VlcControl1.Audio.Volume = TrackBar1.Value
    End Sub

    Private Async Sub PropertiesViewButton_ClickAsync(sender As Object, e As EventArgs) Handles PropertiesViewButton.Click
        Try
            Dim fileType = IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString)

            Dim path = PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString

            Select Case (fileType)
                Case ".mp4"
                    Dim file As StorageFile = Await StorageFile.GetFileFromPathAsync(path)
                    Dim prop = Await file.Properties.GetVideoPropertiesAsync()
                    Dim v As New PropertiesViewerInterface
            End Select
        Catch ex As Exception

        End Try
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

        Dim playHeadLoc = VideoScrollBar.Value
        Dim path = PreSortedDirTextBox.Text & FilesToBeSorted.SelectedItem.ToString
        VlcControl1.Stop()

        Try
            Dim fileType = IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString)
            Dim file = Await getStorageFile(path)

            Dim prop
            If _vidExtensions.Contains(fileType) Then
                prop = Await file.Properties.GetVideoPropertiesAsync()
                prop.Rating = _rating
                Await DirectCast(prop, FileProperties.VideoProperties).SavePropertiesAsync()
            ElseIf Not (fileType.Equals(".gif") Or fileType.Equals(".png")) AndAlso _imgExtensions.Contains(fileType) Then
                prop = Await file.Properties.GetImagePropertiesAsync()
                prop.Rating = _rating
                Await DirectCast(prop, FileProperties.ImageProperties).SavePropertiesAsync()
            End If
        Catch ex As Exception

        Finally
            VlcControl1.SetMedia(path)
            VlcControl1.Play()
            VideoScrollBar.Value = playHeadLoc
        End Try
    End Sub
End Class
