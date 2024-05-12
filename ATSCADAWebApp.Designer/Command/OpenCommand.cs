using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class OpenCommand : CommandBase
    {
        private readonly IStorageService storageService;

        public OpenCommand(IStorageService storageService)
        {           
            Level = 0;
            Name = "Open";
            Enabled = true;            
            Icon = Properties.Resources.Open;
            ShortcutKeys = Keys.Control | Keys.O;

            this.storageService = storageService;
        }

        public override void Execute()
        {
            if (!this.storageService.CheckSaved()) return;
            this.storageService.Open();            
        }
    }
}
