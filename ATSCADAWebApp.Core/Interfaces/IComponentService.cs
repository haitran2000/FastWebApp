using System;
using System.Collections.Generic;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Interface load compoent tu file dll
    /// </summary>
    public interface IComponenService
    {
        IComponenService Load();

        IDictionary<Type, IComponent> GetTemplates();

        IEnumerable<Type> GetTypes();

        IEnumerable<IComponent> GetComponents();

        IEnumerable<IComponent> GetComponents(Predicate<IComponent> predicate);

        IComponent GetComponent(Type type);

        IComponent GetDeepCopy(Type type);
    }
}