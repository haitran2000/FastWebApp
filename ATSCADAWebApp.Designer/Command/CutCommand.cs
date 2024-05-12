using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class CutCommand : CommandBase
    {
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        private readonly IClipboardService clipboardService;

        public CutCommand(
            ICompositeView compositeView,
            IComponentView componentView,
            IClipboardService clipboardService)
        {            
            Name = "Cut";
            Icon = Properties.Resources.Cut;
            ShortcutKeys = Keys.Control | Keys.X;
            Level = 2;

            this.compositeView = compositeView;
            this.componentView = componentView;
            this.clipboardService = clipboardService;
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                CutComposite();
            else
                CutComponent();
        }

        private void CutComposite()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (compositeNode.Tag is IComponent component)
            {
                var parent = component.Parent;
                if (parent.Remove(component))
                {
                    compositeNode.Tag = null;
                    compositeNode.Remove();

                    this.clipboardService.SetToClipboard(ClipboardAction.Cut, component);
                }                
            }
        }

        private void CutComponent()
        {
            var componentItem = this.componentView.SelectedItem;
            if (componentItem is null) return;
            if (componentItem.Tag is IComponent component)
            {
                var parent = component.Parent;
                if (parent.Remove(component))
                {
                    var index = componentItem.Index;
                    var compositeNode = this.compositeView.Get(index);
                    compositeNode.Tag = null;
                    compositeNode.Remove();

                    componentItem.Tag = null;
                    componentItem.Remove();

                    this.clipboardService.SetToClipboard(ClipboardAction.Cut, component);
                }              
                
            }
        }
    }
}
