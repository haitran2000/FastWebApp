using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public class ComponentView : ListView, IComponentView
    {
        private string navigation;

        private int lastSelectedIndex = -1;

        public event Action DoubleClicked;

        public event Action<string> NavigationChanged;

        public ComponentPresenter Presenter { get; set; }

        public ListViewItem SelectedItem
        {
            get
            {
                if (this.SelectedItems.Count < 1) return default;
                return this.SelectedItems[0];
            }
            set
            {
                if (value is null) return;
                value.Selected = true;
            }
        }

        public int Count => this.Items.Count;

        public ComponentView()
        {
            this.Dock = DockStyle.Fill;
            var imageList = new ImageList();
            imageList.Images.AddRange(new Image[5]
            {
                Properties.Resources.View,
                Properties.Resources.Row,
                Properties.Resources.Column,
                Properties.Resources.Component,
                Properties.Resources.Selected
            });
            this.SmallImageList = imageList;
            this.LargeImageList = imageList;
            this.View = System.Windows.Forms.View.Details;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.HideSelection = false;
            this.MultiSelect = false;
            this.UseCompatibleStateImageBehavior = false;
            this.Columns.AddRange(new ColumnHeader[4]
            {
                new ColumnHeader(){ Text = "Name", Width = 160},
                new ColumnHeader(){ Text = "Type", Width = 120},
                new ColumnHeader(){ Text = "Grid", Width = 120},
                new ColumnHeader(){ Text = "Description", Width = 230}
            });
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            this.MouseDoubleClick += (sender, e) => OnEventMouseDoubleClick(e);
            this.SelectedIndexChanged += (sender, e) => OnEventSelectedIndexChanged();
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        public int IndexOf(ListViewItem item) => this.Items.IndexOf(item);

        public ListViewItem Get(int index)
        {
            if (index > this.Items.Count - 1) return default;
            return this.Items[index];
        }

        public ListViewItem AddItem(IComponent component)
        {
            var listViewItem = this.Items.Add(new ListViewItem(new string[4]
            {
                component.Name,
                component.GetType().Name,
                (component as ISupportGrid)?.GridColumn,
                component.Description
            }));
            listViewItem.Tag = component;
            listViewItem.ImageIndex = (int)component.Level - 1;
            return listViewItem;
        }

        public void AddItems(IEnumerable<IComponent> components)
        {
            var listViewItems = new List<ListViewItem>();
            foreach (var component in components)
            {
                var listViewItem = new ListViewItem(new string[4]
                {
                    component.Name,
                    component.GetType().Name,
                    (component as ISupportGrid)?.GridColumn,
                    component.Description
                });
                listViewItem.Tag = component;
                listViewItem.ImageIndex = (int)component.Level - 1;
                listViewItems.Add(listViewItem);
            }
            this.Items.AddRange(listViewItems.ToArray());
        }

        public void InsertItem(int index, ListViewItem item)
        {
            var listViewItem = this.Items.Insert(index, item);
            listViewItem.Selected = true;
        }

        public void UpdateView(ListViewItem item)
        {
            if (item.Tag is IComponent component)
            {
                item.SubItems[0].Text = component.Name;
                item.SubItems[1].Text = component.GetType().Name;
                item.SubItems[2].Text = (component as ISupportGrid)?.GridColumn;
                item.SubItems[3].Text = component.Description;
                UpdateNavigation();
            }
        }

        public new void Clear()
        {
            this.Items.Clear();
            this.lastSelectedIndex = -1;
            UpdateNavigation();
        }

        public void RemoveSelection()
        {
            this.SelectedItems.Clear();
            if (this.lastSelectedIndex > -1 && this.lastSelectedIndex < this.Items.Count)
            {
                var lastSelectedItem = this.Items[this.lastSelectedIndex];
                lastSelectedItem.ImageIndex = (int)(lastSelectedItem?.Tag as IComponent).Level - 1;
            }               
            this.lastSelectedIndex = -1;
            UpdateNavigation();
        }

        private void OnEventMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            DoubleClicked?.Invoke();
        }

        private void OnEventSelectedIndexChanged()
        {
            var selectedItem = SelectedItem;
            if (selectedItem != null)
            {
                selectedItem.ImageIndex = 4;
                if (this.lastSelectedIndex > -1 && this.lastSelectedIndex < this.Items.Count)
                    this.Items[this.lastSelectedIndex].ImageIndex = (int)(selectedItem?.Tag as IComponent).Level - 1;
                this.lastSelectedIndex = selectedItem.Index;
            }
            UpdateNavigation();
        }

        private void UpdateNavigation()
        {
            var selectedItem = SelectedItem;
            var navigation = selectedItem is null ?
                string.Empty : $"/{selectedItem.Text}";

            if (string.Equals(this.navigation, navigation)) return;
            this.navigation = navigation;
            NavigationChanged?.Invoke(this.navigation);
        }
    }
}
