using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Designer.Service
{
    public interface IClipboardService : System.ComponentModel.INotifyPropertyChanged
    {
        ClipboardAction Action { get; }

        IComponent Source { get; }

        bool ContainsData { get; }

        IComponent GetFromClipboard();

        void SetToClipboard(ClipboardAction action, IComponent source);

        void Clear();
    }
}
