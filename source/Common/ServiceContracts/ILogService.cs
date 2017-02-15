using System;

namespace Common.ServiceContracts
{
    public interface ILogService
    {
        void Log(string message);
        void LogError(string message);
        void LogException(string message, Exception exeption);
        void LogWarning(string message);
        void LogDataBase(string message);
    }
}
