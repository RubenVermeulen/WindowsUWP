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
    public class StatisticsPageViewModel: ViewModelBase
    {
        private HttpClient Client { get; set; }
    
        public ObservableCollection<Campus> Campuses { get; set; }
        public ObservableCollection<Degree> Degrees { get; set; }

        public StatisticsPageViewModel()
        {
            Client = new HttpClient();

            Campuses = new ObservableCollection<Campus>();
            Degrees = new ObservableCollection<Degree>();

            PopulateCampuses();
            PopulateDegrees();
        }

        private async void PopulateCampuses()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "campuses"));
            var data = JsonConvert.DeserializeObject<List<Campus>>(json);

            data.ForEach(Campuses.Add);
        }

        private async void PopulateDegrees()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "degrees"));
            var data = JsonConvert.DeserializeObject<List<Degree>>(json);

            data.ForEach(Degrees.Add);
        }
    }
}
