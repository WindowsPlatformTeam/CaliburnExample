using System;
using Common.Contracts;

namespace Common.Wrappers
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime GetUtcActualDateTime()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetLocalActualDateTime()
        {
            return DateTime.Now;
        }

        public DateTime GetInitUtcActualDateTime()
        {
            var dateTime = new DateTime(1754,1,1);
            return dateTime.ToUniversalTime();
        }

        public DateTime GetToday()
        {
            return DateTime.Today;
        }

        public DateTime GetUtcToday()
        {
            return DateTime.Today.ToUniversalTime();
        }

        public DateTime CreateNew(int year, int month, int day, int hour, int minutes, int seconds)
        {
            var local = new DateTime(year, month, day, hour, minutes, seconds);
            return local.ToUniversalTime();
        }
    }
}
