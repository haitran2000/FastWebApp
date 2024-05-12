using System;
using System.Collections.Generic;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Interface cac Component co chua danh sach con
    /// </summary>
    public interface IComposite : IComponent
    {                
        IEnumerable<IComponent> Components { get; }

        int Count { get; }

        IComponent FirstOrDefault(Func<IComponent, bool> func);        

        bool Add(IComponent component);
       
        bool Contains(IComponent component);

        bool Contains(Func<IComponent, bool> func);

        bool Remove(IComponent component);

        bool Insert(int index, IComponent component);       
    }
}
