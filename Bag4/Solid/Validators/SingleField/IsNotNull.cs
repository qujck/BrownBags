using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.Validators.SingleField
{
    public class IsNotNull : ISingleFieldValidator
    {
        public void Validate(FileData data)
        {
            if (data.StringValue == null)
                throw new ArgumentException(data.Fieldname);
        }
    }
}
