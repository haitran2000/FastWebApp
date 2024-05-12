using ATSCADAWebApp.Core;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.Switch
{
    /// <summary>
    /// Switch ON-OFF
    /// </summary>
    [DisplayName("iSwitch")]
    [Serializable()]
    [XmlType(TypeName = "atscada-switch")]
    public class ATSCADASwitch : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FILEDS

        private string content = "Name";

        private string dataTagName = "TaskName.TagName";

        private string color = "#008080";

        private string size = "default";

        private string valueOn = "1";

        private string valueOff = "0";

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
        /// Mau sac hien thi switch
        /// </summary>
        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }

        /// <summary>
        /// Kich thuoc: small, big
        /// </summary>
        [XmlAttribute("at-size")]
        public string Size
        {
            get => this.size;
            set => SetField(ref this.size, value);
        }

        /// <summary>
        /// Gia tri trang thai ON
        /// </summary>
        [XmlAttribute("at-value-on")]
        public string ValueOn
        {
            get => this.valueOn;
            set => SetField(ref this.valueOn, value);
        }

        /// <summary>
        /// Gia tri trang thai OFF
        /// </summary>
        [XmlAttribute("at-value-off")]
        public string ValueOff
        {
            get => this.valueOff;
            set => SetField(ref this.valueOff, value);
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

        public ATSCADASwitch()
           : base()
        {
            Name = "NewSwitch";
            Description = "Switch - ATSCADA Web Component";
        }

        public ATSCADASwitch(IComposite parent)
           : base(parent)
        {
            Name = "NewSwitch";
            Description = "Switch - ATSCADA Web Component";
        }

        public ATSCADASwitch(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Switch - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        public override bool Update()
        {
            return new ATSCADASwitchEditor(this).ShowDialog() == DialogResult.OK;   
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-switch ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-color=\"{Color}\" ");
            builder.Append($"at-size=\"{Size}\" ");
            builder.Append($"at-value-on=\"{ValueOn}\" ");
            builder.Append($"at-value-off=\"{ValueOff}\" >");
            builder.AppendLine($"</atscada-switch></div>");

            return builder.ToString();
        }

        #endregion
    }
}
