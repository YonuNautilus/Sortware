using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SortWare
{

    public partial class FileConversion
    {

        private List<SortDirectory> conversionDirs;
        private SortDirectory finishedDir;
        public FileConversion(List<SortDirectory> convDirs, SortDirectory finDir)
        {
            // This call is required by the designer.
            InitializeComponent();

            conversionDirs = convDirs;
            finishedDir = finDir;
            refreshDirs();
        }

        private void refreshDirs()
        {
            ConversionFolders.Items.Clear();

            foreach (var e in conversionDirs)
            {
                var lvi = new ListViewItem(new[] { e.getName(), e.fullName(), e.getScriptPath(), e.getConvTitle() });
                ConversionFolders.Items.Add(lvi);
            }
        }

        private void refreshFiles()
        {
            FilesToBeConverted.Items.Clear();

            if (ConversionFolders.SelectedItems.Count == 1)
            {
                string loc = ConversionFolders.SelectedItems[0].SubItems[1].Text;
                string[] fType = Regex.Matches(Regex.Match(ConversionFolders.SelectedItems[0].SubItems[3].Text, @"\S+").Value, "[^ -]+").OfType<Match>().Select((m) => m.Value.ToLower()).ToArray();
                foreach (var f in System.IO.Directory.GetFiles(loc))
                {
                    if (fType.Contains(System.IO.Path.GetExtension(f).ToLower().Remove(0, 1)))
                    {
                        var newItem = FilesToBeConverted.Items.Add(f);
                        newItem.SubItems.Add(Generics.GetFileSize(f));
                        string newName = System.IO.Path.GetFileNameWithoutExtension(f) + ".mp4";
                        if (System.IO.File.Exists(finishedDir.fullName() + @"\" + newName))
                        {
                            newItem.BackColor = Color.DarkRed;
                            newItem.ForeColor = Color.White;
                            newItem.SubItems.Add(Generics.GetFileSize(finishedDir.fullName() + @"\" + newName));
                        }
                    }
                }
            }
        }

        private void ConversionFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFiles();
        }

        private void ConvSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem f in FilesToBeConverted.SelectedItems)
            {
                string oldName = f.Text;
                string fname = System.IO.Path.GetFileNameWithoutExtension(f.Text) + ".mp4";
                string newName = finishedDir.fullName() + @"\" + fname;
                string scriptLoc = ConversionFolders.SelectedItems[0].SubItems[1].Text;
                string scriptName = System.IO.Path.GetFileName(ConversionFolders.SelectedItems[0].SubItems[2].Text);
                var proc = new Process();
                try
                {
                    string batDir = string.Format(@"D:\");
                    proc = new Process();
                    proc.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(ConversionFolders.SelectedItems[0].SubItems[1].Text);
                    proc.StartInfo.FileName = scriptLoc;
                    proc.StartInfo.Arguments = "\"" + oldName + "\"" + " " + "\"" + newName + "\"";
                    proc.StartInfo.CreateNoWindow = false;
                    var newProc = Process.Start(scriptLoc + @"\" + scriptName, proc.StartInfo.Arguments);
                    newProc.WaitForExit();
                }
                catch (Exception ex)
                {

                }
            }
            refreshFiles();
        }

        private void ClearDone_Click(object sender, EventArgs e)
        {
            if (ConversionFolders.SelectedItems.Count == 1)
            {
                string loc = ConversionFolders.SelectedItems[0].SubItems[1].Text;
                string[] fType = Regex.Matches(Regex.Match(ConversionFolders.SelectedItems[0].SubItems[3].Text, @"\S+").Value, "[^ -]+").OfType<Match>().Select((m) => m.Value.ToLower()).ToArray();
                foreach (var f in System.IO.Directory.GetFiles(loc))
                {
                    if (fType.Contains(System.IO.Path.GetExtension(f).ToLower().Remove(0, 1)))
                    {
                        var newItem = FilesToBeConverted.Items.Add(f);
                        string newName = System.IO.Path.GetFileNameWithoutExtension(f) + ".mp4";
                        if (System.IO.File.Exists(finishedDir.fullName() + @"\" + newName))
                        {
                            System.IO.File.Delete(f);
                        }
                    }
                }
            }
            refreshFiles();
        }
    }
}