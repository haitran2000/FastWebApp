using ATSCADAWebApp.Component.SVG;
using ATSCADAWebApp.Component.SVGControlValue;
using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.SVGHyperLink
{
    public partial class ATSCADASVGControlValueItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADASVG component;

        public ATSCADASVGControlValueItemEditor(ATSCADASVG component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvSVGControlValueItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var SVGControlValueItem in component.ItemsControlValue)
            {
                var listViewItem = this.lstvSVGControlValueItem.Items.Add(new ListViewItem(new string[4]
                {
                    SVGControlValueItem.Name,
                    SVGControlValueItem.DataTagName,
                    SVGControlValueItem.Type,
                     SVGControlValueItem.Atribute
                }));
                listViewItem.UseItemStyleForSubItems = false;
            }
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvSVGControlValueItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvSVGControlValueItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[1].Text;
            this.cbbType.Text = selectedItem.SubItems[2].Text;
            this.txtAtribute.Text = selectedItem.SubItems[3].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var type = this.cbbType.Text.Trim();
            var Atribute = this.txtAtribute.Text.Trim();
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(dataTagName) ) return;

            foreach (ListViewItem listViewItem in this.lstvSVGControlValueItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (
                        listViewItem.SubItems[1].Text != dataTagName)
                    {
                        listViewItem.SubItems[1].Text = dataTagName;

                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvSVGControlValueItem.Items.Add(new ListViewItem(new string[4]
            {
                name,dataTagName,type,Atribute
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvSVGControlValueItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvSVGControlValueItem.SelectedItems)
            {
                this.lstvSVGControlValueItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvSVGControlValueItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGControlValueItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvSVGControlValueItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGControlValueItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvSVGControlValueItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGControlValueItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvSVGControlValueItem.Items.Count - 1)
            {
                this.lstvSVGControlValueItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGControlValueItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                var SVGControlValueItems = new List<ATSCADASVGControlValueItem>();
                foreach (ListViewItem listViewItem in this.lstvSVGControlValueItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var dataTagName = listViewItem.SubItems[1].Text.Trim();
                    var type = listViewItem.SubItems[2].Text.Trim();
                    var atribute = listViewItem.SubItems[3].Text.Trim();

                    if (string.IsNullOrEmpty(name)) continue;
                    SVGControlValueItems.Add(new ATSCADASVGControlValueItem()
                    {
                        Name = name,
                        DataTagName = dataTagName,
                        Type = type,
                        Atribute = atribute,
                    });
                }
                this.component.ItemsControlValue = SVGControlValueItems;
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
