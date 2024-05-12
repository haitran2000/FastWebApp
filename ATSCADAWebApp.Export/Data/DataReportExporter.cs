using ATSCADAWebApp.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATSCADAWebApp.Extension.Method;
using OfficeOpenXml.Drawing.Chart;

namespace ATSCADAWebApp.Export.Data
{
    /// <summary>
    /// Xuat excel cho dataReport
    /// Du lieu duoc truy xuat tu database. Fill du lieu vao file excel
    /// </summary>
    public class DataReportExporter
    {
        private readonly string templatePath;

        private readonly DataReport dataReport;

        public readonly int itemCount;

        private readonly string[] columnNames;

        private int rowDataCount;

        public DataReportExporter(string templatePath, DataReport report)
        {
            this.templatePath = templatePath;
            this.dataReport = report;
            this.itemCount = report.ColumnNames.Length - 1;
            this.columnNames = this.dataReport.ColumnNames
                .Where(x => !string.Equals(x, "DateTime"))
                .ToArray();
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
                    var dataSheet = excel.Workbook.Worksheets["Data"];
                    var chartSheet = excel.Workbook.Worksheets["Chart"];

                    FillDataSheet(dataSheet);
                    FormatDataSheet(dataSheet);
                    DrawChart(dataSheet, chartSheet);

                    return excel.GetAsByteArray();
                }
            }
            catch
            {
                return default;
            }
        }

        private void FillDataSheet(ExcelWorksheet dataSheet)
        {
            dataSheet.Cells[6, 2].LoadFromArrays(GetHeader());
            dataSheet.Cells[7, 1].LoadFromArrays(GetData());
        }

        private IEnumerable<object[]> GetHeader()
        {
            var headerNames = new object[itemCount];
            for (var index = 0; index < this.itemCount; index++)
                headerNames[index] = this.dataReport.ColumnNames[index + 1];
            yield return headerNames;
        }

        private IEnumerable<object[]> GetData()
        {
            foreach (var dataReportLog in this.dataReport.DataReportLogs)
            {
                var dateTime = dataReportLog.DateTime;
                var dataReportItemLogs = dataReportLog.DataReportItemLogs;
                var data = new object[this.itemCount + 1];

                data[0] = dateTime;
                for (var index = 0; index < this.itemCount; index++)
                {
                    var rawValue = dataReportItemLogs[index].Value;
                    if (double.TryParse(rawValue, out double value))
                    {
                        data[index + 1] = value;
                    }                        
                    else
                        data[index + 1] = rawValue;
                }
                this.rowDataCount++;
                yield return data;
            }
        }

        private void FormatDataSheet(ExcelWorksheet dataSheet)
        {
            #region CONTENT

            dataSheet.Cells[2, 1].Value = this.dataReport.Param.Content;
            dataSheet.Cells[3, 2].Value = this.dataReport.Param.FromDateTime;
            dataSheet.Cells[4, 2].Value = this.dataReport.Param.ToDateTime;
            dataSheet.Cells[2, 1, 2, this.itemCount + 1].Merge = true;
            dataSheet.Cells[2, 1, 2, this.itemCount + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            #endregion

            #region BORDER

            var range = dataSheet.Cells[6, 1, 6 + this.dataReport.DataReportLogs.Count(), 1 + this.itemCount];

            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;

            range.Style.Border.BorderAround(ExcelBorderStyle.Double);
            range.AutoFitColumns();

            #endregion

            #region BACKCOLOR

            for (var index = 0; index < this.itemCount; index++)
            {
                var columnName = this.columnNames[index];
                var item = this.dataReport.Param.Items.FirstOrDefault(x => string.Equals(x.Alias, columnName));
                if (item is null) continue;

                var rangeColor = dataSheet.Cells[6, 2 + index, 6 + this.rowDataCount, 2 + index];
                rangeColor.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rangeColor.Style.Fill.BackgroundColor.SetColor(item.Color.HexToColor());
            }

            #endregion
        }

        private void DrawChart(ExcelWorksheet dataSheet, ExcelWorksheet chartSheet)
        {
            var lineChart = chartSheet.Drawings.AddChart("lineChart", eChartType.Line) as ExcelLineChart;
            lineChart.Title.Text = this.dataReport.Param.Content;

            var rangeDateTime = dataSheet.Cells[7, 1, 6 + this.rowDataCount, 1];           
            for (var index = 0; index < this.itemCount; index++)
            {
                var range = dataSheet.Cells[7, 2 + index, 6 + this.rowDataCount, 2 + index];
                var serie = lineChart.Series.Add(range, rangeDateTime) as ExcelLineChartSerie;
                serie.Header = dataSheet.Cells[6, 2 + index].Value.ToString();
                serie.LineColor = this.dataReport.Param.Items[index].Color.HexToColor();
            }            
            lineChart.Legend.Position = eLegendPosition.Right;
            lineChart.SetSize(800, 400);
            lineChart.SetPosition(0, 0, 0, 0);
        }
    }
}
