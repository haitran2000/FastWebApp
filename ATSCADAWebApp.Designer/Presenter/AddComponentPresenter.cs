using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.View;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class AddComponentPresenter
    {
        private readonly IAddComponentView addComponentView;

        private readonly IComponenService componenService;

        public AddComponentPresenter(
            IAddComponentView addComponentView,
            IComponenService componenService)
        {
            this.addComponentView = addComponentView;
            this.componenService = componenService;

            this.addComponentView.Loaded += () => OnEventLoaded();           
        }

        private void OnEventLoaded()
        {
            this.addComponentView.SetTemplates(
                this.componenService.GetTemplates());
        }       
    }
}
