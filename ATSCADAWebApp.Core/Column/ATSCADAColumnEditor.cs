using System.Windows.Forms;

namespace ATSCADAWebApp.Core
{
    public partial class ATSCADAColumnEditor : Form
    {
        private readonly ATSCADAColumn component;

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
        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public ATSCADAColumnEditor(ATSCADAColumn component)
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
            GridColumn = this.component.GridColumn;
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;            
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
