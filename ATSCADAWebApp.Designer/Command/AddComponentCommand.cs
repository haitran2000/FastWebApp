using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    /// <summary>
    /// Add cac element (card, chart,...) vao Column
    /// </summary>
    public class AddComponentCommand : CommandBase
    {
        // TreeView
        private readonly ICompositeView compositeView;
        // ListView
        private readonly IComponentView componentView;

        private readonly IComponenService componenService;

        public AddComponentCommand(
            ICompositeView compositeView,
            IComponentView componentView,
            IComponenService componenService)
        {
            Level = 4;
            Name = "New Component";
            Icon = Properties.Resources.AddComponent;
            ShortcutKeys = Keys.Alt | Keys.E;

            this.compositeView = compositeView;
            this.componentView = componentView;
            this.componenService = componenService;
        }

        public override void Execute()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;            
            if (compositeNode.Tag is IComposite composite)
            {
                var addComponentView = new AddComponentView();
                addComponentView.Presenter = new AddComponentPresenter(addComponentView, this.componenService);
                var dialogResult = addComponentView.ShowDialog();
                if (dialogResult != DialogResult.OK) return;

                var component = addComponentView.Component.DeepCopy();
                if (component is null) return;
                if (component.Update())
                {
                    composite.Add(component);
                    var newListViewItem = this.componentView.AddItem(component);
                    this.componentView.SelectedItem = newListViewItem;
                }
            }
            else
            {
                MessageBox.Show(
                    "The object does not support sublist.",
                    "ATSCADA",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
