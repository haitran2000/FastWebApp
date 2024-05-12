
namespace ATSCADAWebApp.Component.Chart
{
    partial class ATSCADAChartEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAChartEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.nudSampleNum = new System.Windows.Forms.NumericUpDown();
            this.lblSampleNum = new System.Windows.Forms.Label();
            this.txtYLabel = new System.Windows.Forms.TextBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.txtXLabel = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblYLabel = new System.Windows.Forms.Label();
            this.lblXLabel = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageItem = new System.Windows.Forms.TabPage();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lstvChartItem = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pageExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSampleNum)).BeginInit();
            this.pageBase.SuspendLayout();
            this.tabElement.SuspendLayout();
            this.pageItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(431, 313);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(323, 313);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(121, 220);
            this.txtGridColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(368, 22);
            this.txtGridColumn.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 224);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Grid column:";
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.nudSampleNum);
            this.pageExtend.Controls.Add(this.lblSampleNum);
            this.pageExtend.Controls.Add(this.txtYLabel);
            this.pageExtend.Controls.Add(this.cbxType);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.label1);
            this.pageExtend.Controls.Add(this.txtXLabel);
            this.pageExtend.Controls.Add(this.txtHeight);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblYLabel);
            this.pageExtend.Controls.Add(this.lblXLabel);
            this.pageExtend.Controls.Add(this.lblHeight);
            this.pageExtend.Controls.Add(this.lblType);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 25);
            this.pageExtend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageExtend.Size = new System.Drawing.Size(515, 268);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // nudSampleNum
            // 
            this.nudSampleNum.Location = new System.Drawing.Point(121, 114);
            this.nudSampleNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSampleNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSampleNum.Name = "nudSampleNum";
            this.nudSampleNum.Size = new System.Drawing.Size(369, 22);
            this.nudSampleNum.TabIndex = 19;
            this.nudSampleNum.ThousandsSeparator = true;
            // 
            // lblSampleNum
            // 
            this.lblSampleNum.AutoSize = true;
            this.lblSampleNum.Location = new System.Drawing.Point(23, 118);
            this.lblSampleNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSampleNum.Name = "lblSampleNum";
            this.lblSampleNum.Size = new System.Drawing.Size(90, 17);
            this.lblSampleNum.TabIndex = 15;
            this.lblSampleNum.Text = "Sample num:";
            // 
            // txtYLabel
            // 
            this.txtYLabel.Location = new System.Drawing.Point(121, 183);
            this.txtYLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYLabel.Name = "txtYLabel";
            this.txtYLabel.Size = new System.Drawing.Size(368, 22);
            this.txtYLabel.TabIndex = 7;
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(121, 48);
            this.cbxType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(368, 24);
            this.cbxType.TabIndex = 4;
            // 
            // txtXLabel
            // 
            this.txtXLabel.Location = new System.Drawing.Point(121, 149);
            this.txtXLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXLabel.Name = "txtXLabel";
            this.txtXLabel.Size = new System.Drawing.Size(368, 22);
            this.txtXLabel.TabIndex = 6;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(121, 81);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(368, 22);
            this.txtHeight.TabIndex = 5;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(121, 17);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(368, 22);
            this.txtContent.TabIndex = 3;
            // 
            // lblYLabel
            // 
            this.lblYLabel.AutoSize = true;
            this.lblYLabel.Location = new System.Drawing.Point(23, 187);
            this.lblYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYLabel.Name = "lblYLabel";
            this.lblYLabel.Size = new System.Drawing.Size(61, 17);
            this.lblYLabel.TabIndex = 7;
            this.lblYLabel.Text = "Y-Label:";
            // 
            // lblXLabel
            // 
            this.lblXLabel.AutoSize = true;
            this.lblXLabel.Location = new System.Drawing.Point(23, 153);
            this.lblXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXLabel.Name = "lblXLabel";
            this.lblXLabel.Size = new System.Drawing.Size(56, 17);
            this.lblXLabel.TabIndex = 6;
            this.lblXLabel.Text = "X-label:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(23, 85);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(53, 17);
            this.lblHeight.TabIndex = 5;
            this.lblHeight.Text = "Height:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(23, 55);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(23, 21);
            this.lblContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(61, 17);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "Content:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(121, 52);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(368, 106);
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 55);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(368, 22);
            this.txtName.TabIndex = 1;
            // 
            // pageBase
            // 
            this.pageBase.Controls.Add(this.txtDescription);
            this.pageBase.Controls.Add(this.lblDescription);
            this.pageBase.Controls.Add(this.txtName);
            this.pageBase.Controls.Add(this.lblName);
            this.pageBase.Location = new System.Drawing.Point(4, 25);
            this.pageBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageBase.Name = "pageBase";
            this.pageBase.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageBase.Size = new System.Drawing.Size(515, 268);
            this.pageBase.TabIndex = 0;
            this.pageBase.Text = "Base";
            this.pageBase.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Controls.Add(this.pageItem);
            this.tabElement.Location = new System.Drawing.Point(8, 9);
            this.tabElement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(523, 297);
            this.tabElement.TabIndex = 3;
            // 
            // pageItem
            // 
            this.pageItem.Controls.Add(this.btnEdit);
            this.pageItem.Controls.Add(this.lstvChartItem);
            this.pageItem.Location = new System.Drawing.Point(4, 25);
            this.pageItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageItem.Name = "pageItem";
            this.pageItem.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageItem.Size = new System.Drawing.Size(515, 268);
            this.pageItem.TabIndex = 2;
            this.pageItem.Text = "Items";
            this.pageItem.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(404, 9);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 28);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // lstvChartItem
            // 
            this.lstvChartItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colContent,
            this.colTagName,
            this.colColor});
            this.lstvChartItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstvChartItem.FullRowSelect = true;
            this.lstvChartItem.GridLines = true;
            this.lstvChartItem.HideSelection = false;
            this.lstvChartItem.Location = new System.Drawing.Point(4, 48);
            this.lstvChartItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstvChartItem.Name = "lstvChartItem";
            this.lstvChartItem.Size = new System.Drawing.Size(507, 216);
            this.lstvChartItem.TabIndex = 0;
            this.lstvChartItem.UseCompatibleStateImageBehavior = false;
            this.lstvChartItem.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 65;
            // 
            // colContent
            // 
            this.colContent.Text = "Content";
            this.colContent.Width = 80;
            // 
            // colTagName
            // 
            this.colTagName.Text = "Tag name";
            this.colTagName.Width = 155;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            this.colColor.Width = 70;
            // 
            // ATSCADAChartEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 352);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAChartEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart Editor";
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSampleNum)).EndInit();
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.tabElement.ResumeLayout(false);
            this.pageItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage pageExtend;
        private System.Windows.Forms.TextBox txtXLabel;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblYLabel;
        private System.Windows.Forms.Label lblXLabel;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageItem;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.TextBox txtYLabel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lstvChartItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colContent;
        private System.Windows.Forms.ColumnHeader colTagName;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.Label lblSampleNum;
        private System.Windows.Forms.NumericUpDown nudSampleNum;
    }
}