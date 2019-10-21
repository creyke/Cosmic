using CommandLine;

namespace Cosmic.Commands.Store
{
    [Verb("store", HelpText = "Stores a query for later.")]
    public class StoreOptions
    {
        [Option('n', "name", Required = true, HelpText = "A unique name for this query.")]
        public string Name { get; set; }

        [Value(1, Required = true, HelpText = "Query e.g. \"SELECT * FROM c\"")]
        public string Query { get; set; }
    }
}