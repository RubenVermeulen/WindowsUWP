namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesDateTimeToDateTimeOffSetInActivity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "BeginDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Activities", "EndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Activities", "BeginDate", c => c.DateTime(nullable: false));
        }
    }
}
