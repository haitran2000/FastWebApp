using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Danh sach cac doi tuong NotifyPropertyChanged
    /// Thong bao su kien khi co su thay doi trong danh sach phan tu (Add, Delete, Replacec, Update property)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BindableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public BindableCollection()
        {
            this.CollectionChanged += BindableCollectionChanged;
        }

        public BindableCollection(IEnumerable<T> collection) : base(collection)
        {
            this.CollectionChanged += BindableCollectionChanged;
            foreach (INotifyPropertyChanged item in collection)
                item.PropertyChanged += ItemPropertyChanged;

        }

        /// <summary>
        /// Mac dinh ObservableCollection chi thong bao event khi pha tu con duoc: ADD, DELETE, REPLACE
        /// Thay doi thuoc tinh (Property) cua phan tu con khong Raise Event.
        /// Can custom lai....
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.OldItems != null)
                    foreach (INotifyPropertyChanged item in e.OldItems)
                        item.PropertyChanged -= ItemPropertyChanged;

                // Khi thuoc tinh (property) cua phan tu con thay doi se RaiseEvent CollectionChanged voi Action = Replace
                if (e.NewItems != null)
                    foreach (INotifyPropertyChanged item in e.NewItems)
                        item.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var replace = new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Replace, 
                sender, 
                sender, 
                this.Items.IndexOf((T)sender)); 
            this.OnCollectionChanged(replace);
        }
    }
}
