using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SortWare
{
  public class DirTag
  {
    private string m_sKey;
    private string m_sValue;

    [XmlAttribute("key")]
    public string Key { get { return m_sKey; } set { m_sKey = value; } }

    [XmlAttribute("value")]
    public string Value { get { return m_sValue; } set { m_sValue = value; } }

    public DirTag() { }

    internal DirTag(string key, string value)
    {
      Key = key;
      Value = value;
    }

    public override string ToString() => Key + '\t' + Value;
  }
}
