using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Models
{
    public class NewsItem
    {
        public int NewsItemId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTimeOffset PublishedAtDate { get; set; }

        public TimeSpan PublishedAtTime { get; set; }

        public virtual ICollection<Campus> Campuses { get; set; }

        public virtual ICollection<Degree> Degrees { get; set; }
    }
}
