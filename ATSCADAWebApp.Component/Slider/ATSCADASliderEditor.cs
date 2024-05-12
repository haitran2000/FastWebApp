using System.Windows.Forms;

namespace ATSCADAWebApp.Component.Slider
{
    public partial class ATSCADASliderSlider : Form
    {
        private const double MinDefault = 0d;

        private const double MaxDefault = 100d;

        private const double StepDefault = 0.1d;

        private readonly ATSCADASlider component;

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

        public double Min
        {
            get
            {
                if (double.TryParse(this.txtMin.Text, out double min))
                    return min;
                return MinDefault;
            }
            set
            {
                this.txtMin.Text = value.ToString();
            }
        }

        public double Max
        {
            get
            {
                if (double.TryParse(this.txtMax.Text, out double max))
                    return max;
                return MaxDefault;
            }
            set
            {
                this.txtMax.Text = value.ToString();
            }
        }

        public double Step
        {
            get
            {
                if (double.TryParse(this.txtStep.Text, out double step))
                    return step;
                return StepDefault;
            }
            set
            {
                this.txtStep.Text = value.ToString();
            }
        }

        public string Skin
        {
            get => this.cbxSkin.Text.Trim();
            set => this.cbxSkin.Text = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }
        public ATSCADASliderSlider(ATSCADASlider component)
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
            Min = this.component.Min;
            Max = this.component.Max;
            Step = this.component.Step;
            Skin = this.component.Skin;
            GridColumn = this.component.GridColumn;
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.DataTagName = DataTagName;
            this.component.Min = Min;
            this.component.Max = Max;
            this.component.Step = Step;
            this.component.Skin = Skin;
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
