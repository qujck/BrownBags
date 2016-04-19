using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Queries;

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

        public static IQueryHandler<TQuery, TResponse> WithLogging<TQuery, TResponse>(
            this IQueryHandler<TQuery, TResponse> instance)
            where TQuery : IQuery<TResponse>
        {
            return new QueryHandlerLoggingDecorator<TQuery, TResponse>(instance);
        }

        public static IQueryHandler<TQuery, TResponse> WithExceptionHandler<TQuery, TResponse>(
            this IQueryHandler<TQuery, TResponse> instance)
            where TQuery : IQuery<TResponse>
        {
            return new QueryHandlerExceptionDecorator<TQuery, TResponse>(instance);
        }
    }
}
