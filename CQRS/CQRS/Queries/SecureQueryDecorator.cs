using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries
{
    public sealed class SecureQueryDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public SecureQueryDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }

        public TResult Handle(TQuery query)
        {
            if (System.Security.Principal.WindowsIdentity.GetCurrent().Name != "parkerp")
            {
                throw new AccessViolationException();
            }
            else if (query.GetType().Name != "ReadAddress")
            {
                throw new UnauthorizedAccessException();
            }
            else
            {
                return this.decorated.Handle(query);
            }
        }
    }
}