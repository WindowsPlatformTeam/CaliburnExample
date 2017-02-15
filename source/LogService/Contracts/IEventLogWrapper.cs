using System.Diagnostics;

namespace LoggerService.Contracts
{
    public interface IEventLogWrapper
    {
        void WriteEntry(string source, string log, EventLogEntryType type);
        bool SourceExists(string source);
        void CreateEventSource(string source, string log);
    }
}
