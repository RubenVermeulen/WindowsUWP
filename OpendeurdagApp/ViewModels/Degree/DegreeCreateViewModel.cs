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
    public class DegreeCreateViewModel : ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand SaveDegreeCommand { get; set; }
        public ObservableCollection<Campus> Campuses { get; set; }
        public List<Campus> SelectedCampuses { get; set; }

        private string name;
        private string description;
        private string smallDescription;
        private string imageUrl;
        private string facebookUrl;

        public DegreeCreateViewModel()
        {
            Client = new HttpClient();
            SaveDegreeCommand = new RelayCommand(SaveDegree);
            Campuses = new ObservableCollection<Campus>();
            SelectedCampuses = new List<Campus>();

            PopulateCampuses();
        }

        private async void SaveDegree(object param)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(smallDescription) || string.IsNullOrEmpty(imageUrl))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }

            var degree = new Degree()
            {
                Name = name,
                SmallDescription = smallDescription,
                Description = description,
                ImageUrl = imageUrl,
                FacebookUrl = facebookUrl,
                Campuses = SelectedCampuses
            };

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var httpContent = new StringContent(JsonConvert.SerializeObject(degree), Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrlApi + "degrees"), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.Created)
            {
                // Remove values from all fields
                Name = SmallDescription = Description = ImageUrl = FacebookUrl = string.Empty;

                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("De opleiding is succesvol toegevoegd.", "Opleiding toegevoegd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();

                NavigationService.Navigate(typeof(MainPage));
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

        public string SmallDescription
        {
            get { return smallDescription; }
            set
            {
                smallDescription = value;
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

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                RaisePropertyChanged();
            }
        }

        public string FacebookUrl
        {
            get { return facebookUrl; }
            set
            {
                facebookUrl = value;
                RaisePropertyChanged();
            }
        }
    }
}
