using ATSCADAWebApp.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ATSCADAWebApp.Export.Alarm
{
    /// <summary>
    /// Xuat excel cho alarmReport. Su dung Template
    /// Du lieu duoc truy xuat tu database. Fill du lieu vao file excel
    /// </summary>
    public class AlarmReportExporter
    {
        private readonly string templatePath;

        private readonly AlarmReport report;

        public AlarmReportExporter(string templatePath, AlarmReport report)
        {
            this.templatePath = templatePath;
            this.report = report;
        }

        /// <summary>
        /// File excel se duoc xuat ve dang array byte. 
        /// Trinh duyet (client) tao file excel tu du lieu Array
        /// </summary>
        /// <returns></returns>
        public byte[] GetReportAsByArray()
        {
            try
            {
                var fileInfo = new FileInfo(this.templatePath);
                using (var excel = new ExcelPackage(fileInfo))
                {
                    var worksheet = excel.Workbook.Worksheets[1];

                    FillData(worksheet);
                    FormatWorksheet(worksheet);
                    return excel.GetAsByteArray();
                }
            }
            catch
            {
                return default;
            }
        }

        private void FillData(ExcelWorksheet worksheet)
        {
            worksheet.Cells[7, 1].LoadFromArrays(GetData());
        }

        private IEnumerable<object[]> GetData()
        {
            foreach (var alarmReportLog in this.report.AlarmReportLogs)
            {
                yield return new object[8]
                {
                    alarmReportLog.DateTime,
                    alarmReportLog.TagName,
                    alarmReportLog.TagAlias,
                    alarmReportLog.Value,
                    alarmReportLog.HighLevel,
                    alarmReportLog.LowLevel,
                    alarmReportLog.Status,
                    alarmReportLog.ACK
                };
            }
        }

        private void FormatWorksheet(ExcelWorksheet worksheet)
        {
            worksheet.Cells[2, 1].Value = this.report.Param.Content;
            worksheet.Cells[3, 2].Value = this.report.Param.FromDateTime;
            worksheet.Cells[4, 2].Value = this.report.Param.ToDateTime;
            worksheet.Cells[2, 1, 2, 8].Merge = true;
            worksheet.Cells[2, 1, 2, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var range = worksheet.Cells[6, 1, this.report.AlarmReportLogs.Count() + 6, 8];

            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;

            range.Style.Border.BorderAround(ExcelBorderStyle.Double);
            range.AutoFitColumns();
        }
    }
}
