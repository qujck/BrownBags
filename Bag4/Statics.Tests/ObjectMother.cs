using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Statics.Tests.Unit
{
    public static class ObjectMother
    {
        public static string TestFilePath(string filename)
        {
            return Path.Combine(
                Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location),
                filename);
        }
    }
}
