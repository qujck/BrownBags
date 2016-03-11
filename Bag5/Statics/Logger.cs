using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
    public class Logger
    {
        public static Logger Current { get; } = new Logger();

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
