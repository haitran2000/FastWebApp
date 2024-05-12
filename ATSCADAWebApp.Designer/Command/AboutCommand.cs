using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    /// <summary>
    /// Show thong tin ve phan mem
    /// </summary>
    public class AboutCommand : CommandBase
    {
        public AboutCommand()
        {
            Name = "About";
            Icon = Properties.Resources.About;
            Enabled = true;
            ShortcutKeys = Keys.F2;
        }

        public override void Execute()
        {
            new AboutView().ShowDialog();
        }
    }
}
