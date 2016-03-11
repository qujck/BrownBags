using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solid.Model;

namespace Solid.FileReaders
{
    public abstract class DelimitedReader : IFileReader
    {
        private readonly char delimiter;

        public DelimitedReader(char delimiter)
        {
            this.delimiter = delimiter;
        }

        public abstract bool CanRead(string filename);

        public IEnumerable<FileData> Read(string filename) =>
            from line in File.ReadAllLines(filename)
            let split = line.Split(this.delimiter)
            select new FileData
            {
                Fieldname = split[0],
                StringValue = split[1]
            };
    }
}
