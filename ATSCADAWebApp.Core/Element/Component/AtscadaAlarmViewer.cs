using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaAlarmViewer : IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-table-name")]
        public string TableName { get; set; }

        [XmlAttribute("at-limit")]
        public int Limit { get; set; }

        [XmlAttribute("at-interval")]
        public int Interval { get; set; }

        [XmlAttribute("at-timeout")]
        public int Timeout { get; set; }

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaAlarmViewer()
        {
            Content = "Alarm Viewer";
            TableName = "alarmlog";
            Limit = 50;
            Interval = 3000;
            Timeout = 30000;
            GridColumn = "col-sm-12";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-alarm-viewer ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-table-name=\"{TableName}\" ");
            builder.Append($"at-limit=\"{Limit}\" ");
            builder.Append($"at-interval=\"{Interval}\" ");
            builder.Append($"at-timeout=\"{Timeout}\" >");
            builder.AppendLine($"</atscada-alarm-viewer></div>");

            return builder.ToString();             
        }
    }
}
