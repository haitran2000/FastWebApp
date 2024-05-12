using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class UpCommand : CommandBase
    {        
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        public UpCommand(          
            ICompositeView compositeView,
            IComponentView componentView)
        {
            Name = "Up";
            Icon = Properties.Resources.Up;
            ShortcutKeys = Keys.Control | Keys.Up;
            Level = 2;
           
            this.compositeView = compositeView;
            this.componentView = componentView;
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                UpComposite();
            else
                UpComponent();
        }

        private void UpComposite()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (compositeNode.Level == 0) return;
            var index = compositeNode.Index;
            if (index > 0)
            {
                if (compositeNode.Tag is IComponent component)
                {
                    var parentNode = compositeNode.Parent;
                    var parent = component.Parent;
                    if (parent.Remove(component))
                    {                        
                        compositeNode.Remove();
                        if (parent.Insert(index - 1, component))
                        {
                            this.compositeView.InsertNode(parentNode, index - 1, compositeNode);
                            this.compositeView.SelectedNode = compositeNode;
                        }                                                
                    }
                }
            }
        }

        private void UpComponent()
        {
            var componentItem = this.componentView.SelectedItem;
            if (componentItem is null) return;
            var index = componentItem.Index;
            if (index > 0)
            {
                if (componentItem.Tag is IComponent component)
                {
                    var parent = component.Parent;
                    if (parent.Remove(component))
                    {                        
                        componentItem.Remove();
                        if (parent.Insert(index - 1, component))
                        {
                            this.componentView.InsertItem(index - 1, componentItem);
                            var compositeNode = this.compositeView.Get(index);
                            if(compositeNode?.Tag is IComposite)
                            {
                                compositeNode.Remove();
                                var parentNode = this.compositeView.SelectedNode;
                                this.compositeView.InsertNode(parentNode, index - 1, compositeNode);
                                this.compositeView.SelectedNode = parentNode;
                            }                            
                        }                            
                    }
                }
            }
        }
    }
}
