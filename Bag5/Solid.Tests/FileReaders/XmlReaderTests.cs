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
    public class XmlReaderTests
    {
        [Test]
        public void CanTest_ForFileNamesWithXmlExtension_IsTrue()
        {
            var reader = new XmlReader();

            Assert.True(reader.CanRead("file.xml"));
        }

        [TestCase("file.xm")]
        [TestCase("file.xml1")]
        [TestCase("xml.abc")]
        public void CanTest_ForFileNamesNotWithXmlExtension_IsFalse(string filename)
        {
            var reader = new XmlReader();

            Assert.False(reader.CanRead(filename));
        }

        [Test]
        public void Reader_Always_ReadsData()
        {
            var reader = new XmlReader();

            var result = reader.Read(ObjectMother.TestFilePath("data.xml"));

            Assert.AreEqual("Paul", result.Name().StringValue);
            Assert.AreEqual("Board", result.Department().StringValue);
            Assert.AreEqual("BRD12345678", result.EmployeeNumber().StringValue);
            Assert.AreEqual("CTO", result.Title().StringValue);
        }
    }
}
