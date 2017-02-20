using System;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using CaliburnExample.Contracts;
using CaliburnExample.Contracts.Screen1;
using CaliburnExample.Contracts.Screen2;
using Common.Events;
using Common.ServiceContracts;

namespace CaliburnExample.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>, IShell,
        IHandle<NavigateToHomeEvent>, IHandle<NavigateToScreen1Event>, IHandle<NavigateToScreen2Event>
    {
        private readonly IMainPageViewModel _mainPageViewModel;
        private readonly IScreen1ViewModel _screen1ViewModel;
        private readonly IScreen2ViewModel _screen2ViewModel;
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;
        private readonly ILogService _logService;

        public ShellViewModel(IMainPageViewModel mainPageViewModel, IScreen1ViewModel screen1ViewModel, IScreen2ViewModel screen2ViewModel,
            IEventAggregator eventAggregator, IWindowManager windowManager, ILogService logService)
        {
            _mainPageViewModel = mainPageViewModel;
            _screen1ViewModel = screen1ViewModel;
            _screen2ViewModel = screen2ViewModel;
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _logService = logService;
        }

        protected override void OnViewAttached(object view, object context)
        {
            _eventAggregator.Subscribe(this);
            base.OnViewAttached(view, context);
            ActivateItem(_mainPageViewModel as Screen);
            _logService.Log("Main view attached");
        }

        protected override void OnDeactivate(bool close)
        {
            _eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }

        public void Handle(NavigateToScreen2Event message)
        {
            _windowManager.ShowWindow(_screen1ViewModel as Screen);
        }

        public void Handle(NavigateToScreen1Event message)
        {
            ActivateItem(_screen2ViewModel as Screen);
        }

        public void Handle(NavigateToHomeEvent message)
        {
            ActivateItem(_mainPageViewModel as Screen);
        }
    }
}
