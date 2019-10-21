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
            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");

            ContainerData containerData = null; 

            if (options.ContainerPath is null)
            {
                var activeContainerFile = await File.ReadAllTextAsync($"{cosmicDir}/activeContainer.json");
                containerData = JsonConvert.DeserializeObject<ContainerData>(activeContainerFile);
            }
            else
            {
                var path = options.ContainerPath.Split('/');
                containerData = new ContainerData
                {
                    ConnectionId = path[0].ToLowerInvariant(),
                    DatabaseId = path[1],
                    ContainerId = path[2]
                };
            }

            var connectionsDir = cosmicDir.CreateSubdirectory("connections");
            var connectionFile = await File.ReadAllTextAsync($"{connectionsDir}/{containerData.ConnectionId}.json");
            var connection = JsonConvert.DeserializeObject<ConnectionData>(connectionFile);

            Container = new CosmosClient(connection.ConnectionString)
                .GetDatabase(containerData.DatabaseId)
                .GetContainer(containerData.ContainerId);

            return 0;
        }
    }
}
