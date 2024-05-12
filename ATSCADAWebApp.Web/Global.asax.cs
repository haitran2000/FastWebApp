using ATSCADAWebApp.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ATSCADAWebApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_Error(Object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Oops");
            routeData.Values.Add("exception", exception);

            if(exception is HttpException httpException)
            {
                routeData.Values.Add("statusCode", httpException.GetHttpCode());
            }
            else
            {
                routeData.Values.Add("statusCode", 500);
            }

            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;
            Response.ContentType = "text/html";
            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));            
        }
    }
}
