using System.Windows.Forms;

namespace ATSCADAWebApp.Component.PIDStation
{
    public partial class ATSCADAPIDStationEditor : Form
    {
        private readonly ATSCADAPIDStation component;

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

        public string Pressure3Tag
        {
            get => this.cbxTag_Pressure3.TagName.Trim();
            set => this.cbxTag_Pressure3.TagName = value;
        }
        public string Pressure4Tag
        {
            get => this.cbxTag_Pressure4.TagName.Trim();
            set => this.cbxTag_Pressure4.TagName = value;
        }
        public string LowAlarmValue1
        {
            get => this.cbxTag_alarmLowValue1.TagName.Trim();
            set => this.cbxTag_alarmLowValue1.TagName = value;
        }
        public string LowAlarmValue2
        {
            get => this.cbxTag_alarmLowValue2.TagName.Trim();
            set => this.cbxTag_alarmLowValue2.TagName = value;
        }
        public string LowAlarmValue3
        {
            get => this.cbxTag_alarmLowValue3.TagName.Trim();
            set => this.cbxTag_alarmLowValue3.TagName = value;
        }
        public string LowAlarmValue4
        {
            get => this.cbxTag_alarmLowValue4.TagName.Trim();
            set => this.cbxTag_alarmLowValue4.TagName = value;
        }
        public string HighAlarmValue1
        {
            get => this.cbxTag_alarmHighValue1.TagName.Trim();
            set => this.cbxTag_alarmHighValue1.TagName = value;

        }
        public string HighAlarmValue2
        {
            get => this.cbxTag_alarmHighValue2.TagName.Trim();
            set => this.cbxTag_alarmHighValue2.TagName = value;

        }
        public string HighAlarmValue3
        {
            get => this.cbxTag_alarmHighValue3.TagName.Trim();
            set => this.cbxTag_alarmHighValue3.TagName = value;

        }
        public string HighAlarmValue4
        {
            get => this.cbxTag_alarmHighValue4.TagName.Trim();
            set => this.cbxTag_alarmHighValue4.TagName = value;

        }
        #endregion
        public ATSCADAPIDStationEditor(ATSCADAPIDStation component)
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
            Pressure3Tag = this.component.Pressure3Tag;
            Pressure4Tag = this.component.Pressure4Tag;
            HighAlarmValue1 = this.component.HighAlarmValue1;
            HighAlarmValue2 = this.component.HighAlarmValue2;
            HighAlarmValue3 = this.component.HighAlarmValue3;
            HighAlarmValue4 = this.component.HighAlarmValue4;
            LowAlarmValue1 = this.component.LowAlarmValue1;
            LowAlarmValue2 = this.component.LowAlarmValue2;
            LowAlarmValue3 = this.component.LowAlarmValue3;
            LowAlarmValue4 = this.component.LowAlarmValue4;
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
            this.component.Pressure3Tag = Pressure3Tag;
            this.component.Pressure4Tag = Pressure4Tag;
            this.component.HighAlarmValue1= HighAlarmValue1 ;
            this.component.HighAlarmValue2= HighAlarmValue2 ;
            this.component.HighAlarmValue3= HighAlarmValue3 ;
            this.component.HighAlarmValue4= HighAlarmValue4 ;
            this.component.LowAlarmValue1 = LowAlarmValue1;
            this.component.LowAlarmValue2 = LowAlarmValue2;
            this.component.LowAlarmValue3 = LowAlarmValue3;
            this.component.LowAlarmValue4 = LowAlarmValue4;

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
