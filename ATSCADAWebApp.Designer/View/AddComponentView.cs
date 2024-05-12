using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using ATSCADAWebApp.Extension.Method;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public partial class AddComponentView : Form, IAddComponentView
    {
        public event Action Loaded;
        
        public AddComponentPresenter Presenter { get; set; }

        public IComponent Component => (this.lstbComponent.SelectedItem as ComponentItem)?.Value;      

        public AddComponentView()
        {
            InitializeComponent();

            this.Load += (sender, e) => OnLoad();
            this.lstbComponent.SelectedIndexChanged += (sender, e) => OnSelectedIndexChanged();
            this.lstbComponent.MouseDoubleClick += (sender, e) => OnMouseDoubleClicked();

            this.btnOK.Click += (sender, e) => OnButtonOKClick();
            this.btnCancel.Click += (sender, e) => OnButtonCancelClick();
        }

        public void SetTemplates(IDictionary<Type, IComponent> templates)
        {
            this.lstbComponent.Items.Clear();
            foreach (KeyValuePair<Type, IComponent> entry in templates)
            {
                this.lstbComponent.Items.Add(new ComponentItem()
                {
                    Display = entry.Key.GetDisplayName(),
                    Value = entry.Value
                });
            }
            if (this.lstbComponent.Items.Count > 0)
            {
                this.lstbComponent.SelectedIndex = 0;
                this.btnOK.Enabled = true;
            }
        }

        private void OnLoad()
        {            
            this.lstbComponent.DisplayMember = "Display";
            this.lstbComponent.ValueMember = "Value";
            this.lstbComponent.Sorted = true;
            Loaded?.Invoke();
        }

        private void OnSelectedIndexChanged()
        {
            var selectedComponent = Component;
            this.txtDescription.Text = selectedComponent is null ?
                string.Empty :
                selectedComponent.Description;
            var tool = this.lstbComponent.SelectedItem.ToString();
            if (tool.Equals("iStreamCamera"))
            {
                lblWebsite.Visible = true;
            }
            else
            {
                lblWebsite.Visible = false;
            }
        }

        private void OnMouseDoubleClicked()
        {
            if (this.lstbComponent.SelectedIndex < 0) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnButtonOKClick()
        {
            if (this.lstbComponent.SelectedIndex < 0) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnButtonCancelClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://atscada.com/");
        }
    }

    public class ComponentItem
    {
        public string Display { get; set; }
        public IComponent Value { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
