using ATSCADAWebApp.Database.Service;
using ATSCADAWebApp.Model;
using System.Configuration;
using System.Text;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Load du lieu alarmLog. Cung cap data cho alarmViewer
    /// </summary>
    public class AlarmController : Controller
    {       
        /// <summary>
        /// Get alarm record
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAlarms(AlarmParam param)
        {
            try
            {         
                // Chuoi connectionString ket noi MySql
                var connectionString = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString;
                var service = new AlarmService(connectionString);

                var alarmLogs = service.GetAlarms(param);                         
                return new JsonResult()
                {
                    Data = new { Status = true, Result = alarmLogs },
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

        /// <summary>
        /// Xac nhan ACK
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Acknowledge(AlarmAcknowledgeParam param)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString;
                var service = new AlarmService(connectionString);

                var result = service.Acknowledge(param);
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