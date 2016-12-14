using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OpendeurdagApp.Models
{
    

    public class Activity
    {
        public int ActivityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Location { get; set; }

        public DateTimeOffset BeginDate { get; set; }

        public TimeSpan BeginTime { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public TimeSpan EndTime { get; set; }

        public virtual ICollection<Campus> Campuses { get; set; }

    }
}