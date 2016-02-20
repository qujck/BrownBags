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
    public class ValidateBoardEmployeeNumberTests
    {
        [TestCase("BRD")]
        [TestCase("BRD1")]
        [TestCase("BRD12345678")]
        public void Validate_BoardDepartmentEmployeeNumberStartsWithBRD_Succeeds(string employeeNumber)
        {
            var validator = new ValidateBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Board },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = employeeNumber }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [TestCase("Boar")]
        [TestCase("Board1")]
        [TestCase("xyz")]
        public void Validate_NotBoardDepartmentEmployeeNumberStartsWithBRD_Succeeds(string department)
        {
            var validator = new ValidateBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = department },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = "BRD12345678" }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [Test]
        public void Validate_DepartmentIsMissing_Throws()
        {
            var validator = new ValidateBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = "FIN12345678" }
            };

            Assert.Throws<InvalidOperationException>(() => validator.Validate(data));
        }

        [Test]
        public void Validate_EmployeeNumberIsMissing_Throws()
        {
            var validator = new ValidateBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Board }
            };

            Assert.Throws<InvalidOperationException>(() => validator.Validate(data));
        }

        [TestCase("BR")]
        [TestCase("BDR1")]
        [TestCase("1BRD")]
        public void Validate_BoardDepartmentEmployeeNumberNotStartsWithBRD_Throws(string employeeNumber)
        {
            var validator = new ValidateBoardEmployeeNumber();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Board },
                new FileData { Fieldname = Constants.Field.EmployeeNumber, StringValue = employeeNumber }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }
    }
}
