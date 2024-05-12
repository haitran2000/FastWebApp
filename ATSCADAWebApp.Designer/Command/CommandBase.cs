using ATSCADAWebApp.Core;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public abstract class CommandBase : BindableCore, ICommand
    {
        protected string name;

        protected string description;

        protected bool enabled;

        protected Image icon;

        public int Level { get; protected set; }

        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }

        public string Description
        {
            get => this.description;
            set => SetField(ref this.description, value);
        }

        public bool Enabled
        {
            get => this.enabled;
            set => SetField(ref this.enabled, value);
        }

        public Image Icon
        {
            get => this.icon;
            set => SetField(ref this.icon, value);
        }

        public Keys ShortcutKeys { get; protected set; } = Keys.None;

        protected CommandBase()
        {
            this.enabled = false;
            Level = 0;
        }

        public abstract void Execute();
    }
}
