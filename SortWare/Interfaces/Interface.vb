Imports System.Text.RegularExpressions
Imports System.Diagnostics
Imports Windows.Storage
Public Class MainInterface
    Public Const _imgExtensions = ".png .jpg .jpeg .jfif .tif .tiff .gif .bmp"
    Public Const _vidExtensions = ".mov .webm .wmv .mp4 .avi .mkv .m4v .m2ts .mts .mpg .flv"
    Public Const _miscExtensions = ".zip .rar"

    Public Const SORTLOGFILENAME As String = "\SortWareMoveLogs.log"
    Public Const _1STAR = 1
    Public Const _2STAR = 25
    Public Const _3STAR = 50
    Public Const _4STAR = 75
    Public Const _5STAR = 99

    Private _rating As UInteger = 0

    Private Const TAGIDREGEX = "^[^\t]+"

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

    Public clickedOn As Integer = -1

    Private sortByDefault As String = "----"
    Private sortByDate As String = "Date"
    Private sortByName As String = "Name"
    Private sortBySize As String = "Size"
    Private sortByType As String = "Filetype"
    Private sortBys As String() = {sortByDefault, sortByDate, sortByName, sortBySize, sortByType}

    Public shortcut0, shortcut1, shortcut2, shortcut3, shortcut4, shortcut5, shortcut6, shortcut7, shortcut8, shortcut9 As String

    Private Sub MainInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ImageList1.Images.AddStrip(Global.SortWare.My.Resources.Resources.comctl32_125)
        'Me.moveUpDir.Image = ImageList1.Images(8)
        Me.moveUpDir.Image = My.Resources.Resources.shell32_255.ToBitmap
        Me.enterDir.Image = My.Resources.Resources.shell32_16805.ToBitmap
        Me.SaveRatingButton.Image = My.Resources.Resources.shell32_16761.ToBitmap
        Me.DeleteDirButton.Image = My.Resources.Resources.imageres_54.ToBitmap
        Me.PurgeAllEmptyDirsButton.Image = My.Resources.Resources.imageres_5305.ToBitmap

        Me.SortByComboBox.Items.Clear()

        For Each s As String In sortBys
            Me.SortByComboBox.Items.Add(s)
        Next

        Dim _settings As New SortSettings
        NormalTimer.Start()

        Try
            getLogFile()
        Catch ex As Exception

        End Try
        TrackBar1_Scroll(Nothing, Nothing)

        DataFolderDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SortWare"

        MediaViewer1.loadTypes(_imgExtensions, _vidExtensions)
    End Sub

    Private Sub ButtonOnOff(ByRef button As Button, ByVal enable As Boolean)
        button.Enabled = enable
    End Sub

    Private Sub refreshPresortedFiles()
        FilesToBeSorted.Items.Clear()
        If _innerDir IsNot Nothing AndAlso IO.Directory.Exists(_innerDir.fullName) Then
            'Add the contents of the folder to Listbox1

            Dim filePathsSorted As IEnumerable(Of String)
            Select Case (SortByComboBox.Text)
                Case sortByDate
                    filePathsSorted = From f In System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                      Let fileCreationTime = System.IO.File.GetCreationTime(f)
                                      Where True
                                      Order By fileCreationTime
                                      Select f.Replace(PreSortedDirTextBox.Text, "")
                Case sortByName
                    filePathsSorted = From f In System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                      Let fileName = f.Replace(PreSortedDirTextBox.Text, "")
                                      Where True
                                      Order By fileName
                                      Select f.Replace(PreSortedDirTextBox.Text, "")
                Case sortBySize
                    filePathsSorted = From f In System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                      Let fileSize = My.Computer.FileSystem.GetFileInfo(f).Length
                                      Where True
                                      Order By fileSize
                                      Select f.Replace(PreSortedDirTextBox.Text, "")
                Case sortByType
                    filePathsSorted = From f In System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                      Let fileType = System.IO.Path.GetExtension(f)
                                      Where True
                                      Order By fileType
                                      Select f.Replace(PreSortedDirTextBox.Text, "")
                    'Case sortByDefault

                Case Else

            End Select

            If filePathsSorted IsNot Nothing Then
                For Each file In filePathsSorted.ToList
                    If TypeSelector1.isAllowed(file) Then
                        FilesToBeSorted.Items.Add(file.Replace(PreSortedDirTextBox.Text, ""))
                    End If
                Next
            Else
                For Each file As String In IO.Directory.GetFiles(_innerDir.fullName, "*.*")
                    If TypeSelector1.isAllowed(file) Then
                        FilesToBeSorted.Items.Add(file.Replace(PreSortedDirTextBox.Text, ""))
                    End If
                Next
            End If
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
        Try
            addMains(_settings.getList(SortSettings.dirType.MAINDIR))
            addMains(_settings.getList(SortSettings.dirType.CONVERTDIR))
        Catch ex As Exception

        End Try
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

    Public Sub doMoveFile2(ByVal filePath As String, ByVal targetDir As String, ByVal Optional tag As String = "")
        If Not IO.File.Exists(filePath) Then
            Throw New Exception("File does not exist!")
        End If
        If Not IO.Directory.Exists(targetDir) Then
            Throw New Exception("Target directory does not exist!")
        End If

        'Try
        MediaViewer1.RemoveVideo(filePath)
        MediaViewer1.RemoveImage(filePath)

        'Dim tempFile = New IO.FileInfo(file)
        Dim newName = tag + IO.Path.GetFileName(filePath)
        Dim src = IO.Path.GetDirectoryName(filePath)
        Dim dest = targetDir & "\" & newName

        IO.File.Move(filePath, dest)

        writeToLogFile(src, dest, tag)
        'Catch ex As Exception

        'End Try

        FilesToBeSorted.Select()
    End Sub

    Public Sub doMoveFile(ByVal file As String, ByVal targetDir As String, ByVal Optional tag As String = "")
        If Not IO.File.Exists(PreSortedDirTextBox.Text & file) Then
            Throw New Exception("File does not exist!")
        End If
        If Not IO.Directory.Exists(targetDir) Then
            Throw New Exception("Target directory does not exist!")
        End If

        'Try
        MediaViewer1.RemoveVideo(file)
        MediaViewer1.RemoveImage(file)

        'Dim tempFile = New IO.FileInfo(file)
        Dim newName = tag + IO.Path.GetFileName(file)
        Dim src = PreSortedDirTextBox.Text & file
        Dim dest = targetDir & "\" & newName

        Dim fname = IO.Path.GetFileNameWithoutExtension(file)
        fname = fname & ".srt"

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
            MediaViewer1.RemoveImage()
            MediaViewer1.RemoveVideo()

            Dim newName = tag + dir.getName
            Dim dest = targetDir & "\" & newName

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

    Private Sub FindRootDirButton_Click(sender As Object, e As EventArgs) Handles FindRootDirButton.Click

        Dim fbd As New FolderBrowserDialog
        If PreSortedDirTextBox.Text = "" Then
            fbd.RootFolder = Environment.SpecialFolder.MyComputer
        Else
            'fbd.RootFolder = 
        End If

        If fbd.ShowDialog = DialogResult.OK Then
            RootDirTextBox.Text = fbd.SelectedPath
            If System.IO.File.Exists(RootDirTextBox.Text & "\sortSettings.xml") Then
                _settings = New SortSettings(RootDirTextBox.Text)
                OpenSortSettingsButton.BackColor = SystemColors.Control
                OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black
                OpenSortSettingsButton.Text = "Open Folder Settings"
                openLogsButton.Enabled = True
                refreshMainDirs()
            Else    'A .sortSettings file does not exist
                Debug.WriteLine(".sortSettings file non existent")
                OpenSortSettingsButton.BackColor = Color.Red
                OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon
                OpenSortSettingsButton.Text = ".sortSettings file not found!"
                StatusLabel.Text = ".sortSettings file not found"
                openLogsButton.Enabled = False
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

        If IO.File.Exists(RootDirTextBox.Text & "\sortSettings.xml") Then
            OpenSortSettingsButton.BackColor = SystemColors.Control
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black
            OpenSortSettingsButton.Text = "Open Folder Settings"
            _settings = New SortSettings(RootDirTextBox.Text)
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

    Private Sub FilesToBeSorted_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilesToBeSorted.SelectedIndexChanged
        clickedOn = -1
        Dim fileType As Integer = -1
        Dim fileName As String = ""

        If TypeOf FilesToBeSorted.SelectedItem Is String Then
            fileName = CType(FilesToBeSorted.SelectedItem, String)
        Else
            Return
        End If

        Try
            MediaViewer1.AddMedia(PreSortedDirTextBox.Text & fileName)

            If Not IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString).ToUpper.Contains("GIF") Then
                setRatingFromSelection()
            End If

        Catch Ex As Exception
            MsgBox("Cannot Load File!", vbCritical, "Problem enountered while loading file!")
        End Try

    End Sub

    Private Sub FilesToBeSorted_MouseDown(sender As Object, e As MouseEventArgs) Handles FilesToBeSorted.MouseDown
        If e.Button = MouseButtons.Right Then
            clickedOn = FilesToBeSorted.IndexFromPoint(e.X, e.Y)
            FilesToBeSorted.ContextMenuStrip = FileRightClickContextMenu
            If System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) OrElse
                System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl) Then

                FilesToBeSorted.SelectedIndices.Add(clickedOn)
            Else
                FilesToBeSorted.SelectedIndices.Clear()
            End If
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles NormalTimer.Tick
        'If MouseButtons = MouseButtons.Left Then
        '    VlcControl1.Pause()
        'End If
        Try
            If MediaViewer1.VlcControl1.Length > 0 Then
                MediaViewer1.VideoScrollBar.Value = CInt((MediaViewer1.VlcControl1.Time / MediaViewer1.VlcControl1.Length) * 1000)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            MediaViewer1.VlcControl1.SetPause(Not MediaViewer1.VlcControl1.IsPlaying)
        End Try
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
                'Beep()
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
            If toResel >= FilesToBeSorted.Items.Count Then
                FilesToBeSorted.SelectedIndex = FilesToBeSorted.Items.Count - 1
            ElseIf Not toResel >= FilesToBeSorted.Items.Count Then
                FilesToBeSorted.SelectedIndex = toResel
            End If
            FilesToBeSorted.Select()
        End If
    End Sub

    Private Sub PresortFileToPresortFolderButton_Click(sender As Object, e As EventArgs) Handles PresortFileToPresortFolderButton.Click
        If FilesToBeSorted.SelectedItems.Count > 0 AndAlso FoldersToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FoldersToBeSorted.SelectedItem Is SortDirectory Then
            'Beep()
            Dim toResel = FilesToBeSorted.SelectedIndex
            Dim tagsToAdd = ""

            Try
                imgStream.Close()
            Catch ex As Exception
                Beep()
            End Try

            For Each s In FilesToBeSorted.SelectedItems
                Try
                    doMoveFile(s, DirectCast(FoldersToBeSorted.SelectedItem, SortDirectory).fullName, selectedTags)
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
            If toResel >= FilesToBeSorted.Items.Count Then
                FilesToBeSorted.SelectedIndex = FilesToBeSorted.Items.Count - 1
            ElseIf Not toResel >= FilesToBeSorted.Items.Count Then
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
        MediaViewer1.VlcControl1.Audio.Volume = VolumeBar.Value
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

    Private Sub TypeSelector1_CheckChangeded() Handles TypeSelector1.CheckChanged
        refreshPresortedFiles()
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

        Dim playHeadLoc = MediaViewer1.VideoScrollBar.Value
        MediaViewer1.VlcControl1.Stop()

        Try
            Dim fileType = IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString)
            Dim file = Await getStorageFile(path)

            Dim prop As FileProperties.IStorageItemExtraProperties
            If _vidExtensions.Contains(fileType) Then
                MediaViewer1.RemoveVideo(path)
                prop = Await file.Properties.GetVideoPropertiesAsync()
                DirectCast(prop, FileProperties.VideoProperties).Rating = _rating
                Await DirectCast(prop, FileProperties.VideoProperties).SavePropertiesAsync()
            ElseIf Not fileType.Equals(".gif") And Not fileType.Equals(".png") AndAlso _imgExtensions.Contains(fileType) Then

                Try
                    MediaViewer1.RemoveImage()
                    'imgStream.Close()
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
            MediaViewer1.VlcControl1.SetMedia(path)
            MediaViewer1.VlcControl1.Play()
            MediaViewer1.VideoScrollBar.Value = playHeadLoc
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
                    MediaViewer1.RemoveImage(path)
                    MediaViewer1.RemoveVideo(path)
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

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        Try
            Dim rename As New RenameDialog(PreSortedDirTextBox.Text & FilesToBeSorted.Items(clickedOn).ToString)
            MediaViewer1.RemoveImage()
            MediaViewer1.RemoveVideo()
            rename.ShowDialog()
            refreshPresortedFiles()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GroupToolStripMenuItem1.Click
        Dim folderName As String = InputBox("Folder Name?", "Group Items Into Folder")
        If folderName.Trim.Length > 0 Then
            Dim fullFolderName = _innerDir.fullName & "\" & folderName
            System.IO.Directory.CreateDirectory(fullFolderName)
            refreshPresortedFolders()

            MediaViewer1.RemoveImage()
            MediaViewer1.RemoveVideo()

            For Each file In FilesToBeSorted.SelectedItems
                If TypeOf file Is String Then
                    doMoveFile(DirectCast(file, String), fullFolderName)
                End If
            Next
            refreshPresortedFiles()
        End If
    End Sub

    Private Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged
        refreshPresortedFiles()
        FilesToBeSorted.Select()
    End Sub

    Private Sub ConversionsButton_Click(sender As Object, e As EventArgs) Handles conversionsButton.Click
        Dim conversion = New FileConversion(_settings.getConvDirs, _settings.getFinished)

        conversion.Show()
    End Sub

    Private Sub EmptyFoldersUpButton_Click(sender As Object, e As EventArgs) Handles EmptyFoldersUpButton.Click
        If FoldersToBeSorted.SelectedItems.Count > 0 Then
            For Each item As SortDirectory In FoldersToBeSorted.SelectedItems
                For Each file In IO.Directory.GetFiles(item.fullName)
                    Try
                        doMoveFile2(file, item.getParent.fullName)
                    Catch ex As Exception

                    End Try
                Next
            Next
        End If
        refreshPresortedFiles()
    End Sub

    Private Sub VlcControl1_MediaChanged(sender As Object, e As EventArgs) Handles MediaViewer1.VlcMediaChanged
        MediaViewer1.VlcControl1.Audio.Volume = VolumeBar.Value
        MediaViewer1.VlcControl1.Time = 0
        If Not autoPlay.Checked Then
            MediaViewer1.VlcControl1.SetPause(True)
        Else
            'VlcControl1.SetPause(False)
            'MediaViewer1.VlcControl1.Play()

        End If
        MediaViewer1.VlcControl1.Play()
    End Sub

    Private Sub UnderScoreAddUpDown_ValueChanged(sender As Object, e As EventArgs) Handles UnderScoreAddUpDown.ValueChanged
        AddUnderScoreButton.Text = "Add " + CType(UnderScoreAddUpDown.Value, String) + " ""_"""
    End Sub

    Private Sub AddUnderScoreButton_Click(sender As Object, e As EventArgs) Handles AddUnderScoreButton.Click
        If MoveFilesButton.Enabled AndAlso Not MoveFolderButton.Enabled Then    'This means that a file was last selected
            If FilesToBeSorted.SelectedItems.Count > 0 Then
                Dim toResel As Integer = FilesToBeSorted.SelectedIndex
                Dim newName As String = ""
                Dim oldName As String = ""
                Try
                    For Each f In FilesToBeSorted.SelectedItems
                        If TypeOf f Is String Then

                            Dim fi As New IO.FileInfo(PreSortedDirTextBox.Text + DirectCast(f, String)) 'Get the fileInfo object for the file in question so renaming will be easier
                            Dim tag = New String("_"c, CType(UnderScoreAddUpDown.Value, Integer))
                            newName = tag + fi.Name
                            oldName = fi.FullName
                            fi = Nothing
                            MediaViewer1.RemoveImage(oldName)
                            MediaViewer1.RemoveVideo(oldName)
                            My.Computer.FileSystem.RenameFile(oldName, newName)
                        End If
                    Next
                Catch ex As Exception
                    For i As Integer = 1 To 10
                        MediaViewer1.RemoveImage()
                        Try
                            My.Computer.FileSystem.RenameFile(oldName, newName)
                        Catch ex2 As Exception

                        End Try
                    Next
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
                MediaViewer1.VlcControl1.Pause()
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
            MediaViewer1.RemoveImage(path)
            MediaViewer1.RemoveVideo(path)
            dest.Directory.Create()

            IO.File.Move(path, dest.FullName)
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Sub DupeCheckerButton_Click(sender As Object, e As EventArgs) Handles DupeCheckerButton.Click
        Dim cd As DupeChecker
        If ActiveControl IsNot Nothing Then
            If ActiveControl Is MainDirsBox AndAlso MainDirsBox.SelectedItem IsNot Nothing Then
                cd = New DupeChecker(DirectCast(MainDirsBox.SelectedItem, SortDirectory))
            ElseIf ActiveControl Is FoldersToBeSorted AndAlso FoldersToBeSorted.SelectedItem IsNot Nothing Then
                cd = New DupeChecker(DirectCast(FoldersToBeSorted.SelectedItem, SortDirectory))
            ElseIf PreSortedDirTextBox.Text IsNot Nothing AndAlso Not PreSortedDirTextBox.Text.Equals("") Then
                cd = New DupeChecker(New SortDirectory(PreSortedDirTextBox.Text))
            Else
                cd = New DupeChecker
            End If
        Else
            cd = New DupeChecker
        End If

        If cd IsNot Nothing Then
            cd.ShowDialog()
            cd.Dispose()
        End If
    End Sub

    Private Sub Views_CheckedChanged(sender As Object, e As EventArgs) Handles ImageCheck.CheckedChanged, VideoCheck.CheckedChanged
        Dim styles As TableLayoutColumnStyleCollection = MediaViewer1.MediaPanel.ColumnStyles

        If styles.Count < 2 Then Return

        If ImageCheck.Checked And VideoCheck.Checked Then
            For Each style As ColumnStyle In styles
                style.SizeType = SizeType.Percent
                style.Width = 50
            Next
        ElseIf ImageCheck.Checked And Not VideoCheck.Checked Then
            MediaViewer1.RemoveVideo()
            styles.Item(0).SizeType = SizeType.Percent
            styles.Item(0).Width = 100
            styles.Item(1).SizeType = SizeType.Absolute
            styles.Item(1).Width = 0
        ElseIf Not ImageCheck.Checked And VideoCheck.Checked Then
            MediaViewer1.RemoveImage()
            styles.Item(1).SizeType = SizeType.Percent
            styles.Item(1).Width = 100
            styles.Item(0).SizeType = SizeType.Absolute
            styles.Item(0).Width = 0
        ElseIf Not ImageCheck.Checked And Not VideoCheck.Checked Then
            MediaViewer1.RemoveImage()
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
