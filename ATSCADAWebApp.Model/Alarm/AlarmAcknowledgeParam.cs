namespace ATSCADAWebApp.Model
{
    /// <summary>
    /// param truyen khi bam xac nhan ack
    /// update du lieu trong table alarm log. Set ack = yes
    /// </summary>
    public class AlarmAcknowledgeParam
    {
        /// <summary>
        /// Chuoi ket noi Connection
        /// Dai dien cho ConnectionString trong cau hinh file webConfig
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Table alarm log
        /// </summary>
        public string TableName { get; set; }
    }
}
