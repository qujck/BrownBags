using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Solid.Tests.Unit
{
    public class ProgramTests
    {
        public ProgramTests()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [TestCase("data.csv")]
        [TestCase("data.tab")]
        [TestCase("data.xml")]
        public void Program_WithDataFile_Succeeds(string filename)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { filename });

                Assert.AreEqual("Completed\r\n", sw.ToString());
            }
        }
    }
}
