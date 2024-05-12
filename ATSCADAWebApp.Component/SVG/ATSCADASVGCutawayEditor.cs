using ATSCADAWebApp.Component.SVG;
using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.SVGCutaway
{
    public partial class ATSCADASVGCutawayItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADASVG component;

        public ATSCADASVGCutawayItemEditor(ATSCADASVG component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvSVGCutawayItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var SVGCutawayItem in component.ItemsCutaway)
            {
                var listViewItem = this.lstvSVGCutawayItem.Items.Add(new ListViewItem(new string[5]
                {
                    SVGCutawayItem.Name,
                    SVGCutawayItem.ID2,
                    SVGCutawayItem.DataTagName,
                     SVGCutawayItem.Min,
                     SVGCutawayItem.Max
                }));
                listViewItem.UseItemStyleForSubItems = false;
            }
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvSVGCutawayItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvSVGCutawayItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.txtID2.Text = selectedItem.SubItems[1].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[2].Text;
            this.txtMin.Text = selectedItem.SubItems[3].Text;
            this.txtMax.Text = selectedItem.SubItems[4].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var min = this.txtMin.Text.Trim();
            var max = this.txtMax.Text.Trim();
            var id2 = this.txtID2.Text.Trim();
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(dataTagName) ) return;

            foreach (ListViewItem listViewItem in this.lstvSVGCutawayItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (
                        listViewItem.SubItems[1].Text != dataTagName)
                    {
                        listViewItem.SubItems[2].Text = dataTagName;

                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvSVGCutawayItem.Items.Add(new ListViewItem(new string[5]
            {
                name,id2, dataTagName,min,max
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvSVGCutawayItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvSVGCutawayItem.SelectedItems)
            {
                this.lstvSVGCutawayItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvSVGCutawayItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGCutawayItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvSVGCutawayItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGCutawayItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvSVGCutawayItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGCutawayItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvSVGCutawayItem.Items.Count - 1)
            {
                this.lstvSVGCutawayItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGCutawayItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                var SVGCutawayItems = new List<ATSCADASVGCutawayItem>();
                foreach (ListViewItem listViewItem in this.lstvSVGCutawayItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var id2 = listViewItem.SubItems[1].Text.Trim();
                    var dataTagName = listViewItem.SubItems[2].Text.Trim();
                    var min = listViewItem.SubItems[3].Text.Trim();
                    var max = listViewItem.SubItems[4].Text.Trim();

                    if (string.IsNullOrEmpty(name)) continue;
                    SVGCutawayItems.Add(new ATSCADASVGCutawayItem()
                    {
                        Name = name,
                        ID2=id2,
                        DataTagName = dataTagName,
                        Min = min,
                        Max = max,
                    });
                }
                this.component.ItemsCutaway = SVGCutawayItems;
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
