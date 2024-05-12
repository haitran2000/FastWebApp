using ATSCADAWebApp.Extension.TagCollection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ATSCADAWebApp.ToolExtensions.TagCollection
{
    public partial class SmartTagComboBox : UserControl
    {
        private const int EM_SETCUEBANNER = 0x1703;

        private const string TAG_SEARCH = "Select tag";

        private readonly TagCollectionAccess access;

        private List<string> tagCollection = new List<string>();
       
        [Category("ATSCADA Settings")]
        [Description("Build tag collection in runtime mode.")]
        public bool InRuntime { get; set; } = false;

        public string TagName
        {
            get => this.cbxSmartTag.Text;
            set => this.cbxSmartTag.Text = value;
        }

        public SmartTagComboBox()
        {
            InitializeComponent();
            this.access = new TagCollectionAccess();

            this.Load += SmartTagComboBoxUser_Load;

            this.cbxSmartTag.TextUpdate += CbxSmartTag_TextUpdate;
            this.cbxSmartTag.TextChanged += CbxSmartTag_TextChanged;
        }       

        private void SmartTagComboBoxUser_Load(object sender, EventArgs e)
        {
            SendMessage(this.cbxSmartTag.Handle, EM_SETCUEBANNER, 0, TAG_SEARCH);
            LoadTagCollectionFromTagFile();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private void LoadTagCollectionFromTagFile()
        {
            if (InRuntime)
            {
                var locationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var pathAccess = Path.Combine(locationPath, "Tag_file.xml");

                this.tagCollection = this.access.Convert(pathAccess);
            }
            else
                this.tagCollection = this.access.Convert();

            if (this.tagCollection == null) return;
            if (this.tagCollection.Count == 0) return;

            this.cbxSmartTag.Items.Clear();

            if (this.tagCollection == null) return;
            if (this.tagCollection.Count == 0) return;

            this.cbxSmartTag.Items.AddRange(this.tagCollection.ToArray());
        }

        private void CbxSmartTag_TextUpdate(object sender, EventArgs e)
        {
            var keywords = this.cbxSmartTag.Text;
            var tagCollectionFilted = TagCollectionFilter.Filter(this.tagCollection, keywords);

            if (tagCollectionFilted.Count > 0)
            {
                this.cbxSmartTag.Items.Clear();
                this.cbxSmartTag.Items.AddRange(tagCollectionFilted.ToArray());

                this.cbxSmartTag.SelectionStart = this.cbxSmartTag.Text.Length;
                this.cbxSmartTag.SelectionLength = this.cbxSmartTag.Items[0].ToString().Length - this.cbxSmartTag.Text.Length;
                this.cbxSmartTag.DroppedDown = true;
            }
            else
            {
                this.cbxSmartTag.DroppedDown = false;
                this.cbxSmartTag.SelectionStart = this.cbxSmartTag.Text.Length;
            }
        }

        private void CbxSmartTag_TextChanged(object sender, EventArgs e)
        {
            if (this.cbxSmartTag.Text == string.Empty)
            {
                this.cbxSmartTag.Items.Clear();
                this.cbxSmartTag.Items.AddRange(tagCollection.ToArray());
            }
        }

    }
}
