using Newtonsoft.Json;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Template10.Services.SerializationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DegreeEditPage : Page
    {
        private HttpClient Client { get; set; }
        private Degree degree;

        public DegreeEditPage()
        {
            this.InitializeComponent();
            Client = new HttpClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            degree = SerializationService.Json.Deserialize(e.Parameter as string) as Degree;

            DataContext = degree;
        }

        private async void SaveDegree(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.degree.Name) || string.IsNullOrEmpty(this.degree.SmallDescription) || string.IsNullOrEmpty(this.degree.ImageUrl) || string.IsNullOrEmpty(this.degree.Description))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var httpContent = new StringContent(JsonConvert.SerializeObject(degree), Encoding.UTF8, "application/json");
            var result = await Client.PutAsync(new Uri(Config.Config.BaseUrlApi + "degrees/" + degree.DegreeId), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.NoContent)
            {
                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("Het opleiding is succesvol gewijzigd.", "Opleiding gewijzigd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();

                Frame.Navigate(typeof(MainPage));
            }


        }
    }
}
