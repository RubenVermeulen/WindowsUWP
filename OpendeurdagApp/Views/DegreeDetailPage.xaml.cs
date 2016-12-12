using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.SerializationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        private Degree degree;

        public DegreeDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            degree = SerializationService.Json.Deserialize(e.Parameter as string) as Degree;

            DataContext = new
            {
                Degree = degree,
                AuthVisiblity = AuthService.User == null ? "Collapsed" : "Visible"
            };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var json = SerializationService.Json.Serialize(degree);

            Frame.Navigate(typeof(CampusEditPage), json);
        }
    }
}
