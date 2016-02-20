using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Validators.SingleField;
using Solid.Model;
using NUnit.Framework;

namespace Solid.Tests.Unit.Validators.SingleField
{
    public class IsValidEmployeeNumberTests
    {
        [TestCase("ABC12345678")]
        [TestCase("AAA11111111")]
        public void Validate_WhenStringIsValidEmployeeNumber_Succeeds(string value)
        {
            var validator = new IsValidEmployeeNumber();
            var data = new FileData { StringValue = value };
            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [TestCase("AAA1111111")]
        [TestCase("AAA111111111")]
        [TestCase("AA111111111")]
        [TestCase("AAAA1111111")]
        public void Validate_WhenStringIsNotValidEmployeeNumber_Throws(string value)
        {
            var validator = new IsValidEmployeeNumber();
            var data = new FileData { StringValue = value };
            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }
    }
}
