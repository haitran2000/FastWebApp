using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.DataReporter
{
    public partial class ATSCADADataReporterItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADADataReporter component;

        public ATSCADADataReporterItemEditor(ATSCADADataReporter component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvDataReporterItem.SelectedIndexChanged += (sender, e) => OnSelectedIndexChanged();

            this.btnAddUpdate.Click += (sender, e) => OnButtonAddUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var reportItem in component.Items)
            {
                var listViewItem = this.lstvDataReporterItem.Items.Add(new ListViewItem(new string[3]
                {
                     reportItem.Name,
                    reportItem.Alias,
                    reportItem.Color
                }));
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[2].ForeColor = reportItem.Color.HexToColor();
            }
        }

        private void OnSelectedIndexChanged()
        {
            if (this.lstvDataReporterItem.SelectedItems.Count <= 0) return;
            var selectedItem = this.lstvDataReporterItem.SelectedItems[0];
            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.txtAlias.Text = selectedItem.SubItems[1].Text;
            this.txtColor.Color = selectedItem.SubItems[2].Text;
        }

        private void OnButtonAddUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var alias = this.txtAlias.Text.Trim();
            var color = this.txtColor.Color.Trim();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(alias) ||
                string.IsNullOrEmpty(color)) return;

            foreach (ListViewItem listViewItem in this.lstvDataReporterItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (listViewItem.SubItems[1].Text != alias ||
                       listViewItem.SubItems[2].Text != color)
                    {
                        listViewItem.SubItems[1].Text = alias;
                        listViewItem.SubItems[2].Text = color;
                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvDataReporterItem.Items.Add(new ListViewItem(new string[3]
            {
                name, alias, color
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            newListViewItem.SubItems[2].ForeColor = color.HexToColor();
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvDataReporterItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvDataReporterItem.SelectedItems)
            {
                this.lstvDataReporterItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvDataReporterItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvDataReporterItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvDataReporterItem.Items.RemoveAt(selectedIndex);
                this.lstvDataReporterItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvDataReporterItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvDataReporterItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvDataReporterItem.Items.Count - 1)
            {
                this.lstvDataReporterItem.Items.RemoveAt(selectedIndex);
                this.lstvDataReporterItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (hasChanges)
            {
                var reportItems = new List<ATSCADADataReporterItem>();
                foreach (ListViewItem listViewItem in this.lstvDataReporterItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var alias = listViewItem.SubItems[1].Text.Trim();
                    var color = listViewItem.SubItems[2].Text.Trim();
                    if (string.IsNullOrEmpty(name)) continue;

                    reportItems.Add(new ATSCADADataReporterItem()
                    {
                        Name = name,
                        Alias = alias,
                        Color = color
                    });
                }
                this.component.Items = reportItems;
            }          
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
