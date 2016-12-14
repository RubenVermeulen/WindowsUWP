namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCollectionNewsItemsInDegreeAndCampus : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DegreeStudents", newName: "StudentDegrees");
            DropForeignKey("dbo.Campus", "NewsItem_NewsItemId", "dbo.NewsItems");
            DropForeignKey("dbo.Degrees", "NewsItem_NewsItemId", "dbo.NewsItems");
            DropIndex("dbo.Campus", new[] { "NewsItem_NewsItemId" });
            DropIndex("dbo.Degrees", new[] { "NewsItem_NewsItemId" });
            DropPrimaryKey("dbo.StudentDegrees");
            CreateTable(
                "dbo.NewsItemCampus",
                c => new
                    {
                        NewsItem_NewsItemId = c.Int(nullable: false),
                        Campus_CampusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NewsItem_NewsItemId, t.Campus_CampusId })
                .ForeignKey("dbo.NewsItems", t => t.NewsItem_NewsItemId, cascadeDelete: true)
                .ForeignKey("dbo.Campus", t => t.Campus_CampusId, cascadeDelete: true)
                .Index(t => t.NewsItem_NewsItemId)
                .Index(t => t.Campus_CampusId);
            
            CreateTable(
                "dbo.DegreeNewsItems",
                c => new
                    {
                        Degree_DegreeId = c.Int(nullable: false),
                        NewsItem_NewsItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Degree_DegreeId, t.NewsItem_NewsItemId })
                .ForeignKey("dbo.Degrees", t => t.Degree_DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.NewsItems", t => t.NewsItem_NewsItemId, cascadeDelete: true)
                .Index(t => t.Degree_DegreeId)
                .Index(t => t.NewsItem_NewsItemId);
            
            AddPrimaryKey("dbo.StudentDegrees", new[] { "Student_StudentId", "Degree_DegreeId" });
            DropColumn("dbo.Campus", "NewsItem_NewsItemId");
            DropColumn("dbo.Degrees", "NewsItem_NewsItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Degrees", "NewsItem_NewsItemId", c => c.Int());
            AddColumn("dbo.Campus", "NewsItem_NewsItemId", c => c.Int());
            DropForeignKey("dbo.DegreeNewsItems", "NewsItem_NewsItemId", "dbo.NewsItems");
            DropForeignKey("dbo.DegreeNewsItems", "Degree_DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.NewsItemCampus", "Campus_CampusId", "dbo.Campus");
            DropForeignKey("dbo.NewsItemCampus", "NewsItem_NewsItemId", "dbo.NewsItems");
            DropIndex("dbo.DegreeNewsItems", new[] { "NewsItem_NewsItemId" });
            DropIndex("dbo.DegreeNewsItems", new[] { "Degree_DegreeId" });
            DropIndex("dbo.NewsItemCampus", new[] { "Campus_CampusId" });
            DropIndex("dbo.NewsItemCampus", new[] { "NewsItem_NewsItemId" });
            DropPrimaryKey("dbo.StudentDegrees");
            DropTable("dbo.DegreeNewsItems");
            DropTable("dbo.NewsItemCampus");
            AddPrimaryKey("dbo.StudentDegrees", new[] { "Degree_DegreeId", "Student_StudentId" });
            CreateIndex("dbo.Degrees", "NewsItem_NewsItemId");
            CreateIndex("dbo.Campus", "NewsItem_NewsItemId");
            AddForeignKey("dbo.Degrees", "NewsItem_NewsItemId", "dbo.NewsItems", "NewsItemId");
            AddForeignKey("dbo.Campus", "NewsItem_NewsItemId", "dbo.NewsItems", "NewsItemId");
            RenameTable(name: "dbo.StudentDegrees", newName: "DegreeStudents");
        }
    }
}
