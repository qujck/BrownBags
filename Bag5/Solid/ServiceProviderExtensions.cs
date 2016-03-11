using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public static class ServiceProviderExtensions
    {
        public static TService GetService<TService, TImplementation>(this IServiceProvider serviceProvider)
            where TImplementation : TService
        {
            return (TService)serviceProvider.GetService(typeof(TImplementation));
        }
    }
}
