using System.Drawing;
using System.Windows.Forms;
using ATSCADAWebApp.Component.SVG;
using System;
using SvgNet;
using System.IO;
using ATSCADAWebApp.Extension.Method;
using ATSCADAWebApp.Component.SVGValue;
using ATSCADAWebApp.Component.SVGAlarm;
using ATSCADAWebApp.Component.SVGCutaway;
using System.Diagnostics;

namespace ATSCADAWebApp.Component.SVG
{
    public partial class ATSCADASVGEditor : Form
    {
        private readonly ATSCADASVG component;
        private string selectedPath;
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
        public string Color
        {
            get => this.txtColor.Color;
            set => this.txtColor.Color = value;
        }
        public string pathSVG
        {
            get => this.txtSelectedFile.Text.Trim();
            set => this.txtSelectedFile.Text = value;
        }
        public string TextSVG { get => textSVG; set => textSVG = value; }

        private string textSVG;
        public ATSCADASVGEditor(ATSCADASVG component)
        {
            InitializeComponent();

            this.component = component;
            this.Load += (sender, e) => OnLoad();          
            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Color = this.component.Color;
            pathSVG = this.component.FilePath;
            readFileSVG(pathSVG);
            LoadListView();
            LoadListViewAlarm();
            LoadListViewCutaWay();
        }       

        private void OnButtonOKClick()
        {
            if (!CheckProperties()) return;
            this.component.Name = ComponentName;
            this.component.Description = Description;
            this.component.Content = TextSVG;
            this.component.Color = Color;
            this.component.FilePath = pathSVG;
            
            this.DialogResult = DialogResult.OK;
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
        private void LoadListView()
        {
            this.lstvSVGValueItem.Items.Clear();
            foreach (var item in this.component.Items)
            {
                var listViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(new string[5]
                {
                    item.Name, item.DataTagName,item.Properties,item.Type,item.Attribute
                }));

                listViewItem.UseItemStyleForSubItems = false;
            }
        }
        private void LoadListViewAlarm()
        {
            this.lstvSVGAlarmItem.Items.Clear();
            foreach (var item in this.component.ItemsAlarm)
            {
                var listViewItem = this.lstvSVGAlarmItem.Items.Add(new ListViewItem(new string[4]
                {
                    item.Name, item.DataTagName,item.HighAlarm,item.LowAlarm
                }));

                listViewItem.UseItemStyleForSubItems = false;
            }
        }
        private void LoadListViewCutaWay()
        {
            this.lstvSVGCutawayItem.Items.Clear();
            foreach (var item in this.component.ItemsCutaway)
            {
                var listViewItem = this.lstvSVGCutawayItem.Items.Add(new ListViewItem(new string[5]
                {
                    item.Name,item.ID2, item.DataTagName,item.Min,item.Max
                }));

                listViewItem.UseItemStyleForSubItems = false;
            }
        }

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            DialogResult selectResult = filePicker.ShowDialog();
            if (selectResult == System.Windows.Forms.DialogResult.OK)
            {
                selectedPath = filePicker.FileName;
                readFileSVG(selectedPath);


                // Đọc file SVG

            }
        }
        public void readFileSVG(string path)
        {
            if(path!="")
            {
                txtSelectedFile.Text = path;
                using (StreamReader reader = new StreamReader(path))
                {
                    textSVG = reader.ReadToEnd();
                }
            }    
           
        }
        public static bool IsSvgFile(string filePath)
        {
            // Kiểm tra phần mở rộng file
            if (!filePath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            // Kiểm tra nội dung file
            using (var reader = new StreamReader(filePath))
            {
                var firstLine = reader.ReadLine();
                if (string.IsNullOrEmpty(firstLine))
                {
                    return false;
                }

            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var itemProperties = new ATSCADASVGValueItemEditor(this.component);
            var dialogResult = itemProperties.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListView();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var itemProperties = new ATSCADASVGAlarmItemEditor(this.component);
            var dialogResult = itemProperties.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListViewAlarm();
        }

        private void btnEditCutaway_Click(object sender, EventArgs e)
        {
            var itemCutaway = new ATSCADASVGCutawayItemEditor(this.component);
            var dialogResult = itemCutaway.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListViewCutaWay();
        }

        private void btnOpenApp_Click(object sender, EventArgs e)
        {
            string appPath = @"E:\Rasc\ATSVGEDITOR.appref-ms";
            OpenApplication(appPath);
        }
        static void OpenApplication(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
