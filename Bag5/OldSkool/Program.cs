using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace BrownBagLnch_1
{
    // THIS PROGRAM USES C#6.0 FEATURES 
    public class Program
    {
        public static IEnumerable<FileData> Data { get; private set; }

        public static void Main(string[] args)
        {
            var reader = ReaderFactory.GetReader(args[0]);

            var employees = reader.Read();

            // VALIDATE THE RECORDS

            string[] architects = { "Architect", "Senior Architect", "Lead Architect" };
            string[] developers = { "Junior Programmer Analyst", "Programmer Analyst", "Senior Programmer Analyst", "Lead Programmer Analyst" };
            foreach (Employee employee in employees.EmployeesData)
            {
                // PUT THE FILEDATA INTO A DICTIONARY AS EASIER TO ACCESS RECORDS BY NAME

                Dictionary<string, string> ee = (from p in employee.EmployeeData select p).ToDictionary(a => a.Fieldname, a => a.StringValue);

                if (ee[Field.Name].Any(c => char.IsDigit(c)))
                {
                    // THIS IS A NEW C#6.0 STRING.FORMAT REPLACEMENT. STARTS WITH $ SEE THE VARIABLE BELOW EMBEDDED  
                    // BETWEEN {} DIRECTLY INTO THE STRING, NOT A PARAMETER
                    employee.Errors.Add($"Error Name value contains a number {ee[Field.Name]}");
                }

                Logger.Current.Log("Test: Error Name value is null");
                if (ee[Field.Name] == null)
                {
                    Logger.Current.Log("Failure: Error Name value is null");
                    employee.Errors.Add($"Error Name value is null");
                }

                Logger.Current.Log("Test: Error Name value is <= 1 character long");
                if (ee[Field.Name].Length <= 1)
                {
                    Logger.Current.Log("Failure: Error Name value is <= 1 character long");
                    employee.Errors.Add($"Error Name value is <= 1 character long");
                }

                Logger.Current.Log("Test: Error Name value is > 256 character long");
                if (ee[Field.Name].Length > 256)
                {
                    Logger.Current.Log("Failure: Error Name value is > 256 character long");
                    employee.Errors.Add($"Error Name value is > 256 character long");
                }

                Logger.Current.Log("Test: Error Dept value is <= 1 character long");
                if (ee[Field.Dept].Length <= 1)
                {
                    Logger.Current.Log("Failure: Error Dept value is <= 1 character long");
                    employee.Errors.Add($"Error Dept value is <= 1 character long");
                }

                Logger.Current.Log("Test: Error Dept value is > 256 character long");
                if (ee[Field.Dept].Length > 256)
                {
                    Logger.Current.Log("Failure: Error Dept value is > 256 character long");
                    employee.Errors.Add($"Error Dept value is > 256 character long");
                }

                if (ee[Field.Number] == null)
                {
                    employee.Errors.Add($"Error EmployeeNumber value is null");
                }

                Regex regex = new Regex(@"\b\w{3}\d{8}");
                if (!regex.Match(ee[Field.Number]).Success)
                {
                    employee.Errors.Add($"Error EmployeeNumber '{ee[Field.Number]}' format must be XXXNNNNNNNN");
                }

                if (ee[Field.Dept] == "Finance" && !ee[Field.Number].StartsWith("FIN"))
                {
                    employee.Errors.Add($"Error Dept is Finance but EmployeeNumber does not start FIN");
                }

                if (ee[Field.Dept] == "Board" && !ee[Field.Number].StartsWith("BRD"))
                {
                    employee.Errors.Add($"Error Dept is Board but EmployeeNumber does not start BRD");
                }

                //if (ee[Field.Dept] != "Board" && ee[Field.Dept] != "Finance")
                //{
                //    if (ee[Field.Number].StartsWith("BRD") || ee[Field.Number].StartsWith("FIN"))
                //    {
                //        employee.Errors.Add($"Error EmployeeNumber must not start with BRD or FIN");
                //    }
                //}

                if (ee[Field.Dept] == "Architecture" && !architects.Contains(ee[Field.Title]))
                {
                    employee.Errors.Add($"Error Dept is Architecture but Title is invalid");
                }

                if (ee[Field.Dept] == "Apps" && !developers.Contains(ee[Field.Title]))
                {
                    employee.Errors.Add($"Error Dept is Apps but Title is invalid");
                }

                if (ee[Field.Dept] != "Architecture" && ee[Field.Dept] != "Apps")
                {
                    if (developers.Concat(architects).Contains(ee[Field.Title]))
                    {
                        employee.Errors.Add($"Error Dept cannot have Architecture or Apps Title");
                    }
                }
            }

            // REPORT ERRORS

            foreach (Employee employee in employees.EmployeesData)
            {
                if (employee.Errors.Count > 0)
                {
                    foreach (string error in employee.Errors)
                    {
                        Console.WriteLine($"Error for NAME {employee.EmployeeData[0].StringValue} - {error}");
                    }
                }
            }

            Data = employees.EmployeesData[0].EmployeeData;

            Console.WriteLine("Done");
        }
    }


    public class FileData
    {
        public string Fieldname { get; set; }
        public string StringValue { get; set; }
    }

    public class Employee
    {
        public List<FileData> EmployeeData { get; set; } = new List<FileData>();    // THIS INITIALISE IS C#6.0
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class Employees
    {
        public List<Employee> EmployeesData { get; set; } = new List<Employee>();
    }

    public static class Field
    {
        public const string Dept = "Dept";
        public const string Name = "Name";
        public const string Number = "EmployeeNumber";
        public const string Title = "Title";
    }

    public abstract class Reader
    {
        public string FileName { get; set; }
        public abstract Employees Read();
        public Reader() { }
        public Reader(string filename) { FileName = filename; }
    }

    public class CSVReader : Reader
    {
        public CSVReader(string filename) { base.FileName = filename; }

        public override Employees Read()
        {
            Employees employees = new Employees();
            using (StreamReader sr = new StreamReader(this.FileName))
            {
                string line = string.Empty;
                while (!sr.EndOfStream)
                {
                    Employee employee = new Employee();
                    for (int i = 0; i < 4; i++)
                    {
                        line = sr.ReadLine();

                        FileData fileData = new FileData();
                        fileData.Fieldname = line.Split(',')[0];
                        fileData.StringValue = line.Split(',')[1];

                        employee.EmployeeData.Add(fileData);
                    }
                    employees.EmployeesData.Add(employee);
                }
            }
            return employees;
        }
    }

    public class TABReader : Reader
    {
        public TABReader(string filename) { base.FileName = filename; }

        public override Employees Read()
        {
            Employees employees = new Employees();
            using (StreamReader sr = new StreamReader(this.FileName))
            {
                string line = string.Empty;
                while (!sr.EndOfStream)
                {
                    Employee employee = new Employee();
                    for (int i = 0; i < 4; i++)
                    {
                        line = sr.ReadLine();

                        FileData fileData = new FileData();
                        fileData.Fieldname = line.Split('\t')[0];
                        fileData.StringValue = line.Split('\t')[1];

                        employee.EmployeeData.Add(fileData);
                    }
                    employees.EmployeesData.Add(employee);
                }
            }
            return employees;
        }
    }

    public class XMLReader : Reader
    {
        public XMLReader(string filename) { base.FileName = filename; }

        public override Employees Read()
        {
            Employees employees = new Employees();
            using (XmlReader reader = XmlReader.Create(this.FileName))
            {
                Employee employee = new Employee();
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case Field.Name:
                            case Field.Dept:
                            case Field.Number:
                            case Field.Title:
                                FileData fileData = new FileData();
                                fileData.Fieldname = reader.Name;
                                if (reader.Read())
                                {
                                    fileData.StringValue = reader.Value;
                                }
                                employee.EmployeeData.Add(fileData);
                                if (fileData.Fieldname == Field.Title)
                                {
                                    employees.EmployeesData.Add(employee);
                                    employee = new Employee();
                                }
                                break;
                        }
                    }
                }

            }
            return employees;
        }
    }

    static class ReaderFactory
    {
        public static Reader GetReader(string filename)
        {
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".csv":
                    return new CSVReader(filename);
                case ".tab":
                    return new TABReader(filename);
                case ".xml":
                    return new XMLReader(filename);
            }
            throw new ArgumentException("Expecting one of csv tab xml");
        }
    }
    public class Logger
    {
        public static Logger Current { get; } = new Logger();

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}

