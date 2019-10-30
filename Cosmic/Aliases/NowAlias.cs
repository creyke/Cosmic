using Cosmic.Extensions;
using System;

namespace Cosmic.Aliases
{
    public class NowAlias : Alias
    {
        public override string Description => "The current time (in UTC).";

        public override string Generate(DateTime utcNow, int iterator)
        {
            return utcNow.ToStringCosmos();
        }
    }
}
