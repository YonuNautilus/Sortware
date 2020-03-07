Public Class MediaViewer
    Private _imgExtensions As String = MainInterface._imgExtensions
    Private _vidExtensions As String = MainInterface._vidExtensions

    Private imgStream As IO.FileStream

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub loadTypes(ByVal imgs As String, ByVal vids As String)
        _imgExtensions = imgs
        _vidExtensions = vids
    End Sub

    Public Sub AddMedia(ByVal Path As String)
        Dim fileType As Integer
        If _imgExtensions.Contains(System.IO.Path.GetExtension(Path.ToLower)) Then
            fileType = 0
        ElseIf _vidExtensions.Contains(System.IO.Path.GetExtension(path.ToLower)) Then
            fileType = 1
        End If

        Select Case (fileType)
            Case 0
                If imgStream IsNot Nothing Then
                    imgStream.Close()
                End If
                If Not IO.Path.GetExtension(Path).ToUpper.Contains("GIF") Then
                    imgStream = New IO.FileStream(Path, IO.FileMode.Open, IO.FileAccess.Read)
                    ImagePreview.Image = Image.FromStream(imgStream)
                    'ImagePreview.Load(Path)
                    imgStream.Close()
                Else
                    'ImagePreview.Image = Image.FromFile(PreSortedDirTextBox.Text & fileName)'
                    Dim data() As Byte = IO.File.ReadAllBytes(Path)
                    IO.File.WriteAllBytes(Path.Replace(IO.Path.GetFileName(Path), "") + "\temp.gif", data)
                    imgStream = New IO.FileStream(Path.Replace(IO.Path.GetFileName(Path), "") + "\temp.gif", IO.FileMode.Open, IO.FileAccess.Read)
                    ImagePreview.Image = Image.FromStream(imgStream)
                    'imgStream.Close()
                End If
            Case 1
                Dim file As IO.FileInfo = New IO.FileInfo(Path)
                VideoScrollBar.Value = 0
                VlcControl1.SetMedia(file)
        End Select
    End Sub

    Public Sub AddImage(ByVal path As String)

    End Sub

    ''' <summary>
    ''' Stops displaying the image if it matches the input path
    ''' </summary>
    ''' <param name="path"></param>
    Public Sub RemoveImage(ByVal path As String)
        Try
            If ImagePreview.ImageLocation.Contains(path) Then
                RemoveImage()
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Remove the current image
    ''' </summary>
    Public Sub RemoveImage()
        Try
            If imgStream IsNot Nothing Then
                imgStream.Close()
            End If

            ImagePreview.Image.Dispose()
            ImagePreview.Image = Nothing
            ImagePreview.ImageLocation = Nothing
            ImagePreview.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddVideo(ByVal path As String)

    End Sub

    Public Sub RemoveVideo(ByVal path As String)
        If VlcControl1.GetCurrentMedia IsNot Nothing AndAlso VlcControl1.GetCurrentMedia.Mrl IsNot Nothing Then
            Dim s As String = New Uri(VlcControl1.GetCurrentMedia.Mrl).LocalPath
            If s IsNot Nothing AndAlso VlcControl1.IsPlaying AndAlso s.Contains(path) Then
                VlcControl1.Stop()
            End If
        End If

    End Sub

    Public Sub RemoveVideo()
        VlcControl1.Stop()
    End Sub

    Public Function isPlayingThis(ByVal path As String) As Boolean
        Dim s As String = New Uri(VlcControl1.GetCurrentMedia.Mrl).LocalPath
        If VlcControl1.IsPlaying AndAlso s.Contains(path) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        VlcControl1.SetPause(VlcControl1.IsPlaying)
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        VlcControl1.Play()
    End Sub

    Private Sub VideoScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles VideoScrollBar.Scroll
        VlcControl1.Time = CInt(VideoScrollBar.Value * VlcControl1.Length / 1000)
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

    Private Sub VlcControl1_MediaChanged(sender As Object, e As EventArgs) Handles VlcControl1.MediaChanged
        RaiseEvent VlcMediaChanged(sender, e)

    End Sub

    Public Event VlcMediaChanged(Sender As Object, e As EventArgs)

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        RemoveImage()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        RemoveVideo()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        RemoveVideo()
        RemoveImage()
    End Sub
End Class
