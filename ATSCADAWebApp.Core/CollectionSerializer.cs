using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Ma hoa doi tuong thanH xml
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    public class CollectionSerializer<T> : IXmlSerializable where T : INotifyPropertyChanged
    {
        public BindableCollection<T> Components { get; }

        public CollectionSerializer()
        {
            Components = new BindableCollection<T>();
        }

        public CollectionSerializer(BindableCollection<T> components)
        {
            Components = components;
        }

        public XmlSchema GetSchema() { return null; }

        /// <summary>
        /// Doc xml. Giai ma, chuyen thanh object component
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            // Phan tu bat dau bang tien to atscada-components
            // Mac dinh danh sach Collection la atscada-components
            reader.ReadStartElement("atscada-components");
            while (reader.IsStartElement("atscada-assembly"))
            {
                // Kiem tra ton tai kieu hay khong
                var type = Type.GetType(reader.GetAttribute("at-value"));
                if (type != null)
                {
                    var serializer = new XmlSerializer(type);
                    // atscda-assembly: Namespace cua object component
                    reader.ReadStartElement("atscada-assembly");
                    // add vao danh sach Components
                    Components.Add((T)serializer.Deserialize(reader));
                }
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Ghi xml. Ma hoa, luu object duoi dang xml
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            foreach (T component in Components)
            {
                writer.WriteStartElement("atscada-assembly");
                writer.WriteAttributeString
                ("at-value", component.GetType().AssemblyQualifiedName);
                var serializerNamespaces = new XmlSerializerNamespaces();
                var xmlSerializer = new XmlSerializer(component.GetType());
                serializerNamespaces.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(writer, component, serializerNamespaces);
                writer.WriteEndElement();
            }
        }
    }
}
