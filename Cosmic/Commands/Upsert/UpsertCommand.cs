using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmic.Commands.Upsert
{
    public class UpsertCommand : OperationCommand<UpsertOptions>
    {
        public async override Task<int> ExecuteAsync(UpsertOptions options)
        {
            await base.ExecuteAsync(options);

            var loaded = 0;

            var docs = options.File != null
                ? (await File.ReadAllLinesAsync(options.File))
                    .Select(x => JsonConvert.DeserializeObject(x))
                : new object[] { JsonConvert.DeserializeObject<object>(options.Documents) };

            var count = docs.Count();

            Console.WriteLine($"Upserting {count} documents.");
            
            foreach (var doc in docs)
            {
                var result = await Container.UpsertItemAsync(doc);
                if ((int)result.StatusCode >= 200 && (int)result.StatusCode <= 299)
                {
                    loaded++;
                }
            }

            Console.WriteLine($"Upserted {loaded}/{count} documents.");

            return 0;
        }
    }
}
