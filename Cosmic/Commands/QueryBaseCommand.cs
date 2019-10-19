using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public abstract class QueryBaseCommand<TOptions> : OperationCommand<TOptions>
        where TOptions : QueryBaseOptions
    {
        protected List<dynamic> Docs { get; private set; }

        public async override Task<int> ExecuteAsync(TOptions options)
        {
            await base.ExecuteAsync(options);

            var queryDefinition = new QueryDefinition(options.Query);
            var queryResultSetIterator = Container.GetItemQueryIterator<dynamic>(queryDefinition);

            Docs = new List<dynamic>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<dynamic> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (dynamic doc in currentResultSet)
                {
                    Docs.Add(doc);
                }
            }

            return 0;
        }
    }
}
