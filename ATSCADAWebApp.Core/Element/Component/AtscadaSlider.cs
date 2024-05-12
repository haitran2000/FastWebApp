using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaSlider : IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-data-tag-name")]
        public string DataTagName { get; set; }

        [XmlAttribute("at-min")]
        public double Min { get; set; }

        [XmlAttribute("at-max")]
        public double Max { get; set; }

        [XmlAttribute("at-skin")]
        public string Skin { get; set; }

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaSlider()
        {
            Content = "Name";
            DataTagName = "TaskName.TagName";
            Min = 0;
            Max = 100;
            Skin = "big";
            GridColumn = "col-sm-3";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-slider ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($"at-min=\"{Min}\" ");
            builder.Append($"at-max=\"{Max}\" ");
            builder.Append($"at-skin=\"{Skin}\" >");
            builder.AppendLine($"</atscada-slider></div>");

            return builder.ToString();
        }
    }
}
