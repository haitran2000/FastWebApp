using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.ChartDemo
{
    /// <summary>
    /// ChartDemo
    /// </summary>
    [DisplayName("iChartDemo")]
    [Serializable()]
    [XmlType(TypeName = "atscada-chartdemo")]
    public class ATSCADAChartDemo : ComponentBase, ISupportGrid, ISupportRender, IDefaultableObject
    {
        #region FILEDS

        private string content = "Name";

        private string dataTagName = "TaskName.TagName";

        private string color = "#008080";

        private string icon = "fa fa-globe fa-fw";

        private decimal decimalPlaces = 2;

        private string gridColumn = "col-sm-3";

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Tieu de hien thi tren ChartDemo
        /// </summary>
        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        /// <summary>
        /// TagName
        /// </summary>
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        /// <summary>
        /// BackgroundColor ChartDemo
        /// </summary>
        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }

        /// <summary>
        /// Icon hien thi
        /// </summary>
        [XmlAttribute("at-icon")]
        public string Icon
        {
            get => this.icon;
            set => SetField(ref this.icon, value);
        }

        /// <summary>
        /// So chu so thap phan lam tron neu la kieu so
        /// </summary>
        [XmlAttribute("at-decimal-places")]
        public decimal DecimalPlaces
        {
            get => this.decimalPlaces;
            set => SetField(ref this.decimalPlaces, value);
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

        public ATSCADAChartDemo()
           : base()
        {
            Name = "NewChartDemo";
            Description = "ChartDemo - ATSCADA Web Component";
        }

        public ATSCADAChartDemo(IComposite parent)
           : base(parent)
        {
            Name = "NewChartDemo";
            Description = "ChartDemo - ATSCADA Web Component";
        }

        public ATSCADAChartDemo(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "ChartDemo - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nha thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAChartDemoEditor(this).ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-ChartDemo
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-ChartDemo ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-color=\"{Color}\" ");
            builder.Append($"at-icon=\"{Icon}\" ");
            builder.Append($"at-decimal-places=\"{DecimalPlaces}\" >");
            builder.AppendLine($"</atscada-ChartDemo></div>");

            return builder.ToString();
        }

        /// <summary>
        /// Tao ra danh sach phan tu mac dinh. Tinh nang quick
        /// </summary>
        /// <param name="tagNames"></param>
        /// <returns></returns>
        public IEnumerable<Core.IComponent> DefaultObject(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                var name = "Value";
                var taskNameTagName = tagName.Split('.');
                if (taskNameTagName.Length > 1)
                    name = taskNameTagName[1];
                yield return new ATSCADAChartDemo()
                {
                    Name = name,
                    Content = name,
                    DataTagName = tagName
                };
            }
        }

        #endregion
    }
}
