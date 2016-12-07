using OpendeurdagApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.ViewModels
{
    public class CampusCreateViewModel : Template10.Mvvm.ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand SaveCampusCommand { get; set; }

        private string name;
        private string address;
        private string imageUrl;

        public CampusCreateViewModel()
        {
            Client = new HttpClient();
            SaveCampusCommand = new RelayCommand((param) => SaveCampus(param));
        }

        private async void SaveCampus(object param)
        {
            Campus c = new Campus()
            {
                Name = name,
                Address = address,
                ImageUrl = imageUrl
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrlApi + "campuses"), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.Created)
            {
                // Remove values from all fields
                Name = Address = ImageUrl = string.Empty;
            }
            
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

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                RaisePropertyChanged();
            }
        }
    }
}
