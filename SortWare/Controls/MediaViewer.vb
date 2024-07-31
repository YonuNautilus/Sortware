Public Class MediaViewer
    Private _imgExtensions As String = MainInterface._imgExtensions
    Private _vidExtensions As String = MainInterface._vidExtensions

    Private imgStream As IO.FileStream

    Private DispatchTimer As System.Windows.Threading.DispatcherTimer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MediaViewer_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        DispatchTimer = New System.Windows.Threading.DispatcherTimer()
        DispatchTimer.Interval = New TimeSpan(500)
        AddHandler DispatchTimer.Tick, AddressOf Timer1_Tick
        DispatchTimer.Start()
        VlcControl1.SetPause(False)
        VlcControl1.Play()
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
                If (Not IO.Path.GetExtension(Path).ToUpper.Contains("GIF") Or (Not IO.Path.GetExtension(Path).ToUpper.Contains("ZIP"))) Then
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
                'VideoScrollBar.Value = 0
                VlcControl1.Stop()
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
            'If s IsNot Nothing AndAlso VlcControl1.IsPlaying AndAlso s.Contains(path) Then
            If s IsNot Nothing AndAlso s.Contains(path) Then
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

    Private Sub test(Sender As Object, e As EventArgs) Handles VideoScrollBar.Click

    End Sub

    Private Sub VideoScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles VideoScrollBar.Scroll
        If e.Type = ScrollEventType.EndScroll Then
            If TypeOf VlcControl1.Tag Is Boolean Then
                If CBool(VlcControl1.Tag) Then
                    VlcControl1.Play()
                    VlcControl1.Tag = False
                    Console.WriteLine("EndScroll")
                End If
            End If
        ElseIf e.Type = ScrollEventType.LargeIncrement Or e.Type = ScrollEventType.LargeDecrement Then
            Console.WriteLine("Increment")
        Else
            If VlcControl1.IsPlaying Then
                VlcControl1.Tag = True
                VlcControl1.SetPause(True)
                Console.WriteLine("Else")
            End If
        End If

        'DispatchTimer.Stop()
        VlcControl1.Time = VideoScrollBar.Value
        'DispatchTimer.Start()
        'If VideoScrollBar.ClientRectangle.Contains(VlcControl1.PointToClient(Control.MousePosition)) Then
        '    Debug.WriteLine("here")
        '    Dim I As Integer = 0
        '    I = CInt(6 + VlcControl1.Time)
        'End If
    End Sub

    Private Sub VlcControl1_LengthChanged(Sender As Object, e As EventArgs) Handles VlcControl1.LengthChanged
        VideoScrollBar.Invoke(Sub()
                                  VideoScrollBar.Value = 0
                              End Sub)
        If autoPlay.Checked Then
            VlcControl1.Play()
        Else
            VlcControl1.Pause()
        End If

        VideoScrollBar.Invoke(Sub()
                                  VideoScrollBar.Maximum = VlcControl1.Length
                                  VideoScrollBar.Minimum = 0
                                  VideoScrollBar.LargeChange = VideoScrollBar.Maximum \ 10
                                  VideoScrollBar.SmallChange = VideoScrollBar.Maximum \ 20
                              End Sub)
    End Sub

    Private Sub VlcControl1_MediaChanged(sender As Object, e As EventArgs) Handles VlcControl1.MediaChanged
        VideoScrollBar.Value = 0
        If autoPlay.Checked Then
            VlcControl1.Play()
        Else
            VlcControl1.Pause()
        End If

        RaiseEvent VlcMediaChanged(sender, e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles VlcControl1.EndReached ', Me.VlcMediaPlaying

        'TimeLabel.Text = VlcControl1.Time & " / " & VlcControl1.Length
        'TimeLabel.Invoke(New updateTimeLabel(AddressOf doUpdateTimeLabel), New Object() {VlcControl1.Time, VlcControl1.Length})

        'VideoTrackBar.Invoke(Sub()
        '                         VideoTrackBar.Value = 0
        '                     End Sub)
        Try
            TimeLabel.Invoke(Sub()
                                 Dim fps = VlcControl1.VlcMediaPlayer.FramesPerSecond
                                 If fps > 0 Then
                                     'TimeLabel.Text = getTimeCode(VlcControl1.Time, fps) & " / " & getTimeCode(VlcControl1.Length, fps)
                                     TimeLabel.Text = getTimeCode(VlcControl1.Time, fps) & vbNewLine & getTimeCode(VlcControl1.Length, fps)
                                 End If
                             End Sub)
        Catch Ex As Exception

        End Try


        Try
            If VlcControl1.Length > 0 Then
                'VideoScrollBar.Value = CInt((VlcControl1.Time / VlcControl1.Length) * 1000)
                VideoScrollBar.Value = VlcControl1.Time
                'VideoTrackBar.Value = VlcControl1.Time
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            VideoScrollBar.Value = 0
        Finally
            VlcControl1.SetPause(Not VlcControl1.IsPlaying)
        End Try
    End Sub

    Private Function getTimeCode(ByVal count As Long, ByVal fps As Double) As String
        'Dim sec = count / fps   'Total seconds of video duration
        'Dim frac = sec - Int(sec)
        ''sec = Int(sec)
        'Dim min = Int(sec) \ 60
        'sec = Int(sec) Mod 60

        Dim countString = String.Format("{0:0000000000000000}", count)
        countString = countString.Insert(countString.Length - 3, ".")

        Dim sec = countString.Substring(countString.Length - 6)
        Dim min = countString.Substring(countString.Length - 8, 2)

        Return "00:" & min & ":" & sec
    End Function

    Private Sub VlcControl1_MediaPlaying(Sender As Object, e As EventArgs) Handles VlcControl1.Playing
        RaiseEvent VlcMediaPlaying(Sender, e)
    End Sub

    Public Event VlcMediaChanged(Sender As Object, e As EventArgs)

    Public Event VlcMediaPlaying(sender As Object, e As EventArgs)

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

    Private Sub TimeLabel_Click(sender As Object, e As EventArgs) Handles TimeLabel.Click

    End Sub

End Class
