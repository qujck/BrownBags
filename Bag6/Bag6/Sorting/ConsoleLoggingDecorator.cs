using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag6.Sorting
{
    public sealed class ConsoleLoggingDecorator : IStringSorter
    {
        private readonly IStringSorter decorated;

        public ConsoleLoggingDecorator(IStringSorter decorated)
        {
            this.decorated = decorated;
        }

        public IEnumerable<string> Sort(IEnumerable<string> list)
        {
            foreach (var result in this.decorated.Sort(list))
            {
                Console.WriteLine(result);

                yield return result;
            }
        }
    }
}
