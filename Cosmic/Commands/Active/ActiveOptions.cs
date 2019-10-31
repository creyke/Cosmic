using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Active
{
    [Verb("active", HelpText = "Output the current active container.")]
    [Example("active", HelpText = "Output the current active container.")]
    public class ActiveOptions
    {
    }
}
