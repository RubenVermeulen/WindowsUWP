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
using OpendeurdagApp.Models;
using Template10.Services.SerializationService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsItemDetailPage : Page
    {
        public NewsItemDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var newsItem = SerializationService.Json.Deserialize(e.Parameter as string) as NewsItem;

            ViewModel.NewsItem = newsItem;

        }

        private void EditNewsItem(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteNewsItem(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteNewsItem();
        }
    }
}
