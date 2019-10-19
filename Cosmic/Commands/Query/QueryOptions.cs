using CommandLine;

namespace Cosmic.Commands.Query
{
    [Verb("query", HelpText = "Query an Azure Cosmos DB account.")]
    public class QueryOptions : BaseOptions
    {
        [Value(2, Required = true, HelpText = "Query e.g. \"SELECT * FROM c\"")]
        public string Query { get; set; }
    }
}
