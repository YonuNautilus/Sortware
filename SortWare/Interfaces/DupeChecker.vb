Imports System.Threading
Imports System.Threading.Tasks
Imports System.Security.Cryptography

Public Class DupeChecker

    Private root As SortDirectory
    Private GiantDict As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))

    Private MdupeFiles As List(Of ListViewItem) = New List(Of ListViewItem)
    Private TdupeFiles As List(Of ListViewItem) = New List(Of ListViewItem)

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

        Property dupesInMaster As New List(Of String)
        Property dupesInTarget As New List(Of String)
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
        TargetFilesView.Items.Clear()

        Try
            MasterFilesView.Items.AddRange((Await CheckSearchDirAsync(MasterDirTextBox.Text, DoRecursiveMaster.Checked)).ToArray)
            If Not TargetIsSameAsMaster.Checked Then
                TargetFilesView.Items.AddRange((Await CheckSearchDirAsync(TargetDirTextBox.Text, DoRecursiveTarget.Checked)).ToArray)
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Checks the master directory for dupes inside itself
    ''' </summary>
    Private Async Function CheckSearchDirAsync(ByVal dirToSearch As String, ByVal doRecursive As Boolean) As Task(Of List(Of ListViewItem))
        StatusLabel.Text = ""
        Dim fileDict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim unable As List(Of String) = New List(Of String)
        Dim ret As List(Of ListViewItem) = New List(Of ListViewItem)
        If RegexFilterInput.Text IsNot Nothing Then
            Dim tasks As New List(Of Task)()
            Dim files As List(Of String) = New List(Of String)
            Dim i As Integer = 0

            Dim totalAmnt As UInteger = 0
            Dim doneAmnt As UInteger = 0

            Try
                getAllFiles(files, dirToSearch, doRecursive)
            Catch ex As Exception
                MessageBox.Show("Problem getting files in directory: " & dirToSearch)
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
                                                   fileDict.Add(l, hash)
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

                            fileDict.Add(f, hash)
                            'unable.Remove(f)
                            _md5 = Nothing
                            'inBytes = Nothing
                            ToolStripProgressBar.Value = CType((unable.IndexOf(f) / (unable.Count - 1)) * 100, Integer)
                            Continue For
                        Catch ex As Exception
                        End Try

                        Try
                            Dim fs As IO.FileStream = New IO.FileStream(f, IO.FileMode.Open, IO.FileAccess.Read)
                            hash = BitConverter.ToString(_md5.ComputeHash(fs))
                            fileDict.Add(f, hash)
                            Dim iii As Integer = unable.IndexOf(f)
                            ToolStripProgressBar.Value = CType((iii / (unable.Count - 1)) * 100, Integer)
                            Continue For
                        Catch ex2 As Exception

                        End Try

                    Next
                End If
            End If


            If Not masterFindPhase2Start.Equals(Nothing) Then
                masterFindPhase2 = Date.Now.Subtract(masterFindPhase2Start)
                StatusLabel.Text = StatusLabel.Text & " | " & "P2: " & masterFindPhase2.ToString
            End If


            For Each kvp As KeyValuePair(Of String, String) In fileDict
                Dim dD As dupeData = New dupeData(kvp.Key, kvp.Value)
                Dim displayName As String = kvp.Key.Remove(0, dirToSearch.Length)
                'Dim lvi As ListViewItem = New ListViewItem(New String() {IO.Path.GetFileName(kvp.Key), kvp.Value}) With {
                Dim lvi As ListViewItem = New ListViewItem(New String() {displayName, kvp.Value}) With {
                    .Tag = dD
                }
                ret.Add(lvi)
            Next

        End If
        ToolStripProgressBar.Value = 0
        Return ret

    End Function

    ''' <summary>
    ''' Does a recursive get of all the files in the given path.
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

        Dim masterMarkStart As DateTime = Date.Now
        Dim masterMarkTime As TimeSpan


        Dim hashes

        If Not TargetIsSameAsMaster.Checked Then
            hashes = (From o1 As ListViewItem In MasterFilesView.Items
                      Join o2 As ListViewItem In TargetFilesView.Items
                      On o1.SubItems(1).Text Equals o2.SubItems(1).Text
                      Group o1, o2 By hashGroup = o1.SubItems(1).Text Into Group
                      Where Group.Count() > 1
                      Select hashGroup).ToList.OfType(Of String)
        Else
            hashes = (From o1 As ListViewItem In MasterFilesView.Items
                      Group o1 By hashGroup = o1.SubItems(1).Text Into Group
                      Where Group.Count() > 1
                      Select hashGroup).ToList.OfType(Of String)

        End If

        If hashes Is Nothing OrElse DirectCast(hashes, IEnumerable(Of String)).Count = 0 Then
            MessageBox.Show("No Duplicates were found!")
            Return
        End If

        For Each h As String In hashes
            Dim mlvis = (From lvi In MasterFilesView.Items
                         Where h.Contains(lvi.SubItems(1).Text)
                         Select lvi).ToList.OfType(Of ListViewItem)

            Dim tlvis As IEnumerable(Of ListViewItem)
            If Not TargetIsSameAsMaster.Checked Then
                tlvis = (From lvi In TargetFilesView.Items
                         Where h.Contains(lvi.SubItems(1).Text)
                         Select lvi).ToList.OfType(Of ListViewItem)
            End If

            For Each lvi As ListViewItem In mlvis
                Dim i As Integer = MasterFilesView.Items.IndexOf(lvi)

                DirectCast(MasterFilesView.Items(i).Tag, dupeData).dupesInMaster = New List(Of String)((From v As ListViewItem In mlvis
                                                                                                        Select v.SubItems(0).Text).ToList.OfType(Of String))

                DirectCast(MasterFilesView.Items(i).Tag, dupeData).dupesInMaster.Remove(lvi.SubItems(0).Text)

                MasterFilesView.Items(i).BackColor = Color.Red

                If Not TargetIsSameAsMaster.Checked AndAlso tlvis IsNot Nothing AndAlso (TypeOf tlvis Is IEnumerable OrElse TypeOf tlvis Is IQueryable) Then

                    DirectCast(MasterFilesView.Items(i).Tag, dupeData).dupesInTarget = New List(Of String)((From v As ListViewItem In tlvis
                                                                                                            Select v.SubItems(0).Text).ToList.OfType(Of String))

                    For Each titem As ListViewItem In tlvis
                        titem.BackColor = Color.DeepPink
                        DirectCast(titem.Tag, dupeData).dupesInTarget = New List(Of String)((From v As ListViewItem In tlvis
                                                                                             Select v.SubItems(0).Text).ToList.OfType(Of String))
                        DirectCast(titem.Tag, dupeData).dupesInTarget.Remove(titem.SubItems(0).Text)
                    Next
                End If
            Next
        Next


        If Not masterMarkStart.Equals(Nothing) Then
            masterMarkTime = Date.Now.Subtract(masterMarkStart)
            StatusLabel.Text = StatusLabel.Text & " | " & "Mark Time: " & masterMarkTime.ToString
        End If


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

    Private Sub SelectSearchDirButton_Click(sender As Object, e As EventArgs) Handles SelectTargetDirButton.Click
        Dim fbd As New FolderBrowserDialog
        If TargetDirTextBox.Text <> "" Then
            Try
                fbd.SelectedPath = TargetDirTextBox.Text
            Catch ex As Exception

            End Try
        End If
        If fbd.ShowDialog = DialogResult.OK Then
            TargetDirTextBox.Text = fbd.SelectedPath
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

    Private Sub TargetFilesView_MouseDown(Sender As Object, e As MouseEventArgs) Handles TargetFilesView.MouseDown
        If e.Button = MouseButtons.Right Then
            clickedOn = TargetFilesView.GetItemAt(e.X, e.Y)
            If clickedOn IsNot Nothing Then
                TargetFilesView.ContextMenuStrip = FileRightClickContextMenu
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
                Try
                    MasterFilesView.FocusedItem = MasterFilesView.SelectedItems(0)
                    MasterFilesView.EnsureVisible(MasterFilesView.SelectedIndices(0))
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub TargetFilesView_KeyDown(sender As Object, e As KeyEventArgs) Handles TargetFilesView.KeyDown
        If System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) Or
            System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl) Then
            e.SuppressKeyPress = True
            If TargetFilesView.SelectedItems IsNot Nothing Then
                Dim i As Integer = 0

                If TargetFilesView.SelectedItems.Count > 0 Then
                    i = TargetFilesView.SelectedIndices(0)
                Else
                    i = TargetFilesView.Items.IndexOf(TargetFilesView.FocusedItem)
                End If

                If e.KeyCode = Keys.PageDown Then
                    If i < TargetFilesView.Items.Count - 1 Then
                        For ii = i + 1 To TargetFilesView.Items.Count - 1
                            If TargetFilesView.Items(ii).BackColor = Color.DeepPink Or TargetFilesView.Items(ii).BackColor = Color.GreenYellow Then
                                TargetFilesView.SelectedIndices.Clear()
                                TargetFilesView.SelectedIndices.Add(ii)
                                Exit For
                            End If
                        Next
                    End If
                ElseIf e.KeyCode = Keys.PageUp Then
                    If i > 0 Then
                        For ii = i - 1 To 0 Step -1
                            If TargetFilesView.Items(ii).BackColor = Color.DeepPink Or TargetFilesView.Items(ii).BackColor = Color.GreenYellow Then
                                TargetFilesView.SelectedIndices.Clear()
                                TargetFilesView.SelectedIndices.Add(ii)
                                Exit For
                            End If
                        Next
                    End If
                End If
                Try
                    TargetFilesView.FocusedItem = TargetFilesView.SelectedItems(0)
                    TargetFilesView.EnsureVisible(TargetFilesView.SelectedIndices(0))
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub MasterFilesView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MasterFilesView.SelectedIndexChanged

        For Each olvi As ListViewItem In MdupeFiles
            olvi.BackColor = Color.Red
        Next

        For Each olvi As ListViewItem In TdupeFiles
            olvi.BackColor = Color.DeepPink
        Next

        MdupeFiles.Clear()
        TdupeFiles.Clear()

        If MasterFilesView.SelectedItems.Count = 1 Then
            Dim mlvi As ListViewItem = MasterFilesView.SelectedItems(0)

            Try
                MediaViewer1.AddMedia(MasterDirTextBox.Text & "\" & MasterFilesView.SelectedItems(0).Text)
            Catch ex As Exception

            End Try

            For Each S As String In DirectCast(mlvi.Tag, dupeData).dupesInMaster
                For Each lvi As ListViewItem In MasterFilesView.Items
                    If lvi.Text IsNot Nothing AndAlso lvi.Text.Equals(S) Then
                        MdupeFiles.Add(lvi)
                        lvi.BackColor = Color.GreenYellow
                    End If
                Next
            Next

            For Each S As String In DirectCast(mlvi.Tag, dupeData).dupesInTarget
                For Each lvi As ListViewItem In TargetFilesView.Items
                    If lvi.Text IsNot Nothing AndAlso lvi.Text.Equals(S) Then
                        TdupeFiles.Add(lvi)
                        lvi.BackColor = Color.GreenYellow
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub TargetFilesView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TargetFilesView.SelectedIndexChanged

        For Each olvi As ListViewItem In MdupeFiles
            olvi.BackColor = Color.Red
        Next

        For Each olvi As ListViewItem In TdupeFiles
            olvi.BackColor = Color.DeepPink
        Next

        MdupeFiles.Clear()
        TdupeFiles.Clear()

        If TargetFilesView.SelectedItems.Count = 1 Then
            Dim mlvi As ListViewItem = TargetFilesView.SelectedItems(0)

            Try
                MediaViewer1.AddMedia(TargetDirTextBox.Text & "\" & TargetFilesView.SelectedItems(0).Text)
            Catch ex As Exception

            End Try

            Dim t = New List(Of ListViewItem)(MasterFilesView.Items.Cast(Of ListViewItem))
            Dim firstLvi As ListViewItem = t.FirstOrDefault(Function(x) x.SubItems(1).Text.Equals(mlvi.SubItems(1).Text))
            If firstLvi IsNot Nothing Then
                MasterFilesView.SelectedIndices.Clear()
                MasterFilesView.SelectedIndices.Add(MasterFilesView.Items.IndexOf(firstLvi))
                MasterFilesView.FocusedItem = firstLvi
            End If

            'For Each S As String In DirectCast(mlvi.Tag, dupeData).dupesInTarget
            '    For Each lvi As ListViewItem In TargetFilesView.Items
            '        If lvi.Text IsNot Nothing AndAlso lvi.Text.Equals(S) Then
            '            TdupeFiles.Add(lvi)
            '            lvi.BackColor = Color.GreenYellow
            '        End If
            '    Next
            'Next
        End If
    End Sub

    Private Sub KeepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeepToolStripMenuItem.Click
        If Me.ActiveControl IsNot Nothing AndAlso TypeOf ActiveControl Is ListView Then
            Dim templv As ListView = DirectCast(Me.ActiveControl, ListView)
            If templv.Equals(MasterFilesView) AndAlso templv.SelectedItems.Count = 1 Then
                If TargetIsSameAsMaster.Checked Then
                    For Each lvi As ListViewItem In MdupeFiles
                        Try
                            lvi.SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, False.ToString)
                        Catch ex As Exception
                            lvi.SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, False.ToString))
                        End Try
                    Next
                    Try
                        templv.SelectedItems.Item(0).SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, True.ToString)
                    Catch ex As Exception
                        templv.SelectedItems.Item(0).SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, True.ToString))
                    End Try
                Else
                    For Each lvi As ListViewItem In TdupeFiles
                        Try
                            lvi.SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, False.ToString)
                        Catch ex As Exception
                            lvi.SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, False.ToString))
                        End Try
                    Next
                    Try
                        templv.SelectedItems.Item(0).SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, True.ToString)
                    Catch ex As Exception
                        templv.SelectedItems.Item(0).SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, True.ToString))
                    End Try
                End If
            Else


            End If
        End If
    End Sub

    Private Sub DontKeepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DontKeepToolStripMenuItem.Click

    End Sub

    Private Sub ClearStatusMenuItem_Click(sender As Object, e As EventArgs) Handles ClearStatusMenuItem.Click
        If clickedOn IsNot Nothing AndAlso clickedOn.SubItems.Count >= 3 Then
            clickedOn.SubItems.Remove(clickedOn.SubItems.Item(2))
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
            DirectCast(f.Tag, dupeData).dupesInMaster.Clear()
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

    Private Sub TargetFilesView_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles TargetFilesView.ColumnClick
        'Get the column that needs to be sorted
        Dim sOrdCol As ColumnHeader = TargetFilesView.Columns(e.Column)

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
        TargetFilesView.ListViewItemSorter = New Generics.ListViewItemComparer(e.Column, sOrd)

        'Aaaaand SORT
        TargetFilesView.Sort()
    End Sub

    Private Sub DupeChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StatusLabel.Text = ""
    End Sub

    Private Sub DupeChecker_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Dim masterWidth As Integer = MasterFilesView.Width - (MasterFilesView.Margin.Left + MasterFilesView.Margin.Right)
        MasterFilesView.Columns.Item(0).Width = masterWidth - 120
        MasterFilesView.Columns.Item(1).Width = 60
        MasterFilesView.Columns.Item(2).Width = 60

        Dim targetWidth As Integer = TargetFilesView.Width - (TargetFilesView.Margin.Left + TargetFilesView.Margin.Right)
        TargetFilesView.Columns.Item(0).Width = targetWidth - 120
        TargetFilesView.Columns.Item(1).Width = 60
        TargetFilesView.Columns.Item(2).Width = 60
    End Sub
End Class