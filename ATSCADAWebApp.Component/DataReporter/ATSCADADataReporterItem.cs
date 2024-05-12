using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.DataReporter
{
    [Serializable()]
    [XmlType(TypeName = "atscada-data-report-item")]
    public class ATSCADADataReporterItem : BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "DataReporterItem";

        private string alias = "Alias";

        private string color = "#008080";

        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }

        [XmlAttribute("at-alias")]
        public string Alias
        {
            get => this.alias;
            set => SetField(ref this.alias, value);
        }

        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }

        #endregion

        public ATSCADADataReporterItem()
        {           
        }        

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-data-reporter-item ");
            builder.Append($"at-alias=\"{Alias}\" ");          
            builder.Append($"at-color=\"{Color}\" >");
            builder.AppendLine($"</atscada-data-reporter-item>");

            return builder.ToString();
        }        
    }
}
