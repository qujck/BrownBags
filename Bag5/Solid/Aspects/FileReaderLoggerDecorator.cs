using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solid.Model;

namespace Solid.Aspects
{
    public sealed class FileReaderLoggerDecorator : IFileReader
    {
        private readonly IFileReader decorated;
        private readonly ILogger logger;

        public FileReaderLoggerDecorator(
            IFileReader decorated,
            ILogger logger)
        {
            this.decorated = decorated;
            this.logger = logger;
        }

        public bool CanRead(string filename)
        {
            var result = this.decorated.CanRead(filename);

            if (result)
            {
                this.logger.Log(() => $"{this.decorated.GetType().Name} can read {filename}");
            }
            else
            {
                this.logger.Log(() => $"{this.decorated.GetType().Name}  can't read {filename}");
            }


            return result;
        }

        public IEnumerable<FileData> Read(string filename)
        {
            var result = this.decorated.Read(filename);

            this.logger.Log(() => $"{this.decorated.GetType().Name}: " + JsonConvert.SerializeObject(result));

            return result;
        }
    }
}
