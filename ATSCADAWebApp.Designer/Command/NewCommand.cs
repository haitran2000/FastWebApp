using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class NewCommand : CommandBase
    {
        private readonly IStorageService storageService;
      
        public NewCommand(IStorageService storageService)
        {            
            Level = 0;
            Name = "New";
            Enabled = true;            
            Icon = Properties.Resources.New;
            ShortcutKeys = Keys.Control | Keys.N;

            this.storageService = storageService;
        }

        public override void Execute()
        {
            if (this.storageService.RequestSaved)
            {
                var dialogResult = MessageBox.Show(
                    "The working project file is not saved. Do you want to save now?",
                    "ATSCADA",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Cancel) return;
                if (dialogResult == DialogResult.Yes) this.storageService.Save();
            }
            this.storageService.New();           
        }
    }
}
