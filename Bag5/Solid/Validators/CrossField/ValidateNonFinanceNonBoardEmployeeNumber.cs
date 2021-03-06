﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Model;

namespace Solid.Validators.CrossField
{
    public class ValidateNonFinanceNonBoardEmployeeNumber : ICrossFieldValidator
    {
        public void Validate(IEnumerable<FileData> data)
        {
            if (data.Department().StringValue != Constants.Department.Finance
                && data.Department().StringValue != Constants.Department.Board
                && (data.EmployeeNumber().StringValue.StartsWith(Constants.Prefix.EmployeeNumber.BRD)
                    || data.EmployeeNumber().StringValue.StartsWith(Constants.Prefix.EmployeeNumber.FIN)))
            {
                throw new ArgumentException();
            }
        }
    }
}
