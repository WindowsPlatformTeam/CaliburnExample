using System;
using Autofac;
using Caliburn.Micro;
using CaliburnExample.Contracts;
using CaliburnExample.Contracts.Screen1;
using CaliburnExample.Contracts.Screen2;
using CaliburnExample.ViewModels;
using CaliburnExample.ViewModels.Screen1;
using CaliburnExample.ViewModels.Screen2;
using Common.Contracts;
using Common.ServiceContracts;
using Common.Wrappers;
using LoggerService;

namespace CaliburnExample
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            // Basic 
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();

            // ViewModels
            builder.RegisterType<ShellViewModel>().As<IShell>().SingleInstance();
            builder.RegisterType<MainPageViewModel>().As<IMainPageViewModel>().SingleInstance();
            builder.RegisterType<Screen1ViewModel>().As<IScreen1ViewModel>().SingleInstance();
            builder.RegisterType<Screen2ViewModel>().As<IScreen2ViewModel>().SingleInstance();

            // Services
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
            DisplayRootViewFor<IShell>();
        }
    }
}