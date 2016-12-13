using OpendeurdagApp.Helper;
using System;
using System.Collections.Generic;
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
    public class CampusCreateViewModel : ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand SaveCampusCommand { get; set; }

        private string name;
        private string address;
        private string imageUrl;

        public CampusCreateViewModel()
        {
            Client = new HttpClient();
            SaveCampusCommand = new RelayCommand(SaveCampus);
        }

        private async void SaveCampus(object param)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(imageUrl))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }

            Campus c = new Campus()
            {
                Name = name,
                Address = address,
                ImageUrl = imageUrl
            };

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var httpContent = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrlApi + "campuses"), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.Created)
            {
                // Remove values from all fields
                Name = Address = ImageUrl = string.Empty;

                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("De campus is succesvol toegevoegd.", "Campus toegevoegd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();
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
