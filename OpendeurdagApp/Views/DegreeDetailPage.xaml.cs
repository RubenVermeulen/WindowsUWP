using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    public sealed partial class DegreeDetailPage : Page
    {

        private HttpClient Client;
        private Degree degree;

        public DegreeDetailPage()
        {
            this.InitializeComponent();
            Client = new HttpClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            degree = SerializationService.Json.Deserialize(e.Parameter as string) as Degree;

            ViewModel.Degree = degree;
        }

        private void EditDegree(object sender, RoutedEventArgs e)
        {
            var json = SerializationService.Json.Serialize(degree);

            Frame.Navigate(typeof(DegreeEditPage), json);
        }

        private void DeleteDegree(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteDegree();
        }
    }
}
