using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Doi tuong Base cua tat ca Component
    /// Quy dinh cac thuoc tinh co ban: Name, Description, Parent, ...
    /// </summary>
    [Serializable()]
    public abstract class ComponentBase : BindableCore, IComponent
    {
        #region FIELDS

        protected string name = "NewComponent";

        protected string description = "ATSCADA Fast Web Component";

        protected IComposite parent;     

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Ten doi tuong
        /// </summary>

        [XmlElement("at-component-name")]
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);          
        }      

        /// <summary>
        /// Chu thich doi tuong
        /// </summary>
        [XmlElement("at-component-description")]
        public string Description
        {
            get => this.description;
            set => SetField(ref this.description, value);
        }
        
        /// <summary>
        /// Doi tuong cha. Chua phan tu
        /// </summary>
        [XmlIgnore]       
        public IComposite Parent
        {
            get => this.parent;
            set => SetField(ref this.parent, value);
        }   
       
        /// <summary>
        /// Level cua Component
        /// </summary>
        [XmlIgnore]
        public ComponentLevel Level { get; protected set; } = ComponentLevel.Component;

        #endregion

        #region CONSTRUCTORS

        public ComponentBase() { }

        public ComponentBase(IComposite parent = null) 
        {
            Parent = parent;
        }

        public ComponentBase(string name, IComposite parent = null)
        {
            Name = name;
            Parent = parent;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Phuong thuc goi UI cai dat cau hinh.
        /// </summary>
        /// <returns></returns>
        public abstract bool Update();       

        /// <summary>
        /// Copy doi duong. Tao Clone
        /// </summary>
        /// <returns></returns>
        public virtual IComponent ShallowCopy()
        {
            return this.MemberwiseClone() as IComponent;
        }

        /// <summary>
        /// Tao moi hoan toan mot doi tuong. References khac
        /// Gia tri cac thuoc tinh, thong so se giong nguyen mau
        /// </summary>
        /// <returns></returns>
        public virtual IComponent DeepCopy()
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (IComponent)formatter.Deserialize(memoryStream);
            }
        }       

        #endregion
    }
}
