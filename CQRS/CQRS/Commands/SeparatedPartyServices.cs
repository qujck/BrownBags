using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public interface ICreateParty
    {
        void Create(string path, string name);
    }

    public interface IUpdateParty
    {
        void Update(string path, string name);
    }

    public interface IDeleteParty
    {
        void Delete(string path);
    }

    public sealed class CreatePartyService : ICreateParty
    {
        public void Create(string path, string name)
        {
            File.WriteAllText(path, string.Format("Name:{0}", name));
        }
    }

    public sealed class UpdatePartyService : IUpdateParty
    {
        public void Update(string path, string name)
        {
            var file = File.Open(path, FileMode.Truncate);
            file.Close();
            File.WriteAllText(path, string.Format("Name:{0}", name));
        }
    }

    public sealed class DeletePartyService : IDeleteParty
    {
        public void Delete(string path)
        {
            File.Delete(path);
        }
    }

    public sealed class CreatePartyServiceLogger : ICreateParty
    {
        private readonly ICreateParty decorated;

        public CreatePartyServiceLogger(ICreateParty decorated)
        {
            this.decorated = decorated;
        }

        public void Create(string path, string name)
        {
            Console.WriteLine("Creating {0} for {1}", path, name);
            this.decorated.Create(path, name);
        }
    }

    public sealed class UpdatePartyServiceLogger : IUpdateParty
    {
        private readonly IUpdateParty decorated;

        public UpdatePartyServiceLogger(IUpdateParty decorated)
        {
            this.decorated = decorated;
        }

        public void Update(string path, string name)
        {
            Console.WriteLine("Updating {0} for {1}", path, name);
            this.decorated.Update(path, name);
        }
    }

    public sealed class DeletePartyServiceLogger : IDeleteParty
    {
        private readonly IDeleteParty decorated;

        public DeletePartyServiceLogger(IDeleteParty decorated)
        {
            this.decorated = decorated;
        }

        public void Delete(string path)
        {
            Console.WriteLine("Deleting {0}", path);
            this.decorated.Delete(path);
        }
    }
}
