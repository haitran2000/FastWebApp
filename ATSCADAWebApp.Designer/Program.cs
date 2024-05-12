using ATSCADAWebApp.Component;
using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Designer.View;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer
{
    static class Program
    {       
        [STAThread]
        static void Main()
        {           
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var startupLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var serializer = new CompositeSerializer<ATSCADAApp>();
            var storageService = new StorageService(startupLocation, serializer);
            var componentService = new ComponentService().Load();
            var clipboardService = new ClipboardService();

            var menuView = new MenuView();
            var toolbarView = new ToolbarView();
            var toolStripView = new ToolStripView();
            var contextMenuStripView = new ContextMenuStripView();            
            var compositeView = new CompositeView();            
            var componentView = new ComponentView();           
            var mainView = new MainView(menuView, toolbarView, toolStripView, compositeView, componentView, storageService);
            
            var commandFactory = new CommandFactory();
            commandFactory.Register(
                new NewCommand(storageService),
                new OpenCommand(storageService),
                new SaveCommand(storageService),
                new SaveAsCommand(storageService),
                new QuickCommand(storageService, componentService),
                new RegisterCommand(storageService),
                new ExitCommand(),
                new AddViewCommand(compositeView, componentView),
                new AddHyperlinkViewCommand(compositeView, componentView),
                new AddRowCommand(compositeView, componentView),
                new AddColumnCommand(compositeView, componentView),
                new AddComponentCommand(compositeView, componentView, componentService),
                new CutCommand(compositeView, componentView, clipboardService),
                new CopyCommand(compositeView, componentView, clipboardService),
                new PasteCommand(compositeView, componentView, clipboardService),
                new EscapeCommand(clipboardService),
                new DeleteCommand(compositeView, componentView),
                new UpCommand(compositeView, componentView),
                new DownCommand(compositeView, componentView),
                new UpdateCommand(compositeView, componentView, storageService),                
                new ContentCommand(),
                new AboutCommand()
                );

            menuView.Presenter = new MenuPresenter(menuView, commandFactory);
            toolbarView.Presenter = new ToolbarPresenter(toolbarView, commandFactory);
            toolStripView.Presenter = new ToolStripPresenter(toolStripView, compositeView, componentView);
            contextMenuStripView.Presenter = new ContextMenuStripPresenter(contextMenuStripView, componentView, compositeView, commandFactory);
            compositeView.Presenter = new CompositePresenter(compositeView, componentView, commandFactory, storageService);            
            componentView.Presenter = new ComponentPresenter(componentView, compositeView, commandFactory);           
            mainView.Presenter = new MainPresenter(mainView);

            compositeView.ContextMenuStrip = contextMenuStripView;
            componentView.ContextMenuStrip = contextMenuStripView;

            Application.Run(mainView);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message = string.Format("Sorry, something went wrong.\r\n" +
                "{0}\r\n" +
                "Please contact ATSCADA Lab to support.",
                ((Exception)e.ExceptionObject).Message);
            MessageBox.Show(message, "ATSCADA - Unexpected Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = string.Format("Sorry, something went wrong.\r\n" +
              "{0}\r\n" +
              "Please contact ATSCADA Lab to support.",
                e.Exception.Message);

            MessageBox.Show(message, "ATSCADA - Unexpected Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
    }
}
