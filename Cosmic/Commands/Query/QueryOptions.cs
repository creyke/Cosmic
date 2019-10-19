using CommandLine;

namespace Cosmic.Commands.Query
{
    [Verb("query", HelpText = "Query an Azure Cosmos DB account.")]
    public class QueryOptions : QueryBaseOptions
    {
    }
}
