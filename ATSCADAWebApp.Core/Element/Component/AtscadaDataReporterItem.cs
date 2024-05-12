using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaDataReporterItem : IRender
    {
        [XmlAttribute("at-alias")]
        public string Alias { get; set; }        

        public AtscadaDataReporterItem()
        {
            Alias = "Alias";           
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-data-reporter-item ");           
            builder.Append($"at-alias=\"{Alias}\" >");
            builder.AppendLine($"</atscada-data-reporter-item>");

            return builder.ToString();
        }
    }
}
