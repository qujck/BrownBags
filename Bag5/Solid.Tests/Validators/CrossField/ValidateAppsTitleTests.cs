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
    public class ValidateAppsTitleTests
    {
        [TestCaseSource("AppsTitles")]
        public void Validate_AppSupportDepartmentKnownTitle_Succeeds(string title)
        {
            var validator = new ValidateAppsTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Architecture },
                new FileData { Fieldname = Constants.Field.Title, StringValue = title }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [Test]
        public void Validate_AppSupportDepartmentUnknownTitle_Throws()
        {
            var validator = new ValidateAppsTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Apps },
                new FileData { Fieldname = Constants.Field.Title, StringValue = "abc" }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }

        public static string[] AppsTitles { get { return Constants.Titles.Apps; } }
    }
}
