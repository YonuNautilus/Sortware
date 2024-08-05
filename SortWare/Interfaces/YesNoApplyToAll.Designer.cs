using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class YesNoApplyToAll : Form
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
            YesButton = new Button();
            YesButton.Click += new EventHandler(YesButton_Click);
            NoButton = new Button();
            NoButton.Click += new EventHandler(NoButton_Click);
            MainLabel = new Label();
            ApplyAllChkBx = new CheckBox();
            CancelButton = new Button();
            CancelButton.Click += new EventHandler(CancelButton_Click);
            SuspendLayout();
            // 
            // YesButton
            // 
            YesButton.Location = new Point(15, 56);
            YesButton.Name = "YesButton";
            YesButton.Size = new Size(158, 23);
            YesButton.TabIndex = 0;
            YesButton.Text = "Yes, Delete This Folder";
            YesButton.UseVisualStyleBackColor = true;
            // 
            // NoButton
            // 
            NoButton.Location = new Point(179, 56);
            NoButton.Name = "NoButton";
            NoButton.Size = new Size(158, 23);
            NoButton.TabIndex = 1;
            NoButton.Text = "No, Do Not Delete This Folder";
            NoButton.UseVisualStyleBackColor = true;
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Location = new Point(12, 9);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(19, 13);
            MainLabel.TabIndex = 2;
            MainLabel.Text = "__";
            // 
            // ApplyAllChkBx
            // 
            ApplyAllChkBx.AutoSize = true;
            ApplyAllChkBx.Location = new Point(15, 86);
            ApplyAllChkBx.Name = "ApplyAllChkBx";
            ApplyAllChkBx.Size = new Size(191, 17);
            ApplyAllChkBx.TabIndex = 3;
            ApplyAllChkBx.Text = "Apply To All Folders In This Batch?";
            ApplyAllChkBx.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(343, 56);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(121, 23);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancel, Stop Deleting";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // YesNoApplyToAll
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 115);
            Controls.Add(CancelButton);
            Controls.Add(ApplyAllChkBx);
            Controls.Add(MainLabel);
            Controls.Add(NoButton);
            Controls.Add(YesButton);
            Name = "YesNoApplyToAll";
            Text = "Folder Still Contains Files!";
            ResumeLayout(false);
            PerformLayout();

        }

        internal Button YesButton;
        internal Button NoButton;
        internal Label MainLabel;
        internal CheckBox ApplyAllChkBx;
        internal Button CancelButton;
    }
}