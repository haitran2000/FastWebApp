using ATSCADAWebApp.Export.Alarm;
using ATSCADAWebApp.Export.Data;
using ATSCADAWebApp.Model.Export;
using ATSCADAWebApp.Model;
using System;
using System.Text;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Quan ly export excel
    /// </summary>
    public class ExportController : Controller
    {
        /// <summary>
        /// Xuat excel alarm
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAlarmReport(ExportParam param)
        {
            try
            {       
                // Du lieu se duoc lay o TempData (duoc luu khi report - hien thi DataTable)
                var alarmReport = (AlarmReport)(TempData.Peek($"AlarmReport{param.ID}"));
                if (alarmReport is null)
                    return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

                var templatePath = Server.MapPath("~/ReportTemplate/AlarmReport.xlsx");              
                var reportAsByteArray = new AlarmReportExporter(templatePath, alarmReport).GetReportAsByArray();
                // Du lieu tra ve dang Base64String
                // Trinh duyet (Client) se tw xuat, tao ra flie .xlsx
                var representation = Convert.ToBase64String(reportAsByteArray, 0, reportAsByteArray.Length);

                return new JsonResult()
                {
                    Data = new { Status = true, Result = representation },
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
        /// Xuat excel data
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDataReport(ExportParam param)
        {
            try
            {
                // Du lieu se duoc lay o TempData (duoc luu khi report - hien thi DataTable)
                var dataReport = (DataReport)(TempData.Peek($"DataReport{param.ID}"));
                if (dataReport is null)
                    return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

                var templatePath = Server.MapPath("~/ReportTemplate/DataReport.xlsx");
                var reportAsByteArray = new DataReportExporter(templatePath, dataReport).GetReportAsByArray();
                // Du lieu tra ve dang Base64String
                // Trinh duyet (Client) se tw xuat, tao ra flie .xlsx
                var representation = Convert.ToBase64String(reportAsByteArray, 0, reportAsByteArray.Length);

                return new JsonResult()
                {
                    Data = new { Status = true, Result = representation },
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