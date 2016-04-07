using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public sealed class FibonnaciQueryHandler : IQueryHandler<FibonnaciQuery, IEnumerable<double>>
    {
        public IEnumerable<double> Handle(FibonnaciQuery query)
        {
            for (double i = query.Min; i < query.Max; i++)
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
