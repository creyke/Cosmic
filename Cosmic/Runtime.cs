using System.Threading.Tasks;
using CommandLine;
using Cosmic.Commands.Active;
using Cosmic.Commands.Connect;
using Cosmic.Commands.Delete;
using Cosmic.Commands.Query;
using Cosmic.Commands.Switch;
using Cosmic.Commands.Upsert;

namespace Cosmic
{
    public class Runtime
    {
        public async Task<int> ExecuteAsync(string[] args)
        {
            return await Parser.Default.ParseArguments<ActiveOptions, ConnectOptions, DeleteOptions, QueryOptions, SwitchOptions, UpsertOptions>(args)
                .MapResult(
                  (ActiveOptions o) => new ActiveCommand().ExecuteAsync(o),
                  (ConnectOptions o) => new ConnectCommand().ExecuteAsync(o),
                  (DeleteOptions o) => new DeleteCommand().ExecuteAsync(o),
                  (QueryOptions o) => new QueryCommand().ExecuteAsync(o),
                  (SwitchOptions o) => new SwitchCommand().ExecuteAsync(o),
                  (UpsertOptions o) => new UpsertCommand().ExecuteAsync(o),
                  errs => Task.FromResult(1));
        }
    }
}
