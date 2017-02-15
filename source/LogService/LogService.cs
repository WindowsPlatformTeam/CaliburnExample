using System;
using System.Collections.Generic;
using System.Linq;
using LoggerService.Contracts;
using Common.ServiceContracts;

namespace LoggerService
{
    public class LogService : ILogService
    {
        private readonly List<ILogger> _loggers;

        public LogService(params ILogger[] loggers)
        {
            if (loggers == null) return;
            _loggers = loggers.ToList();
        }

        public void Log(string message)
        {
            if (_loggers == null) return;
            foreach (var logger in _loggers.FindAll(logger => logger != null))
            {
                logger.Log(message);
            }
        }

        public void LogError(string message)
        {
            if (_loggers == null) return;
            foreach (var logger in _loggers.FindAll(logger => logger != null))
            {
                logger.LogError(message);
            }
        }

        public void LogWarning(string message)
        {
            if (_loggers == null) return;
            foreach (var logger in _loggers.FindAll(logger => logger != null))
            {
                logger.LogWarning(message);
            }
        }

        public void LogDataBase(string message)
        {
            if (_loggers == null) return;
            LogError($"(DB) {message}");
        }

        public void LogException(string message, Exception exeption)
        {
            if (_loggers == null) return;
            LogError(message);
            while (exeption != null)
            {
                LogError(exeption.Message);
                exeption = exeption.InnerException;
            }
        }
    }
}
