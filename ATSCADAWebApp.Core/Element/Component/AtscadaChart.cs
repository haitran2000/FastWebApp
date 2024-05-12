using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    [XmlType(TypeName = "atscada-chart")]
    public class AtscadaChart : IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-type")]
        public string Type { get; set; }

        [XmlAttribute("at-height")]
        public string Height { get; set; }

        [XmlAttribute("at-xlabel")]
        public string Xlabel { get; set; }

        [XmlAttribute("at-ylabel")]
        public string Ylabel { get; set; }

        [XmlArray("atscada-chart-items")]
        [XmlArrayItem("atscada-chart-item", typeof(AtscadaChartItem))]
        public List<AtscadaChartItem> AtscadaChartItems { get; set; }

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaChart()
        {
            AtscadaChartItems = new List<AtscadaChartItem>();

            Content = "Chart";
            Type = "line";
            Height = "200px";
            Xlabel = "Time";
            Ylabel = "Value";
            GridColumn = "col-sm-6";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-chart ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-type=\"{Type}\" ");
            builder.Append($"at-height=\"{Height}\" ");
            builder.Append($"at-xlabel=\"{Xlabel}\" ");
            builder.Append($"at-ylabel=\"{Ylabel}\" >");
            foreach (var chartItem in AtscadaChartItems)
                builder.Append(chartItem.Render());
            builder.AppendLine($"</atscada-chart></div>");

            return builder.ToString();
        }
    }
}
