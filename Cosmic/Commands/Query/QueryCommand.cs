using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Cosmic.Commands.Query
{
    public class QueryCommand : QueryBaseCommand<QueryOptions>
    {
        public async override Task<int> ExecuteAsync(QueryOptions options)
        {
            var result = await base.ExecuteAsync(options);

            if (result != 0)
            {
                return result;
            }

            foreach (var doc in Docs)
            {
                Console.WriteLine(JsonConvert.SerializeObject(doc));
            }

            return 0;
        }
    }
}
