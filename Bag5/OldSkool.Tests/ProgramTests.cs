using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BrownBagLnch_1;

namespace OldSkool.Tests.Unit
{
    public class ProgramTests
    {
        public ProgramTests()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [Test]
        public void Program_WithTabFile_Succeeds()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { ObjectMother.TestFilePath("data.tab") });

                var output = sw.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Assert.AreEqual("Done", output[0]);
            }
        }

        [Test]
        public void Program_WithXmlFile_Succeeds()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { ObjectMother.TestFilePath("data.xml") });

                var output = sw.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(
                    "Error for NAME Paula - Error EmployeeNumber 'BRD1234578' format must be XXXNNNNNNNN",
                    output[0]);
                Assert.AreEqual(
                    "Error for NAME Maryd - Error EmployeeNumber 'BRD1234578' format must be XXXNNNNNNNN",
                    output[1]);
                Assert.AreEqual("Done", output[2]);
            }
        }

        [Test]
        public void Program_WithCsvFile_Succeeds()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] { ObjectMother.TestFilePath("data.csv") });

                var output = sw.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(
                    "Error for NAME Paul111 - Error Name value contains a number Paul111",
                    output[0]);
                Assert.AreEqual(
                    "Error for NAME Paul - Error Dept is Architecture but Title is invalid",
                    output[1]);
                Assert.AreEqual(
                    "Error for NAME Paul - Error Dept cannot have Architecture or Apps Title",
                    output[2]);
                Assert.AreEqual(
                    "Error for NAME Paul - Error Dept cannot have Architecture or Apps Title",
                    output[3]);
                Assert.AreEqual(
                    "Error for NAME Paul - Error EmployeeNumber 'BRD1234568' format must be XXXNNNNNNNN",
                    output[4]);
                Assert.AreEqual("Done", output[5]);
            }
        }
    }
}