using System.Collections.Generic;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Interface quy dinh Component co tinh nang tu dong tao doi tuong mac dinh
    /// Phuc vu cho tinh nang Quick
    /// </summary>
    public interface IDefaultableObject
    {
        IEnumerable<IComponent> DefaultObject(string[] tagNames);
    }
}
