using CarouselView.Controls;
using OpendeurdagApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CampusTourPage : Page
    {
        public CampusTourPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            carousel.ItemClick += Carousel_ItemClick;
        }

        private async void Carousel_ItemClick(object arg1, CarouselViewItemClickEventArgs arg2)
        {
            MessageDialog md = new MessageDialog($"You have clicked {(arg2.ClickItem as ICarouselViewItemSource).Title} ;-)", "Wow");
            await md.ShowAsync();
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            carousel.ItemImageSource = new List<ICarouselViewItemSource>()
            {
                 new CarouselItemSource() {
                     ImageSource ="https://img1.doubanio.com/view/photo/photo/public/p1547743259.jpg",
                     Title ="title1" },
                 new CarouselItemSource() {
                     ImageSource ="https://img1.doubanio.com/view/photo/photo/public/p2183422782.jpg",
                     Title ="title2" },
                 new CarouselItemSource() {
                     ImageSource ="https://img1.doubanio.com/view/photo/photo/public/p832662844.jpg",
                     Title ="title3" },
                 new CarouselItemSource() {
                     ImageSource ="https://img1.doubanio.com/view/photo/photo/public/p752907403.jpg",
                     Title ="title" },
            };
        }
    }
}
