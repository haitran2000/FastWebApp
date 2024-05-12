using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Load cac Component tu DLL Tools
    /// </summary>
    public abstract class ComponentServiceBase : IComponenService
    {
        public Dictionary<Type, IComponent> templates;

        public ComponentServiceBase()
        {
            this.templates = new Dictionary<Type, IComponent>();
        }

        public virtual IComponenService Load()
        {
            // Load dll
            var assembly = Assembly.GetEntryAssembly();
            var assemblies = assembly.GetReferencedAssemblies();
            foreach (var assemblyName in assemblies)
            {
                assembly = Assembly.Load(assemblyName);
                foreach (var typeInfo in assembly.DefinedTypes)
                {
                    // Kiem tra xem class co phai thuoc kieu IComponent hoac IComposite hay khong
                    // Neu dung, add nguyen mau class vao Template
                    // Khi tao moi doi tuong, se Copy tu Template
                    if (
                        typeInfo.ImplementedInterfaces.Contains(typeof(IComponent)) &&
                        !typeInfo.ImplementedInterfaces.Contains(typeof(IComposite)) &&
                        !typeInfo.IsInterface && !typeInfo.IsAbstract)
                    {
                        var key = typeInfo.AsType();
                        if (key is null) continue;
                        if (assembly.CreateInstance(typeInfo.FullName) is IComponent component)
                            if (component.Level == ComponentLevel.Component)
                                this.templates[key] = component;
                    }
                }
            }
            return this;
        }

        public virtual IDictionary<Type, IComponent> GetTemplates()
        {
            return templates;
        }

        public virtual IEnumerable<Type> GetTypes()
        {
            foreach (var type in this.templates.Keys)
                yield return type;
        }

        public virtual IEnumerable<IComponent> GetComponents()
        {
            foreach (var component in this.templates.Values)
                yield return component;
        }

        public virtual IEnumerable<IComponent> GetComponents(Predicate<IComponent> predicate)
        {
            foreach (var component in this.templates.Values)
                if (predicate(component))
                    yield return component;
        }

        public virtual IComponent GetComponent(Type type)
        {
            if (this.templates.ContainsKey(type))
            {
                return this.templates[type];
            }
            return default;
        }

        public virtual IComponent GetDeepCopy(Type type)
        {
            if (this.templates.ContainsKey(type))
            {
                return this.templates[type].DeepCopy();
            }
            return default;
        }
    }
}
