using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag6.Fibonacci
{
    public sealed class ConsoleLoggingDecorator : IFibonacciService
    {
        private readonly IFibonacciService decorated;

        public ConsoleLoggingDecorator(IFibonacciService decorated)
        {
            this.decorated = decorated;
        }

        public IEnumerable<double> Compute(double min, double max)
        {
            foreach(var result in this.decorated.Compute(min, max))
            {
                Console.WriteLine(result);

                yield return result;
            }
        }
    }
}
