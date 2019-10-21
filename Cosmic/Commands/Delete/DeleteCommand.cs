using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace Cosmic.Commands.Delete
{
    public class DeleteCommand : QueryBaseCommand<DeleteOptions>
    {
        protected async override Task<int> ExecuteCommandAsync(DeleteOptions options)
        {
            await base.ExecuteCommandAsync(options);

            var deleted = 0;

            Console.WriteLine($"Discovered {Docs.Count} documents.");

            foreach (var doc in Docs)
            {
                string id = Convert.ToString(doc["id"]);
                string partitionKeyValue = Convert.ToString(options.PartitionKey is null ? id : doc[options.PartitionKey]);
                var partitionKey = new PartitionKey(Convert.ToString(partitionKeyValue));
                var result = await Container.DeleteItemAsync<object>(id, partitionKey);
                LogRequestCharge(result.RequestCharge);
                if ((int)result.StatusCode >= 200 && (int)result.StatusCode <= 299)
                {
                    deleted++;
                }
            }

            Console.WriteLine($"Deleted {deleted}/{Docs.Count} documents.");

            return 0;
        }
    }
}
