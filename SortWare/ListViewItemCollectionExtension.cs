using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortWare
{
    internal static class ListViewItemCollectionExtension
    {
        public static List<ListViewItem> ToList(this ListView.ListViewItemCollection list)
        {
            List<ListViewItem> retList = new List<ListViewItem>();

            foreach (ListViewItem item in list)
                retList.Add(item);

            return retList;
        }
    }
}
