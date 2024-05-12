using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class RegisterCommand : CommandBase
    {
        private readonly IStorageService storageService;

        public RegisterCommand(IStorageService storageService)
        {
            Level = 0;
            Name = "Register";
            Icon = Properties.Resources.Register;
            ShortcutKeys = Keys.Control | Keys.R;

            this.storageService = storageService;
        }

        public override void Execute()
        {
            if (!this.storageService.CheckSaved()) return;
            var dialogResultRegister = MessageBox.Show(
                "Are you sure to register project file?",
                "ATSCADA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResultRegister == DialogResult.No) return;
            this.storageService.Register();
        }
    }
}
