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
    public class NewsItemPageViewModel: ViewModelBase
    {
        private HttpClient Client { get; set; }

        public ObservableCollection<NewsItem> NewsItems { get; set; }

        public NewsItemPageViewModel()
        {
            Client = new HttpClient();
            NewsItems = new ObservableCollection<NewsItem>();

            populateCollection();
        }

        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "newsitems"));
            var data = JsonConvert.DeserializeObject<List<NewsItem>>(json);

            data.ForEach(NewsItems.Add);
        }
    }
}
