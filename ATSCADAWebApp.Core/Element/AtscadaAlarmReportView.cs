using ATSCADAWebApp.Core.Element.Component;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element
{
    [Serializable()]
    public class AtscadaAlarmReportView : IRender
    {
        [XmlArray("atscada-alarm-reporters")]
        [XmlArrayItem("atscada-alarm-reporter", typeof(AtscadaAlarmReporter))]
        public List<AtscadaAlarmReporter> AtscadaAlarmReporters { get; set; }    
        
        public AtscadaAlarmReportView()
        {
            AtscadaAlarmReporters = new List<AtscadaAlarmReporter>();
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"<div class=\"row\">");
            foreach (var alarmReporter in AtscadaAlarmReporters)
                builder.Append(alarmReporter.Render());
            builder.AppendLine($"</div>");           

            return builder.ToString();
        }
    }
}
