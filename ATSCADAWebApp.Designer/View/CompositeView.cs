using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public class CompositeView : TreeView, ICompositeView
    {
        private string navigation;

        public event Action<TreeNode> AfterSelected;

        public event Action<TreeNode> Clicked;

        public event Action<TreeNode> DoubleClicked;

        public event Action<string> NavigationChanged;

        public CompositePresenter Presenter { get; set; }

        public CompositeView()
        {
            this.Dock = DockStyle.Fill;
            this.ImageList = new ImageList();
            this.ImageList.Images.AddRange(new Image[6]
            {
                Properties.Resources.App,
                Properties.Resources.View,
                Properties.Resources.Row,
                Properties.Resources.Column,
                Properties.Resources.Component,
                Properties.Resources.Selected
            });
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            this.AfterSelect += (sender, e) => OnEventAfterSelect(e);
            this.NodeMouseClick += (sender, e) => OnEventNodeMouseClick(e);
            this.NodeMouseDoubleClick += (sender, e) => OnEventNodeMouseDoubleClick(e);
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        public int IndexOf(TreeNode treeNode) => this.Nodes.IndexOf(treeNode);

        public TreeNode Get(int index)
        {
            if (this.SelectedNode is null) return default;
            if (index > this.SelectedNode.Nodes.Count - 1) return default;
            return this.SelectedNode.Nodes[index];
        }

        public TreeNode AddRoot(IComponent component)
        {
            if (component is null) return default;
            var node = new TreeNode(component.Name);
            node.Tag = component;
            node.ImageIndex = (int)component.Level;
            node.SelectedImageIndex = 5;
            if ((int)component.Level < 3)
                if (component is IComposite composite)
                    foreach (var child in composite.Components)                        
                        AddNode(node, child);
            this.Nodes.Add(node);
            return node;
        }

        public TreeNode AddNode(TreeNode parent, IComponent component)
        {
            if (parent is null || component is null) return default;
            var node = new TreeNode(component.Name);
            node.Tag = component;
            node.ImageIndex = (int)component.Level;
            node.SelectedImageIndex = 5;
            if ((int)component.Level < 3)
                if (component is IComposite composite)
                    foreach (var child in composite.Components)
                        AddNode(node, child);
            parent.Nodes.Add(node);
            return node;
        }

        public void InsertNode(TreeNode parent, int index, TreeNode node)
        {
            parent.Nodes.Insert(index, node);
        }

        public void UpdateView(TreeNode node)
        {
            if (node.Tag is IComponent composite)
            {
                node.Text = composite.Name;
                UpdateNavigation();
            }
        }

        public void Clear()
        {
            this.Nodes.Clear();
            UpdateNavigation();
        }

        private void OnEventAfterSelect(TreeViewEventArgs e)
        {
            AfterSelected?.Invoke(e.Node);
            UpdateNavigation();
        }

        private void OnEventNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.SelectedNode = e.Node;
            Clicked?.Invoke(e.Node);
        }

        private void OnEventNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            DoubleClicked?.Invoke(e.Node);
        }

        private void UpdateNavigation()
        {
            var compositeNode = SelectedNode;
            var navigation = string.Empty;
            if (compositeNode != null)
            {
                navigation = compositeNode.Text;
                while (compositeNode.Level > 0)
                {
                    compositeNode = compositeNode.Parent;
                    if (compositeNode is null) return;
                    navigation = $"{compositeNode.Text}/{navigation}";
                }
            }

            if (string.Equals(this.navigation, navigation)) return;
            this.navigation = navigation;
            NavigationChanged?.Invoke(this.navigation);
        }
    }
}
