using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.DataReporter
{
    /// <summary>
    /// Bao cao du lieu dataLog
    /// </summary>
    [DisplayName("iDataReporter")]
    [Serializable()]
    [XmlType(TypeName = "atscada-data-reporter")]
    public class ATSCADADataReporter : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FIELDS

        private string content = "Data Reporter";

        private string connection = "atscada";

        private string tableName = "datalog";

        private decimal timeout = 30000;

        private string gridColumn = "col-sm-12";

        private List<ATSCADADataReporterItem> items = new List<ATSCADADataReporterItem>();

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

        /// <summary>
        /// Danh sach cac Item (cot du lieu trong table) bao cao
        /// </summary>
        [XmlElement("atscada-data-reporter-item")]
        public List<ATSCADADataReporterItem> Items
        {
            get => this.items;
            set => SetField(ref this.items, value);
        }            

        #endregion

        #region CONSTRUCTORS

        public ATSCADADataReporter()
              : base()
        {
            Name = "NewDataReporter";
            Description = "DataReporter - ATSCADA Web Component";          
        }

        public ATSCADADataReporter(IComposite parent)
              : base(parent)
        {
            Name = "NewDataReporter";
            Description = "DataReporter - ATSCADA Web Component";          
        }

        public ATSCADADataReporter(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "DataReporter - ATSCADA Web Component";           
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nha thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADADataReporterEditor(this).ShowDialog() == DialogResult.OK;      
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-data-reporter
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-data-reporter ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-connection=\"{Connection}\" ");
            builder.Append($"at-table-name=\"{TableName}\" ");
            builder.AppendLine($"at-timeout=\"{Timeout}\" >");

            foreach (var item in Items)
                builder.Append(item.Render());

            builder.AppendLine($"</atscada-data-reporter></div>");

            return builder.ToString();
        }

        #endregion
    }
}
