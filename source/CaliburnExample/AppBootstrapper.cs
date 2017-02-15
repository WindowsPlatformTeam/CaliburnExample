using System;
using System.Threading;
using Autofac;
using Caliburn.Micro;
using CaliburnExample.Contracts;
using CaliburnExample.Views;
using Common.Contracts;
using Common.ServiceContracts;
using Common.Wrappers;
using LoggerService;

namespace CaliburnExample
{
    public class AppBootstrapper : BootstrapperBase
    {
        IContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();

            LogBootstrapper.RegisterTypes(builder);
            builder.RegisterType<LogService>().As<ILogService>().SingleInstance();

            builder.RegisterType<DateTimeWrapper>().As<IDateTimeWrapper>().SingleInstance();

            _container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.Resolve(service);
            if (instance != null)
            {
                return instance;
            }
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
        }
    }
}