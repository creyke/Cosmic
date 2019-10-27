using System.Threading.Tasks;

namespace Cosmic.Commands.Aliases
{
    public class AliasesCommand : Command<AliasesOptions>
    {
        protected override Task<int> ExecuteCommandAsync(AliasesOptions options)
        {
            return Task.FromResult(0);
        }
    }
}
