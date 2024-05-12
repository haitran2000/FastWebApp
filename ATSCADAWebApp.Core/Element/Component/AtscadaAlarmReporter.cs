using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaAlarmReporter : IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-table-name")]
        public string TableName { get; set; }

        [XmlAttribute("at-timeout")]
        public int Timeout { get; set; }

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaAlarmReporter()
        {
            Content = "Alarm Reporter";
            TableName = "alarmlog";
            Timeout = 30000;
            GridColumn = "col-sm-12";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-alarm-reporter ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-table-name=\"{TableName}\" ");
            builder.Append($"at-timeout=\"{Timeout}\" >");
            builder.AppendLine($"</atscada-alarm-reporter></div>");

            return builder.ToString();
        }
    }
}
