using CommandLine;

namespace Cosmic.Commands
{
    public abstract class QueryBaseOptions : OperationOptions
    {
        [Option('q', "output-query", HelpText = "Output query before result.")]
        public bool OutputQuery { get; set; }

        [Value(1, Required = true, HelpText = "Query e.g. \"SELECT * FROM c\"")]
        public string Query { get; set; }

        [Value(2, HelpText = "Default argument e.g 'id'.")]
        public string Value1 { get; set; }

        [Value(3, HelpText = "Default argument e.g 'id'.")]
        public string Value2 { get; set; }

        [Value(4, HelpText = "Default argument e.g 'id'.")]
        public string Value3 { get; set; }

        [Value(5, HelpText = "Default argument e.g 'id'.")]
        public string Value4 { get; set; }

        [Value(6, HelpText = "Default argument e.g 'id'.")]
        public string Value5 { get; set; }

        [Value(7, HelpText = "Default argument e.g 'id'.")]
        public string Value6 { get; set; }

        [Value(8, HelpText = "Default argument e.g 'id'.")]
        public string Value7 { get; set; }

        [Value(9, HelpText = "Default argument e.g 'id'.")]
        public string Value8 { get; set; }

        [Value(10, HelpText = "Default argument e.g 'id'.")]
        public string Value9 { get; set; }
    }
}
