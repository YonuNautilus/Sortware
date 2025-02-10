using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SortWare
{

  public partial class SortSettingsDialog
  {

    private SortSettings _sortSettings;
    private string _rootDir;
    private SortDirectory _rootDirObj;

    private List<SortDirectory> _mainsSettings = new List<SortDirectory>();
    private List<SortDirectory> _presortSettings = new List<SortDirectory>();
    private List<SortDirectory> _blockedSettings = new List<SortDirectory>();
    private List<SortDirectory> _convertSettings = new List<SortDirectory>();
    private SortDirectory _finished;

    private bool _changedNotSaved = false;

    private TreeNode _rootNode;
    private TreeNode _mainNode;
    private TreeNode _presortNode;
    private TreeNode _blockedNode;
    private TreeNode _convNode;
    private TreeNode _finishedNode;

    private List<TreeNode> _errorNodes = new List<TreeNode>();
    private int currentErrNodeIndex = -1;

    private ContextMenuStrip nodeContextMenu = new ContextMenuStrip();
    private ToolStripMenuItem editNodeOption = new ToolStripMenuItem("Edit Directory");
    private ToolStripMenuItem delNodeOption = new ToolStripMenuItem("Delete Directory");

    private SortDirectory selectedMainDir
    {
      get
      {
        if (SettingsTreeView.SelectedNode.Tag is not null && SettingsTreeView.SelectedNode.Tag is SortDirectory)
        {
          return SettingsTreeView.SelectedNode.Tag as SortDirectory;
        }
        return null;
      }
    }


    private const string TWOLINE = Constants.vbNewLine + Constants.vbNewLine;

    private class TreeNodeContextMenu : ContextMenu
    {

    }

    public SortSettingsDialog(string path)
    {
      Debug.AutoFlush = true;
      // This call is required by the designer.
      InitializeComponent();

      // Add any initialization after the InitializeComponent() call.
      SaveButton.Image = My.Resources.Resources.shell32_16761.ToBitmap();

      editNodeOption.Click += editNodeOption_Click;
      delNodeOption.Click += delNodeOption_Click;

      nodeContextMenu.Items.AddRange(new[] { editNodeOption, delNodeOption });

      _rootDir = path;

      if (System.IO.File.Exists(_rootDir + @"\sortSettings.xml"))
      {
        InitializeSettings.Enabled = false;
      }
      else
      {
        InitializeSettings.Enabled = true;
      }

      SettingsTreeView.Nodes.Clear();

      _rootNode = SettingsTreeView.Nodes.Add("Root Directory");
      _mainNode = SettingsTreeView.Nodes.Add("Main Directories");
      _presortNode = SettingsTreeView.Nodes.Add("Presorted Directories");
      _blockedNode = SettingsTreeView.Nodes.Add("Blocked Directories");
      _convNode = SettingsTreeView.Nodes.Add("Conversion Directories");
      _finishedNode = SettingsTreeView.Nodes.Add("Finished Conversion Directories");

      refreshDirs();
      initSettings();
    }

    private void SortSettingsDialog_Load(object sender, EventArgs e)
    {
      object dirs;
    }

    #region REFRESH
    private void initSettings()
    {
      if (System.IO.File.Exists(_rootDir + @"\sortSettings.xml"))
      {
        // _sortSettingsReader = New IO.StreamReader(_rootDir + "\.sortSettings.txt")
        _sortSettings = SortSettings.CreateFromXml(_rootDir);
        SettingsViewer.Text = _sortSettings.ToString();
        // _sortSettingsReader.Close()

        initSettingsList();
        refreshDirView();
      }
    }

    private void initSettingsList()
    {
      _rootDirObj = _sortSettings.rootDir;
      _mainsSettings = _sortSettings.getList(SortSettings.dirType.MAINDIR);
      _presortSettings = _sortSettings.getList(SortSettings.dirType.PRESORTDIR);
      _convertSettings = _sortSettings.getList(SortSettings.dirType.CONVERTDIR);
      if (_sortSettings.getFinished() is not null)
      {
        _finished = _sortSettings.getFinished();
      }
      _blockedSettings = _sortSettings.getList(SortSettings.dirType.BLOCKEDDIR);
    }
    private void refreshSettings()
    {
      refreshDirView();
      SettingsViewer.Text = _sortSettings.ToString();
    }

    private void refreshDirView()
    {
      _errorNodes.Clear();

      currentErrNodeIndex = -1;

      foreach (TreeNode n in SettingsTreeView.Nodes)
        n.Nodes.Clear();

      initSettingsList();

      var tempNode = _rootNode.Nodes.Add(_rootDirObj.fullName);
      tempNode.Tag = _rootDirObj;

      if (_finished is not null)
      {
        tempNode = _finishedNode.Nodes.Add(_finished.fullName);
        tempNode.Tag = _finished;
      }

      addDirs(ref _mainNode, _mainsSettings);
      addDirs(ref _presortNode, _presortSettings);
      addDirs(ref _blockedNode, _blockedSettings);
      addDirs(ref _convNode, _convertSettings);

      if (_errorNodes.Count > 0)
      {
        StatusLabel.Text = "ERROR! Please address broken dirs";
      }

      DirErrorGroup.Text = "Directry Errors: " + _errorNodes.Count;

    }

    private void addDirs(ref TreeNode parent, List<SortDirectory> _list)
    {
      if (_list is null)
        return;
      foreach (SortDirectory sd in _list)
      {
        var currentNew = parent.Nodes.Add(sd.fullName);
        currentNew.Tag = sd;
        if (sd.hasSubs())
        {
          addDirs(ref currentNew, sd.getSubs());
        }
        currentNew.ContextMenuStrip = nodeContextMenu;

        if (!sd.isValid())
        {
          currentNew.BackColor = Color.Red;
          _errorNodes.Add(currentNew);
        }
      }
    }

    public void refreshTagsViewer()
    {
      TagsViewer.Items.Clear();
      if (selectedMainDir != null &&  selectedMainDir.type == SortSettings.dirType.MAINDIR)
      {
        if (selectedMainDir.hasTags())
        {
          foreach(DirTag tag in selectedMainDir.DirTags)
            TagsViewer.Items.Add(tag);
        }
      }
    }

    /// <summary>
    /// Calls the recursive populateDirs routine
    /// </summary>
    private void refreshDirs()
    {
      RootDirViewTree.Nodes.Clear();
      foreach (string Dir in System.IO.Directory.GetDirectories(_rootDir))
      {

        var currentNode = RootDirViewTree.Nodes.Add(new SortDirectory(Dir).getName());
        currentNode.Tag = new SortDirectory(Dir);
        populateDirs(ref currentNode, Dir);
      }
    }

    private void populateDirs(ref TreeNode node, string _dir)
    {
      try
      {
        foreach (string Dir in System.IO.Directory.GetDirectories(_dir))
        {
          var currentNode = node.Nodes.Add(new SortDirectory(Dir).getName());
          currentNode.Tag = new SortDirectory(Dir);
          populateDirs(ref currentNode, Dir);
        }
      }
      catch (Exception ex)
      {

      }
    }

    private void RefreshCreateButton()
    {
      if (System.IO.File.Exists(_rootDir + @"\.sortSettings.txt"))
      {
        InitializeSettings.Enabled = false;
      }
      else
      {
        InitializeSettings.Enabled = true;
      }
    }

    private void RefreshAddButtons(object sender, EventArgs e)
    {
      if (sender is Control)
      {
        switch (((Control)sender).Name ?? "")
        {
          case var @case when @case == (RootDirViewTree.Name ?? ""):
            {
              addRootDir.Enabled = true;
              addMainDir.Enabled = true;
              addMainSubdir.Enabled = true;
              addPresortDir.Enabled = true;
              addBlockedDir.Enabled = true;
              removeDir.Enabled = false;
              break;
            }
          case var case1 when case1 == (SettingsTreeView.Name ?? ""):
            {
              addRootDir.Enabled = false;
              addMainDir.Enabled = false;
              addMainSubdir.Enabled = false;
              addPresortDir.Enabled = false;
              addBlockedDir.Enabled = false;
              removeDir.Enabled = true;
              refreshTagsViewer();
              break;
            }

          default:
            {
              addRootDir.Enabled = false;
              addMainDir.Enabled = false;
              addMainSubdir.Enabled = false;
              addPresortDir.Enabled = false;
              addBlockedDir.Enabled = false;
              removeDir.Enabled = false;
              break;
            }
        }
      }
    }
    #endregion

    private void TurnOffWarnings()
    {
      StatusLabel.Text = "";
      foreach (var button in AddButtonGroup.Controls)
      {
        if (button is Button)
        {
          ((Button)button).BackColor = SystemColors.Control;
        }
      }
    }

    public static List<ListViewItem> getTags(SortDirectory directory)
    {
      if (directory.hasTags())
      {

      }

      return default;
    }

    #region Handlers
    private void AddRootDir_Click(object sender, EventArgs e)
    {
      if (RootDirViewTree.SelectedNode is null)
      {
        return;
      }

      if (RootDirViewTree.SelectedNode.Tag is not null && RootDirViewTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)RootDirViewTree.SelectedNode.Tag).exists())
      {
        _sortSettings.setDir(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName);
      }

      refreshSettings();
    }

    private void AddMainDir_Click(object sender, EventArgs e)
    {
      if (RootDirViewTree.SelectedNode is null)
      {
        return;
      }

      if (RootDirViewTree.SelectedNode.Tag is not null && RootDirViewTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)RootDirViewTree.SelectedNode.Tag).exists())
      {
        _sortSettings.addToDirList(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName, SortSettings.dirType.MAINDIR);
        _mainsSettings.Add((SortDirectory)RootDirViewTree.SelectedNode.Tag);
      }

      refreshSettings();
    }

    private void AddMainSubdir_Click(object sender, EventArgs e)
    {
      // First check that both selected items are sortDirectories...
      if (RootDirViewTree.SelectedNode.Tag is not null && RootDirViewTree.SelectedNode.Tag is SortDirectory && SettingsTreeView.SelectedNode.Tag is not null && SettingsTreeView.SelectedNode.Tag is SortDirectory)
      {
        // Then check that the selected settingsDir is a main Dir, and that the rootDir item contains the path of the selected MainDirectory
        if (((SortDirectory)SettingsTreeView.SelectedNode.Tag).type == SortSettings.dirType.MAINDIR && ((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName.Contains(((SortDirectory)SettingsTreeView.SelectedNode.Tag).fullName))
        {
          ((SortDirectory)SettingsTreeView.SelectedNode.Tag).addSubDir(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName);
        }
      }
      refreshSettings();
    }

    private void AddPresortDir_Click(object sender, EventArgs e)
    {
      if (RootDirViewTree.SelectedNode.Tag is not null && RootDirViewTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)RootDirViewTree.SelectedNode.Tag).exists())
      {
        _sortSettings.addToDirList(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName, SortSettings.dirType.PRESORTDIR);
        _presortSettings.Add((SortDirectory)RootDirViewTree.SelectedNode.Tag);
      }

      refreshSettings();
    }

    private void AddConvertDir_Click(object sender, EventArgs e)
    {
      if (RootDirViewTree.SelectedNode.Tag is not null && RootDirViewTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)RootDirViewTree.SelectedNode.Tag).exists())
      {
        string name = Interaction.InputBox("Enter a Title for this Conversion Folder");

        var ofd = new OpenFileDialog();
        ofd.InitialDirectory = ((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName;
        ofd.Filter = "Bat Files (*.bat)|*.bat|All Files (*.*)|(*.*)";

        string scriptPath;

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          scriptPath = ofd.FileName;
        }
        else
        {
          return;
        }

        var cdts = new ConvDirTypeSelector();
        cdts.ShowDialog(this);
        string @type = Conversions.ToString(cdts.Tag);

        if (name is not null || !name.Equals(""))
        {
          _sortSettings.addToDirList(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName, SortSettings.dirType.CONVERTDIR, name, scriptPath);
          _convertSettings.Add(new SortDirectory(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName, 3, SortSettings.dirType.CONVERTDIR, false, name, scriptPath));
        }

        refreshSettings();
      }
    }

    private void AddFinishedDir_Click(object sender, EventArgs e)
    {
      if (RootDirViewTree.SelectedNode.Tag is not null && RootDirViewTree.SelectedNode.Tag is SortDirectory && ((SortDirectory)RootDirViewTree.SelectedNode.Tag).exists())
      {
        _sortSettings.addToDirList(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName, SortSettings.dirType.FINISHEDDIR);
        _finished = new SortDirectory(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName, 3);
      }

      refreshSettings();
    }

    private void RemoveDir_Click(object sender, EventArgs e)
    {
      var thing = SettingsTreeView.SelectedNode.Tag;

      if (thing is not null && thing is SortDirectory)
      {
        SortDirectory selSortDir = (SortDirectory)thing;
        _sortSettings.removeFromDirList(selSortDir.fullName, selSortDir.type);
      }

      // If SettingsTreeView.SelectedItem IsNot Nothing AndAlso TypeOf SettingsTreeView.SelectedItem Is SortDirectory Then
      // _sortSettings.removeFromDirList(DirectCast(thing, SortDirectory).fullName, DirectCast()
      // If DirectCast(thing, SortDirectory).type = SortSettings.dirType.MAINDIR Then
      // If DirectCast(thing, SortDirectory).isSubDir Then
      // searchAndDestroySub
      // End If
      // Else

      // End If
      // End If

      refreshSettings();
    }

    private void InitializeSettings_Click(object sender, EventArgs e)
    {
      var xws = new XmlWriterSettings();
      xws.Indent = true;

      using (var writer = XmlWriter.Create(_rootDir + @"\sortSettings.xml", xws))
      {
        writer.WriteStartDocument();
        writer.WriteStartElement("rootDir");
        writer.WriteAttributeString("dir", _rootDir);

        writer.WriteStartElement("mains");
        writer.WriteFullEndElement();

        writer.WriteStartElement("presorts");
        writer.WriteFullEndElement();

        writer.WriteStartElement("convert");
        writer.WriteFullEndElement();

        writer.WriteStartElement("finished");
        writer.WriteFullEndElement();

        writer.WriteFullEndElement();
        writer.Close();
      }



      // Dim fs As IO.FileStream = IO.File.Create(_rootDir & "\.sortSettings.txt")
      // fs.Close()
      // 'IO.File.Create(_rootDir & "\.sortSettings.txt", IO.FileMode.CreateNew)
      // 'IO.File.SetAttributes(_rootDir & "\.sortSettings.txt", IO.FileAttributes.Hidden)

      // Using _sortSettingsWriter = New IO.StreamWriter(_rootDir + "\.sortSettings.txt")
      // _sortSettingsWriter.Write("Root: " + _rootDir + vbNewLine + "#" + TWOLINE + "Mains:" + vbNewLine + "#" + TWOLINE + "Presorts:" + vbNewLine + "#" + TWOLINE + "Blocked:" + vbNewLine + "#")
      // End Using

      _sortSettings = SortSettings.CreateFromXml(_rootDir);

      RefreshCreateButton();
      initSettings();
    }

    private void FinishedButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void SortSettingsDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (_changedNotSaved)
      {
        var result = MessageBox.Show("Do you want to save the sort settings before exiting?", "Closing without saving!", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.No)
        {
        }
        else if (result == DialogResult.Yes)
        {
          SaveButton_Click(this, e);
        }
        else if (result == DialogResult.Cancel)
        {
          e.Cancel = true;
        }

      }

      try
      {
        _sortSettings?.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      var tempSortSettings = new SortSettings(_rootDirObj, _mainsSettings, _presortSettings, _blockedSettings, _convertSettings, _finished);
      if (!tempSortSettings.IsValidSettings())
      {
        var result = MessageBox.Show("There was an error with one of the directories. Do you want to close and save with potential errors?", "Saving with errors!", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.No | result == DialogResult.Cancel)
        {
          return;
        }
      }

      _sortSettings.SaveSettingsXML();

      _changedNotSaved = false;
    }

    private void SettingsViewer_TextChanged(object sender, EventArgs e)
    {
      _changedNotSaved = true;
    }

    private void ErrorTimer_Tick(object sender, EventArgs e)
    {
      ErrorTimer.Stop();
      TurnOffWarnings();
    }

    private void AddTagButton_Click(object sender, EventArgs e)
    {
      if (TagIDEntry.Text is not null && TagIDEntry.Text.Trim()[TagIDEntry.Text.Length - 1] == '.')
      {
        TagsViewer.Sorted = true;
        if (TagsViewer.Items.Contains((TagIDEntry.Text + Constants.vbTab + TagDescEntry.Text.Trim()).Trim()))
        {
          StatusLabel.Text = "This tag already exists";
          ErrorTimer.Start();
          return;
        }
        else
        {
          DirTag newTag = new DirTag(TagIDEntry.Text, TagDescEntry.Text.Trim());

          selectedMainDir?.AddTag(newTag);
          refreshTagsViewer();
        }
      }
    }

    private void RemoveTagButton_Click(object sender, EventArgs e)
    {
      if (TagsViewer.SelectedItem is not null)
      {
        selectedMainDir?.RemoveTag(TagsViewer.SelectedItem as DirTag);
        refreshTagsViewer();
      }
    }

    private void TagsViewer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void AddNewDir(object sender, EventArgs e)
    {
      try
      {
        if (e is MouseEventArgs && ((MouseEventArgs)e).Button == MouseButtons.Right)
        {
          RootDirViewTree.SelectedNode = RootDirViewTree.GetNodeAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

          if (RootDirViewTree.SelectedNode is not null)
          {
            string newName = Interaction.InputBox("Add New Folder in: " + RootDirViewTree.SelectedNode.Text);
            if (newName is not null && !newName.Equals(""))
            {

              string newFolder = System.IO.Directory.CreateDirectory(((SortDirectory)RootDirViewTree.SelectedNode.Tag).fullName + @"\" + newName).FullName;
              var curNode = RootDirViewTree.SelectedNode.Nodes.Add(new SortDirectory(newFolder).getName());
              curNode.Tag = new SortDirectory(newFolder);
            }
          }

        }
      }
      catch (Exception ex)
      {
        StatusLabel.Text = "Problem making new folder: " + ex.Message;
        ErrorTimer.Start();
      }

    }

    private void SettingsTreeView_MouseDown(object sender, MouseEventArgs e)
    {
      SettingsTreeView.SelectedNode = SettingsTreeView.GetNodeAt(e.Location);
    }

    private void editNodeOption_Click(object sender, EventArgs e)
    {
      string path = SettingsTreeView.SelectedNode.Text;

      var cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog("Edit Directory: " + path);
      cofd.IsFolderPicker = true;
      cofd.InitialDirectory = path;

      if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
      {
        ((SortDirectory)SettingsTreeView.SelectedNode.Tag).SetDir(cofd.FileName);
      }

      refreshSettings();
    }

    private void delNodeOption_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Delete Directory: [" + SettingsTreeView.SelectedNode.Text + "]?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        RemoveDir_Click(sender, e);
      }
    }



    private void PrevErrorButton_Click(object sender, EventArgs e)
    {
      if (_errorNodes.Count <= 0)
      {
        return;
      }

      if (currentErrNodeIndex <= 0) // If at the start or after initialization
      {
        currentErrNodeIndex = _errorNodes.Count - 1;
      }
      else
      {
        currentErrNodeIndex = currentErrNodeIndex - 1;
      }

      SettingsTreeView.SelectedNode = _errorNodes[currentErrNodeIndex];
      SettingsTreeView.Select();
    }

    private void NextErrorButton_Click(object sender, EventArgs e)
    {
      if (_errorNodes.Count <= 0)
      {
        return;
      }

      if (currentErrNodeIndex >= _errorNodes.Count - 1) // If at the end
      {
        currentErrNodeIndex = 0;
      }
      else
      {
        currentErrNodeIndex = currentErrNodeIndex + 1;
      }

      SettingsTreeView.SelectedNode = _errorNodes[currentErrNodeIndex];
      SettingsTreeView.Select();
    }
    #endregion

  }
}