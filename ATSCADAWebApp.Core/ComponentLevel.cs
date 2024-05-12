using System;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Cac cap do cua Component
    /// </summary>
    [Serializable()]
    public enum ComponentLevel
    {
        /// <summary>
        /// App. Cap cao nhat. Dai dien cho project, trang web
        /// </summary>
        [XmlEnum(Name = "app")]
        App = 0,
        /// <summary>
        /// Trang giao dien
        /// </summary>
        [XmlEnum(Name = "view")]
        View = 1,
        /// <summary>
        /// Moi trang se duoc chia lam nhieu hang
        /// </summary>
        [XmlEnum(Name = "row")]
        Row = 2,
        /// <summary>
        /// Moi hang se duoc chia lam nhieu cot
        /// </summary>
        [XmlEnum(Name = "column")]
        Column = 3,
        /// <summary>
        /// Trong cot se chua cac phan tu Tools hien thi
        /// </summary>
        [XmlEnum(Name = "element")]
        Component = 4
    }
}
