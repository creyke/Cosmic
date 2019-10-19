using System.Threading.Tasks;
using CommandLine;
using Cosmic.Commands.Connect;
using Cosmic.Commands.Delete;
using Cosmic.Commands.Query;

namespace Cosmic
{
    public class Runtime
    {
        public async Task<int> ExecuteAsync(string[] args)
        {
            return await Parser.Default.ParseArguments<ConnectOptions, DeleteOptions, QueryOptions>(args)
                .MapResult(
                  (ConnectOptions o) => new ConnectCommand().ExecuteAsync(o),
                  (DeleteOptions o) => new DeleteCommand().ExecuteAsync(o),
                  (QueryOptions o) => new QueryCommand().ExecuteAsync(o),
                  errs => Task.FromResult(1));
        }
    }
}
