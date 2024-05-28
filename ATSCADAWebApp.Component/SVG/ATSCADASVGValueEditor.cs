using ATSCADAWebApp.Component.SVG;
using ATSCADAWebApp.Extension.Method;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace ATSCADAWebApp.Component.SVGValue
{
    public partial class ATSCADASVGValueItemEditor : Form
    {
        private bool hasChanges;

        private readonly ATSCADASVG component;
        private string settingAnimation;
        private Panel panel;
        private TextBox inputTextBox;
        private Button submitButton;
        private List<TextBox> breakpointTextBoxes = new List<TextBox>();
        private List<Button> colorButtons = new List<Button>();
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
            panel_status_color.Visible = false;
            panel_status_text.Visible = false;
            panelSettingAnimation.Visible = false;
        }

        private void OnLoad()
        {
            //if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Color")
            //{

            //}    
            foreach (var SVGValueItem in component.Items)
            {
                var listViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(new string[5]
                {
                    SVGValueItem.Name,
                    SVGValueItem.DataTagName,
                     SVGValueItem.Properties,
                     SVGValueItem.Type,
                     SVGValueItem.Attribute
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
            try
            {
                if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Text")
                {
                    string atribute = selectedItem.SubItems[4].Text;
                    string[] parts = atribute.Split(new string[] { "--" }, StringSplitOptions.None);
                    this.textBad.Text = parts[0];
                    this.textGood.Text = parts[1];
                }
                if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Color")
                {
                    string atribute = selectedItem.SubItems[4].Text;
                    string[] parts = atribute.Split(new string[] { "--" }, StringSplitOptions.None);
                    this.txtBadColor.Text = parts[0];
                    System.Drawing.Color colorbad = ColorTranslator.FromHtml(parts[0]);
                    this.btnPickBadColor.BackColor = colorbad;
                    this.txtGoodColor.Text = parts[1];
                    System.Drawing.Color colorgood = ColorTranslator.FromHtml(parts[1]);
                    this.btnPickGoodColor.BackColor = colorgood;
                }
                if (this.cbbProperties.SelectedItem.ToString() == "Animation")
                {
                    string atribute = selectedItem.SubItems[4].Text;
                    GenerateInputs(atribute);
                }
            }
            catch
            {

            }
            
        }
        private void GenerateInputs(string data)
        {
            panelAnimation.Controls.Clear();

            var pairs = data.Split(',');

            inputNumber.Value = pairs.Length;

            for (int i = 0; i < pairs.Length; i++)
            {
                
                var parts = pairs[i].Split('-');
                System.Drawing.Color color = ColorTranslator.FromHtml(parts[1]);
                if (parts.Length == 2)
                {
                    var breakpointLabel = new Label
                    {
                        Text = "Breakpoint:",
                        Location = new Point(10, i * 30 + 10),
                        AutoSize = true
                    };

                    var breakpointTextBox = new TextBox
                    {
                        Location = new Point(80, i * 30 + 7),
                        Size = new Size(100, 20),
                        Name = $"breakpointTextBox{i}",
                        Text = parts[0]
                    };

                    var colorLabel = new Label
                    {
                        Text = "Color:",
                        Location = new Point(190, i * 30 + 10),
                        AutoSize = true
                    };

                    var colorButton = new Button
                    {
                        Location = new Point(230, i * 30 + 5),
                        Size = new Size(75, 23),
                        BackColor = color,
                        Text = "Select",
                        Name = $"colorButton{i}",
                    };
                    colorButton.Click += (s, e) => SelectColor(colorButton);
                    panelAnimation.Controls.Add(breakpointLabel);
                    panelAnimation.Controls.Add(breakpointTextBox);
                    panelAnimation.Controls.Add(colorLabel);
                    panelAnimation.Controls.Add(colorButton);
                }
            }
        }

        private void OnButtonUpdateClick()
        {
            var name = this.txtName.Text.Trim();
            var dataTagName = this.cbxDataTagName.TagName.Trim();
            var properties = this.cbbProperties.SelectedItem.ToString();
            var type = this.cbbType.SelectedItem.ToString();
            string atribute1 = "";
            string atribute2 = "";
            string atribute = "";
            if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Text")
            {
                atribute1 = this.textBad.Text;
                atribute2 = this.textGood.Text;
                atribute = atribute1 + "--" + atribute2;
            }
            if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Color")
            {
                atribute1 = this.txtBadColor.Text;
                atribute2 = this.txtGoodColor.Text;
                atribute = atribute1 + "--" + atribute2;
            }
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
                    if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Text")
                    {
                        listViewItem.SubItems[4].Text = atribute;
                        hasChanges = true;
                    }
                    if (this.cbbProperties.SelectedItem.ToString() == "Status" && this.cbbType.SelectedItem.ToString() == "Color")
                    {
                        listViewItem.SubItems[4].Text = atribute;
                        hasChanges = true;
                    }
                    if (this.cbbProperties.SelectedItem.ToString() == "Animation")
                    {
                        listViewItem.SubItems[4].Text = settingAnimation;
                        hasChanges = true;
                    }
                    return;
                }
            }

            var newListViewItem = this.lstvSVGValueItem.Items.Add(new ListViewItem(new string[5]
            {
                name, dataTagName,properties,type,atribute
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
                    var attribute = listViewItem.SubItems[4].Text.Trim();
                    if (string.IsNullOrEmpty(name)) continue;
                    SVGValueItems.Add(new ATSCADASVGValueItem()
                    {
                        Name = name,
                        DataTagName = dataTagName,
                        Properties = properties,
                        Attribute = attribute,
                        Type = type
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
                string[] items = {"String"};
                cbbType.Items.AddRange(items);
                cbbType.SelectedIndex = 0;
            }
            else if (this.cbbProperties.SelectedItem.ToString() == "Status")
            {
                cbbType.Items.Clear();
                string[] items = {  "Color",
                                    "Text"
                                    };
                cbbType.Items.AddRange(items);
                cbbType.SelectedIndex = 0;
            }
            else if (this.cbbProperties.SelectedItem.ToString() == "Animation")
            {
                panel_status_text.Visible = false;
                panel_status_color.Visible = false;
                panelSettingAnimation.Visible = true;
                cbbType.Items.Clear();
                string[] items = {  "Color",
                                    "Blink"
                                    };
                cbbType.Items.AddRange(items);
                cbbType.SelectedIndex = 0;
            }

        }

        private void cbbType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(this.cbbProperties.SelectedItem.ToString() == "Status"&&this.cbbType.SelectedItem.ToString() == "Color")
            {
                panel_status_color.Visible = true;
                panel_status_text.Visible = false;
                panelSettingAnimation.Visible = false;
            }
            else if (this.cbbProperties.SelectedItem.ToString() == "Status"&&this.cbbType.SelectedItem.ToString() == "Text")
            {
                panel_status_text.Visible = true;
                panel_status_color.Visible = false;
                panelSettingAnimation.Visible = false;
            }
            else
            {
                panel_status_color.Visible = false;
                panel_status_text.Visible = false;
            }    
        }
        private void importButton_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"C:\Program Files\ATPro\ATSCADA\Reports";
                openFileDialog.FileName = "iSVG_FileImport.xlsx";
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
                            MessageBox.Show("No data to display.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while reading the Excel file. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Hiển thị hộp thoại màu và kiểm tra nếu người dùng chọn màu
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy màu được chọn
                    btnPickBadColor.BackColor = colorDialog.Color;
                    System.Drawing.Color selectedColor = colorDialog.Color;
                    txtBadColor.Text = ColorToHex(selectedColor);

                }
            }
        }
        private string ColorToHex(System.Drawing.Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Hiển thị hộp thoại màu và kiểm tra nếu người dùng chọn màu
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    btnPickGoodColor.BackColor = colorDialog.Color;
                    // Lấy màu được chọn
                    System.Drawing.Color selectedColor = colorDialog.Color;
                    txtGoodColor.Text = ColorToHex(selectedColor);

                }
            }
        }
        private void GenerateRows(int numberOfRows)
        {
            if (numberOfRows <= 0)
                return;
            //// Lưu trữ dữ liệu của các dòng đã nhập trước đó
            //List<string> breakpoints = new List<string>();
            //List<string> colors = new List<string>();
            //foreach (var breakpointTextBox in breakpointTextBoxes)
            //{
            //    breakpoints.Add(breakpointTextBox.Text);
            //}
            //foreach (var colorTextBox in colorButtons)
            //{
            //    colors.Add(ColorTranslator.ToHtml(colorTextBox.BackColor));
            //}
            this.panelAnimation.Controls.Clear();

            for (int i = 0; i < numberOfRows; i++)
            {
                var breakpointLabel = new Label
                {
                    Text = "Breakpoint:",
                    Location = new Point(10, i * 30 + 10),
                    AutoSize = true
                };

                var breakpointTextBox = new TextBox
                {
                    Location = new Point(80, i * 30 + 7),
                    Size = new Size(100, 20),
                    Name = $"breakpointTextBox{i}"
                };
                breakpointTextBox.TextChanged += BreakpointTextBox_TextChanged;

                var colorLabel = new Label
                {
                    Text = "Color:",
                    Location = new Point(190, i * 30 + 10),
                    AutoSize = true
                };

                var colorButton = new Button
                {
                    Location = new Point(230, i * 30 + 5),
                    Size = new Size(75, 23),
                    BackColor = System.Drawing.Color.White,
                    Text = "Select",
                    Name = $"colorButton{i}"
                };
                //if (i < breakpoints.Count)
                //{
                //    breakpointTextBox.Text = breakpoints[i];
                //}
                //if (i < colors.Count)
                //{
                //    System.Drawing.Color colorgood = ColorTranslator.FromHtml(colors[i]);
                //    colorButton.BackColor = colorgood;
                //}
                colorButton.Click += (s, e) => SelectColor(colorButton);
                breakpointTextBoxes.Add(breakpointTextBox);
                colorButtons.Add(colorButton);
                this.panelAnimation.Controls.Add(breakpointLabel);
                this.panelAnimation.Controls.Add(breakpointTextBox);
                this.panelAnimation.Controls.Add(colorLabel);
                this.panelAnimation.Controls.Add(colorButton);
            }
        }
        private void BreakpointTextBox_TextChanged(object sender, EventArgs e)
        {
            // Example: Update a corresponding colorTextBox when a breakpointTextBox changes
            var breakpointTextBox = sender as TextBox;
            if (breakpointTextBox != null)
            {
                int index = breakpointTextBoxes.IndexOf(breakpointTextBox);
                // Do something with breakpointTextBox.Text
            }
        }
        private void SelectColor(Button colorButton)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    colorButton.BackColor = colorDialog.Color;
                }
            }
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var result = new HashSet<string>();

            foreach (System.Windows.Forms.Control control in this.panelAnimation.Controls)
            {
                if (control is TextBox textBox && textBox.Name.StartsWith("breakpointTextBox"))
                {
                    var index = textBox.Name.Replace("breakpointTextBox", "");
                    var colorButton = this.panelAnimation.Controls.OfType<Button>().FirstOrDefault(b => b.Name == $"colorButton{index}");
                    if (colorButton != null)
                    {
                        var breakpoint = textBox.Text;
                        var color = ColorTranslator.ToHtml(colorButton.BackColor);
                        result.Add($"{breakpoint}-{color}");
                    }
                }
            }

            settingAnimation = string.Join(",", result);
            MessageBox.Show(settingAnimation);
        }
        private void inputNumber_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.inputNumber.Text, out int numberOfRows))
            {
                GenerateRows(numberOfRows+1);
            }
            else
            {
                this.panelAnimation.Controls.Clear(); // Clear panel if input is invalid
            }
        }

        private void inputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void inputNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void inputNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Xử lý khi người dùng nhấn phím lên
                if (int.TryParse(this.inputNumber.Text, out int numberOfRows))
                {
                    GenerateRows(numberOfRows + 1);
                }
                else
                {
                    this.panelAnimation.Controls.Clear(); // Clear panel if input is invalid
                }
            }
        }
    }
}
