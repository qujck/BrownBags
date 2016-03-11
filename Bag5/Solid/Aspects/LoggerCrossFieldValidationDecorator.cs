using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solid.Model;

namespace Solid.Aspects
{
    public sealed class LoggerCrossFieldValidationDecorator :
        ICrossFieldValidator
    {
        private readonly ICrossFieldValidator decorated;
        private readonly ILogger logger;

        public LoggerCrossFieldValidationDecorator(
            ICrossFieldValidator decorated,
            ILogger logger)
        {
            this.decorated = decorated;
            this.logger = logger;
        }

        public void Validate(IEnumerable<FileData> data)
        {
            try
            {
                this.logger.Log(() => $"Test: {this.decorated.GetType().Name}:{DateTime.Now} " + JsonConvert.SerializeObject(data));
            }
            catch
            {
                this.logger.Log(() => $"Failed: {this.decorated.GetType().Name}");
                throw;
            }
        }
    }
}
