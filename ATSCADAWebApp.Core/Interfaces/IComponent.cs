using System.ComponentModel;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Interface cua cac Component trong FastWeb
    /// </summary>
    public interface IComponent : INotifyPropertyChanged
    {
        string Name { get; set; }

        string Description { get; set; }        

        IComposite Parent { get; set; }       
       
        ComponentLevel Level { get; }       

        bool Update();       

        IComponent ShallowCopy();

        IComponent DeepCopy();
    }
}
