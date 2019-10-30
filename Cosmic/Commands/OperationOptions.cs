using CommandLine;

namespace Cosmic.Commands
{
    public abstract class OperationOptions
    {
        [Option('c', "container-path", HelpText = "Container path e.g. <connection>/<database>/<container>")]
        public string ContainerPath { get; set; }

        [Option('r', "output-request-charge", HelpText = "Output request charge (in RUs).")]
        public bool OutputRequestCharge { get; set; }

        [Option('l', "loop", Default = 1, HelpText = "Loops this operation multiple specified times with %I% as the iterator.")]
        public int Loop { get; set; }
    }
}