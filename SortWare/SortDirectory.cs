using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.VisualBasic;

namespace SortWare
{

  public class SortDirectory
  {

    private System.IO.DirectoryInfo dir;
    private string dirString = "";
    private int indent;
    private string[] tags;
    private bool isSub = false;
    private List<SortDirectory> subDirs;
    private string scriptPath = "";
    private string convTitle = "";

    private System.IO.StreamReader _logReader;
    private System.IO.StreamWriter _logWriter;

    private const string TAGFILENAME = @"\_tags.txt";
    public SortSettings.dirType @type { get; private set; }

    public SortDirectory(string _dir, int _in = 0)
    {
      @type = SortSettings.dirType.ERRORDIR;
      dirString = _dir;
      dir = new System.IO.DirectoryInfo(_dir);

      if (_in > 0)
      {
        indent = _in;
      }
      else
      {
        indent = 0;
      }
    }

    public SortDirectory(string _dir, int _in, SortSettings.dirType _type, bool isSubDir = false, string name = "", string script = "", string convType = "")
    {
      @type = _type;
      dirString = _dir;
      dir = new System.IO.DirectoryInfo(_dir);

      if (_in > 0)
      {
        indent = _in;
      }
      else
      {
        indent = 0;
      }

      isSub = isSubDir;

      scriptPath = script;
      convTitle = name;

      if (hasTags())
      {
        tags = getTagsFromFile();
      }
      if (hasSubs())
      {
        loadSubs();
      }

    }

    public bool exists()
    {
      return dir.Exists & System.IO.Directory.Exists(dir.FullName);
    }

    public void addSubDir(string s)
    {
      if (@type == SortSettings.dirType.MAINDIR)
      {
        if (s.Contains(fullName()))
        {
          if (subDirs is null)
            subDirs = new List<SortDirectory>();
        }
        subDirs.Add(new SortDirectory(s, indent + 1, SortSettings.dirType.MAINDIR, true));
      }
    }

    public void addSubDir(SortDirectory sd)
    {
      if (@type == SortSettings.dirType.MAINDIR)
      {
        if (sd.fullName().Contains(fullName()))
        {
          if (subDirs is null)
            subDirs = new List<SortDirectory>();
        }
        subDirs.Add(sd);
      }
    }

    public void loadSubs()
    {
      var xdoc = new XmlDocument();
      xdoc.Load(fullName() + @"\subSortSettings.xml");

      var smain = xdoc.GetElementsByTagName(SortSettings.XMLNODESUBS);

      foreach (XmlNode s in smain)
      {
        foreach (XmlNode c in s.ChildNodes)
        {
          if (c.Name == "dir")
          {
            addSubDir(c.FirstChild.Value.Trim());
          }
        }
      }

    }
    public void saveSubs()
    {
      if (hasSubs())
      {

        var xws = new XmlWriterSettings();
        xws.Indent = true;

        using (var writer = XmlWriter.Create(fullName() + @"\subSortSettings.xml", xws))
        {
          writer.WriteStartDocument();
          writer.WriteStartElement("rootDir");
          writer.WriteAttributeString("dir", fullName());

          if (subDirs is null)
          {
            writer.WriteStartElement("subs");
            foreach (var m in subDirs)
            {
              writer.WriteStartElement("dir");
              if (m.hasSubs())
              {
                writer.WriteAttributeString("hasSub", "true");
                m.saveSubs();
              }
              writer.WriteString(m.fullName());
              writer.WriteFullEndElement();
            }
            writer.WriteFullEndElement();
          }

          writer.WriteFullEndElement();
          writer.Close();
        }




        // Using _sortSettingsWriter = New IO.StreamWriter(Me.fullName + "\.SubSortSettings.txt")
        // _sortSettingsWriter.Write(New SubSortSettings(Me, subDirs).toString)
        // End Using
        // For Each sd In getSubs()
        // sd.saveSubs()
        // Next
      }
    }


    public bool hasSubs() => subDirs is not null | (exists() && System.IO.File.Exists(fullName() + @"\subSortSettings.xml"));

    public ref List<SortDirectory> getSubs() => ref subDirs;

    public bool hasTags() => exists() && System.IO.File.Exists(fullName() + TAGFILENAME);

    public string[] getTags() => tags;

    private string[] getTagsFromFile()
    {
      if (!hasTags())
      {
        return null;
      }
      var ret = new List<string>();
      System.IO.TextReader reader = new System.IO.StreamReader(fullName() + TAGFILENAME);
      string[] fullString = Strings.Split(reader.ReadToEnd().Trim(), Constants.vbNewLine);
      reader.Close();
      return fullString;
    }

    public void saveTags(string _tags)
    {
      // If Me.hasTags Then
      var writer = new System.IO.StreamWriter(fullName() + TAGFILENAME, false);
      writer.Write(_tags.Trim());
      writer.Close();
      // End If
      tags = getTagsFromFile();
    }

    public string fullName()
    {
      return dir.FullName;
    }

    public SortDirectory getParent()
    {
      return new SortDirectory(System.IO.Directory.GetParent(dir.FullName).FullName, indent - 1);
    }

    public string getName()
    {
      return dir.Name;
    }

    public string getConvTitle()
    {
      return @type == SortSettings.dirType.CONVERTDIR ? convTitle : "";
    }

    public bool isSubDir()
    {
      return isSub;
    }

    public string getScriptPath()
    {
      return scriptPath;
    }

    public bool matchesFilter(string filter)
    {
      bool ret = false;

      if (!string.IsNullOrWhiteSpace(filter))
      {
        if (getName().ToLower().Contains(filter.ToLower()))
        {
          ret = true;
        }

        if (hasSubs())
        {
          foreach (var d in getSubs())
          {
            if (d.matchesFilter(filter))
            {
              ret = true;
            }
          }
        }
      }

      return ret;
    }

    public void SetDir(string newDir)
    {
      dir = new System.IO.DirectoryInfo(newDir);
    }

    public bool isValid()
    {
      bool ret = true;

      if (@type == SortSettings.dirType.CONVERTDIR)
      {
        ret = ret & !(string.IsNullOrEmpty(scriptPath) || !System.IO.Directory.Exists(scriptPath));
      }

      ret = ret & exists();

      return ret;
    }

    public override string ToString()
    {
      return dir.Name.PadLeft(indent * 3 + dir.Name.Length, Convert.ToChar(" "));
    }

  }
}