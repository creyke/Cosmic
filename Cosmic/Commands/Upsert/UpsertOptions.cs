using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Upsert
{
    [Verb("upsert", HelpText = "Load data into an Azure Cosmos DB container.")]
    [Example("upsert \"{'id':'0'}\"", HelpText = "Load document into an Azure Cosmos DB container.")]
    [Example("upsert -f mydocs.json", HelpText = "Load documents from file.")]
    [Example("upsert \"{'id':'%I%'}\" -l 3", HelpText = "Loop and load 3 documents.")]
    public class UpsertOptions : OperationOptions
    {
        [Option('d', "output-document", HelpText = "Output document before result.")]
        public bool OutputDocument { get; set; }

        [Option('f', "file", HelpText = "File e.g. 'data.json'")]
        public string File { get; set; }

        [Value(1, HelpText = "One or more json documents e.g. '{\'id\':\'foo\'}'.")]
        public string Documents { get; set; }

        [Value(2, HelpText = "Query parameter e.g 'id'.")]
        public string Value1 { get; set; }

        [Value(3, HelpText = "Query parameter e.g 'id'.")]
        public string Value2 { get; set; }

        [Value(4, HelpText = "Query parameter e.g 'id'.")]
        public string Value3 { get; set; }

        [Value(5, HelpText = "Query parameter e.g 'id'.")]
        public string Value4 { get; set; }

        [Value(6, HelpText = "Query parameter e.g 'id'.")]
        public string Value5 { get; set; }

        [Value(7, HelpText = "Query parameter e.g 'id'.")]
        public string Value6 { get; set; }

        [Value(8, HelpText = "Query parameter e.g 'id'.")]
        public string Value7 { get; set; }

        [Value(9, HelpText = "Query parameter e.g 'id'.")]
        public string Value8 { get; set; }

        [Value(10, HelpText = "Query parameter e.g 'id'.")]
        public string Value9 { get; set; }
    }
}
