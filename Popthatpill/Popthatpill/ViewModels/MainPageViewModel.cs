using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Popthatpill.ViewModels
{
    public class MainPageViewModel : BindableBase
    {

        INavigationService _NavigationService;
        private IPageDialogService _dialogService;

        private string _MainTitle = "Popthatpill    ";
        public string MainTitle
        {
            get { return _MainTitle; }
            set { SetProperty(ref _MainTitle, value); }
        }

        //Morning Pill Titles
        private string _sumTitle = "Sunday Morning Pills";
        public string sumTitle
        {
            get { return _sumTitle; }
            set { SetProperty(ref _sumTitle, value); }
        }

        private string _mmTitle = "Monday Morning Pills";
        public string mmTitle
        {
            get { return _mmTitle; }
            set { SetProperty(ref _mmTitle, value); }
        }

        private string _tmTitle = "Tuesday Morning Pills";
        public string tmTitle
        {
            get { return _tmTitle; }
            set { SetProperty(ref _tmTitle, value); }
        }

        private string _wmTitle = "Wednesday Morning Pills";
        public string wmTitle
        {
            get { return _wmTitle; }
            set { SetProperty(ref _wmTitle, value); }
        }

        private string _thmTitle = "Thursday Morning Pills";
        public string thmTitle
        {
            get { return _thmTitle; }
            set { SetProperty(ref _thmTitle, value); }
        }

        private string _fmTitle = "Friday Morning Pills";
        public string fmTitle
        {
            get { return _fmTitle; }
            set { SetProperty(ref _fmTitle, value); }
        }

        private string _stmTitle = "Saturday Morning Pills";
        public string stmTitle
        {
            get { return _stmTitle; }
            set { SetProperty(ref _stmTitle, value); }
        }

        //Night Pills
        private string _sunTitle = "Sunday Night Pills";
        public string snTitle
        {
            get { return _sunTitle; }
            set { SetProperty(ref _sunTitle, value); }
        }

        private string _mnTitle = "Monday Night Pills";
        public string mnTitle
        {
            get { return _mnTitle; }
            set { SetProperty(ref _mnTitle, value); }
        }

        private string _tnTitle = "Tuesday Night Pills";
        public string tnTitle
        {
            get { return _tnTitle; }
            set { SetProperty(ref _tnTitle, value); }
        }

        private string _wnTitle = "Wednesday Night Pills";
        public string wnTitle
        {
            get { return _wnTitle; }
            set { SetProperty(ref _wnTitle, value); }
        }

        private string _thnTitle = "Thursday Night Pills";
        public string thnTitle
        {
            get { return _thnTitle; }
            set { SetProperty(ref _thnTitle, value); }
        }

        private string _fnTitle = "Friday Night Pills";
        public string fnTitle
        {
            get { return _fnTitle; }
            set { SetProperty(ref _fnTitle, value); }
        }

        private string _stnTitle = "Saturday Night Pills";
 
        public string stnTitle
        {
            get { return _stnTitle; }
            set { SetProperty(ref _stnTitle, value); }
        }

        //Morning Commands
        public DelegateCommand SMNavigateCommand { get; private set; }
        public DelegateCommand MMNavigateCommand { get; private set; }
        public DelegateCommand TMNavigateCommand { get; private set; }
        public DelegateCommand WMNavigateCommand { get; private set; }
        public DelegateCommand THMNavigateCommand { get; private set; }
        public DelegateCommand FMNavigateCommand { get; private set; }
        public DelegateCommand STMNavigateCommand { get; private set; }

        //Night Commands
        public DelegateCommand SNNavigateCommand { get; private set; }
        public DelegateCommand MNNavigateCommand { get; private set; }
        public DelegateCommand TNNavigateCommand { get; private set; }
        public DelegateCommand WNNavigateCommand { get; private set; }
        public DelegateCommand THNNavigateCommand { get; private set; }
        public DelegateCommand FNNavigateCommand { get; private set; }
        public DelegateCommand STNNavigateCommand { get; private set; }


        public DelegateCommand popmenuCommand { get; private set; }




        //Class starts here
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _NavigationService = navigationService;
            _dialogService = dialogService;

            //Morning Command Buttons
            SMNavigateCommand = new DelegateCommand(SUMNavigate);
            MMNavigateCommand = new DelegateCommand(MMNavigate);
            TMNavigateCommand = new DelegateCommand(TMNavigate);
            WMNavigateCommand = new DelegateCommand(WMNavigate);
            THMNavigateCommand = new DelegateCommand(THMNavigate);
            FMNavigateCommand = new DelegateCommand(FMNavigate);
            STMNavigateCommand = new DelegateCommand(STMNavigate);

            //Night Command Buttons
            SNNavigateCommand = new DelegateCommand(SNNavigate);
            MNNavigateCommand = new DelegateCommand(MNNavigate);
            TNNavigateCommand = new DelegateCommand(TNNavigate);
            WNNavigateCommand = new DelegateCommand(WNNavigate);
            THNNavigateCommand = new DelegateCommand(THNNavigate);
            FNNavigateCommand = new DelegateCommand(FNNavigate);
            STNNavigateCommand = new DelegateCommand(STNNavigate);

            //popmenu and actions
            popmenuCommand = new DelegateCommand(popmenu);

        }

        private async void popmenu()
        {
            //actionsheet to different information
            var action = await _dialogService.DisplayActionSheetAsync("   Menu   ", "Cancel", "", "PBS Website", "Prism Site", "About");


            if (action == "About")
            {
                await _NavigationService.NavigateAsync("About");
            }

            if (action == "PBS Website")
            {
                await _NavigationService.NavigateAsync("PBSWebsite");
            }

            if (action == "Prism Site")
            {
                await _NavigationService.NavigateAsync("PrismSite");
            }

        }


        private void STNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", stnTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void FNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", fnTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void THNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", thnTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void WNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", wnTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void TNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", tnTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void MNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", mnTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void SNNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", snTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        #region MorningCommandNavSyncs definition
        private void STMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", stmTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void FMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", fmTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void THMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", thmTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void WMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", wmTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void TMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", tmTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void MMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", mmTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        private void SUMNavigate()
        {
            var p = new NavigationParameters();
            p.Add("Title", sumTitle);
            _NavigationService.NavigateAsync("PillPage", p);
        }

        #endregion
    }
}
