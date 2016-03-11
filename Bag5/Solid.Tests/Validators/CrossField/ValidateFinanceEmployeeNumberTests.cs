using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Validators.CrossField;
using Solid.Model;
using NUnit.Framework;

namespace Solid.Tests.Unit.Validators.CrossField
{
    public class ValidateFinanceEmployeeNumberTests
    {
        [TestCase("FIN")]
        [TestCase("FIN1")]
        [TestCase("FIN12345678")]
        public void Validate_FinanceDepartmentEmployeeNumberStartsWithFIN_Succeeds(string employeeNumber)
        {
            var validator = new ValidateFinanceEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Finance },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = employeeNumber }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [TestCase("Financ")]
        [TestCase("Finance1")]
        [TestCase("xyz")]
        public void Validate_NotFinanceDepartmentEmployeeNumberStartsWithFIN_Succeeds(string department)
        {
            var validator = new ValidateFinanceEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = department },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = "FIN12345678" }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [Test]
        public void Validate_DepartmentIsMissing_Throws()
        {
            var validator = new ValidateFinanceEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = "FIN12345678" }
            };

            Assert.Throws<InvalidOperationException>(() => validator.Validate(data));
        }

        [Test]
        public void Validate_EmployeeNumberIsMissing_Throws()
        {
            var validator = new ValidateFinanceEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Finance }
            };

            Assert.Throws<InvalidOperationException>(() => validator.Validate(data));
        }

        [TestCase("FI")]
        [TestCase("INF1")]
        [TestCase("1FIN")]
        public void Validate_FinanceDepartmentEmployeeNumberNotStartsWithFIN_Throws(string employeeNumber)
        {
            var validator = new ValidateFinanceEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Finance },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = employeeNumber }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }
    }
}
