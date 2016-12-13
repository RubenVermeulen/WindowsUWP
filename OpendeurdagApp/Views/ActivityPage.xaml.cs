﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActivityView : Page
    {
        public ActivityView()
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
            var c = (Activity)lv.SelectedItem;
            var json = SerializationService.Json.Serialize(c);

            Frame.Navigate(typeof(CampusDetailPage), json);
        }

        private void CreateActivity(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ActivityCreatePage));
        }
    }
}
