using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntegrationTests
{
    public class FileReaderTests
    {
        [TestCase(0, "Name", "Paul")]
        [TestCase(1, "Dept", "BRD")]
        [TestCase(2, "EmployeeNumber", "BRD12345678")]
        [TestCase(3, "Title", "CTO")]
        public void FileReader_GivenCsvFile_ReturnsFileDataForEachLine(
            int index, string field, string value)
        {
            var fileReader = new FileReader();
            var data = fileReader.Read(@"..\..\data.csv", FileType.Csv);
            Assert.AreEqual(4, data.Count);
            Assert.AreEqual(field, data[index].Fieldname);
            Assert.AreEqual(value, data[index].StringValue);
        }

        [TestCase(0, "Name", "Paul")]
        [TestCase(1, "Dept", "BRD")]
        [TestCase(2, "EmployeeNumber", "BRD12345678")]
        [TestCase(3, "Title", "CTO")]
        public void FileReader_GivenTabFile_ReturnsFileDataForEachLine(
            int index, string field, string value)
        {
            var fileReader = new FileReader();
            var data = fileReader.Read(@"..\..\data.tab", FileType.Tab);
            Assert.AreEqual(4, data.Count);
            Assert.AreEqual(field, data[index].Fieldname);
            Assert.AreEqual(value, data[index].StringValue);
        }

        [TestCase(0, "Name", "Paul")]
        [TestCase(1, "Dept", "BRD")]
        [TestCase(2, "EmployeeNumber", "BRD12345678")]
        [TestCase(3, "Title", "CTO")]
        public void FileReader_GivenXmlFile_ReturnsFileDataForEachLine(
            int index, string field, string value)
        {
            var fileReader = new FileReader();
            var data = fileReader.Read(@"..\..\data.xml", FileType.Xml);
            Assert.AreEqual(4, data.Count);
            Assert.AreEqual(field, data[index].Fieldname);
            Assert.AreEqual(value, data[index].StringValue);
        }
    }
}
