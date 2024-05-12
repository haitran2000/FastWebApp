using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class UpdateCommand : CommandBase
    {
        private readonly IStorageService storageService;

        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        public UpdateCommand(           
            ICompositeView compositeView,
            IComponentView componentView,
            IStorageService storageService)
        {
            Name = "Update";
            Icon = Properties.Resources.Update;
            ShortcutKeys = Keys.Control | Keys.U;

            this.storageService = storageService;
            this.compositeView = compositeView;
            this.componentView = componentView;
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                UpdateComposite();
            else
                UpdateComponent();
        }

        private void UpdateComposite()
        {
            var selectedNode = this.compositeView.SelectedNode;
            if (selectedNode is null) return;            
            if (selectedNode.Tag is IComponent component)
            {
                if (component.Update())
                {
                    if (this.storageService.RequestSaved)
                    {
                        this.compositeView.UpdateView(selectedNode);
                        var componentItem = this.componentView.Get(selectedNode.Index);
                        if(componentItem?.Tag is IComposite)
                        {
                            this.componentView.UpdateView(componentItem);
                        }                                                              
                    }                        
                }
            }
        }

        private void UpdateComponent()
        {
            var selectedItem = this.componentView.SelectedItem;
            if (selectedItem is null) return;
            if (selectedItem.Tag is IComponent component)
            {
                if (component.Update())
                {
                    if (this.storageService.RequestSaved)
                    {
                        this.componentView.UpdateView(selectedItem);
                        var compositeNode = this.compositeView.Get(selectedItem.Index);
                        if (compositeNode?.Tag is IComposite)
                        {
                            this.compositeView.UpdateView(compositeNode);
                        }                        
                    }                        
                }
            }
        }
    }
}
