Imports System.Threading
Imports System.Threading.Tasks
Imports System.Security.Cryptography

Public Class DupeChecker

    Private root As SortDirectory
    Private GiantDict As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
    Private FileDict As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private unable As List(Of String) = New List(Of String)

    Private dupeFiles As List(Of ListViewItem) = New List(Of ListViewItem)

    Private clickedOn As ListViewItem

    Private sortingCol As ColumnHeader

    Protected _allowedExtensions As String = ""

    Private listLock As New Object
    Private dictLock As New Object

    <Serializable()> Private Class dupeData
        Public Sub New(ByVal name As String, ByVal hash As String)
            name_hash_kvp = New KeyValuePair(Of String, String)(name, hash)
        End Sub

        Property name_hash_kvp As KeyValuePair(Of String, String)

        Property dupes As New List(Of String)
        Property dupes2 As New List(Of ListViewItem)
    End Class

    Public Sub New(ByVal rootIn As SortDirectory)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        root = rootIn
        MasterDirTextBox.Text = root.fullName
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub FindDupesButton_Click(sender As Object, e As EventArgs) Handles FindDupesButton.Click
        MasterFilesView.Items.Clear()
        FileDict.Clear()
        unable.Clear()

        Try
            Await CheckMasterDirAsync()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Checks the master directory for dupes inside itself
    ''' </summary>
    Private Async Function CheckMasterDirAsync() As Task
        StatusLabel.Text = ""
        If RegexFilterInput.Text IsNot Nothing Then
            Dim tasks As New List(Of Task)()
            Dim files As List(Of String) = New List(Of String)
            Dim i As Integer = 0

            Dim totalAmnt As UInteger = 0
            Dim doneAmnt As UInteger = 0

            Try
                'files = New List(Of String)(IO.Directory.GetFiles(MasterDirTextBox.Text))
                'files = From f As String In IO.Directory.GetFiles(MasterDirTextBox.Text)
                '        Where TypeSelector1.isAllowed(f)
                '        Select f
                'End If
                getAllFiles(files, MasterDirTextBox.Text, DoRecursiveMaster.Checked)
            Catch ex As Exception
                MessageBox.Show("Problem getting files in master Directory")
            End Try

            Dim masterFindStart As DateTime = Date.Now
            Dim masterFindPhase1 As TimeSpan
            Dim masterFindPhase2Start As DateTime = Nothing
            Dim masterFindPhase2 As TimeSpan

            For Each l As String In files
                tasks.Add(New Task(Sub()
                                       'Dim fs As IO.FileStream
                                       Dim _md5 As MD5 = MD5.Create
                                       Dim inBytes As Byte()
                                       Dim retry As Boolean = True
                                       Dim hash As String = ""
                                       Dim tryAmnt As Integer = 0
                                       While retry
                                           Try
                                               inBytes = IO.File.ReadAllBytes(l)
                                               hash = BitConverter.ToString(_md5.ComputeHash(inBytes))

                                               'Using fs As IO.FileStream = IO.File.Open(l, IO.FileMode.Open)
                                               'hash = BitConverter.ToString(_md5.ComputeHash(fs))
                                               'End Using

                                               SyncLock listLock
                                                   FileDict.Add(l, hash)
                                               End SyncLock

                                               _md5 = Nothing
                                               inBytes = Nothing
                                               retry = False
                                           Catch ex As Exception
                                               'Beep()
                                               'My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                                               tryAmnt += 1
                                               If tryAmnt >= 10 Then

                                                   SyncLock dictLock
                                                       unable.Add(l)
                                                   End SyncLock

                                                   retry = False
                                               End If
                                           End Try
                                       End While
                                       doneAmnt += CUInt(1)
                                       Dim updateDelegate As New updateBar(AddressOf doUpdateBar)

                                       getUpdateDel(updateDelegate, totalAmnt, doneAmnt)
                                   End Sub)
                            )
            Next

            totalAmnt = CUInt(tasks.Count)

            For Each t As Task In tasks
                t.Start()
            Next

            Await Task.WhenAll(tasks)

            masterFindPhase1 = Date.Now.Subtract(masterFindStart)

            StatusLabel.Text = "Time Taken To Get Hashes, P1: " & masterFindPhase1.ToString

            If unable.Count > 0 Then
                Dim result As Integer = MessageBox.Show("There were " & unable.Count.ToString & " files that were unable to be processed. Would you like to try processing them again? It may take a short while", "Retry files?", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Yes Then
                    masterFindPhase2Start = Date.Now

                    For Each f In unable
                        Dim _md5 As MD5 = MD5.Create
                        Dim inBytes As Byte()
                        Dim hash As String = ""
                        Dim tryAmnt As Integer = 0
                        Try
                            inBytes = IO.File.ReadAllBytes(f)
                            hash = BitConverter.ToString(_md5.ComputeHash(inBytes))


                            'Using fs As IO.FileStream = IO.File.Open(f, IO.FileMode.Open)
                            '    'hash = BitConverter.ToString(_md5.ComputeHash(fs))
                            'End Using

                            FileDict.Add(f, hash)
                            'unable.Remove(f)
                            _md5 = Nothing
                            'inBytes = Nothing
                        Catch ex As Exception

                        End Try
                    Next
                End If
            End If


            If Not masterFindPhase2Start.Equals(Nothing) Then
                masterFindPhase2 = Date.Now.Subtract(masterFindPhase2Start)
                StatusLabel.Text = StatusLabel.Text & vbTab & "P2: " & masterFindPhase2.ToString
            End If


            For Each kvp As KeyValuePair(Of String, String) In FileDict
                Dim dD As dupeData = New dupeData(kvp.Key, kvp.Value)
                Dim displayName As String = kvp.Key.Remove(0, MasterDirTextBox.Text.Length)
                'Dim lvi As ListViewItem = New ListViewItem(New String() {IO.Path.GetFileName(kvp.Key), kvp.Value}) With {
                Dim lvi As ListViewItem = New ListViewItem(New String() {displayName, kvp.Value}) With {
                    .Tag = dD
                }
                MasterFilesView.Items.Add(lvi)
            Next

        End If
        ToolStripProgressBar.Value = 0

    End Function

    ''' <summary>
    ''' Does a recursive 
    ''' </summary>
    ''' <param name="files">A list of filepaths as strings, passed by reference, to be added to.</param>
    ''' <param name="path">The path the subroutine will add files and directories from.</param>
    ''' <param name="recursive">Optional, False by default. If true, will call this function on each folder in the current path</param>
    Private Sub getAllFiles(ByRef files As List(Of String), ByVal path As String, Optional ByVal recursive As Boolean = False)
        If files IsNot Nothing Then
            Dim presentFiles = From f As String In IO.Directory.GetFiles(path)
                               Where TypeSelector1.isAllowed(f)
                               Select f

            files.AddRange(presentFiles)

            If recursive Then
                For Each d In IO.Directory.GetDirectories(path)
                    getAllFiles(files, d, recursive)
                Next
            End If
        End If
    End Sub

    Private Sub doUpdateBar(ByVal total As UInteger, ByVal done As UInteger)
        If done <> 0 AndAlso total <> 0 Then
            ToolStripProgressBar.Value = CInt(100 * (CDbl(done) / CDbl(total)))
        End If
    End Sub
    Private Sub getUpdateDel(ByVal del As updateBar, ByVal tot As UInteger, ByVal done As UInteger)
        StatusStrip1.Invoke(New updateBar(AddressOf doUpdateBar), New Object() {tot, done})
    End Sub

    Private Delegate Sub updateBar(ByVal tot As UInteger, ByVal done As UInteger)

    Private Sub MarkFilesWithDupes_Click(sender As Object, e As EventArgs) Handles MarkFilesWithDupes.Click
        Dim curFile As String = ""
        Dim curHash As String = ""
        Dim k As KeyValuePair(Of String, String) = Nothing

        Dim noDupes = True

        Dim hashes = (From olvi In MasterFilesView.Items     'Gets the hashes for which there are mulitple of in the directory
                      Group olvi By hashGroup = olvi.SubItems(1).Text Into Group
                      Where Group.Count() > 1
                      Select hashGroup).ToList.OfType(Of String)


        If hashes Is Nothing OrElse hashes.Count = 0 Then
            MessageBox.Show("No Duplicates were found!")
        End If

        For Each h As String In hashes
            Dim lvis = (From lvi In MasterFilesView.Items
                        Where h.Contains(lvi.SubItems(1).Text)
                        Select lvi).ToList.OfType(Of ListViewItem)

            For Each lvi As ListViewItem In lvis
                Dim i As Integer = MasterFilesView.Items.IndexOf(lvi)

                DirectCast(MasterFilesView.Items(i).Tag, dupeData).dupes = New List(Of String)((From v As ListViewItem In lvis
                                                                                                Select v.SubItems(0).Text).ToList.OfType(Of String))

                DirectCast(MasterFilesView.Items(i).Tag, dupeData).dupes.Remove(MasterFilesView.Items(i).SubItems(0).Text)

                MasterFilesView.Items(i).BackColor = Color.Red
            Next
        Next



        'For Each lvi As ListViewItem In MasterFilesView.Items
        '    Try
        '        Dim otherfiles = From l As ListViewItem In MasterFilesView.Items
        '                         Let dd = DirectCast(l.Tag, dupeData)
        '                         Where l IsNot lvi AndAlso dd.name_hash_kvp.Value = DirectCast(lvi.Tag, dupeData).name_hash_kvp.Value
        '                         Select dd.name_hash_kvp.Key

        '        If otherfiles IsNot Nothing AndAlso otherfiles.Count > 0 Then
        '            lvi.BackColor = Color.Red
        '            noDupes = False
        '        End If

        '        For Each s As String In otherfiles
        '            DirectCast(lvi.Tag, dupeData).dupes.Add(s)
        '        Next
        '    Catch ex As Exception
        '        StatusLabel.Text = "ERROR: " + curFile + " || " + curHash + " || " + lvi.ToString + " || " + k.ToString
        '    End Try
        'Next
        '
        'If noDupes Then
        '    MessageBox.Show("No Duplicates were found!")
        'End If


    End Sub

    Private Sub SelectMasterDirButton_Click(sender As Object, e As EventArgs) Handles SelectMasterDirButton.Click
        Dim fbd As New FolderBrowserDialog
        If MasterDirTextBox.Text <> "" Then
            Try
                fbd.SelectedPath = MasterDirTextBox.Text
            Catch ex As Exception

            End Try
        End If
        If fbd.ShowDialog = DialogResult.OK Then
            MasterDirTextBox.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub SelectSearchDirButton_Click(sender As Object, e As EventArgs) Handles SelectSearchDirButton.Click
        Dim fbd As New FolderBrowserDialog
        If SearchDirTextBox.Text <> "" Then
            Try
                fbd.SelectedPath = SearchDirTextBox.Text
            Catch ex As Exception

            End Try
        End If
        If fbd.ShowDialog = DialogResult.OK Then
            SearchDirTextBox.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub MasterFilesView_MouseDown(Sender As Object, e As MouseEventArgs) Handles MasterFilesView.MouseDown
        If e.Button = MouseButtons.Right Then
            clickedOn = MasterFilesView.GetItemAt(e.X, e.Y)
            If clickedOn IsNot Nothing Then
                MasterFilesView.ContextMenuStrip = FileRightClickContextMenu
            End If

        End If

    End Sub

    Private Sub MasterFilesView_KeyDown(sender As Object, e As KeyEventArgs) Handles MasterFilesView.KeyDown
        If System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) Or
            System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl) Then
            e.SuppressKeyPress = True
            If MasterFilesView.SelectedItems IsNot Nothing Then
                Dim i As Integer = 0

                If MasterFilesView.SelectedItems.Count > 0 Then
                    i = MasterFilesView.SelectedIndices(0)
                Else
                    i = MasterFilesView.Items.IndexOf(MasterFilesView.FocusedItem)
                End If

                If e.KeyCode = Keys.PageDown Then
                    If i < MasterFilesView.Items.Count - 1 Then
                        For ii = i + 1 To MasterFilesView.Items.Count - 1
                            If MasterFilesView.Items(ii).BackColor = Color.Red Or MasterFilesView.Items(ii).BackColor = Color.GreenYellow Then
                                MasterFilesView.SelectedIndices.Clear()
                                MasterFilesView.SelectedIndices.Add(ii)
                                Exit For
                            End If
                        Next
                    End If
                ElseIf e.KeyCode = Keys.PageUp Then
                    If i > 0 Then
                        For ii = i - 1 To 0 Step -1
                            If MasterFilesView.Items(ii).BackColor = Color.Red Or MasterFilesView.Items(ii).BackColor = Color.GreenYellow Then
                                MasterFilesView.SelectedIndices.Clear()
                                MasterFilesView.SelectedIndices.Add(ii)
                                Exit For
                            End If
                        Next
                    End If
                End If
                MasterFilesView.FocusedItem = MasterFilesView.SelectedItems(0)
            End If
        End If
    End Sub

    Private Sub MasterFilesView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MasterFilesView.SelectedIndexChanged

        For Each olvi As ListViewItem In dupeFiles
            olvi.BackColor = Color.Red
        Next

        dupeFiles.Clear()

        If MasterFilesView.SelectedItems.Count = 1 Then
            Dim mlvi As ListViewItem = MasterFilesView.SelectedItems(0)

            Try
                MediaViewer1.AddMedia(MasterDirTextBox.Text & "\" & MasterFilesView.SelectedItems(0).Text)
            Catch ex As Exception

            End Try

            For Each S As String In DirectCast(mlvi.Tag, dupeData).dupes
                For Each lvi As ListViewItem In MasterFilesView.Items
                    If lvi.Text IsNot Nothing AndAlso lvi.Text.Equals(S) Then
                        dupeFiles.Add(lvi)
                        lvi.BackColor = Color.GreenYellow
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub KeepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeepToolStripMenuItem.Click
        If clickedOn IsNot Nothing Then
            Try
                clickedOn.SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, True.ToString)
            Catch ex As Exception
                clickedOn.SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, True.ToString))
            End Try


            For Each lvi As ListViewItem In dupeFiles
                Try
                    lvi.SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, False.ToString)
                Catch ex As Exception
                    lvi.SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, False.ToString))
                End Try
            Next
        End If
    End Sub

    Private Sub ExecuteMasterDupes_Click(sender As Object, e As EventArgs) Handles ExecuteMasterDupes.Click
        Dim filesToDelete = From f As ListViewItem In MasterFilesView.Items
                            Let subs = f.SubItems
                            Where f.SubItems.Count >= 3 AndAlso f.SubItems.Item(2).Text = False.ToString
                            Select f
        '                   Select MasterDirTextBox.Text & "\" & f.Text

        For Each f As ListViewItem In filesToDelete
            Dim fName As String = MasterDirTextBox.Text & "\" & f.Text

            Try
                IO.File.Delete(fName)
                MasterFilesView.Items.Remove(f)
            Catch ex As Exception
                MediaViewer1.RemoveImage()
                MediaViewer1.RemoveVideo()
                IO.File.Delete(fName)
                MasterFilesView.Items.Remove(f)
            Finally

            End Try
        Next




        Dim filesToKeep = From f As ListViewItem In MasterFilesView.Items
                          Let subs = f.SubItems
                          Where f.SubItems.Count >= 3 AndAlso f.SubItems.Item(2).Text = True.ToString
                          Select f

        For Each f As ListViewItem In filesToKeep
            f.BackColor = Color.White
            f.SubItems(2).Text = ""
            DirectCast(f.Tag, dupeData).dupes.Clear()
        Next

    End Sub

    Private Sub MasterFilesView_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles MasterFilesView.ColumnClick
        'Get the column that needs to be sorted
        Dim sOrdCol As ColumnHeader = MasterFilesView.Columns(e.Column)

        'Figure out the new sorting order
        Dim sOrd As SortOrder
        If sortingCol Is Nothing Then
            'New column was clicked, set the order to ascending
            sOrd = SortOrder.Ascending
        Else
            ' See if its the same column
            If sOrdCol.Equals(sortingCol) Then
                'if it is, change the sorting order
                If sortingCol.Text.StartsWith("> ") Then
                    sOrd = SortOrder.Descending
                Else
                    sOrd = SortOrder.Ascending
                End If
            Else
                'It's a new column, sort ascending
                sOrd = SortOrder.Ascending
            End If
            'Remove the old sorting indicator
            sortingCol.Text = sortingCol.Text.Substring(2)
        End If


        'Now display the new sorting order
        sortingCol = sOrdCol
        If sOrd = SortOrder.Ascending Then
            sOrdCol.Text = "> " & sOrdCol.Text
        Else
            sOrdCol.Text = "< " & sOrdCol.Text
        End If

        'Create a comparer...
        MasterFilesView.ListViewItemSorter = New Generics.ListViewItemComparer(e.Column, sOrd)

        'Aaaaand SORT
        MasterFilesView.Sort()
    End Sub

    Private Sub DupeChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StatusLabel.Text = ""
    End Sub
End Class