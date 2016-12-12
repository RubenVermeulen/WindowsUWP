namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DegreeSmallDescriptionFacebookandImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Degrees", "SmallDescription", c => c.String());
            AddColumn("dbo.Degrees", "FacebookUrl", c => c.String());
            AddColumn("dbo.Degrees", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Degrees", "ImageUrl");
            DropColumn("dbo.Degrees", "FacebookUrl");
            DropColumn("dbo.Degrees", "SmallDescription");
        }
    }
}
