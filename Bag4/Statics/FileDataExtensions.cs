using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
    public static class FileDataExtensions
    {
        public static FileData Department(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == "Dept");

        public static FileData Name(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == "Name");

        public static FileData EmployeeNumber(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == "EmployeeNumber");

        public static FileData Title(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == "Title");
    }
}
