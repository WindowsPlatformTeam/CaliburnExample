using Caliburn.Micro;
using CaliburnExample.Contracts.Screen2;
using Common.Events;
using Common.ServiceContracts;
using FooService;

namespace CaliburnExample.ViewModels.Screen2
{
    public class Screen2ViewModel : Screen, IScreen2ViewModel
    {
        private readonly IFooService _fooService;
        private readonly ILogService _logService;
        private readonly IEventAggregator _eventAggregator;

        public Screen2ViewModel(IFooService fooService, ILogService logService, IEventAggregator eventAggregator)
        {
            _fooService = fooService;
            _logService = logService;
            _eventAggregator = eventAggregator;
        }

        public void GoToHome()
        {
            _eventAggregator.PublishOnUIThread(new NavigateToHomeEvent());
        }

        public void Foo()
        {
            _fooService.DoSomething();
        }
    }
}
