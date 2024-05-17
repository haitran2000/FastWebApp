using ATSCADAWebApp.Export.Alarm;
using ATSCADAWebApp.Export.Data;
using ATSCADAWebApp.Model.Export;
using ATSCADAWebApp.Model;
using System;
using System.Text;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Runtime.InteropServices;
using OfficeOpenXml;
using GemBox.Spreadsheet;
using Aspose.Cells;

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
                byte[] pdfBytes = Convert.FromBase64String(representation);

                // Lưu mảng byte vào tệp PDF
                
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
        public JsonResult GetDataReportPDF(ExportParam param)
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
                using (MemoryStream stream = new MemoryStream(reportAsByteArray))
                {
                    Workbook workbook = new Workbook(stream);

                    // Đường dẫn tạm thời để lưu tệp Excel
                    string excelTempFilePath = Path.GetTempFileName() + ".xlsx";

                    // Lưu tệp Excel tạm thời
                    workbook.Save(excelTempFilePath, SaveFormat.Xlsx);

                    // Chuyển đổi tệp Excel thành tệp PDF
                    string pdfTempFilePath = excelTempFilePath.Replace(".xlsx", ".pdf");
                    Workbook excelWorkbook = new Workbook(excelTempFilePath);
                    excelWorkbook.Save(pdfTempFilePath, SaveFormat.Pdf);

                    // Trả về tệp PDF cho người dùng để tải xuống
                    byte[] pdfByteArray = System.IO.File.ReadAllBytes(pdfTempFilePath);

                    // Xóa các tệp tạm thời sau khi đã sử dụng xong
                    System.IO.File.Delete(excelTempFilePath);
                    System.IO.File.Delete(pdfTempFilePath);
                    string pdfBase64 = Convert.ToBase64String(pdfByteArray);
                    return new JsonResult()
                    {
                        Data = new { Status = true, Result = pdfBase64 },
                        ContentType = "application/json",
                        ContentEncoding = Encoding.UTF8,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        MaxJsonLength = int.MaxValue
                    };
                    //return Json(new { Status = true, PdfBase64 = pdfBase64 });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }
        public void Test()
        {
            // Load tệp Excel từ đường dẫn
            Workbook workbook = new Workbook("D:\\Data.xlsx");

            // Chuyển đổi sang định dạng PDF
            workbook.Save("D:\\Okila.pdf", SaveFormat.Pdf);

            System.Console.WriteLine("Chuyển đổi thành công từ Excel sang PDF.");
        }
        public ActionResult DownloadPdfFromBase64(string base64String)
        {
            try
            {
                // Giải mã chuỗi base64 thành mảng byte
                byte[] byteArray = Convert.FromBase64String(base64String);

                // Tạo một tệp Excel tạm thời từ mảng byte
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    Workbook workbook = new Workbook(stream);

                    // Đường dẫn tạm thời để lưu tệp Excel
                    string excelTempFilePath = Path.GetTempFileName() + ".xlsx";

                    // Lưu tệp Excel tạm thời
                    workbook.Save(excelTempFilePath, SaveFormat.Xlsx);

                    // Chuyển đổi tệp Excel thành tệp PDF
                    string pdfTempFilePath = excelTempFilePath.Replace(".xlsx", ".pdf");
                    Workbook excelWorkbook = new Workbook(excelTempFilePath);
                    excelWorkbook.Save(pdfTempFilePath, SaveFormat.Pdf);

                    // Trả về tệp PDF cho người dùng để tải xuống
                    byte[] pdfByteArray = System.IO.File.ReadAllBytes(pdfTempFilePath);
                    string pdfFileName = "converted_file.pdf";

                    // Xóa các tệp tạm thời sau khi đã sử dụng xong
                    System.IO.File.Delete(excelTempFilePath);
                    System.IO.File.Delete(pdfTempFilePath);

                    return File(pdfByteArray, "application/pdf", pdfFileName);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return Content("Error: " + ex.Message);
            }
        }
    }
}