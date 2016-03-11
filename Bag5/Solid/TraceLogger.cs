using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public sealed class TraceLogger : ILogger
    {
        public void Log(Func<string> messageFactory)
        {
            Debug.WriteLine(messageFactory());
        }
    }
}
