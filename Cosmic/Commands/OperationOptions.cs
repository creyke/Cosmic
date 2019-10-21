using CommandLine;

namespace Cosmic.Commands
{
    public abstract class OperationOptions
    {
        [Option('c', "container-path", HelpText = "Container path e.g. <connection>/<database>/<container>")]
        public string ContainerPath { get; set; }
    }
}