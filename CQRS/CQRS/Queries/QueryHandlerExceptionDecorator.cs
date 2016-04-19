using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQRS.Queries
{
    public sealed class QueryHandlerExceptionDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public QueryHandlerExceptionDecorator(
            IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }

        public TResult Handle(TQuery query)
        {
            try
            {
                return this.decorated.Handle(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                throw;
            }
        }
    }
}
