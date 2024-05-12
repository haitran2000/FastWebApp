using System;
using System.Text;
using System.Xml.Serialization;
using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Component.GoogleMap
{
    [Serializable()]
    [XmlType(TypeName = "atscada-param-item")]
    public class ATSCADAParamItem : BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "Paramater Item";

        private string alias = "Item";

        private string paramTagName = "TaskName.TagName";

        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }

        [XmlAttribute("at-alias")]
        public string Alias
        {
            get => this.alias;
            set => SetField(ref this.alias, value);
        }

        [XmlAttribute("at-param-tag-name")]
        public string ParamTagName
        {
            get => this.paramTagName;
            set => SetField(ref this.paramTagName, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAParamItem() { }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-param-item ");
            builder.Append($"at-alias=\"{Alias}\" ");
            builder.Append($"at-param-tag-name=\"{ParamTagName}\" >");
            builder.AppendLine($"</atscada-param-item>");

            return builder.ToString();
        }

        #endregion
    }
}
