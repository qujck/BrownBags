using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Statics.Tests.Unit
{
    public class SingleFieldValidationTests
    {
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("ABC")]
        [TestCase("AbC")]
        public void DoesNotContainANumber_WhenStringDoesNotContainANumber_Succeeds(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.DoesNotThrow(() => data.DoesNotContainANumber());
        }

        [TestCase("1")]
        [TestCase("abc1")]
        [TestCase("ab1c")]
        [TestCase("1abc")]
        public void DoesNotContainANumber_WhenStringDoesContainANumber_Throws(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.Throws<ArgumentException>(() => data.DoesNotContainANumber());
        }

        [Test]
        public void DoesNotContainANumber_WhenStringDoesContainANumber_WritesTraceMessage()
        {
            var listener = new TestListener();
            Trace.Listeners.Add(listener);

            var data = new FileData { StringValue = "1" };
            Assert.Throws<ArgumentException>(() => data.DoesNotContainANumber());

            Assert.AreEqual("Test:DoesNotContainANumberFailed:DoesNotContainANumber", listener.Output);
            Trace.Listeners.Remove(listener);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("abc")]
        public void IsNotNull_WhenValueIsNotNull_Succeeds(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.DoesNotThrow(() => data.IsNotNull());
        }

        [Test]
        public void IsNotNull_WhenValueIsNull_Throws()
        {
            var data = new FileData { StringValue = null };
            Assert.Throws<ArgumentException>(() => data.IsNotNull());
        }


        [Test]
        public void IsNotNull_WhenValueIsNull_WritesTraceMessage()
        {
            var listener = new TestListener();
            Trace.Listeners.Add(listener);

            var data = new FileData { StringValue = null };
            Assert.Throws<ArgumentException>(() => data.IsNotNull());

            Assert.AreEqual("Test:IsNotNullFailed:IsNotNull", listener.Output);
            Trace.Listeners.Remove(listener);
        }

        [Test]
        public void IsNotEmpty_WhenStringIsNotEmpty_Succeeds()
        {
            var data = new FileData { StringValue = "abv" };
            Assert.DoesNotThrow(() => data.IsNotEmpty());
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void IsNotEmpty_WhenStringIsEmpty_Throws(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.Throws<ArgumentException>(() => data.IsNotEmpty());
        }

        [TestCase("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345")]
        [TestCase("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456")]
        public void IsNoLongerThan256_WhenStringIsNoLongerThan256_Succeeds(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.LessOrEqual(value.Length, 256);
            Assert.DoesNotThrow(() => data.IsNoLongerThan256());
        }

        [TestCase("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567")]
        [TestCase("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678")]
        public void IsNoLongerThan256_WhenStringIsLongerThan256_Throws(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.Greater(value.Length, 256);
            Assert.Throws<ArgumentException>(() => data.IsNoLongerThan256());
        }

        [TestCase("ABC12345678")]
        [TestCase("AAA11111111")]
        public void IsValidEmployeeNumber_WhenStringIsValidEmployeeNumber_Succeeds(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.DoesNotThrow(() => data.IsValidEmployeeNumber());
        }

        [TestCase("AAA1111111")]
        [TestCase("AAA111111111")]
        [TestCase("AA111111111")]
        [TestCase("AAAA1111111")]
        public void IsValidEmployeeNumber_WhenStringIsNotValidEmployeeNumber_Throws(string value)
        {
            var data = new FileData { StringValue = value };
            Assert.Throws<ArgumentException>(() => data.IsValidEmployeeNumber());
        }
    }
}
