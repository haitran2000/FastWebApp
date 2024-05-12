using ATSCADAWebApp.Core.Element.Component;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element
{
    [Serializable()]
    public class AtscadaSettingsView : IRender
    {
        [XmlAttribute("at-interval")]
        public int Interval { get; set; }

        [XmlAttribute("at-max-number-of-write")]
        public int MaxNumberOfWrite { get; set; }

        [XmlAttribute("at-timeout")]
        public int Timeout { get; set; }

        [XmlArray("atscada-sliders")]
        [XmlArrayItem("atscada-slider", typeof(AtscadaSlider))]
        public List<AtscadaSlider> AtscadaSliders { get; set; }

        [XmlArray("atscada-inputs")]
        [XmlArrayItem("atscada-input", typeof(AtscadaInput))]
        public List<AtscadaInput> AtscadaInputs { get; set; }       

        public AtscadaSettingsView()
        {
            AtscadaSliders = new List<AtscadaSlider>();
            AtscadaInputs = new List<AtscadaInput>();           

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
            foreach (var slider in AtscadaSliders)
                builder.Append(slider.Render());
            builder.AppendLine($"</div>");

            builder.AppendLine($"<div class=\"row\">");
            foreach (var input in AtscadaInputs)
                builder.Append(input.Render());
            builder.AppendLine($"</div>");            

            builder.AppendLine($"</atscada-data-task>");

            return builder.ToString();
        }
    }
}
