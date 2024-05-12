using ATSCADAWebApp.Component.SVG;
using ATSCADAWebApp.Extension.Method;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.SVGAlarm
{
    public partial class ATSCADASVGAlarmItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADASVG component;

        public ATSCADASVGAlarmItemEditor(ATSCADASVG component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvSVGAlarmItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var SVGAlarmItem in component.ItemsAlarm)
            {
                var listViewItem = this.lstvSVGAlarmItem.Items.Add(new ListViewItem(new string[4]
                {
                    SVGAlarmItem.Name,
                    SVGAlarmItem.DataTagName,
                    SVGAlarmItem.LowAlarm,
                    SVGAlarmItem.HighAlarm,
                }));
                listViewItem.UseItemStyleForSubItems = false;
            }
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvSVGAlarmItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvSVGAlarmItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[1].Text;
            this.cbxDataTagLowName.TagName = selectedItem.SubItems[2].Text;
            this.cbxDataTagHighName.TagName = selectedItem.SubItems[3].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var dataLowTagName = this.cbxDataTagLowName.TagName.Trim();
            var dataHighTagName = this.cbxDataTagHighName.TagName.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dataLowTagName) || string.IsNullOrEmpty(dataHighTagName) ||
                string.IsNullOrEmpty(dataTagName)) return;

            foreach (ListViewItem listViewItem in this.lstvSVGAlarmItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (
                        listViewItem.SubItems[1].Text != dataTagName ||
                        listViewItem.SubItems[2].Text != dataLowTagName ||
                        listViewItem.SubItems[3].Text != dataHighTagName)
                    {
                        listViewItem.SubItems[1].Text = dataTagName;
                        listViewItem.SubItems[2].Text = dataLowTagName;
                        listViewItem.SubItems[3].Text = dataHighTagName;
                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvSVGAlarmItem.Items.Add(new ListViewItem(new string[4]
            {
                name, dataTagName,dataLowTagName,dataHighTagName
            }));
            newListViewItem.UseItemStyleForSubItems = false;
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvSVGAlarmItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvSVGAlarmItem.SelectedItems)
            {
                this.lstvSVGAlarmItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvSVGAlarmItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGAlarmItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvSVGAlarmItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGAlarmItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvSVGAlarmItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGAlarmItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvSVGAlarmItem.Items.Count - 1)
            {
                this.lstvSVGAlarmItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGAlarmItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                var SVGAlarmItems = new List<ATSCADASVGAlarmItem>();
                foreach (ListViewItem listViewItem in this.lstvSVGAlarmItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var dataTagName = listViewItem.SubItems[1].Text.Trim();
                    var dataLowTagName = listViewItem.SubItems[2].Text.Trim();
                    var dataHighTagName = listViewItem.SubItems[3].Text.Trim();

                    if (string.IsNullOrEmpty(name)) continue;
                    SVGAlarmItems.Add(new ATSCADASVGAlarmItem()
                    {
                        Name = name,
                        DataTagName = dataTagName,
                        LowAlarm = dataLowTagName,
                        HighAlarm= dataHighTagName
                    });
                }
                this.component.ItemsAlarm = SVGAlarmItems;              
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageProperties_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {

        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {

        }

        private void txtContent_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void lblContent_Click(object sender, System.EventArgs e)
        {

        }

        private void lstvSVGAlarmItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void lblName_Click(object sender, System.EventArgs e)
        {

        }

        private void tabElement_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void lblTagName_Click(object sender, System.EventArgs e)
        {

        }

        private void cbxDataTagName_Load(object sender, System.EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {

        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {

        }
    }
}
