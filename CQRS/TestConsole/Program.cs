using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Queries;

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

        /*
        static void Main(string[] args)
        {
            var createPartyHandler = new CreatePartyHandler();
            var parameter = new CreateParty
            {
                path = @"C:\Temp\Party3.txt",
                name = "Mark"
            };
            createPartyHandler.Handle(parameter);

            AllInOneFile();

            SeparateDecoratedClasses();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void SeparateDecoratedClasses()
        {
            string file2 = @"C:\Temp\Party2.txt";

            ICreateParty createParty = new CreatePartyService();
            createParty = new CreatePartyServiceLogger(createParty);
            IUpdateParty updateParty = new UpdatePartyService();
            updateParty = new UpdatePartyServiceLogger(updateParty);
            IDeleteParty deleteParty = new DeletePartyService();
            deleteParty = new DeletePartyServiceLogger(deleteParty);

            createParty.Create(file2, "Billy");
            updateParty.Update(file2, "Bob");
            deleteParty.Delete(file2);
        }

        private static void AllInOneFile()
        {
            string file1 = @"C:\Temp\Party1.txt";

            var service = new OnePartyService();

            service.CreateParty(file1, "John");
            service.UpdateParty(file1, "James");
            service.DeleteParty(file1);
        }
        */
    }
}
