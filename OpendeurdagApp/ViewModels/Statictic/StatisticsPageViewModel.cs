using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpendeurdagApp.Models;
using Template10.Utils;

namespace OpendeurdagApp.ViewModels
{
    public class StatisticsPageViewModel: ViewModelBase
    {
        private HttpClient Client { get; set; }
    
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Student> StudentsDay { get; set; }
        public ObservableCollection<Student> StudentsWeek { get; set; }
        public ObservableCollection<Campus> Campuses { get; set; }
        public ObservableCollection<Degree> Degrees { get; set; }

        public StatisticsPageViewModel()
        {
            Client = new HttpClient();

            Students = new ObservableCollection<Student>();
            StudentsDay = new ObservableCollection<Student>();
            StudentsWeek = new ObservableCollection<Student>();
            Campuses = new ObservableCollection<Campus>();
            Degrees = new ObservableCollection<Degree>();

            PopulateStudents();
            PopulateCampuses();
            PopulateDegrees();
        }

        private async void PopulateStudents()
        {
            var json = await Client.GetStringAsync(new Uri(Config.Config.BaseUrlApi + "students"));
            var data = JsonConvert.DeserializeObject<List<Student>>(json);

            data.ForEach(Students.Add);
            data.Where(s => s.RegisterdAt > DateTimeOffset.Now.AddDays(-1)).ForEach(StudentsDay.Add);
            data.Where(s => s.RegisterdAt > DateTimeOffset.Now.AddDays(-7)).ForEach(StudentsWeek.Add);
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
    }
}
