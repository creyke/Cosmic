using Cosmic.Extensions;
using System;

namespace Cosmic.Aliases
{
    public class Last_WeekAlias : Alias
    {
        public override string Description => "The time at which the previous week commenced (in UTC).";

        public override string Generate(DateTime utcNow, int iterator)
        {
            var yesterday = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0, DateTimeKind.Utc).AddDays(-1);
            return yesterday.AddDays(-(int)yesterday.DayOfWeek + 1).AddDays(-7).ToStringCosmos();
        }
    }
}
