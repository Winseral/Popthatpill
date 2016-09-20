using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Popthatpill.ViewModels
{
    public class PBSWebsiteViewModel : BindableBase
    {
        INavigationService _navigationService;

        public DelegateCommand returnCommand { get; private set; }

        public PBSWebsiteViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            returnCommand = new DelegateCommand(returnMainMenu);
        }

        public async void returnMainMenu()
        {

            await _navigationService.GoBackAsync();
        }

    }
}
