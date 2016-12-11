using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using System.Collections.ObjectModel;
using OpendeurdagApp.Models;
using Newtonsoft.Json;

namespace OpendeurdagApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private HttpClient Client { get; set; }

        public ObservableCollection<Degree> Degrees { get; set; }

        public Activity NextActivity { get; set; }

        public String thisTest { get; set; }


        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Value = "Designtime value";
            }

            Client = new HttpClient();
            Degrees = new ObservableCollection<Degree>();
            NextActivity = new Activity();
            thisTest = "xd";

            populateCollection();
        }

        string _Value = "Gas";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                Value = suspensionState[nameof(Value)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "degrees"));
            var data = JsonConvert.DeserializeObject<List<Degree>>(json);

            data.ForEach(Degrees.Add);


            List<Activity> activities = new List<Activity>();

            var jsonActivity = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "activities"));
            var dataActivity = JsonConvert.DeserializeObject<List<Activity>>(jsonActivity);

            dataActivity.ForEach(activities.Add);
            List<Activity> sortedActivities = activities.OrderBy(o => o.BeginDate).ToList();

            //NextActivity = sortedActivities[0];
            NextActivity = new Activity(){
                Type = 0,
                Name = "test",
                Description = "testdescr"
            };
        }

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), Value);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

