using System.Diagnostics;
using LoggerService.Contracts;

namespace LoggerService.Wrappers
{
    public class EventLogWrapper : IEventLogWrapper
    {
        public void WriteEntry(string source, string log, EventLogEntryType type)
        {
            EventLog.WriteEntry(source, log, type);
        }
        public bool SourceExists(string source)
        {
            return EventLog.SourceExists(source);
        }

        public void CreateEventSource(string source, string log)
        {
            EventLog.CreateEventSource(source, log);
        }
    }
}
