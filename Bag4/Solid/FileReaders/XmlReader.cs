using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Solid.Model;

namespace Solid.FileReaders
{
    public sealed class XmlReader : IFileReader
    {
        public bool CanRead(string filename) => 
            filename.ToLower().EndsWith(".xml");

        public IEnumerable<FileData> Read(string filename) =>
            from element in XDocument.Load(filename).Root.Elements()
            select new FileData
            {
                Fieldname = element.Name.LocalName,
                StringValue = element.Value
            };
    }
}
