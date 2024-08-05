using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DecompressFolderDialog : Form
    {

        // Form overrides dispose to clean up the component list.
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
            var TreeNode1 = new TreeNode("Images");
            var TreeNode2 = new TreeNode("Videos/Animations");
            var TreeNode3 = new TreeNode("Misc");
            TableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel2 = new TableLayoutPanel();
            FileTypeCheckBox = new TreeView();
            TableLayoutPanel3 = new TableLayoutPanel();
            DoDecompressButton = new Button();
            TableLayoutPanel1.SuspendLayout();
            TableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 0);
            TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 0, 0);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Size = new Size(800, 450);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            TableLayoutPanel2.ColumnCount = 1;
            TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel2.Controls.Add(FileTypeCheckBox, 0, 0);
            TableLayoutPanel2.Controls.Add(DoDecompressButton, 0, 2);
            TableLayoutPanel2.Dock = DockStyle.Fill;
            TableLayoutPanel2.Location = new Point(403, 3);
            TableLayoutPanel2.Name = "TableLayoutPanel2";
            TableLayoutPanel2.RowCount = 3;
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00001f));
            TableLayoutPanel2.RowStyles.Add(new RowStyle());
            TableLayoutPanel2.Size = new Size(394, 444);
            TableLayoutPanel2.TabIndex = 0;
            // 
            // FileTypeCheckBox
            // 
            FileTypeCheckBox.CheckBoxes = true;
            FileTypeCheckBox.Dock = DockStyle.Fill;
            FileTypeCheckBox.Location = new Point(0, 0);
            FileTypeCheckBox.Margin = new Padding(0);
            FileTypeCheckBox.Name = "FileTypeCheckBox";
            TreeNode1.Name = "Images";
            TreeNode1.Tag = "PARENT";
            TreeNode1.Text = "Images";
            TreeNode2.Name = "Videos/Animations";
            TreeNode2.Tag = "PARENT";
            TreeNode2.Text = "Videos/Animations";
            TreeNode3.Name = "Misc";
            TreeNode3.Text = "Misc";
            FileTypeCheckBox.Nodes.AddRange(new TreeNode[] { TreeNode1, TreeNode2, TreeNode3 });
            FileTypeCheckBox.Size = new Size(394, 207);
            FileTypeCheckBox.TabIndex = 1;
            // 
            // TableLayoutPanel3
            // 
            TableLayoutPanel3.ColumnCount = 1;
            TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel3.Dock = DockStyle.Fill;
            TableLayoutPanel3.Location = new Point(3, 3);
            TableLayoutPanel3.Name = "TableLayoutPanel3";
            TableLayoutPanel3.RowCount = 2;
            TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel3.Size = new Size(394, 444);
            TableLayoutPanel3.TabIndex = 1;
            // 
            // DoDecompressButton
            // 
            DoDecompressButton.Dock = DockStyle.Fill;
            DoDecompressButton.Location = new Point(3, 417);
            DoDecompressButton.Name = "DoDecompressButton";
            DoDecompressButton.Size = new Size(388, 24);
            DoDecompressButton.TabIndex = 2;
            DoDecompressButton.Text = "Move Specified Items Into Specified Folder";
            DoDecompressButton.UseVisualStyleBackColor = true;
            // 
            // DecompressFolderDialog
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TableLayoutPanel1);
            Name = "DecompressFolderDialog";
            Text = "Presorted Directory Decompressor";
            TableLayoutPanel1.ResumeLayout(false);
            TableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal TableLayoutPanel TableLayoutPanel1;
        internal TableLayoutPanel TableLayoutPanel2;
        internal TreeView FileTypeCheckBox;
        internal TableLayoutPanel TableLayoutPanel3;
        internal Button DoDecompressButton;
    }
}