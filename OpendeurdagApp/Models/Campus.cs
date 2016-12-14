using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OpendeurdagApp.Models
{
    public class Campus : INotifyPropertyChanged
    {
        public int CampusId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<NewsItem> NewsItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}