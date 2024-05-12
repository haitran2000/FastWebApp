using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Component.PIDStation
{
    [DisplayName("iSCDemo")]
    [Serializable()]
    [XmlType(TypeName = "atscada-pid-station")]

    public class ATSCADAPIDStation : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FIELDS

        private string content = "Name";

        private string gridColumn = "col-sm-12";

        private string pressure1Tag = "TaskName.TagName";

        private string pressure2Tag = "TaskName.TagName";

        private string pressure3Tag = "TaskName.TagName";
        private string pressure4Tag = "TaskName.TagName";
        private string highAlarmValue1 = "TaskName.TagName";
        private string highAlarmValue2 = "TaskName.TagName";
        private string highAlarmValue3 = "TaskName.TagName";
        private string highAlarmValue4 = "TaskName.TagName";
        private string lowAlarmValue1= "TaskName.TagName";
        private string lowAlarmValue2 = "TaskName.TagName";
        private string lowAlarmValue3 = "TaskName.TagName";
        private string lowAlarmValue4 = "TaskName.TagName";


        #endregion
        #region DEFAULT

        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        [XmlAttribute("at-grid-column")]
        public string GridColumn
        {
            get => this.gridColumn;
            set => SetField(ref this.gridColumn, value);
        }

        #endregion
        #region SENSOR TAGS

        [XmlAttribute("at-pressure-1")]
        public string Pressure1Tag
        {
            get => this.pressure1Tag;
            set => SetField(ref this.pressure1Tag, value);
        }

        [XmlAttribute("at-pressure-2")]
        public string Pressure2Tag
        {
            get => this.pressure2Tag;
            set => SetField(ref this.pressure2Tag, value);
        }

        [XmlAttribute("at-pressure-3")]
        public string Pressure3Tag
        {
            get => this.pressure3Tag;
            set => SetField(ref this.pressure3Tag, value);
        }
        [XmlAttribute("at-pressure-4")]
        public string Pressure4Tag
        {
            get => this.pressure4Tag;
            set => SetField(ref this.pressure4Tag, value);
        }
        [XmlAttribute("at-highalarm-1")]
        public string HighAlarmValue1
        {
            get => this.highAlarmValue1;
            set => SetField(ref this.highAlarmValue1, value);
        }
        [XmlAttribute("at-highalarm-2")]
        public string HighAlarmValue2
        {
            get => this.highAlarmValue2;
            set => SetField(ref this.highAlarmValue2, value);
        }
        [XmlAttribute("at-highalarm-3")]
        public string HighAlarmValue3
        {
            get => this.highAlarmValue3;
            set => SetField(ref this.highAlarmValue3, value);
        }
        [XmlAttribute("at-highalarm-4")]
        public string HighAlarmValue4
        {
            get => this.highAlarmValue4;
            set => SetField(ref this.highAlarmValue4, value);
        }
        [XmlAttribute("at-lowalarm-1")]
        public string LowAlarmValue1
        {
            get => this.lowAlarmValue1;
            set => SetField(ref this.lowAlarmValue1, value);
        }
        [XmlAttribute("at-lowalarm-2")]
        public string LowAlarmValue2
        {
            get => this.lowAlarmValue2;
            set => SetField(ref this.lowAlarmValue2, value);
        }
        [XmlAttribute("at-lowalarm-3")]
        public string LowAlarmValue3
        {
            get => this.lowAlarmValue3;
            set => SetField(ref this.lowAlarmValue3, value);
        }
        [XmlAttribute("at-lowalarm-4")]
        public string LowAlarmValue4
        {
            get => this.lowAlarmValue4;
            set => SetField(ref this.lowAlarmValue4, value);
        }
        #endregion
        #region CONSTRUCTORS

        public ATSCADAPIDStation()
           : base()
        {
            Name = "Demo";
            Description = "Demo - ATSCADA Web Component";
        }

        public ATSCADAPIDStation(IComposite parent)
           : base(parent)
        {
            Name = "Demo";
            Description = "Demo - ATSCADA Web Component";
        }

        public ATSCADAPIDStation(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Demo - ATSCADA Web Component";
        }

        public override bool Update()
        {
            return new ATSCADAPIDStationEditor(this).ShowDialog() == DialogResult.OK;
        }

        #endregion
        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-pid-station ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-pressure-1=\"{Pressure1Tag}\" ");
            builder.Append($"at-pressure-2=\"{Pressure2Tag}\" ");
            builder.Append($"at-pressure-3=\"{Pressure3Tag}\" ");
            builder.Append($"at-pressure-4=\"{Pressure4Tag}\" ");
            builder.Append($"at-highalarm-1=\"{HighAlarmValue1}\" ");
            builder.Append($"at-highalarm-2=\"{HighAlarmValue2}\" ");
            builder.Append($"at-highalarm-3=\"{HighAlarmValue3}\" ");
            builder.Append($"at-highalarm-4=\"{HighAlarmValue4}\" ");
            builder.Append($"at-lowalarm-1=\"{LowAlarmValue1}\" ");
            builder.Append($"at-lowalarm-2=\"{LowAlarmValue2}\" ");
            builder.Append($"at-lowalarm-3=\"{LowAlarmValue3}\" ");
            builder.Append($"at-lowalarm-4=\"{LowAlarmValue4}\" ");


            builder.AppendLine($"</atscada-pid-station></div>");

            return builder.ToString();
        }

        #endregion
    }
}
