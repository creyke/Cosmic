using Cosmic.Data;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands.Query
{
    public class QueryCommand : ICommand<QueryOptions>
    {
        public async Task<int> ExecuteAsync(QueryOptions options)
        {
            var path = options.Path.Split('/');

            var connectionId = path[0].ToLowerInvariant();

            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");
            var connectionsDir = cosmicDir.CreateSubdirectory("connections");
            var connectionFile = await File.ReadAllTextAsync($"{connectionsDir}/{connectionId}.json");
            var connection = JsonConvert.DeserializeObject<Connection>(connectionFile);

            var container = new CosmosClient(connection.ConnectionString)
                .GetDatabase(path[1])
                .GetContainer(path[2]);

            var queryDefinition = new QueryDefinition(options.Query);
            var queryResultSetIterator = container.GetItemQueryIterator<dynamic>(queryDefinition);

            var docs = new List<dynamic>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<dynamic> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (dynamic doc in currentResultSet)
                {
                    docs.Add(doc);
                }
            }

            foreach (var doc in docs)
            {
                Console.WriteLine(JsonConvert.SerializeObject(doc));
            }

            return 0;
        }
    }
}
