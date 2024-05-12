using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.GoogleMap
{
    [Serializable()]
    [XmlType(TypeName = "atscada-marker-item")]
    public class ATSCADAMarkerItem: BindableCore, ISupportRender
    {
        #region FILEDS

        private string name = "MarkerItem";

        private string alias = "Marker Item";

        private string paramTagName = "Name=Alias=TaskName.TagName|Name=Alias=TaskName.TagName";

        private string linkUrl = "http://";

        private string locationTagName = "TaskName.TagName";

        private string color = "#008080";

        private string show = "checked";

        private string newTab = "checked";

        private string movable = "checked";

        private string table = "datalog";

        private List<ATSCADAParamItem> items = new List<ATSCADAParamItem>();

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

        [XmlAttribute("at-location-tag-name")]
        public string LocationTagName
        {
            get => this.locationTagName;
            set => SetField(ref this.locationTagName, value);
        }

        [XmlAttribute("at-color")]
        public string Color
        {
            get => this.color;
            set => SetField(ref this.color, value);
        }

        [XmlAttribute("at-show")]
        public string ShowCheckBox
        {
            get => this.show.ToLower();
            set => SetField(ref this.show, value);
        }

        [XmlAttribute("at-movable")]
        public string Movable
        {
            get => this.movable.ToLower();
            set => SetField(ref this.movable, value);
        }

        [XmlAttribute("at-new-tab")]
        public string OpenNewTab
        {
            get => this.newTab.ToLower();
            set => SetField(ref this.newTab, value);
        }

        [XmlAttribute("at-table")]
        public string Table
        {
            get => this.table;
            set => SetField(ref this.table, value);
        }

        [XmlAttribute("at-url")]
        public string LinkUrl
        {
            get => this.linkUrl;
            set => SetField(ref this.linkUrl, value);
        }

        [XmlElement("atscada-param-item")]
        public List<ATSCADAParamItem> Items
        {
            get => this.items;
            set => SetField(ref this.items, value);
        }

        [XmlIgnore]
        public string ParamTagName
        {
            get => this.paramTagName;
            set => SetField(ref this.paramTagName, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAMarkerItem() { }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-marker-item ");
            builder.Append($"at-alias=\"{Alias}\" ");
            builder.Append($"at-location-tag-name=\"{LocationTagName}\" ");
            builder.Append($"at-url=\"{LinkUrl}\" ");
            builder.Append($"at-show=\"{ShowCheckBox}\" ");
            builder.Append($"at-movable=\"{Movable}\" ");
            builder.Append($"at-new-tab=\"{OpenNewTab}\" ");
            builder.Append($"at-table=\"{Table}\" ");
            builder.Append($"at-color=\"{Color}\" >");

            foreach (var item in Items)
                builder.Append(item.Render());

            builder.AppendLine($"</atscada-marker-item>");

            return builder.ToString();
        }

        #endregion
    }
}
