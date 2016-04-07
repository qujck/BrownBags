using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag6.Sorting
{
    public sealed class ReversedStringSorter : IStringSorter
    {
        public IEnumerable<string> Sort(IEnumerable<string> list)
        {
            var result =
                from item in list
                orderby string.Concat(item.Reverse())
                select item;

            return result;
        }
    }
}
