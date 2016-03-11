using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Aspects;

namespace Solid
{
    public class ServiceProvider : IServiceProvider
    {
        private static ILogger logger = new ConsoleLogger();

        public object GetService(Type serviceType)
        {
            var instance = Activator.CreateInstance(serviceType);

            if (typeof(ISingleFieldValidator).IsAssignableFrom(serviceType))
            {
                return new LoggerSingleFieldValidatorDecorator(
                        (ISingleFieldValidator)instance,
                        logger);
            }

            if (typeof(ICrossFieldValidator).IsAssignableFrom(serviceType))
            {
                return new LoggerCrossFieldValidationDecorator(
                        (ICrossFieldValidator)instance,
                        logger);
            }

            if (typeof(IFileReader).IsAssignableFrom(serviceType))
            {
                return new FileReaderLoggerDecorator(
                    (IFileReader)instance, 
                    logger);
            }

            throw new InvalidProgramException();
        }
    }
}
