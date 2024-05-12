using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.Chart
{
    [Serializable()]
    [XmlType(TypeName = "atscada-chart-item")]
    public class ATSCADAChartItem: BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "ChartItem";

        private string content = "Chart Item";

        private string dataTagName = "TaskName.TagName";

        private string color = "#008080";

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

        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAChartItem()
        {        
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-chart-item ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-color=\"{Color}\" >");            
            builder.AppendLine($"</atscada-chart-item>");

            return builder.ToString();
        }

        #endregion
    }
}
