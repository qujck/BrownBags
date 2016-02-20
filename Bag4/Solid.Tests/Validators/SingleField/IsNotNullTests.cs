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
    public class IsNotNullTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("abc")]
        public void Validate_WhenValueIsNotNull_Succeeds(string value)
        {
            var validator = new IsNotNull();
            var data = new FileData { StringValue = value };
            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [Test]
        public void Validate_WhenValueIsNull_Throws()
        {
            var validator = new IsNotNull();
            var data = new FileData { StringValue = null };
            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }
    }
}
