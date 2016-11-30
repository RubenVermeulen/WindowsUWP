namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsDatesToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "BeginDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "EndDate");
            DropColumn("dbo.Activities", "BeginDate");
        }
    }
}
