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
        Infomoment
    }

    public class Activity
    {
        public int ActivityId { get; set; }

        public ActivityType Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}