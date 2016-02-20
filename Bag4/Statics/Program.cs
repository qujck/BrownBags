using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<FileData> data = Readers.ReadData(args[0]);

            data.Name()
                .DoesNotContainANumber()
                .IsNotNull()
                .IsNotEmpty()
                .IsNoLongerThan256();

            data.Department()
                .IsNotEmpty()
                .IsNoLongerThan256();

            data.EmployeeNumber()
                .IsNotNull()
                .IsValidEmployeeNumber();

            data.ValidateAppsTitle()
                .ValidateArchitectTitle()
                .ValidateNonArchitectAndNonAppsTitle()
                .ValidateBoardEmployeeNumber()
                .ValidateFinanceEmployeeNumber()
                .ValidateNonFinanceNonBoardEmployeeNumber();
        }
    }
}
