using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FolderSelector : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderSelector));
            FoldersListBox = new ListBox();
            FoldersListBox.DoubleClick += new EventHandler(FoldersListBox_SelectedIndexChanged);
            TableLayoutPanel1 = new TableLayoutPanel();
            Panel1 = new Panel();
            cancelSelectButton = new Button();
            cancelSelectButton.Click += new EventHandler(CancelButton_Click);
            doneButton = new Button();
            doneButton.Click += new EventHandler(DoneButton_Click);
            TableLayoutPanel1.SuspendLayout();
            Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // FoldersListBox
            // 
            FoldersListBox.Dock = DockStyle.Fill;
            FoldersListBox.FormattingEnabled = true;
            FoldersListBox.Location = new Point(3, 3);
            FoldersListBox.Name = "FoldersListBox";
            FoldersListBox.Size = new Size(233, 140);
            FoldersListBox.TabIndex = 0;
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 1;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Controls.Add(FoldersListBox, 0, 0);
            TableLayoutPanel1.Controls.Add(Panel1, 0, 1);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 2;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35.0f));
            TableLayoutPanel1.Size = new Size(239, 181);
            TableLayoutPanel1.TabIndex = 1;
            // 
            // Panel1
            // 
            Panel1.Controls.Add(cancelSelectButton);
            Panel1.Controls.Add(doneButton);
            Panel1.Dock = DockStyle.Fill;
            Panel1.Location = new Point(3, 149);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(233, 29);
            Panel1.TabIndex = 1;
            // 
            // cancelSelectButton
            // 
            cancelSelectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelSelectButton.Location = new Point(74, 3);
            cancelSelectButton.Name = "cancelSelectButton";
            cancelSelectButton.Size = new Size(75, 23);
            cancelSelectButton.TabIndex = 1;
            cancelSelectButton.Text = "Cancel";
            cancelSelectButton.UseVisualStyleBackColor = true;
            // 
            // doneButton
            // 
            doneButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            doneButton.Location = new Point(155, 3);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(75, 23);
            doneButton.TabIndex = 0;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            // 
            // FolderSelector
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 181);
            Controls.Add(TableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FolderSelector";
            Text = "Folder Selector";
            TableLayoutPanel1.ResumeLayout(false);
            Panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal ListBox FoldersListBox;
        internal TableLayoutPanel TableLayoutPanel1;
        internal Panel Panel1;
        internal Button cancelSelectButton;
        internal Button doneButton;
    }
}