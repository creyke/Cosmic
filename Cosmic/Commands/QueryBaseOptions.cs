using CommandLine;

namespace Cosmic.Commands
{
    public abstract class QueryBaseOptions : OperationOptions
    {
        [Value(1, Required = true, HelpText = "Query e.g. \"SELECT * FROM c\"")]
        public string Query { get; set; }
    }
}
