using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid
{
    public interface ICrossFieldValidator
    {
        void Validate(IEnumerable<FileData> data);
    }
}
