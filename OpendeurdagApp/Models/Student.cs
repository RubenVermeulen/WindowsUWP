using System;
using System.Collections.Generic;
using System.Linq;

namespace OpendeurdagApp.Models
{
    public class Student
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
    }
}