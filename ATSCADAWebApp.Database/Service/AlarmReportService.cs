using ATSCADAWebApp.Database.Access;
using ATSCADAWebApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ATSCADAWebApp.Database.Service
{
    /// <summary>
    /// Service ket noi lay du lieu AlarmReport
    /// </summary>
    public class AlarmReportService
    {
        private readonly ISqlAccess sqlAccess = new MySqlAccess();

        public string ConnectionString { get; set; } = "server=localhost;uid=root;pwd=100100;database=atscada";

        public AlarmReportService() { }

        public AlarmReportService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Lay danh sach AlarmLog
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<AlarmReportLog> GetAlarmReportLogs(AlarmReportParam param)
        {
            try
            {
                sqlAccess.ConnectionString = ConnectionString;
                var query = $"select * from `{param.TableName}` where `DateTime` between " +
                    $"str_to_date('{param.FromDateTime}', '%m-%d-%Y %H:%i:%s') and " +
                    $"str_to_date('{param.ToDateTime}', '%m-%d-%Y %H:%i:%s') " +
                    $"order by `DateTime` asc";
                var dataTable = sqlAccess.ExecuteQuery(query);
                if (dataTable is null) return Enumerable.Empty<AlarmReportLog>();

                var alarmLogs = new List<AlarmReportLog>();
                foreach (DataRow row in dataTable.Rows)
                {
                    alarmLogs.Add(new AlarmReportLog()
                    {
                        DateTime = row.Field<DateTime>("DateTime").ToString("MM-dd-yyyy HH:mm:ss"),
                        TagName = row["TagName"].ToString(),
                        TagAlias = row["TagAlias"].ToString(),
                        Value = row["Value"].ToString(),
                        HighLevel = row["HighLevel"].ToString(),
                        LowLevel = row["LowLevel"].ToString(),
                        Status = row["Status"].ToString(),
                        ACK = row["Acknowledged"].ToString()
                    });
                }
                return alarmLogs;
            }
            catch
            {
                return Enumerable.Empty<AlarmReportLog>();
            }
        }
    }
}
