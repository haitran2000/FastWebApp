using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public interface IComponentView
    {
        event Action DoubleClicked;

        event Action<string> NavigationChanged;

        ComponentPresenter Presenter { get; set; }

        ListViewItem SelectedItem { get; set; }

        int Count { get; }        

        int IndexOf(ListViewItem item);

        ListViewItem Get(int index);

        ListViewItem AddItem(IComponent component);

        void AddItems(IEnumerable<IComponent> components);

        void InsertItem(int index, ListViewItem item);

        void UpdateView(ListViewItem item);

        void Clear();

        void RemoveSelection();        
    }
}
