using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class ExitCommand : CommandBase
    {        
        public ExitCommand()
        {
            Name = "Exit";
            Icon = Properties.Resources.Exit;
            Enabled = true;
            ShortcutKeys = Keys.Alt | Keys.F4;          
        }

        public override void Execute()
        {            
            Application.Exit();
        }
    }
}
