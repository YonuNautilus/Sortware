using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.VisualBasic;

namespace SortWare
{
  public class SortSettings
  {

    // Protected _filePath As String
    protected System.IO.FileStream _fileStream;

    public const string rootHeader = "Root: ";
    public const string mainsHeader = "Mains:";
    public const string presortHeader = "Presorts:";
    public const string blockHeader = "Blocked:";

    private const string rootRegex = rootHeader + @"([A-z\:0-9]*)[^\#]+";
    private const string mainsRegex = mainsHeader + @"([A-z\:0-9]*)[^\#]+";
    private const string presortRegex = presortHeader + @"([A-z\:0-9]*)[^\#]+";
    private const string blockRegex = blockHeader + @"([A-z\:0-9]*)[^\#]+";

    public const string XMLNODEMAIN = "mains";
    public const string XMLNODEPRESORTS = "presorts";
    public const string XMLNODEBLOCKED = "blocked";
    public const string XMLNODECONVERT = "convert";
    public const string XMLNODEFINISHED = "finished";
    public const string XMLNODESUBS = "subs";

    public enum dirType
    {
      ROOTDIR,
      MAINDIR,
      PRESORTDIR,
      BLOCKEDDIR,
      CONVERTDIR,
      FINISHEDDIR,
      ERRORDIR
    }

    // Private mainDirs As List(Of String) = New List(Of String)
    // Private preSortDirs As List(Of String) = New List(Of String)
    // Private blockedDirs As List(Of String) = New List(Of String)
    // Private ConvertDirs As List(Of Tuple(Of String, String, String)) = New List(Of Tuple(Of String, String, String))
    // Private FinishedDir As String
    private List<SortDirectory> mainDirs = new List<SortDirectory>();
    private List<SortDirectory> presortDirs = new List<SortDirectory>();
    private List<SortDirectory> blockedDirs = new List<SortDirectory>();
    private List<SortDirectory> convertDirs = new List<SortDirectory>();
    private SortDirectory FinishedDir;
    public SortDirectory rootDir { get; set; }

    public SortSettings()
    {

    }
    public SortSettings(string filePath)
    {
      // If System.IO.File.Exists(filePath & "\.sortSettings.txt") Then
      // '_fileStream = IO.File.Open(filePath & "\.sortSettings.txt", System.IO.FileMode.Open)
      // rootDir = filePath.Trim
      // ParseSettings()
      // ElseIf System.IO.File.Exists(filePath & "\sortSettings.xml") Then
      if (System.IO.File.Exists(filePath + @"\sortSettings.xml"))
      {
        rootDir = new SortDirectory(filePath.Trim(), (int)dirType.ROOTDIR);
        ParseSettingsXML();
      }
    }

    public SortSettings(SortDirectory root, List<SortDirectory> _mains, List<SortDirectory> _presorts, List<SortDirectory> _blocks, List<SortDirectory> _converts, SortDirectory _finished)
    {
      rootDir = root;
      foreach (var d in _mains)
        mainDirs.Add(d);
      foreach (var d in _presorts)
        presortDirs.Add(d);
      foreach (var d in _blocks)
        blockedDirs.Add(d);
      if (_finished is not null)
      {
        FinishedDir = _finished;
      }
    }

    public void setDir(string filePath)
    {
      if (System.IO.File.Exists(filePath + @"\sortSettings.xml"))
      {
        ParseSettingsXML();
        rootDir = new SortDirectory(filePath.Trim(), (int)dirType.ROOTDIR);
      }
    }

    public void addToDirList(string _dir, dirType _type, string title = "", string scriptPath = "", string convType = "")
    {
      switch (_type)
      {
        case dirType.MAINDIR:
          {
            addToDirList(new SortDirectory(_dir, 0, dirType.MAINDIR), ref mainDirs);
            break;
          }
        case dirType.PRESORTDIR:
          {
            addToDirList(new SortDirectory(_dir, 0, dirType.PRESORTDIR), ref presortDirs);
            break;
          }
        case dirType.CONVERTDIR:
          {
            // ConvertDirs.Add(New Tuple(Of String, String, String)(_dir, title, scriptPath))
            addToDirList(new SortDirectory(_dir, 0, dirType.CONVERTDIR, false, title, scriptPath, convType), ref convertDirs);
            break;
          }
        case dirType.FINISHEDDIR:
          {
            FinishedDir = new SortDirectory(_dir, 0, dirType.FINISHEDDIR);
            break;
          }
      }
    }

    private void addToDirList(SortDirectory _dir, ref List<SortDirectory> _list)
    {
      if (!_list.Contains(_dir))
      {
        _list.Add(_dir);
      }
    }

    public void addMainSubDir_Interface(ref SortDirectory _MainDir, string subDir)
    {
      // Debug.WriteLine(_MainDir.fullName)
      // Debug.WriteLine(subDir)
      _MainDir.addSubDir(subDir);
      _MainDir.saveSubs();
      SaveSettingsXML();
    }

    public bool removeFromDirList(string _dir, dirType _type)
    {
      switch (_type)
      {
        case dirType.MAINDIR:
          {
            return removeFromDirList(_dir, ref mainDirs);
          }
        case dirType.PRESORTDIR:
          {
            return removeFromDirList(_dir, ref presortDirs);
          }
        case dirType.ROOTDIR:
          {
            return false;
          }
        case dirType.FINISHEDDIR:
          {
            if (FinishedDir is not null || !FinishedDir.Equals(""))
            {
              FinishedDir = null;
              return true;
            }
            else
            {
              return false;
            }
          }
        case dirType.CONVERTDIR:
          {
            foreach (SortDirectory c in convertDirs)
            {
              if (c.fullName().Equals(_dir))
              {
                return convertDirs.Remove(c);
              }
              else
              {
                // Return False
              }
            }

            break;
          }

        case dirType.ERRORDIR:
          {
            return false;
          }
        case dirType.BLOCKEDDIR:
          {
            return removeFromDirList(_dir, ref blockedDirs);
          }
      }

      return default;
    }

    public bool removeFromDirList(string _dir, ref List<SortDirectory> _list)
    {
      if (_list is not null && _list.Count > 0)
      {
        foreach (SortDirectory sd in _list)
        {
          if (sd.fullName().Equals(_dir))
          {
            return _list.Remove(sd);
          }
          // If it got here, then it did not run the return statement (i.e., it did not find a directory in the list that matched the target directory)
          // so there's a chance the target directory may exist in this SortDirectory sd's list of subdirectories
          if (removeFromDirList(_dir, ref sd.getSubs()))
          {
            return true;
          }
        }
      }

      return default;
    }

    public void ParseSettingsXML()
    {
      // Dim reader = XmlReader.Create(rootDir & "\sortSettings.xml")
      var xdoc = new XmlDocument();
      try
      {
        xdoc.Load(rootDir.fullName() + @"\sortSettings.xml");
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return;
      }

      var emain = xdoc.GetElementsByTagName(XMLNODEMAIN);
      var pmain = xdoc.GetElementsByTagName(XMLNODEPRESORTS);
      var bmain = xdoc.GetElementsByTagName(XMLNODEBLOCKED);
      var cmain = xdoc.GetElementsByTagName(XMLNODECONVERT);
      var finish = xdoc.GetElementsByTagName(XMLNODEFINISHED);

      foreach (XmlNode e in emain)
      {
        foreach (XmlNode c in e.ChildNodes)
        {
          if (c.Name == "dir")
          {
            addToDirList(c.FirstChild.Value.Trim(), dirType.MAINDIR);
          }
        }
      }

      foreach (XmlNode e in pmain)
      {
        foreach (XmlNode c in e.ChildNodes)
        {
          if (c.Name == "dir")
          {
            addToDirList(c.FirstChild.Value.Trim(), dirType.PRESORTDIR);
          }
        }
      }

      foreach (XmlNode e in bmain)
      {
        foreach (XmlNode c in e.ChildNodes)
        {
          if (c.Name == "dir")
          {
            addToDirList(c.FirstChild.Value.Trim(), dirType.BLOCKEDDIR);
          }
        }
      }

      foreach (XmlNode e in cmain)
      {
        foreach (XmlNode c in e.ChildNodes)
        {
          if (c.Name == "dir")
          {
            string script = c.Attributes.GetNamedItem("script").Value;
            string name = c.Attributes.GetNamedItem("name").Value;
            addToDirList(c.FirstChild.Value.Trim(), dirType.CONVERTDIR, name, script);
          }
        }
      }

      foreach (XmlNode e in finish)
      {
        foreach (XmlNode c in e.ChildNodes)
        {
          if (c.Name == "dir")
          {
            addToDirList(c.FirstChild.Value.Trim(), dirType.FINISHEDDIR);
          }
        }
      }
    }

    public bool SaveSettingsXML()
    {
      var xws = new XmlWriterSettings();
      xws.Indent = true;

      using (var writer = XmlWriter.Create(rootDir.fullName() + @"\sortSettings.xml", xws))
      {
        writer.WriteStartDocument();
        writer.WriteStartElement("rootDir");
        writer.WriteAttributeString("dir", rootDir.fullName());

        writer.WriteStartElement("mains");
        foreach (var m in mainDirs)
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

        writer.WriteStartElement("presorts");
        foreach (var p in presortDirs)
        {
          writer.WriteStartElement("dir");
          // If p.hasSubs() Then
          // writer.WriteStartAttribute("hasSub", "true")
          // p.saveSubs()
          // End If
          writer.WriteString(p.fullName());
          writer.WriteFullEndElement();
        }
        writer.WriteFullEndElement();

        writer.WriteStartElement("convert");
        foreach (var c in convertDirs)
        {
          writer.WriteStartElement("dir");
          writer.WriteAttributeString("name", c.getConvTitle());
          writer.WriteAttributeString("script", c.getScriptPath());
          writer.WriteString(c.fullName());
          writer.WriteFullEndElement();
        }
        writer.WriteFullEndElement();

        writer.WriteStartElement("finished");
        if (FinishedDir is not null)
        {
          writer.WriteStartElement("dir");
          writer.WriteString(FinishedDir.fullName());
          writer.WriteFullEndElement();
        }
        writer.WriteFullEndElement();

        writer.WriteFullEndElement();
        writer.Close();
      }

      return default;

    }


    public bool IsValidSettings(string _in)
    {
      string tempRoot;
      var tempMains = new List<string>();
      var tempPresort = new List<string>();
      var tempBlock = new List<string>();

      if (!string.IsNullOrEmpty(_in))
      {
        var temp = Regex.Match(_in, rootRegex);
        tempRoot = temp.ToString().Remove(0, rootHeader.Length);

        if (!System.IO.Directory.Exists(rootDir.fullName()))
        {
          return false;
        }

        temp = Regex.Match(_in, mainsRegex);
        string mainsFull = temp.ToString().Remove(0, mainsHeader.Length);
        string[] mains = Strings.Split(mainsFull, Constants.vbNewLine);
        foreach (string line in mains)
          tempMains.Add(line);

        foreach (var main in tempMains)
        {
          if (!System.IO.Directory.Exists(main))
          {
            return false;
          }
        }


        temp = Regex.Match(_in, presortRegex);
        string presortFull = temp.ToString().Remove(0, presortHeader.Length);
        string[] presorts = Strings.Split(presortFull, Constants.vbNewLine);
        foreach (string line in presorts)
          tempPresort.Add(line);

        foreach (var presort in tempPresort)
        {
          if (!System.IO.Directory.Exists(presort))
          {
            return false;
          }
        }

        temp = Regex.Match(_in, blockRegex);
        string blockFull = temp.ToString().Remove(0, blockHeader.Length);
        string[] blocks = Strings.Split(presortFull, Constants.vbNewLine);
        foreach (string line in blocks)
          tempBlock.Add(line);

        foreach (var block in tempBlock)
        {
          if (!System.IO.Directory.Exists(block))
          {
            return false;
          }
        }

      }

      return default;
    }


    /// <summary>
    /// Checks if settings are valid.
    /// </summary>
    /// <param name="throwEx">Optional, defaults False. Function throws an exception instead of returning false when there the settings are invalid.</param>
    /// <returns>True if settings are valid. If input true, will throw exception instead of returning false when settings are invalid.</returns>
    public bool IsValidSettings(bool throwEx = false)
    {
      bool ret = true;
      if (!System.IO.Directory.Exists(rootDir.fullName()))
      {
        if (throwEx)
          throw new InvalidDirectoryException("Root Directory Does not exist!" + Constants.vbNewLine + rootDir.fullName());
        ret = false;
      }

      foreach (var main in mainDirs)
      {
        if (!System.IO.Directory.Exists(main.fullName()))
        {
          if (throwEx)
            throw new InvalidDirectoryException("Main Directory Does not exist!" + Constants.vbNewLine + main.fullName());
          ret = false;
        }
      }

      foreach (var presort in presortDirs)
      {
        if (!System.IO.Directory.Exists(presort.fullName()))
        {
          if (throwEx)
            throw new InvalidDirectoryException("Presorted Directory Does not exist!" + Constants.vbNewLine + presort.fullName());
          ret = false;
        }
      }

      foreach (var block in blockedDirs)
      {
        if (!System.IO.Directory.Exists(block.fullName()))
        {
          if (throwEx)
            throw new InvalidDirectoryException("Blocked Directory Does not exist!" + Constants.vbNewLine + block.fullName());
          ret = false;
        }
      }

      foreach (var conv in convertDirs)
      {
        if (!System.IO.Directory.Exists(conv.fullName()))
        {
          if (throwEx)
            throw new InvalidDirectoryException("Conversion Directory Does not exist!" + Constants.vbNewLine + conv.fullName());
          ret = false;
        }

        if (conv.getScriptPath() is not null || System.IO.File.Exists(conv.getScriptPath()))
        {
          if (throwEx)
            throw new InvalidDirectoryException("Conversion Directory Script Does not exist!" + Constants.vbNewLine + conv.fullName());
          ret = false;
        }
      }


      return ret;
    }



    public List<SortDirectory> getList(dirType which)
    {
      var ret = new List<SortDirectory>();
      switch (which)
      {
        case dirType.ROOTDIR:
          {
            ret.Add(rootDir);
            break;
          }
        case dirType.MAINDIR:
          {
            ret.AddRange(mainDirs);
            break;
          }
        case dirType.PRESORTDIR:
          {
            ret.AddRange(presortDirs);
            break;
          }
        case dirType.BLOCKEDDIR:
          {
            ret.AddRange(blockedDirs);
            break;
          }
        case dirType.CONVERTDIR:
          {
            ret.AddRange(convertDirs);
            break;
          }
      }
      return ret;
    }

    public SortDirectory getFinished()
    {
      return FinishedDir;
    }

    public List<SortDirectory> getConvDirs()
    {
      return convertDirs;
    }

    public override string ToString()
    {
      string tempMain = mainsHeader + Constants.vbNewLine;
      string tempPres = presortHeader + Constants.vbNewLine;
      string tempBlock = blockHeader + Constants.vbNewLine;
      foreach (var l in mainDirs)
        tempMain += l.fullName() + Constants.vbNewLine;
      tempMain += "#" + Constants.vbNewLine;

      foreach (var l in presortDirs)
        tempPres += l.fullName() + Constants.vbNewLine;
      tempPres += "#" + Constants.vbNewLine;

      foreach (var l in blockedDirs)
        tempBlock += l.fullName() + Constants.vbNewLine;
      tempBlock += "#" + Constants.vbNewLine;

      return rootHeader + Constants.vbNewLine + rootDir.fullName().Trim() + Constants.vbNewLine + "#" + Constants.vbNewLine + tempMain + tempPres + tempBlock;

    }

    public void Close()
    {
      try
      {
        _fileStream.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }

  }
}