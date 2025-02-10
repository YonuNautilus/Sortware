using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using LibVLCSharp.Shared;

namespace SortWare
{
  public partial class MainInterface
  {
    public const string _imgExtensions = ".png .jpg .jpeg .jfif .tif .tiff .gif .bmp .webp";
    public const string _vidExtensions = ".mov .webm .wmv .mp4 .avi .mkv .m4v .m2ts .mts .mpg .mpeg .flv";
    public const string _miscExtensions = ".zip .rar";

    public const string SORTLOGFILENAME = @"\SortWareMoveLogs.log";
    public const int _1STAR = 1;
    public const int _2STAR = 25;
    public const int _3STAR = 50;
    public const int _4STAR = 75;
    public const int _5STAR = 99;

    private uint _rating = 0U;

    private const string TAGIDREGEX = @"^[^\t]+";

    private List<string> _extensions;
    private string selectedTags = "";

    private Stack<SortDirectory> _selectedFolderStack = new Stack<SortDirectory>();
    private Stack<List<string>> _selectedFileStack = new Stack<List<string>>();

    protected SortDirectory _innerDir;
    protected string _allowedExtensions = "";
    protected SortSettings _settings;

    private System.IO.FileStream imgStream;

    private System.IO.StreamReader _logReader;
    private System.IO.StreamWriter _logWriter;

    private string DataFolderDir = "";

    public System.IO.FileStream tempGif;

    public int clickedOn = -1;

    private string sortByDefault = "----";
    private string sortByDate = "Date";
    private string sortByName = "Name";
    private string sortBySize = "Size";
    private string sortByType = "Filetype";
    private string[] sortBys;

    public string shortcut0, shortcut1, shortcut2, shortcut3, shortcut4, shortcut5, shortcut6, shortcut7, shortcut8, shortcut9;

    public MainInterface()
    {
      sortBys = new[] { sortByDefault, sortByDate, sortByName, sortBySize, sortByType };
      InitializeComponent();
    }

    private void MainInterface_Load(object sender, EventArgs e)
    {
      ImageList1.Images.AddStrip(My.Resources.Resources.comctl32_125);
      // Me.moveUpDir.Image = ImageList1.Images(8)
      moveUpDir.Image = My.Resources.Resources.shell32_255.ToBitmap();
      enterDir.Image = My.Resources.Resources.shell32_16805.ToBitmap();
      SaveRatingButton.Image = My.Resources.Resources.shell32_16761.ToBitmap();
      DeleteDirButton.Image = My.Resources.Resources.imageres_54.ToBitmap();
      PurgeAllEmptyDirsButton.Image = My.Resources.Resources.imageres_5305.ToBitmap();

      SortByComboBox.Items.Clear();

      foreach (string s in sortBys)
        SortByComboBox.Items.Add(s);

      var _settings = new SortSettings();

      try
      {
        getLogFile();
      }
      catch (Exception ex)
      {

      }
      TrackBar1_Scroll(null, null);

      DataFolderDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SortWare";

      MediaViewer1.loadTypes(_imgExtensions, _vidExtensions);
    }

    private void ButtonOnOff(ref Button button, bool enable)
    {
      button.Enabled = enable;
    }

    private void refreshPresortedFiles()
    {
      FilesToBeSorted.Items.Clear();
      if (_innerDir is not null && System.IO.Directory.Exists(_innerDir.fullName))
      {
        // Add the contents of the folder to Listbox1

        IEnumerable<string> filePathsSorted;
        switch (SortByComboBox.Text ?? "")
        {
          case var @case when @case == (sortByDate ?? ""):
            {
              filePathsSorted = from f in System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                let fileCreationTime = System.IO.File.GetCreationTime(f)
                                where true
                                orderby fileCreationTime
                                select f.Replace(PreSortedDirTextBox.Text, "");
              break;
            }
          case var case1 when case1 == (sortByName ?? ""):
            {
              filePathsSorted = from f in System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                let fileName = f.Replace(PreSortedDirTextBox.Text, "")
                                where true
                                orderby fileName
                                select f.Replace(PreSortedDirTextBox.Text, "");
              break;
            }
          case var case2 when case2 == (sortBySize ?? ""):
            {
              filePathsSorted = from f in System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                let fileSize = new System.IO.FileInfo(f).Length
                                where true
                                orderby fileSize
                                select f.Replace(PreSortedDirTextBox.Text, "");
              break;
            }
          case var case3 when case3 == (sortByType ?? ""):
            {
              filePathsSorted = from f in System.IO.Directory.EnumerateFiles(_innerDir.fullName)
                                let fileType = System.IO.Path.GetExtension(f)
                                where true
                                orderby fileType
                                // Case sortByDefault

                                select f.Replace(PreSortedDirTextBox.Text, "");
              break;
            }

          default:
            {
              filePathsSorted = System.IO.Directory.GetFiles(_innerDir.fullName, "*.*");
              break;
            }
        }

        if (!string.IsNullOrWhiteSpace(ToBeSortedFilter.Text) && filePathsSorted is not null && filePathsSorted.Count() > 0)
          filePathsSorted = filePathsSorted.Select(s => System.IO.Path.GetFileNameWithoutExtension(s).ToLower()).Where(s => s.Contains(this.ToBeSortedFilter.Text.ToLower()) == true).ToList();

        foreach (var @file in filePathsSorted.ToList())
        {
          if (TypeSelector1.isAllowed(@file))
          {
            FilesToBeSorted.Items.Add(@file.Replace(PreSortedDirTextBox.Text, ""));
          }
        }
      }
    }

    private void refreshPresortedFolders()
    {
      int lastIndex = FoldersToBeSorted.SelectedIndex;
      FoldersToBeSorted.Items.Clear();

      var folderPathsSorted = default(IEnumerable<SortDirectory>);

      if (System.IO.Directory.Exists(_innerDir.fullName))
      {
        if (!string.IsNullOrWhiteSpace(ToBeSortedFoldersFilter.Text))
        {
          folderPathsSorted = from f in System.IO.Directory.GetDirectories(_innerDir.fullName)
                              let n = System.IO.Path.GetFileName(f)
                              where n.Contains(ToBeSortedFoldersFilter.Text)
                              select new SortDirectory(f);
        }
        else
        {
          folderPathsSorted = from f in System.IO.Directory.GetDirectories(_innerDir.fullName)
                              select new SortDirectory(f);
        }
      }

      FoldersToBeSorted.Items.AddRange(folderPathsSorted.ToArray());

      if (FoldersToBeSorted.Items.Count > 0 && lastIndex < FoldersToBeSorted.Items.Count)
      {
        FoldersToBeSorted.SelectedIndex = lastIndex;
      }
    }

    private void refreshMainDirs()
    {
      MainDirsTree.BeginUpdate();

      MainDirsTree.Nodes.Clear();

      try
      {
        addMains(_settings.getList(SortSettings.dirType.MAINDIR));

        if (!string.IsNullOrWhiteSpace(MainDirsFilter.Text))
        {
          // filterDirNode()
          MainDirsTree.ExpandAll();
        }

        addMains(_settings.getList(SortSettings.dirType.CONVERTDIR));
      }
      catch (Exception ex)
      {

      }

      MainDirsTree.EndUpdate();
    }

    private void addMains(List<SortDirectory> sdl)
    {
      foreach (SortDirectory m in sdl)
      {
        TreeNode tempNode;

        // If there is valid filter text
        if (!string.IsNullOrWhiteSpace(MainDirsFilter.Text))
        {
          if (m.matchesFilter(MainDirsFilter.Text))
          {
            tempNode = MainDirsTree.Nodes.Add(m.getName());
            tempNode.Tag = m;

            if (m.hasSubs())
            {
              addMains(m.getSubs(), ref tempNode);
            }
          }
        }

        else    // If filter textbox is empty
        {

          tempNode = MainDirsTree.Nodes.Add(m.getName());
          tempNode.Tag = m;

          if (m.hasSubs())
          {
            addMains(m.getSubs(), ref tempNode);
          }

        }
      }
    }

    private void addMains(List<SortDirectory> sdl, ref TreeNode root)
    {
      foreach (SortDirectory m in sdl)
      {
        TreeNode tempNode;

        // If there is valid filter text
        if (!string.IsNullOrWhiteSpace(MainDirsFilter.Text))
        {
          if (m.matchesFilter(MainDirsFilter.Text))
          {
            tempNode = root.Nodes.Add(m.getName());
            tempNode.Tag = m;

            if (m.hasSubs())
            {
              addMains(m.getSubs(), ref tempNode);
            }
          }
        }

        else    // If filter textbox is empty
        {

          tempNode = root.Nodes.Add(m.getName());
          tempNode.Tag = m;

          if (m.hasSubs())
          {
            addMains(m.getSubs(), ref tempNode);
          }

        }
      }
    }

    public void getLogFile()
    {
      if (System.IO.File.Exists(RootDirTextBox.Text + SORTLOGFILENAME))
      {
        _logWriter = new System.IO.StreamWriter(RootDirTextBox.Text + SORTLOGFILENAME);
      }
      else
      {
        var fs = System.IO.File.Create(RootDirTextBox.Text + SORTLOGFILENAME);
        fs.Close();
      }
    }

    public void doMoveFile2(string filePath, string targetDir, string tag = "")
    {
      if (!System.IO.File.Exists(filePath))
      {
        throw new Exception("File does not exist!");
      }
      if (!System.IO.Directory.Exists(targetDir))
      {
        throw new Exception("Target directory does not exist!");
      }

      // Try
      MediaViewer1.RemoveVideo(filePath);
      MediaViewer1.RemoveImage(filePath);

      // Dim tempFile = New IO.FileInfo(file)
      string newName = tag + System.IO.Path.GetFileName(filePath);
      string src = System.IO.Path.GetDirectoryName(filePath);
      string dest = targetDir + @"\" + newName;

      System.IO.File.Move(filePath, dest);

      writeToLogFile(src, dest, tag);
      // Catch ex As Exception

      // End Try

      FilesToBeSorted.Select();
    }

    public void doMoveFile(string @file, string targetDir, string tag = "")
    {
      if (!System.IO.File.Exists(PreSortedDirTextBox.Text + @file))
      {
        throw new Exception("File does not exist!");
      }
      if (!System.IO.Directory.Exists(targetDir))
      {
        throw new Exception("Target directory does not exist!");
      }

      // Try
      MediaViewer1.RemoveVideo(@file);
      MediaViewer1.RemoveImage(@file);

      // Dim tempFile = New IO.FileInfo(file)
      string newName = tag + System.IO.Path.GetFileName(@file);
      string src = PreSortedDirTextBox.Text + @file;
      string dest = targetDir + @"\" + newName;

      string fname = System.IO.Path.GetFileNameWithoutExtension(@file);
      fname = fname + ".srt";

      System.IO.File.Move(src, dest);

      writeToLogFile(src, dest, tag);
      // Catch ex As Exception

      // End Try

      FilesToBeSorted.Select();
    }

    public string doMoveDir(SortDirectory dir, string targetDir, string tag = "")
    {
      // Dim ret As Boolean = True
      string dest = "";
      if (!System.IO.Directory.Exists(dir.fullName))
      {
        throw new Exception("Directory does not exist!");
      }
      if (!System.IO.Directory.Exists(targetDir))
      {
        throw new Exception("Target directory does not exist!");
      }

      try
      {
        MediaViewer1.RemoveImage();
        MediaViewer1.RemoveVideo();

        string newName = tag + dir.getName();
        dest = targetDir + @"\" + newName;

        System.IO.Directory.Move(dir.fullName, dest);

        writeToLogFile(dir.fullName, dest, tag);
      }

      catch (Exception ex)
      {
        PropertiesSaveStatus.Text = ex.Message;
      }

      return dest;
    }

    public void writeToLogFile(string src, string dest, string tag)
    {
      _logWriter = new System.IO.StreamWriter(RootDirTextBox.Text + SORTLOGFILENAME, true);
      _logWriter.WriteLine(DateTime.Now.ToString() + Constants.vbTab + src + Constants.vbTab + dest + Constants.vbTab + tag);
      _logWriter.Close();
    }

    public async void setRatingFromSelection()
    {
      string path = "";
      try
      {
        string fileType = System.IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString());
        path = PreSortedDirTextBox.Text + FilesToBeSorted.SelectedItem.ToString();
        uint rating = 0;

        var file = ShellFile.FromFilePath(path);
        uint? tempRating = file.Properties.System.Rating.Value;

        if (tempRating.HasValue)
        {
          rating = (uint)tempRating.Value;
        }

        if (_vidExtensions.Contains(fileType))
        {
          //var prop = await @file.Properties.GetVideoPropertiesAsync();
          //setStarRating(prop.Rating);
        }
        else if (_imgExtensions.Contains(fileType))
        {
          //var prop = await @file.Properties.GetImagePropertiesAsync();
          //setStarRating(prop.Rating);
        }

        setStarRating(rating);
      }
      catch (Exception ex)
      {
        PropertiesSaveStatus.Text = "Something went wrong, until to get file at " + path;
      }
    }

    /*public async Task<StorageFile> getStorageFile(string p)
    {
      try
      {
        return await StorageFile.GetFileFromPathAsync(p);
      }
      catch (Exception e)
      {
        return null;
      }
    }*/

    private void setStarRating(uint rating)
    {
      StarRatingPanel.Enabled = true;
      switch (rating)
      {
        case 0U:
          {
            Star1.Checked = false;
            break;
          }
        case _1STAR:
          {
            Star1.Checked = true;
            break;
          }
        case _2STAR:
          {
            Star2.Checked = true;
            break;
          }
        case _3STAR:
          {
            Star3.Checked = true;
            break;
          }
        case _4STAR:
          {
            Star4.Checked = true;
            break;
          }
        case _5STAR:
          {
            Star5.Checked = true;
            break;
          }
      }
    }

    private void StarRatingChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox)
      {
        if (((CheckBox)sender).Tag is null)
        {
          if (ReferenceEquals((CheckBox)sender, Star1))
          {
            Star1.CheckedChanged -= StarRatingChanged;
            Star2.CheckedChanged -= StarRatingChanged;
            Star3.CheckedChanged -= StarRatingChanged;
            Star4.CheckedChanged -= StarRatingChanged;
            Star5.CheckedChanged -= StarRatingChanged;

            Star1.Checked = true;
            Star2.Checked = false;
            Star3.Checked = false;
            Star4.Checked = false;
            Star5.Checked = false;
            Star1.Tag = "Previously Clicked";
            Star2.Tag = null;
            Star3.Tag = null;
            Star4.Tag = null;
            Star5.Tag = null;

            Star1.CheckedChanged += StarRatingChanged;
            Star2.CheckedChanged += StarRatingChanged;
            Star3.CheckedChanged += StarRatingChanged;
            Star4.CheckedChanged += StarRatingChanged;
            Star5.CheckedChanged += StarRatingChanged;

            if (Star1.Checked)
            {
              _rating = 1U;
            }
            else
            {
              _rating = 0U;
            }
          }
          else if (ReferenceEquals((CheckBox)sender, Star2))
          {
            Star1.CheckedChanged -= StarRatingChanged;
            Star2.CheckedChanged -= StarRatingChanged;
            Star3.CheckedChanged -= StarRatingChanged;
            Star4.CheckedChanged -= StarRatingChanged;
            Star5.CheckedChanged -= StarRatingChanged;

            Star1.Checked = true;
            Star2.Checked = true;
            Star3.Checked = false;
            Star4.Checked = false;
            Star5.Checked = false;

            Star1.Tag = null;
            Star2.Tag = "Previously Clicked";
            Star3.Tag = null;
            Star4.Tag = null;
            Star5.Tag = null;


            Star1.CheckedChanged += StarRatingChanged;
            Star2.CheckedChanged += StarRatingChanged;
            Star3.CheckedChanged += StarRatingChanged;
            Star4.CheckedChanged += StarRatingChanged;
            Star5.CheckedChanged += StarRatingChanged;

            if (Star2.Checked)
            {
              _rating = 25U;
            }
            else
            {
              _rating = 0U;
            }
          }
          else if (ReferenceEquals((CheckBox)sender, Star3))
          {
            Star1.CheckedChanged -= StarRatingChanged;
            Star2.CheckedChanged -= StarRatingChanged;
            Star3.CheckedChanged -= StarRatingChanged;
            Star4.CheckedChanged -= StarRatingChanged;
            Star5.CheckedChanged -= StarRatingChanged;

            Star1.Checked = true;
            Star2.Checked = true;
            Star3.Checked = true;
            Star4.Checked = false;
            Star5.Checked = false;
            Star2.Tag = null;
            Star2.Tag = null;
            Star3.Tag = "Previously Clicked";
            Star4.Tag = null;
            Star5.Tag = null;

            Star1.CheckedChanged += StarRatingChanged;
            Star2.CheckedChanged += StarRatingChanged;
            Star3.CheckedChanged += StarRatingChanged;
            Star4.CheckedChanged += StarRatingChanged;
            Star5.CheckedChanged += StarRatingChanged;

            if (Star3.Checked)
            {
              _rating = 50U;
            }
            else
            {
              _rating = 0U;
            }
          }
          else if (ReferenceEquals((CheckBox)sender, Star4))
          {
            Star1.CheckedChanged -= StarRatingChanged;
            Star2.CheckedChanged -= StarRatingChanged;
            Star3.CheckedChanged -= StarRatingChanged;
            Star4.CheckedChanged -= StarRatingChanged;
            Star5.CheckedChanged -= StarRatingChanged;

            Star1.Checked = true;
            Star2.Checked = true;
            Star3.Checked = true;
            Star4.Checked = true;
            Star5.Checked = false;
            Star2.Tag = null;
            Star2.Tag = null;
            Star3.Tag = null;
            Star4.Tag = "Previously Clicked";
            Star5.Tag = null;

            Star1.CheckedChanged += StarRatingChanged;
            Star2.CheckedChanged += StarRatingChanged;
            Star3.CheckedChanged += StarRatingChanged;
            Star4.CheckedChanged += StarRatingChanged;
            Star5.CheckedChanged += StarRatingChanged;

            if (Star4.Checked)
            {
              _rating = 75U;
            }
            else
            {
              _rating = 0U;
            }
          }
          else if (ReferenceEquals((CheckBox)sender, Star5))
          {
            Star1.CheckedChanged -= StarRatingChanged;
            Star2.CheckedChanged -= StarRatingChanged;
            Star3.CheckedChanged -= StarRatingChanged;
            Star4.CheckedChanged -= StarRatingChanged;
            Star5.CheckedChanged -= StarRatingChanged;

            Star1.Checked = true;
            Star2.Checked = true;
            Star3.Checked = true;
            Star4.Checked = true;
            Star5.Checked = true;
            Star2.Tag = null;
            Star2.Tag = null;
            Star3.Tag = null;
            Star4.Tag = null;
            Star5.Tag = "Previously Clicked";

            Star1.CheckedChanged += StarRatingChanged;
            Star2.CheckedChanged += StarRatingChanged;
            Star3.CheckedChanged += StarRatingChanged;
            Star4.CheckedChanged += StarRatingChanged;
            Star5.CheckedChanged += StarRatingChanged;

            if (Star5.Checked)
            {
              _rating = 99U;
            }
            else
            {
              _rating = 0U;
            }
          }
        }
        else
        {
          Star1.CheckedChanged -= StarRatingChanged;
          Star2.CheckedChanged -= StarRatingChanged;
          Star3.CheckedChanged -= StarRatingChanged;
          Star4.CheckedChanged -= StarRatingChanged;
          Star5.CheckedChanged -= StarRatingChanged;

          Star1.Checked = false;
          Star2.Checked = false;
          Star3.Checked = false;
          Star4.Checked = false;
          Star5.Checked = false;

          Star1.Tag = null;
          Star2.Tag = null;
          Star3.Tag = null;
          Star4.Tag = null;
          Star5.Tag = null;

          Star1.CheckedChanged += StarRatingChanged;
          Star2.CheckedChanged += StarRatingChanged;
          Star3.CheckedChanged += StarRatingChanged;
          Star4.CheckedChanged += StarRatingChanged;
          Star5.CheckedChanged += StarRatingChanged;
        }
      }
    }

    private void FindRootDirButton_Click(object sender, EventArgs e)
    {

      var fbd = new FolderBrowserDialog();
      if (string.IsNullOrEmpty(PreSortedDirTextBox.Text))
      {
        fbd.RootFolder = Environment.SpecialFolder.MyComputer;
      }
      else
      {
        // fbd.RootFolder = 
      }

      if (fbd.ShowDialog() == DialogResult.OK)
      {
        RootDirTextBox.Text = fbd.SelectedPath;
        if (System.IO.File.Exists(RootDirTextBox.Text + @"\sortSettings.xml"))
        {
          _settings = SortSettings.CreateFromXml(RootDirTextBox.Text);

          if (!_settings.IsValidSettings())
          {
            FindRootDirButton.BackColor = Color.Red;
            OpenSortSettingsButton.BackColor = Color.Red;
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black;
            OpenSortSettingsButton.Text = "Fix Sort Settings";
            StatusLabel.Text = "Invalid Sort Settings - Please open settings to fix";
          }
          else
          {
            FindRootDirButton.BackColor = SystemColors.Control;
            OpenSortSettingsButton.BackColor = SystemColors.Control;
            OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black;
            OpenSortSettingsButton.Text = "Open Sort Settings";
            StatusLabel.Text = "";
          }

          refreshMainDirs();
        }
        else    // A .sortSettings file does not exist
        {
          Debug.WriteLine(".sortSettings file non existent");
          OpenSortSettingsButton.BackColor = Color.Red;
          OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon;
          OpenSortSettingsButton.Text = ".sortSettings file not found!";
          StatusLabel.Text = ".sortSettings file not found";
          openLogsButton.Enabled = false;
          refreshMainDirs();
        }
      }

    }

    private void OpenSortSettingsButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(RootDirTextBox.Text))
      {
        StatusLabel.Text = "No Root Directory Selected";
        return;
      }

      var _sortSettings = new SortSettingsDialog(RootDirTextBox.Text);

      _sortSettings.ShowDialog();

      if (System.IO.File.Exists(RootDirTextBox.Text + @"\sortSettings.xml"))
      {
        OpenSortSettingsButton.BackColor = SystemColors.Control;
        OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Black;
        OpenSortSettingsButton.Text = "Open Folder Settings";
        _settings = SortSettings.CreateFromXml(RootDirTextBox.Text);
      }
      else
      {
        OpenSortSettingsButton.BackColor = Color.Red;
        OpenSortSettingsButton.FlatAppearance.BorderColor = Color.Maroon;
      }

      refreshMainDirs();
    }

    private void FindPreSortedDirButton_Click(object sender, EventArgs e)
    {
      var fbd = new FolderBrowserDialog();
      fbd.RootFolder = Environment.SpecialFolder.MyComputer;
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        PreSortedDirTextBox.Text = fbd.SelectedPath;
        _innerDir = new SortDirectory(PreSortedDirTextBox.Text, 0);

        refreshPresortedFiles();
        refreshPresortedFolders();
      }

    }

    private void OpenPresortsButton_Click(object sender, EventArgs e)
    {
      if (_settings is null | string.IsNullOrEmpty(RootDirTextBox.Text))
      {
        return;
      }
      var selectedDir = new FolderSelector(_settings);
      if (selectedDir.ShowDialog() == DialogResult.OK)
      {
        if (selectedDir.getSelectedDir() is SortDirectory)
        {
          PreSortedDirTextBox.Text = selectedDir.getSelectedDir().fullName;
          _innerDir = new SortDirectory(PreSortedDirTextBox.Text, 0);
          refreshPresortedFiles();
          refreshPresortedFolders();
        }
      }
    }

    private void FilesToBeSorted_SelectedIndexChanged(object sender, EventArgs e)
    {
      clickedOn = -1;
      int fileType = -1;
      string fileName = "";

      if (FilesToBeSorted.SelectedItem is string)
      {
        fileName = PreSortedDirTextBox.Text + Conversions.ToString(FilesToBeSorted.SelectedItem);
      }
      else
      {
        return;
      }

      // Calculate file size in B, KB, MB or GB to show on FileSizeLabel
      long fsize = new System.IO.FileInfo(fileName).Length;
      int i = 0;
      long sizeTemp = fsize;
      while (sizeTemp / (double)1024 > 1d)
      {
        sizeTemp = (long)Math.Round(sizeTemp / 1024d);
        i += 1;
      }
      string byteType = "";
      switch (i)
      {
        case 0:
          {
            byteType = "B";
            break;
          }
        case 1:
          {
            byteType = "KB";
            break;
          }
        case 2:
          {
            byteType = "MB";
            break;
          }
        case 3:
          {
            byteType = "GB";
            break;
          }
        case 4:
          {
            byteType = "TB";
            break;
          }
      }
      FileSizeLabel.Text = sizeTemp + " " + byteType;

      do
      {
        try
        {
          if (!FilesToBeSorted.Focused)
          {
            break;
          }
          MediaViewer1.AddMedia(fileName);

          if (!System.IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString()).ToUpper().Contains("GIF"))
          {
            setRatingFromSelection();
          }
        }

        catch (Exception Ex)
        {
          Interaction.MsgBox("Cannot Load File!", Constants.vbCritical, "Problem enountered while loading file!");
        }
      }
      while (false);

    }

    private void FilesToBeSorted_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        clickedOn = FilesToBeSorted.IndexFromPoint(e.X, e.Y);
        FilesToBeSorted.ContextMenuStrip = FileRightClickContextMenu;
        if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
        {

          FilesToBeSorted.SelectedIndices.Add(clickedOn);
        }
        else
        {
          FilesToBeSorted.SelectedIndices.Clear();
        }
      }
    }

    private void FilesToBeSorted_GotFocus(object Sender, EventArgs e)
    {
      if (FilesToBeSorted.SelectedItems.Count > 0)
      {
        MoveFilesButton.Enabled = true;
        MoveFolderButton.Enabled = false;
        MoveFolderSubDirButton.Enabled = false;
      }

    }

    private void FoldersToBeSorted_GotFocus(object Sender, EventArgs e)
    {
      if (FoldersToBeSorted.SelectedItems.Count > 0)
      {
        MoveFilesButton.Enabled = false;
        MoveFolderButton.Enabled = true;
        MoveFolderSubDirButton.Enabled = true;
      }
    }

    private void OpenLogsButton_Click(object sender, EventArgs e)
    {
      if (System.IO.File.Exists(RootDirTextBox.Text + SORTLOGFILENAME))
      {
        System.IO.TextReader reader = new System.IO.StreamReader(RootDirTextBox.Text + SORTLOGFILENAME);
        string[] logArr = Strings.Split(reader.ReadToEnd().Trim(), Constants.vbNewLine);
        reader.Dispose();
        var argmainInt = this;
        var lviewer = new LogViewer(logArr, ref argmainInt);
        lviewer.Show();
      }
    }

    private void MoveFilesButton_Click(object sender, EventArgs e)
    {
      if (FilesToBeSorted.SelectedItems.Count > 0 && MainDirsTree.SelectedNode is not null && MainDirsTree.SelectedNode.Tag is SortDirectory)
      {
        // Beep()
        int toResel = FilesToBeSorted.SelectedIndex;

        if (imgStream is not null)
        {
          try
          {
            imgStream.Close();
          }
          catch (Exception ex)
          {
            // Beep()
          }
        }


        foreach (var s in FilesToBeSorted.SelectedItems)
        {
          try
          {
            doMoveFile(Conversions.ToString(s), ((SortDirectory)MainDirsTree.SelectedNode.Tag).fullName, selectedTags);
          }
          catch (Exception ex)
          {
            Interaction.Beep();
            if (!ex.Message.Contains("Cannot create a file when that file already exists."))
            {
              PropertiesSaveStatus.Text = "Something went wrong while attempting to move file";
            }
            else
            {
              PropertiesSaveStatus.Text = ex.Message.Trim();
            }
          }
        }
        refreshPresortedFiles();
        if (toResel >= FilesToBeSorted.Items.Count)
        {
          FilesToBeSorted.SelectedIndex = FilesToBeSorted.Items.Count - 1;
        }
        else if (!(toResel >= FilesToBeSorted.Items.Count))
        {
          FilesToBeSorted.SelectedIndex = toResel;
        }
        FilesToBeSorted.Select();
      }
    }

    private void PresortFileToPresortFolderButton_Click(object sender, EventArgs e)
    {

      if (FilesToBeSorted.SelectedItems.Count > 0 && FoldersToBeSorted.SelectedItem is not null && FoldersToBeSorted.SelectedItem is SortDirectory)
      {
        // Beep()
        int toResel = FilesToBeSorted.SelectedIndex;
        string tagsToAdd = "";

        if (imgStream is not null)
        {
          try
          {
            imgStream.Close();
          }
          catch (Exception ex)
          {
            Interaction.Beep();
          }
        }


        foreach (var s in FilesToBeSorted.SelectedItems)
        {
          try
          {
            doMoveFile(Conversions.ToString(s), ((SortDirectory)FoldersToBeSorted.SelectedItem).fullName, selectedTags);
          }
          catch (Exception ex)
          {
            Interaction.Beep();
            if (ex.Message.Contains("Cannot create a file When that file already exists."))
            {
              PropertiesSaveStatus.Text = "Something went wrong while attempting to move file";
            }
            else
            {
              PropertiesSaveStatus.Text = ex.Message.Trim();
            }
          }
        }
        refreshPresortedFiles();
        if (toResel >= FilesToBeSorted.Items.Count)
        {
          FilesToBeSorted.SelectedIndex = FilesToBeSorted.Items.Count - 1;
        }
        else if (!(toResel >= FilesToBeSorted.Items.Count))
        {
          FilesToBeSorted.SelectedIndex = toResel;
        }
        FilesToBeSorted.Select();
      }
    }

    private void MoveFolderButton_Click(object sender, EventArgs e)
    {
      if (FoldersToBeSorted.SelectedItems.Count > 0 && MainDirsTree.SelectedNode is not null && MainDirsTree.SelectedNode.Tag is SortDirectory)
      {
        string tagsToAdd = "";
        foreach (var t in TagsSelector.SelectedItems)
        {
          var m = Regex.Match(Conversions.ToString(t), TAGIDREGEX);
          tagsToAdd = tagsToAdd + m.ToString();
        }
        foreach (var s in FoldersToBeSorted.SelectedItems)
          doMoveDir((SortDirectory)s, ((SortDirectory)MainDirsTree.SelectedNode.Tag).fullName, selectedTags);
        refreshPresortedFolders();
      }
    }

    private void MoveFolderSubDir_Click(object sender, EventArgs e)
    {
      if (FoldersToBeSorted.SelectedItems.Count > 0 && MainDirsTree.SelectedNode is not null && MainDirsTree.SelectedNode.Tag is SortDirectory)
      {
        foreach (SortDirectory s in FoldersToBeSorted.SelectedItems)
        {
          string newLoc = doMoveDir(s, ((SortDirectory)MainDirsTree.SelectedNode.Tag).fullName);
          if (string.IsNullOrEmpty(newLoc))
          {
            Interaction.Beep();
            PropertiesSaveStatus.Text = "Folder " + s.fullName + " might already exist in this directory... use Folder Settings dialog";
          }
          else
          {
            SortDirectory arg_MainDir = (SortDirectory)MainDirsTree.SelectedNode.Tag;
            _settings.addMainSubDir_Interface(ref arg_MainDir, newLoc);
          }
        }
        refreshMainDirs();
        refreshPresortedFolders();
      }
    }

    private void MoveUpDir_Click(object sender, EventArgs e)
    {
      if (_innerDir is not null && !((_innerDir.fullName ?? "") == (PreSortedDirTextBox.Text ?? "")))
      {
        var tempName = _innerDir;
        _innerDir = _innerDir.getParent();
        refreshPresortedFiles();
        refreshPresortedFolders();

        var newItem = FoldersToBeSorted.Items.OfType<SortDirectory>().ToList().Where(x => (x.fullName ?? "") == (tempName.fullName ?? "")).FirstOrDefault();
        FoldersToBeSorted.SelectedIndex = FoldersToBeSorted.Items.IndexOf(newItem);

      }
    }

    private void EnterDir_Click(object sender, EventArgs e)
    {
      if (FoldersToBeSorted.SelectedItem is not null && FoldersToBeSorted.SelectedItem is SortDirectory)
      {
        _innerDir = (SortDirectory)FoldersToBeSorted.SelectedItem;
        refreshPresortedFiles();
        refreshPresortedFolders();
      }
    }

    private void MainDirsTree_SelectedNodeChanged(object sender, EventArgs e)
    {
      selectedTags = "";
      TagsSelector.Items.Clear();
      if (MainDirsTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)MainDirsTree.SelectedNode.Tag).hasTags())
      {
        foreach (DirTag t in ((SortDirectory)MainDirsTree.SelectedNode.Tag).DirTags)
        {
          TagsSelector.Items.Add(t);
        }
      }
    }

    private void OpenFile_Click(object sender, EventArgs e)
    {
      MouseEventArgs mouseE = e as MouseEventArgs;
      if (mouseE is not null)
      {
        if (mouseE.Button == MouseButtons.Left && FilesToBeSorted.SelectedItem is not null && FilesToBeSorted.SelectedItem is string)
        {
          if (System.IO.File.Exists(PreSortedDirTextBox.Text + FilesToBeSorted.SelectedItem.ToString()) == true)
          {
            Process.Start(PreSortedDirTextBox.Text + FilesToBeSorted.SelectedItem.ToString());
          }
          else
          {
            Interaction.MsgBox("File Does Not Exist");
          }
        }
        else if (mouseE.Button == MouseButtons.Right && FilesToBeSorted.SelectedItem is not null && FilesToBeSorted.SelectedItem is string)
        {
          if (System.IO.File.Exists(PreSortedDirTextBox.Text + FilesToBeSorted.SelectedItem.ToString()) == true)
          {
            Process.Start("explorer.exe", "/select, " + PreSortedDirTextBox.Text + FilesToBeSorted.SelectedItem.ToString());
          }
          else
          {
            Interaction.MsgBox("File Does Not Exist");
          }
        }
      }

    }

    private void MainDirsBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      selectedTags = "";
      TagsSelector.Items.Clear();
      if (MainDirsTree.SelectedNode is not null && MainDirsTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)MainDirsTree.SelectedNode.Tag).hasTags())
      {
        foreach (DirTag t in ((SortDirectory)MainDirsTree.SelectedNode.Tag).DirTags)
        {
          TagsSelector.Items.Add(t);
        }
      }
    }

    private void TrackBar1_Scroll(object sender, EventArgs e)
    {
      MediaViewer1.SetVolume(VolumeBar.Value);
    }

    private void TagsSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (TagsSelector.SelectedItems.Count == 1)
      {
        selectedTags = ((DirTag)TagsSelector.SelectedItem).Key;
      }
      else if (TagsSelector.SelectedItems.Count > 1)
      {
        selectedTags = selectedTags + ((DirTag)TagsSelector.SelectedItem).Key;
      }
      else    // Nothing was selected
      {
        selectedTags = "";
      }
    }

    private void TypeSelector1_CheckChangeded()
    {
      refreshPresortedFiles();
    }

    private void SaveRatingButton_Click(object sender, EventArgs e)
    {
      saveRating();
    }

    private async void saveRating()
    {
      string path = "";
      try
      {
        path = PreSortedDirTextBox.Text + FilesToBeSorted.SelectedItem.ToString();
      }
      catch (Exception ex)
      {
        return;
      }

      PropertiesSaveStatus.Text = "";

      int playHeadLoc = MediaViewer1.VideoScrollBar.Value;
      MediaViewer1.Stop();

      try
      {
        string fileType = System.IO.Path.GetExtension(FilesToBeSorted.SelectedItem.ToString());
        

        if (_vidExtensions.Contains(fileType))
        {
          MediaViewer1.RemoveVideo(path);

          var file = ShellFile.FromFilePath(path);

          try
          {
            ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
            propertyWriter.WriteProperty(SystemProperties.System.Rating, _rating);
            propertyWriter.Close();

          }
          catch(Exception e)
          {

          }
          finally
          {
            file.Dispose();
          }

        }
        else if (!fileType.Equals(".gif") & !fileType.Equals(".png") && _imgExtensions.Contains(fileType))
        {

          try
          {
            MediaViewer1.RemoveImage();
          }
          // imgStream.Close()
          catch (Exception ex2)
          {
            throw new Exception("Error Closing imgStream");
          }

          var file = ShellFile.FromFilePath(path);

          ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
          propertyWriter.WriteProperty(SystemProperties.System.Rating, _rating);
          propertyWriter.Close();

        }
        else if (fileType.Equals(".gif") | fileType.Equals(".png"))
        {
          throw new Exception("This file type is NOT ratable!!!");
        }

        PropertiesSaveStatus.Text = "Rating Successfully applied to " + System.IO.Path.GetFileName(path) + " | in directory " + System.IO.Path.GetDirectoryName(path);
      }
      catch (Exception ex)
      {
        PropertiesSaveStatus.Text = "File " + System.IO.Path.GetFileName(path) + " Is NOT ratable!";
        SaveRatingButton.BackColor = Color.Red;
        AlertTimer.Start();
      }
      finally
      {
        MediaViewer1.AddVideo(path);
        MediaViewer1.Play();
        // MediaViewer1.VideoScrollBar.Value = playHeadLoc
      }

    }

    private void DeleteDirButton_Click(object sender, EventArgs e)
    {
      bool clearAll = false;
      if (FoldersToBeSorted.SelectedItems is not null && FoldersToBeSorted.SelectedItem is SortDirectory)
      {
        foreach (var folderItem in FoldersToBeSorted.SelectedItems)
        {
          string path = ((SortDirectory)folderItem).fullName;
          if (getFiles(path).Count > 0 && !clearAll)
          {
            // There are still files that exist!
            var yna = new YesNoApplyToAll("There are still files that exist in this folder [" + ((SortDirectory)folderItem).getName() + "] or in its directories! Are you sure you want to delete this directory and lose all of the files in it?");
            var result = yna.ShowDialog();
            clearAll = yna.applyAll;
            // Dim result As Integer = MessageBox.Show("There are still files that exist in this folder or in its directories! Are you sure you want to delete this directory and lose all of the files in it?", "WARNING", MessageBoxButtons.YesNoCancel)
            if (result == DialogResult.Cancel)
            {
              return;
            }
            else if (result == DialogResult.No)
            {
              continue;
            }
            else if (result == DialogResult.Yes)
            {
              MediaViewer1.RemoveImage(path);
              MediaViewer1.RemoveVideo(path);
            }
          }
          try
          {
            System.IO.Directory.Delete(path, true);
          }
          // refreshPresortedFolders()
          catch (Exception ex)
          {

          }
        }
        refreshPresortedFolders();
      }

    }

    private void PurgeAllEmptyDirsButton_Click(object sender, EventArgs e)
    {
      if (_innerDir is not null)
      {
        foreach (var d in System.IO.Directory.GetDirectories(_innerDir.fullName))
        {
          if (getFiles(d).Count == 0)
          {
            try
            {
              System.IO.Directory.Delete(d, true);
            }
            catch (Exception ex)
            {
              StatusStrip1.Text = "Could not delete folder: " + d;
            }
          }
          else
          {
            // There are still files that exist!
          }
        }
        refreshPresortedFolders();
      }
    }

    private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        var rename = new RenameDialog(PreSortedDirTextBox.Text + FilesToBeSorted.Items[clickedOn].ToString());
        MediaViewer1.RemoveImage();
        MediaViewer1.RemoveVideo();
        rename.ShowDialog();
        refreshPresortedFiles();
      }
      catch (Exception ex)
      {

      }
    }

    private void GroupToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      string folderName = Interaction.InputBox("Folder Name?", "Group Items Into Folder");
      if (folderName.Trim().Length > 0)
      {
        string fullFolderName = _innerDir.fullName + @"\" + folderName;
        System.IO.Directory.CreateDirectory(fullFolderName);
        refreshPresortedFolders();

        MediaViewer1.RemoveImage();
        MediaViewer1.RemoveVideo();

        foreach (var @file in FilesToBeSorted.SelectedItems)
        {
          if (@file is string)
          {
            doMoveFile((string)@file, fullFolderName);
          }
        }
        refreshPresortedFiles();
      }
    }

    private void SortByComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      refreshPresortedFiles();
      FilesToBeSorted.Select();
    }

    private void ConversionsButton_Click(object sender, EventArgs e)
    {
      if (_settings is not null)
      {
        var conversion = new FileConversion(_settings.getConvDirs(), _settings.getFinished());

        conversion.Show();
      }
      else
      {
        StatusLabel.Text = "No settings selected";
      }

    }

    private void EmptyFoldersUpButton_Click(object sender, EventArgs e)
    {
      if (FoldersToBeSorted.SelectedItems.Count > 0)
      {
        foreach (SortDirectory item in FoldersToBeSorted.SelectedItems)
        {
          foreach (var @file in System.IO.Directory.GetFiles(item.fullName))
          {
            try
            {
              doMoveFile2(@file, item.getParent().fullName);
            }
            catch (Exception ex)
            {
              StatusLabel.Text = ex.Message;
            }
          }
        }
      }
      refreshPresortedFiles();
    }

    private void ToBeSortedFilter_TextChanged(object sender, EventArgs e)
    {
      refreshPresortedFiles();
    }

    private void ToBeSortedFoldersFilter_TextChanged(object sender, EventArgs e)
    {
      refreshPresortedFolders();
    }

    private void MainDirsFilter_TextChanged(object sender, EventArgs e)
    {
      refreshMainDirs();
    }

    private void ClearDirFilterBtn_Click(object sender, EventArgs e)
    {
      MainDirsFilter.Clear();
    }

    private void ClearFilesFilterBtn_Click(object sender, EventArgs e)
    {
      ToBeSortedFilter.Clear();
    }

    private void ClearFoldersFilterBtn_Click(object sender, EventArgs e)
    {
      ToBeSortedFoldersFilter.Clear();
    }

    private void VlcControl1_MediaChanged(object sender, EventArgs e)
    {
      MediaViewer1.SetVolume(VolumeBar.Value);
    }

    private void UnderScoreAddUpDown_ValueChanged(object sender, EventArgs e)
    {
      AddUnderScoreButton.Text = "Add " + UnderScoreAddUpDown.Value.ToString() + " \"_\"";
    }

    private void AddUnderScoreButton_Click(object sender, EventArgs e)
    {
      if (MoveFilesButton.Enabled && !MoveFolderButton.Enabled)    // This means that a file was last selected
      {
        if (FilesToBeSorted.SelectedItems.Count > 0)
        {
          int toResel = FilesToBeSorted.SelectedIndex;
          string newName = "";
          string oldName = "";
          try
          {
            foreach (var f in FilesToBeSorted.SelectedItems)
            {
              if (f is string)
              {

                var fi = new System.IO.FileInfo(PreSortedDirTextBox.Text + (string)f); // Get the fileInfo object for the file in question so renaming will be easier
                string tag = new string('_', (int)Math.Round(UnderScoreAddUpDown.Value));
                newName = tag + fi.Name;
                oldName = fi.FullName;
                fi = null;
                MediaViewer1.RemoveImage(oldName);
                MediaViewer1.RemoveVideo(oldName);
                My.MyProject.Computer.FileSystem.RenameFile(oldName, newName);
              }
            }
          }
          catch (Exception ex)
          {
            for (int i = 1; i <= 10; i++)
            {
              MediaViewer1.RemoveImage();
              try
              {
                My.MyProject.Computer.FileSystem.RenameFile(oldName, newName);
              }
              catch (Exception ex2)
              {

              }
            }
          }
          refreshPresortedFiles();
          FilesToBeSorted.SelectedItem = FilesToBeSorted.Items[toResel];
        }
      }

    }

    public static List<string> getFiles(string path)
    {
      List<string> ret;
      ret = System.IO.Directory.GetFiles(path).ToList();
      foreach (var d in System.IO.Directory.GetDirectories(path))
      {
        var Temp = getFiles(d);
        ret.AddRange(Temp);
      }

      return ret;
    }

    private void AlertTimer_Tick(object sender, EventArgs e)
    {
      SaveRatingButton.BackColor = SystemColors.Control;
      AlertTimer.Stop();
    }

    private void HandleKeys(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Delete: // , Keys.Back
          {
            uint indMax = uint.MinValue;
            uint indMin = uint.MaxValue;
            foreach (string s in FilesToBeSorted.SelectedItems)
            {

              // Find the min and max indices (this will help us select which item to reselect when the listview is refreshed.
              if (FilesToBeSorted.Items.IndexOf(s) > indMax)
              {
                indMax = (uint)FilesToBeSorted.Items.IndexOf(s);
              }
              if (FilesToBeSorted.Items.IndexOf(s) < indMin)
              {
                indMin = (uint)FilesToBeSorted.Items.IndexOf(s);
              }

              doDelete(PreSortedDirTextBox.Text + s);
            }
            refreshPresortedFiles();

            if (FilesToBeSorted.Items.Count == 0)
            {
            }

            else if (indMax >= FilesToBeSorted.Items.Count)
            {
              FilesToBeSorted.SelectedIndex = FilesToBeSorted.Items.Count - 1;
            }
            else if (indMax <= FilesToBeSorted.Items.Count)
            {
              FilesToBeSorted.SelectedIndex = (int)indMax;
            }
            else if (indMin <= FilesToBeSorted.Items.Count)
            {
              FilesToBeSorted.SelectedIndex = (int)indMin;
            }

            break;
          }

        case Keys.Space:
          {
            ActiveControl = null;
            MediaViewer1.Select();
            MediaViewer1.Pause();
            break;
          }
        case Keys.D0:
        case Keys.D1:
        case Keys.D2:
        case Keys.D3:
        case Keys.D4:
        case Keys.D5:
        case Keys.D6:
        case Keys.D7:
        case Keys.D8:
        case Keys.D9:
          {
            if (MainDirsTree.Focused)
            {
              if (MainDirsTree.SelectedNode is not null) // {AndAlso MainDirsTree.SelectedNode.Count = 1 Then
              {
                switch (e.KeyCode)
                {
                  case Keys.D0:
                    {
                      break;
                    }
                  // MainDir Keys.D1
                  // sBox.SelectedIndex
                  case Keys.D1:
                    {
                      break;
                    }

                  case Keys.D2:
                    {
                      break;
                    }

                  case Keys.D3:
                    {
                      break;
                    }

                  case Keys.D4:
                    {
                      break;
                    }

                  case Keys.D5:
                    {
                      break;
                    }

                  case Keys.D6:
                    {
                      break;
                    }

                  case Keys.D7:
                    {
                      break;
                    }

                  case Keys.D8:
                    {
                      break;
                    }

                  case Keys.D9:
                    {
                      break;
                    }
                }
              }
              else
              {
                Interaction.Beep();
              }
            }

            break;
          }
        case Keys.Enter:
          {
            MoveFilesButton_Click(null, null);
            FilesToBeSorted.Select();
            break;
          }
      }

    }

    private void doDelete(string path)
    {
      try
      {
        // IO.File.Delete(path)
        var dest = new System.IO.FileInfo(RootDirTextBox.Text + @"\toBeDeleted\" + System.IO.Path.GetFileName(path));
        MediaViewer1.RemoveImage(path);
        MediaViewer1.RemoveVideo(path);
        dest.Directory.Create();

        int iTry = 1;

        while (dest.Exists && iTry < 99)
          dest = new System.IO.FileInfo(RootDirTextBox.Text + @"\toBeDeleted\" + System.IO.Path.GetFileName(path) + "(" + iTry.ToString() + ")");

        if (!dest.Exists)
        {
          System.IO.File.Move(path, dest.FullName);
        }
        else
        {
          System.IO.File.Delete(path);
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {

      }
    }

    private void DupeCheckerButton_Click(object sender, EventArgs e)
    {
      DupeChecker cd;
      if (ActiveControl is not null)
      {
        if (ReferenceEquals(ActiveControl, MainDirsTree) && MainDirsTree.SelectedNode is not null)
        {
          cd = new DupeChecker((SortDirectory)MainDirsTree.SelectedNode.Tag);
        }
        else if (ReferenceEquals(ActiveControl, FoldersToBeSorted) && FoldersToBeSorted.SelectedItem is not null)
        {
          cd = new DupeChecker((SortDirectory)FoldersToBeSorted.SelectedItem);
        }
        else if (PreSortedDirTextBox.Text is not null && !PreSortedDirTextBox.Text.Equals(""))
        {
          cd = new DupeChecker(new SortDirectory(PreSortedDirTextBox.Text));
        }
        else
        {
          cd = new DupeChecker();
        }
      }
      else
      {
        cd = new DupeChecker();
      }

      if (cd is not null)
      {
        cd.ShowDialog();
        cd.Dispose();
      }
    }

    private void Views_CheckedChanged(object sender, EventArgs e)
    {
      var styles = MediaViewer1.MediaPanel.ColumnStyles;

      if (styles.Count < 2)
        return;

      if (ImageCheck.Checked & VideoCheck.Checked)
      {
        foreach (ColumnStyle style in styles)
        {
          style.SizeType = SizeType.Percent;
          style.Width = 50f;
        }
      }
      else if (ImageCheck.Checked & !VideoCheck.Checked)
      {
        MediaViewer1.RemoveVideo();
        styles[0].SizeType = SizeType.Percent;
        styles[0].Width = 100f;
        styles[1].SizeType = SizeType.Absolute;
        styles[1].Width = 0f;
      }
      else if (!ImageCheck.Checked & VideoCheck.Checked)
      {
        MediaViewer1.RemoveImage();
        styles[1].SizeType = SizeType.Percent;
        styles[1].Width = 100f;
        styles[0].SizeType = SizeType.Absolute;
        styles[0].Width = 0f;
      }
      else if (!ImageCheck.Checked & !VideoCheck.Checked)
      {
        MediaViewer1.RemoveImage();
        styles[0].SizeType = SizeType.Absolute;
        styles[0].Width = 0f;
        styles[1].SizeType = SizeType.Absolute;
        styles[1].Width = 0f;
      }

    }

    // Private Sub markFilesForMove()
    // For Each s As String In FilesToBeSorted.SelectedItems
    // For Each lvi As ListViewItem In FilesToBeMovedView.Items
    // If lvi.
    // Next
    // Next
    // End Sub
  }
}