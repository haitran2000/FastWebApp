using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.GoogleMap
{
    public partial class ATSCADAMarkerItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADAGoogleMap component;

        private List<ATSCADAMarkerItem> markers;

        public ATSCADAMarkerItemEditor(ATSCADAGoogleMap component)
        {
            InitializeComponent();
            this.component = component;
            this.markers = component.Items;
            foreach (var item in this.component.Items)
            {
                var mergeParam = "";
                foreach (var param in item.Items)
                {
                    var name = param.Name;
                    var alias = param.Alias;
                    var paramTagName = param.ParamTagName;
                    mergeParam = mergeParam + name + "=" + alias + "=" + paramTagName + "|";
                }
                item.ParamTagName = mergeParam;
            }

            this.Load += (sender, e) => OnLoad();
            this.lstvMapItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
            this.ptnSettings.Click += (sender, e) => OnButtonSettingClick();
        }

        private void OnButtonSettingClick()
        {
            var textbox = new ATSCADAParamItemEditor(this.txtParam);
            var dialogResult = textbox.ShowDialog();
            if (dialogResult == DialogResult.OK) return;
        }

        private void OnLoad()
        {
            this.lstvMapItem.Items.Clear();
            foreach (var markerItem in this.markers)
            {
                var merge = "";
                foreach (var concernString in markerItem.Items)
                {
                    var name = concernString.Name;
                    var alias = concernString.Alias;
                    var paramTagName = concernString.ParamTagName;
                    merge = merge + name + "=" + alias + "=" + paramTagName + "|";
                }

                var listViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[10]
                {
                    markerItem.Name,
                    markerItem.Alias,
                    merge,
                    markerItem.LocationTagName,
                    markerItem.Color,
                    markerItem.Table,
                    markerItem.LinkUrl,
                    markerItem.OpenNewTab,
                    markerItem.Movable,
                    markerItem.ShowCheckBox
                }));
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[4].ForeColor = markerItem.Color.HexToColor();
                listViewItem.Tag = markerItem;
            }
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvMapItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvMapItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.txtAlias.Text = selectedItem.SubItems[1].Text;
            this.txtParam.Text = selectedItem.SubItems[2].Text;
            this.cbxLocationTagName.TagName = selectedItem.SubItems[3].Text;
            this.txtColor.Color = selectedItem.SubItems[4].Text;
            this.txtTable.Text = selectedItem.SubItems[5].Text;
            this.txtUrl.Text = selectedItem.SubItems[6].Text;

            if (selectedItem.SubItems[7].Text.Equals("checked"))
                this.chbOpenNewTab.Checked = true;
            else
                this.chbOpenNewTab.Checked = false;

            if (selectedItem.SubItems[8].Text.Equals("checked"))
                this.chbMovable.Checked = true;
            else
                this.chbMovable.Checked = false;

            if (selectedItem.SubItems[9].Text.Equals("checked"))
                this.chbShow.Checked = true;
            else
                this.chbShow.Checked = false;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var alias = this.txtAlias.Text.Trim();
            var paramTagName = this.txtParam.Text.Trim();
            var locationTagName = this.cbxLocationTagName.TagName.Trim();
            var color = this.txtColor.Color.Trim();
            var show = this.chbShow.CheckState.ToString().ToLower();
            var table = this.txtTable.Text.Trim();
            var newTab = this.chbOpenNewTab.CheckState.ToString().ToLower();
            var url = this.txtUrl.Text.Trim();
            var movable = this.chbMovable.CheckState.ToString().ToLower();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(alias) ||
                string.IsNullOrEmpty(locationTagName) ||
                string.IsNullOrEmpty(color) ||
                string.IsNullOrEmpty(show) ||
                string.IsNullOrEmpty(newTab) ||
                string.IsNullOrEmpty(movable)) return;

            foreach (ListViewItem listViewItem in this.lstvMapItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (listViewItem.SubItems[1].Text != alias ||
                        listViewItem.SubItems[2].Text != paramTagName ||
                        listViewItem.SubItems[3].Text != locationTagName ||
                        listViewItem.SubItems[4].Text != color ||
                        listViewItem.SubItems[5].Text != table ||
                        listViewItem.SubItems[6].Text != url ||
                        listViewItem.SubItems[7].Text != newTab ||
                        listViewItem.SubItems[8].Text != movable ||
                        listViewItem.SubItems[9].Text != show)
                    {
                        // Update new value to list view
                        listViewItem.SubItems[1].Text = alias;
                        listViewItem.SubItems[2].Text = paramTagName;
                        listViewItem.SubItems[3].Text = locationTagName;
                        listViewItem.SubItems[4].Text = color;
                        listViewItem.SubItems[5].Text = table;
                        listViewItem.SubItems[6].Text = url;
                        listViewItem.SubItems[7].Text = newTab;
                        listViewItem.SubItems[8].Text = movable;
                        listViewItem.SubItems[9].Text = show;
                        listViewItem.SubItems[4].ForeColor = color.HexToColor();
                        hasChanges = true;

                        foreach (var item in this.markers)
                        {
                            if (item.Name == name)
                            {
                                item.Alias = alias;
                                item.ParamTagName = paramTagName;
                                item.LocationTagName = locationTagName;
                                item.Color = color;
                                item.Table = table;
                                item.LinkUrl = url;
                                item.OpenNewTab = newTab;
                                item.Movable = movable;
                                item.ShowCheckBox = show;
                                UpdateParamItems(item, paramTagName);
                                return;
                            }
                        }
                    }
                }
            }

            // Create new marker
            var mapItem = new ATSCADAMarkerItem()
            {
                Name = name,
                Alias = alias,
                ParamTagName = paramTagName,
                LocationTagName = locationTagName,
                Color = color,
                Table = table,
                LinkUrl = url,
                OpenNewTab = newTab,
                Movable = movable,
                ShowCheckBox = show
            };

            // Update value to Items
            UpdateParamItems(mapItem, paramTagName);

            // Add new row in listview
            var newListViewItem = this.lstvMapItem.Items.Add(new ListViewItem(new string[10]
            {
                name, alias, paramTagName, locationTagName, color, table, url, newTab, movable, show
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            newListViewItem.SubItems[4].ForeColor = color.HexToColor();
            newListViewItem.Tag = mapItem;

            // Save to new memory
            var markerItems = new List<ATSCADAMarkerItem>();
            foreach (ListViewItem listViewItem in this.lstvMapItem.Items)
            {
                if (listViewItem.Tag is ATSCADAMarkerItem marker)
                    markerItems.Add(marker);
            }
            this.markers = markerItems;
            hasChanges = true;
        }

        private void UpdateParamItems(ATSCADAMarkerItem item, string paramTagName)
        {
            if (!paramTagName.Contains("|")) return;
            var str = paramTagName.Split('|');

            item.Items.RemoveRange(0, item.Items.Count);
            var paramItems = new List<ATSCADAParamItem>();
            foreach (var param in str)
            {
                if (!param.Contains("="))
                    continue;
                var splitString = param.Split('=');
                if (splitString.Length < 3)
                    continue;
                var ten = splitString[0];
                var tenthaythe = splitString[1];
                var tag = splitString[2];

                paramItems.Add(new ATSCADAParamItem()
                {
                    Name = ten,
                    Alias = tenthaythe,
                    ParamTagName = tag
                });
                item.Items = paramItems;
            }
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvMapItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvMapItem.SelectedItems)
            {               
                foreach(var marker in this.markers)
                {
                    if (listViewItem.Text == marker.Name)
                    {
                        this.markers.Remove(marker);
                        break;
                    }
                }
                this.lstvMapItem.Items.Remove(listViewItem);
                hasChanges = true;
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
                hasChanges = true;
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
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                this.component.Items = this.markers;
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
