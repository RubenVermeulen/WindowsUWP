using System;
using System.Collections.Generic;
using System.Linq;

namespace OpendeurdagClient.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}