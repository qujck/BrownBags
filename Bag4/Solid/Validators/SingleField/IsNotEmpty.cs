using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.Validators.SingleField
{
    public class IsNotEmpty : ISingleFieldValidator
    {
        public void Validate(FileData data)
        {
            if (string.IsNullOrWhiteSpace(data.StringValue))
                throw new ArgumentException(data.Fieldname);
        }
    }
}
