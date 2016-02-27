using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class ServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            var instance = Activator.CreateInstance(serviceType);
            return instance;
        }
    }
}
