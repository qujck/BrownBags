using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Statics.Tests.Unit
{
    public class CrossFieldValidationTests
    {
        [TestCase("FIN")]
        [TestCase("FIN1")]
        [TestCase("FIN12345678")]
        public void ValidateFinanceEmployeeNumber_FinanceDepartmentEmployeeNumberStartsWithFIN_Succeeds(string employeeNumber)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Finance" },
                new FileData { Fieldname = "EmployeeNumber", StringValue = employeeNumber }
            };

            Assert.DoesNotThrow(() => data.ValidateFinanceEmployeeNumber());
        }

        [TestCase("Financ")]
        [TestCase("Finance1")]
        [TestCase("xyz")]
        public void ValidateFinanceEmployeeNumber_NotFinanceDepartmentEmployeeNumberStartsWithFIN_Succeeds(string department)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = department },
                new FileData { Fieldname = "EmployeeNumber", StringValue = "FIN12345678" }
            };

            Assert.DoesNotThrow(() => data.ValidateFinanceEmployeeNumber());
        }

        [Test]
        public void ValidateFinanceEmployeeNumber_DepartmentIsMissing_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "EmployeeNumber", StringValue = "FIN12345678" }
            };

            Assert.Throws<InvalidOperationException>(() => data.ValidateFinanceEmployeeNumber());
        }

        [Test]
        public void ValidateFinanceEmployeeNumber_EmployeeNumberIsMissing_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Finance" }
            };

            Assert.Throws<InvalidOperationException>(() => data.ValidateFinanceEmployeeNumber());
        }

        [TestCase("FI")]
        [TestCase("INF1")]
        [TestCase("1FIN")]
        public void ValidateFinanceEmployeeNumber_FinanceDepartmentEmployeeNumberNotStartsWithFIN_Throws(string employeeNumber)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Finance" },
                new FileData { Fieldname = "EmployeeNumber", StringValue = employeeNumber }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateFinanceEmployeeNumber());
        }

        [TestCase("BRD")]
        [TestCase("BRD1")]
        [TestCase("BRD12345678")]
        public void ValidateBoardEmployeeNumber_BoardDepartmentEmployeeNumberStartsWithBRD_Succeeds(string employeeNumber)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Board" },
                new FileData { Fieldname = "EmployeeNumber", StringValue = employeeNumber }
            };

            Assert.DoesNotThrow(() => data.ValidateBoardEmployeeNumber());
        }

        [TestCase("Boar")]
        [TestCase("Board1")]
        [TestCase("xyz")]
        public void ValidateBoardEmployeeNumber_NotBoardDepartmentEmployeeNumberStartsWithBRD_Succeeds(string department)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = department },
                new FileData { Fieldname = "EmployeeNumber", StringValue = "BRD12345678" }
            };

            Assert.DoesNotThrow(() => data.ValidateBoardEmployeeNumber());
        }

        [Test]
        public void ValidateBoardEmployeeNumber_DepartmentIsMissing_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "EmployeeNumber", StringValue = "FIN12345678" }
            };

            Assert.Throws<InvalidOperationException>(() => data.ValidateBoardEmployeeNumber());
        }

        [Test]
        public void ValidateBoardEmployeeNumber_EmployeeNumberIsMissing_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Board" }
            };

            Assert.Throws<InvalidOperationException>(() => data.ValidateBoardEmployeeNumber());
        }

        [TestCase("BR")]
        [TestCase("BDR1")]
        [TestCase("1BRD")]
        public void ValidateBoardEmployeeNumber_BoardDepartmentEmployeeNumberNotStartsWithBRD_Throws(string employeeNumber)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Board" },
                new FileData { Fieldname = "EmployeeNumber", StringValue = employeeNumber }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateBoardEmployeeNumber());
        }

        [TestCase("Board", "BRD1")]
        [TestCase("Finance", "FIN1")]
        public void ValidateNonFinanceNonBoardEmployeeNumber_ValidFinanceOrBoardDetails_Succeeds(string department, string employeeNumber)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = department },
                new FileData { Fieldname = "EmployeeNumber", StringValue = employeeNumber }
            };

            Assert.DoesNotThrow(() => data.ValidateNonFinanceNonBoardEmployeeNumber());
        }

        [Test]
        public void ValidateNonFinanceNonBoardEmployeeNumber_DepartmentNotBoardNotFinanceEmployeeNumberStartsWithFIN_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "abc" },
                new FileData { Fieldname = "EmployeeNumber", StringValue = "FIN1" }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateNonFinanceNonBoardEmployeeNumber());
        }

        [Test]
        public void ValidateNonFinanceNonBoardEmployeeNumber_DepartmentNotBoardNotFinanceEmployeeNumberStartsWithBRD_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "abc" },
                new FileData { Fieldname = "EmployeeNumber", StringValue = "BRD1" }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateNonFinanceNonBoardEmployeeNumber());
        }

        [TestCaseSource("ArchitectTitles")]
        public void ValidateArchitectTitle_ArchitectureDepartmentKnownTitle_Succeeds(string title)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Architecture" },
                new FileData { Fieldname = "Title", StringValue = title }
            };

            Assert.DoesNotThrow(() => data.ValidateArchitectTitle());
        }

        [Test]
        public void ValidateArchitectTitle_ArchitectureDepartmentUnknownTitle_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Architecture" },
                new FileData { Fieldname = "Title", StringValue = "abc" }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateArchitectTitle());
        }

        [TestCaseSource("AppSupportTitles")]
        public void ValidateAppsTitle_AppSupportDepartmentKnownTitle_Succeeds(string title)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Architecture" },
                new FileData { Fieldname = "Title", StringValue = title }
            };

            Assert.DoesNotThrow(() => data.ValidateAppsTitle());
        }

        [Test]
        public void ValidateAppsTitle_AppSupportDepartmentUnknownTitle_Throws()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "Apps" },
                new FileData { Fieldname = "Title", StringValue = "abc" }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateAppsTitle());
        }

        [Test]
        public void ValidateNonArchitectAndNonAppsTitle_NonArchitectAndNonAppsTitle_Succeeds()
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "abc" },
                new FileData { Fieldname = "Title", StringValue = "xyz" }
            };

            Assert.DoesNotThrow(() => data.ValidateNonArchitectAndNonAppsTitle());
        }

        [TestCaseSource("ArchitectTitles")]
        public void ValidateNonArchitectAndNonAppsTitle_NotArchitectureDepartmentKnownArchitectureTitle_Throws(string title)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "abc" },
                new FileData { Fieldname = "Title", StringValue = title }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateNonArchitectAndNonAppsTitle());
        }

        [TestCaseSource("AppSupportTitles")]
        public void ValidateNonArchitectAndNonAppsTitle_NotAppSupportDepartmentKnownAppSupportTitle_Throws(string title)
        {
            var data = new[]
            {
                new FileData { Fieldname = "Dept", StringValue = "abc" },
                new FileData { Fieldname = "Title", StringValue = title }
            };

            Assert.Throws<ArgumentException>(() => data.ValidateNonArchitectAndNonAppsTitle());
        }

        public static string[] ArchitectTitles { get { return CrossFieldValidation.ArchitectTitles; } }

        public static string[] AppSupportTitles { get { return CrossFieldValidation.AppSupportTitles; } }
    }
}
