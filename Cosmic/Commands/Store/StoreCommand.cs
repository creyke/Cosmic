using Cosmic.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands.Store
{
    public class StoreCommand : Command<StoreOptions>
    {
        protected async override Task<int> ExecuteCommandAsync(StoreOptions options)
        {
            var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var cosmicDir = appDir.CreateSubdirectory("cosmic");
            var queriesDir = cosmicDir.CreateSubdirectory("queries");

            var query = new QueryData
            {
                Query = options.Query
            };

            await File.WriteAllTextAsync($"{queriesDir}/{options.Name}.json", JsonConvert.SerializeObject(query));

            return 0;
        }
    }
}
