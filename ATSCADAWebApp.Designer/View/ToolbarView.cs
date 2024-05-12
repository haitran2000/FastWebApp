using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public class ToolbarView : ToolStrip, IToolbarView
    {
        public ToolbarPresenter Presenter { get; set; }

        public ToolbarView()
        {
        }

        public ToolStripDropDownButton AddDropDownButton()
        {
            var dropDownButton = new ToolStripDropDownButton();
            dropDownButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.Items.Add(dropDownButton);                      
            return dropDownButton;
        }

        public void SetCommands(params ICommand[] commands)
        {
            foreach (var command in commands)
                SetCommand(command);
        }

        public void SetCommand(ICommand command)
        {
            if (command is null) return;
            var button = new ToolStripButton()
            {
                Text = command.Name,
                Image = command.Icon,
                Enabled = command.Enabled,
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                DisplayStyle = ToolStripItemDisplayStyle.Image
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

        public void SetCommands(ToolStripDropDownButton parent, params ICommand[] commands)
        {
            foreach (var command in commands)
                SetCommand(parent, command);
        }

        public void SetCommand(ToolStripDropDownButton parent, ICommand command)
        {
            if (command is null) return;
            var button = new ToolStripMenuItem()
            {
                Text = command.Name,
                Image = command.Icon,
                Enabled = command.Enabled,
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                AutoSize = true
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
                        parent.Enabled = command.Enabled;
                        button.Enabled = command.Enabled;
                        break;
                    case "Icon":
                        button.Image = command.Icon;
                        break;
                    default:
                        break;
                }
            };
            parent.Enabled = command.Enabled;
            button.Click += (sender, e) => command.Execute();           
            parent.DropDownItems.AddRange(new ToolStripItem[] { button });
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
