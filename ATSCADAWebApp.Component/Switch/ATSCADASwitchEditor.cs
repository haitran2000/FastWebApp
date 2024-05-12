using System.Windows.Forms;

namespace ATSCADAWebApp.Component.Switch
{
    public partial class ATSCADASwitchEditor : Form
    {
        private readonly ATSCADASwitch component;

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

        public new string Size
        {
            get => this.cbxSize.Text.Trim();
            set => this.cbxSize.Text = value;
        }

        public string ValueOn
        {
            get => this.txtValueOn.Text;
            set => this.txtValueOn.Text = value;
        }

        public string ValueOff
        {
            get => this.txtValueOff.Text;
            set => this.txtValueOff.Text = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public ATSCADASwitchEditor(ATSCADASwitch component)
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
            Size = this.component.Size;
            ValueOn = this.component.ValueOn;
            ValueOff = this.component.ValueOff;
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
            this.component.Size = Size;
            this.component.ValueOn = ValueOn;
            this.component.ValueOff = ValueOff;
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
