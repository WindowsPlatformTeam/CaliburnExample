using Autofac;
using LoggerService.Contracts;
using LoggerService.Loggers;
using LoggerService.Wrappers;

namespace LoggerService
{
    public static class LogBootstrapper
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<DebugWrapper>().As<IDebugWrapper>();
            builder.RegisterType<EventLogWrapper>().As<IEventLogWrapper>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
        }
    }
}
