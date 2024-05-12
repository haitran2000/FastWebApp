using ATSCADAWebApp.Model;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Dieu huong View
    /// </summary>
    public class RoutingController : BaseController
    {
        private const string ERROR_TEMPLATE = null;

        private const string EMPTY_TEMPLATE = null;

        /// <summary>
        /// Tra ve Template cua View
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetView(string location)
        {
            try
            {
                // Lay view tu Repository theo link location
                var view = RootRepository.ViewAccessed?
                    .FirstOrDefault(x => string.Equals(x.Location, location));
                // render template content
                var template = view is null ? EMPTY_TEMPLATE : view.Render();
                return new JsonResult()
                {
                    Data = new { Status = true, Result = template },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
            }
            catch
            {
                return Json(new { Status = false, Result = ERROR_TEMPLATE }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}