namespace ATSCADAWebApp.Model
{
    public class AlarmReportParam
    {
        /// <summary>
        /// ID cua AlarmReporter
        /// Tren mot view co the co nhieu AlarmReporter. Moi reporter se duoc gan 1 ID duy nhat
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Tieu de hien thi trong file Excel
        /// </summary>
        public string Content { get; set; }

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
        /// Tu ngay
        /// </summary>
        public string FromDateTime { get; set; }

        /// <summary>
        /// Den ngay
        /// </summary>
        public string ToDateTime { get; set; }
    }
}
