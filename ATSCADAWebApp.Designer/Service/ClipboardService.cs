using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Designer.Service
{
    /// <summary>
    /// Quan ly cac doi tuong duoc Copy, Cut
    /// </summary>
    public class ClipboardService : BindableCore, IClipboardService
    {
        private ClipboardAction action;

        private IComponent source;

        public ClipboardAction Action => this.action;

        private int numOfCopy = 0;
 
        public IComponent Source
        {
            get => this.source;
            private set => SetField(ref this.source, value);
        }

        public bool ContainsData => this.action != ClipboardAction.None && this.source is IComponent;

        public IComponent GetFromClipboard()
        {
            if (!ContainsData) return default;
            IComponent component = default;
            switch (this.action)
            {
                case ClipboardAction.Copy:
                    component = this.source.DeepCopy();
                    var nameExtend = this.numOfCopy < 1 ? " - Copy" : $" - Copy ({this.numOfCopy})";
                    component.Name = $"{component.Name}{nameExtend}";
                    this.numOfCopy++;
                    break;
                case ClipboardAction.Cut:
                    component = this.source.DeepCopy();
                    Clear();
                    break;
                default:
                    break;
            }
            return component;
        }

        public void SetToClipboard(ClipboardAction action, IComponent source)
        {
            this.action = action;
            Source = source;
            numOfCopy = 0;
        }       

        public void Clear()
        {
            this.action = ClipboardAction.None;
            Source = null;
            numOfCopy = 0;
        }
    }
}
