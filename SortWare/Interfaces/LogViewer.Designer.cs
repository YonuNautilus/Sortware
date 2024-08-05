using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class LogViewer : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            TableLayoutPanel1 = new TableLayoutPanel();
            LogsBox = new ListView();
            File = new ColumnHeader();
            Time = new ColumnHeader();
            Original = new ColumnHeader();
            Final = new ColumnHeader();
            Tags = new ColumnHeader();
            Panel1 = new Panel();
            UndoActionButton = new Button();
            UndoActionButton.Click += new EventHandler(UndoActionButton_Click);
            OpenFileButton = new Button();
            OpenFileButton.Click += new EventHandler(OpenFileButton_Click);
            OpenFileLocButton = new Button();
            OpenFileLocButton.Click += new EventHandler(OpenFileLocButton_Click);
            TableLayoutPanel1.SuspendLayout();
            Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 1;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.Controls.Add(LogsBox, 0, 0);
            TableLayoutPanel1.Controls.Add(Panel1, 0, 1);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 2;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.0f));
            TableLayoutPanel1.Size = new Size(800, 450);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // LogsBox
            // 
            LogsBox.Columns.AddRange(new ColumnHeader[] { File, Time, Original, Final, Tags });
            LogsBox.Dock = DockStyle.Fill;
            LogsBox.Location = new Point(3, 3);
            LogsBox.Name = "LogsBox";
            LogsBox.Size = new Size(794, 414);
            LogsBox.TabIndex = 0;
            LogsBox.UseCompatibleStateImageBehavior = false;
            LogsBox.View = View.Details;
            // 
            // File
            // 
            File.Text = "File Name";
            File.Width = 175;
            // 
            // Time
            // 
            Time.Text = "Time";
            Time.Width = 71;
            // 
            // Original
            // 
            Original.Text = "Original File";
            Original.Width = 243;
            // 
            // Final
            // 
            Final.Text = "Final File";
            Final.Width = 236;
            // 
            // Tags
            // 
            Tags.Text = "Tags";
            // 
            // Panel1
            // 
            Panel1.Controls.Add(OpenFileLocButton);
            Panel1.Controls.Add(UndoActionButton);
            Panel1.Controls.Add(OpenFileButton);
            Panel1.Dock = DockStyle.Fill;
            Panel1.Location = new Point(0, 420);
            Panel1.Margin = new Padding(0);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(800, 30);
            Panel1.TabIndex = 1;
            // 
            // UndoActionButton
            // 
            UndoActionButton.Location = new Point(722, 4);
            UndoActionButton.Name = "UndoActionButton";
            UndoActionButton.Size = new Size(75, 23);
            UndoActionButton.TabIndex = 1;
            UndoActionButton.Text = "Undo Move";
            UndoActionButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(3, 4);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(75, 23);
            OpenFileButton.TabIndex = 0;
            OpenFileButton.Text = "Open File";
            OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileLocButton
            // 
            OpenFileLocButton.Location = new Point(359, 4);
            OpenFileLocButton.Name = "OpenFileLocButton";
            OpenFileLocButton.Size = new Size(113, 23);
            OpenFileLocButton.TabIndex = 2;
            OpenFileLocButton.Text = "Open File Location";
            OpenFileLocButton.UseVisualStyleBackColor = true;
            // 
            // LogViewer
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogViewer";
            Text = "LogViewer";
            TableLayoutPanel1.ResumeLayout(false);
            Panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal TableLayoutPanel TableLayoutPanel1;
        internal ListView LogsBox;
        internal ColumnHeader File;
        internal ColumnHeader Time;
        internal ColumnHeader Original;
        internal ColumnHeader Final;
        internal ColumnHeader Tags;
        internal Panel Panel1;
        internal Button OpenFileButton;
        internal Button UndoActionButton;
        internal Button OpenFileLocButton;
    }
}