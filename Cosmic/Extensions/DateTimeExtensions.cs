using System;
using System.Globalization;

namespace Cosmic.Extensions
{
    static class DateTimeExtensions
    {
        public static string ToStringCosmos(this DateTime dateTime)
        {
            return $"'{dateTime.ToString("o", CultureInfo.InvariantCulture)}'";
        }
    }
}
