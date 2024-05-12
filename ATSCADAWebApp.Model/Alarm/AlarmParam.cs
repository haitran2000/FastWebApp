namespace ATSCADAWebApp.Model
{
    /// <summary>
    /// param ke noi connection
    /// </summary>
    public class AlarmParam
    {
        /// <summary>
        /// Chuoi ket noi Connection
        /// Dai dien cho ConnectionString trong cau hinh file webConfig
        /// </summary>
        public string Connection { get; set; } = "atscada";

        /// <summary>
        /// Table alarm log
        /// </summary>
        public string TableName { get; set; } = "alarmlog";

        /// <summary>
        /// Gioi han so hang query (hien thi tren alarmViewr)
        /// </summary>
        public int Limit { get; set; } = 50;
    }
}
