namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationActivitiesCampuses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampusActivities",
                c => new
                    {
                        Campus_CampusId = c.Int(nullable: false),
                        Activity_ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Campus_CampusId, t.Activity_ActivityId })
                .ForeignKey("dbo.Campus", t => t.Campus_CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityId, cascadeDelete: true)
                .Index(t => t.Campus_CampusId)
                .Index(t => t.Activity_ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampusActivities", "Activity_ActivityId", "dbo.Activities");
            DropForeignKey("dbo.CampusActivities", "Campus_CampusId", "dbo.Campus");
            DropIndex("dbo.CampusActivities", new[] { "Activity_ActivityId" });
            DropIndex("dbo.CampusActivities", new[] { "Campus_CampusId" });
            DropTable("dbo.CampusActivities");
        }
    }
}
