using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.Agauge
{
    /// <summary>
    /// Agauge
    /// </summary>
    [DisplayName("iAgauge")]
    [Serializable()]
    [XmlType(TypeName = "atscada-Agauge")]
    public class ATSCADAAgauge : ComponentBase, ISupportGrid, ISupportRender, IDefaultableObject
    {
        #region FILEDS

        private string content = "Name";

        private string dataTagName = "TaskName.TagName";

        private string color = "#008080";

        private string gridColumn = "col-sm-3";

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Tieu de hien thi tren Agauge
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
        /// BackgroundColor Agauge
        /// </summary>
        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }

        /// <summary>
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

        public ATSCADAAgauge()
           : base()
        {
            Name = "NewAgauge";
            Description = "Agauge - ATSCADA Web Component";
        }

        public ATSCADAAgauge(IComposite parent)
           : base(parent)
        {
            Name = "NewAgauge";
            Description = "Agauge - ATSCADA Web Component";
        }

        public ATSCADAAgauge(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Agauge - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nha thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAAgaugeEditor(this).ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-Agauge
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();
            string i = "myGauge";
            builder.Append($"<div class=\"{GridColumn}\"><atscada-agauge> ");
            builder.Append($"<canvas id=\"{i}\"></canvas>");
            builder.AppendLine($"</atscada-agauge></div>");

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
                yield return new ATSCADAAgauge()
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
