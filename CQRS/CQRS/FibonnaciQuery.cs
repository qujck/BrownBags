using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class FibonnaciQuery : IQuery<IEnumerable<double>>
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
