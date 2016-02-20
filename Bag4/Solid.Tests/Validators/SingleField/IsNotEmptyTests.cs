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
    public class IsNotEmptyTests
    {
        [Test]
        public void Validate_WhenStringIsNotEmpty_Succeeds()
        {
            var validator = new IsNotEmpty();
            var data = new FileData { StringValue = "abv" };
            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Validate_WhenStringIsEmpty_Throws(string value)
        {
            var validator = new IsNotEmpty();
            var data = new FileData { StringValue = value };
            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }
    }
}
