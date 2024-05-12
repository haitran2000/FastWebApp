using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class EscapeCommand : CommandBase
    {
        private readonly IClipboardService clipboardService;

        public EscapeCommand(           
            IClipboardService clipboardService)
        {
            Name = "Escape";
            Icon = Properties.Resources.Escape;
            ShortcutKeys = Keys.Control | Keys.E;
            Level = 0;

            this.clipboardService = clipboardService;
        }

        public override void Execute()
        {
            this.clipboardService.Clear();
        }
    }
}
