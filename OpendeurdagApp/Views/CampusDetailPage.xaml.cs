using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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

            ViewModel.Campus = c;

            LoadMap();
        }

        private async void LoadMap()
        {
            // Specify location (converts address to lat and long)
            var result = await MapLocationFinder.FindLocationsAsync(c.Address, null);
            var location = result.Locations[0];

            // Set map location
            Map.Center = location.Point;
            Map.ZoomLevel = 16;

            // Set map pushpin
            var pushpin = new MapIcon()
            {
                Location = location.Point,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = c.Name,
                ZIndex = 0
            };

            Map.MapElements.Add(pushpin);
        }

        private void EditCampus(object sender, RoutedEventArgs e)
        {
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(CampusEditPage), json);
        }

        private void DeleteCampus(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteCampus();
        }

        private void StartTour(object sender, RoutedEventArgs e)
        {
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(CampusTourPage), json);
        }
    }
}
