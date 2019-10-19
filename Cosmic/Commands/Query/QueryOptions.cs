using CommandLine;

namespace Cosmic.Commands.Query
{
    [Verb("query", HelpText = "Query an Azure Cosmos DB container.")]
    public class QueryOptions : QueryBaseOptions
    {
    }
}
