using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Thong bao su kien khi Property Value thay doi
    /// </summary>
    [Serializable]
    public abstract class BindableCore : INotifyPropertyChanged
    {       
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Dung trong ham Setter. Neu gia tri thay doi thi thong bao su kien
        /// </summary>
        /// <typeparam name="T">Kieu du lieu</typeparam>
        /// <param name="field">Bien</param>
        /// <param name="value">Gia tri cap nhat</param>
        /// <param name="propertyName">Ten thuoc tinh- tu dong goi trong ham SETTER thong qua CallerMemberName Attribute</param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;           
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler;
            lock (this) handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
