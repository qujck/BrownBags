using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public sealed class CreateParty : ICommand
    {
        public string path;
        public string name;
    }

    public sealed class CreatePartyHandler : ICommandHandler<CreateParty>
    {
        public void Handle(CreateParty command)
        {
            File.WriteAllText(command.path, string.Format("Name:{0}", command.name));
        }
    }
}
