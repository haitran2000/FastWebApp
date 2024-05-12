using ATSCADAWebApp.Core;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.Slider
{
    /// <summary>
    /// thanh truot hien thi, ghi gia tri xuong Tag
    /// </summary>
    [DisplayName("iSlider")]
    [Serializable()]
    [XmlType(TypeName = "atscada-slider")]
    public class ATSCADASlider : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FILEDS

        private string content = "Name";

        private string dataTagName = "TaskName.TagName";

        private double min = 0d;

        private double max = 100d;

        private double step = 0.1d;

        private string skin = "big";

        private string gridColumn = "col-sm-3";

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
        /// TagName
        /// </summary>
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        /// <summary>
        /// Gia tri nho nhat cua thanh Slider
        /// </summary>
        [XmlAttribute("at-min")]
        public double Min
        {
            get => this.min;
            set => SetField(ref this.min, value);
        }

        /// <summary>
        /// Gia tri lon nhat cua thanh Slider
        /// </summary>
        [XmlAttribute("at-max")]
        public double Max
        {
            get => this.max;
            set => SetField(ref this.max, value);
        }

        /// <summary>
        /// Buoc nhay khi keo thanh truot
        /// </summary>
        [XmlAttribute("at-step")]
        public double Step
        {
            get => this.step;
            set => SetField(ref this.step, value);
        }

        [XmlAttribute("at-skin")]
        public string Skin
        {
            get => this.skin;
            set => SetField(ref this.skin, value);
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

        public ATSCADASlider()
             : base()
        {
            Name = "NewSlider";
            Description = "Slider - ATSCADA Web Component";
        }

        public ATSCADASlider(IComposite parent)
             : base(parent)
        {
            Name = "NewSlider";
            Description = "Slider - ATSCADA Web Component";
        }

        public ATSCADASlider(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Slider - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nhat thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADASliderSlider(this).ShowDialog() == DialogResult.OK;     
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-input
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-slider ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-min=\"{Min}\" ");
            builder.Append($"at-max=\"{Max}\" ");
            builder.Append($"at-step=\"{Step}\" ");
            builder.Append($"at-skin=\"{Skin}\" >");
            builder.AppendLine($"</atscada-slider></div>");

            return builder.ToString();
        }

        #endregion
    }
}
