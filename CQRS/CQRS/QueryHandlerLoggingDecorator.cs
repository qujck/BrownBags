using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQRS
{
    public sealed class QueryHandlerLoggingDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
        where TResult : IEnumerable
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public QueryHandlerLoggingDecorator(
            IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }

        public TResult Handle(TQuery query)
        {
            var result = this.decorated.Handle(query);

            Console.WriteLine(JsonConvert.SerializeObject(result));

            return result;
        }
    }
}
