using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmic.Commands.Load
{
    public class LoadCommand : OperationCommand<LoadOptions>
    {
        public async override Task<int> ExecuteAsync(LoadOptions options)
        {
            await base.ExecuteAsync(options);

            var loaded = 0;

            var file = await File.ReadAllLinesAsync(options.File);

            Console.WriteLine($"Loading {file.Length} documents.");

            foreach (var line in file)
            {
                var doc = JsonConvert.DeserializeObject(line);

                var result = await Container.UpsertItemAsync(doc);
                if ((int)result.StatusCode >= 200 && (int)result.StatusCode <= 299)
                {
                    loaded++;
                }
            }

            Console.WriteLine($"Loaded {loaded}/{file.Length} documents.");

            return 0;
        }
    }
}
