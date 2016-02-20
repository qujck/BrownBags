using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Statics
{
    public static class Readers
    {
        public static IEnumerable<FileData> ReadData(string filename) =>
            filename.EndsWith(".csv")
            ? Csv(filename)
            : filename.EndsWith(".tab")
                ? Tabular(filename)
                : Xml(filename);

        private static IEnumerable<FileData> Xml(string filename) =>
            from element in XDocument.Load(filename).Root.Elements()
            select new FileData
            {
                Fieldname = element.Name.LocalName,
                StringValue = element.Value
            };

        private static IEnumerable<FileData> Csv(string filename) =>
            from line in File.ReadAllLines(filename)
            let split = line.Split(',')
            select new FileData
            {
                Fieldname = split[0],
                StringValue = split[1]
            };

        private static IEnumerable<FileData> Tabular(string filename) =>
            from line in File.ReadAllLines(filename)
            let split = line.Split('\t')
            select new FileData
            {
                Fieldname = split[0],
                StringValue = split[1]
            };
    }
}
