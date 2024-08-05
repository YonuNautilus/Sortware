using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SortWare
{
    public partial class LogViewer
    {

        private MainInterface MI;
        private class LogItem : ListViewItem
        {

            public ListViewSubItem Time;
            public ListViewSubItem Original;
            public ListViewSubItem Final;
            public ListViewSubItem Tags;
            public LogItem(string _entry)
            {
                string[] things = Strings.Split(_entry, Constants.vbTab);
                for (int i = 0, loopTo = things.Length - 1; i <= loopTo; i++)
                {
                    // take each line of the log file, split it up by tab, and set the LogItem's fields to the corresponding log file line's field
                    switch (i)
                    {
                        case 0:
                            {
                                Time = new ListViewSubItem(this, things[i]);
                                SubItems.Add(Time);
                                break;
                            }
                        case 1:
                            {
                                Original = new ListViewSubItem(this, things[i]);
                                SubItems.Add(Original);
                                break;
                            }
                        case 2:
                            {
                                Final = new ListViewSubItem(this, things[i]);
                                SubItems.Add(Final);
                                break;
                            }
                        case 3:
                            {
                                Tags = new ListViewSubItem(this, things[i]);
                                SubItems.Add(Tags);
                                break;
                            }
                    }
                }
                Text = System.IO.Path.GetFileName(Final.Text);
            }
        }
        public LogViewer(string[] _logs, ref MainInterface mainInt)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            LogsBox.MultiSelect = false;
            MI = mainInt;
            foreach (var l in _logs)
                LogsBox.Items.Add(new LogItem(l));
        }

        private void UndoActionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogsBox.SelectedItems is not null && LogsBox.SelectedItems[0] is LogItem)
                {
                    string final = ((LogItem)LogsBox.SelectedItems[0]).Final.Text;
                    string orig = ((LogItem)LogsBox.SelectedItems[0]).Original.Text;
                    string tags = "";
                    if (((LogItem)LogsBox.SelectedItems[0]).Tags is not null)
                    {
                        tags = ((LogItem)LogsBox.SelectedItems[0]).Tags.Text;
                    }

                    if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(orig)))
                    {
                        throw new System.IO.IOException("Original File's Directory Doesn't Exist");
                    }
                    if (!System.IO.File.Exists(final))
                    {
                        throw new System.IO.IOException("Final File Doesn't Exist");
                    }

                    System.IO.File.Move(final, orig);
                    // Dim finalFile = IO.Path.GetFileName(final)
                    // If finalFile.Length >= tags AndAlso finalFile.Substring(0, tags.Length) = tags Then 'If the tags can fit into the file name, and the first part of the file name is the tags, then
                    MI.writeToLogFile(final, orig, tags);
                    // End If
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (LogsBox.SelectedItems is not null && LogsBox.SelectedItems[0] is LogItem)
            {
                if (System.IO.File.Exists(((LogItem)LogsBox.SelectedItems[0]).Final.Text))
                {
                    Process.Start(((LogItem)LogsBox.SelectedItems[0]).Final.Text);
                }
                else
                {
                    Interaction.MsgBox("File Does Not Exist");
                }
            }
        }

        private void OpenFileLocButton_Click(object sender, EventArgs e)
        {
            if (LogsBox.SelectedItems is not null && LogsBox.SelectedItems[0] is LogItem)
            {
                if (System.IO.File.Exists(((LogItem)LogsBox.SelectedItems[0]).Final.Text))
                {
                    Process.Start("explorer.exe", "/select," + ((LogItem)LogsBox.SelectedItems[0]).Final.Text);
                }
                else
                {
                    Interaction.MsgBox("File Does Not Exist");
                }
            }
        }
    }
}