using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Designer.View;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class CompositePresenter
    {
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        private readonly ICommandFactory commandFactory;

        private readonly ICommand updateCommands;

        public CompositePresenter(
            ICompositeView compositeView,
            IComponentView componentView,
            ICommandFactory commandFactory,
            IStorageService storageService)
        {
            this.compositeView = compositeView;
            this.componentView = componentView;
            this.commandFactory = commandFactory;

            this.updateCommands = commandFactory.Get<UpdateCommand>();
            this.compositeView.AfterSelected += (node) => BindEnable(node.Level);
            this.compositeView.DoubleClicked += (node) => Update();
            storageService.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Composite")
                    LoadView(storageService.Composite);
            };
        }

        public void Update()
        {
            if (this.compositeView.SelectedNode is null) return;
            this.updateCommands.Execute();
            this.compositeView.SelectedNode.Expand();
        }

        private void BindEnable(int level)
        {
            foreach (var command in this.commandFactory.GetAll())
            {
                if (command.Level > -1)
                    command.Enabled = command.Level < level + 2;
            }
        }

        private void LoadView(IComposite composite)
        {
            this.compositeView.Clear();
            this.componentView.Clear();
            if (composite is null) return;
            
            var appNode = this.compositeView.AddRoot(composite);
            this.compositeView.SelectedNode = appNode;
            this.compositeView.ExpandAll();           
        }
    }
}
