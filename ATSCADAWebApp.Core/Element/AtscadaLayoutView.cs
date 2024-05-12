using ATSCADAWebApp.Core.Element.Component;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element
{
    [Serializable()]
    public class AtscadaLayoutView : IRender
    {
        [XmlAttribute("at-interval")]
        public int Interval { get; set; }

        [XmlAttribute("at-max-number-of-write")]
        public int MaxNumberOfWrite { get; set; }

        [XmlAttribute("at-timeout")]
        public int Timeout { get; set; }

        [XmlArray("atscada-cards")]
        [XmlArrayItem("atscada-card", typeof(AtscadaCard))]
        public List<AtscadaCard> AtscadaCards { get; set; }

        [XmlArray("atscada-charts")]
        [XmlArrayItem("atscada-chart", typeof(AtscadaChart))]
        public List<AtscadaChart> AtscadaCharts { get; set; }

        [XmlArray("atscada-alarm-viewers")]
        [XmlArrayItem("atscada-alarm-viewers", typeof(AtscadaAlarmViewer))]
        public List<AtscadaAlarmViewer> AtscadaAlarmViewers { get; set; }

        public AtscadaLayoutView()
        {            
            AtscadaCards = new List<AtscadaCard>();
            AtscadaCharts = new List<AtscadaChart>();
            AtscadaAlarmViewers = new List<AtscadaAlarmViewer>();

            Interval = 1000;
            MaxNumberOfWrite = 10;
            Timeout = 3000;
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-data-task ");
            builder.Append($"at-interval=\"{Interval}\" ");
            builder.Append($"at-max-number-of-write=\"{MaxNumberOfWrite}\" ");
            builder.Append($"at-timeout=\"{Timeout}\" >");

            builder.AppendLine($"<div class=\"row\">");
            foreach (var card in AtscadaCards)
                builder.Append(card.Render());
            builder.AppendLine($"</div>");

            builder.AppendLine($"<div class=\"row\">");
            foreach (var chart in AtscadaCharts)
                builder.Append(chart.Render());
            builder.AppendLine($"</div>");

            builder.AppendLine($"<div class=\"row\">");
            foreach (var alarmViewer in AtscadaAlarmViewers)
                builder.Append(alarmViewer.Render());
            builder.AppendLine($"</div>");

            builder.AppendLine($"</atscada-data-task>");

            return builder.ToString();
        }
    }
}
