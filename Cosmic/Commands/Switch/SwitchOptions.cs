using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Switch
{
    [Verb("switch", HelpText = "Switch to a specific default container.")]
    [Example("switch myaccount/mydatabase/mycontainer", HelpText = "Switch to a specific default container.")]
    public class SwitchOptions
    {
        [Value(1, Required = true, HelpText = "Container path e.g. <connection>/<database>/<container>")]
        public string Path { get; set; }
    }
}
