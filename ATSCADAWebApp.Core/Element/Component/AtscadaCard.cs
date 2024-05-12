using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaCard : IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-data-tag-name")]
        public string DataTagName { get; set; }

        [XmlAttribute("at-color")]
        public string Color { get; set; }

        [XmlAttribute("at-icon")]
        public string Icon { get; set; }

        [XmlAttribute("at-decimal-places")]
        public uint DecimalPlaces { get; set; }

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaCard()
        {
            Content = "Name";
            DataTagName = "TaskName.TagName";
            Color = "#00acac";
            Icon = "fa fa-globe fa-fw";
            DecimalPlaces = 2;
            GridColumn = "col-sm-3";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-card ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-color=\"{Color}\" ");
            builder.Append($"at-icon=\"{Icon}\" ");
            builder.Append($"at-decimal-places=\"{DecimalPlaces}\" >");
            builder.AppendLine($"</atscada-card></div>");

            return builder.ToString();
        }
    }
}
