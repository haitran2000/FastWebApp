using ATSCADAWebApp.Core;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.AlarmViewer
{
    /// <summary>
    /// alarm viewer. Hien thi realime cac alarmRecord
    /// </summary>
    [DisplayName("iAlarmViewer")]
    [Serializable()]
    [XmlType(TypeName = "atscada-alarm-viewer")]
    public class ATSCADAAlarmViewer : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FIELDS

        private string content = "Alarm Viewer";

        private string connection = "atscada";

        private string tableName = "alarmlog";

        private decimal limit = 50;

        private decimal interval = 3000;

        private decimal timeout = 30000;

        private string gridColumn = "col-sm-12";

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Tieu de hien thi cua alarmViewer
        /// </summary>

        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        /// <summary>
        /// Chuoi ket noi toi DATABASE de kiem tra dang nhap, login
        /// Chuoi connection duoc cai dat trong file webConfig
        /// Gom: Server, Port, User, Pass, Database
        /// </summary>
        [XmlAttribute("at-connection")]
        public string Connection
        {
            get => this.connection;
            set => SetField(ref this.connection, value);
        }

        /// <summary>
        /// Table alarm log
        /// </summary>
        [XmlAttribute("at-table-name")]
        public string TableName
        {
            get => this.tableName;
            set => SetField(ref this.tableName, value);
        }

        /// <summary>
        /// Gioi han so record hien thi tren giao dien
        /// </summary>
        [XmlAttribute("at-limit")]
        public decimal Limit
        {
            get => this.limit;
            set => SetField(ref this.limit, value);
        }

        /// <summary>
        /// Chu ky cap nhat record
        /// </summary>
        [XmlAttribute("at-interval")]
        public decimal Interval
        {
            get => this.interval;
            set => SetField(ref this.interval, value);
        }

        /// <summary>
        /// Thoi gian timeout request alarm log recocrd
        /// </summary>
        [XmlAttribute("at-timeout")]
        public decimal Timeout
        {
            get => this.timeout;
            set => SetField(ref this.timeout, value);
        }

        /// <summary>
        /// So cot hien thi trong Column. Theo bootsrap grid
        /// </summary>
        [XmlAttribute("at-grid-column")]
        public string GridColumn
        {
            get => this.gridColumn;
            set => SetField(ref this.gridColumn, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAAlarmViewer()
            : base()
        {
            Name = "NewAlarmViewer";
            Description = "AlarmViewer - ATSCADA Web Component";
        }

        public ATSCADAAlarmViewer(IComposite parent)
            : base(parent)
        {
            Name = "NewAlarmViewer";
            Description = "Alarm Reporter - ATSCADA Web Component";
        }

        public ATSCADAAlarmViewer(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "AlarmViewer - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nhat thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAAlarmViewerEditor(this).ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-alarm-viewer
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-alarm-viewer ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-connection=\"{Connection}\" ");
            builder.Append($"at-table-name=\"{TableName}\" ");
            builder.Append($"at-limit=\"{Limit}\" ");
            builder.Append($"at-interval=\"{Interval}\" ");
            builder.Append($"at-timeout=\"{Timeout}\" >");
            builder.AppendLine($"</atscada-alarm-viewer></div>");

            return builder.ToString();
        }

        #endregion
    }
}
