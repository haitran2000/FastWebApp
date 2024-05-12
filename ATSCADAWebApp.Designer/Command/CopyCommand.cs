using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class CopyCommand : CommandBase
    {
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        private readonly IClipboardService clipboardService; 

        public CopyCommand(
            ICompositeView compositeView,
            IComponentView componentView,
            IClipboardService clipboardService)
        {            
            Name = "Copy";
            Icon = Properties.Resources.Copy;
            ShortcutKeys = Keys.Control | Keys.C;
            Level = 2;

            this.compositeView = compositeView;
            this.componentView = componentView;
            this.clipboardService = clipboardService;
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                CopyComposite();
            else
                CopyComponent();
        }

        private void CopyComposite()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (compositeNode.Tag is IComponent component)
            {
                var source = component.DeepCopy();                
                this.clipboardService.SetToClipboard(ClipboardAction.Copy, source);
            }
        }

        private void CopyComponent()
        {
            var componentItem = this.componentView.SelectedItem;
            if (componentItem is null) return;
            if (componentItem.Tag is IComponent component)
            {
                var source = component.DeepCopy();             
                this.clipboardService.SetToClipboard(ClipboardAction.Copy, source);
            }
        }
    }
}
