using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Store
{
    [Verb("store", HelpText = "Stores a query for later.")]
    [Example("store -n myquery \"SELECT * FROM c\"", HelpText = "Stores a query for later.")]
    [Example("store -n myquery \"SELECT * FROM c WHERE c.Size > %% AND c.Vehicle = '%%'\" 3 boat", HelpText = "Stores a parametisable query for later.")]
    [Example("store -n -g myquery \"SELECT * FROM c\"", HelpText = "Stores query in global store rather than current working directory.")]
    public class StoreOptions
    {
        [Option('n', "name", Required = true, HelpText = "A unique name for this query.")]
        public string Name { get; set; }

        [Option('g', "global", HelpText = "Store queries in global store.")]
        public bool Global { get; set; }

        [Value(1, Required = true, HelpText = "Query e.g. \"SELECT * FROM c\"")]
        public string Query { get; set; }

        [Value(2, HelpText = "Default parameter value e.g 'id'.")]
        public string Value1 { get; set; }

        [Value(3, HelpText = "Default parameter value e.g 'id'.")]
        public string Value2 { get; set; }

        [Value(4, HelpText = "Default parameter value e.g 'id'.")]
        public string Value3 { get; set; }

        [Value(5, HelpText = "Default parameter value e.g 'id'.")]
        public string Value4 { get; set; }

        [Value(6, HelpText = "Default parameter value e.g 'id'.")]
        public string Value5 { get; set; }

        [Value(7, HelpText = "Default parameter value e.g 'id'.")]
        public string Value6 { get; set; }

        [Value(8, HelpText = "Default parameter value e.g 'id'.")]
        public string Value7 { get; set; }

        [Value(9, HelpText = "Default parameter value e.g 'id'.")]
        public string Value8 { get; set; }

        [Value(10, HelpText = "Default parameter value e.g 'id'.")]
        public string Value9 { get; set; }
    }
}