using System;

namespace SortWare
{
    public partial class ConvDirTypeSelector
    {
        public ConvDirTypeSelector()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Tag = (string)ComboBox1.SelectedItem;
            Close();
        }
    }
}