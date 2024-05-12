using System.Windows.Forms;

namespace ATSCADAWebApp.Component.MixerStation
{
    public partial class ATSCADAMixerStationEditor : Form
    {
        private readonly ATSCADAMixerStation component;

        #region DEFAULT
     
        public string ComponentName
        {
            get => this.txtName.Text.Trim();
            set => this.txtName.Text = value;
        }

        public string Description
        {
            get => this.txtDescription.Text.Trim();
            set => this.txtDescription.Text = value;
        }

        public string Content
        {
            get => this.txtContent.Text.Trim();
            set => this.txtContent.Text = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        #endregion

        #region SENSOR TAGS

        public string Pressure1Tag
        {
            get => this.cbxTag_Pressure1.TagName.Trim();
            set => this.cbxTag_Pressure1.TagName = value;
        }

        public string Pressure2Tag
        {
            get => this.cbxTag_Pressure2.TagName.Trim();
            set => this.cbxTag_Pressure2.TagName = value;
        }

        public string Temp1Tag
        {
            get => this.cbxTag_Temp1.TagName.Trim();
            set => this.cbxTag_Temp1.TagName = value;
        }

        public string Temp2Tag
        {
            get => this.cbxTag_Temp2.TagName.Trim();
            set => this.cbxTag_Temp2.TagName = value;
        }

        public string Flow1Tag
        {
            get => this.cbxTag_Flow1.TagName.Trim();
            set => this.cbxTag_Flow1.TagName = value;
        }

        public string Flow2Tag
        {
            get => this.cbxTag_Flow2.TagName.Trim();
            set => this.cbxTag_Flow2.TagName = value;
        }

        public string PipeRatioTag
        {
            get => this.cbxTag_PipeRatio.TagName.Trim();
            set => this.cbxTag_PipeRatio.TagName = value;
        }

        public string PercentTag
        {
            get => this.cbxTag_Percent.TagName.Trim();
            set => this.cbxTag_Percent.TagName = value;
        }

        public string HeatTempTag
        {
            get => this.cbxTag_HeatTemp.TagName.Trim();
            set => this.cbxTag_HeatTemp.TagName = value;
        }

        #endregion

        #region ALARM STATION TAGs

        public string HighPressure1Tag
        {
            get => this.cbxTag_HighPressure1.TagName.Trim();
            set => this.cbxTag_HighPressure1.TagName = value;
        }

        public string LowPressure1Tag
        {
            get => this.cbxTag_LowPressure1.TagName.Trim();
            set => this.cbxTag_LowPressure1.TagName = value;
        }

        public string HighPressure2Tag
        {
            get => this.cbxTag_HighPressure2.TagName.Trim();
            set => this.cbxTag_HighPressure2.TagName = value;
        }

        public string LowPressure2Tag
        {
            get => this.cbxTag_LowPressure2.TagName.Trim();
            set => this.cbxTag_LowPressure2.TagName = value;
        }

        public string HighTemp1Tag
        {
            get => this.cbxTag_HighTemp1.TagName.Trim();
            set => this.cbxTag_HighTemp1.TagName = value;
        }

        public string LowTemp1Tag
        {
            get => this.cbxTag_LowTemp1.TagName.Trim();
            set => this.cbxTag_LowTemp1.TagName = value;
        }

        public string HighTemp2Tag
        {
            get => this.cbxTag_HighTemp2.TagName.Trim();
            set => this.cbxTag_HighTemp2.TagName = value;
        }

        public string LowTemp2Tag
        {
            get => this.cbxTag_LowTemp2.TagName.Trim();
            set => this.cbxTag_LowTemp2.TagName = value;
        }

        public string HighFlow1Tag
        {
            get => this.cbxTag_HighFlow1.TagName.Trim();
            set => this.cbxTag_HighFlow1.TagName = value;
        }

        public string LowFlow1Tag
        {
            get => this.cbxTag_LowFlow1.TagName.Trim();
            set => this.cbxTag_LowFlow1.TagName = value;
        }

        public string HighFlow2Tag
        {
            get => this.cbxTag_HighFlow2.TagName.Trim();
            set => this.cbxTag_HighFlow2.TagName = value;
        }

        public string LowFlow2Tag
        {
            get => this.cbxTag_LowFlow2.TagName.Trim();
            set => this.cbxTag_LowFlow2.TagName = value;
        }

        public string HighPipeRatioTag
        {
            get => this.cbxTag_HighPipe.TagName.Trim();
            set => this.cbxTag_HighPipe.TagName = value;
        }

        public string LowPipeRatioTag
        {
            get => this.cbxTag_LowPipe.TagName.Trim();
            set => this.cbxTag_LowPipe.TagName = value;
        }

        public string HighHeatTempTag
        {
            get => this.cbxTag_HighHeat.TagName.Trim();
            set => this.cbxTag_HighHeat.TagName = value;
        }

        public string LowHeatTempTag
        {
            get => this.cbxTag_LowHeat.TagName.Trim();
            set => this.cbxTag_LowHeat.TagName = value;
        }

        #endregion

        #region ALARM TOTAL TAGs

        public string AlarmPID
        {
            get => this.cbxTag_alarmPID.TagName.Trim();
            set => this.cbxTag_alarmPID.TagName = value;
        }

        public string AlarmMixer
        {
            get => this.cbxTag_alarmMixer.TagName.Trim();
            set => this.cbxTag_alarmMixer.TagName = value;
        }

        public string AlarmPRU
        {
            get => this.cbxTag_alarmPRU.TagName.Trim();
            set => this.cbxTag_alarmPRU.TagName = value;
        }

        #endregion

        public ATSCADAMixerStationEditor(ATSCADAMixerStation component)
        {
            InitializeComponent();

            this.component = component;
            this.Load += (sender, e) => OnLoad();
            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Content = this.component.Content;
            GridColumn = this.component.GridColumn;
            Pressure1Tag = this.component.Pressure1Tag;
            Pressure2Tag = this.component.Pressure2Tag;
            Temp1Tag = this.component.Temp1Tag;
            Temp2Tag = this.component.Temp2Tag;           
            Flow1Tag = this.component.Flow1Tag;
            Flow2Tag = this.component.Flow2Tag;
            PipeRatioTag = this.component.PipeRatioTag;
            PercentTag = this.component.PercentTag;
            HeatTempTag = this.component.HeatTempTag;

            HighPressure1Tag = this.component.HighPressure1Tag;
            LowPressure1Tag = this.component.LowPressure1Tag;
            HighPressure2Tag = this.component.HighPressure2Tag;
            LowPressure2Tag = this.component.LowPressure2Tag;
            HighTemp1Tag = this.component.HighTemp1Tag;
            LowTemp1Tag = this.component.LowTemp1Tag;
            HighTemp2Tag = this.component.HighTemp2Tag;
            LowTemp2Tag = this.component.LowTemp2Tag;
            HighFlow1Tag = this.component.HighFlow1Tag;
            LowFlow1Tag = this.component.LowFlow1Tag;
            HighFlow2Tag = this.component.HighFlow2Tag;
            LowFlow2Tag = this.component.LowFlow2Tag;

            HighPipeRatioTag = this.component.HighPipeRatioTag;
            LowPipeRatioTag = this.component.LowPipeRatioTag;
            HighHeatTempTag = this.component.HighHeatTempTag;
            LowHeatTempTag = this.component.LowHeatTempTag;

            AlarmPID = this.component.AlarmPID;
            AlarmMixer = this.component.AlarmMixer;
            AlarmPRU = this.component.AlarmPRU;
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.GridColumn = GridColumn;
            this.component.Pressure1Tag = Pressure1Tag;
            this.component.Pressure2Tag = Pressure2Tag;
            this.component.Temp1Tag = Temp1Tag;
            this.component.Temp2Tag = Temp2Tag;           
            this.component.Flow1Tag = Flow1Tag;           
            this.component.Flow2Tag = Flow2Tag;
            this.component.PipeRatioTag = PipeRatioTag;
            this.component.PercentTag = PercentTag;
            this.component.HeatTempTag = HeatTempTag;

            this.component.HighPressure1Tag = HighPressure1Tag;
            this.component.LowPressure1Tag = LowPressure1Tag;
            this.component.HighPressure2Tag = HighPressure2Tag;
            this.component.LowPressure2Tag = LowPressure2Tag;
            this.component.HighTemp1Tag = HighTemp1Tag;
            this.component.LowTemp1Tag = LowTemp1Tag;
            this.component.HighTemp2Tag = HighTemp2Tag;
            this.component.LowTemp2Tag = LowTemp2Tag;
            this.component.HighFlow1Tag = HighFlow1Tag;
            this.component.LowFlow1Tag = LowFlow1Tag;
            this.component.HighFlow2Tag = HighFlow2Tag;
            this.component.LowFlow2Tag = LowFlow2Tag;

            this.component.HighPipeRatioTag = HighPipeRatioTag;
            this.component.LowPipeRatioTag = LowPipeRatioTag;
            this.component.HighHeatTempTag = HighHeatTempTag;
            this.component.LowHeatTempTag = LowHeatTempTag;

            this.component.AlarmPID = AlarmPID;
            this.component.AlarmMixer = AlarmMixer;
            this.component.AlarmPRU = AlarmPRU;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckProperties()
        {
            if (string.IsNullOrEmpty(ComponentName))
            {
                MessageBox.Show("Property 'Name' must not be null or empty",
                    "ATSCADA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            return true;
        }
    }
}
