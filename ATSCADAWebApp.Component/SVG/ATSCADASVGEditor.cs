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
using ATSCADAWebApp.Component.SVGHyperLink;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;

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
            lbLoadFileTo.Text = "";
            ComponentName = this.component.Name;
            Description = this.component.Description;
            Color = this.component.Color;
            pathSVG = this.component.FilePath;
            readFileSVG(pathSVG);
            LoadListView();
            LoadListViewAlarm();
            LoadListViewCutaWay();
            LoadListViewHyperLink();
            LoadListViewControlValue();
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
        private void LoadListViewHyperLink()
        {
            this.lstvSVGHyperLinkItem.Items.Clear();
            foreach (var item in this.component.ItemsHyperLink)
            {
                var listViewItem = this.lstvSVGHyperLinkItem.Items.Add(new ListViewItem(new string[4]
                {
                    item.Name,item.DataTagName,item.Type,item.Color
                }));

                listViewItem.UseItemStyleForSubItems = false;
            }
        }
        private void LoadListViewControlValue()
        {
            this.listViewControl.Items.Clear();
            foreach (var item in this.component.ItemsControlValue)
            {
                var listViewItem = this.listViewControl.Items.Add(new ListViewItem(new string[4]
                {
                    item.Name,item.DataTagName,item.Type,item.Atribute
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
            string appPath = @"C:\Program Files\ATPro\iSVGEditor\iSVG.exe";
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

        private void button3_Click(object sender, EventArgs e)
        {
            var itemHyperLink = new ATSCADASVGHyperLinkItemEditor(this.component);
            var dialogResult = itemHyperLink.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListViewHyperLink();
        }

        private void btnReFresh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = @"C:\Program Files\ATPro\ATSCADA\Reports";
                //openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                //openFileDialog.FileName = "iSVG_FileImport";
                string excelFilePath = @"C:\Program Files\ATPro\ATSCADA\Reports\iSVG_FileImport.xlsx";
                // Kiểm tra xem tệp tồn tại hay không
                
                try
                    {
                    if (File.Exists(excelFilePath))
                    {
                        try
                        {
                            List<List<string>> excelData = ReadExcelFile(excelFilePath);

                            if (excelData.Count > 0)
                            {
                                PopulateListView(excelData);
                            }
                            else
                            {
                                MessageBox.Show("No data to display.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while reading the Excel file. " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Excel file does not exist.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while reading the Excel file. " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
        private void PopulateListView(List<List<string>> excelData)
        {
            this.lstvSVGValueItem.Items.Clear();
            this.lstvSVGValueItem.View = System.Windows.Forms.View.Details;
            this.component.Items.Clear();
            bool firstIteration = true;
            foreach (var rowData in excelData)
            {
                if (firstIteration)
                {
                    firstIteration = false;
                    continue; // Bỏ qua vòng lặp đầu tiên
                }
                var row = rowData.ToArray();

                // Kiểm tra xem dòng đã tồn tại trong ListView hay chưa
                bool exists = false;
                foreach (ListViewItem item in this.lstvSVGValueItem.Items)
                {
                    if (item.SubItems.Count >= 5 &&
                        item.SubItems[0].Text == row[0] &&
                        item.SubItems[1].Text == row[1] &&
                        item.SubItems[2].Text == row[2] &&
                        item.SubItems[3].Text == row[3] &&
                        item.SubItems[4].Text == row[4])
                    {
                        exists = true;
                        break;
                    }
                }

                // Nếu dòng không tồn tại, thêm dòng mới
                if (!exists)
                {
                    var newListViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(row));
                    ATSCADASVGValueItem item = new ATSCADASVGValueItem();
                    item.Name = row[0];
                    item.DataTagName = row[1];
                    item.Properties = row[2];
                    item.Type = row[3];
                    item.Attribute = row[4];
                    this.component.Items.Add(item);
                    newListViewItem.UseItemStyleForSubItems = false;
                }
            }
            lbLoadFileTo.Text = @"Load file C:\Program Files\ATPro\ATSCADA\Reports\iSVG_FileImport.xlsx";
        }
        private List<List<string>> ReadExcelFile(string filePath)
        {
            List<List<string>> excelData = new List<List<string>>();

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = spreadsheetDocument.WorkbookPart.Workbook.Descendants<Sheet>();
                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheets.First().Id);

                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                foreach (Row row in sheetData.Elements<Row>())
                {
                    List<string> rowData = new List<string>();
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        rowData.Add(GetCellValue(cell, spreadsheetDocument));
                    }
                    excelData.Add(rowData);
                }
            }

            return excelData;
        }
        private string GetCellValue(Cell cell, SpreadsheetDocument spreadsheetDocument)
        {
            SharedStringTablePart sharedStringPart = spreadsheetDocument.WorkbookPart.SharedStringTablePart;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                int index = int.Parse(cell.CellValue.Text);
                return sharedStringPart.SharedStringTable.ElementAt(index).InnerText;
            }
            else
            {
                return cell.CellValue.Text;
            }
        }

        private void btnEditControl_Click(object sender, EventArgs e)
        {
            var itemProperties = new ATSCADASVGControlValueItemEditor(this.component);
            var dialogResult = itemProperties.ShowDialog();
            if (dialogResult == DialogResult.OK)
                LoadListViewControlValue();
        }
    }
}
