using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solid.FileReaders
{
    public sealed class CsvReader : DelimitedReader
    {
        public CsvReader() : base(',') { }

        public override bool CanRead(string filename) =>
            filename.ToLower().EndsWith(".csv");
    }
}
