using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public sealed class EnumerableQueryHandlerLoggingDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
        where TResult : IEnumerable
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public EnumerableQueryHandlerLoggingDecorator(
            IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }

        public TResult Handle(TQuery query)
        {
            var result = this.decorated.Handle(query);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            return result;
        }
    }
}
