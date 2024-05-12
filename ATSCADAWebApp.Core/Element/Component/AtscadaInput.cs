using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element.Component
{
    [Serializable()]
    public class AtscadaInput: IRender, IGrid
    {
        [XmlAttribute("at-content")]
        public string Content { get; set; }

        [XmlAttribute("at-data-tag-name")]
        public string DataTagName { get; set; }       

        [XmlAttribute("at-grid-column")]
        public string GridColumn { get; set; }

        public AtscadaInput()
        {
            Content = "Name";
            DataTagName = "TaskName.TagName";          
            GridColumn = "col-sm-3";
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-input ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" >");            
            builder.AppendLine($"</atscada-input></div>");

            return builder.ToString();
        }
    }
}
