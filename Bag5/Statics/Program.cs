using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
    public class Program
    {
        public static IEnumerable<FileData> Data { get; private set; }

        public static void Main(string[] args)
        {
            var data = Readers.ReadData(args[0]);

            ValidateName(data.Name());
            ValidateDepartment(data.Department());
            ValidateEmployeeNumber(data.EmployeeNumber());
            ValidateData(data);

            Data = data;

            Console.WriteLine("Completed");
        }

        private static void ValidateName(FileData name)
        {
            name.DoesNotContainANumber()
                .IsNotNull()
                .IsNotEmpty()
                .IsNoLongerThan256();
        }

        private static void ValidateDepartment(FileData department)
        {
            department.IsNotEmpty()
                .IsNoLongerThan256();
        }

        private static void ValidateEmployeeNumber(FileData employeeNumber)
        {
            employeeNumber.IsNotNull()
                .IsValidEmployeeNumber();
        }

        private static void ValidateData(IEnumerable<FileData> data)
        {
            data.ValidateAppsTitle()
                .ValidateArchitectTitle()
                .ValidateNonArchitectAndNonAppsTitle()
                .ValidateBoardEmployeeNumber()
                .ValidateFinanceEmployeeNumber()
                .ValidateNonFinanceNonBoardEmployeeNumber();
        }
    }
}
