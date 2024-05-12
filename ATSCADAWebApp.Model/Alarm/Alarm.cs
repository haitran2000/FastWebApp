namespace ATSCADAWebApp.Model
{
    /// <summary>
    /// Model alarm log record
    /// </summary>
    public class Alarm
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
