namespace ATSCADAWebApp.Model
{
    /// <summary>
    /// Alarm record log
    /// </summary>
    public class AlarmReportLog
    {
        public string DateTime { get; set; }

        public string TagName { get; set; }

        public string TagAlias { get; set; }

        public string Value { get; set; }

        public string HighLevel { get; set; }

        public string LowLevel { get; set; }

        public string Status { get; set; }

        public string ACK { get; set; }
    }
}
