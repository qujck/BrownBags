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
    public class ValidateArchitectTitleTests
    {
        [TestCaseSource("ArchitectTitles")]
        public void Validate_ArchitectureDepartmentKnownTitle_Succeeds(string title)
        {
            var validator = new ValidateArchitectTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Architecture },
                new FileData { Fieldname = Constants.Field.Title, StringValue = title }
            };

            Assert.DoesNotThrow(() => validator.Validate(data));
        }

        [Test]
        public void Validate_ArchitectureDepartmentUnknownTitle_Throws()
        {
            var validator = new ValidateArchitectTitle();
            var data = new[]
            {
                new FileData { Fieldname = Constants.Field.Dept, StringValue = Constants.Department.Architecture },
                new FileData { Fieldname = Constants.Field.Title, StringValue = "abc" }
            };

            Assert.Throws<ArgumentException>(() => validator.Validate(data));
        }

        public static string[] ArchitectTitles { get { return Constants.Titles.Architect; } }
    }
}
