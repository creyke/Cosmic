using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public interface ICommand<TOptions>
    {
        Task<int> ExecuteAsync(TOptions options);
    }
}
