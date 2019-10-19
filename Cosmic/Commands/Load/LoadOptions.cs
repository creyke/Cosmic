using CommandLine;

namespace Cosmic.Commands.Load
{
    [Verb("load", HelpText = "Loads data into an Azure Cosmos DB container.")]
    public class LoadOptions : OperationOptions
    {
        [Value(2, Required = true, HelpText = "File e.g. 'data.json'")]
        public string File { get; set; }
    }
}
