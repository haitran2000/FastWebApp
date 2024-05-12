using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.View;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class ToolbarPresenter
    {
        private readonly IToolbarView toolbarView;

        private readonly ICommandFactory commandFactory;       

        public ToolbarPresenter(
            IToolbarView toolbarView,
            ICommandFactory commandFactory)
        {
            this.toolbarView = toolbarView;
            this.commandFactory = commandFactory;
            SetCommands();
        }

        private void SetCommands()
        {
            this.toolbarView.Clear();

            this.toolbarView.SetCommands(
                this.commandFactory.Get<NewCommand>(),
                this.commandFactory.Get<OpenCommand>(),
                this.commandFactory.Get<SaveCommand>(),
                this.commandFactory.Get<SaveAsCommand>()                
                );
            this.toolbarView.AddSeparator();
            this.toolbarView.SetCommands(                
                this.commandFactory.Get<QuickCommand>(),
                this.commandFactory.Get<RegisterCommand>()
                );
            this.toolbarView.AddSeparator();

            var addViewDropDown = this.toolbarView.AddDropDownButton();
            addViewDropDown.Image = Properties.Resources.AddView;
            this.toolbarView.SetCommands(addViewDropDown,
                this.commandFactory.Get<AddViewCommand>(),
                this.commandFactory.Get<AddHyperlinkViewCommand>()                         
                );
            this.toolbarView.SetCommands(                
                this.commandFactory.Get<AddRowCommand>(),
                this.commandFactory.Get<AddColumnCommand>(),
                this.commandFactory.Get<AddComponentCommand>()
                );
            this.toolbarView.AddSeparator();
            this.toolbarView.SetCommands(
                this.commandFactory.Get<CutCommand>(),
                this.commandFactory.Get<CopyCommand>(),
                this.commandFactory.Get<PasteCommand>(),
                this.commandFactory.Get<EscapeCommand>(),
                this.commandFactory.Get<DeleteCommand>()
                );
            this.toolbarView.AddSeparator();
            this.toolbarView.SetCommands(
                this.commandFactory.Get<UpCommand>(),
                this.commandFactory.Get<DownCommand>(),
                this.commandFactory.Get<UpdateCommand>()               
                );            
        }
    }
}
