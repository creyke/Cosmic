using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Query
{
    [Verb("query", HelpText = "Query an Azure Cosmos DB container.")]
    [Example("query \"SELECT * FROM c\"", HelpText = "Query an Azure Cosmos DB container.")]
    [Example("query \"SELECT * FROM c\" -q -r", HelpText = "Output query and/or request charges.")]
    [Example("query \"SELECT * FROM c WHERE c.UtcStart > %NOW%\"", HelpText = "Query using supported aliases.")]
    [Example("query \"SELECT * FROM c WHERE c.Size > %% AND c.Vehicle = '%%'\" 3 boat", HelpText = "Query using arguments.")]
    [Example("query myquery", HelpText = "Execute a stored query.")]
    [Example("query myquery 3 boat", HelpText = "Execute a stored query using arguments.")]
    [Example("query -g myquery", HelpText = "Executes query from global store rather than current working directory.")]
    public class QueryOptions : QueryBaseOptions
    {
    }
}
