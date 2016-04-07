using System.Collections.Generic;

namespace Bag6.Fibonacci
{
    public interface IFibonacciService
    {
        IEnumerable<double> Compute(double min, double max);
    }
}