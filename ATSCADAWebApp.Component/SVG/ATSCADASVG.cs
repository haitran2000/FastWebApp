using ATSCADAWebApp.Component.SVGAlarm;
using ATSCADAWebApp.Component.SVGControlValue;
using ATSCADAWebApp.Component.SVGCutaway;
using ATSCADAWebApp.Component.SVGHyperLink;
using ATSCADAWebApp.Component.SVGValue;
using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.SVG
{
    /// <summary>
    /// SVG
    /// </summary>
    [DisplayName("iSVG")]
    [Serializable()]
    [XmlType(TypeName = "atscada-svg")]
    public class ATSCADASVG : ComponentBase, ISupportGrid, ISupportRender, IDefaultableObject
    {
        #region FILEDS

        private string content = "Name";


        private string color = "#008080";
        private string gridColumn = "col-sm-12";
        private string pathSVG = null;
        private List<ATSCADASVGValueItem> items = new List<ATSCADASVGValueItem>();
        private List<ATSCADASVGAlarmItem> itemsAlarm = new List<ATSCADASVGAlarmItem>();
        private List<ATSCADASVGCutawayItem> itemsCutaway = new List<ATSCADASVGCutawayItem>();
        private List<ATSCADASVGHyperLinkItem> itemsHyperLink = new List<ATSCADASVGHyperLinkItem>();
        private List<ATSCADASVGControlValueItem> itemsControlValue = new List<ATSCADASVGControlValueItem>();
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Text file SVG
        /// </summary>
        [XmlAttribute("at-path")]
        public string FilePath
        {
            get => this.pathSVG;
            set => SetField(ref this.pathSVG, value);
        }
        /// <summary>
        /// Text file SVG
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
        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
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
        /// Danh sach cac Item, phan tu hien thi tren SVGValue
        /// </summary>
        [XmlElement("atscada-svgvalue-item")]
        public List<ATSCADASVGValueItem> Items
        {
            get => this.items;
            set => SetField(ref this.items, value);
        }
        [XmlElement("atscada-svgalarm-item")]
        public List<ATSCADASVGAlarmItem> ItemsAlarm
        {
            get => this.itemsAlarm;
            set => SetField(ref this.itemsAlarm, value);
        }
        [XmlElement("atscada-svgcutaway-item")]
        public List<ATSCADASVGCutawayItem> ItemsCutaway
        {
            get => this.itemsCutaway;
            set => SetField(ref this.itemsCutaway, value);
        }
        [XmlElement("atscada-svghyperlink-item")]
        public List<ATSCADASVGHyperLinkItem> ItemsHyperLink
        {
            get => this.itemsHyperLink;
            set => SetField(ref this.itemsHyperLink, value);
        }

        [XmlElement("atscada-svgcontrolvalue-item")]
        public List<ATSCADASVGControlValueItem> ItemsControlValue
        {
            get => this.itemsControlValue;
            set => SetField(ref this.itemsControlValue, value);
        }
        #endregion

        #region CONSTRUCTORS

        public ATSCADASVG()
           : base()
        {
            Name = "NewSVG";
            Description = "SVG - ATSCADA Web Component";
        }

        public ATSCADASVG(IComposite parent)
           : base(parent)
        {
            Name = "NewSVG";
            Description = "SVG - ATSCADA Web Component";
        }

        public ATSCADASVG(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "SVG - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nha thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADASVGEditor(this).ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-SVG
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-svg");
            builder.Append($">");
            builder.Append($"<div style=\"background-color:{Color}; width: 1245px;\">");
            builder.Append($"{ Content}");
            builder.Append($"</ div >");

            foreach (var item in Items)
                builder.Append(item.Render());
            foreach (var item in ItemsAlarm)
                builder.Append(item.Render());
            foreach (var item in ItemsCutaway)
                builder.Append(item.Render());
            foreach (var item in ItemsHyperLink)
                builder.Append(item.Render());
            foreach (var item in ItemsControlValue)
                builder.Append(item.Render());
            builder.AppendLine($"</atscada-svg></div>");
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
                yield return new ATSCADASVG()
                {
                    Name = name,
                    Content = name,
                };
            }
        }

        #endregion
    }
}
