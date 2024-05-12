using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using System;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public interface ICompositeView
    {
        event Action<TreeNode> AfterSelected;

        event Action<TreeNode> Clicked;

        event Action<TreeNode> DoubleClicked;

        event Action<string> NavigationChanged;

        CompositePresenter Presenter { get; set; }      
        
        TreeNode SelectedNode { get; set; }

        int IndexOf(TreeNode treeNode);

        TreeNode Get(int index);
      
        TreeNode AddRoot(IComponent component);

        TreeNode AddNode(TreeNode parent, IComponent component);

        void InsertNode(TreeNode parent, int index, TreeNode node);

        void UpdateView(TreeNode node);

        void Clear();

        void ExpandAll();
    }
}
