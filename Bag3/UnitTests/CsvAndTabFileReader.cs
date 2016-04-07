using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class CsvAndTabFileReader : IFileReader
    {
        public IEnumerable<FileData> Read(string filename)
        {
            char delimiter = filename.EndsWith(".csv")
                ? ','
                : '\t';

            return
                from line in File.ReadAllLines(filename)
                let split = line.Split(delimiter)
                select new FileData
                {
                    Fieldname = split[0],
                    StringValue = split[1]
                };
        }
    }
}
