using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Popthatpill.ViewModels
{
    public class PrismSiteViewModel : BindableBase

    {
        private INavigationService _navigationService;

        public DelegateCommand returnCommand { get; private set; }

        public PrismSiteViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            returnCommand = new DelegateCommand(returnMainMenu);
        }

        private async void returnMainMenu()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
