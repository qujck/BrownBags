using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public sealed class OnePartyService
    {
        public void CreateParty(string path, string name)
        {
            Console.WriteLine("Creating {0} for {1}", path, name);

            File.WriteAllText(path, string.Format("Name:{0}", name));
        }

        public void UpdateParty(string path, string name)
        {
            Console.WriteLine("Updating {0} for {1}", path, name);

            var file = File.Open(path, FileMode.Truncate);
            file.Close();
            File.WriteAllText(path, string.Format("Name:{0}", name));
        }

        public void DeleteParty(string path)
        {
            Console.WriteLine("Deleting {0}", path);

            File.Delete(path);
        }
    }
}
