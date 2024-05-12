using ATSCADAWebApp.Database.Access;
using ATSCADAWebApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ATSCADAWebApp.Database.Service
{
    /// <summary>
    /// Service xuat bao cao data.
    /// </summary>
    public class DataReportService
    {
        private readonly ISqlAccess sqlAccess = new MySqlAccess();

        public string ConnectionString { get; set; } = "server=localhost;uid=root;pwd=100100;database=atscada";

        public DataReportService() { }

        public DataReportService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Lay du lieu bao cao
        /// </summary>
        /// <param name="param">Thong tin ve chuoi ket noi, bang du lieu</param>
        /// <param name="columnNames">Danh sach cac cot du lieu trong Table</param>
        /// <returns></returns>
        public IEnumerable<DataReportLog> GetDataReportLogs(DataReportParam param, out string[] columnNames)
        {
            try
            {
                sqlAccess.ConnectionString = ConnectionString;
                var query = $"select * from `{param.TableName}` where `DateTime` between " +
                    $"str_to_date('{param.FromDateTime}', '%m-%d-%Y %H:%i:%s') and " +
                    $"str_to_date('{param.ToDateTime}', '%m-%d-%Y %H:%i:%s') " +
                    $"order by `DateTime` asc";

                var dataTable = sqlAccess.ExecuteQuery(query);
                if (dataTable is null || dataTable.Columns[0].ColumnName != "DateTime")
                {
                    columnNames = new string[0];
                    return Enumerable.Empty<DataReportLog>();
                }

                var columnParams = param.Items.Select(x => x.Alias);
                var columnNameRemove = dataTable.Columns.Cast<DataColumn>()
                    .Select(x => x.ColumnName)
                    .Except(columnParams)
                    .ToList();

                foreach (var name in columnNameRemove)
                    if (!string.Equals(name, "DateTime"))
                        dataTable.Columns.Remove(name);
                columnNames = dataTable.Columns.Cast<DataColumn>()
                    .Select(x => x.ColumnName)                   
                    .ToArray();

                var dataReportLogs = new List<DataReportLog>();
                var columnCount = dataTable.Columns.Count;
                foreach (DataRow row in dataTable.Rows)
                {
                    var dataReportLog = new DataReportLog(
                        row.Field<DateTime>("DateTime").ToString("MM-dd-yyyy HH:mm:ss"));
                    for (var index = 1; index < columnCount; index++)
                    {
                        var alias = dataTable.Columns[index].ColumnName;
                        var value = row[index].ToString();
                        dataReportLog.DataReportItemLogs.Add(new DataReportItemLog(
                            alias, value));
                    }
                    dataReportLogs.Add(dataReportLog);
                }

                return dataReportLogs;
            }
            catch
            {
                columnNames = new string[0];
                return Enumerable.Empty<DataReportLog>();
            }
        }
    }
}
