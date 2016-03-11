using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.Validators.CrossField
{
    public class ValidateAppsTitle : ICrossFieldValidator
    {
        public void Validate(IEnumerable<FileData> data)
        {
            if (data.Department().StringValue == Constants.Department.Apps
                && !Constants.Titles.Apps.Contains(data.Title().StringValue))
            { 
                throw new ArgumentException();
            }
        }
    }
}
