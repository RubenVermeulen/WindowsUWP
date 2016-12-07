using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OpendeurdagClient.Models
{
    public class Degree : INotifyPropertyChanged
    {
        public int DegreeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}