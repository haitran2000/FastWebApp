using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public interface IToolbarView
    {
        ToolbarPresenter Presenter { get; set; }

        ToolStripDropDownButton AddDropDownButton();

        void SetCommands(params ICommand[] command);

        void SetCommand(ICommand command);

        void SetCommands(ToolStripDropDownButton parent, params ICommand[] command);

        void SetCommand(ToolStripDropDownButton parent, ICommand command);

        void AddSeparator();

        void Clear();
       
    }
}
