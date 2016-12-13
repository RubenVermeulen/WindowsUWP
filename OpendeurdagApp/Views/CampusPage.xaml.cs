using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using OpendeurdagApp.Models;
using Template10.Services.NavigationService;
using Template10.Services.SerializationService;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace OpendeurdagApp.Views
{
    public sealed partial class CampusView : Page
    {
        public CampusView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = (Campus) lv.SelectedItem;
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(CampusDetailPage), json);
        }

        private void CreateCampus(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CampusCreatePage));
        }
    }
}
