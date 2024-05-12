using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.GoogleMap
{
    [DisplayName("iGoogleMap")]
    [Serializable()]
    [XmlType(TypeName = "atscada-google-map")]
    public class ATSCADAGoogleMap : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FIELDS

        private string content = "ATSCADA Google Map";

        private string applicationName = "DemoMap";

        private string connection = "atscada";

        private string height = "300px";

        private string gridColumn = "col-sm-12";

        private string apikey = "";

        private List<ATSCADAMarkerItem> items = new List<ATSCADAMarkerItem>();

        #endregion

        #region PROPERTIES

        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        [XmlAttribute("at-application-name")]
        public string Application
        {
            get => this.applicationName;
            set => SetField(ref this.applicationName, value);
        }

        [XmlAttribute("at-connection")]
        public string Connection
        {
            get => this.connection;
            set => SetField(ref this.connection, value);
        }

        [XmlAttribute("at-height")]
        public string Height
        {
            get => this.height;
            set => SetField(ref this.height, value);
        }

        [XmlAttribute("at-grid-column")]
        public string GridColumn
        {
            get => this.gridColumn;
            set => SetField(ref this.gridColumn, value);
        }

        [XmlAttribute("at-api-key")]
        public string KeyAPI
        {
            get => this.apikey;
            set => SetField(ref this.apikey, value);
        }

        [XmlElement("atscada-marker-item")]
        public List<ATSCADAMarkerItem> Items
        {
            get => this.items;
            set => SetField(ref this.items, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAGoogleMap() : base()
        {
            Name = "NewGoogleMap";
            Description = $"GoogleMap - ATSCADA Web Component";
        }

        public ATSCADAGoogleMap(IComposite parent) : base(parent)
        {
            Name = "NewGoogleMap";
            Description = "GoogleMap - ATSCADA Web Component";
        }

        public ATSCADAGoogleMap(string name, IComposite parent) : base(name, parent)
        {
            Description = "GoogleMap - ATSCADA Web Component";
        }

        #endregion

        #region METHODS       

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-google-map ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-application-name=\"{Application}\" ");
            builder.Append($"at-connection=\"{Connection}\" ");
            builder.Append($"at-height=\"{Height}\" ");
            builder.Append($"at-api-key=\"{KeyAPI}\" >");

            foreach (var item in Items)
                builder.Append(item.Render());

            builder.AppendLine($"</atscada-google-map></div>");

            return builder.ToString();
        }

        public override bool Update()
        {
            return new ATSCADAGoogleMapEditor(this).ShowDialog() == DialogResult.OK;
        }

        #endregion
    }
}
