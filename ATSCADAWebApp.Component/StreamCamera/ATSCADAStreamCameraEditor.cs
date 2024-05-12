using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.StreamCamera
{
    public partial class ATSCADAStreamCameraEditor : Form
    {
        #region FIELDS

        private readonly ATSCADAStreamCamera component;

        #endregion

        #region PROPERTIES

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

        public string Network
        {
            get => this.cbxNetwork.SelectedItem.ToString();
            set => this.cbxNetwork.SelectedItem = value;
        }

        public string FrameSize
        {
            get => this.cbxFrame.SelectedItem.ToString();
            set => this.cbxFrame.SelectedItem = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public string TokenTime
        {
            get => this.txtTokenTime.Text.Trim();
            set => this.txtTokenTime.Text = value;
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAStreamCameraEditor(ATSCADAStreamCamera component)
        {
            InitializeComponent();
            this.cbxNetwork.Items.AddRange(new string[] { "Cloud" });
            this.cbxFrame.Items.AddRange(new string[] { "vjs-fluid", "vjs-16-9", "vjs-4-3", "vjs-1-1", "vjs-9-16" });

            this.component = component;
            this.Load += (sender, e) => OnLoad();
            this.cbxNetwork.SelectedIndexChanged += (sender, e) => OnNetwork();
            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();            
        }

        #endregion

        #region METHODS

        public void OnLoad()
        {
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Content = this.component.Content;
            Network = this.component.Network;
            FrameSize = this.component.Frame;
            GridColumn = this.component.GridColumn;
            TokenTime = this.component.TokenTime;
            Connection = this.component.Connection;
        }

        public void OnNetwork()
        {
            if (cbxNetwork.Text == "LAN")
            {
                txtTokenTime.Text = "1";
                txtTokenTime.Enabled = false;
                txtTokenTime.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if (cbxNetwork.Text == "Cloud")
            {
                txtTokenTime.Enabled = true;
                txtTokenTime.BackColor = SystemColors.Window;
            }
        }

        public void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.Network = Network;
            this.component.Frame = FrameSize;
            this.component.GridColumn = GridColumn;
            this.component.TokenTime = TokenTime;
            this.component.Connection = Connection;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool CheckProperties()
        {
            if (string.IsNullOrEmpty(ComponentName))
            {
                MessageBox.Show("Property 'Name' must not be null or empty", "ATSCADA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion
    }
}
