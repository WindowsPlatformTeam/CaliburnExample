using System.Diagnostics;
using Common.Exceptions;
using LoggerService.Contracts;

namespace LoggerService.Loggers
{
    public class WindowsLogger : ILogger
    {
        #region Fields

        private readonly IEventLogWrapper _eventLog;

        private string _source = "OBS";
        private string _log = "Application";

        #endregion

        public WindowsLogger(IEventLogWrapper eventLog)
        {
            _eventLog = eventLog;
        }

        public void Log(string message)
        {
            try
            {
                CreateIfNotExist();
                _eventLog.WriteEntry(_source, message, EventLogEntryType.Information);
            }
            catch
            {
                throw new WindowsLogException();
            }
        }

        public void LogError(string message)
        {
            try
            {
                CreateIfNotExist();
                _eventLog.WriteEntry(_source, message, EventLogEntryType.Error);
            }
            catch
            {
                throw new WindowsLogException();
            }
        }

        public void LogWarning(string message)
        {
            try
            {
                CreateIfNotExist();
                _eventLog.WriteEntry(_source, message, EventLogEntryType.Warning);
            }
            catch
            {
                throw new WindowsLogException();
            }
        }

        private void CreateIfNotExist()
        {
            if (!_eventLog.SourceExists(_source))
            {
                _eventLog.CreateEventSource(_source, _log);
            }
        }
    }
}
