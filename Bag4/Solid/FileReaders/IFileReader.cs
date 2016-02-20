using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.FileReaders
{
    public interface IFileReader
    {
        bool CanRead(string filename);

        IEnumerable<FileData> Read(string filename);
    }
}
