using CommandLine;

namespace Cosmic.Commands
{
    public abstract class BaseOptions
    {
        [Value(1, Required = true, HelpText = "Container path e.g. <connection>/<database>/<container>")]
        public string Path { get; set; }
    }
}