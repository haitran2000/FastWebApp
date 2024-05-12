using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.Chart
{
    public partial class ATSCADAChartItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADAChart component;

        public ATSCADAChartItemEditor(ATSCADAChart component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvChartItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var chartItem in component.Items)
            {
                var listViewItem = this.lstvChartItem.Items.Add(new ListViewItem(new string[4]
                {
                    chartItem.Name,
                    chartItem.Content,
                    chartItem.DataTagName,
                    chartItem.Color
                }));
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.SubItems[3].ForeColor = chartItem.Color.HexToColor();
            }
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvChartItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvChartItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.txtContent.Text = selectedItem.SubItems[1].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[2].Text;
            this.txtColor.Color = selectedItem.SubItems[3].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var content = this.txtContent.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var color = this.txtColor.Color.Trim();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(content) ||
                string.IsNullOrEmpty(dataTagName) ||
                string.IsNullOrEmpty(color)) return;

            foreach (ListViewItem listViewItem in this.lstvChartItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (listViewItem.SubItems[1].Text != content ||
                        listViewItem.SubItems[2].Text != dataTagName ||
                        listViewItem.SubItems[3].Text != color)
                    {
                        listViewItem.SubItems[1].Text = content;
                        listViewItem.SubItems[2].Text = dataTagName;
                        listViewItem.SubItems[3].Text = color;
                        listViewItem.SubItems[3].ForeColor = color.HexToColor();
                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvChartItem.Items.Add(new ListViewItem(new string[4]
            {
                name, content, dataTagName, color
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            newListViewItem.SubItems[3].ForeColor = color.HexToColor();
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvChartItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvChartItem.SelectedItems)
            {
                this.lstvChartItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvChartItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvChartItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvChartItem.Items.RemoveAt(selectedIndex);
                this.lstvChartItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvChartItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvChartItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvChartItem.Items.Count - 1)
            {
                this.lstvChartItem.Items.RemoveAt(selectedIndex);
                this.lstvChartItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                var chartItems = new List<ATSCADAChartItem>();
                foreach (ListViewItem listViewItem in this.lstvChartItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var content = listViewItem.SubItems[1].Text.Trim();
                    var dataTagName = listViewItem.SubItems[2].Text.Trim();
                    var color = listViewItem.SubItems[3].Text.Trim();

                    if (string.IsNullOrEmpty(name)) continue;
                    chartItems.Add(new ATSCADAChartItem()
                    {
                        Name = name,
                        Content = content,
                        DataTagName = dataTagName,
                        Color = color
                    });
                }
                this.component.Items = chartItems;              
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
