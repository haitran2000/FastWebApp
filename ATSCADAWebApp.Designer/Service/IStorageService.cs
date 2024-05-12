using ATSCADAWebApp.Core;
using System.Collections.Generic;

namespace ATSCADAWebApp.Designer.Service
{
    public interface IStorageService : System.ComponentModel.INotifyPropertyChanged
    {
        string Location { get; }

        IComposite Composite { get; }

        bool RequestSaved { get; }

        void New();

        void New(IEnumerable<IComponent> components);

        void Open();

        void Save();

        void SaveAs();

        void Register();

        bool CheckSaved();
    }
}
