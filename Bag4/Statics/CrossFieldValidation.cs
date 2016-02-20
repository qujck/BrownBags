using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
    public static class CrossFieldValidation
    {
        public static string[] ArchitectTitles =
        {
            "Architect", "Senior Architect", "Lead Architect"
        };

        public static string[] AppSupportTitles =
        {
            "Junior Programmer Analyst", "Programmer Analyst", "Senior Programmer Analyst", "Lead Programmer Analyst"
        };

        public static IEnumerable<FileData> ValidateFinanceEmployeeNumber(this IEnumerable<FileData> data)
        {
            if (data.Department().StringValue == "Finance"
                && !data.EmployeeNumber().StringValue.StartsWith("FIN"))
                throw new ArgumentException();
            else
                return data;
        }

        public static IEnumerable<FileData> ValidateBoardEmployeeNumber(this IEnumerable<FileData> data)
        {
            if (data.Department().StringValue == "Board"
                && !data.EmployeeNumber().StringValue.StartsWith("BRD"))
                throw new ArgumentException();
            else
                return data;
        }

        public static IEnumerable<FileData> ValidateNonFinanceNonBoardEmployeeNumber(this IEnumerable<FileData> data)
        {
            if (!new[] { "Finance", "Board" }.Contains(data.Department().StringValue)
                && (data.EmployeeNumber().StringValue.StartsWith("BRD")
                    || data.EmployeeNumber().StringValue.StartsWith("FIN")))
                throw new ArgumentException();
            else
                return data;
        }

        public static IEnumerable<FileData> ValidateArchitectTitle(this IEnumerable<FileData> data)
        {
            if (data.Department().StringValue == "Architecture"
                && !ArchitectTitles.Contains(data.Title().StringValue))
                throw new ArgumentException();
            else
                return data;
        }

        public static IEnumerable<FileData> ValidateAppsTitle(this IEnumerable<FileData> data)
        {
            if (data.Department().StringValue == "Apps"
                && !AppSupportTitles.Contains(data.Title().StringValue))
                throw new ArgumentException();
            else
                return data;
        }

        public static IEnumerable<FileData> ValidateNonArchitectAndNonAppsTitle(this IEnumerable<FileData> data)
        {
            if (!new[] { "Architecture", "Apps" }.Contains(data.Department().StringValue)
                && ArchitectTitles.Concat(AppSupportTitles).Contains(data.Title().StringValue))
                throw new ArgumentException();
            else
                return data;
        }
    }
}
