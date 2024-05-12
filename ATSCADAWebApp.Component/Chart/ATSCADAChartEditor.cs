using ATSCADAWebApp.Extension.Method;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.Chart
{
    public partial class ATSCADAChartEditor : Form
    {
        private const decimal SampleNumDefault = 50;

        private readonly ATSCADAChart component;
        
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

        public string Type
        {
            get => this.cbxType.Text.Trim();
            set => this.cbxType.Text = value;
        }

        public new string Height
        {
            get => this.txtHeight.Text.Trim();
            set => this.txtHeight.Text = value;
        }

        public decimal SampleNum
        {
            get => this.nudSampleNum.Value;
            set => this.nudSampleNum.Value = value;
        }
        
        public string Xlabel
        {
            get => this.txtXLabel.Text.Trim();
            set => this.txtXLabel.Text = value;
        }

        public string Ylabel
        {
            get => this.txtYLabel.Text.Trim();
            set => this.txtYLabel.Text = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public ATSCADAChartEditor(ATSCADAChart component)
        {
            InitializeComponent();
            this.cbxType.Items.AddRange(new string[4] { "line", "bar", "pie", "donut" });

            this.component = component;
            this.Load += (sender, e) => OnLoad();
            this.btnEdit.Click += (sender, e) => OnButtonEdit();
            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Content = this.component.Content;
            Type = this.component.Type;
            Height = this.component.Height;
            SampleNum = this.component.SampleNum;
            Xlabel = this.component.Xlabel;
            Ylabel = this.component.Ylabel;
            GridColumn = this.component.GridColumn;

            LoadListView();
        }

        private void OnButtonEdit()
        {
            var itemProperties = new ATSCADAChartItemEditor(this.component);
            var dialogResult = itemProperties.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListView();
        }

        private void LoadListView()
        {
            this.lstvChartItem.Items.Clear();
            foreach (var item in this.component.Items)
            {
                var listViewItem = this.lstvChartItem.Items.Add(new ListViewItem(new string[4]
                {
                    item.Name, item.Content, item.DataTagName, item.Color
                }));

                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[3].ForeColor = item.Color.HexToColor();
            }
        }

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.Type = Type;
            this.component.Height = Height;
            this.component.SampleNum = SampleNum;
            this.component.Xlabel = Xlabel;
            this.component.Ylabel = Ylabel;
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
