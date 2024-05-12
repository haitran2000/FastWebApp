using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;


namespace ATSCADAWebApp.Designer.Command
{
    public class SaveCommand : CommandBase
    {
        private readonly IStorageService storageService;
        
        public SaveCommand(IStorageService storageService)
        {          
            Level = 0;
            Name = "Save";
            Icon = Properties.Resources.Save;
            ShortcutKeys = Keys.Control | Keys.S;

            this.storageService = storageService;
        }
        public override void Execute()
        {
            this.storageService.Save();            
        }
    }
}
