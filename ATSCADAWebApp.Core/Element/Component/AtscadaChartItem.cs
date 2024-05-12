using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaChartItem : IRender
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-data-tag-name")]
        public string DataTagName { get; set; }

        [XmlAttribute("at-color")]
        public string Color { get; set; }

        public AtscadaChartItem()
        {
            Content = "Chart Item";
            DataTagName = "TaskName.TagName";
            Color = "#00acac";
        }

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
    }
}
