using Common.Contracts;
using LoggerService.Contracts;

namespace LoggerService.Loggers
{
    public class ConsoleLogger : ILogger
    {
        #region Fields
        private readonly IDebugWrapper _debug;
        private readonly IDateTimeWrapper _dateTimeWrapper;

        private const string InfoFormat = "{0} - INFO: {1}";
        private const string ErrorFormat = "{0} - ERROR: {1}";
        private const string WarningFormat = "{0} - WARNING: {1}";

        #endregion

        public ConsoleLogger(IDebugWrapper debug, IDateTimeWrapper dateTimeWrapper)
        {
            _debug = debug;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public void Log(string message)
        {
            _debug.WriteLine(string.Format(InfoFormat, _dateTimeWrapper.GetUtcActualDateTime().ToString("HH:mm:ss"), message));
        }

        public void LogError(string message)
        {
            _debug.WriteLine(string.Format(ErrorFormat, _dateTimeWrapper.GetUtcActualDateTime().ToString("HH:mm:ss"), message));
        }

        public void LogWarning(string message)
        {
            _debug.WriteLine(string.Format(WarningFormat, _dateTimeWrapper.GetUtcActualDateTime().ToString("HH:mm:ss"), message));
        }
    }
}
