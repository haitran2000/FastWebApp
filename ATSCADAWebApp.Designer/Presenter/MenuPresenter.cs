using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.View;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class MenuPresenter
    {
        private readonly IMenuView menuView;

        private readonly ICommandFactory commandFactory;

        public MenuPresenter(
            IMenuView menuView,
            ICommandFactory commandFactory)
        {
            this.menuView = menuView;
            this.commandFactory = commandFactory;
            SetCommands();
        }

        private void SetCommands()
        {
            this.menuView.Clear();

            var fileMenu = this.menuView.AddMenuItem("File");
            this.menuView.SetCommands(fileMenu, false,
                this.commandFactory.Get<NewCommand>(),
                this.commandFactory.Get<OpenCommand>(),
                this.commandFactory.Get<SaveCommand>(),
                this.commandFactory.Get<SaveAsCommand>());
            this.menuView.AddSeparator(fileMenu);
            this.menuView.SetCommands(fileMenu, false,
               this.commandFactory.Get<QuickCommand>(),
               this.commandFactory.Get<RegisterCommand>());
            this.menuView.AddSeparator(fileMenu);
            this.menuView.SetCommands(fileMenu, false,
                this.commandFactory.Get<ExitCommand>());

            var editMenu = this.menuView.AddMenuItem("Edit");
            var addViewMenu = this.menuView.AddMenuItem(editMenu, "Add View...", Properties.Resources.AddView);

            this.menuView.SetCommands(addViewMenu, true,
                this.commandFactory.Get<AddViewCommand>(),
                this.commandFactory.Get<AddHyperlinkViewCommand>());

            this.menuView.SetCommands(editMenu, false,
                this.commandFactory.Get<AddRowCommand>(),
                this.commandFactory.Get<AddColumnCommand>(),
                this.commandFactory.Get<AddComponentCommand>());

            this.menuView.AddSeparator(editMenu);
            this.menuView.SetCommands(editMenu, false,
                this.commandFactory.Get<CutCommand>(),
                this.commandFactory.Get<CopyCommand>(),
                this.commandFactory.Get<PasteCommand>(),
                this.commandFactory.Get<EscapeCommand>(),
                this.commandFactory.Get<DeleteCommand>());
            this.menuView.AddSeparator(editMenu);
            this.menuView.SetCommands(editMenu, false,
                this.commandFactory.Get<UpCommand>(),
                this.commandFactory.Get<DownCommand>(),
                this.commandFactory.Get<UpdateCommand>());


            var helpMenu = this.menuView.AddMenuItem("Help");
            this.menuView.SetCommands(helpMenu, false,
                this.commandFactory.Get<ContentCommand>(),
                this.commandFactory.Get<AboutCommand>());
        }
    }
}
