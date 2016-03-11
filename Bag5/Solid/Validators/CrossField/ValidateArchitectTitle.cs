using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.Validators.CrossField
{
    public class ValidateArchitectTitle : ICrossFieldValidator
    {
        public void Validate(IEnumerable<FileData> data)
        {
            if (data.Department().StringValue == Constants.Department.Architecture
                && !Constants.Titles.Architect.Contains(data.Title().StringValue))
            {
                throw new ArgumentException();
            }
        }
    }
}
