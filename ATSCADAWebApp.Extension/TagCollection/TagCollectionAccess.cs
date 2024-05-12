using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ATSCADAWebApp.Extension.TagCollection
{
    public class TagCollectionAccess
    {
        private const string PATH = @"C:\Program Files\ATPro\ATSCADA\DesignerFiles\Tag_file.XML";

        private const string PATH_x86 = @"C:\Program Files (x86)\ATPro\ATSCADA\DesignerFiles\Tag_file.XML";

        private const string TASK = "/Root/Task";

        private const string TASK_INTERNAL = "/Root/InternalTask";

        private const string TAG_NAME = "TagName";

        private const string INTERNAL_TAG_NAME = "InternalTagName";

        private const string VALUE = "Value";        

        public List<string> Convert()
        {
            try
            {
                var tagCollection = new List<string>();

                string pathAccess = PATH;
                if (!File.Exists(pathAccess))
                {
                    pathAccess = PATH_x86;
                    if (!File.Exists(pathAccess)) return null;
                }

                var xmlDocument = new XmlDocument();
                xmlDocument.Load(pathAccess);

                var xmlNodeListTask = xmlDocument.SelectNodes(TASK);
                var xmlNodeListInternalTask = xmlDocument.SelectNodes(TASK_INTERNAL);

                foreach (XmlNode xmlNode in xmlNodeListTask)
                {
                    string taskName = xmlNode.ChildNodes.Item(0).Attributes.GetNamedItem(VALUE).Value;
                    for (int index = 2; index < xmlNode.ChildNodes.Count; ++index)
                        tagCollection.Add(taskName + "." + xmlNode.ChildNodes.Item(index).Attributes.GetNamedItem(TAG_NAME).Value);
                }
                foreach (XmlNode xmlNode in xmlNodeListInternalTask)
                {
                    string InternalTaskName = xmlNode.ChildNodes.Item(0).Attributes.GetNamedItem(VALUE).Value;
                    for (int index = 2; index < xmlNode.ChildNodes.Count; ++index)
                        tagCollection.Add(InternalTaskName + "." + xmlNode.ChildNodes.Item(index).Attributes.GetNamedItem(INTERNAL_TAG_NAME).Value);
                }
                
                return tagCollection;
            }
            catch
            {
                return null;
            }
        }

        public List<string> Convert(string pathAccess)
        {
            try
            {
                var tagCollection = new List<string>();

                if (!File.Exists(pathAccess)) return null;

                var xmlDocument = new XmlDocument();
                xmlDocument.Load(pathAccess);

                var xmlNodeListTask = xmlDocument.SelectNodes(TASK);
                var xmlNodeListInternalTask = xmlDocument.SelectNodes(TASK_INTERNAL);

                foreach (XmlNode xmlNode in xmlNodeListTask)
                {
                    string taskName = xmlNode.ChildNodes.Item(0).Attributes.GetNamedItem(VALUE).Value;
                    for (int index = 2; index < xmlNode.ChildNodes.Count; ++index)
                        tagCollection.Add(taskName + "." + xmlNode.ChildNodes.Item(index).Attributes.GetNamedItem(TAG_NAME).Value);
                }
                foreach (XmlNode xmlNode in xmlNodeListInternalTask)
                {
                    string InternalTaskName = xmlNode.ChildNodes.Item(0).Attributes.GetNamedItem(VALUE).Value;
                    for (int index = 2; index < xmlNode.ChildNodes.Count; ++index)
                        tagCollection.Add(InternalTaskName + "." + xmlNode.ChildNodes.Item(index).Attributes.GetNamedItem(INTERNAL_TAG_NAME).Value);
                }

                return tagCollection;
            }
            catch
            {
                return null;
            }
        }
    }
}
