using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OpendeurdagApp.Models
{
    public class Degree : INotifyPropertyChanged
    {
        public int DegreeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public string ImageUrl { get; set; }

        public string FacebookUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}