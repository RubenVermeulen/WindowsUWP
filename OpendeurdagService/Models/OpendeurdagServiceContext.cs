using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpendeurdagService.Models
{
    public class OpendeurdagServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OpendeurdagServiceContext() : base("name=OpendeurdagServiceContext")
        {
        }

        public System.Data.Entity.DbSet<OpendeurdagService.Models.Campus> Campus { get; set; }

        public System.Data.Entity.DbSet<OpendeurdagService.Models.Degree> Degrees { get; set; }

        public System.Data.Entity.DbSet<OpendeurdagService.Models.Activity> Activities { get; set; }

        public System.Data.Entity.DbSet<OpendeurdagService.Models.Student> Students { get; set; }
    }
}
