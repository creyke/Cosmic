using Cosmic.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands.Connect
{
    public class ConnectCommand : Command<ConnectOptions>
    {
        public async override Task<int> ExecuteAsync(ConnectOptions options)
        {
            var connection = new Connection
            {
                ConnectionString = options.ConnectionString
            };

            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");
            var connectionsDir = cosmicDir.CreateSubdirectory("connections");

            await File.WriteAllTextAsync($"{connectionsDir}/{options.Name.ToLowerInvariant()}.json", JsonConvert.SerializeObject(connection));

            return 0;
        }
    }
}
