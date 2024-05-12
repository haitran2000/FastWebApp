using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaDataReporter : IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-table-name")]
        public string TableName { get; set; }

        [XmlAttribute("at-timeout")]
        public int Timeout { get; set; }

        [XmlArray("atscada-data-reporter-items")]
        [XmlArrayItem("atscada-data-reporter-item", typeof(AtscadaDataReporterItem))]
        public List<AtscadaDataReporterItem> AtscadaDataReporterItems { get; set; }

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaDataReporter()
        {
            AtscadaDataReporterItems = new List<AtscadaDataReporterItem>();

            Content = "Data Reporter";
            TableName = "datalog";
            Timeout = 30000;
            GridColumn = "col-sm-12";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-data-reporter ");
            builder.Append($"at-content=\"{Content}\" ");          
            builder.Append($"at-table-name=\"{TableName}\" ");
            builder.Append($"at-timeout=\"{Timeout}\" >");
            foreach (var dataReporterItem in AtscadaDataReporterItems)
                builder.Append(dataReporterItem.Render());
            builder.AppendLine($"</atscada-data-reporter></div>");

            return builder.ToString();
        }
    }
}
