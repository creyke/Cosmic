using CommandLine;

namespace Cosmic.Commands.Delete
{
    [Verb("delete", HelpText = "Delete documents from an Azure Cosmos DB container based on a query.")]
    public class DeleteOptions : QueryBaseOptions
    {
        [Option('p', "partition-key", Default = "id", Required = false, HelpText = "Partition key of container e.g. 'id'")]
        public string PartitionKey { get; set; }
    }
}
