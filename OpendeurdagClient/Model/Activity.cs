using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OpendeurdagClient.Models
{
    public enum ActivityType
    {
        Opendeurdag,
        Infomoment,
        Extern
    }

    public class Activity
    {
        public int ActivityId { get; set; }

        public ActivityType Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }
    }
}