using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag6.Fibonacci
{
    public sealed class FibonacciService : IFibonacciService
    {
        public IEnumerable<double> Compute(double min, double max)
        {
            for (double i = min; i < max; i++)
            {
                double a = 0;
                double b = 1;

                for (double j = 0; j <= i; j++)
                {
                    double temp = a;
                    a = b;
                    b = temp + b;
                }

                System.Threading.Thread.Sleep(5);

                yield return a;
            }
        }
    }
}
