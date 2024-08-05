using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class TypeSelector : UserControl
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
            var TreeNode1 = new TreeNode("Images");
            var TreeNode2 = new TreeNode("Videos");
            var TreeNode3 = new TreeNode("Misc");
            TreeView1 = new TreeView();
            TreeView1.AfterCheck += new TreeViewEventHandler(TreeView1_AfterSelect);
            TreeView1.AfterSelect += new TreeViewEventHandler(TreeView1_AfterSelect);
            SuspendLayout();
            // 
            // TreeView1
            // 
            TreeView1.CheckBoxes = true;
            TreeView1.Dock = DockStyle.Fill;
            TreeView1.Location = new Point(0, 0);
            TreeView1.Name = "TreeView1";
            TreeNode1.Name = "Images";
            TreeNode1.Text = "Images";
            TreeNode2.Name = "Videos";
            TreeNode2.Text = "Videos";
            TreeNode3.Name = "Misc";
            TreeNode3.Text = "Misc";
            TreeView1.Nodes.AddRange(new TreeNode[] { TreeNode1, TreeNode2, TreeNode3 });
            TreeView1.Size = new Size(150, 150);
            TreeView1.TabIndex = 0;
            // 
            // TypeSelector
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TreeView1);
            Name = "TypeSelector";
            Load += new EventHandler(TypeSelect_Load);
            ResumeLayout(false);

        }

        internal TreeView TreeView1;
    }
}