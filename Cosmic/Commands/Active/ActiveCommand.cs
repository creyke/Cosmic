using Cosmic.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands.Active
{
    public class ActiveCommand : Command<ActiveOptions>
    {
        protected override async Task<int> ExecuteCommandAsync(ActiveOptions options)
        {
            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");

            var activeContainerFile = $"{cosmicDir}/activeContainer.json";

            if (File.Exists(activeContainerFile))
            {
                var container = JsonConvert.DeserializeObject<ContainerData>(await File.ReadAllTextAsync($"{cosmicDir}/activeContainer.json"));

                Console.WriteLine($"Active on connection '{container.ConnectionId}', database '{container.DatabaseId}', container '{container.ContainerId}'.");
            }
            else
            {
                Console.WriteLine("No active container defined. Use 'switch' command to specify an active container.");
            }

            return 0;
        }
    }
}
