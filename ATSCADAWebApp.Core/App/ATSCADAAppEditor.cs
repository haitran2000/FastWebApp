using System.Windows.Forms;

namespace ATSCADAWebApp.Core
{
    public partial class ATSCADAAppEditor : Form
    {
        private readonly ATSCADAApp component;

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

        public string Title
        {
            get => this.txtTitle.Text.Trim();
            set => this.txtTitle.Text = value;
        }

        public string Brand
        {
            get => this.txtBrand.Text.Trim();
            set => this.txtBrand.Text = value;
        }

        public string Author
        {
            get => this.txtAuthor.Text.Trim();
            set => this.txtAuthor.Text = value;
        }

        public bool DarkMode
        {
            get => this.ckbDarkMode.Checked;
            set => this.ckbDarkMode.Checked = value;
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

        public bool Required
        {
            get => ckbRequirement.Checked;
            set => this.ckbRequirement.Checked = value;
        }

        public string Address
        {
            get => this.txtAddress.Text.Trim();
            set => this.txtAddress.Text = value;
        }

        public string Port
        {
            get => this.txtPort.Text.Trim();
            set => this.txtPort.Text = value;
        }

        public ATSCADAAppEditor(ATSCADAApp component)
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
            Title = this.component.Title;
            Brand = this.component.Brand;
            Author = this.component.Author;
            DarkMode = this.component.DarkMode;
            Connection = this.component.Authentication.Connection;
            TableName = this.component.Authentication.TableName;
            Required = this.component.Authentication.Required;
            Address = this.component.Service.Address;
            Port = this.component.Service.Port;
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Title = Title;
            this.component.Brand = Brand;
            this.component.Author = Author;
            this.component.DarkMode = DarkMode;
            if (this.component.Authentication.Connection != Connection ||
                this.component.Authentication.TableName != TableName ||
                this.component.Authentication.Required != Required)
            {
                this.component.Authentication = new ATSCADAAppAuthentication()
                {
                    Connection = Connection,
                    TableName = TableName,
                    Required = Required
                };
            }

            if (this.component.Service.Address != Address ||                
                this.component.Service.Port != Address)
            {
                this.component.Service = new ATSCADAAppService()
                {
                    Address = Address,
                    Port = Port
                };
            }           

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
