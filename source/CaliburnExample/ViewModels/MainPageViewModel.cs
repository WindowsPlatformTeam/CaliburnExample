using System;
using System.Globalization;
using Caliburn.Micro;
using CaliburnExample.Contracts;
using Common.Events;
using Common.ServiceContracts;

namespace CaliburnExample.ViewModels
{
    public class MainPageViewModel : Screen, IMainPageViewModel
    {
        private readonly ILogService _logService;
        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(ILogService logService, IEventAggregator eventAggregator)
        {
            _logService = logService;
            _eventAggregator = eventAggregator;
        }

        public string Date => DateTime.Now.Date.ToString(CultureInfo.InvariantCulture);

        public void GoToThePage1()
        {
            _logService.Log($"Execution GoToThePage1");
            _eventAggregator.BeginPublishOnUIThread(new NavigateToScreen1Event());
        }

        public void GoToThePage2()
        {
            _logService.Log($"Execution GoToThePage2");
            _eventAggregator.BeginPublishOnUIThread(new NavigateToScreen2Event());
        }
    }
}
