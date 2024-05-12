using System.Diagnostics;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class ContentCommand : CommandBase
    {
        public ContentCommand()
        {
            Name = "Content";
            Icon = Properties.Resources.Content;
            Enabled = true;
            ShortcutKeys = Keys.F1;
        }

        public override void Execute()
        {            
            Process.Start("http://atscada.com/?s=Fast+Web+Designer");
        }
    }
}
