using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bag6.Fibonacci;
using Bag6.Sorting;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = new[] { "january", "february", "march", "april" };

            IStringSorter fs = new ReversedStringSorter();
            fs = new Bag6.Sorting.ConsoleLoggingDecorator(fs);

            var result = fs.Sort(values).ToList();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");

            Console.ReadLine();





            //IFibonacciService fs = new FibonacciService();
            //fs = new ConsoleLoggingDecorator(fs);

            //var result = fs.Compute(0, 1250).ToList();

            //Console.WriteLine();
            //Console.WriteLine("Press any key to exit");

            //Console.ReadLine();
        }
    }
}