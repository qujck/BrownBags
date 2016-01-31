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
        [TestCase(0, "Name", "Peter")]
        [TestCase(1, "Dept", "DMS")]
        [TestCase(2, "EmployeeNumber", "12345")]
        public void FileReader_GivenCsvFile_ReturnsFileDataForEachLine(
            int index, string field, string value)
        {
            var fileReader = new FileReader();
            var data = fileReader.Read(@"D:\Peter\OneDrive\DEV\BrownBags\Bag3\IntegrationTests\data.csv", FileType.Csv);
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual(field, data[index].Fieldname);
            Assert.AreEqual(value, data[index].StringValue);
        }

        [TestCase(0, "Name", "Peter")]
        [TestCase(1, "Dept", "DMS")]
        [TestCase(2, "EmployeeNumber", "12345")]
        public void FileReader_GivenTabFile_ReturnsFileDataForEachLine(
            int index, string field, string value)
        {
            var fileReader = new FileReader();
            var data = fileReader.Read(@"D:\Peter\OneDrive\DEV\BrownBags\Bag3\IntegrationTests\data.tab", FileType.Tab);
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual(field, data[index].Fieldname);
            Assert.AreEqual(value, data[index].StringValue);
        }

        [TestCase(0, "Name", "Peter")]
        [TestCase(1, "Dept", "DMS")]
        [TestCase(2, "EmployeeNumber", "12345")]
        public void FileReader_GivenXmlFile_ReturnsFileDataForEachLine(
            int index, string field, string value)
        {
            var fileReader = new FileReader();
            var data = fileReader.Read(@"D:\Peter\OneDrive\DEV\BrownBags\Bag3\IntegrationTests\data.xml", FileType.Xml);
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual(field, data[index].Fieldname);
            Assert.AreEqual(value, data[index].StringValue);
        }
    }
}
