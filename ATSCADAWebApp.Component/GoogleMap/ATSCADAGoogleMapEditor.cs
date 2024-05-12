using ATSCADAWebApp.Extension.Method;
using System.Diagnostics;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.GoogleMap
{
    public partial class ATSCADAGoogleMapEditor : Form
    {
        #region FIELDS

        private readonly ATSCADAGoogleMap component;

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

        public string ApplicationName
        {
            get => this.txtApplication.Text.Trim();
            set => this.txtApplication.Text = value;
        }

        public string Connection
        {
            get => this.txtConnection.Text.Trim();
            set => this.txtConnection.Text = value;
        }

        public string GridColumn
        {
            get => this.txtGridColumn.Text.Trim();
            set => this.txtGridColumn.Text = value;
        }

        public string HeightPixel
        {
            get => this.txtHeight.Text.Trim();
            set => this.txtHeight.Text = value;
        }

        public string KeyAPI
        {
            get => this.txtKeyAPI.Text.Trim();
            set => this.txtKeyAPI.Text = value;
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAGoogleMapEditor(ATSCADAGoogleMap component)
        {
            InitializeComponent();
            this.component = component;
            this.Load += (sender, e) => OnLoad();
            this.btnEdit.Click += (sender, e) => OnButtonEdit();
            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
            this.ptnYtb.Click += (sender, e) => OnButtonYoutubeClick();
        }

        #endregion

        #region METHODS

        public void OnLoad()
        {
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Content = this.component.Content;
            GridColumn = this.component.GridColumn;
            Connection = this.component.Connection;
            HeightPixel = this.component.Height;
            KeyAPI = this.component.KeyAPI;
            ApplicationName = this.component.Application;

            LoadListView();
        }

        private void OnButtonEdit()
        {
            var itemProperties = new ATSCADAMarkerItemEditor(this.component);
            var dialogResult = itemProperties.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListView();
        }

        private void LoadListView()
        {
            this.lstvMapItem.Items.Clear();
            foreach (var item in this.component.Items)
            {
                var merge = "";
                foreach (var concernString in item.Items)
                {
                    var name = concernString.Name;
                    var alias = concernString.Alias;
                    var paramTagName = concernString.ParamTagName;
                    merge = merge + name + "=" + alias + "=" + paramTagName + "|";
                }

                var listViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[7]
                {
                    item.Name, item.Alias, merge, item.LocationTagName, item.Color, item.Table,
                    item.ShowCheckBox
                }));

                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[4].ForeColor = item.Color.HexToColor();
            }
        }

        public void OnButtonOKClick()
        {
            if (!CheckProperties()) return;

            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = Content;
            this.component.GridColumn = GridColumn;
            this.component.Connection = Connection;
            this.component.Height = HeightPixel;
            this.component.KeyAPI = KeyAPI;
            this.component.Application = ApplicationName;

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

        #region HELP INFORMATION        

        public void OnButtonYoutubeClick()
        {
            Process.Start("https://www.youtube.com/watch?v=WVjLW0AAs4I");
        }

        #endregion
    }
}
