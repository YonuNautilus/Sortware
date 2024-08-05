using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SortWare
{

  public partial class DupeChecker
  {

    private DupeStruct dp = new DupeStruct();

    private SortDirectory root;
    private Dictionary<string, Dictionary<string, string>> GiantDict = new Dictionary<string, Dictionary<string, string>>();

    private List<ListViewItem> MdupeFiles = new List<ListViewItem>();
    private List<ListViewItem> TdupeFiles = new List<ListViewItem>();

    private ListViewItem clickedOn;

    private ColumnHeader sortingCol;

    protected string _allowedExtensions = "";

    private object listLock = new object();
    private object dictLock = new object();

    private byte[] JPEG_IMAGEHEADER = new byte[] { 0xFF, 0xDA };
    private byte[] MP4_MDATHEADER = new byte[] { 0x6D, 0x64, 0x61, 0x74 };


    [Serializable()]
    private class dupeData
    {
      public dupeData(string name, string hash)
      {
        name_hash_kvp = new KeyValuePair<string, string>(name, hash);
      }

      public KeyValuePair<string, string> name_hash_kvp { get; set; }

      public List<ListViewItem> dupesInMaster { get; set; } = new List<ListViewItem>();
      public List<ListViewItem> dupesInTarget { get; set; } = new List<ListViewItem>();
    }

    public DupeChecker(SortDirectory rootIn)
    {

      // This call is required by the designer.
      InitializeComponent();

      // Add any initialization after the InitializeComponent() call.
      root = rootIn;
      MasterDirTextBox.Text = root.fullName();
    }

    public DupeChecker()
    {

      // This call is required by the designer.
      InitializeComponent();

      // Add any initialization after the InitializeComponent() call.

    }

    private async void FindDupesButton_Click(object sender, EventArgs e)
    {
      MasterFilesView.Items.Clear();
      TargetFilesView.Items.Clear();

      dp.Clear();

      // Try
      // MasterFilesView.Items.AddRange((Await CheckSearchDirAsync(MasterDirTextBox.Text, DoRecursiveMaster.Checked)).ToArray)
      // If Not TargetIsSameAsMaster.Checked Then
      // TargetFilesView.Items.AddRange((Await CheckSearchDirAsync(TargetDirTextBox.Text, DoRecursiveTarget.Checked)).ToArray)
      // End If
      // Catch ex As Exception

      // End Try

      try
      {
        CheckSearchDirs(MasterDirTextBox.Text, DoRecursiveMaster.Checked, 1);
        if (!TargetIsSameAsMaster.Checked)
        {
          CheckSearchDirs(TargetDirTextBox.Text, DoRecursiveTarget.Checked, 2);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }

      if (!IgnoreMetaDataBox.Checked)
      {

        dp.ClearLowCountSizes();

        var dir1Files = dp.GetDir1Files();
        var dir2Files = dp.GetDir2Files();

        foreach (var f in dir1Files)
        {
          var _md5 = MD5.Create();
          string hash = BitConverter.ToString(_md5.ComputeHash(new System.IO.BufferedStream(System.IO.File.OpenRead(f))));
          var data = new dupeData(f, hash);
          string displayName = new string(f.ToCharArray()).Remove(0, MasterDirTextBox.Text.Length);
          var lvi = new ListViewItem(new string[] { displayName, hash }) { Tag = data };
          MasterFilesView.Items.Add(lvi);
        }

        foreach (var f in dir2Files)
        {
          var _md5 = MD5.Create();
          string hash = BitConverter.ToString(_md5.ComputeHash(new System.IO.BufferedStream(System.IO.File.OpenRead(f))));
          var data = new dupeData(f, hash);
          string displayName = new string(f.ToCharArray()).Remove(0, TargetDirTextBox.Text.Length);
          var lvi = new ListViewItem(new string[] { displayName, hash }) { Tag = data };
          TargetFilesView.Items.Add(lvi);
        }
      }

      else
      {

        var dir1Files = dp.GetDir1Files();
        var dir2Files = dp.GetDir2Files();

        foreach (var f in dir1Files)
        {
          string hashCode = null;

          try
          {
            hashCode = hashIgnoreMetaData(f);
          }
          catch (Exception ex)
          {
            Console.WriteLine("File: " + f + Constants.vbNewLine + Constants.vbTab + ex.Message);
          }

          if (hashCode is not null)
          {
            var data = new dupeData(f, hashCode);
            string displayName = new string(f.ToCharArray()).Remove(0, MasterDirTextBox.Text.Length);
            var lvi = new ListViewItem(new string[] { displayName, hashCode }) { Tag = data };
            MasterFilesView.Items.Add(lvi);
          }
          ToolStripProgressBar.Value = (int)Math.Round(dir1Files.IndexOf(f) / (double)(dir1Files.Count + dir2Files.Count) * 100d);
        }

        var hash = default(string);
        foreach (var f in dir2Files)
        {

          try
          {
            hash = hashIgnoreMetaData(f);
          }
          catch (Exception ex)
          {
            Console.WriteLine("File: " + f + Constants.vbNewLine + Constants.vbTab + ex.Message);
          }

          if (hash is not null)
          {
            var data = new dupeData(f, hash);
            string displayName = new string(f.ToCharArray()).Remove(0, TargetDirTextBox.Text.Length);
            var lvi = new ListViewItem(new string[] { displayName, hash }) { Tag = data };
            TargetFilesView.Items.Add(lvi);
          }
        }

      }

    }

    private void CheckSearchDirs(string dirToSearch, bool doRecursive, int iteration = 1)
    {
      var files = new List<string>();
      try
      {
        getAllFiles(ref files, dirToSearch, doRecursive);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Problem getting files in directory: " + dirToSearch);
      }

      foreach (string f in files)
      {
        long size = new System.IO.FileInfo(f).Length;
        if (iteration == 1)
        {
          dp.AddD1File(size, f);
        }
        else
        {
          dp.AddD2File(size, f);
        }
      }

    }

    /// <summary>
    /// Checks the master directory for dupes inside itself
    /// </summary>
    private async Task<List<ListViewItem>> CheckSearchDirAsync(string dirToSearch, bool doRecursive)
    {
      StatusLabel.Text = "";
      var fileDict = new Dictionary<string, string>();
      var unable = new List<string>();
      var ret = new List<ListViewItem>();
      if (RegexFilterInput.Text is not null)
      {
        var tasks = new List<Task>();
        var files = new List<string>();
        int i = 0;

        uint totalAmnt = 0U;
        uint doneAmnt = 0U;

        try
        {
          getAllFiles(ref files, dirToSearch, doRecursive);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Problem getting files in directory: " + dirToSearch);
        }

        var masterFindStart = DateTime.Now;
        TimeSpan masterFindPhase1;
        DateTime masterFindPhase2Start = default;
        TimeSpan masterFindPhase2;


        // Parallel.ForEach(Of String)(files, Sub(ByVal f As String)
        // Dim hash As String = ""
        // Dim _md5 As MD5 = MD5.Create
        // Using fs As IO.FileStream = IO.File.OpenRead(f)
        // hash = BitConverter.ToString(_md5.ComputeHash(fs))
        // End Using
        // SyncLock listLock
        // fileDict.Add(f, hash)
        // End SyncLock
        // End Sub)

        totalAmnt = (uint)files.Count;
        foreach (string l in files)
        {
          // tasks.Add(New Task(Sub()
          // 'Dim fs As IO.FileStream
          var _md5 = MD5.Create();
          byte[] inBytes;
          bool retry = true;
          string hash = "";
          int tryAmnt = 0;
          while (retry)
          {
            try
            {
              // inBytes = IO.File.ReadAllBytes(l)
              // hash = BitConverter.ToString(_md5.ComputeHash(inBytes))

              using (var fs = new System.IO.BufferedStream(System.IO.File.OpenRead(l), 120000))
              {
                hash = BitConverter.ToString(_md5.ComputeHash(fs));
              }

              // SyncLock listLock
              fileDict.Add(l, hash);
              // End SyncLock

              _md5 = null;
              inBytes = null;
              retry = false;
            }
            catch (Exception ex)
            {
              // Beep()
              // My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
              tryAmnt += 1;
              if (tryAmnt >= 10)
              {

                // SyncLock dictLock
                unable.Add(l);
                // End SyncLock

                retry = false;
              }
            }
          }
          doneAmnt += 1;
          // Dim updateDelegate As New updateBar(AddressOf doUpdateBar)

          // getUpdateDel(updateDelegate, totalAmnt, doneAmnt)
          doUpdateBar(totalAmnt, doneAmnt);
          // End Sub)
          // )
        }

        // totalAmnt = CUInt(tasks.Count)

        // For Each t As Task In tasks
        // t.Start()
        // Next

        // Await Task.WhenAll(tasks)

        masterFindPhase1 = DateTime.Now.Subtract(masterFindStart);

        StatusLabel.Text = "Time Taken To Get Hashes, P1: " + masterFindPhase1.ToString();

        if (unable.Count > 0)
        {
          int result = (int)MessageBox.Show("There were " + unable.Count.ToString() + " files that were unable to be processed. Would you like to try processing them again? It may take a short while", "Retry files?", MessageBoxButtons.YesNoCancel);
          if (result == (int)DialogResult.Yes)
          {
            masterFindPhase2Start = DateTime.Now;

            foreach (var f in unable)
            {
              var _md5 = MD5.Create();
              byte[] inBytes;
              string hash = "";
              int tryAmnt = 0;
              try
              {

                // inBytes = IO.File.ReadAllBytes(f)
                // hash = BitConverter.ToString(_md5.ComputeHash(inBytes))


                using (var fs = System.IO.File.OpenRead(f))
                {
                  hash = BitConverter.ToString(_md5.ComputeHash(fs));
                }

                fileDict.Add(f, hash);
                // unable.Remove(f)
                _md5 = null;
                // inBytes = Nothing
                ToolStripProgressBar.Value = (int)Math.Round(unable.IndexOf(f) / (double)(unable.Count - 1) * 100d);
                continue;
              }
              catch (Exception ex)
              {

              }

              // Try
              // Dim fs As IO.FileStream = New IO.FileStream(f, IO.FileMode.Open, IO.FileAccess.Read)
              // hash = BitConverter.ToString(_md5.ComputeHash(fs))
              // fileDict.Add(f, hash)
              // Dim iii As Integer = unable.IndexOf(f)
              // ToolStripProgressBar.Value = CType((iii / (unable.Count - 1)) * 100, Integer)
              // Continue For
              // Catch ex2 As Exception

              // End Try

            }
          }
        }


        if (!masterFindPhase2Start.Equals(default))
        {
          masterFindPhase2 = DateTime.Now.Subtract(masterFindPhase2Start);
          StatusLabel.Text = StatusLabel.Text + " | " + "P2: " + masterFindPhase2.ToString();
        }


        foreach (KeyValuePair<string, string> kvp in fileDict)
        {
          var dD = new dupeData(kvp.Key, kvp.Value);
          string displayName = kvp.Key.Remove(0, dirToSearch.Length);
          // Dim lvi As ListViewItem = New ListViewItem(New String() {IO.Path.GetFileName(kvp.Key), kvp.Value}) With {
          var lvi = new ListViewItem(new string[] { displayName, kvp.Value }) { Tag = dD };
          ret.Add(lvi);
        }

      }
      ToolStripProgressBar.Value = 0;
      return ret;

    }

    /// <summary>
    /// Does a recursive get of all the files in the given path.
    /// </summary>
    /// <param name="files">A list of filepaths as strings, passed by reference, to be added to.</param>
    /// <param name="path">The path the subroutine will add files and directories from.</param>
    /// <param name="recursive">Optional, False by default. If true, will call this function on each folder in the current path</param>
    private void getAllFiles(ref List<string> files, string path, bool recursive = false)
    {
      string[] af = System.IO.Directory.GetFiles(path);
      if (files is not null)
      {
        var presentFiles = from f in System.IO.Directory.GetFiles(path)
                           where TypeSelector1.isAllowed(f)
                           select f;

        files.AddRange(presentFiles);

        if (recursive)
        {
          foreach (var d in System.IO.Directory.GetDirectories(path))
            getAllFiles(ref files, d, recursive);
        }
      }
    }

    private string hashIgnoreMetaData(string fname)
    {
      string ret;
      string fType = System.IO.Path.GetExtension(fname).ToLower();
      string hash;
      switch (fType.ToLower() ?? "")
      {
        case ".jpeg":
        case ".jpg":
          {
            byte[] fileBytes = System.IO.File.ReadAllBytes(fname);

            for (int x = 0, loopTo = fileBytes.Length - 1; x <= loopTo; x++)
            {
              if (fileBytes[x] == JPEG_IMAGEHEADER[0] && fileBytes.Skip(x).Take(JPEG_IMAGEHEADER.Length).SequenceEqual(JPEG_IMAGEHEADER))
              {
                var _md5 = MD5.Create();
                byte[] p2h = fileBytes.Skip(x).ToArray();
                hash = BitConverter.ToString(_md5.ComputeHash(p2h));
                return hash;
                break;
              }
            }

            break;
          }
        case ".mp4":
          {
            using (var fs = new System.IO.FileStream(fname, System.IO.FileMode.Open))
            {

              int x = 0;
              ulong len = 0UL;
              byte[] fileBytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
              int bytesRead = fs.Read(fileBytes, 0, 8);

              while (!(fileBytes[4] == MP4_MDATHEADER[0] && fileBytes.Skip(4).Take(MP4_MDATHEADER.Length).SequenceEqual(MP4_MDATHEADER)))
              {
                byte[] t = fileBytes.Skip(4).Take(MP4_MDATHEADER.Length).ToArray();
                len = BitConverter.ToUInt32(fileBytes.Take(4).Reverse().ToArray(), 0);

                if (len == 1m)
                {
                  bytesRead = fs.Read(fileBytes, 0, 8);
                  len = BitConverter.ToUInt64(fileBytes.Reverse().ToArray(), 0);
                  fs.Position -= 8L;
                }

                x = (int)Math.Round(x + (decimal)len);
                fs.Position = x;
                bytesRead = fs.Read(fileBytes, 0, 8);
              }

              len = BitConverter.ToUInt32(fileBytes.Take(4).Reverse().ToArray(), 0);

              if (len == 1m)
              {
                bytesRead = fs.Read(fileBytes, 0, 8);
                len = BitConverter.ToUInt64(fileBytes.Reverse().ToArray(), 0);
                fs.Position -= 8L;
              }

              var _md5 = MD5.Create();
              fs.Position -= 8L;
              try
              {
                var p2h = new byte[(int)Math.Round(len - 1m) + 1];
                fs.Read(p2h, 0, (int)len);
                hash = BitConverter.ToString(_md5.ComputeHash(p2h));
              }
              catch (Exception ex)
              {
                hash = BitConverter.ToString(_md5.ComputeHash(fs));
              }
            }

            return hash;
          }

        default:
          {
            break;
          }

      }
      return null;
    }

    private void doUpdateBar(uint total, uint done)
    {
      if (done != 0L && total != 0L)
      {
        ToolStripProgressBar.Value = (int)Math.Round(100d * (done / (double)total));
      }
      Refresh();
    }
    private void getUpdateDel(updateBar del, uint tot, uint done)
    {
      StatusStrip1.Invoke(new updateBar(doUpdateBar), new object[] { tot, done });
    }

    private delegate void updateBar(uint tot, uint done);

    private void MarkFilesWithDupes_Click(object sender, EventArgs e)
    {
      string curFile = "";
      string curHash = "";
      KeyValuePair<string, string> k = default;

      bool noDupes = true;

      var masterMarkStart = DateTime.Now;
      TimeSpan masterMarkTime;


      List<string> hashes;

      if (!TargetIsSameAsMaster.Checked)
      {
       hashes = this.MasterFilesView.Items.ToList().AsQueryable().Join<ListViewItem, ListViewItem, string, string>(TargetFilesView.Items.ToList(), i1 => i1.SubItems[1].Text, i2 => i2.SubItems[1].Text, (i1, i2) => i1.SubItems[1].Text).ToList();
      }
      else
        hashes = MasterFilesView.Items.ToList().GroupBy(l => l.SubItems[1].Text).Select(g => g.Key).Where(h => h.Count() > 1).ToList();

      if (hashes is null || ((IEnumerable<string>)hashes).Count() == 0)
      {
        MessageBox.Show("No Duplicates were found!");
        return;
      }

      List<ListViewItem> tlvis = new List<ListViewItem>();
      foreach (string h in hashes)
      {
        List<ListViewItem> mlvis = MasterFilesView.Items.ToList().Where(i => h.Contains(i.SubItems[1].Text)).ToList();
        if (!TargetIsSameAsMaster.Checked)
        {
          tlvis = TargetFilesView.Items.ToList().Where(i => h.Contains(i.SubItems[1].Text)).ToList();
        }

        foreach (ListViewItem lvi in mlvis)
        {
          int i = MasterFilesView.Items.IndexOf(lvi);

          ((dupeData)MasterFilesView.Items[i].Tag).dupesInMaster = new List<ListViewItem>(mlvis);

          ((dupeData)MasterFilesView.Items[i].Tag).dupesInMaster.Remove(lvi);

          MasterFilesView.Items[i].BackColor = Color.Red;

          if (!TargetIsSameAsMaster.Checked && tlvis is not null && (tlvis is IEnumerable || tlvis is IQueryable))
          {

            ((dupeData)MasterFilesView.Items[i].Tag).dupesInTarget = new List<ListViewItem>(tlvis);

            foreach (ListViewItem titem in tlvis)
            {
              titem.BackColor = Color.DeepPink;
              ((dupeData)titem.Tag).dupesInTarget = new List<ListViewItem>(tlvis);
              ((dupeData)titem.Tag).dupesInTarget.Remove(titem);
            }
          }
        }
      }


      if (!masterMarkStart.Equals(default))
      {
        masterMarkTime = DateTime.Now.Subtract(masterMarkStart);
        StatusLabel.Text = StatusLabel.Text + " | " + "Mark Time: " + masterMarkTime.ToString();
      }


    }

    private void SelectMasterDirButton_Click(object sender, EventArgs e)
    {
      var fbd = new FolderBrowserDialog();
      if (!string.IsNullOrEmpty(MasterDirTextBox.Text))
      {
        try
        {
          fbd.SelectedPath = MasterDirTextBox.Text;
        }
        catch (Exception ex)
        {

        }
      }
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        MasterDirTextBox.Text = fbd.SelectedPath;
      }
    }

    private void SelectSearchDirButton_Click(object sender, EventArgs e)
    {
      var fbd = new FolderBrowserDialog();
      if (!string.IsNullOrEmpty(TargetDirTextBox.Text))
      {
        try
        {
          fbd.SelectedPath = TargetDirTextBox.Text;
        }
        catch (Exception ex)
        {

        }
      }
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        TargetDirTextBox.Text = fbd.SelectedPath;
      }
    }

    private void MasterFilesView_MouseDown(object Sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        clickedOn = MasterFilesView.GetItemAt(e.X, e.Y);
        if (clickedOn is not null)
        {
          MasterFilesView.ContextMenuStrip = FileRightClickContextMenu;
        }
      }
    }

    private void TargetFilesView_MouseDown(object Sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        clickedOn = TargetFilesView.GetItemAt(e.X, e.Y);
        if (clickedOn is not null)
        {
          TargetFilesView.ContextMenuStrip = FileRightClickContextMenu;
        }
      }
    }

    private void MasterFilesView_KeyDown(object sender, KeyEventArgs e)
    {
      if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) | System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
      {
        e.SuppressKeyPress = true;
        if (MasterFilesView.SelectedItems is not null)
        {
          int i = 0;

          if (MasterFilesView.SelectedItems.Count > 0)
          {
            i = MasterFilesView.SelectedIndices[0];
          }
          else
          {
            i = MasterFilesView.Items.IndexOf(MasterFilesView.FocusedItem);
          }

          if (e.KeyCode == Keys.PageDown)
          {
            if (i < MasterFilesView.Items.Count - 1)
            {
              for (int ii = i + 1, loopTo = MasterFilesView.Items.Count - 1; ii <= loopTo; ii++)
              {
                if (MasterFilesView.Items[ii].BackColor == Color.Red | MasterFilesView.Items[ii].BackColor == Color.GreenYellow)
                {
                  MasterFilesView.SelectedIndices.Clear();
                  MasterFilesView.SelectedIndices.Add(ii);
                  break;
                }
              }
            }
          }
          else if (e.KeyCode == Keys.PageUp)
          {
            if (i > 0)
            {
              for (int ii = i - 1; ii >= 0; ii -= 1)
              {
                if (MasterFilesView.Items[ii].BackColor == Color.Red | MasterFilesView.Items[ii].BackColor == Color.GreenYellow)
                {
                  MasterFilesView.SelectedIndices.Clear();
                  MasterFilesView.SelectedIndices.Add(ii);
                  break;
                }
              }
            }
          }
          try
          {
            MasterFilesView.FocusedItem = MasterFilesView.SelectedItems[0];
            MasterFilesView.EnsureVisible(MasterFilesView.SelectedIndices[0]);
          }
          catch (Exception ex)
          {

          }
        }
      }
    }

    private void TargetFilesView_KeyDown(object sender, KeyEventArgs e)
    {
      if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) | System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
      {
        e.SuppressKeyPress = true;
        if (TargetFilesView.SelectedItems is not null)
        {
          int i = 0;

          if (TargetFilesView.SelectedItems.Count > 0)
          {
            i = TargetFilesView.SelectedIndices[0];
          }
          else
          {
            i = TargetFilesView.Items.IndexOf(TargetFilesView.FocusedItem);
          }

          if (e.KeyCode == Keys.PageDown)
          {
            if (i < TargetFilesView.Items.Count - 1)
            {
              for (int ii = i + 1, loopTo = TargetFilesView.Items.Count - 1; ii <= loopTo; ii++)
              {
                if (TargetFilesView.Items[ii].BackColor == Color.DeepPink | TargetFilesView.Items[ii].BackColor == Color.GreenYellow)
                {
                  TargetFilesView.SelectedIndices.Clear();
                  TargetFilesView.SelectedIndices.Add(ii);
                  break;
                }
              }
            }
          }
          else if (e.KeyCode == Keys.PageUp)
          {
            if (i > 0)
            {
              for (int ii = i - 1; ii >= 0; ii -= 1)
              {
                if (TargetFilesView.Items[ii].BackColor == Color.DeepPink | TargetFilesView.Items[ii].BackColor == Color.GreenYellow)
                {
                  TargetFilesView.SelectedIndices.Clear();
                  TargetFilesView.SelectedIndices.Add(ii);
                  break;
                }
              }
            }
          }
          try
          {
            TargetFilesView.FocusedItem = TargetFilesView.SelectedItems[0];
            TargetFilesView.EnsureVisible(TargetFilesView.SelectedIndices[0]);
          }
          catch (Exception ex)
          {

          }
        }
      }
    }

    private void MasterFilesView_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {

      // If Not e.IsSelected Then    'If the item in question is being deselected...

      // End If

      // For Each olvi As ListViewItem In MdupeFiles
      // olvi.BackColor = Color.Red
      // Next

      // For Each olvi As ListViewItem In TdupeFiles
      // olvi.BackColor = Color.DeepPink
      // Next

      // MdupeFiles.Clear()
      // TdupeFiles.Clear()

      if (!e.IsSelected)    // If an item is being taken off the 'selected' list...
      {
        foreach (ListViewItem d in ((dupeData)e.Item.Tag).dupesInMaster)
        {
          MdupeFiles.Remove(d);
          d.BackColor = Color.Red;
        }
        foreach (ListViewItem d in ((dupeData)e.Item.Tag).dupesInTarget)
        {
          TdupeFiles.Remove(d);
          d.BackColor = Color.DeepPink;
        }
      }
      else if (e.IsSelected)
      {

        if (e.Item.Equals(MasterFilesView.SelectedItems[0]))
        {
          try
          {
            MediaViewer1.AddMedia(MasterDirTextBox.Text + @"\" + MasterFilesView.SelectedItems[0].Text);
          }
          catch (Exception ex)
          {

          }
        }
        MediaViewer1.VlcControl1.Play();

        // Dim mlvi As ListViewItem = MasterFilesView.SelectedItems(0)

        foreach (ListViewItem thing in ((dupeData)e.Item.Tag).dupesInMaster)
        {
          string S = thing.Text;
          foreach (ListViewItem lvi in MasterFilesView.Items)
          {
            if (lvi.Text is not null && lvi.Text.Equals(S))
            {
              MdupeFiles.Add(lvi);

              lvi.BackColor = Color.GreenYellow;
            }
          }
        }

        foreach (ListViewItem thing in ((dupeData)e.Item.Tag).dupesInTarget)
        {
          string S = thing.Text;
          foreach (ListViewItem lvi in TargetFilesView.Items)
          {
            if (lvi.Text is not null && lvi.Text.Equals(S))
            {
              TdupeFiles.Add(lvi);
              lvi.BackColor = Color.GreenYellow;
            }
          }
        }

      }
    }

    private void TargetFilesView_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {

      foreach (ListViewItem olvi in MdupeFiles)
        olvi.BackColor = Color.Red;

      foreach (ListViewItem olvi in TdupeFiles)
        olvi.BackColor = Color.DeepPink;

      MdupeFiles.Clear();
      TdupeFiles.Clear();

      if (TargetFilesView.SelectedItems.Count >= 1)
      {
        try
        {
          MediaViewer1.AddMedia(TargetDirTextBox.Text + @"\" + TargetFilesView.SelectedItems[0].Text);
        }
        catch (Exception ex)
        {

        }
        MediaViewer1.VlcControl1.Play();

        foreach (ListViewItem mlvi in TargetFilesView.SelectedItems)
        {
          // Dim mlvi As ListViewItem = TargetFilesView.SelectedItems(0)



          var t = new List<ListViewItem>(MasterFilesView.Items.Cast<ListViewItem>());
          var firstLvi = t.FirstOrDefault(x => x.SubItems[1].Text.Equals(mlvi.SubItems[1].Text));
          if (firstLvi is not null)
          {
            MasterFilesView.SelectedIndices.Clear();
            MasterFilesView.SelectedIndices.Add(MasterFilesView.Items.IndexOf(firstLvi));
            MasterFilesView.FocusedItem = firstLvi;
          }

        }

      }
    }

    private void KeepToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (ActiveControl is not null && ActiveControl is ListView)
      {
        ListView templv = (ListView)ActiveControl;
        if (templv.Equals(MasterFilesView) && templv.SelectedItems.Count > 0)
        {

          foreach (ListViewItem lvitem in templv.SelectedItems)
          {

            if (TargetIsSameAsMaster.Checked)
            {
              foreach (ListViewItem lvi in MdupeFiles)
              {
                try
                {
                  lvi.SubItems[2] = new ListViewItem.ListViewSubItem(clickedOn, false.ToString());
                }
                catch (Exception ex)
                {
                  lvi.SubItems.Add(new ListViewItem.ListViewSubItem(clickedOn, false.ToString()));
                }
              }
              try
              {
                lvitem.SubItems[2] = new ListViewItem.ListViewSubItem(clickedOn, true.ToString());
              }
              catch (Exception ex)
              {
                lvitem.SubItems.Add(new ListViewItem.ListViewSubItem(clickedOn, true.ToString()));
              }
            }
            else
            {
              foreach (ListViewItem lvi in TdupeFiles)
              {
                try
                {
                  lvi.SubItems[2] = new ListViewItem.ListViewSubItem(clickedOn, false.ToString());
                }
                catch (Exception ex)
                {
                  lvi.SubItems.Add(new ListViewItem.ListViewSubItem(clickedOn, false.ToString()));
                }
              }
              try
              {
                lvitem.SubItems[2] = new ListViewItem.ListViewSubItem(clickedOn, true.ToString());
              }
              catch (Exception ex)
              {
                lvitem.SubItems.Add(new ListViewItem.ListViewSubItem(clickedOn, true.ToString()));
              }
            }
          }
        }


        else
        {


        }
      }
    }

    private void DontKeepToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (ActiveControl is not null && ActiveControl is ListView)
      {
        ListView templv = (ListView)ActiveControl;
        if (templv.Equals(MasterFilesView) && templv.SelectedItems.Count == 1)
        {
          if (TargetIsSameAsMaster.Checked)
          {
            // For Each lvi As ListViewItem In MdupeFiles
            // Try
            // lvi.SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, False.ToString)
            // Catch ex As Exception
            // lvi.SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, False.ToString))
            // End Try
            // Next
            try
            {
              templv.SelectedItems[0].SubItems[2] = new ListViewItem.ListViewSubItem(clickedOn, false.ToString());
            }
            catch (Exception ex)
            {
              templv.SelectedItems[0].SubItems.Add(new ListViewItem.ListViewSubItem(clickedOn, false.ToString()));
            }
          }
          else
          {
            // For Each lvi As ListViewItem In TdupeFiles
            // Try
            // lvi.SubItems.Item(2) = New ListViewItem.ListViewSubItem(clickedOn, False.ToString)
            // Catch ex As Exception
            // lvi.SubItems.Add(New ListViewItem.ListViewSubItem(clickedOn, False.ToString))
            // End Try
            // Next
            try
            {
              templv.SelectedItems[0].SubItems[2] = new ListViewItem.ListViewSubItem(clickedOn, false.ToString());
            }
            catch (Exception ex)
            {
              templv.SelectedItems[0].SubItems.Add(new ListViewItem.ListViewSubItem(clickedOn, false.ToString()));
            }
          }
        }
        else
        {


        }
      }
    }

    private void ClearStatusMenuItem_Click(object sender, EventArgs e)
    {
      if (clickedOn is not null && clickedOn.SubItems.Count >= 3)
      {
        clickedOn.SubItems.Remove(clickedOn.SubItems[2]);
      }
    }

    private void ExecuteMasterDupes_Click(object sender, EventArgs e)
    {
      List<ListViewItem> filesToDelete = MasterFilesView.Items.ToList().Where(lvi => lvi.SubItems.Count >= 3 && lvi.SubItems[2].Text == false.ToString()).ToList();

      foreach (ListViewItem f in filesToDelete)
      {
        string fName = MasterDirTextBox.Text + @"\" + f.Text;

        try
        {
          System.IO.File.Delete(fName);
          MasterFilesView.Items.Remove(f);
        }
        catch (Exception ex)
        {
          MediaViewer1.RemoveImage();
          MediaViewer1.RemoveVideo();
          System.IO.File.Delete(fName);
          MasterFilesView.Items.Remove(f);
        }
        finally
        {

        }
      }




      List<ListViewItem> filesToKeep = MasterFilesView.Items.ToList().Where(lvi => lvi.SubItems.Count >= 3 && lvi.SubItems[2].Text == false.ToString()).ToList();

      foreach (ListViewItem f in filesToKeep)
      {
        f.BackColor = Color.White;
        f.SubItems[2].Text = "";
        ((dupeData)f.Tag).dupesInMaster.Clear();
      }

    }

    private void MasterFilesView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      // Get the column that needs to be sorted
      var sOrdCol = MasterFilesView.Columns[e.Column];

      // Figure out the new sorting order
      SortOrder sOrd;
      if (sortingCol is null)
      {
        // New column was clicked, set the order to ascending
        sOrd = SortOrder.Ascending;
      }
      else
      {
        // See if its the same column
        if (sOrdCol.Equals(sortingCol))
        {
          // if it is, change the sorting order
          if (sortingCol.Text.StartsWith("> "))
          {
            sOrd = SortOrder.Descending;
          }
          else
          {
            sOrd = SortOrder.Ascending;
          }
        }
        else
        {
          // It's a new column, sort ascending
          sOrd = SortOrder.Ascending;
        }
        // Remove the old sorting indicator
        sortingCol.Text = sortingCol.Text.Substring(2);
      }


      // Now display the new sorting order
      sortingCol = sOrdCol;
      if (sOrd == SortOrder.Ascending)
      {
        sOrdCol.Text = "> " + sOrdCol.Text;
      }
      else
      {
        sOrdCol.Text = "< " + sOrdCol.Text;
      }

      // Create a comparer...
      MasterFilesView.ListViewItemSorter = new Generics.ListViewItemComparer(e.Column, sOrd);

      // Aaaaand SORT
      MasterFilesView.Sort();
    }

    private void TargetFilesView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      // Get the column that needs to be sorted
      var sOrdCol = TargetFilesView.Columns[e.Column];

      // Figure out the new sorting order
      SortOrder sOrd;
      if (sortingCol is null)
      {
        // New column was clicked, set the order to ascending
        sOrd = SortOrder.Ascending;
      }
      else
      {
        // See if its the same column
        if (sOrdCol.Equals(sortingCol))
        {
          // if it is, change the sorting order
          if (sortingCol.Text.StartsWith("> "))
          {
            sOrd = SortOrder.Descending;
          }
          else
          {
            sOrd = SortOrder.Ascending;
          }
        }
        else
        {
          // It's a new column, sort ascending
          sOrd = SortOrder.Ascending;
        }
        // Remove the old sorting indicator
        sortingCol.Text = sortingCol.Text.Substring(2);
      }


      // Now display the new sorting order
      sortingCol = sOrdCol;
      if (sOrd == SortOrder.Ascending)
      {
        sOrdCol.Text = "> " + sOrdCol.Text;
      }
      else
      {
        sOrdCol.Text = "< " + sOrdCol.Text;
      }

      // Create a comparer...
      TargetFilesView.ListViewItemSorter = new Generics.ListViewItemComparer(e.Column, sOrd);

      // Aaaaand SORT
      TargetFilesView.Sort();
    }

    private void DupeChecker_Load(object sender, EventArgs e)
    {
      StatusLabel.Text = "";
    }

    private void DupeChecker_SizeChanged(object sender, EventArgs e)
    {
      int masterWidth = MasterFilesView.Width - (MasterFilesView.Margin.Left + MasterFilesView.Margin.Right);
      MasterFilesView.Columns[0].Width = masterWidth - 120;
      MasterFilesView.Columns[1].Width = 60;
      MasterFilesView.Columns[2].Width = 60;

      int targetWidth = TargetFilesView.Width - (TargetFilesView.Margin.Left + TargetFilesView.Margin.Right);
      TargetFilesView.Columns[0].Width = targetWidth - 120;
      TargetFilesView.Columns[1].Width = 60;
      TargetFilesView.Columns[2].Width = 60;
    }
  }
}