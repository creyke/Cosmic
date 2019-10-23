using Cosmic.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmic.Commands.Store
{
    public class StoreCommand : Command<StoreOptions>
    {
        protected async override Task<int> ExecuteCommandAsync(StoreOptions options)
        {
            DirectoryInfo queriesDir = null;

            if (options.Global)
            {
                var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                var cosmicDir = appDir.CreateSubdirectory("cosmic");
                queriesDir = cosmicDir.CreateSubdirectory("queries");
            }
            else
            {
                queriesDir = new DirectoryInfo(".");
            }

            var parameters = new string[]
            {
                options.Value1, options.Value2, options.Value3,
                options.Value4, options.Value5, options.Value6,
                options.Value7, options.Value8, options.Value9
            };

            var query = new QueryData
            {
                Query = options.Query,
                Parameters = parameters
                    .TakeWhile(x => x != null)
                    .Select(x => new ParameterData
                    {
                        DefaultValue = x
                    })
                    .ToArray()
            };

            await File.WriteAllTextAsync($"{queriesDir}/{options.Name}.json", JsonConvert.SerializeObject(query));

            return 0;
        }
    }
}
