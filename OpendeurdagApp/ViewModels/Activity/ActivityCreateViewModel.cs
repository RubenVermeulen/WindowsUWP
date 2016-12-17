using OpendeurdagApp.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using OpendeurdagApp.Models;
using OpendeurdagApp.Views;

namespace OpendeurdagApp.ViewModels
{
    class ActivityCreateViewModel : ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand SaveActivityCommand { get; set; }
        public ObservableCollection<Campus> Campuses { get; set; }
        public List<Campus> SelectedCampuses { get; set; }

        private string name;
        private string description;
        private string location;
        private DateTimeOffset? beginDate;
        private TimeSpan? beginTime;
        private DateTimeOffset? endDate;
        private TimeSpan? endTime;



        public ActivityCreateViewModel() {
            Client = new HttpClient();
            SaveActivityCommand = new RelayCommand(SaveActivity);
            Campuses = new ObservableCollection<Campus>();
            SelectedCampuses = new List<Campus>();

            PopulateCampuses();
        }

        private async void SaveActivity(object param)
        {

            
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(location))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }

            if (beginDate == null || endDate == null|| beginTime == null || endTime == null) {
                beginDate = DateTimeOffset.Now;
                endDate = DateTimeOffset.Now;
                beginTime = new TimeSpan();
                endTime = new TimeSpan();
            }


            var a = new Activity()
            {
                
                Name = name,
                Description = description,
                Location = location,
                BeginDate = (DateTimeOffset) beginDate,
                BeginTime = (TimeSpan) beginTime,
                EndDate = (DateTimeOffset) endDate,
                EndTime = (TimeSpan) endTime,
                Campuses = SelectedCampuses
            };

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var httpContent = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrlApi + "activities"), httpContent);
            var status = result.StatusCode;


            if (status == HttpStatusCode.Created)
            {
                // Remove values from all fields
                Name = Description = Location = string.Empty;
                BeginDate = EndDate  = null;
                beginTime = endTime = null;
              

                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("De activity is succesvol toegevoegd.", "Activity toegevoegd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Ok", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();

                NavigationService.Navigate(typeof(ActivityView));
            }
        }

        private async void PopulateCampuses()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "campuses"));
            var data = JsonConvert.DeserializeObject<List<Campus>>(json);

            data.ForEach(Campuses.Add);
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged();
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                RaisePropertyChanged();
            }
        }

        public DateTimeOffset? BeginDate
        {
            get { return beginDate; }
            set
            {
                beginDate = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan? BeginTime {
            get { return beginTime; }
            set {
                beginTime = value;
                RaisePropertyChanged();
            }

        }

        public DateTimeOffset? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan? EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                RaisePropertyChanged();
            }

        }

       

    }

    }

