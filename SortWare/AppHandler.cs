using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortWare
{
  internal sealed class AppHandler
  {
    private static AppHandler m_oInstance;
    private static readonly object instanceLock = new object();
    private AppHandler() { Core.Initialize(); }
    public static AppHandler Instance
    {
      get
      {
        lock (instanceLock)
        {
          if (m_oInstance == null) m_oInstance = new AppHandler();
          return m_oInstance;
        }
      }
    }

    private void StartApp()
    {
      Application.Run(new MainInterface());
    }

    public static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Instance.StartApp();
    }

  }
}