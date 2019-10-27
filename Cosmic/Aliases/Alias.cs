using System;

namespace Cosmic.Aliases
{
    public abstract class Alias
    {
        public string Key { get; }
        public abstract string Description { get; }

        public Alias()
        {
            Key = $"%{GetType().Name.ToUpperInvariant().Replace(nameof(Alias).ToUpperInvariant(), string.Empty)}%";
        }

        public abstract string Generate(DateTime utcNow);
    }
}
