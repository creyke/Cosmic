using Cosmic.Data;
using Cosmic.Extensions;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            string query = null;
            
            if (options.Query.Contains(' '))
            {
                query = options.Query;
            }
            else
            {
                var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                var cosmicDir = appDir.CreateSubdirectory("cosmic");
                var queriesDir = cosmicDir.CreateSubdirectory("queries");
                var queryFile = await File.ReadAllTextAsync($"{queriesDir}/{options.Query}.json");
                var queryData = JsonConvert.DeserializeObject<QueryData>(queryFile);
                query = queryData.Query;
            }

            var parameters = new string[]
            {
                options.Value1, options.Value2, options.Value3,
                options.Value4, options.Value5, options.Value6,
                options.Value7, options.Value8, options.Value9
            };

            parameters
                .TakeWhile(x => x != null)
                .ToList()
                .ForEach(x => { query = query.ReplaceFirst("%%", x); });

            if (options.OutputQuery)
            {
                Console.WriteLine(query);
            }

            var queryDefinition = new QueryDefinition(query);
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
