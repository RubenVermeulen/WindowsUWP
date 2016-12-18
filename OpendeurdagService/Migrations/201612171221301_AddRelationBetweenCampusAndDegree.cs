namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenCampusAndDegree : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DegreeNewsItems", newName: "NewsItemDegrees");
            DropPrimaryKey("dbo.NewsItemDegrees");
            CreateTable(
                "dbo.DegreeCampus",
                c => new
                    {
                        Degree_DegreeId = c.Int(nullable: false),
                        Campus_CampusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Degree_DegreeId, t.Campus_CampusId })
                .ForeignKey("dbo.Degrees", t => t.Degree_DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Campus", t => t.Campus_CampusId, cascadeDelete: true)
                .Index(t => t.Degree_DegreeId)
                .Index(t => t.Campus_CampusId);
            
            AddPrimaryKey("dbo.NewsItemDegrees", new[] { "NewsItem_NewsItemId", "Degree_DegreeId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DegreeCampus", "Campus_CampusId", "dbo.Campus");
            DropForeignKey("dbo.DegreeCampus", "Degree_DegreeId", "dbo.Degrees");
            DropIndex("dbo.DegreeCampus", new[] { "Campus_CampusId" });
            DropIndex("dbo.DegreeCampus", new[] { "Degree_DegreeId" });
            DropPrimaryKey("dbo.NewsItemDegrees");
            DropTable("dbo.DegreeCampus");
            AddPrimaryKey("dbo.NewsItemDegrees", new[] { "Degree_DegreeId", "NewsItem_NewsItemId" });
            RenameTable(name: "dbo.NewsItemDegrees", newName: "DegreeNewsItems");
        }
    }
}
