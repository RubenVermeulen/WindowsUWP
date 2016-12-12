using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.ViewModels
{
    public class StudentOverviewPageViewModel: ViewModelBase
    {
        private HttpClient Client { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public StudentOverviewPageViewModel()
        {
            Client = new HttpClient();
            Students = new ObservableCollection<Student>();

            populateCollection();
        }

        private async void populateCollection()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "students"));
            var data = JsonConvert.DeserializeObject<List<Student>>(json);

            data.ForEach(Students.Add);
        }
    }
}
