using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public interface IContextMenuStripView
    {
        event CancelEventHandler Opening;

        ContextMenuStripPresenter Presenter { get; set; }

        ToolStripMenuItem AddMenuItem(string name, Image image);

        void SetCommands(params ICommand[] command);

        void SetCommand(ICommand command);

        void SetCommands(ToolStripMenuItem parent, params ICommand[] commands);

        void SetCommand(ToolStripMenuItem parent, ICommand command);

        void AddSeparator();

        void Clear();
    }
}
