using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.GoogleMap
{
    public partial class ATSCADAParamItemEditor : Form
    {
        private readonly ATSCADAMarkerItem component;

        private readonly TextBox parameters;

        public ATSCADAParamItemEditor(ATSCADAMarkerItem component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvMapItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        public ATSCADAParamItemEditor(TextBox textbox)
        {
            InitializeComponent();
            this.parameters = textbox;

            this.Load += (sender, e) => OnLoad();
            this.lstvMapItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            if (string.IsNullOrEmpty(this.parameters.Text)) return;
            var content = this.parameters.Text;
            var str = content.Contains("|");
            if (!str) return;

            var split = content.Split('|');            
            foreach (var param in split)
            {
                if (!param.Contains("="))
                    continue;
                var splitString = param.Split('=');
                if (splitString.Length < 3)
                    continue;
                var name = splitString[0];
                var alias = splitString[1];
                var tag = splitString[2];
                var listViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[3]
                {
                        name, alias, tag
                }));
                listViewItem.UseItemStyleForSubItems = false;
            }
        }

        //private void OnLoad()
        //{
        //    var length = this.component.Items.Count;
        //    if (length == 0)
        //    {
        //        // First time
        //        if (string.IsNullOrEmpty(this.component.ParamTagName)) return;
        //        var str = this.component.ParamTagName;
        //        var contain = str.Contains("|");
        //        if (!contain) return;

        //        var split = str.Split('|');
        //        foreach (var param in split)
        //        {
        //            if (!param.Contains("=")) continue;
        //            var splitString = param.Split('=');
        //            var name = splitString[0];
        //            var alias = splitString[1];
        //            var tag = splitString[2];
        //            var listViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[3]
        //            {
        //                name, alias, tag
        //            }));
        //            listViewItem.UseItemStyleForSubItems = false;
        //        }
        //        return;
        //    }
        //    else
        //    {
        //        foreach (var paramItems in this.component.Items)
        //        {
        //            var listViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[3]
        //            {
        //            paramItems.Name,
        //            paramItems.Alias,
        //            paramItems.ParamTagName
        //            }));
        //            listViewItem.UseItemStyleForSubItems = false;
        //        }
        //    }
        //}

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvMapItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvMapItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.txtAlias.Text = selectedItem.SubItems[1].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[2].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var alias = this.txtAlias.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(alias) ||
                string.IsNullOrEmpty(dataTagName)) return;

            foreach (ListViewItem listViewItem in this.lstvMapItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (listViewItem.SubItems[1].Text != alias ||
                        listViewItem.SubItems[2].Text != dataTagName)
                    {
                        listViewItem.SubItems[1].Text = alias;
                        listViewItem.SubItems[2].Text = dataTagName;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[3]
            {
                name, alias, dataTagName
            }));
            newListViewItem.UseItemStyleForSubItems = false;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvMapItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvMapItem.SelectedItems)
            {
                this.lstvMapItem.Items.Remove(listViewItem);
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvMapItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvMapItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvMapItem.Items.RemoveAt(selectedIndex);
                this.lstvMapItem.Items.Insert(selectedIndex - 1, listViewItem);
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvMapItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvMapItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvMapItem.Items.Count - 1)
            {
                this.lstvMapItem.Items.RemoveAt(selectedIndex);
                this.lstvMapItem.Items.Insert(selectedIndex + 1, listViewItem);
            }
        }

        private void OnButtonOKClick()
        {
            var paramItems = new List<ATSCADAParamItem>();
            var mergeParam = "";
            foreach (ListViewItem listViewItem in this.lstvMapItem.Items)
            {
                var name = listViewItem.SubItems[0].Text.Trim();
                var alias = listViewItem.SubItems[1].Text.Trim();
                var paramTagName = listViewItem.SubItems[2].Text.Trim();
                mergeParam = mergeParam + name + "=" + alias + "=" + paramTagName + "|";

                if (string.IsNullOrEmpty(name)) continue;
                paramItems.Add(new ATSCADAParamItem()
                {
                    Name = name,
                    Alias = alias,
                    ParamTagName = paramTagName
                });
            }
            this.parameters.Text = mergeParam;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //private void OnButtonOKClick()
        //{
        //    var paramItems = new List<ATSCADAParamItem>();
        //    var mergeParam = "";
        //    foreach (ListViewItem listViewItem in this.lstvMapItem.Items)
        //    {
        //        var name = listViewItem.SubItems[0].Text.Trim();
        //        var alias = listViewItem.SubItems[1].Text.Trim();
        //        var paramTagName = listViewItem.SubItems[2].Text.Trim();
        //        mergeParam = mergeParam + name + "=" + alias + "=" + paramTagName + "|";

        //        if (string.IsNullOrEmpty(name)) continue;
        //        paramItems.Add(new ATSCADAParamItem()
        //        {
        //            Name = name,
        //            Alias = alias,
        //            ParamTagName = paramTagName
        //        });
        //    }
        //    this.component.Items = paramItems;
        //    this.component.ParamTagName = mergeParam;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnButtonHelp_AliasClick()
        {
            MessageBox.Show("", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
