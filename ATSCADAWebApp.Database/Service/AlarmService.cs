using ATSCADAWebApp.Database.Access;
using ATSCADAWebApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ATSCADAWebApp.Database.Service
{
    /// <summary>
    /// Service truy van, lay du lieu hien thi cho AlarmViewer
    /// </summary>
    public class AlarmService
    {
        private readonly ISqlAccess sqlAccess = new MySqlAccess();

        public string ConnectionString { get; set; } = "server=localhost;uid=root;pwd=100100;database=atscada";

        public AlarmService() { }

        public AlarmService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Requets lay realtime alarm
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<Alarm> GetAlarms(AlarmParam param)
        {
            try
            {
                sqlAccess.ConnectionString = ConnectionString;
                var query = $"select * from `{param.TableName}` order by `DateTime` desc limit {param.Limit}";                
                var dataTable = sqlAccess.ExecuteQuery(query);
                if (dataTable is null) return Enumerable.Empty<Alarm>();

                var alarms = new List<Alarm>();
                foreach (DataRow row in dataTable.Rows)
                {
                    alarms.Add(new Alarm()
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
                return alarms;
            }
            catch
            {
                return Enumerable.Empty<Alarm>();
            }
        }

        public AlarmAcknowledgeResult Acknowledge(AlarmAcknowledgeParam param)
        {
            try
            {
                sqlAccess.ConnectionString = ConnectionString;
                var query = $"update `{param.TableName}` set `Acknowledged` = 'Yes' where `Acknowledged` = 'No'";
                var numberOfRows = sqlAccess.ExecuteNonQuery(query);
                return new AlarmAcknowledgeResult
                {
                    Connection = param.Connection,
                    TableName = param.TableName,
                    NumberOfRows = numberOfRows,
                    Status = true
                };
            }
            catch
            {
                return new AlarmAcknowledgeResult() { 
                    Connection = param.Connection,
                    TableName = param.TableName 
                };
            }
        }
    }
}
