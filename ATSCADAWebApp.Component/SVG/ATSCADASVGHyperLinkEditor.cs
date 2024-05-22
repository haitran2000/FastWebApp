using ATSCADAWebApp.Component.SVG;
using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.SVGHyperLink
{
    public partial class ATSCADASVGHyperLinkItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADASVG component;

        public ATSCADASVGHyperLinkItemEditor(ATSCADASVG component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvSVGHyperLinkItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var SVGHyperLinkItem in component.ItemsHyperLink)
            {
                var listViewItem = this.lstvSVGHyperLinkItem.Items.Add(new ListViewItem(new string[4]
                {
                    SVGHyperLinkItem.Name,
                    SVGHyperLinkItem.Type,
                    SVGHyperLinkItem.DataTagName,
                     SVGHyperLinkItem.Color
                }));
                listViewItem.UseItemStyleForSubItems = false;
            }
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvSVGHyperLinkItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvSVGHyperLinkItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[1].Text;
            this.txtType.Text = selectedItem.SubItems[2].Text;
            this.txtColorLink.Text = selectedItem.SubItems[3].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var type = this.txtType.Text.Trim();
            var color = this.txtColorLink.Text.Trim();
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(dataTagName) ) return;

            foreach (ListViewItem listViewItem in this.lstvSVGHyperLinkItem.Items)
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

            var newListViewItem = this.lstvSVGHyperLinkItem.Items.Add(new ListViewItem(new string[4]
            {
                name,dataTagName,type,color
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvSVGHyperLinkItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvSVGHyperLinkItem.SelectedItems)
            {
                this.lstvSVGHyperLinkItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvSVGHyperLinkItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGHyperLinkItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvSVGHyperLinkItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGHyperLinkItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvSVGHyperLinkItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGHyperLinkItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvSVGHyperLinkItem.Items.Count - 1)
            {
                this.lstvSVGHyperLinkItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGHyperLinkItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                var SVGHyperLinkItems = new List<ATSCADASVGHyperLinkItem>();
                foreach (ListViewItem listViewItem in this.lstvSVGHyperLinkItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var dataTagName = listViewItem.SubItems[1].Text.Trim();
                    var type = listViewItem.SubItems[2].Text.Trim();
                    var color = listViewItem.SubItems[3].Text.Trim();

                    if (string.IsNullOrEmpty(name)) continue;
                    SVGHyperLinkItems.Add(new ATSCADASVGHyperLinkItem()
                    {
                        Name = name,
                        DataTagName = dataTagName,
                        Type = type,
                        Color = color,
                    });
                }
                this.component.ItemsHyperLink = SVGHyperLinkItems;
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
