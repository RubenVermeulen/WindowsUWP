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
    public class CampusViewModel : Template10.Mvvm.ViewModelBase
    {
        private HttpClient Client { get; set; }

        public ObservableCollection<Campus> Campuses { get; set; }

        public CampusViewModel()
        {
            Client = new HttpClient();
            Campuses = new ObservableCollection<Campus>();

            populateCollection();
        }

        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "campuses"));
            var data = JsonConvert.DeserializeObject<List<Campus>>(json);

            data.ForEach(Campuses.Add);
        }
    }
}
