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
    public class ValidateNonFinanceNonBoardEmployeeNumberTests
    {
        [TestCase("Board", "BRD1")]
        [TestCase("Finance", "FIN1")]
        public void Validate_ValidFinanceOrBoardDetails_Succeeds(string department, string employeeNumber)
        {
            var validator = new ValidateNonFinanceNonBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = department },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = employeeNumber }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [Test]
        public void Validate_DepartmentNotBoardNotFinanceEmployeeNumberStartsWithFIN_Throws()
        {
            var validator = new ValidateNonFinanceNonBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = "abc" },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = "FIN1" }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }

        [Test]
        public void Validate_DepartmentNotBoardNotFinanceEmployeeNumberStartsWithBRD_Throws()
        {
            var validator = new ValidateNonFinanceNonBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = "abc" },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = "BRD1" }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }

    }
}
