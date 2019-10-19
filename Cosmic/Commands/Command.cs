using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public abstract class Command<TOptions>
    {
        public abstract Task<int> ExecuteAsync(TOptions options);
    }
}
