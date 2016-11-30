using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.ViewModels
{
    class ActivityPageViewModel : Template10.Mvvm.ViewModelBase
    {

        private HttpClient Client { get; set; }

        public ObservableCollection<Activity> Activities{ get; set; }

        public ActivityPageViewModel()
        {
            Client = new HttpClient();
            Activities = new ObservableCollection<Activity>();

            populateCollection();
        }

        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "activities"));
            var data = JsonConvert.DeserializeObject<List<Activity>>(json);

            data.ForEach(Activities.Add);

            
        }

     
    }
}
