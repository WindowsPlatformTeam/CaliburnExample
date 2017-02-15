using System;
using Caliburn.Micro;
using CaliburnExample.Contracts;
using CaliburnExample.Contracts.Screen1;
using CaliburnExample.Contracts.Screen2;
using Common.Events;

namespace CaliburnExample.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>, IShell,
        IHandle<NavigateToHomeEvent>, IHandle<NavigateToScreen1Event>, IHandle<NavigateToScreen2Event>
    {
        private readonly IMainPageViewModel _mainPageViewModel;
        private readonly IScreen1ViewModel _screen1ViewModel;
        private readonly IScreen2ViewModel _screen2ViewModel;

        public ShellViewModel(IMainPageViewModel mainPageViewModel, IScreen1ViewModel screen1ViewModel, IScreen2ViewModel screen2ViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
            _screen1ViewModel = screen1ViewModel;
            _screen2ViewModel = screen2ViewModel;
        }

        public void Handle(NavigateToScreen2Event message)
        {
            ActivateItem(_screen1ViewModel as Screen);
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
