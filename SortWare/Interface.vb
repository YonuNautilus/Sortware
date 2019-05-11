Public Class MainInterface
    Public Const _imgExtensions = ".png .jpg .jpeg .gif"
    Public Const _vidExtensions = ".mov .webm .mp4"

    Private _extensions As List(Of String)

    Protected _allowedExtensions As String = ""
    Protected _settings As SortSettings
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _settings As New SortSettings
        Timer1.Start()
        FileTypeCheckBox.ExpandAll()
    End Sub

    Private Sub ButtonOnOff(ByRef button As Button, ByVal enable As Boolean)
        button.Enabled = enable
    End Sub

    Private Sub refreshPresortedFiles()
        FilesToBeSorted.Items.Clear()

        If IO.Directory.Exists(PreSortedDirTextBox.Text) Then
            'Add the contents of the folder to Listbox1
            For Each file As String In IO.Directory.GetFiles(PreSortedDirTextBox.Text, "*.*")
                If _allowedExtensions.Contains(IO.Path.GetExtension(file).ToLower) Then
                    FilesToBeSorted.Items.Add(file.Replace(PreSortedDirTextBox.Text, ""))
                End If
            Next
            'FilesToBeSorted.Items.AddRange(IO.Directory.GetFiles(PreSortedDirTextBox.Text, "*.mp3*"))
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
        End If

        If Not System.IO.File.Exists(RootDirTextBox.Text & "\.sortSettings.txt") Then
            Debug.WriteLine(".sortSettings file non existent")
            OpenSortSettingsButton.BackColor = Color.Red
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon
            OpenSortSettingsButton.Text = ".sortSettings file not found!"
            StatusLabel.Text = ".sortSettings file not found"
        Else    'A .sortSettings file does exist
            _settings = New SortSettings(RootDirTextBox.Text)
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
        End If

        refreshPresortedFiles()
    End Sub

    Private Sub OpenPresortsButton_Click(sender As Object, e As EventArgs) Handles OpenPresortsButton.Click
        If _settings Is Nothing Or RootDirTextBox.Text = "" Then
            Return
        End If
        Dim selectedDir = New FolderSelector(_settings)
        If selectedDir.ShowDialog() = DialogResult.OK Then
            If TypeOf selectedDir.getSelectedDir() Is SortDirectory Then
                PreSortedDirTextBox.Text = selectedDir.getSelectedDir.fullName()
                refreshPresortedFiles()
            End If
        End If
    End Sub

    Private Sub FileTypeCheckBox_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FileTypeCheckBox.AfterCheck, FileTypeCheckBox.AfterSelect
        _allowedExtensions = ""
        For Each n As TreeNode In GetCheck(FileTypeCheckBox.Nodes)
            _allowedExtensions &= n.Text.Replace("/", " ") & " "
        Next
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
                ImagePreview.Image = Image.FromFile(PreSortedDirTextBox.Text & fileName)
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
                    PlayButton_Click(Nothing, Nothing)
                End If

        End Select

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

End Class
