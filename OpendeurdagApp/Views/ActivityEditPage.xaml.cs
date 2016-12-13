using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
using Newtonsoft.Json;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using Template10.Services.SerializationService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActivityEditPage : Page
    {
        private HttpClient Client { get; set; }
        private Activity a;


        public ActivityEditPage()
        {
            this.InitializeComponent();
            Client = new HttpClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            a = SerializationService.Json.Deserialize(e.Parameter as string) as Activity;

            DataContext = a;
        }

        private async void SaveActivity(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.a.Name) || string.IsNullOrEmpty(this.a.Location) || string.IsNullOrEmpty(this.a.Description))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var httpContent = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            var result = await Client.PutAsync(new Uri(Config.Config.BaseUrlApi + "activities/" + a.ActivityId), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.NoContent)
            {
                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("De activity is succesvol gewijzigd.", "Activity gewijzigd");

                // Add commands and set their command ids
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Show the message dialog and get the event that was invoked via the async operator
                await messageDialog.ShowAsync();
            }

        }
    }
}
