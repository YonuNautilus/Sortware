using System;
using System.Windows.Forms;

namespace SortWare
{
    public partial class FolderSelector
    {
        private SortSettings settings;
        private SortDirectory returnDirectory;
        public FolderSelector(SortSettings _settings)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            settings = _settings;
            foreach (var f in settings.getList(SortSettings.dirType.PRESORTDIR))
                FoldersListBox.Items.Add(f);
        }

        public SortDirectory getSelectedDir()
        {
            return returnDirectory;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            returnDirectory = (SortDirectory)FoldersListBox.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FoldersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoneButton_Click(sender, e);
        }
    }
}