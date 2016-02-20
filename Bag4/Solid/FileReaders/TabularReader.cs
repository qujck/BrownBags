using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solid.FileReaders
{
    public sealed class TabularReader : DelimitedReader
    {
        public TabularReader() : base('\t') { }

        public override bool CanRead(string filename) =>
            filename.ToLower().EndsWith(".tab");
    }
}
