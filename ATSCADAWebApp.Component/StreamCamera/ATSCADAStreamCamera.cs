using ATSCADAWebApp.Core;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.StreamCamera
{
    [DisplayName("iStreamCamera")]
    [Serializable()]
    [XmlType(TypeName = "atscada-stream-camera")]
    public class ATSCADAStreamCamera : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FIELDS

        private string content = "Camera";

        private string connection = "camera";

        private string network = "Cloud";

        private string frame = "vjs-fluid";

        private string gridColumn = "col-sm-12";

        private string tokenTime = "300";

        #endregion

        #region PROPERTIES

        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        [XmlAttribute("at-connection")]
        public string Connection
        {
            get => this.connection;
            set => SetField(ref this.connection, value);
        }

        [XmlAttribute("at-network")]
        public string Network
        {
            get => this.network;
            set => SetField(ref this.network, value);
        }      

        [XmlAttribute("at-frame-size")]
        public string Frame
        {
            get => this.frame;
            set => SetField(ref this.frame, value);
        }

        [XmlAttribute("at-grid-column")]
        public string GridColumn
        {
            get => this.gridColumn;
            set => SetField(ref this.gridColumn, value);
        }

        [XmlAttribute("at-token-time")]
        public string TokenTime
        {
            get => this.tokenTime;
            set => SetField(ref this.tokenTime, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAStreamCamera() : base()
        {
            Name = "NewStreamCamera";
            Description = $"StreamCamera - ATSCADA Web Component.{Environment.NewLine}Current version only supports for Imou IP Camera.{Environment.NewLine}For more information please contact our website: https://atscada.com/";
        }

        public ATSCADAStreamCamera(IComposite parent) : base(parent)
        {
            Name = "NewStreamCamera";
            Description = "StreamCamera - ATSCADA Web Component";
        }

        public ATSCADAStreamCamera(string name, IComposite parent) : base(name, parent)
        {
            Description = "StreamCamera - ATSCADA Web Component";
        }

        #endregion

        #region METHODS
        
        public override bool Update()
        {
            return new ATSCADAStreamCameraEditor(this).ShowDialog() == DialogResult.OK;
        }

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-stream-camera ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-connection=\"{Connection}\" ");
            builder.Append($"at-network=\"{Network}\" ");
            builder.Append($"at-token-time=\"{TokenTime}\" ");
            builder.Append($"at-frame-size=\"{Frame}\" ");
            builder.AppendLine($"</atscada-stream-camera></div>");

            return builder.ToString();
        }

        #endregion
    }
}
