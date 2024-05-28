using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.SVGHyperLink
{
    [Serializable()]
    [XmlType(TypeName = "atscada-SVGHyperLink-item")]
    public class ATSCADASVGHyperLinkItem : BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "SVGHyperLinkItem";
        private string type = "0";
        private string color = "link";
        private string dataTagName = "TaskName.TagName";


        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }
        [XmlAttribute("at-type")]
        public string Type
        {
            get => this.type;
            set => SetField(ref this.type, value);
        }
        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADASVGHyperLinkItem()
        {
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-svghyperlink-item ");
            builder.Append($"at-content=\"{Name}\" ");
            builder.Append($"at-color=\"{Color}\" ");
            builder.Append($"at-type=\"{Type}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($">");
            builder.AppendLine($"</atscada-svghyperlink-item>");


            return builder.ToString();
        }

        #endregion
    }
}
