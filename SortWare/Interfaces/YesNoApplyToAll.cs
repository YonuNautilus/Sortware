using System;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    public partial class YesNoApplyToAll
    {

        public bool applyAll { get; set; } = false;

        public YesNoApplyToAll(string msg)
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            MainLabel.Text = msg;
            MainLabel.MaximumSize = new Size(480, 0);
            MainLabel.AutoSize = true;
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            applyAll = ApplyAllChkBx.Checked;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            applyAll = ApplyAllChkBx.Checked;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            applyAll = ApplyAllChkBx.Checked;
        }
    }
}