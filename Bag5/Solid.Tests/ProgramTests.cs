using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Solid.Model;

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
        public void Main_WithDataFile_Succeeds(string filename)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { ObjectMother.TestFilePath(filename) });

                Assert.True(sw.ToString().EndsWith("Completed\r\n"));
            }
        }

        [TestCase("data.csv")]
        [TestCase("data.tab")]
        [TestCase("data.xml")]
        public void FileData_WithDataFile_ContainsExpectedData(string filename)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { ObjectMother.TestFilePath(filename) });

                Assert.AreEqual("Paul", Program.Data.Name().StringValue);
                Assert.AreEqual("Board", Program.Data.Department().StringValue);
                Assert.AreEqual("BRD12345678", Program.Data.EmployeeNumber().StringValue);
                Assert.AreEqual("CTO", Program.Data.Title().StringValue);
            }
        }
    }
}
