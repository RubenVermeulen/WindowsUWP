using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using OpendeurdagApp.Models;
using Template10.Services.SerializationService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CampusEditPage : Page
    {
        private HttpClient Client { get; set; }
        private Campus c;

        public CampusEditPage()
        {
            this.InitializeComponent();
            Client = new HttpClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            c = SerializationService.Json.Deserialize(e.Parameter as string) as Campus;

            DataContext = c;
        }

        private async void SaveCampus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.c.Name) || string.IsNullOrEmpty(this.c.Address) || string.IsNullOrEmpty(this.c.ImageUrl))
            {
                // Validation message
                var messageDialog = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                messageDialog.Commands.Add(new UICommand("Sluiten", null, 0));
                await messageDialog.ShowAsync();

                return;
            }

            var httpContent = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
            var result = await Client.PutAsync(new Uri(Config.Config.BaseUrlApi + "campuses/" + c.CampusId), httpContent);
            var status = result.StatusCode;

            if (status == HttpStatusCode.NoContent)
            {
                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("De campus is succesvol gewijzigd.", "Campus gewijzigd");

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
