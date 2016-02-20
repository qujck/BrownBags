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
    public class DoesNotContainANumberTests
    {
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("ABC")]
        [TestCase("AbC")]
        public void Validate_WhenStringDoesNotContainANumber_Succeeds(string value)
        {
            var validator = new DoesNotContainANumber();
            var data = new FileData { StringValue = value };
            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [TestCase("1")]
        [TestCase("abc1")]
        [TestCase("ab1c")]
        [TestCase("1abc")]
        public void Validate_WhenStringDoesContainANumber_Throws(string value)
        {
            var validator = new DoesNotContainANumber();
            var data = new FileData { StringValue = value };
            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }
    }
}
