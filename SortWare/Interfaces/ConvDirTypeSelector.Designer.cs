using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ConvDirTypeSelector : Form
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
            TableLayoutPanel1 = new TableLayoutPanel();
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            ComboBox1 = new ComboBox();
            TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 1;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Controls.Add(ComboBox1, 0, 0);
            TableLayoutPanel1.Controls.Add(Button1, 0, 1);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 2;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.RowStyles.Add(new RowStyle());
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel1.Size = new Size(312, 62);
            TableLayoutPanel1.TabIndex = 1;
            // 
            // Button1
            // 
            Button1.Dock = DockStyle.Fill;
            Button1.Location = new Point(3, 31);
            Button1.Name = "Button1";
            Button1.Size = new Size(306, 28);
            Button1.TabIndex = 0;
            Button1.Text = "Button1";
            Button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            Button1.UseVisualStyleBackColor = true;
            // 
            // ComboBox1
            // 
            ComboBox1.Dock = DockStyle.Fill;
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Items.AddRange(new object[] { "(None)", "Normal File Conversion", "Concatenation", "Rotation", "Cropping", "Trimming" });
            ComboBox1.Location = new Point(3, 3);
            ComboBox1.Name = "ComboBox1";
            ComboBox1.Size = new Size(306, 21);
            ComboBox1.TabIndex = 2;
            // 
            // ConvDirTypeSelector
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(312, 62);
            Controls.Add(TableLayoutPanel1);
            Name = "ConvDirTypeSelector";
            Text = "Choose Convirsion Directory Type";
            TableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal TableLayoutPanel TableLayoutPanel1;
        internal Button Button1;
        internal ComboBox ComboBox1;
    }
}