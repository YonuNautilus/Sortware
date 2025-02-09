using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace SortWare
{

  public class SortDirectory
  {

    private System.IO.DirectoryInfo m_cDir;
    private string dirString = "";
    private int indent;
    private List<DirTag> m_cTags = new List<DirTag>();
    private bool isSub = false;
    private List<SortDirectory> m_cSubDirs;
    private string scriptPath = "";
    private string convTitle = "";

    private System.IO.StreamReader _logReader;
    private System.IO.StreamWriter _logWriter;

    private const string TAGFILENAME = @"\_tags.txt";

    [XmlAttribute("dir_type")]
    public SortSettings.dirType type { get; set; }

    [XmlArray("sub_dirs")]
    [XmlArrayItem("sub-dir")]
    public List<SortDirectory> SubDirs { get { return m_cSubDirs; } set { m_cSubDirs = value; } }

    [XmlAttribute("path")]
    public string fullName { get { return m_cDir.FullName; } set { m_cDir = new System.IO.DirectoryInfo(value); } }

    [XmlArray("tags")]
    [XmlArrayItem("tag")]
    public List<DirTag> DirTags { get { return m_cTags; } set { m_cTags = value; } }

    public SortDirectory() { }

    public SortDirectory(string _dir, int _in = 0)
    {
      @type = SortSettings.dirType.ERRORDIR;
      dirString = _dir;
      m_cDir = new System.IO.DirectoryInfo(_dir);

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
      m_cDir = new System.IO.DirectoryInfo(_dir);

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


      if (hasSubs())
      {
        loadSubs();
      }

    }

    public void AddTag(DirTag tag)
    {
      DirTags.Add(tag);
      DirTags.Sort((x,y) => x.Key.CompareTo(y.Key));
    }

    public void RemoveTag(DirTag tag)
    {
      DirTags.Remove(tag);
      DirTags.Sort((x, y) => x.Key.CompareTo(y.Key));
    }

    public bool exists()
    {
      return m_cDir.Exists & System.IO.Directory.Exists(m_cDir.FullName);
    }

    public void addSubDir(string s)
    {
      if (@type == SortSettings.dirType.MAINDIR)
      {
        if (s.Contains(fullName))
        {
          if (m_cSubDirs is null)
            m_cSubDirs = new List<SortDirectory>();
        }
        m_cSubDirs.Add(new SortDirectory(s, indent + 1, SortSettings.dirType.MAINDIR, true));
      }
    }

    public void addSubDir(SortDirectory sd)
    {
      if (@type == SortSettings.dirType.MAINDIR)
      {
        if (sd.fullName.Contains(fullName))
        {
          if (m_cSubDirs is null)
            m_cSubDirs = new List<SortDirectory>();
        }
        m_cSubDirs.Add(sd);
      }
    }

    public void loadSubs()
    {
      var xdoc = new XmlDocument();
      xdoc.Load(fullName + @"\subSortSettings.xml");

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

        using (var writer = XmlWriter.Create(fullName + @"\subSortSettings.xml", xws))
        {
          writer.WriteStartDocument();
          writer.WriteStartElement("rootDir");
          writer.WriteAttributeString("dir", fullName);

          if (m_cSubDirs is null)
          {
            writer.WriteStartElement("subs");
            foreach (var m in m_cSubDirs)
            {
              writer.WriteStartElement("dir");
              if (m.hasSubs())
              {
                writer.WriteAttributeString("hasSub", "true");
                m.saveSubs();
              }
              writer.WriteString(m.fullName);
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


    public bool hasSubs() => m_cSubDirs is not null && m_cSubDirs.Count > 0;

    public ref List<SortDirectory> getSubs() => ref m_cSubDirs;

    public bool hasTags() => exists() && System.IO.File.Exists(fullName + TAGFILENAME);


    public SortDirectory getParent()
    {
      return new SortDirectory(System.IO.Directory.GetParent(m_cDir.FullName).FullName, indent - 1);
    }

    public string getName()
    {
      return m_cDir.Name;
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
      m_cDir = new System.IO.DirectoryInfo(newDir);
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
      return m_cDir.Name.PadLeft(indent * 3 + m_cDir.Name.Length, Convert.ToChar(" "));
    }

  }
}