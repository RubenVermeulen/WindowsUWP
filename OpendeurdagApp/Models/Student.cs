using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OpendeurdagApp.Models
{
    public class Student: INotifyPropertyChanged
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Campus> Campuses { get; set; }

        public virtual ICollection<Degree> Degrees { get; set; }

        public DateTimeOffset RegisterdAt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}