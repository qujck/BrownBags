using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueryHandler<FibonnaciQuery, IEnumerable<double>> handler;
            handler = new FibonnaciQueryHandler();
            handler = new EnumerableQueryHandlerLoggingDecorator<FibonnaciQuery, IEnumerable<double>>(handler);
            var query = new FibonnaciQuery { Min = 1, Max = 1250 };

            var result = handler.Handle(query).ToList();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
