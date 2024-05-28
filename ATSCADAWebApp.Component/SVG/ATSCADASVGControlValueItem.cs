using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.SVGControlValue
{
    [Serializable()]
    [XmlType(TypeName = "atscada-svgcontrolvalue-item")]
    public class ATSCADASVGControlValueItem : BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "SVGControlValueItem";
        private string dataTagName = "TaskName.TagName";
        private string atribute = "";
        private string type = "";
        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }
        [XmlAttribute("at-atribute")]
        public string Atribute
        {
            get => this.atribute;
            set => SetField(ref this.atribute, value);
        }
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }
        [XmlAttribute("at-type")]
        public string Type
        {
            get => this.type;
            set => SetField(ref this.type, value);
        }
        #endregion

        #region CONSTRUCTORS

        public ATSCADASVGControlValueItem()
        {
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-svgcontrolvalue-item ");
            builder.Append($"at-content=\"{Name}\" ");
            builder.Append($"at-atribute=\"{Atribute}\" ");
            builder.Append($"at-type=\"{Type}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($">");
            builder.AppendLine($"</atscada-svgcontrolvalue-item>");


            return builder.ToString();
        }

        #endregion
    }
}
