using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// DOi tuong Base, dai dien cho cac phan tu, Component chua tap hopw con Collection
    /// </summary>
    [Serializable()]
    public abstract class CompositeBase : ComponentBase, IComposite
    {
        #region FILEDS

        protected BindableCollection<IComponent> components;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ma hoa Collection
        /// </summary>
        [XmlElement("atscada-components")]
        public CollectionSerializer<IComponent> ObservableSerializer
        {
            get
            {
                if (this.components is null) return null;
                return new CollectionSerializer<IComponent>(this.components);
            }
            set
            {
                SetActionCollectionChanged(value.Components);
                if (this.components is null) return;
                foreach (var component in this.components)
                    component.Parent = this;
            }
        }

        /// <summary>
        /// Danh sach phan tu con
        /// </summary>
        [XmlIgnore]
        public IEnumerable<IComponent> Components
        {
            get => this.components;
        }

        /// <summary>
        /// So luong phan tu con
        /// </summary>
        [XmlIgnore]
        public int Count
        {
            get => this.components.Count;
        }

        #endregion

        #region CONSTRUCTORS

        public CompositeBase()
            : base()
        {
            SetActionCollectionChanged(new BindableCollection<IComponent>());
        }

        public CompositeBase(IComposite parent)
           : base(parent)
        {
            SetActionCollectionChanged(new BindableCollection<IComponent>());
        }

        public CompositeBase(string name, IComposite parent = null)
            : base(name, parent)
        {
            SetActionCollectionChanged(new BindableCollection<IComponent>());
        }

        private void SetActionCollectionChanged(BindableCollection<IComponent> newCollection)
        {
            if (this.components != null)
                this.components.CollectionChanged -= ComponentsCollectionChanged;
            this.components = newCollection;
            if (this.components != null)
                this.components.CollectionChanged += ComponentsCollectionChanged;
        }

        private void ComponentsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Components));
        }

        #endregion

        #region METHODS        

        /// <summary>
        /// Tim kiem phan tu
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public IComponent FirstOrDefault(Func<IComponent, bool> func)
        {
            return this.components.FirstOrDefault(func);
        }

        /// <summary>
        /// Them moi phan tu
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool Add(IComponent component)
        {
            if (this.components.Contains(component)) return false;          
            if (component.Parent is IComposite group) group.Remove(component);
            component.Parent = this;
            this.components.Add(component);
            return true;
        }

        /// <summary>
        /// Kiem tra su ton tai cua phan tu
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool Contains(IComponent component)
        {
            return this.components.Contains(component);
        }

        /// <summary>
        /// Kiem tra su ton tai cua phan tu
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool Contains(Func<IComponent, bool> func)
        {
            foreach (var component in this.components)
                if (func(component)) return true;
            return false;
        }

        /// <summary>
        /// Xoa pha tu khoi danh sach
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool Remove(IComponent component)
        {
            if (!this.components.Contains(component)) return false;
            component.Parent = default;
            this.components.Remove(component);
            return true;
        }

        /// <summary>
        /// Them moi phan tu vao vi tri chi dinh
        /// </summary>
        /// <param name="index"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool Insert(int index, IComponent component)
        {
            if (this.components.Contains(component)) return false;            
            if (component.Parent is IComposite group) group.Remove(component);
            component.Parent = this;
            this.components.Insert(index, component);
            return true;
        }
        
        #endregion
    }
}
