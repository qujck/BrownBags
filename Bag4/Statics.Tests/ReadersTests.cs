using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Statics.Tests.Unit
{
    public class ReadersTests
    {
        [TestCase("data.xml")]
        [TestCase("data.csv")]
        [TestCase("data.tab")]
        public void Reader_Always_ReadsData(string filename)
        {
            var result = Readers.ReadData(filename);
            Assert.AreEqual("Paul", result.Name().StringValue);
            Assert.AreEqual("Board", result.Department().StringValue);
            Assert.AreEqual("BRD12345678", result.EmployeeNumber().StringValue);
            Assert.AreEqual("CTO", result.Title().StringValue);
        }
    }
}
