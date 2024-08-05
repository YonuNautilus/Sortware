using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class PresortedFilesViewer : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FilesToBeSorted = new ListBox();
            SuspendLayout();
            // 
            // FilesToBeSorted
            // 
            FilesToBeSorted.Dock = DockStyle.Fill;
            FilesToBeSorted.FormattingEnabled = true;
            FilesToBeSorted.Location = new Point(0, 0);
            FilesToBeSorted.Margin = new Padding(0);
            FilesToBeSorted.Name = "FilesToBeSorted";
            FilesToBeSorted.SelectionMode = SelectionMode.MultiExtended;
            FilesToBeSorted.Size = new Size(150, 150);
            FilesToBeSorted.TabIndex = 1;
            // 
            // PresortedFilesViewer
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(FilesToBeSorted);
            Name = "PresortedFilesViewer";
            ResumeLayout(false);

        }

        internal ListBox FilesToBeSorted;
    }
}