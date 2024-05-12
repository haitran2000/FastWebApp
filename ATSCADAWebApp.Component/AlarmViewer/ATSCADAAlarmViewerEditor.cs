using System.Windows.Forms;

namespace ATSCADAWebApp.Component.AlarmViewer
{
    public partial class ATSCADAAlarmViewerEditor : Form
    {
        private readonly ATSCADAAlarmViewer component;

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

        public decimal Limit
        {
            get => this.nudLimit.Value;
            set => this.nudLimit.Value = value;
        }

        public decimal Interval
        {
            get => this.nudInterval.Value;
            set => this.nudInterval.Value = value;
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

        public ATSCADAAlarmViewerEditor(ATSCADAAlarmViewer component)
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
            Connection = this.component.Connection;
            TableName = this.component.TableName;
            Limit = this.component.Limit;
            Interval = this.component.Interval;
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
            this.component.Limit = Limit;
            this.component.Interval = Interval;
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
