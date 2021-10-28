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
                    filePathsSorted = IO.Directory.GetFiles(_innerDir.fullName, "*.*")
            End Select

            If (Not String.IsNullOrWhiteSpace(ToBeSortedFilter.Text)) AndAlso filePathsSorted IsNot Nothing AndAlso filePathsSorted.Count > 0 Then

                filePathsSorted = From f In filePathsSorted
                                  Let n = System.IO.Path.GetFileNameWithoutExtension(f).ToLower, filterText = ToBeSortedFilter.Text.ToLower
                                  Where n.Contains(filterText)
                                  Select f

            End If

            For Each file In filePathsSorted.ToList
                If TypeSelector1.isAllowed(file) Then
                    FilesToBeSorted.Items.Add(file.Replace(PreSortedDirTextBox.Text, ""))
                End If
            Next
        End If
    End Sub

    Private Sub refreshPresortedFolders()
        Dim lastIndex = FoldersToBeSorted.SelectedIndex
        FoldersToBeSorted.Items.Clear()
        If IO.Directory.Exists(_innerDir.fullName) Then
            For Each directory In IO.Directory.GetDirectories(_innerDir.fullName)
                FoldersToBeSorted.Items.Add(New SortDirectory(directory, 0))
            Next
        End If

        If FoldersToBeSorted.Items.Count > 0 AndAlso lastIndex < FoldersToBeSorted.Items.Count Then
            FoldersToBeSorted.SelectedIndex = lastIndex
        End If
    End Sub

    Private Sub refreshMainDirs()
        MainDirsTree.BeginUpdate()

        MainDirsTree.Nodes.Clear()

        Try
            addMains(_settings.getList(SortSettings.dirType.MAINDIR))

            If Not String.IsNullOrWhiteSpace(MainDirsFilter.Text) Then
                'filterDirNode()
                MainDirsTree.ExpandAll()
            End If

            addMains(_settings.getList(SortSettings.dirType.CONVERTDIR))
        Catch ex As Exception

        End Try

        MainDirsTree.EndUpdate()
    End Sub

    Private Sub addMains(ByVal sdl As List(Of SortDirectory))
        For Each m As SortDirectory In sdl
            Dim tempNode As TreeNode

            'If there is valid filter text
            If Not String.IsNullOrWhiteSpace(MainDirsFilter.Text) Then
                If m.matchesFilter(MainDirsFilter.Text) Then
                    tempNode = MainDirsTree.Nodes.Add(m.getName)
                    tempNode.Tag = m

                    If m.hasSubs Then
                        addMains(m.getSubs, tempNode)
                    End If
                End If

            Else    'If filter textbox is empty

                tempNode = MainDirsTree.Nodes.Add(m.getName)
                tempNode.Tag = m

                If m.hasSubs Then
                    addMains(m.getSubs, tempNode)
                End If

            End If
        Next
    End Sub

    Private Sub addMains(ByVal sdl As List(Of SortDirectory), ByRef root As TreeNode)
        For Each m As SortDirectory In sdl
            Dim tempNode As TreeNode

            'If there is valid filter text
            If Not String.IsNullOrWhiteSpace(MainDirsFilter.Text) Then
                If m.matchesFilter(MainDirsFilter.Text) Then
                    tempNode = root.Nodes.Add(m.getName)
                    tempNode.Tag = m

                    If m.hasSubs Then
                        addMains(m.getSubs, tempNode)
                    End If
                End If

            Else    'If filter textbox is empty

                tempNode = root.Nodes.Add(m.getName)
                tempNode.Tag = m

                If m.hasSubs Then
                    addMains(m.getSubs, tempNode)
                End If

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

    Public Function doMoveDir(ByVal dir As SortDirectory, ByVal targetDir As String, ByVal Optional tag As String = "") As String
        'Dim ret As Boolean = True
        Dim dest As String = ""
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
            dest = targetDir & "\" & newName

            IO.Directory.Move(dir.fullName, dest)

            writeToLogFile(dir.fullName, dest, tag)

        Catch ex As Exception
            PropertiesSaveStatus.Text = ex.Message
        End Try

        Return dest
    End Function

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
            fileName = PreSortedDirTextBox.Text & CType(FilesToBeSorted.SelectedItem, String)
        Else
            Return
        End If

        'Calculate file size in B, KB, MB or GB to show on FileSizeLabel
        Dim fsize As Long = New System.IO.FileInfo(fileName).Length
        Dim i As Integer = 0
        Dim sizeTemp = fsize
        While (sizeTemp / CLng(1024)) > 1
            sizeTemp /= 1024
            i += 1
        End While
        Dim byteType = ""
        Select Case i
            Case 0
                byteType = "B"
            Case 1
                byteType = "KB"
            Case 2
                byteType = "MB"
            Case 3
                byteType = "GB"
            Case 4
                byteType = "TB"
        End Select
        FileSizeLabel.Text = sizeTemp & " " & byteType

        Try
            If Not FilesToBeSorted.Focused Then
                Exit Try
            End If
            MediaViewer1.AddMedia(fileName)

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

    Private Sub FilesToBeSorted_GotFocus(Sender As Object, e As EventArgs) Handles FilesToBeSorted.GotFocus, FilesToBeSorted.SelectedIndexChanged
        If FilesToBeSorted.SelectedItems.Count > 0 Then
            MoveFilesButton.Enabled = True
            MoveFolderButton.Enabled = False
            MoveFolderSubDirButton.Enabled = False
        End If

    End Sub

    Private Sub FoldersToBeSorted_GotFocus(Sender As Object, e As EventArgs) Handles FoldersToBeSorted.GotFocus, FoldersToBeSorted.SelectedIndexChanged
        If FoldersToBeSorted.SelectedItems.Count > 0 Then
            MoveFilesButton.Enabled = False
            MoveFolderButton.Enabled = True
            MoveFolderSubDirButton.Enabled = True
        End If
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
        If FilesToBeSorted.SelectedItems.Count > 0 AndAlso MainDirsTree.SelectedNode IsNot Nothing AndAlso TypeOf MainDirsTree.SelectedNode.Tag Is SortDirectory Then
            'Beep()
            Dim toResel = FilesToBeSorted.SelectedIndex
            Dim tagsToAdd = ""
            For Each t In TagsSelector.SelectedItems
                Dim m = Regex.Match(t, TAGIDREGEX)
                tagsToAdd = tagsToAdd & m.ToString
            Next

            If imgStream IsNot Nothing Then
                Try
                    imgStream.Close()
                Catch ex As Exception
                    'Beep()
                End Try
            End If


            For Each s In FilesToBeSorted.SelectedItems
                Try
                    doMoveFile(s, DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).fullName, selectedTags)
                Catch ex As Exception
                    Beep()
                    If Not ex.Message.Contains("Cannot create a file when that file already exists.") Then
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

            If imgStream IsNot Nothing Then
                Try
                    imgStream.Close()
                Catch ex As Exception
                    Beep()
                End Try
            End If


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
        If FoldersToBeSorted.SelectedItems.Count > 0 AndAlso MainDirsTree.SelectedNode IsNot Nothing AndAlso TypeOf MainDirsTree.SelectedNode.Tag Is SortDirectory Then
            Dim tagsToAdd = ""
            For Each t In TagsSelector.SelectedItems
                Dim m = Regex.Match(t, TAGIDREGEX)
                tagsToAdd = tagsToAdd & m.ToString
            Next
            For Each s In FoldersToBeSorted.SelectedItems
                doMoveDir(s, DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).fullName, selectedTags)
            Next
            refreshPresortedFolders()
        End If
    End Sub

    Private Sub MoveFolderSubDir_Click(sender As Object, e As EventArgs) Handles MoveFolderSubDirButton.Click
        If FoldersToBeSorted.SelectedItems.Count > 0 AndAlso MainDirsTree.SelectedNode IsNot Nothing AndAlso TypeOf MainDirsTree.SelectedNode.Tag Is SortDirectory Then
            For Each s As SortDirectory In FoldersToBeSorted.SelectedItems
                Dim newLoc As String = doMoveDir(s, DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).fullName)
                If newLoc = "" Then
                    Beep()
                    PropertiesSaveStatus.Text = "Folder " + s.fullName + " might already exist in this directory... use Folder Settings dialog"
                Else
                    _settings.addMainSubDir_Interface(DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory), newLoc)
                End If
            Next
            refreshMainDirs()
            refreshPresortedFolders()
        End If
    End Sub

    Private Sub MoveUpDir_Click(sender As Object, e As EventArgs) Handles moveUpDir.Click
        If _innerDir IsNot Nothing AndAlso Not _innerDir.fullName = PreSortedDirTextBox.Text Then
            Dim tempName = _innerDir
            _innerDir = _innerDir.getParent
            refreshPresortedFiles()
            refreshPresortedFolders()

            Dim newItem As SortDirectory = FoldersToBeSorted.Items.OfType(Of SortDirectory).ToList.Where(Function(x) x.fullName = tempName.fullName).FirstOrDefault
            FoldersToBeSorted.SelectedIndex = FoldersToBeSorted.Items.IndexOf(newItem)

        End If
    End Sub

    Private Sub EnterDir_Click(sender As Object, e As EventArgs) Handles enterDir.Click
        If FoldersToBeSorted.SelectedItem IsNot Nothing AndAlso TypeOf FoldersToBeSorted.SelectedItem Is SortDirectory Then
            _innerDir = DirectCast(FoldersToBeSorted.SelectedItem, SortDirectory)
            refreshPresortedFiles()
            refreshPresortedFolders()
        End If
    End Sub

    Private Sub MainDirsTree_SelectedNodeChanged(sender As Object, e As EventArgs) Handles MainDirsTree.AfterSelect
        selectedTags = ""
        TagsSelector.Items.Clear()
        If TypeOf MainDirsTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).hasTags Then
            TagsSelector.Items.AddRange(DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).getTags)
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

    Private Sub MainDirsBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectedTags = ""
        TagsSelector.Items.Clear()
        If MainDirsTree.SelectedNode IsNot Nothing AndAlso TypeOf MainDirsTree.SelectedNode.Tag Is SortDirectory AndAlso DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).hasTags Then
            TagsSelector.Items.AddRange(DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory).getTags)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles VolumeBar.Scroll
        MediaViewer1.VlcControl1.Audio.Volume = VolumeBar.Value
    End Sub

    Private Sub TagsSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TagsSelector.SelectedIndexChanged
        If TagsSelector.SelectedItems.Count = 1 Then
            selectedTags = Regex.Match(CType(TagsSelector.SelectedItem, String), TAGIDREGEX).ToString
        ElseIf TagsSelector.SelectedItems.Count > 1 Then
            selectedTags = selectedTags + Regex.Match(CType(TagsSelector.SelectedItem, String), TAGIDREGEX).ToString
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
            'MediaViewer1.VideoScrollBar.Value = playHeadLoc
        End Try

    End Sub

    Private Sub DeleteDirButton_Click(sender As Object, e As EventArgs) Handles DeleteDirButton.Click
        Dim clearAll As Boolean = False
        If FoldersToBeSorted.SelectedItems IsNot Nothing AndAlso TypeOf FoldersToBeSorted.SelectedItem Is SortDirectory Then
            For Each folderItem In FoldersToBeSorted.SelectedItems
                Dim path = DirectCast(folderItem, SortDirectory).fullName
                If (getFiles(path).Count > 0) AndAlso Not clearAll Then
                    'There are still files that exist!
                    Dim yna As YesNoApplyToAll = New YesNoApplyToAll("There are still files that exist in this folder [" & DirectCast(folderItem, SortDirectory).getName & "] or in its directories! Are you sure you want to delete this directory and lose all of the files in it?")
                    Dim result As DialogResult = yna.ShowDialog
                    clearAll = yna.applyAll
                    'Dim result As Integer = MessageBox.Show("There are still files that exist in this folder or in its directories! Are you sure you want to delete this directory and lose all of the files in it?", "WARNING", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                        Return
                    ElseIf result = DialogResult.No Then
                        Continue For
                    ElseIf result = DialogResult.Yes Then
                        MediaViewer1.RemoveImage(path)
                        MediaViewer1.RemoveVideo(path)
                    End If
                End If
                Try
                    IO.Directory.Delete(path, True)
                    'refreshPresortedFolders()
                Catch ex As Exception

                End Try
            Next
            refreshPresortedFolders()
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
        If _settings IsNot Nothing Then
            Dim conversion = New FileConversion(_settings.getConvDirs, _settings.getFinished)

            conversion.Show()
        Else
            StatusLabel.Text = "No settings selected"
        End If

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

    Private Sub ToBeSortedFilter_TextChanged(sender As Object, e As EventArgs) Handles ToBeSortedFilter.TextChanged
        refreshPresortedFiles()
    End Sub

    Private Sub MainDirsFilter_TextChanged(sender As Object, e As EventArgs) Handles MainDirsFilter.TextChanged
        refreshMainDirs()
    End Sub

    Private Sub ClearDirFilterBtn_Click(sender As Object, e As EventArgs) Handles ClearDirFilterBtn.Click
        MainDirsFilter.Clear()
    End Sub

    Private Sub ClearFilesFilterBtn_Click(sender As Object, e As EventArgs) Handles ClearFilesFilterBtn.Click
        ToBeSortedFilter.Clear()
    End Sub

    Private Sub VlcControl1_MediaChanged(sender As Object, e As EventArgs) Handles MediaViewer1.VlcMediaChanged
        MediaViewer1.VlcControl1.Audio.Volume = VolumeBar.Value
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
                ElseIf indMax <= FilesToBeSorted.Items.Count Then
                    FilesToBeSorted.SelectedIndex = CInt(indMax)
                ElseIf indMin <= FilesToBeSorted.Items.Count Then
                    FilesToBeSorted.SelectedIndex = CInt(indMin)
                End If

            Case Keys.Space
                Me.ActiveControl = Nothing
                MediaViewer1.Select()
                MediaViewer1.VlcControl1.Pause()
            Case Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9
                If MainDirsTree.Focused Then
                    If MainDirsTree.SelectedNode IsNot Nothing Then '{AndAlso MainDirsTree.SelectedNode.Count = 1 Then
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

            Dim iTry As Integer = 1

            While dest.Exists AndAlso iTry < 99
                dest = New IO.FileInfo(RootDirTextBox.Text + "\toBeDeleted\" + IO.Path.GetFileName(path) + "(" + iTry.ToString + ")")
            End While

            If Not dest.Exists Then
                IO.File.Move(path, dest.FullName)
            Else
                IO.File.Delete(path)
            End If
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Sub DupeCheckerButton_Click(sender As Object, e As EventArgs) Handles DupeCheckerButton.Click
        Dim cd As DupeChecker
        If ActiveControl IsNot Nothing Then
            If ActiveControl Is MainDirsTree AndAlso MainDirsTree.SelectedNode IsNot Nothing Then
                cd = New DupeChecker(DirectCast(MainDirsTree.SelectedNode.Tag, SortDirectory))
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
