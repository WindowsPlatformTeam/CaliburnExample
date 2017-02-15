using Caliburn.Micro;
using CaliburnExample.Contracts.Screen1;
using Common.Events;
using Common.ServiceContracts;

namespace CaliburnExample.ViewModels.Screen1
{
    public class Screen1ViewModel : Screen, IScreen1ViewModel
    {
        private readonly ILogService _logService;
        private readonly IEventAggregator _eventAggregator;

        public Screen1ViewModel(ILogService logService, IEventAggregator eventAggregator)
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
