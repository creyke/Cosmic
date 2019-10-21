using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Cosmic.Commands.Query
{
    public class QueryCommand : QueryBaseCommand<QueryOptions>
    {
        protected async override Task<int> ExecuteCommandAsync(QueryOptions options)
        {
            var result = await base.ExecuteCommandAsync(options);

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
