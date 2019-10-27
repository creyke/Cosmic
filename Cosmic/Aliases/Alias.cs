using System;

namespace Cosmic.Aliases
{
    public abstract class Alias
    {
        public string Key { get; }
        public abstract string Description { get; }

        public Alias()
        {
            Key = $"%{GetType().Name.Replace(nameof(Alias), string.Empty)}%";
        }

        public abstract string Generate(DateTime utcNow);
    }
}
