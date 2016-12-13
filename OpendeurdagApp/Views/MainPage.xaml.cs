using System;
using OpendeurdagApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using OpendeurdagApp.Models;
using Template10.Services.SerializationService;

namespace OpendeurdagApp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            //NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
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
            var c = (Degree)degreesListView.SelectedItem;
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(DegreeDetailPage), json);
        }

        private void CreateDegree(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DegreeCreatePage));
        }

        private void lv_ActivitySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (Activity)degreesListView.SelectedItem;
            var json = SerializationService.Json.Serialize(a);

            Frame.Navigate(typeof(ActivityDetailPage), json);
        }

    }
}
