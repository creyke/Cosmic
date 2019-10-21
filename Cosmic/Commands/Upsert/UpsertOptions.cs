using CommandLine;

namespace Cosmic.Commands.Upsert
{
    [Verb("upsert", HelpText = "Load data into an Azure Cosmos DB container.")]
    public class UpsertOptions : OperationOptions
    {
        [Option('f', "file", HelpText = "File e.g. 'data.json'")]
        public string File { get; set; }

        [Value(2, HelpText = "One or more json documents e.g. '{\'id\':\'foo\'}'.")]
        public string Documents { get; set; }
    }
}
