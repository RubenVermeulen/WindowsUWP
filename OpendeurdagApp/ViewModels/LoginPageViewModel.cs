using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using OpendeurdagApp.Views;
using Template10.Services.NavigationService;

namespace OpendeurdagApp.ViewModels
{
    public class LoginPageViewModel : Template10.Mvvm.ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand LoginCommand { get; set; }

        private string userName;
        private string password;

        public LoginPageViewModel()
        {
            Client = new HttpClient();
            LoginCommand = new RelayCommand(Login);
        }

        private async void Login(object param)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");

                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }


            var obj = new
            {
                grant_type = "password",
                userName = UserName,
                password = Password
            };

            var urlEncoded = string.Format("grant_type=password&userName={0}&password={1}", UserName, Password);

            var httpContent = new StringContent(urlEncoded, Encoding.UTF8, "application/x-www-form-urlencoded");
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrl + "token"), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.OK)
            {
                var data = await result.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserDbo>(data);

                AuthService.User = user;

                // Remove values from all fields
                UserName = Password = string.Empty;

                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("Je bent succesvol ingelogd.", "Ingelogd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();

                // Redirect
                NavigationService.Navigate(typeof(CampusView));
            }
            else
            {
                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("Gebruikersnaam/wachtwoord is foutief.", "Ingelogd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
    }
}
