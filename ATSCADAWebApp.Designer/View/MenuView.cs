using ATSCADAWebApp.Designer.Command;
using ATSCADAWebApp.Designer.Presenter;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public class MenuView : MenuStrip, IMenuView
    {
        public MenuPresenter Presenter { get; set; }

        public MenuView()
        {           
        }

        public ToolStripMenuItem AddMenuItem(string name, Image image = null)
        {
            var menuItem = new ToolStripMenuItem(name);
            menuItem.Image = image;
            this.Items.Add(menuItem);
            return menuItem;
        }

        public ToolStripMenuItem AddMenuItem(ToolStripMenuItem parent, string name, Image image = null)
        {
            var menuItem = new ToolStripMenuItem(name);
            menuItem.Image = image;
            parent.DropDownItems.AddRange(new ToolStripItem[] { menuItem });            
            return menuItem;
        }

        public void SetCommands(ToolStripMenuItem parent, bool enable, params ICommand[] commands)
        {
            foreach (var command in commands)
                SetCommand(parent, enable, command);
        }       

        public void SetCommand(ToolStripMenuItem parent, bool enable, ICommand command)
        {
            if (command is null) return;
            var menuItem = new ToolStripMenuItem()
            {
                Text = command.Name,
                Image = command.Icon,
                Enabled = command.Enabled,
                ShortcutKeys = command.ShortcutKeys,
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                AutoSize = true
            };          
            command.PropertyChanged += (sender, e) =>
            {
                string propertyName = e.PropertyName;
                switch (propertyName)
                {
                    case "Name":
                        menuItem.Text = command.Name;
                        break;
                    case "Enabled":
                        if (enable) parent.Enabled = command.Enabled;
                        menuItem.Enabled = command.Enabled;
                        break;
                    case "Icon":
                        menuItem.Image = command.Icon;
                        break;
                    default:
                        break;
                }                
            };
            if (enable) parent.Enabled = command.Enabled;
            menuItem.Click += (sender, e) => command.Execute();
            parent?.DropDownItems.Add(menuItem);
        }
       
        public void AddSeparator(ToolStripMenuItem parent)
        {
            var separator = new ToolStripSeparator();
            parent.DropDownItems.Add(separator);
        }             

        public void Clear()
        {
            this.Items.Clear();
        }     
    }
}
