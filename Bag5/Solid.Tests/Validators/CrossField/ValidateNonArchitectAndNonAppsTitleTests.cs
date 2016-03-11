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
    public class ValidateNonArchitectAndNonAppsTitleTests
    {
        [Test]
        public void Validate_NonArchitectAndNonAppsTitle_Succeeds()
        {
            var validator = new ValidateNonArchitectAndNonAppsTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = "abc" },
                new FileData { Fieldname = Constants.Field.Title, StringValue = "xyz" }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [TestCaseSource("ArchitectTitles")]
        public void Validate_NotArchitectureDepartmentKnownArchitectureTitle_Throws(string title)
        {
            var validator = new ValidateNonArchitectAndNonAppsTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = "abc" },
                new FileData { Fieldname = Constants.Field.Title, StringValue = title }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }

        [TestCaseSource("AppsTitles")]
        public void Validate_NotAppSupportDepartmentKnownAppSupportTitle_Throws(string title)
        {
            var validator = new ValidateNonArchitectAndNonAppsTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = "abc" },
                new FileData { Fieldname = Constants.Field.Title, StringValue = title }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }

        public static string[] ArchitectTitles { get { return Constants.Titles.Architect; } }

        public static string[] AppsTitles { get { return Constants.Titles.Apps; } }
    }
}
