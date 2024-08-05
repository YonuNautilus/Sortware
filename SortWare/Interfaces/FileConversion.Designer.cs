using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FileConversion : Form
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
            FilesToBeConverted = new ListView();
            Filename = new ColumnHeader();
            ConversionFolders = new ListView();
            ConversionFolders.SelectedIndexChanged += new EventHandler(ConversionFolders_SelectedIndexChanged);
            FolderName = new ColumnHeader();
            FolderLocation = new ColumnHeader();
            ScriptLocation = new ColumnHeader();
            ControlPanel = new Panel();
            ButtonsGroup = new GroupBox();
            ClearDone = new Button();
            ClearDone.Click += new EventHandler(ClearDone_Click);
            ConvAll = new Button();
            ConvSelected = new Button();
            ConvSelected.Click += new EventHandler(ConvSelected_Click);
            PreConSize = new ColumnHeader();
            ConSize = new ColumnHeader();
            TableLayoutPanel1.SuspendLayout();
            ControlPanel.SuspendLayout();
            ButtonsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.ColumnCount = 3;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
            TableLayoutPanel1.Controls.Add(FilesToBeConverted, 1, 0);
            TableLayoutPanel1.Controls.Add(ConversionFolders, 0, 0);
            TableLayoutPanel1.Controls.Add(ControlPanel, 2, 0);
            TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Location = new Point(0, 0);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel1.Size = new Size(800, 450);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // FilesToBeConverted
            // 
            FilesToBeConverted.Activation = ItemActivation.OneClick;
            FilesToBeConverted.Columns.AddRange(new ColumnHeader[] { Filename, PreConSize, ConSize });
            FilesToBeConverted.Dock = DockStyle.Fill;
            FilesToBeConverted.HideSelection = false;
            FilesToBeConverted.Location = new Point(269, 3);
            FilesToBeConverted.Name = "FilesToBeConverted";
            FilesToBeConverted.Size = new Size(260, 444);
            FilesToBeConverted.TabIndex = 3;
            FilesToBeConverted.UseCompatibleStateImageBehavior = false;
            FilesToBeConverted.View = View.Details;
            // 
            // Filename
            // 
            Filename.Text = "Name";
            Filename.Width = 256;
            // 
            // ConversionFolders
            // 
            ConversionFolders.Columns.AddRange(new ColumnHeader[] { FolderName, FolderLocation, ScriptLocation });
            ConversionFolders.Dock = DockStyle.Fill;
            ConversionFolders.HideSelection = false;
            ConversionFolders.Location = new Point(3, 3);
            ConversionFolders.MultiSelect = false;
            ConversionFolders.Name = "ConversionFolders";
            ConversionFolders.Size = new Size(260, 444);
            ConversionFolders.TabIndex = 0;
            ConversionFolders.UseCompatibleStateImageBehavior = false;
            ConversionFolders.View = View.Details;
            // 
            // FolderName
            // 
            FolderName.Text = "Name";
            // 
            // FolderLocation
            // 
            FolderLocation.Text = "Location";
            // 
            // ScriptLocation
            // 
            ScriptLocation.Text = "Script";
            // 
            // ControlPanel
            // 
            ControlPanel.Controls.Add(ButtonsGroup);
            ControlPanel.Dock = DockStyle.Fill;
            ControlPanel.Location = new Point(535, 3);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(262, 444);
            ControlPanel.TabIndex = 2;
            // 
            // ButtonsGroup
            // 
            ButtonsGroup.Controls.Add(ClearDone);
            ButtonsGroup.Controls.Add(ConvAll);
            ButtonsGroup.Controls.Add(ConvSelected);
            ButtonsGroup.Dock = DockStyle.Top;
            ButtonsGroup.Location = new Point(0, 0);
            ButtonsGroup.Name = "ButtonsGroup";
            ButtonsGroup.Size = new Size(262, 164);
            ButtonsGroup.TabIndex = 1;
            ButtonsGroup.TabStop = false;
            ButtonsGroup.Text = "GroupBox1";
            // 
            // ClearDone
            // 
            ClearDone.Dock = DockStyle.Top;
            ClearDone.Location = new Point(3, 62);
            ClearDone.Name = "ClearDone";
            ClearDone.Size = new Size(256, 23);
            ClearDone.TabIndex = 2;
            ClearDone.Text = "Delete Finished Files";
            ClearDone.UseVisualStyleBackColor = true;
            // 
            // ConvAll
            // 
            ConvAll.Dock = DockStyle.Top;
            ConvAll.Location = new Point(3, 39);
            ConvAll.Name = "ConvAll";
            ConvAll.Size = new Size(256, 23);
            ConvAll.TabIndex = 1;
            ConvAll.Text = "Convert All Files In Folder";
            ConvAll.UseVisualStyleBackColor = true;
            // 
            // ConvSelected
            // 
            ConvSelected.Dock = DockStyle.Top;
            ConvSelected.Location = new Point(3, 16);
            ConvSelected.Name = "ConvSelected";
            ConvSelected.Size = new Size(256, 23);
            ConvSelected.TabIndex = 0;
            ConvSelected.Text = "Convert Selected Files";
            ConvSelected.UseVisualStyleBackColor = true;
            // 
            // PreConSize
            // 
            PreConSize.Text = "Preconverted size";
            // 
            // ConSize
            // 
            ConSize.Text = "Converted Size";
            // 
            // FileConversion
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TableLayoutPanel1);
            Name = "FileConversion";
            Text = "FileConversion";
            TableLayoutPanel1.ResumeLayout(false);
            ControlPanel.ResumeLayout(false);
            ButtonsGroup.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal TableLayoutPanel TableLayoutPanel1;
        internal ListView ConversionFolders;
        internal Panel ControlPanel;
        internal GroupBox ButtonsGroup;
        internal ListView FilesToBeConverted;
        internal Button ClearDone;
        internal Button ConvAll;
        internal Button ConvSelected;
        internal ColumnHeader FolderName;
        internal ColumnHeader FolderLocation;
        internal ColumnHeader ScriptLocation;
        internal ColumnHeader Filename;
        internal ColumnHeader PreConSize;
        internal ColumnHeader ConSize;
    }
}