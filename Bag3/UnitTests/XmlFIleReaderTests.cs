using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests
{
    public class XmlFIleReaderTests
    {
        [Test]
        public void Read_Test1()
        {
            var reader = new XmlFIleReader();
            var result = reader.Read("data.xml").ToArray();

            Assert.AreEqual("Paul", result[0].StringValue);
            Assert.AreEqual("BRD", result[1].StringValue);
            Assert.AreEqual("BRD12345678", result[2].StringValue);
            Assert.AreEqual("CTO", result[3].StringValue);
        }
    }
}
