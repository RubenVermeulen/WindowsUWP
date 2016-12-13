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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsItemCreatePage : Page
    {
        public NewsItemCreatePage()
        {
            this.InitializeComponent();
        }

        private void GvCampuses_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCampuses = new List<Campus>();

            foreach (Campus c in GvCampuses.SelectedItems)
            {
                selectedCampuses.Add(c);
            }

            ViewModel.SelectedCampuses = selectedCampuses;
        }

        private void GvDegrees_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDegrees = new List<Degree>();

            foreach (Degree d in GvDegrees.SelectedItems)
            {
                selectedDegrees.Add(d);
            }

            ViewModel.SelectedDegrees = selectedDegrees;
        }
    }
}
