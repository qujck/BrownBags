using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Model;

namespace CQRS
{
    public class ReadBankAccount : IQuery<BankAccount>
    {
        public long Id { get; set; }
    }

    public sealed class ReadBankAccountHandler : IQueryHandler<ReadBankAccount, BankAccount>
    {
        public BankAccount Handle(ReadBankAccount query)
        {
            if (query.Id != 1)
            {
                throw new KeyNotFoundException();
            }

            return new BankAccount
            {
                SortCode = "123456",
                Number = "12345678",
                Name = "Mr A CLient"
            };
        }
    }
}
