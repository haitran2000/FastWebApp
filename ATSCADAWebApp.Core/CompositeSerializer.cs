using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Ma hoa, giai ma doi tuong Composite thanh XML
    /// Cu the trong du an la App
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompositeSerializer<T> : ICompositeSerializer where T : IComposite
    {
        public string Location { get; set; }

        /// <summary>
        /// Ma hoa thanh XML
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public bool Serialize(IComposite composite)
        {
            if (string.IsNullOrEmpty(Location)) return false;            
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var fileStream = new FileStream(Location, FileMode.Create))
                {
                    var settings = new XmlWriterSettings
                    {
                        Encoding = Encoding.GetEncoding("ISO-8859-1"),
                        NewLineChars = Environment.NewLine,
                        ConformanceLevel = ConformanceLevel.Document,
                        Indent = true
                    };
                    using (var writer = XmlWriter.Create(fileStream, settings))
                    {
                        var serializerNamespaces = new XmlSerializerNamespaces();
                        xmlSerializer.Serialize(new CompositeWriter(writer), composite, serializerNamespaces);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Giai ma XML thanh objectc Composite
        /// </summary>
        /// <returns></returns>
        public IComposite Deserialize()
        {
            if (!File.Exists(Location)) return default;
            try
            {
                using (var fileStream = new StreamReader(Location))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch
            {
                return default;
            }
        }
    }
}
