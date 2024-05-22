using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.SVGValue
{
    [Serializable()]
    [XmlType(TypeName = "atscada-SVGValue-item")]
    public class ATSCADASVGValueItem: BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "SVGValueItem";
        private string min = "0";
        private string max = "100";
        private string content = "SVGValue Item";
        private string properties = "Value";
        private string type = "Bool";
        private string dataTagName = "TaskName.TagName";
        private string attribute = "";
        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }
        [XmlAttribute("at-min")]
        public string Min
        {
            get => this.min;
            set => SetField(ref this.min, value);
        }
        [XmlAttribute("at-type")]
        public string Type
        {
            get => this.type;
            set => SetField(ref this.type, value);
        }
        [XmlAttribute("at-max")]
        public string Max
        {
            get => this.max;
            set => SetField(ref this.max, value);
        }
        [XmlAttribute("at-properties")]
        public string Properties
        {
            get => this.properties;
            set => SetField(ref this.properties, value);
        }
        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }
        [XmlAttribute("at-bad")]
        public string Attribute
        {
            get => this.attribute;
            set => SetField(ref this.attribute, value);
        }
        #endregion

        #region CONSTRUCTORS

        public ATSCADASVGValueItem()
        {        
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-svgvalue-item ");
            builder.Append($"at-content=\"{Name}\" ");
            builder.Append($"at-properties=\"{Properties}\" ");
            builder.Append($"at-type=\"{Type}\" ");
            builder.Append($"at-min=\"{Min}\" ");
            builder.Append($"at-max=\"{Max}\" ");
            builder.Append($"at-attribute=\"{Attribute}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($">"); 
            builder.AppendLine($"</atscada-svgvalue-item>");
           

            return builder.ToString();
        }

        #endregion
    }
}
