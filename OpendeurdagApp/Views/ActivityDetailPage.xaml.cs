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
    public sealed partial class ActivityDetailPage : Page
    {
        private HttpClient Client;
        private Activity a;


        public ActivityDetailPage()
        {
            this.InitializeComponent();
            Client = new HttpClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            a = SerializationService.Json.Deserialize(e.Parameter as string) as Activity;

            ViewModel.Activity = a;
        }

      

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void EditActivity(object sender, RoutedEventArgs e)
        {
            var json = SerializationService.Json.Serialize(a);

            Frame.Navigate(typeof(ActivityEditPage), json);
        }

        private void DeleteActivity(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteActivity();
        }

        /*
        private void lv_CampusSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = (Campus)Lv_Campuses.SelectedItem;
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(CampusDetailPage), json);
        }
        */

    }
}
