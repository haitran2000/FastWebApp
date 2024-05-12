using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.Chart
{
    /// <summary>
    /// chart fastweb
    /// Bao gom: line, bar, pie
    /// moi item la 1 tag
    /// </summary>
    [DisplayName("iChart")]
    [Serializable()]
    [XmlType(TypeName = "atscada-chart")]
    public class ATSCADAChart : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FILEDS

        private string content = "Name";

        private string type = "line";

        private string height = "250px";

        private decimal sampleNum = 50;

        private string xlabel = "Time";

        private string ylabel = "Value";        

        private string gridColumn = "col-sm-12";

        private List<ATSCADAChartItem> items = new List<ATSCADAChartItem>();

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Tieu de hien thi
        /// </summary>
        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        /// <summary>
        /// Kieu chart: line, bar, pie
        /// </summary>
        [XmlAttribute("at-type")]
        public string Type
        {
            get => this.type;
            set => SetField(ref this.type, value);
        }

        /// <summary>
        /// Chieu cao cua chart
        /// </summary>
        [XmlAttribute("at-height")]
        public string Height
        {
            get => this.height;
            set => SetField(ref this.height, value);
        }

        /// <summary>
        /// So diem lay mau
        /// </summary>
        [XmlAttribute("at-sample-num")]
        public decimal SampleNum
        {
            get => this.sampleNum;
            set => SetField(ref this.sampleNum, value);
        }

        /// <summary>
        /// Tieu de truc X
        /// </summary>
        [XmlAttribute("at-xlabel")]
        public string Xlabel
        {
            get => this.xlabel;
            set => SetField(ref this.xlabel, value);
        }

        /// <summary>
        /// Tieu de truc Y
        /// </summary>
        [XmlAttribute("at-ylabel")]
        public string Ylabel
        {
            get => this.ylabel;
            set => SetField(ref this.ylabel, value);
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
        /// Danh sach cac Item, phan tu hien thi tren Chart
        /// </summary>
        [XmlElement("atscada-chart-item")]
        public List<ATSCADAChartItem> Items
        {
            get => this.items;
            set => SetField(ref this.items, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAChart()
              : base()
        {
            Name = "NewChart";
            Description = "Chart - ATSCADA Web Component";            
        }

        public ATSCADAChart(IComposite parent)
             : base(parent)
        {
            Name = "NewChart";
            Description = "Chart - ATSCADA Web Component";            
        }

        public ATSCADAChart(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Chart - ATSCADA Web Component";            
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nha thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAChartEditor(this).ShowDialog() == DialogResult.OK;      
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-chart
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-chart ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-type=\"{Type}\" ");
            builder.Append($"at-height=\"{Height}\" ");
            builder.Append($"at-sample-num=\"{SampleNum}\" ");
            builder.Append($"at-xlabel=\"{Xlabel}\" ");
            builder.AppendLine($"at-ylabel=\"{Ylabel}\" >");

            foreach (var item in Items)
                builder.Append(item.Render());

            builder.AppendLine($"</atscada-chart></div>");

            return builder.ToString();
        }

        #endregion
    }
}
