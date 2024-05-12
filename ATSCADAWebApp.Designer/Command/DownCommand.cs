using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class DownCommand : CommandBase
    {       
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        public DownCommand(            
            ICompositeView compositeView,
            IComponentView componentView)
        {
            Name = "Down";
            Icon = Properties.Resources.Down;
            ShortcutKeys = Keys.Control | Keys.Down;
            Level = 2;
          
            this.compositeView = compositeView;
            this.componentView = componentView;
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                DownComposite();
            else
                DownComponent();
        }

        private void DownComposite()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (compositeNode.Level == 0) return;
            var index = compositeNode.Index;
            var parentNode = compositeNode.Parent;
            if (index < parentNode.Nodes.Count - 1)
            {
                if (compositeNode.Tag is IComponent component)
                {                    
                    var parent = component.Parent;
                    if (parent.Remove(component))
                    {
                        compositeNode.Remove();
                        if (parent.Insert(index + 1, component))
                        {
                            this.compositeView.InsertNode(parentNode, index + 1, compositeNode);
                            this.compositeView.SelectedNode = compositeNode;
                        }                            
                    }
                }
            }
        }

        private void DownComponent()
        {
            var componentItem = this.componentView.SelectedItem;
            if (componentItem is null) return;
            var index = componentItem.Index;
            if (index < this.componentView.Count - 1)
            {
                if (componentItem.Tag is IComponent component)
                {
                    var parent = component.Parent;
                    if (parent.Remove(component))
                    {
                        
                        componentItem.Remove();
                        if (parent.Insert(index + 1, component))
                        {
                            this.componentView.InsertItem(index + 1, componentItem);
                            var compositeNode = this.compositeView.Get(index);
                            if(compositeNode?.Tag is IComposite)
                            {
                                compositeNode.Remove();
                                var parentNode = this.compositeView.SelectedNode;
                                this.compositeView.InsertNode(parentNode, index + 1, compositeNode);
                                this.compositeView.SelectedNode = parentNode;
                            }                            
                        }                           
                    }
                }
            }
        }
    }
}
