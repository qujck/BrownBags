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
    public class TabularReaderTests
    {
        [Test]
        public void CanTest_ForFileNamesWithTabExtension_IsTrue()
        {
            var reader = new TabularReader();

            Assert.True(reader.CanRead("file.tab"));
        }

        [TestCase("file.ta")]
        [TestCase("file.tab1")]
        [TestCase("tab.abc")]
        public void CanTest_ForFileNamesNotWithTabExtension_IsFalse(string filename)
        {
            var reader = new TabularReader();

            Assert.False(reader.CanRead(filename));
        }

        [Test]
        public void Reader_Always_ReadsData()
        {
            var reader = new TabularReader();

            var result = reader.Read(ObjectMother.TestFilePath("data.tab"));

            Assert.AreEqual("Paul", result.Name().StringValue);
            Assert.AreEqual("Board", result.Department().StringValue);
            Assert.AreEqual("BRD12345678", result.EmployeeNumber().StringValue);
            Assert.AreEqual("CTO", result.Title().StringValue);
        }
    }
}
