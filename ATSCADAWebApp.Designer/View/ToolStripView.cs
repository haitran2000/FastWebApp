using ATSCADAWebApp.Designer.Presenter;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public class ToolStripView : ToolStrip, IToolStripView
    {
        public ToolStripPresenter Presenter { get; set; }

        public ToolStripView()
        {
            this.Dock = DockStyle.Bottom;
            this.Items.Add(new ToolStripStatusLabel("Navigation:"));
            this.Items.Add(new ToolStripStatusLabel());
        }

        public void SetNavigation(string navigation)
        {
            this.Items[1].Text = navigation;
        }
    }
}
