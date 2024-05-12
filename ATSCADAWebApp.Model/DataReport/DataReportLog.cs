using System.Collections.Generic;

namespace ATSCADAWebApp.Model
{
    public class DataReportLog
    {
        public string DateTime { get; }

        public List<DataReportItemLog> DataReportItemLogs { get; }
        
        public DataReportLog(string dateTime)
        {
            DateTime = dateTime;
            DataReportItemLogs = new List<DataReportItemLog>();
        }
    }
}
