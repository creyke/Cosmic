using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Aliases
{
    [Verb("aliases", HelpText = "List query aliases for common functions.")]
    [Example("aliases", HelpText = "List query aliases for common functions.")]
    public class AliasesOptions
    {
    }
}
