using Cosmic.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands.Switch
{
    public class SwitchCommand : Command<SwitchOptions>
    {
        public async override Task<int> ExecuteAsync(SwitchOptions options)
        {
            var path = options.Path.Split('/');

            if (path.Length != 3)
            {
                throw new Exception("Path should be in the format '<connection>/<database>/<container>'.");
            }

            var connectionId = path[0].ToLowerInvariant();

            var container = new ContainerData
            {
                ConnectionId = connectionId,
                DatabaseId = path[1],
                ContainerId = path[2]
            };

            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");

            await File.WriteAllTextAsync($"{cosmicDir}/activeContainer.json", JsonConvert.SerializeObject(container));

            Console.WriteLine($"Switched to connection '{container.ConnectionId}', database '{container.DatabaseId}', container '{container.ContainerId}'.");

            return 0;
        }
    }
}
