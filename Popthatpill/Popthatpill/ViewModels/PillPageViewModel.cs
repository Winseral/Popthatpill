using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Media;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using SQLite.Net;
using Popthatpill.ViewModel;
using Prism.Services;
using System.Net.Http;
using Newtonsoft.Json;
using static Popthatpill.ViewModels.PBS;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace Popthatpill.ViewModels
{
    public class PillPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _NavigationService;

        public IPageDialogService _dialogService { get; private set; }

        public SQLiteConnection database;

        public static object CollisionLock = new object();

        public TimeSpan Timezero { get; private set; }

        //List of Strings
        private string _MainTitle;
        public string MainTitle
        {
            get { return _MainTitle; }
            set { SetProperty(ref _MainTitle, value); }
        }

        private Image _PillImage;
        public Image PillImage
        {
            get { return _PillImage; }
            set { SetProperty(ref _PillImage, value); }
        }

        private string _PillName;
        public string PillName
        {
            get { return _PillName; }
            set{SetProperty(ref _PillName, value); }

        }

        private int _PillCount;
        public int PillCount
        {
            get { return _PillCount; }
            set { SetProperty(ref _PillCount, value); }
        }


        private TimeSpan _Time;
        public TimeSpan Time
        {
            get { return _Time; }
            set { SetProperty(ref _Time, value); }
        }

        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private bool _isActive = false;
        public bool isActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }

        }

        private List<Pill> _GetDayPills;
        public List<Pill> GetDayPills
        {
            get { return _GetDayPills; }
            set { SetProperty(ref _GetDayPills, value); }
        }

        private List<string> _ListOfSearchPBSNames;
        public List<string> ListOfSearchPBSNames
        {
            get { return _ListOfSearchPBSNames; }
            set { SetProperty(ref _ListOfSearchPBSNames, value); }
        }

        //Navigation Command
        public DelegateCommand NavigationCommand { get; private set; }

        //Add Command
        public DelegateCommand AddCommand { get; private set; }

        //Add Pill Image
        public DelegateCommand AddImageCommand { get; private set; }

        //Add SearchBar Pill test
        public DelegateCommand AddPBSTestCommand { get; private set; }

        public HttpClient PBSClient { get; private set; }

        public int ID { get; private set; }

        //Start of Main Class
        public PillPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            
            _dialogService = dialogService;
            _NavigationService = navigationService;

            PillCount = 1;
  

            NavigationCommand = new DelegateCommand(Navigate);
            AddCommand = new DelegateCommand(AddPill, CanAddPill).ObservesProperty(()=> PillName).ObservesProperty(()=>Time);
            AddImageCommand = new DelegateCommand(AddImage, CanAddImage).ObservesProperty(()=> PillName);
            AddPBSTestCommand = new DelegateCommand(PBSTest);

        }

      
        public async void PBSTest()
        {
            //Once Searchbutton pressed look but the PBS list of pills
            
            isActive = true;
            await PBSGetData();
            isActive = false;  

        }


        public async Task<List<Item>> PBSGetData()
        {

            IEnumerable<Item> Items = Enumerable.Empty<Item>();
            List<string> ListOfSearchPBSNames = new List<string>();


            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())

            {
                string apikey = "afb2cdb41210b24f70e9b8cbf63653e2";
                var Uri2 = string.Format(@"https://api.pbs.gov.au/0.3/search.json?term={0}&effectivedate=2016-08-01&view=item&api_key={1}", PillName, apikey);

                PBSClient = new HttpClient();
                var response = await PBSClient.GetAsync(Uri2);
                
                if (response.IsSuccessStatusCode)
                {
                    
                    var content = await response.Content.ReadAsStringAsync();
                    RootObject name = JsonConvert.DeserializeObject<RootObject>(content);

                    foreach (GenericDrug s in name.Items.Item)
                    {
                        if (s.LIName != null)
                        {
                            ListOfSearchPBSNames.Add(s.LIName);
                        }
                    }
                 
                }

                //display the list of PBS distinct values and allows user to add this name to PillName
                var action = await _dialogService.DisplayActionSheetAsync("Pharmaceutical Benefits Scheme Search Result/s", "Cancel", "", ListOfSearchPBSNames.Distinct().ToArray());

                if (action != "Cancel")
                PillName = action;

            }
            else await _dialogService.DisplayAlertAsync("Server Error", "Unable to connect to server, please confirm WiFi or MobileData is available", "OK");
            return Items.ToList();
        }

        private bool CanAddImage()
        {
            return !string.IsNullOrEmpty(PillName);
        }

        public async void AddImage()
        {
      
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _dialogService.DisplayAlertAsync("Alert","no camera availble","OK");
                return;

            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name =  PillName + ".jpg",
                

            });
            if (file == null)
                return;

            await _dialogService.DisplayAlertAsync("File Location", file.Path, "OK");
            var newimage = file.GetStream();
            //newimage = Xamarin.Forms.DependencyService.Get<ICameraImages>().GetWriteStream(PillName + ".JPG");
           
        }

        private bool CanAddPill()
        {
            return !string.IsNullOrEmpty(PillName) && Time != Timezero;
        }

        public async void AddPill()
        {
            //Copies the add data to the Sqlite file
            PillDataAccess();

            await _dialogService.DisplayAlertAsync("Added Reminder", PillCount + " Pills of  the pill type " + PillName + " has been added to the " + Time + " Reminder" , "OK");

            //Send information to reminder

            //re-Int the screen variables
            PillName = "";
            PillCount = 1;
            PillImage = null;
            Time = Timezero;

           
        }

        //set what the NavigationCommnad will do
        private async void Navigate()
        {
           await _NavigationService.GoBackAsync();
        }

        //INavigationAware passing Parameters between pages
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            return;
        }


        public void OnNavigatedTo(NavigationParameters parameters)
        {

            if (parameters.ContainsKey("Title"))
                MainTitle = (string)parameters["Title"];

            PillImage = new Image { Aspect = Aspect.AspectFit };

            //connect to database and get list of Pills related to this Day
            var database = Xamarin.Forms.DependencyService.Get<IDatabaseConnection>().DbConnection();

            var listView = new ListView();
            GetDayPills = database.Table<Pill>().Where(v => v.Day.StartsWith(MainTitle)).ToList();
  
            foreach (var Pill in GetDayPills)
            {
                PillImage.Source = Xamarin.Forms.DependencyService.Get<ICameraImages>().GetPictureFromDisk(GetDayPills.AsEnumerable().ToString());
                listView.ItemsSource = GetDayPills;
            }
        }

        //On add pill sets the database with the new pill information
        public void PillDataAccess()
        {
            PillImage = new Image { Aspect = Aspect.AspectFit };
  
            var database = Xamarin.Forms.DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Pill>();
         
            var Pills = new Pill();
            Pills.Day = MainTitle;
            Pills.NewPillName = PillName;
            Pills.NewPillImage = PillName + ".JPG";
            Pills.NewPillCount = PillCount;
            date = DateTime.Today + Time;
            Pills.NewTime = date.ToString("hh:mm tt");

            database.Insert(Pills);
            database.Commit();

            var listView = new ListView();
            GetDayPills = database.Table<Pill>().Where(v => v.Day.StartsWith(MainTitle)).ToList();
            
            foreach (var Pill in GetDayPills)
            {
                PillImage.Source = Xamarin.Forms.DependencyService.Get<ICameraImages>().GetPictureFromDisk(GetDayPills.AsEnumerable().ToString());
                listView.ItemsSource = GetDayPills;  
               
            }

            ID = Pills.ID;
            Xamarin.Forms.DependencyService.Get<ICalendar>().PoppillReminder(ID,PillName,MainTitle,PillCount,Time);
        }
        
    }
}

