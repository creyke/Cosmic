using Cosmic.Extensions;
using System;

namespace Cosmic.Aliases
{
    public class Next_Week_EndAlias : Alias
    {
        public override string Description => "The time at which the subsequent week will end (in UTC).";

        public override string Generate(DateTime utcNow)
        {
            var yesterday = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0, DateTimeKind.Utc).AddDays(-1);
            return yesterday.AddDays(-(int)yesterday.DayOfWeek + 1).AddDays(14).ToStringCosmos();
        }
    }
}
