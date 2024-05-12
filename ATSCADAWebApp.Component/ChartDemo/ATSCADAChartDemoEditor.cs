using System.Windows.Forms;

namespace ATSCADAWebApp.Component.ChartDemo
{
    public partial class ATSCADAChartDemoEditor : Form
    {
        private readonly ATSCADAChartDemo component;

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

        public string DataTagName
        {
            get => this.cbxDataTagName.TagName.Trim();
            set => this.cbxDataTagName.TagName = value;
        }

        public string Color
        {
            get => this.txtColor.Color;
            set => this.txtColor.Color = value;
        }

        public new string Icon
        {
            get => this.txtIcon.Text.Trim();
            set => this.txtIcon.Text = value;
        }

        public decimal DecimalPlaces
        {
            get => this.nudDecimalPlaces.Value;
            set => this.nudDecimalPlaces.Value = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public ATSCADAChartDemoEditor(ATSCADAChartDemo component)
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
            DataTagName = this.component.DataTagName;
            Color = this.component.Color;
            Icon = this.component.Icon;
            DecimalPlaces = this.component.DecimalPlaces;
            GridColumn = this.component.GridColumn;
        }       

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.DataTagName = DataTagName;
            this.component.Color = Color;
            this.component.Icon = Icon;
            this.component.DecimalPlaces = DecimalPlaces;
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
