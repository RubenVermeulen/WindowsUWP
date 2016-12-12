using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.ViewModels
{
    public class StudentCreatePageViewModel: ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand SaveStudentCommand { get; set; }

        private string firstName;
        private string lastName;
        private string email;
        private string telephone;
        private string address;

        public StudentCreatePageViewModel()
        {
            Client = new HttpClient();
            SaveStudentCommand = new RelayCommand(SaveStudent);
        }

        private async void SaveStudent(object param)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(telephone) || string.IsNullOrEmpty(address))
            {
                // Validation message
                var mdFailed = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                mdFailed.Commands.Add(new UICommand("Sluiten", null, 0));
                await mdFailed.ShowAsync();

                return;
            }

            var s = new Student()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Telephone = Telephone,
                Address = Address
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrlApi + "students"), httpContent);
            var status = result.StatusCode;

            if (status != HttpStatusCode.Created) return;
            
            // Remove values from all fields
            FirstName = LastName = Email = Telephone = Address = string.Empty;

            // Create the message dialog and set its content and title
            var mdSuccess = new MessageDialog("Bedankt voor je gegevens. Ze succesvol zijn verzonden.", "Gegevens verzonden");

            // Add commands and set their command ids
            mdSuccess.Commands.Add(new UICommand("Sluiten", null, 0));

            // Set the command that will be invoked by default
            mdSuccess.DefaultCommandIndex = 0;

            // Show the message dialog and get the event that was invoked via the async operator
            await mdSuccess.ShowAsync();
            
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
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
    }
}
