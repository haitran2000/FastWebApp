using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.View;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class ContextMenuStripPresenter
    {
        private readonly IContextMenuStripView compositeContextView;
        
        private readonly ICommandFactory commandFactory;

        public ContextMenuStripPresenter(
            IContextMenuStripView compositeContextView,
            IComponentView componentView,
            ICompositeView compositeView,
            ICommandFactory commandFactory)
        {
            this.compositeContextView = compositeContextView;         
            this.commandFactory = commandFactory;
            SetCommands();

            this.compositeContextView.Opening += (sender, e) =>
            {
                e.Cancel = compositeView.SelectedNode is null &&
               componentView.SelectedItem is null;
            };
        }

        private void SetCommands()
        {
            this.compositeContextView.Clear();

            var addViewContext = this.compositeContextView.AddMenuItem("Add View...", Properties.Resources.AddView);

            this.compositeContextView.SetCommands(addViewContext,
                this.commandFactory.Get<AddViewCommand>(),
                this.commandFactory.Get<AddHyperlinkViewCommand>()                
                );

            this.compositeContextView.SetCommands(                
                this.commandFactory.Get<AddRowCommand>(),
                this.commandFactory.Get<AddColumnCommand>(),
                this.commandFactory.Get<AddComponentCommand>()                
                );
            this.compositeContextView.AddSeparator();
            this.compositeContextView.SetCommands(
                this.commandFactory.Get<CutCommand>(),
                this.commandFactory.Get<CopyCommand>(),
                this.commandFactory.Get<PasteCommand>(),
                this.commandFactory.Get<DeleteCommand>()
                );
            this.compositeContextView.AddSeparator();
            this.compositeContextView.SetCommands(              
                this.commandFactory.Get<UpdateCommand>()
                );            
        }
    }
}
