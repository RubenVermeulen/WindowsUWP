using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpendeurdagClient.Helper;
using OpendeurdagClient.Model;
using OpendeurdagClient.Models;

namespace OpendeurdagClient.ViewModel
{
    class DegreeViewModel : ViewModelBase
    {
        private HttpClient Client { get; set; }

        public ObservableCollection<Degree> Degrees { get; set; }

        public DegreeViewModel()
        {
            Client = new HttpClient();
            Degrees = new ObservableCollection<Degree>();

            populateCollection();
        }

        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.DegreeUrlApi));
            var data = JsonConvert.DeserializeObject<List<Degree>>(json);

            data.ForEach(Degrees.Add);
        }
    }
}
