using ATSCADAWebApp.Component.SVG;
using ATSCADAWebApp.Extension.Method;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.SVGValue
{
    public partial class ATSCADASVGValueItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADASVG component;

        public ATSCADASVGValueItemEditor(ATSCADASVG component)
        {
            InitializeComponent();
            this.component = component;

            this.Load += (sender, e) => OnLoad();
            this.lstvSVGValueItem.SelectedIndexChanged += (sender, e) => OnListViewSelectedIndexChanged();

            this.btnUpdate.Click += (sender, e) => OnButtonUpdateClick();
            this.btnRemove.Click += (sender, e) => OnButtonRemoveClick();
            this.btnUp.Click += (sender, e) => OnButtonUpClick();
            this.btnDown.Click += (sender, e) => OnButtonDownClick();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        private void OnLoad()
        {
            foreach (var SVGValueItem in component.Items)
            {
                var listViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(new string[4]
                {
                    SVGValueItem.Name,
                    SVGValueItem.DataTagName,
                     SVGValueItem.Properties,
                     SVGValueItem.Type
                }));
                listViewItem.UseItemStyleForSubItems = false;
            }
            cbbProperties.SelectedIndex = 0;
            changeProperties();
        }

        private void OnListViewSelectedIndexChanged()
        {
            if (this.lstvSVGValueItem.SelectedItems.Count < 1) return;
            var selectedItem = this.lstvSVGValueItem.SelectedItems[0];

            this.txtName.Text = selectedItem.SubItems[0].Text;
            this.cbbProperties.Text = selectedItem.SubItems[2].Text;
            this.cbxDataTagName.TagName = selectedItem.SubItems[1].Text;
            this.cbbType.Text = selectedItem.SubItems[3].Text;
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var properties = this.cbbProperties.SelectedItem.ToString();
            var type = this.cbbType.SelectedItem.ToString();
 
            var min = this.txtMin.Text.Trim();
            var max = this.txtMax.Text.Trim();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(dataTagName)|| string.IsNullOrEmpty(properties)) return;

            foreach (ListViewItem listViewItem in this.lstvSVGValueItem.Items)
            {
                if (listViewItem.SubItems[0].Text == name)
                {
                    if (
                        listViewItem.SubItems[1].Text != dataTagName)
                    {
                        listViewItem.SubItems[1].Text = dataTagName;
                        hasChanges = true;
                    }
                    if (listViewItem.SubItems[2].Text != properties)
                    {
                        listViewItem.SubItems[2].Text = properties;
                        hasChanges = true;
                    }
                    if (listViewItem.SubItems[3].Text != type)
                    {
                        listViewItem.SubItems[3].Text = type;
                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(new string[6]
            {
                name, dataTagName,properties,type,min,max
            })) ;
            newListViewItem.UseItemStyleForSubItems = false;
            hasChanges = true;
        }

        private void OnButtonRemoveClick()
        {
            if (this.lstvSVGValueItem.SelectedItems.Count <= 0) return;
            foreach (ListViewItem listViewItem in this.lstvSVGValueItem.SelectedItems)
            {
                this.lstvSVGValueItem.Items.Remove(listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonUpClick()
        {
            if (this.lstvSVGValueItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGValueItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex > 0)
            {
                this.lstvSVGValueItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGValueItem.Items.Insert(selectedIndex - 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonDownClick()
        {
            if (this.lstvSVGValueItem.SelectedItems.Count <= 0) return;
            var listViewItem = this.lstvSVGValueItem.SelectedItems[0];
            var selectedIndex = listViewItem.Index;
            if (selectedIndex < this.lstvSVGValueItem.Items.Count - 1)
            {
                this.lstvSVGValueItem.Items.RemoveAt(selectedIndex);
                this.lstvSVGValueItem.Items.Insert(selectedIndex + 1, listViewItem);
                hasChanges = true;
            }
        }

        private void OnButtonOKClick()
        {
            if (this.hasChanges)
            {
                var SVGValueItems = new List<ATSCADASVGValueItem>();
                foreach (ListViewItem listViewItem in this.lstvSVGValueItem.Items)
                {
                    var name = listViewItem.SubItems[0].Text.Trim();
                    var dataTagName = listViewItem.SubItems[1].Text.Trim();
                    var properties = listViewItem.SubItems[2].Text.Trim();
                    var type = listViewItem.SubItems[3].Text.Trim();
                    //var min = listViewItem.SubItems[4].Text.Trim();
                    //var max = listViewItem.SubItems[5].Text.Trim();
                    if (string.IsNullOrEmpty(name)) continue;
                    SVGValueItems.Add(new ATSCADASVGValueItem()
                    {
                        Name = name,
                        DataTagName = dataTagName,
                        Properties = properties,
                        //Min = min,
                        //Max = max,
                        Type= type
                    });
                }
                this.component.Items = SVGValueItems;              
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbbProperties_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            changeProperties();
        }
        public void changeProperties()
        {
            if (this.cbbProperties.SelectedItem.ToString() == "Value")
            {
                cbbType.Items.Clear();
                string[] items = { "Bool",
                                    "Int",
                                    "Word",
                                    "Float",
                                    "Double",
                                    "String"};
                cbbType.Items.AddRange(items);
                cbbType.SelectedIndex = 0;
            }
            if (this.cbbProperties.SelectedItem.ToString() == "Animation")
            {
                cbbType.Items.Clear();
                string[] items = {  "Color",
                                    "Blink",
                                    "IsRunning"
                                    };
                cbbType.Items.AddRange(items);
                cbbType.SelectedIndex = 0;
            }
            else
            {
                cbbType.Items.Clear();
                string[] items = {"Color",
                                    };
                cbbType.Items.AddRange(items);
                cbbType.SelectedIndex = 0;
            }
          
        }

        private void cbbType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cbbType.SelectedItem.ToString() == "IsRunning")
            {
                label3.Visible = true;
                label4.Visible = true;
                txtMax.Visible = true;
                txtMin.Visible = true;
                txtMin.Text = "0";
                txtMax.Text = "100";
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
                txtMax.Visible = false;
                txtMin.Visible = false;
            }
        }
        private void importButton_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = openFileDialog.FileName;

                    try
                    {
                        List<List<string>> excelData = ReadExcelFile(excelFilePath);

                        if (excelData.Count > 0)
                        {
                            PopulateListView(excelData);
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi đọc tệp Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void PopulateListView(List<List<string>> excelData)
        {
            bool firstIteration = true;
            foreach (var rowData in excelData)
            {
                if (firstIteration)
                {
                    firstIteration = false;
                    continue; // Bỏ qua vòng lặp đầu tiên
                }
                var row = rowData.ToArray();
                var newListViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(new string[6]
                {
                    row[0],row[1],row[2],row[3],"0","100"
                    }));
                newListViewItem.UseItemStyleForSubItems = false;
                    hasChanges = true;
                }
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
    }
}
