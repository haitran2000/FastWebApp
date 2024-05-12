using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class PasteCommand : CommandBase
    {
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        private readonly IClipboardService clipboardService;

        public PasteCommand(
            ICompositeView compositeView,
            IComponentView componentView,
            IClipboardService clipboardService)
        {
            Name = "Paste";
            Icon = Properties.Resources.Paste;
            ShortcutKeys = Keys.Control | Keys.V;
            Level = -1;
            Enabled = false;

            this.compositeView = compositeView;
            this.componentView = componentView;
            this.clipboardService = clipboardService;

            this.clipboardService.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Source")
                    Enabled = this.clipboardService.ContainsData;
            };
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                PasteComposite();
            else
                PasteComponent();
        }

        private void PasteComposite()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (!this.clipboardService.ContainsData) return;

            var componentFromClipboard = this.clipboardService.GetFromClipboard();
            if(compositeNode.Level != (int)componentFromClipboard.Level &&
                compositeNode.Level != (int)componentFromClipboard.Level -1) return;

            while (compositeNode.Level > (int)componentFromClipboard.Level - 1)
            {
                compositeNode = compositeNode.Parent;
                if (compositeNode is null) return;
            }            
            if (compositeNode.Tag is IComposite composite)
            {
                if (composite.Add(componentFromClipboard))
                {
                    if (compositeNode.Level == this.compositeView.SelectedNode.Level)
                        this.componentView.AddItem(componentFromClipboard);
                    this.compositeView.AddNode(compositeNode, componentFromClipboard as IComponent);
                }                   
            }
            else
            {
                MessageBox.Show(
                    "The object does not support paste sublist.",
                    "ATSCADA",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
            }
        }

        private void PasteComponent()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (!this.clipboardService.ContainsData) return;

            var componentFromClipboard = this.clipboardService.GetFromClipboard();
            if (componentFromClipboard.Level != ComponentLevel.Component) return;

            if (compositeNode.Tag is IComposite composite)
            {
                if (composite.Level == ComponentLevel.Column)
                {              
                    if (composite.Add(componentFromClipboard))
                    {
                        this.componentView.AddItem(componentFromClipboard);
                        this.compositeView.AddNode(compositeNode, componentFromClipboard as IComposite);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "The object does not support paste sublist.",
                    "ATSCADA",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
