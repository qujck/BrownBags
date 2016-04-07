using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests
{
    public class CsvAndTabFileReaderTests
    {
        [Test]
        public void Read_ReadsFromTheFile_AsItMoveThroughTheResults()
        {
            var reader = new CsvAndTabFileReader();
            var result = reader.Read("data.csv");

            var subset =
                from data in result
                where data.Fieldname == "Name"
                where data.StringValue == "Paul"
                select data.StringValue;

            Assert.AreEqual(1, subset.Count());
        }
    }
}
