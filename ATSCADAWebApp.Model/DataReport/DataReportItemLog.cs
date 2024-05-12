namespace ATSCADAWebApp.Model
{
    public class DataReportItemLog
    {
        public string Alias { get; }

        public string Value { get; }

        public DataReportItemLog(string alias, string value)
        {
            Alias = alias;
            Value = value;
        }
    }
}
