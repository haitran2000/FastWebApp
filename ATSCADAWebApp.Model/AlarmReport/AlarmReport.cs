using System.Collections.Generic;

namespace ATSCADAWebApp.Model
{
    public class AlarmReport
    {
        public AlarmReportParam Param { get; set; }

        public IEnumerable<AlarmReportLog> AlarmReportLogs { get; set; }
    }
}
