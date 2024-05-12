using System.Windows.Forms;

namespace ATSCADAWebApp.Component.AlarmReporter
{
    public partial class ATSCADAAlarmReporterEditor : Form
    {
        private readonly ATSCADAAlarmReporter component;

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

        public string Connection
        {
            get => this.txtConnection.Text.Trim();
            set => this.txtConnection.Text = value;
        }

        public string TableName
        {
            get => this.txtTableName.Text.Trim();
            set => this.txtTableName.Text = value;
        }

        public decimal Timeout
        {
            get => this.nudTimeout.Value;
            set => this.nudTimeout.Value = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public ATSCADAAlarmReporterEditor(ATSCADAAlarmReporter component)
        {
            InitializeComponent();
            this.component = component; this.Load += (sender, e) => OnLoad();
            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Content = this.component.Content;
            Connection = this.component.Connection;
            TableName = this.component.TableName;
            Timeout = this.component.Timeout;
            GridColumn = this.component.GridColumn;
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.Connection = Connection;
            this.component.TableName = TableName;
            this.component.Timeout = Timeout;
            this.component.GridColumn = GridColumn;

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
