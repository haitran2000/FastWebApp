using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public interface IMenuView
    {
        MenuPresenter Presenter { get; set; }

        ToolStripMenuItem AddMenuItem(string name, Image image = null);

        ToolStripMenuItem AddMenuItem(ToolStripMenuItem parent, string name, Image image = null);

        void SetCommands(ToolStripMenuItem parent, bool enable, params ICommand[] commands);

        void SetCommand(ToolStripMenuItem parent, bool enable, ICommand command);        

        void AddSeparator(ToolStripMenuItem parent);     

        void Clear();
    }
}
