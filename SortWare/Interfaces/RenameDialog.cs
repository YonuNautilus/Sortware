using System;
using System.Windows.Forms;

namespace SortWare
{
    public partial class RenameDialog
    {
        private string _path;
        public RenameDialog(string path)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            Label1.Text = "Renaming File: " + path;
            _path = path;
            TextBox1.Text = System.IO.Path.GetFileNameWithoutExtension(path);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HandleKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string oldPath = System.IO.Path.GetFileNameWithoutExtension(_path);
                string newFileName = TextBox1.Text + System.IO.Path.GetExtension(_path);
                if (!oldPath.Equals(TextBox1.Text))
                {
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(_path, newFileName);
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                    Close();
                }
            }
        }
    }
}