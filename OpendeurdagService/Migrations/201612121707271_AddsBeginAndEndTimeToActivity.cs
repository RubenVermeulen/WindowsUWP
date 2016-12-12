namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsBeginAndEndTimeToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "BeginTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Activities", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "EndTime");
            DropColumn("dbo.Activities", "BeginTime");
        }
    }
}
