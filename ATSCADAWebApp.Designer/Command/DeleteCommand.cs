using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class DeleteCommand : CommandBase
    {
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        public DeleteCommand(
            ICompositeView compositeView,
            IComponentView componentView)
        {
            Name = "Delete";
            Icon = Properties.Resources.Delete;
            ShortcutKeys = Keys.Delete;
            Level = 2;

            this.compositeView = compositeView;
            this.componentView = componentView;
        }

        public override void Execute()
        {
            if (this.componentView.SelectedItem is null)
                DeleteComposite();
            else
                DeleteComponent();
        }

        private void DeleteComposite()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            if (compositeNode.Tag is IComponent component)
            {
                var dialogResult = MessageBox.Show(
                    $"Are you sure want to delete '{component.Name}'?",
                    "ATSCADA",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (dialogResult != DialogResult.OK) return;

                var parent = component.Parent;
                if (parent.Remove(component))
                {
                    compositeNode.Tag = null;
                    compositeNode.Remove();
                }
            }
        }

        private void DeleteComponent()
        {
            var componentItem = this.componentView.SelectedItem;
            if (componentItem is null) return;
            if (componentItem.Tag is IComponent component)
            {
                var dialogResult = MessageBox.Show(
                    $"Are you sure want to delete '{component.Name}'?",
                    "ATSCADA",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (dialogResult != DialogResult.OK) return;

                var parent = component.Parent;
                if (parent.Remove(component))
                {
                    var index = componentItem.Index;
                    var compositeNode = this.compositeView.Get(index);
                    if (compositeNode != null)
                    {
                        compositeNode.Tag = null;
                        compositeNode.Remove();
                    }

                    componentItem.Tag = null;
                    componentItem.Remove();
                }
            }
        }
    }
}
