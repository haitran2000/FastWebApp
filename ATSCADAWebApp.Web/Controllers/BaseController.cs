using ATSCADAWebApp.Model;
using System.Web;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Controller base
    /// Load project tu file cau hinh
    /// </summary>
    public class BaseController : Controller
    {
        protected string ConfigPath => Server.MapPath("~/AppConfig/ATSCADAWebConfig.xml");

        protected RootRepository RootRepository => RootRepository.Instance;

        protected void LoadApplication(bool forceLoad = false)
        {
            if (forceLoad)             
                if(!RootRepository.Deserialize(ConfigPath))
                    throw new HttpException(501, "Please check the configuration file again");
                    

            if (!RootRepository.Status)
                if (!RootRepository.Deserialize(ConfigPath))
                    throw new HttpException(501, "Please check the configuration file again");
        }
    }
}