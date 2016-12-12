using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class CampusDetailPage : Page
    {
        private HttpClient Client;
        private Campus c;

        public CampusDetailPage()
        {
            this.InitializeComponent();
            Client = new HttpClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            c = SerializationService.Json.Deserialize(e.Parameter as string) as Campus;

            DataContext = new
            {
                Campus = c,
                AuthVisibility = AuthService.User == null ? "Collapsed" : "Visible"
            };
        }

        private void EditCampus(object sender, RoutedEventArgs e)
        {
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(CampusEditPage), json);
        }

        private async void DeleteCampus(object sender, RoutedEventArgs e)
        {
            var md = new MessageDialog("Je staat op het punt om \"" + c.Name + "\" te verwijderen. Ben je zeker?");

            md.Title = "Verwijderen";
            md.Commands.Add(new UICommand { Label = "Ja", Id = 0 });
            md.Commands.Add(new UICommand { Label = "Nee", Id = 1 });

            var mdResult = await md.ShowAsync();

            if ((int) mdResult.Id != 0) return;

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var result = await Client.DeleteAsync(new Uri(Config.Config.BaseUrlApi + "campuses/" + c.CampusId));
            var status = result.StatusCode;

            if (status == HttpStatusCode.OK)
            {
                Frame.Navigate(typeof(CampusView));
            }
        }
    }
}
