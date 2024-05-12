using System;
using ATSCADAWebApp.Database.Access;
using ATSCADAWebApp.Model.GoogleMap;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ATSCADAWebApp.Database.Service
{
    public class GoogleMapService
    {
        private readonly ISqlAccess sqlAccess = new MySqlAccess();

        public string ConnectionString { get; set; } = "server=localhost;uid=root;pwd=100100;database=atscada";

        public GoogleMapService() { }

        public GoogleMapService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<GoogleMapDatalog> LoadDatabase(GoogleMapParam param)
        {
            try
            {
                sqlAccess.ConnectionString = ConnectionString;
                var table = param.TableName;
                var startDate = param.FromDateTime;
                var endDate = param.ToDateTime;

                var query = $"select * from `{param.TableName}` where `DateTime` between " +
                    $"str_to_date('{startDate}', '%m-%d-%Y %H:%i:%s') and " +
                    $"str_to_date('{endDate}', '%m-%d-%Y %H:%i:%s');";

                var dataTable = sqlAccess.ExecuteQuery(query);
                if (dataTable is null)
                    return Enumerable.Empty<GoogleMapDatalog>();

                var data = new List<GoogleMapDatalog>();
                var count = dataTable.Columns.Count;
                foreach (DataRow row in dataTable.Rows)
                {
                    var getData = new GoogleMapDatalog(
                        row.Field<DateTime>("DateTime").ToString("dd/MM/yyyy HH:mm:ss"),
                        row["Location"].ToString());

                    for (var index = 2; index < count; index++)
                    {
                        var alias = dataTable.Columns[index].ColumnName;
                        var value = row[index].ToString();
                        getData.Parameters.Add(new GoogleMapParameters(alias, value));
                    }
                    data.Add(getData);
                }
                return data;
            }
            catch
            {
                return Enumerable.Empty<GoogleMapDatalog>();
            }
        }
    }
}
