using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Model
{
    public static class FileDataExtensions
    {
        public static FileData Department(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == Constants.Field.Dept);

        public static FileData Name(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == Constants.Field.Name);

        public static FileData EmployeeNumber(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == Constants.Field.EmployeeNumber);

        public static FileData Title(this IEnumerable<FileData> data) =>
            data.Single(item => item.Fieldname == Constants.Field.Title);
    }
}
