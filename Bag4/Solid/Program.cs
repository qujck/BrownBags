using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.FileReaders;
using Solid.Model;
using Solid.Validators.CrossField;
using Solid.Validators.SingleField;

namespace Solid
{
    public class Program
    {
        static readonly IFileReader[] readers;
        static readonly ISingleFieldValidator doesNotContainANumber;
        static readonly ISingleFieldValidator isNotEmpty;
        static readonly ISingleFieldValidator isNotLongerThan256;
        static readonly ISingleFieldValidator isNotNull;
        static readonly ISingleFieldValidator isValidEmployeeNumber;
        static readonly ICrossFieldValidator validateAppsTitle;
        static readonly ICrossFieldValidator validateArchitectTitle;
        static readonly ICrossFieldValidator validateBoardEmployeeNumber;
        static readonly ICrossFieldValidator validateFinanceEmployeeNumber;
        static readonly ICrossFieldValidator validateNonArchitectAndNonAppsTitle;
        static readonly ICrossFieldValidator validateNonFinanceNonBoardEmployeeNumber;

        public static void Main(string[] args)
        {
            IEnumerable<FileData> data = readers.Single(reader => reader.CanRead(args[0])).Read(args[0]);

            doesNotContainANumber.Validate(data.Name());
            isNotNull.Validate(data.Name());
            isNotEmpty.Validate(data.Name());
            isNotLongerThan256.Validate(data.Name());

            isNotEmpty.Validate(data.Department());
            isNotLongerThan256.Validate(data.Department());

            isNotNull.Validate(data.EmployeeNumber());
            isValidEmployeeNumber.Validate(data.EmployeeNumber());

            validateAppsTitle.Validate(data);
            validateArchitectTitle.Validate(data);
            validateBoardEmployeeNumber.Validate(data);
            validateFinanceEmployeeNumber.Validate(data);
            validateNonArchitectAndNonAppsTitle.Validate(data);
            validateNonFinanceNonBoardEmployeeNumber.Validate(data);

            Console.WriteLine("Completed");
        }

        static Program()
        {
            readers = new IFileReader[]
            {
                new CsvReader(),
                new TabularReader(),
                new XmlReader()
            };
            doesNotContainANumber = new DoesNotContainANumber();
            isNotEmpty = new IsNotEmpty();
            isNotLongerThan256 = new IsNotLongerThan256();
            isNotNull = new IsNotNull();
            isValidEmployeeNumber = new IsValidEmployeeNumber();
            validateAppsTitle = new ValidateAppsTitle();
            validateArchitectTitle = new ValidateArchitectTitle();
            validateBoardEmployeeNumber = new ValidateBoardEmployeeNumber();
            validateFinanceEmployeeNumber = new ValidateFinanceEmployeeNumber();
            validateNonArchitectAndNonAppsTitle = new ValidateNonArchitectAndNonAppsTitle();
            validateNonFinanceNonBoardEmployeeNumber = new ValidateNonFinanceNonBoardEmployeeNumber();
        }
    }
}
