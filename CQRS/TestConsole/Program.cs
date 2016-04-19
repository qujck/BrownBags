using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var addressReader = new ReadAddressHandler();
            var accountReader = new ReadBankAccountHandler();

            addressReader.Handle(new ReadAddress { Id = 1 });
            accountReader.Handle(new ReadBankAccount { Id = 1 });

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
