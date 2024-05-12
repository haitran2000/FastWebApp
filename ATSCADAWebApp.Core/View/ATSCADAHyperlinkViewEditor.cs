using System.Windows.Forms;

namespace ATSCADAWebApp.Core
{
    public partial class ATSCADAHyperlinkViewEditor : Form
    {
        private readonly ATSCADAHyperlinkView component;

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

        public new string Location
        {
            get => this.txtLocation.Text.Trim();
            set => this.txtLocation.Text = value;
        }

        public new string Icon
        {
            get => this.txtIcon.Text.Trim();
            set => this.txtIcon.Text = value;
        }

        public string Roles
        {
            get => this.txtRoles.Text.Trim();
            set => this.txtRoles.Text = value;
        }

        public string Link
        {
            get => this.txtLink.Text.Trim();
            set => this.txtLink.Text = value;
        }

        public decimal Delay
        {
            get => this.nudDelay.Value;
            set => this.nudDelay.Value = value;
        }

        public ATSCADAHyperlinkViewEditor(ATSCADAHyperlinkView component)
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
            Location = this.component.Location;
            Roles = this.component.Roles;
            Icon = this.component.Icon;
            Link = this.component.Link;
            Delay = this.component.Delay;
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.Location = Location;
            this.component.Roles = Roles;
            this.component.Icon = Icon;
            this.component.Link = Link;
            this.component.Delay = Delay;

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
