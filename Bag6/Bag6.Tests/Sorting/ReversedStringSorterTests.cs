using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Bag6.Sorting;

namespace Bag6.Tests.Sorting
{
    public class ReversedStringSorterTests
    {
        //[Test]
        public void Sort_Always_ReturnsExpectedResults()
        {
            var sorter = new ReversedStringSorter();

            var result = sorter.Sort(new[] { "abc", "bcd", "dcb", "cba" }).ToArray();

            Assert.AreEqual(
                new[] { "cba", "dcb", "abc", "bcd" },
                result);
        }
    }
}
