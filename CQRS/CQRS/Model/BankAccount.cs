using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Model
{
    public class BankAccount
    {
        public string SortCode { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}
