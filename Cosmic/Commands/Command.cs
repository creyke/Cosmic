using System;
using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public abstract class Command<TOptions> : ICommand
    {
        public virtual async Task<int> ExecuteAsync(TOptions options)
        {
            await ExecuteBeforeAsync(options);
            await ExecuteCommandAsync(options);
            await ExecuteAfterAsync(options);
            return 0;
        }

        protected virtual Task ExecuteBeforeAsync(TOptions options)
        {
            return Task.CompletedTask;
        }

        protected abstract Task<int> ExecuteCommandAsync(TOptions options);

        protected virtual Task ExecuteAfterAsync(TOptions options)
        {
            return Task.CompletedTask;
        }
    }
}
