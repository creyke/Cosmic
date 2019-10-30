using System;

namespace Cosmic.Aliases
{
    public class IAlias : Alias
    {
        public override string Description => "Iterator variable.";

        public override string Generate(DateTime utcNow, int iterator)
        {
            return iterator.ToString();
        }
    }
}
