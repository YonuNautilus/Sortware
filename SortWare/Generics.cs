using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SortWare
{
    public class Generics
    {

        public const string _imgExtensions = ".png .jpg .jpeg .jfif .tif .tiff .gif .bmp .webp";
        public const string _vidExtensions = ".mov .webm .wmv .mp4 .avi .mkv .m4v .m2ts .mts .mpg .mpeg .flv";
        public const string _miscExtensions = ".zip .rar";

        public class ListViewItemComparer : IComparer
        {
            private int colNum;
            private SortOrder sOrd;

            public ListViewItemComparer(int _colNum, SortOrder _sOrd)
            {
                colNum = _colNum;
                sOrd = _sOrd;
            }

            public int Compare(object x, object y)
            {
                // Throw New NotImplementedException()
                ListViewItem itemX = (ListViewItem)x;
                ListViewItem itemY = (ListViewItem)y;

                // get the subitem values
                string stringX;
                if (itemX.SubItems.Count <= colNum)
                {
                    stringX = "";
                }
                else
                {
                    stringX = itemX.SubItems[colNum].Text;
                }

                string stringY;
                if (itemY.SubItems.Count <= colNum)
                {
                    stringY = "";
                }
                else
                {
                    stringY = itemY.SubItems[colNum].Text;
                }

                // Compare them
                if (sOrd == SortOrder.Ascending)
                {
                    if (Information.IsNumeric(stringX) && Information.IsNumeric(stringY))
                    {
                        return Conversion.Val(stringX).CompareTo(Conversion.Val(stringY));
                    }
                    else if (Information.IsDate(stringX) && Information.IsDate(stringY))
                    {
                        return DateTime.Parse(stringX).CompareTo(DateTime.Parse(stringY));
                    }
                    else
                    {
                        return string.Compare(stringX, stringY);
                    }
                }
                else if (Information.IsNumeric(stringY) && Information.IsNumeric(stringX))
                {
                    return Conversion.Val(stringY).CompareTo(Conversion.Val(stringX));
                }
                else if (Information.IsDate(stringY) && Information.IsDate(stringX))
                {
                    return DateTime.Parse(stringY).CompareTo(DateTime.Parse(stringX));
                }
                else
                {
                    return string.Compare(stringY, stringX);
                }

            }
        }

        public static List<TreeNode> GetCheck(TreeNodeCollection node)
        {
            var lN = new List<TreeNode>();
            foreach (TreeNode n in node)
            {
                if (n.Checked && n.Tag is null)
                {
                    lN.Add(n);
                }
                lN.AddRange(GetCheck(n.Nodes));
            }

            return lN;
        }


        // https://stackoverflow.com/questions/27367190/how-to-return-kb-mb-and-gb-from-bytes-using-a-public-function
        public static string GetFileSize(string TheFile)
        {
            double DoubleBytes;
            if (TheFile.Length == 0)
                return "";
            if (!System.IO.File.Exists(TheFile))
                return "";
            // ---
            ulong TheSize = (ulong)new System.IO.FileInfo(TheFile).Length;
            string SizeType = "";
            // ---

            try
            {
                switch (TheSize)
                {
                    case var @case when @case >= 1099511627776UL:
                        {
                            DoubleBytes = TheSize / 1099511627776d; // TB
                            return Strings.FormatNumber(DoubleBytes, 2) + " TB";
                        }
                    case var case1 when 1073741824UL <= case1 && case1 <= 1099511627775UL:
                        {
                            DoubleBytes = TheSize / 1073741824d; // GB
                            return Strings.FormatNumber(DoubleBytes, 2) + " GB";
                        }
                    case var case2 when 1048576UL <= case2 && case2 <= 1073741823UL:
                        {
                            DoubleBytes = TheSize / 1048576d; // MB
                            return Strings.FormatNumber(DoubleBytes, 2) + " MB";
                        }
                    case var case3 when 1024UL <= case3 && case3 <= 1048575UL:
                        {
                            DoubleBytes = TheSize / 1024d; // KB
                            return Strings.FormatNumber(DoubleBytes, 2) + " KB";
                        }
                    case var case4 when 0UL <= case4 && case4 <= 1023UL:
                        {
                            DoubleBytes = TheSize; // bytes
                            return Strings.FormatNumber(DoubleBytes, 2) + " bytes";
                        }

                    default:
                        {
                            return "";
                        }
                }
            }
            catch
            {
                return "";
            }
        }
    }
}