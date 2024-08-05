using System.Collections.Generic;
using System.Linq;

namespace SortWare
{
    public class DupeStruct
    {

        private class FileNamePair
        {
            private List<string> Dir1Files;
            private List<string> Dir2Files;

            public FileNamePair()
            {
                Dir1Files = new List<string>();
                Dir2Files = new List<string>();
            }

            public FileNamePair(string d1f, string d2f)
            {
                Dir1Files = new List<string>();
                Dir2Files = new List<string>();

                if (d1f is not null)
                {
                    Dir1Files.Add(d1f);
                }

                if (d2f is not null)
                {
                    Dir2Files.Add(d2f);
                }
            }

            public void AddD1File(string fname)
            {
                Dir1Files.Add(fname);
            }

            public void AddD2File(string fname)
            {
                Dir2Files.Add(fname);
            }

            public long Count()
            {
                return Dir1Files.Count + Dir2Files.Count;
            }

            public bool isGoodCount()
            {
                return Count() > 1L;
            }

            public List<string> GetDir1Files()
            {
                return new List<string>(Dir1Files);
            }

            public List<string> GetDir2Files()
            {
                return new List<string>(Dir2Files);
            }
        }

        private Dictionary<long, FileNamePair> dupeDict;

        public DupeStruct()
        {
            dupeDict = new Dictionary<long, FileNamePair>();
        }

        public void AddD1File(long size, string fname)
        {
            if (!dupeDict.ContainsKey(size))
            {
                dupeDict.Add(size, new FileNamePair(fname, null));
            }
            else
            {
                dupeDict[size].AddD1File(fname);
            }
        }

        public void AddD2File(long size, string fname)
        {
            if (!dupeDict.ContainsKey(size))
            {
                dupeDict.Add(size, new FileNamePair(null, fname));
            }
            else
            {
                dupeDict[size].AddD2File(fname);
            }
        }

        public void ClearLowCountSizes()
        {
            foreach (var item in dupeDict.ToList())
            {
                if (!item.Value.isGoodCount())
                {
                    dupeDict.Remove(item.Key);
                }
            }
        }

        public List<string> GetDir1Files()
        {
            var ret = new List<string>();
            foreach (var item in dupeDict)
                ret.AddRange(item.Value.GetDir1Files());
            return ret;
        }

        public List<string> GetDir2Files()
        {
            var ret = new List<string>();
            foreach (var item in dupeDict)
                ret.AddRange(item.Value.GetDir2Files());
            return ret;
        }

        public void Clear()
        {
            dupeDict.Clear();
        }
    }
}