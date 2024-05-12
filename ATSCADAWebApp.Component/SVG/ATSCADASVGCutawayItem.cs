using ATSCADAWebApp.Core;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.SVGCutaway
{
    [Serializable()]
    [XmlType(TypeName = "atscada-SVGCutaway-item")]
    public class ATSCADASVGCutawayItem: BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "SVGCutawayItem";
        private string min = "0";
        private string max = "0";
        private string id2 = "SVGCutawayItem";
        private string content = "SVGCutaway Item";
        private string properties = "Cutaway";

        private string dataTagName = "TaskName.TagName";
        

        #endregion

        #region PROPERTIES

        [XmlAttribute("at-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }
        [XmlAttribute("at-id2")]
        public string ID2
        {
            get => this.id2;
            set => SetField(ref this.id2, value);
        }
        [XmlAttribute("at-min")]
        public string Min
        {
            get => this.min;
            set => SetField(ref this.min, value);
        }
        [XmlAttribute("at-max")]
        public string Max
        {
            get => this.max;
            set => SetField(ref this.max, value);
        }
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADASVGCutawayItem()
        {        
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-svgcutaway-item ");
            builder.Append($"at-content=\"{Name}\" ");
            builder.Append($"at-id2=\"{ID2}\" ");
            builder.Append($"at-min=\"{Min}\" ");
            builder.Append($"at-max=\"{Max}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" ");
            builder.Append($">");            
            builder.AppendLine($"</atscada-svgcutaway-item>");
           

            return builder.ToString();
        }

        #endregion
    }
}
