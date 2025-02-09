using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SortWare
{
  public partial class MediaViewer
  {
    private string _imgExtensions = MainInterface._imgExtensions;
    private string _vidExtensions = MainInterface._vidExtensions;

    private System.IO.FileStream imgStream;

    private System.Windows.Threading.DispatcherTimer DispatchTimer;

    private LibVLC _libVlc = new LibVLC();
    private MediaPlayer _mp;
    private Media _media;

    public MediaViewer()
    {

      // This call is required by the designer.
      InitializeComponent();
      VideoScrollBar = _VideoScrollBar;
      VlcControl1.Name = "VlcControl1";
      _VideoScrollBar.Name = "VideoScrollBar";

      _mp = new MediaPlayer(_libVlc);
      VlcControl1.MediaPlayer = _mp;
      _mp.MediaChanged += VlcControl1_MediaChanged;
      _mp.LengthChanged += VlcControl1_LengthChanged;
      _mp.Playing += VlcControl1_MediaPlaying;
    }

    public void Pause(){ VlcControl1.MediaPlayer.Pause(); }

    public void Play() { VlcControl1.MediaPlayer.Play(); }

    public void Stop() { VlcControl1.MediaPlayer.Stop(); }

    private void MediaViewer_Load(object Sender, EventArgs e)
    {
      DispatchTimer = new System.Windows.Threading.DispatcherTimer();
      DispatchTimer.Interval = new TimeSpan(500L);
      DispatchTimer.Tick += Timer1_Tick;
      DispatchTimer.Start();
    }

    public void loadTypes(string imgs, string vids)
    {
      _imgExtensions = imgs;
      _vidExtensions = vids;
    }

    public void AddMedia(string Path)
    {
      var fileType = default(int);
      if (_imgExtensions.Contains(System.IO.Path.GetExtension(Path.ToLower())))
      {
        fileType = 0;
      }
      else if (_vidExtensions.Contains(System.IO.Path.GetExtension(Path.ToLower())))
      {
        fileType = 1;
      }

      switch (fileType)
      {
        case 0:
          {
            if (imgStream is not null)
            {
              imgStream.Close();
            }
            if (!System.IO.Path.GetExtension(Path).ToUpper().Contains("GIF") | !System.IO.Path.GetExtension(Path).ToUpper().Contains("ZIP"))
            {
              imgStream = new System.IO.FileStream(Path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
              ImagePreview.Image = Image.FromStream(imgStream);
              // ImagePreview.Load(Path)
              imgStream.Close();
            }
            else
            {
              // ImagePreview.Image = Image.FromFile(PreSortedDirTextBox.Text & fileName)'
              byte[] data = System.IO.File.ReadAllBytes(Path);
              System.IO.File.WriteAllBytes(Path.Replace(System.IO.Path.GetFileName(Path), "") + @"\temp.gif", data);
              imgStream = new System.IO.FileStream(Path.Replace(System.IO.Path.GetFileName(Path), "") + @"\temp.gif", System.IO.FileMode.Open, System.IO.FileAccess.Read);
              ImagePreview.Image = Image.FromStream(imgStream);
              // imgStream.Close()
            }

            break;
          }
        case 1:
          {
            // VideoScrollBar.Value = 0
            VlcControl1.MediaPlayer.Stop();
            _mp.Play(new Media(_libVlc, new Uri(Path)));
            break;
          }
      }
    }

    public void AddImage(string path)
    {

    }

    /// <summary>
    /// Stops displaying the image if it matches the input path
    /// </summary>
    /// <param name="path"></param>
    public void RemoveImage(string path)
    {
      try
      {
        if (ImagePreview.ImageLocation.Contains(path))
        {
          RemoveImage();
        }
      }
      catch (Exception ex)
      {

      }
    }

    /// <summary>
    /// Remove the current image
    /// </summary>
    public void RemoveImage()
    {
      try
      {
        if (imgStream is not null)
        {
          imgStream.Close();
        }

        ImagePreview.Image.Dispose();
        ImagePreview.Image = null;
        ImagePreview.ImageLocation = null;
        ImagePreview.Refresh();
      }
      catch (Exception ex)
      {

      }
    }

    public void AddVideo(string path)
    {

    }

    public void RemoveVideo(string path)
    {
      if (VlcControl1.MediaPlayer.Media is not null && VlcControl1.MediaPlayer.Media.Mrl is not null)
      {
        string s = new Uri(VlcControl1.MediaPlayer.Media.Mrl).LocalPath;
        // If s IsNot Nothing AndAlso VlcControl1.IsPlaying AndAlso s.Contains(path) Then
        if (s is not null && s.Contains(path))
        {
          VlcControl1.MediaPlayer.Stop();
        }
      }

    }

    public void RemoveVideo()
    {
      VlcControl1.MediaPlayer.Stop();
    }

    public bool isPlayingThis(string path)
    {
      string s = new Uri(VlcControl1.MediaPlayer.Media.Mrl).LocalPath;
      if (VlcControl1.MediaPlayer.IsPlaying && s.Contains(path))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void PauseButton_Click(object sender, EventArgs e)
    {
      VlcControl1.MediaPlayer.SetPause(VlcControl1.MediaPlayer.IsPlaying);
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
      VlcControl1.MediaPlayer.Play();
    }

    public void SetVolume(int value)
    {
      VlcControl1.MediaPlayer.Volume = value;
    }

    private void test(object Sender, EventArgs e)
    {

    }

    private void VideoScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
      if (e.Type == ScrollEventType.EndScroll)
      {
        if (VlcControl1.Tag is bool)
        {
          if (Conversions.ToBoolean(VlcControl1.Tag))
          {
            VlcControl1.MediaPlayer.Play();
            VlcControl1.Tag = false;
            Console.WriteLine("EndScroll");
          }
        }
      }
      else if (e.Type == ScrollEventType.LargeIncrement | e.Type == ScrollEventType.LargeDecrement)
      {
        Console.WriteLine("Increment");
      }
      else if (VlcControl1.MediaPlayer.IsPlaying)
      {
        VlcControl1.Tag = true;
        VlcControl1.MediaPlayer.SetPause(true);
        Console.WriteLine("Else");
      }

      // DispatchTimer.Stop()
      VlcControl1.MediaPlayer.Time = e.NewValue;
      // DispatchTimer.Start()
      // If VideoScrollBar.ClientRectangle.Contains(VlcControl1.PointToClient(Control.MousePosition)) Then
      // Debug.WriteLine("here")
      // Dim I As Integer = 0
      // I = CInt(6 + VlcControl1.Time)
      // End If
    }

    private void VlcControl1_LengthChanged(object Sender, EventArgs e)
    {
      VideoScrollBar.Invoke(new Action(() => VideoScrollBar.Value = 0));
      if (autoPlay.Checked)
      {
        VlcControl1.MediaPlayer.Play();
      }
      else
      {
        VlcControl1.MediaPlayer.Pause();
      }

      VideoScrollBar.Invoke(new Action(() =>
          {
            VideoScrollBar.Maximum = (int)VlcControl1.MediaPlayer.Length;
            VideoScrollBar.Minimum = 0;
            VideoScrollBar.LargeChange = VideoScrollBar.Maximum / 10;
            VideoScrollBar.SmallChange = VideoScrollBar.Maximum / 20;
          }));
    }

    private void VlcControl1_MediaChanged(object sender, EventArgs e)
    {
      VideoScrollBar.Value = 0;
      if (autoPlay.Checked)
      {
        VlcControl1.MediaPlayer.Play();
      }
      else
      {
        VlcControl1.MediaPlayer.Pause();
      }

      VlcMediaChanged?.Invoke(sender, e);
    }

    private void Timer1_Tick(object sender, EventArgs e) // , Me.VlcMediaPlaying
    {

      // TimeLabel.Text = VlcControl1.Time & " / " & VlcControl1.Length
      // TimeLabel.Invoke(New updateTimeLabel(AddressOf doUpdateTimeLabel), New Object() {VlcControl1.Time, VlcControl1.Length})

      // VideoTrackBar.Invoke(Sub()
      // VideoTrackBar.Value = 0
      // End Sub)
      try
      {
        TimeLabel.Invoke(new Action(() =>
            {
              float fps = VlcControl1.MediaPlayer.Fps;
              if (fps > 0f)
              {
                // TimeLabel.Text = getTimeCode(VlcControl1.Time, fps) & " / " & getTimeCode(VlcControl1.Length, fps)
                TimeLabel.Text = getTimeCode(VlcControl1.MediaPlayer.Time, (double)fps) + Constants.vbNewLine + getTimeCode(VlcControl1.MediaPlayer.Length, (double)fps);
              }
            }));
      }
      catch (Exception Ex)
      {

      }


      try
      {
        if (VlcControl1.MediaPlayer.Length > 0L)
        {
          // VideoScrollBar.Value = CInt((VlcControl1.Time / VlcControl1.Length) * 1000)
          VideoScrollBar.Value = (int)VlcControl1.MediaPlayer.Time;
          // VideoTrackBar.Value = VlcControl1.Time
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        VideoScrollBar.Value = 0;
      }
      finally
      {
        VlcControl1.MediaPlayer.SetPause(!VlcControl1.MediaPlayer.IsPlaying);
      }
    }

    private string getTimeCode(long count, double fps)
    {
      // Dim sec = count / fps   'Total seconds of video duration
      // Dim frac = sec - Int(sec)
      // 'sec = Int(sec)
      // Dim min = Int(sec) \ 60
      // sec = Int(sec) Mod 60

      string countString = string.Format("{0:0000000000000000}", count);
      countString = countString.Insert(countString.Length - 3, ".");

      string sec = countString.Substring(countString.Length - 6);
      string min = countString.Substring(countString.Length - 8, 2);

      return "00:" + min + ":" + sec;
    }

    private void VlcControl1_MediaPlaying(object Sender, EventArgs e)
    {
      VlcMediaPlaying?.Invoke(Sender, e);
    }

    public event VlcMediaChangedEventHandler VlcMediaChanged;

    public delegate void VlcMediaChangedEventHandler(object Sender, EventArgs e);

    public event VlcMediaPlayingEventHandler VlcMediaPlaying;

    public delegate void VlcMediaPlayingEventHandler(object sender, EventArgs e);

    private void ToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      RemoveImage();
    }

    private void ToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      RemoveVideo();
    }

    private void ToolStripMenuItem3_Click(object sender, EventArgs e)
    {
      RemoveVideo();
      RemoveImage();
    }

    private void TimeLabel_Click(object sender, EventArgs e)
    {

    }

    private void MediaViewer_Disposing(object sender, EventArgs e)
    {
      NormalTimer.Stop();
      NormalTimer.Dispose();
    }
  }
}