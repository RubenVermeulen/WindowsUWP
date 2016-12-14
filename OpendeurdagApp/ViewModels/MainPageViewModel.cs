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

        public ObservableCollection<Activity> Activities { get; set; }

        public Activity NextActivity { get; set; }


        public MainPageViewModel()
        {
 

            Client = new HttpClient();
            Degrees = new ObservableCollection<Degree>();
            Activities = new ObservableCollection<Activity>();
            NextActivity = new Activity();

            populateCollection();
        }

        
        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "degrees"));
            var data = JsonConvert.DeserializeObject<List<Degree>>(json);

            data.ForEach(Degrees.Add);


            List<Activity> activitiesHelper = new List<Activity>();

            var jsonActivity = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "nextactivities"));
            var dataActivity = JsonConvert.DeserializeObject<List<Activity>>(jsonActivity);

            dataActivity.ForEach(Activities.Add);
        }


        //public void GotoSettings() =>
        //    NavigationService.Navigate(typeof(Views.LoginPage), 0);

        //public void GotoPrivacy() =>
        //    NavigationService.Navigate(typeof(Views.LoginPage), 1);

        //public void GotoAbout() =>
        //    NavigationService.Navigate(typeof(Views.LoginPage), 2);

    }
}

