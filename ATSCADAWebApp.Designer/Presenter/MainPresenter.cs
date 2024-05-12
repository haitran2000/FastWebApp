using ATSCADAWebApp.Designer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView mainView;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
        }
    }
}
