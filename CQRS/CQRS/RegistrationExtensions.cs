using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public static class RegistrationExtensions
    {
        public static IQueryHandler<TQuery, TResponse> Secured<TQuery, TResponse>(
            this IQueryHandler<TQuery, TResponse> instance)
            where TQuery : IQuery<TResponse>
        {
            return new SecureQueryDecorator<TQuery, TResponse>(instance);
        }
    }
}
