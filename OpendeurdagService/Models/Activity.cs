using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace OpendeurdagService.Models
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

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}