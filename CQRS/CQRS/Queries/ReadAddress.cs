﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Model;

namespace CQRS.Queries
{
    public class ReadAddress : IQuery<Address>
    {
        public ReadAddress(int id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }

    public sealed class ReadAddressHandler : IQueryHandler<ReadAddress, Address>
    {
        public Address Handle(ReadAddress query)
        {
            if (query.Id != 1)
            {
                throw new KeyNotFoundException();
            }

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
