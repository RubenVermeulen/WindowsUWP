using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpendeurdagService.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public string FacebookUrl { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public string ImageUrl { get; set; }
    }
}