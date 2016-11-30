namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsLocationToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Location");
        }
    }
}
