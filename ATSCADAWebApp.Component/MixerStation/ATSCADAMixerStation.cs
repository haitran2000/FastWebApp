using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Component.MixerStation
{
    [DisplayName("iMixerStation")]
    [Serializable()]
    [XmlType(TypeName = "atscada-mixer-station")]

    public class ATSCADAMixerStation : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FIELDS

        private string content = "Name";

        private string gridColumn = "col-sm-12";

        private string pressure1Tag = "TaskName.TagName";

        private string pressure2Tag = "TaskName.TagName";

        private string temp1Tag = "TaskName.TagName";

        private string temp2Tag = "TaskName.TagName";

        private string flow1Tag = "TaskName.TagName";

        private string flow2Tag = "TaskName.TagName";

        private string percentTag = "TaskName.TagName";

        private string pipeRatioTag = "TaskName.TagName";

        private string heatTempTag = "TaskName.TagName";

        private string highpressure1Tag = "TaskName.TagName";

        private string lowpressure1Tag = "TaskName.TagName";

        private string highpressure2Tag = "TaskName.TagName";

        private string lowpressure2Tag = "TaskName.TagName";

        private string highTemp1Tag = "TaskName.TagName";

        private string lowTemp1Tag = "TaskName.TagName";

        private string highTemp2Tag = "TaskName.TagName";

        private string lowTemp2Tag = "TaskName.TagName";

        private string highFlow1Tag = "TaskName.TagName";

        private string lowFlow1Tag = "TaskName.TagName";

        private string highFlow2Tag = "TaskName.TagName";

        private string lowFlow2Tag = "TaskName.TagName";

        private string highPipeRatioTag = "TaskName.TagName";

        private string lowPipeRatioTag = "TaskName.TagName";

        private string highHeatTempTag = "TaskName.TagName";

        private string lowHeatTempTag = "TaskName.TagName";

        private string alarmPidTag = "TaskName.TagName";

        private string alarmMixerTag = "TaskName.TagName";

        private string alarmPruTag = "TaskName.TagName";

        #endregion

        #region PROPERTIES

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

        [XmlAttribute("at-temp-1")]
        public string Temp1Tag
        {
            get => this.temp1Tag;
            set => SetField(ref this.temp1Tag, value);
        }

        [XmlAttribute("at-temp-2")]
        public string Temp2Tag
        {
            get => this.temp2Tag;
            set => SetField(ref this.temp2Tag, value);
        }

        [XmlAttribute("at-flow-1")]
        public string Flow1Tag
        {
            get => this.flow1Tag;
            set => SetField(ref this.flow1Tag, value);
        }

        [XmlAttribute("at-flow-2")]
        public string Flow2Tag
        {
            get => this.flow2Tag;
            set => SetField(ref this.flow2Tag, value);
        }

        [XmlAttribute("at-pipe-ratio")]
        public string PipeRatioTag
        {
            get => this.percentTag;
            set => SetField(ref this.percentTag, value);
        }

        [XmlAttribute("at-percent")]
        public string PercentTag
        {
            get => this.pipeRatioTag;
            set => SetField(ref this.pipeRatioTag, value);
        }

        [XmlAttribute("at-heat-temp")]
        public string HeatTempTag
        {
            get => this.heatTempTag;
            set => SetField(ref this.heatTempTag, value);
        }

        #endregion

        #region ALARM TAGS

        [XmlAttribute("at-high-pres-1")]
        public string HighPressure1Tag
        {
            get => this.highpressure1Tag;
            set => SetField(ref this.highpressure1Tag, value);
        }

        [XmlAttribute("at-low-pres-1")]
        public string LowPressure1Tag
        {
            get => this.lowpressure1Tag;
            set => SetField(ref this.lowpressure1Tag, value);
        }

        [XmlAttribute("at-high-pres-2")]
        public string HighPressure2Tag
        {
            get => this.highpressure2Tag;
            set => SetField(ref this.highpressure2Tag, value);
        }

        [XmlAttribute("at-low-pres-2")]
        public string LowPressure2Tag
        {
            get => this.lowpressure2Tag;
            set => SetField(ref this.lowpressure2Tag, value);
        }

        [XmlAttribute("at-high-temp-1")]
        public string HighTemp1Tag
        {
            get => this.highTemp1Tag;
            set => SetField(ref this.highTemp1Tag, value);
        }

        [XmlAttribute("at-low-temp-1")]
        public string LowTemp1Tag
        {
            get => this.lowTemp1Tag;
            set => SetField(ref this.lowTemp1Tag, value);
        }

        [XmlAttribute("at-high-temp-2")]
        public string HighTemp2Tag
        {
            get => this.highTemp2Tag;
            set => SetField(ref this.highTemp2Tag, value);
        }

        [XmlAttribute("at-low-temp-2")]
        public string LowTemp2Tag
        {
            get => this.lowTemp2Tag;
            set => SetField(ref this.lowTemp2Tag, value);
        }

        [XmlAttribute("at-high-flow-1")]
        public string HighFlow1Tag
        {
            get => this.highFlow1Tag;
            set => SetField(ref this.highFlow1Tag, value);
        }

        [XmlAttribute("at-low-flow-1")]
        public string LowFlow1Tag
        {
            get => this.lowFlow1Tag;
            set => SetField(ref this.lowFlow1Tag, value);
        }

        [XmlAttribute("at-high-flow-2")]
        public string HighFlow2Tag
        {
            get => this.highFlow2Tag;
            set => SetField(ref this.highFlow2Tag, value);
        }

        [XmlAttribute("at-low-flow-2")]
        public string LowFlow2Tag
        {
            get => this.lowFlow2Tag;
            set => SetField(ref this.lowFlow2Tag, value);
        }

        [XmlAttribute("at-high-pipe-ratio")]
        public string HighPipeRatioTag
        {
            get => this.highPipeRatioTag;
            set => SetField(ref this.highPipeRatioTag, value);
        }

        [XmlAttribute("at-low-pipe-ratio")]
        public string LowPipeRatioTag
        {
            get => this.lowPipeRatioTag;
            set => SetField(ref this.lowPipeRatioTag, value);
        }

        [XmlAttribute("at-high-heat-temp")]
        public string HighHeatTempTag
        {
            get => this.highHeatTempTag;
            set => SetField(ref this.highHeatTempTag, value);
        }

        [XmlAttribute("at-low-heat-temp")]
        public string LowHeatTempTag
        {
            get => this.lowHeatTempTag;
            set => SetField(ref this.lowHeatTempTag, value);
        }

        [XmlAttribute("at-alarm-pid")]
        public string AlarmPID
        {
            get => this.alarmPidTag;
            set => SetField(ref this.alarmPidTag, value);
        }

        [XmlAttribute("at-alarm-mixer")]
        public string AlarmMixer
        {
            get => this.alarmMixerTag;
            set => SetField(ref this.alarmMixerTag, value);
        }

        [XmlAttribute("at-alarm-pru")]
        public string AlarmPRU
        {
            get => this.alarmPruTag;
            set => SetField(ref this.alarmPruTag, value);
        }

        #endregion

        #endregion

        #region CONSTRUCTORS

        public ATSCADAMixerStation()
           : base()
        {
            Name = "NewMixerStation";
            Description = "Mixer Station - ATSCADA Web Component";
        }

        public ATSCADAMixerStation(IComposite parent)
           : base(parent)
        {
            Name = "NewMixerStation";
            Description = "Mixer Station - ATSCADA Web Component";
        }

        public ATSCADAMixerStation(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Mixer Station - ATSCADA Web Component";
        }

        public override bool Update()
        {
            return new ATSCADAMixerStationEditor(this).ShowDialog() == DialogResult.OK;
        }

        #endregion

        #region METHODS

        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-mixer-station ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-pressure-1=\"{Pressure1Tag}\" ");
            builder.Append($"at-pressure-2=\"{Pressure2Tag}\" ");
            builder.Append($"at-temp-1=\"{Temp1Tag}\" ");
            builder.Append($"at-temp-2=\"{Temp2Tag}\" ");
            builder.Append($"at-flow-1=\"{Flow1Tag}\" ");
            builder.Append($"at-flow-2=\"{Flow2Tag}\" ");
            builder.Append($"at-pipe-ratio=\"{PipeRatioTag}\" ");
            builder.Append($"at-percent=\"{PercentTag}\" ");
            builder.Append($"at-heat-temp=\"{HeatTempTag}\" ");

            builder.Append($"at-high-pres-1=\"{HighPressure1Tag}\" ");
            builder.Append($"at-low-pres-1=\"{LowPressure1Tag}\" ");
            builder.Append($"at-high-pres-2=\"{HighPressure2Tag}\" ");
            builder.Append($"at-low-pres-2=\"{LowPressure2Tag}\" ");
            builder.Append($"at-high-temp-1=\"{HighTemp1Tag}\" ");
            builder.Append($"at-low-temp-1=\"{LowTemp1Tag}\" ");
            builder.Append($"at-high-temp-2=\"{HighTemp2Tag}\" ");
            builder.Append($"at-low-temp-2=\"{LowTemp2Tag}\" ");
            builder.Append($"at-high-flow-1=\"{HighFlow1Tag}\" ");
            builder.Append($"at-low-flow-1=\"{LowFlow1Tag}\" ");
            builder.Append($"at-high-flow-2=\"{HighFlow2Tag}\" ");
            builder.Append($"at-low-flow-2=\"{LowFlow2Tag}\" ");
            builder.Append($"at-high-pipe-ratio=\"{HighPipeRatioTag}\" ");
            builder.Append($"at-low-pipe-ratio=\"{LowPipeRatioTag}\" ");
            builder.Append($"at-high-heat-temp=\"{HighHeatTempTag}\" ");
            builder.Append($"at-low-heat-temp=\"{LowHeatTempTag}\" ");

            builder.Append($"at-alarm-pid=\"{AlarmPID}\" ");
            builder.Append($"at-alarm-mixer=\"{AlarmMixer}\" ");
            builder.Append($"at-alarm-pru=\"{AlarmPRU}\" >");

            builder.AppendLine($"</atscada-mixer-station></div>");

            return builder.ToString();
        }

        #endregion
    }
}
