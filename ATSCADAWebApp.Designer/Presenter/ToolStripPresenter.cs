using ATSCADAWebApp.Designer.View;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class ToolStripPresenter
    {
        private string compositeNavigation;

        private string componentNavigation;

        private IToolStripView toolStripView;

        public ToolStripPresenter(
            IToolStripView toolStripView,
            ICompositeView compositeView,
            IComponentView componentView)
        {
            this.toolStripView = toolStripView;

            compositeView.NavigationChanged += (navigation) => OnEventCompositeNavigationChanged(navigation);
            componentView.NavigationChanged += (navigation) => OnEventComponentNavigationChanged(navigation);
        }
        
        private void OnEventCompositeNavigationChanged(string navigation)
        {
            this.compositeNavigation = navigation;
            this.toolStripView.SetNavigation(
                $"{this.compositeNavigation}" +
                $"{this.componentNavigation}");
        }

        private void OnEventComponentNavigationChanged(string navigation)
        {
            this.componentNavigation = navigation;
            this.toolStripView.SetNavigation(
                $"{this.compositeNavigation}" +
                $"{this.componentNavigation}");
        }

    }
}
