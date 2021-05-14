using System;

namespace LiteSmallConference.Domain
{
    public class AppTime
    {
        public static Func<DateTime> CurrentTimeProvider
        { get; set; } = () => DateTime.Now;

        public static DateTime Now() => CurrentTimeProvider();
    }
}
