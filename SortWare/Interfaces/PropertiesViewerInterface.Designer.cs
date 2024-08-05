using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SortWare
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class PropertiesViewerInterface : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesViewerInterface));
            PropertiesViewer = new TabControl();
            BasicTab = new TabPage();
            DocumentTab = new TabPage();
            ImageTab = new TabPage();
            MusicTab = new TabPage();
            StorageTab = new TabPage();
            VideoTab = new TabPage();
            BasicPropertiesList = new ListBox();
            PropertiesViewer.SuspendLayout();
            BasicTab.SuspendLayout();
            SuspendLayout();
            // 
            // PropertiesViewer
            // 
            PropertiesViewer.Controls.Add(BasicTab);
            PropertiesViewer.Controls.Add(DocumentTab);
            PropertiesViewer.Controls.Add(ImageTab);
            PropertiesViewer.Controls.Add(MusicTab);
            PropertiesViewer.Controls.Add(StorageTab);
            PropertiesViewer.Controls.Add(VideoTab);
            PropertiesViewer.Dock = DockStyle.Fill;
            PropertiesViewer.Location = new Point(0, 0);
            PropertiesViewer.Name = "PropertiesViewer";
            PropertiesViewer.SelectedIndex = 0;
            PropertiesViewer.Size = new Size(800, 450);
            PropertiesViewer.TabIndex = 0;
            // 
            // BasicTab
            // 
            BasicTab.Controls.Add(BasicPropertiesList);
            BasicTab.Location = new Point(4, 22);
            BasicTab.Name = "BasicTab";
            BasicTab.Padding = new Padding(3);
            BasicTab.Size = new Size(792, 424);
            BasicTab.TabIndex = 0;
            BasicTab.Text = "Basic";
            BasicTab.UseVisualStyleBackColor = true;
            // 
            // DocumentTab
            // 
            DocumentTab.Location = new Point(4, 22);
            DocumentTab.Name = "DocumentTab";
            DocumentTab.Padding = new Padding(3);
            DocumentTab.Size = new Size(792, 424);
            DocumentTab.TabIndex = 1;
            DocumentTab.Text = "Document";
            DocumentTab.UseVisualStyleBackColor = true;
            // 
            // ImageTab
            // 
            ImageTab.Location = new Point(4, 22);
            ImageTab.Name = "ImageTab";
            ImageTab.Padding = new Padding(3);
            ImageTab.Size = new Size(792, 424);
            ImageTab.TabIndex = 2;
            ImageTab.Text = "Image";
            ImageTab.UseVisualStyleBackColor = true;
            // 
            // MusicTab
            // 
            MusicTab.Location = new Point(4, 22);
            MusicTab.Name = "MusicTab";
            MusicTab.Padding = new Padding(3);
            MusicTab.Size = new Size(792, 424);
            MusicTab.TabIndex = 3;
            MusicTab.Text = "Music";
            MusicTab.UseVisualStyleBackColor = true;
            // 
            // StorageTab
            // 
            StorageTab.Location = new Point(4, 22);
            StorageTab.Name = "StorageTab";
            StorageTab.Padding = new Padding(3);
            StorageTab.Size = new Size(792, 424);
            StorageTab.TabIndex = 4;
            StorageTab.Text = "Storage";
            StorageTab.UseVisualStyleBackColor = true;
            // 
            // VideoTab
            // 
            VideoTab.Location = new Point(4, 22);
            VideoTab.Name = "VideoTab";
            VideoTab.Padding = new Padding(3);
            VideoTab.Size = new Size(792, 424);
            VideoTab.TabIndex = 5;
            VideoTab.Text = "Video";
            VideoTab.UseVisualStyleBackColor = true;
            // 
            // BasicPropertiesList
            // 
            BasicPropertiesList.Dock = DockStyle.Fill;
            BasicPropertiesList.FormattingEnabled = true;
            BasicPropertiesList.Location = new Point(3, 3);
            BasicPropertiesList.Name = "BasicPropertiesList";
            BasicPropertiesList.Size = new Size(786, 418);
            BasicPropertiesList.TabIndex = 0;
            // 
            // PropertiesViewerInterface
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PropertiesViewer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PropertiesViewerInterface";
            Text = "PropertiesViewerInterface";
            PropertiesViewer.ResumeLayout(false);
            BasicTab.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal TabControl PropertiesViewer;
        internal TabPage BasicTab;
        internal TabPage DocumentTab;
        internal TabPage ImageTab;
        internal TabPage MusicTab;
        internal TabPage StorageTab;
        internal TabPage VideoTab;
        internal ListBox BasicPropertiesList;
    }
}