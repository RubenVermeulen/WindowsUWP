using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;
using OpendeurdagApp.Views;

namespace OpendeurdagApp.ViewModels
{
    public class ActivityDetailViewModel : ViewModelBase
    {
        private HttpClient Client;

        public Activity Activity { get; set; }

        public ActivityDetailViewModel()
        {
            Client = new HttpClient();
        }

        public async void DeleteActivity()
        {
            var confirmDelete = await DeleteDialog();

            if (!confirmDelete) return;

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.User.AccessToken);

            var result = await Client.DeleteAsync(new Uri(Config.Config.BaseUrlApi + "activities/" + Activity.ActivityId));
            var status = result.StatusCode;

            if (status == HttpStatusCode.OK)
            {
                NavigationService.Navigate(typeof(ActivityView));
            }
        }

        public async Task<bool> DeleteDialog()
        {
            var md = new MessageDialog("Je staat op het punt om deze \"" + Activity.Name + "\" te verwijderen. Ben je zeker?")
            {
                Title = "Verwijderen"
            };

            md.Commands.Add(new UICommand { Label = "Ja", Id = 0 });
            md.Commands.Add(new UICommand { Label = "Nee", Id = 1 });

            var mdResult = await md.ShowAsync();

            return (int)mdResult.Id == 0;
        }
    }
}