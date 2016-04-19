using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Model;

namespace CQRS
{
    public class ReadAddress : IQuery<Address>
    {
        public long Id { get; set; }
    }

    public sealed class ReadAddressHandler : IQueryHandler<ReadAddress, Address>
    {
        public Address Handle(ReadAddress query)
        {
            return new Address
            {
                Line1 = "Line 1",
                Line2 = "Line 2",
                Line3 = "Line 3",
                Line4 = "Line 4",
                Line5 = "Line 5",
                PostCode = "ABC123"
            };
        }
    }
}
