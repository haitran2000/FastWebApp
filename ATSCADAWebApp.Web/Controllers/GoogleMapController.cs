using ATSCADAWebApp.Database.Service;
using ATSCADAWebApp.Model.GoogleMap;
using System.Web.Mvc;
using System.Configuration;
using System.Text;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// GoogleMap controller
    /// </summary>
    public class GoogleMapController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Load du lieu lich tu tu dataBase
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LoadDatabase(GoogleMapParam param)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString;
                var service = new GoogleMapService(connectionString);
                var result = service.LoadDatabase(param);
                return new JsonResult()
                {
                    Data = new { Status = true, Result = result },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
            }
            catch
            {
                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}