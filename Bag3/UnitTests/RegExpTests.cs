using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace UnitTests
{
    public class RegExpTests
    {
        [Test]
        public void TestNameDoesntContainANumber()
        {
            var regex = new Regex(@"(\d)");

            Assert.True(regex.IsMatch("12ame"));
            Assert.True(regex.IsMatch("N12ame"));
            Assert.True(regex.IsMatch("N12"));
        }

        [Test]
        public void WordsTest()
        {
            var regex = new Regex(@"^(\w|-)*$");

            Assert.True(regex.IsMatch("bob"));
            Assert.True(regex.IsMatch("bob1"));
            Assert.True(regex.IsMatch("bob-bib"));
        }
    }
}
