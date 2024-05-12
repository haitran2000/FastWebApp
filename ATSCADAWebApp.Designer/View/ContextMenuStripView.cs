using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public class ContextMenuStripView : ContextMenuStrip, IContextMenuStripView
    {
        public ContextMenuStripPresenter Presenter { get; set; }

        public ContextMenuStripView()
        {
        }

        public ToolStripMenuItem AddMenuItem(string name, Image image)
        {
            var menuItem = new ToolStripMenuItem(name);
            menuItem.Image = image;
            this.Items.Add(menuItem);
            return menuItem;
        }

        public void SetCommands(params ICommand[] commands)
        {
            foreach (var command in commands)
                SetCommand(command);
        }

        public void SetCommand(ICommand command)
        {
            if (command is null) return;
            var button = new ToolStripMenuItem()
            {
                Text = command.Name,
                Image = command.Icon,
                Enabled = command.Enabled,
                ShortcutKeys = command.ShortcutKeys,
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            };
            command.PropertyChanged += (sender, e) =>
            {
                string propertyName = e.PropertyName;
                switch (propertyName)
                {
                    case "Name":
                        button.Text = command.Name;
                        break;
                    case "Enabled":
                        button.Enabled = command.Enabled;
                        break;
                    case "Icon":
                        button.Image = command.Icon;
                        break;
                    default:
                        break;
                }
            };
            button.Click += (sender, e) => command.Execute();
            this.Items.Add(button);
        }

        public void SetCommands(ToolStripMenuItem parent, params ICommand[] commands)
        {
            foreach (var command in commands)
                SetCommand(parent, command);
        }

        public void SetCommand(ToolStripMenuItem parent, ICommand command)
        {
            if (command is null) return;
            var button = new ToolStripMenuItem()
            {
                Text = command.Name,
                Image = command.Icon,
                Enabled = command.Enabled,
                ShortcutKeys = command.ShortcutKeys,
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            };
            command.PropertyChanged += (sender, e) =>
            {
                string propertyName = e.PropertyName;
                switch (propertyName)
                {
                    case "Name":
                        button.Text = command.Name;
                        break;
                    case "Enabled":
                        button.Enabled = command.Enabled;
                        break;
                    case "Icon":
                        button.Image = command.Icon;
                        break;
                    default:
                        break;
                }
            };
            button.Click += (sender, e) => command.Execute();
            parent.DropDownItems.Add(button);
        }

        public void AddSeparator()
        {
            var separator = new ToolStripSeparator();
            this.Items.Add(separator);
        }

        public void Clear()
        {
            this.Items.Clear();
        }
    }
}
