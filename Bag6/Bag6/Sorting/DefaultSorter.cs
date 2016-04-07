using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag6.Sorting
{
    public sealed class DefaultSorter : IStringSorter
    {
        public IEnumerable<string> Sort(IEnumerable<string> list)
        {
            var result =
                from item in list
                orderby item
                select item;

            return result;
        }
    }
}
