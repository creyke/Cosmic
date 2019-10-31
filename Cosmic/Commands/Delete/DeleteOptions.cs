using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Delete
{
    [Verb("delete", HelpText = "Delete documents from an Azure Cosmos DB container based on a query.")]
    [Example("delete \"SELECT * FROM c\"", HelpText = "Delete documents from an Azure Cosmos DB container based on a query.")]
    [Example("delete \"SELECT * FROM c\" -p Tenant", HelpText = "Delete with a non-id partition key.")]
    public class DeleteOptions : QueryBaseOptions
    {
        [Option('p', "partition-key", Default = "id", Required = false, HelpText = "Partition key of container e.g. 'id'")]
        public string PartitionKey { get; set; }
    }
}
