using System.Collections.Generic;

namespace ATSCADAWebApp.Model
{
    public class DataReport
    {
        public string[] ColumnNames { get; set; }

        public DataReportParam Param { get; set; }

        public IEnumerable<DataReportLog> DataReportLogs { get; set; }        
    }
}
