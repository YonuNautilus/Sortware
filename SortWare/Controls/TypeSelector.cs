using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SortWare
{
    public partial class TypeSelector
    {

        protected string _allowedExtensions = "";

        public TypeSelector()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

        }
        public void TypeSelect_Load()
        {
            string[] itypes = Generics._imgExtensions.Split(' ');
            string[] vtypes = Generics._vidExtensions.Split(' ');
            string[] misctypes = Generics._miscExtensions.Split(' ');
            foreach (var i in itypes)
                TreeView1.Nodes[0].Nodes.Add(i);
            foreach (var t in vtypes)
                TreeView1.Nodes[1].Nodes.Add(t);
            foreach (var m in misctypes)
                TreeView1.Nodes[2].Nodes.Add(m);
            // TreeView1.ExpandAll()
        }

        public bool isAllowed(string Path)
        {
            string ext = System.IO.Path.GetExtension(Path).ToLower();
            return _allowedExtensions.ToLower().Contains(ext);
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView1.AfterCheck -= TreeView1_AfterSelect;

            foreach (TreeNode node in e.Node.Nodes)
                node.Checked = e.Node.Checked;

            if (e.Node.Checked)
            {
                if (e.Node.Parent is not null)
                {
                    bool allChecked = true;

                    foreach (TreeNode node in e.Node.Parent.Nodes)
                    {
                        if (!node.Checked)
                        {
                            allChecked = false;
                        }
                    }

                    if (allChecked)
                    {
                        e.Node.Parent.Checked = true;
                    }
                }
            }
            else if (e.Node.Parent is not null)
            {
                e.Node.Parent.Checked = false;
            }

            _allowedExtensions = "";
            foreach (TreeNode n in GetCheck(TreeView1.Nodes))
                _allowedExtensions += n.Text.Replace("/", " ") + " ";

            TreeView1.AfterCheck += TreeView1_AfterSelect;
            CheckChanged?.Invoke();
        }

        private List<TreeNode> GetCheck(TreeNodeCollection node)
        {
            var lN = new List<TreeNode>();
            foreach (TreeNode n in node)
            {
                if (n.Checked && n.Tag is null)
                {
                    lN.Add(n);
                }
                lN.AddRange(GetCheck(n.Nodes));
            }

            return lN;
        }

        public event CheckChangedEventHandler CheckChanged;

        public delegate void CheckChangedEventHandler();

        private void TypeSelect_Load(object sender, EventArgs e) => TypeSelect_Load();

    }
}