using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics.Tests.Unit
{
    public class TestListener : TraceListener
    {
        public string Output { get; private set; } = "";

        public override void Write(string message)
        {
            Output += message;
        }

        public override void WriteLine(string message)
        {
            Output += message;
        }
    }
}
