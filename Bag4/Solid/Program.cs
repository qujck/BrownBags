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
        #region Composition Root
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

        static Program()
        {
            IServiceProvider serviceProvider = new ServiceProvider();
            readers = new IFileReader[]
            {
                serviceProvider.GetService<CsvReader>(),
                serviceProvider.GetService<TabularReader>(),
                serviceProvider.GetService<XmlReader>()
            };
            doesNotContainANumber = serviceProvider.GetService<DoesNotContainANumber>();
            isNotEmpty = serviceProvider.GetService<IsNotEmpty>();
            isNotLongerThan256 = serviceProvider.GetService<IsNotLongerThan256>();
            isNotNull = serviceProvider.GetService<IsNotNull>();
            isValidEmployeeNumber = serviceProvider.GetService<IsValidEmployeeNumber>();
            validateAppsTitle = serviceProvider.GetService<ValidateAppsTitle>();
            validateArchitectTitle = serviceProvider.GetService<ValidateArchitectTitle>();
            validateBoardEmployeeNumber = serviceProvider.GetService<ValidateBoardEmployeeNumber>();
            validateFinanceEmployeeNumber = serviceProvider.GetService<ValidateFinanceEmployeeNumber>();
            validateNonArchitectAndNonAppsTitle = serviceProvider.GetService<ValidateNonArchitectAndNonAppsTitle>();
            validateNonFinanceNonBoardEmployeeNumber = serviceProvider.GetService<ValidateNonFinanceNonBoardEmployeeNumber>();
        }
        #endregion

        public static void Main(string[] args)
        {
            var data = ReadFileData(args[0]);

            ValidateName(data.Name());
            ValidateDepartment(data.Department());
            ValidateEmployeeNumber(data.EmployeeNumber());
            ValidateData(data);

            Console.WriteLine("Completed");
        }

        private static void ValidateName(FileData name)
        {
            doesNotContainANumber.Validate(name);
            isNotNull.Validate(name);
            isNotEmpty.Validate(name);
            isNotLongerThan256.Validate(name);
        }

        private static void ValidateDepartment(FileData department)
        {
            isNotEmpty.Validate(department);
            isNotLongerThan256.Validate(department);
        }

        private static void ValidateEmployeeNumber(FileData employeeNumber)
        {
            isNotNull.Validate(employeeNumber);
            isValidEmployeeNumber.Validate(employeeNumber);
        }

        private static void ValidateData(IEnumerable<FileData> data)
        {
            validateAppsTitle.Validate(data);
            validateArchitectTitle.Validate(data);
            validateBoardEmployeeNumber.Validate(data);
            validateFinanceEmployeeNumber.Validate(data);
            validateNonArchitectAndNonAppsTitle.Validate(data);
            validateNonFinanceNonBoardEmployeeNumber.Validate(data);
        }

        private static IEnumerable<FileData> ReadFileData(string filename)
        {
            var reader = readers
                .Where(x => x.CanRead(filename))
                .Single();

            return reader.Read(filename);
        }
    }
}
