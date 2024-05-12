using ATSCADAWebApp.Designer.Presenter;

namespace ATSCADAWebApp.Designer.View
{
    public interface IToolStripView
    {
        ToolStripPresenter Presenter { get; set; }

        void SetNavigation(string navigation);
    }
}
