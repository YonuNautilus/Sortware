using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortWare
{
  internal sealed class AppHandler
  {
    private static AppHandler instance;
    private static readonly object instanceLock = new object();
    private AppHandler() { Core.Initialize(); }
    public static AppHandler Instance
    {
      get
      {
        lock (instanceLock)
        {
          if (instance == null) instance = new AppHandler();
          return instance;
        }
      }
    }


  }
}