using ATSCADAWebApp.Database.Service;
using ATSCADAWebApp.Model;
using System.Configuration;
using System.Text;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Report. Load data tu dataBase
    /// </summary>
    public class ReportController : Controller
    {
        /// <summary>
        /// Get alarm report log
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAlarmReportLogs(AlarmReportParam param)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString;
                var service = new AlarmReportService(connectionString);

                var alarmReportLogs = service.GetAlarmReportLogs(param);
                var alarmReport = new AlarmReport()
                {
                    Param = param,
                    AlarmReportLogs = alarmReportLogs
                };

                // De toi uu hieu nang. Du lieu sau khi load, se duoc hien thi len DataTable
                // Dong thoi, du lieu Report se duoc luu vao TempData de phuc vu cho viec xuat Excel\
                // Gan data dua theo ID cua tung AlarmReport
                TempData[$"AlarmReport{param.ID}"] = alarmReport;

                return new JsonResult()
                {
                    Data = new { Status = true, Result = alarmReportLogs },
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
        /// Get dataReport log
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDataReportLogs(DataReportParam param)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString;
                var repository = new DataReportService(connectionString);

                var dataReportLogs = repository.GetDataReportLogs(param, out string[] columnNames);
                var dataReport = new DataReport()
                {
                    ColumnNames = columnNames,
                    Param = param,
                    DataReportLogs = dataReportLogs
                };
                // De toi uu hieu nang. Du lieu sau khi load, se duoc hien thi len DataTable
                // Dong thoi, du lieu Report se duoc luu vao TempData de phuc vu cho viec xuat Excel\
                // Gan data dua theo ID cua tung DataReport
                TempData[$"DataReport{param.ID}"] = dataReport;

                return new JsonResult()
                {
                    Data = new { Status = true, Result = dataReportLogs },
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