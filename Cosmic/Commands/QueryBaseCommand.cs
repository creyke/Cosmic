using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public abstract class QueryBaseCommand<TOptions> : OperationCommand<TOptions>
        where TOptions : QueryBaseOptions
    {
        protected List<dynamic> Docs { get; private set; }

        protected async override Task<int> ExecuteCommandAsync(TOptions options)
        {
            await base.ExecuteCommandAsync(options);

            if (!options.Query.Contains(' '))
            {
                Console.WriteLine("Query appears malformed. Consider surrounding with apostrophes.");
                return 1;
            }

            var queryDefinition = new QueryDefinition(options.Query);
            var queryResultSetIterator = Container.GetItemQueryIterator<dynamic>(queryDefinition);

            Docs = new List<dynamic>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                LogRequestCharge(currentResultSet.RequestCharge);
                foreach (dynamic doc in currentResultSet)
                {
                    Docs.Add(doc);
                }
            }

            return 0;
        }
    }
}
