using Cosmic.Extensions;
using System;

namespace Cosmic.Aliases
{
    public class TodayAlias : Alias
    {
        public override string Description => "The time at which the current day commenced (in UTC).";

        public override string Generate(DateTime utcNow, int iterator)
        {
            return new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0, DateTimeKind.Utc).ToStringCosmos();
        }
    }
}
