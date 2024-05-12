using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.SVGAlarm
{
    [Serializable()]
    [XmlType(TypeName = "atscada-SVGAlarm-item")]
    public class ATSCADASVGAlarmItem : BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "SVGalarmItem";

        private string content = "SVGalarm Item";

        private string dataTagName = "TaskName.TagName";
        private string dataHighTagName = "TaskName.TagName";
        private string dataLowTagName = "TaskName.TagName";
        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }

        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }
        
        [XmlAttribute("at-highalarm")]
        public string HighAlarm
        {
            get => this.dataHighTagName;
            set => SetField(ref this.dataHighTagName, value);
        }
        [XmlAttribute("at-Lowalarm")]
        public string LowAlarm
        {
            get => this.dataLowTagName;
            set => SetField(ref this.dataLowTagName, value);
        }
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADASVGAlarmItem()
        {        
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-svgalarm-item ");
            builder.Append($"at-content=\"{Name}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-data-low-tag-name=\"{LowAlarm}\" ");
            builder.Append($"at-data-hight-tag-name=\"{HighAlarm}\" ");
            builder.Append($">");            
            builder.AppendLine($"</atscada-svgalarm-item>");

            return builder.ToString();
        }

        #endregion
    }
}
