﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpendeurdagService.Models
{
    public class Campus
    {
        public int CampusId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<NewsItem> NewsItems { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public virtual ICollection<Degree> Degrees { get; set; }
    }
}