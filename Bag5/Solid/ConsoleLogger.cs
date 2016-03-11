using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public sealed class ConsoleLogger : ILogger
    {
        public void Log(Func<string> messageFactory)
        {
            Console.WriteLine(messageFactory());
        }
    }
}
