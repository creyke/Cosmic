using Cosmic.Data;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public abstract class OperationCommand<TOptions> : Command<TOptions>
        where TOptions : OperationOptions
    {
        protected Container Container { get; private set; }

        public async override Task<int> ExecuteAsync(TOptions options)
        {
            var path = options.Path.Split('/');

            var connectionId = path[0].ToLowerInvariant();

            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");
            var connectionsDir = cosmicDir.CreateSubdirectory("connections");
            var connectionFile = await File.ReadAllTextAsync($"{connectionsDir}/{connectionId}.json");
            var connection = JsonConvert.DeserializeObject<ConnectionData>(connectionFile);

            Container = new CosmosClient(connection.ConnectionString)
                .GetDatabase(path[1])
                .GetContainer(path[2]);

            return 0;
        }
    }
}
