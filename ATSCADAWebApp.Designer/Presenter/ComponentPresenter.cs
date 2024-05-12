using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class ComponentPresenter
    {
        private readonly IComponentView componentView;

        private readonly ICompositeView compositeView;

        private readonly ICommand updateCommand;

        public ComponentPresenter(
            IComponentView componentView,
            ICompositeView compositeView,
            ICommandFactory commandFactory)
        {
            this.componentView = componentView;
            this.compositeView = compositeView;
            this.updateCommand = commandFactory.Get<UpdateCommand>();

            this.compositeView.AfterSelected += (node) => OnEventCompositeViewAfterSelected(node);
            this.compositeView.Clicked += (node) => OnEventCompositeViewClicked(node);
            this.componentView.DoubleClicked += () => Update();
        }

        private void OnEventCompositeViewAfterSelected(TreeNode node)
        {
            if (node is null) return;
            this.componentView.Clear();
            if (node.Tag is IComposite composite)
                this.componentView.AddItems(composite.Components);
        }
        
        private void OnEventCompositeViewClicked(TreeNode node)
        {           
            if (node?.Tag is IComposite)
            {               
                this.componentView.RemoveSelection();  
            }
        }                 
        
        private void Update()
        {
            if (this.componentView.SelectedItem is null) return;
            this.updateCommand?.Execute();
        }
    }
}
