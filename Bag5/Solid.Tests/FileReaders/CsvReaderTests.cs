using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Solid.FileReaders;
using Solid.Model;

namespace Solid.Tests.Unit.FileReaders
{
    public class CsvReaderTests
    {
        [Test]
        public void CanTest_ForFileNamesWithCsvExtension_IsTrue()
        {
            var reader = new CsvReader();

            Assert.True(reader.CanRead("file.csv"));
        }

        [TestCase("file.cs")]
        [TestCase("file.csv1")]
        [TestCase("csv.abc")]
        public void CanTest_ForFileNamesNotWithCsvExtension_IsFalse(string filename)
        {
            var reader = new CsvReader();

            Assert.False(reader.CanRead(filename));
        }

        [Test]
        public void Reader_Always_ReadsData()
        {
            var reader = new CsvReader();

            var result = reader.Read(ObjectMother.TestFilePath("data.csv"));

            Assert.AreEqual("Paul", result.Name().StringValue);
            Assert.AreEqual("Board", result.Department().StringValue);
            Assert.AreEqual("BRD12345678", result.EmployeeNumber().StringValue);
            Assert.AreEqual("CTO", result.Title().StringValue);
        }
    }
}
