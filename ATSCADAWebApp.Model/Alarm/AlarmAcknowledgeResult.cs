namespace ATSCADAWebApp.Model
{
    /// <summary>
    /// Ket qua ack
    /// Tra ve so hang duoc thay doi, duoc ack
    /// </summary>
    public class AlarmAcknowledgeResult
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

        /// <summary>
        /// So record (row) duoc xac nhan ACK
        /// </summary>
        public int NumberOfRows { get; set; }
        
        /// <summary>
        /// Trang thai ACK: 
        /// True: Thanh cong
        /// False: That bai
        /// </summary>
        public bool Status { get; set; }
    }
}
