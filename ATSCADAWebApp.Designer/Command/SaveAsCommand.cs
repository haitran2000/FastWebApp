using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class SaveAsCommand : CommandBase
    {
        private readonly IStorageService storageService;

        public SaveAsCommand(IStorageService storageService)
        {           
            Level = 0;
            Name = "Save As";
            Icon = Properties.Resources.SaveAs;
            ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

            this.storageService = storageService;
        }

        public override void Execute()
        {
            this.storageService.SaveAs();            
        }
    }
}
