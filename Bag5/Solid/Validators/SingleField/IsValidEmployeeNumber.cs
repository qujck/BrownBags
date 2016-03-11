using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.Validators.SingleField
{
    public class IsValidEmployeeNumber : ISingleFieldValidator
    {
        public void Validate(FileData data)
        {
            if (!new Regex(@"^([a-zA-Z]){3}(\d){8}$").IsMatch(data.StringValue))
                throw new ArgumentException(data.Fieldname);
        }
    }
}
