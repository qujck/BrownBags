using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solid.Model;

namespace Solid.Aspects
{
    public sealed class LoggerSingleFieldValidatorDecorator :
        ISingleFieldValidator
    {
        private readonly ISingleFieldValidator decorated;
        private readonly ILogger logger;

        public LoggerSingleFieldValidatorDecorator(
            ISingleFieldValidator decorated,
            ILogger logger)
        {
            this.decorated = decorated;
            this.logger = logger;
        }

        public void Validate(FileData data)
        {
            this.logger.Log(() => $"{this.decorated.GetType().Name}:{DateTime.Now} " + JsonConvert.SerializeObject(data));
            this.decorated.Validate(data);
        }
    }
}
