using System;

namespace Common.Contracts
{
    public interface IDateTimeWrapper
    {
        DateTime GetUtcActualDateTime();
        DateTime GetLocalActualDateTime();
        DateTime GetInitUtcActualDateTime();
        DateTime GetToday();
        DateTime GetUtcToday();
        DateTime CreateNew(int year, int month, int day, int hour, int minutes, int seconds);
    }
}