using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Model
{
    public struct Constants
    {
        public struct Field
        {
            public static string Dept = "Dept";
            public static string Name = "Name";
            public static string EmployeeNumber = "EmployeeNumber";
            public static string Title = "Title";
        }

        public struct Titles
        {
            public static string[] Architect =
            {
                "Architect", "Senior Architect", "Lead Architect"
            };
            public static string[] Apps =
            {
                "Junior Programmer Analyst", "Programmer Analyst", "Senior Programmer Analyst", "Lead Programmer Analyst"
            };
        }

        public struct Department
        {
            public static string Finance = "Finance";
            public static string Board = "Board";
            public static string Architecture = "Architecture";
            public static string Apps = "Apps";
        }

        public struct Prefix
        {
            public struct EmployeeNumber
            {
                public static string BRD = "BRD";
                public static string FIN = "FIN";
            }
        }
    }
}
