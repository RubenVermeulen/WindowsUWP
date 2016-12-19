using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using OpendeurdagApp.Views;
using Template10.Services.NavigationService;

namespace OpendeurdagApp.ViewModels
{
    public class NewsItemCreatePageViewModel: ViewModelBase
    {
        private HttpClient Client { get; set; }
        public RelayCommand SaveNewsItemCommand { get; set; }
        public ObservableCollection<Campus> Campuses { get; set; }
        public ObservableCollection<Degree> Degrees { get; set; }
        public List<Campus> SelectedCampuses { get; set; }
        public List<Degree> SelectedDegrees { get; set; }

        private string title;
        private string content;
        private DateTimeOffset publishedAtDate;
        private TimeSpan publishedAtTime;

        public NewsItemCreatePageViewModel()
        {
            Client = new HttpClient();
            SaveNewsItemCommand = new RelayCommand(SaveNewsItem);
            Campuses = new ObservableCollection<Campus>();
            Degrees = new ObservableCollection<Degree>();
            SelectedCampuses = new List<Campus>();
            SelectedDegrees = new List<Degree>();
            PublishedAtDate =  DateTimeOffset.Now;
            PublishedAtTime = DateTime.Now.TimeOfDay;

            PopulateCampuses();
            PopulateDegrees();
        }

        private async void SaveNewsItem(object param)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                // Validation message
                var mdFailed = new MessageDialog("Alle velden moeten ingevuld zijn.", "Opgelet");
                mdFailed.Commands.Add(new UICommand("Sluiten", null, 0));
                await mdFailed.ShowAsync();

                return;
            }

            var s = new NewsItem()
            {
                Title = Title,
                Content = Content,
                PublishedAtDate = PublishedAtDate,
                PublishedAtTime = PublishedAtTime,
                Campuses = new List<Campus>(SelectedCampuses),
                Degrees = new List<Degree>(SelectedDegrees)
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");

            // Post Student
            var result = await Client.PostAsync(new Uri(Config.Config.BaseUrlApi + "newsitems"), httpContent);
            var status = result.StatusCode;

            if (status != HttpStatusCode.Created) return;            

            // Create the message dialog and set its content and title
            var mdSuccess = new MessageDialog("Het nieuwsitem is succesvol aangemaakt.", "Nieuwsitem aangemaakt");

            // Add commands and set their command ids
            mdSuccess.Commands.Add(new UICommand("Sluiten", null, 0));

            // Set the command that will be invoked by default
            mdSuccess.DefaultCommandIndex = 0;

            // Show the message dialog and get the event that was invoked via the async operator
            await mdSuccess.ShowAsync();

            NavigationService.Navigate(typeof(NewsItemPage));
        }

        private async void PopulateCampuses()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "campuses"));
            var data = JsonConvert.DeserializeObject<List<Campus>>(json);

            data.ForEach(Campuses.Add);
        }

        private async void PopulateDegrees()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "degrees"));
            var data = JsonConvert.DeserializeObject<List<Degree>>(json);

            data.ForEach(Degrees.Add);
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                RaisePropertyChanged();
            }
        }

        public DateTimeOffset PublishedAtDate
        {
            get { return publishedAtDate; }
            set
            {
                publishedAtDate = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan PublishedAtTime
        {
            get { return publishedAtTime; }
            set
            {
                publishedAtTime = value;
                RaisePropertyChanged();
            }
        }
    }
}
