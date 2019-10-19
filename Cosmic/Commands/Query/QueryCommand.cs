using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Cosmic.Commands.Query
{
    public class QueryCommand : QueryBaseCommand<QueryOptions>
    {
        public async override Task<int> ExecuteAsync(QueryOptions options)
        {
            await base.ExecuteAsync(options);

            foreach (var doc in Docs)
            {
                Console.WriteLine(JsonConvert.SerializeObject(doc));
            }

            return 0;
        }
    }
}
