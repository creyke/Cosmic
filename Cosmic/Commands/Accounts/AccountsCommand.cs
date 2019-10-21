using Cosmic.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmic.Commands.Accounts
{
    public class AccountsCommand : Command<AccountsOptions>
    {
        protected async override Task<int> ExecuteCommandAsync(AccountsOptions options)
        {
            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");
            var connectionsDir = cosmicDir.CreateSubdirectory("connections");

            var activeContainerFile = new FileInfo($"{cosmicDir}/activeContainer.json");
            ContainerData activeContainerData = null;

            if (activeContainerFile.Exists)
            {
                activeContainerData = JsonConvert.DeserializeObject<ContainerData>(await File.ReadAllTextAsync(activeContainerFile.FullName));
            }

            bool isActive(string connectionId)
            {
                return activeContainerData != null && activeContainerData.ConnectionId.ToLowerInvariant() == connectionId.ToLowerInvariant();
            }

            connectionsDir.GetFiles()
                .Where(x => x.Extension.ToLowerInvariant() == ".json")
                .ToDictionary(x => x.Name.Split('.').First(), x => JsonConvert.DeserializeObject<ConnectionData>(File.ReadAllText(x.FullName)))
                .ToList()
                .ForEach(x => Console.WriteLine($"{(isActive(x.Key) ? '*' : ' ')} {x.Key.PadRight(20)} {x.Value.ConnectionString.Substring(0, x.Value.ConnectionString.LastIndexOf("AccountKey")).TrimEnd(';')}"));

            return 0;
        }
    }
}
