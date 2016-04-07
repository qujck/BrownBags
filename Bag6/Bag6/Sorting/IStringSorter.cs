using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag6.Sorting
{
    public interface IStringSorter
    {
        IEnumerable<string> Sort(IEnumerable<string> list);
    }
}
