namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsImageUrlToCampusModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campus", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campus", "ImageUrl");
        }
    }
}
