
namespace ATSCADAWebApp.Component.DataReporter
{
    partial class ATSCADADataReporterItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADADataReporterItemEditor));
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.lstvDataReporterItem = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageProperties = new System.Windows.Forms.TabPage();
            this.txtColor = new ATSCADAWebApp.Extension.Color.TextBoxColor();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabElement.SuspendLayout();
            this.pageProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(117, 447);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 28);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(117, 411);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 28);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(11, 447);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Location = new System.Drawing.Point(11, 411);
            this.btnAddUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnAddUpdate.TabIndex = 4;
            this.btnAddUpdate.Text = "Update";
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            // 
            // lstvDataReporterItem
            // 
            this.lstvDataReporterItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAlias,
            this.colColor});
            this.lstvDataReporterItem.FullRowSelect = true;
            this.lstvDataReporterItem.GridLines = true;
            this.lstvDataReporterItem.HideSelection = false;
            this.lstvDataReporterItem.Location = new System.Drawing.Point(11, 180);
            this.lstvDataReporterItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstvDataReporterItem.MultiSelect = false;
            this.lstvDataReporterItem.Name = "lstvDataReporterItem";
            this.lstvDataReporterItem.Size = new System.Drawing.Size(504, 223);
            this.lstvDataReporterItem.TabIndex = 26;
            this.lstvDataReporterItem.UseCompatibleStateImageBehavior = false;
            this.lstvDataReporterItem.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colAlias
            // 
            this.colAlias.Text = "Alias";
            this.colAlias.Width = 155;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            this.colColor.Width = 100;
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageProperties);
            this.tabElement.Location = new System.Drawing.Point(11, 10);
            this.tabElement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(511, 162);
            this.tabElement.TabIndex = 25;
            // 
            // pageProperties
            // 
            this.pageProperties.Controls.Add(this.txtColor);
            this.pageProperties.Controls.Add(this.txtAlias);
            this.pageProperties.Controls.Add(this.lblName);
            this.pageProperties.Controls.Add(this.txtName);
            this.pageProperties.Controls.Add(this.lblAlias);
            this.pageProperties.Controls.Add(this.lblColor);
            this.pageProperties.Location = new System.Drawing.Point(4, 25);
            this.pageProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageProperties.Name = "pageProperties";
            this.pageProperties.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageProperties.Size = new System.Drawing.Size(503, 133);
            this.pageProperties.TabIndex = 0;
            this.pageProperties.Text = "Properties";
            this.pageProperties.UseVisualStyleBackColor = true;
            // 
            // txtColor
            // 
            this.txtColor.Color = "#008080";
            this.txtColor.Location = new System.Drawing.Point(108, 84);
            this.txtColor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(369, 25);
            this.txtColor.TabIndex = 20;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(108, 50);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(368, 22);
            this.txtAlias.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(368, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(23, 55);
            this.lblAlias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(42, 17);
            this.lblAlias.TabIndex = 18;
            this.lblAlias.Text = "Alias:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(23, 89);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(45, 17);
            this.lblColor.TabIndex = 19;
            this.lblColor.Text = "Color:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(416, 447);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(416, 411);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ATSCADADataReporterItemEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(528, 485);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddUpdate);
            this.Controls.Add(this.lstvDataReporterItem);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADADataReporterItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataReporter Item Editor";
            this.tabElement.ResumeLayout(false);
            this.pageProperties.ResumeLayout(false);
            this.pageProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.ListView lstvDataReporterItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAlias;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage pageProperties;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColumnHeader colColor;
        private Extension.Color.TextBoxColor txtColor;
    }
}