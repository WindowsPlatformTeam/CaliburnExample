using Caliburn.Micro;
using CaliburnExample.Contracts.Screen2;
using Common.Events;
using Common.ServiceContracts;

namespace CaliburnExample.ViewModels.Screen2
{
    public class Screen2ViewModel : Screen, IScreen2ViewModel
    {
        private readonly ILogService _logService;
        private readonly IEventAggregator _eventAggregator;

        public Screen2ViewModel(ILogService logService, IEventAggregator eventAggregator)
        {
            _logService = logService;
            _eventAggregator = eventAggregator;
        }

        public void GoToHome()
        {
            _eventAggregator.PublishOnUIThread(new NavigateToHomeEvent());
        }
    }
}
