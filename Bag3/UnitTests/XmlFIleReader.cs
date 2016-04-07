using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTests
{
    public class XmlFIleReader : IFileReader
    {
        public IEnumerable<FileData> Read(string filename) =>
            from child in XDocument.Load(filename).Root.Elements()
            select new FileData
            {
                Fieldname = child.Name.LocalName,
                StringValue = child.Value
            };
    }
}
