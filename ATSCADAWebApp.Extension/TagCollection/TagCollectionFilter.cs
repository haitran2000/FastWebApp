using System;
using System.Collections.Generic;
using System.Linq;

namespace ATSCADAWebApp.ToolExtensions.TagCollection
{
    public class TagCollectionFilter
    {
        public static List<string> Filter(List<string> tagCollection, string keywords)
        {            
            if (string.IsNullOrEmpty(keywords)) return tagCollection;

            var keywordArray = keywords.Split(' ').Where(keyword => !string.IsNullOrWhiteSpace(keyword));

            return tagCollection.FindAll(tagName =>
            {
                return keywordArray.All(keyword =>
                {
                    return tagName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
                });
            });
        }
    }
}
