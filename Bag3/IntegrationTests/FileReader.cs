using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationTests
{
    /* Bag 3:
       Add Csv delimited, Tab delimited and Xml delimited
       Then redo as unit testable
       Talk about the benefits of tests in general, refactor the new code into Linq statements

       Validation:
        
           Name:
               cannot contain numbers
               cannot be null
               > 1 character
               < 256 characters

           Dept:
               can be null
               > 1 character
               < 256 characters

           Employee Number:
               cannot be null
               must be 3 characters + 8 numbers

           Dept & Employee Number:
               if Dept = 'Finance' employee number starts with FIN
               if Dept = 'Board' employee number starts with BRD
               else employee number does not start with FIN or BRD

           Dept & Title:
               if Dept = 'Ivory Tower' title is one of Architect, Senior Architect, Lead Architect
               if Dept = 'BAU' title is one of Junior Programmer Analyst, Programmer Analyst, Senior Programmer Analyst, Lead Programmer Analyst
               else title is none of the above
    */

    // Bag 4:
    // Show a generic query abstraction
    // refactor to parameter objects
    // add logging with a static class
    // And then we have AOP :-)
    public sealed class FileReader
    {
        public List<FileData> Read(string filename, FileType fileType)
        {
            var result = new List<FileData>();
            switch (fileType)
            {
                case FileType.Csv:
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        string[] split = line.Split(',');
                        var dataItem = new FileData();
                        dataItem.Fieldname = split[0];
                        dataItem.StringValue = split[1];
                        result.Add(dataItem);
                    }

                    return result;
                case FileType.Tab:
                    string[] lines2 = File.ReadAllLines(filename);
                    foreach (string line in lines2)
                    {
                        string[] split = line.Split('\t');
                        var dataItem = new FileData();
                        dataItem.Fieldname = split[0];
                        dataItem.StringValue = split[1];
                        result.Add(dataItem);
                    }

                    return result;
                case FileType.Xml:
                    var doc = XDocument.Load(filename);
                    foreach(var child in doc.Root.Elements())
                    {
                        var dataItem = new FileData();
                        dataItem.Fieldname = child.Name.LocalName;
                        dataItem.StringValue = child.Value;
                        result.Add(dataItem);
                    }

                    return result;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public enum FileType
    {
        Xml,
        Csv,
        Tab
    }

    public class FileData
    {
        public string Fieldname { get; set; }

        public string StringValue { get; set; }
    }
}
