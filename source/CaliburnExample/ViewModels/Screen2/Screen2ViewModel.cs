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
        private readonly IFooService _fooService;

<<<<<<< Updated upstream
        public Screen2ViewModel(IFooService fooService, ILogService logService, IEventAggregator eventAggregator)
=======
        public Screen2ViewModel(ILogService logService, IEventAggregator eventAggregator, IFooService fooService)
>>>>>>> Stashed changes
        {
            _fooService = fooService;
            _logService = logService;
            _eventAggregator = eventAggregator;
            _fooService = fooService;
        }

        public void GoToHome()
        {
            _eventAggregator.PublishOnUIThread(new NavigateToHomeEvent());
        }

<<<<<<< Updated upstream
        public void Foo()
=======
        public void CallFoo(object o)
>>>>>>> Stashed changes
        {
            _fooService.DoSomething();
        }
    }
}
