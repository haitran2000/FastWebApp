using ATSCADAWebApp.Core.Element.Component;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element
{
    [Serializable()]
    public class AtscadaDataReportView : IRender
    {
        [XmlArray("atscada-data-reporters")]
        [XmlArrayItem("atscada-data-reporter", typeof(AtscadaDataReporter))]
        public List<AtscadaDataReporter> AtscadaDataReporters { get; set; }

        public AtscadaDataReportView()
        {
            AtscadaDataReporters = new List<AtscadaDataReporter>();
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"<div class=\"row\">");
            foreach (var dataReporter in AtscadaDataReporters)
                builder.Append(dataReporter.Render());
            builder.AppendLine($"</div>");

            return builder.ToString();
        }
    }
}
