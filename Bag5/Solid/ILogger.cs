using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public interface ILogger
    {
        void Log(Func<string> messageFactory);
    }
}
