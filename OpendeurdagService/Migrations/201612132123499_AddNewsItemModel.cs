namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsItemModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsItems",
                c => new
                    {
                        NewsItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishedAtDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PublishedAtTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.NewsItemId);
            
            AddColumn("dbo.Campus", "NewsItem_NewsItemId", c => c.Int());
            AddColumn("dbo.Degrees", "NewsItem_NewsItemId", c => c.Int());
            CreateIndex("dbo.Campus", "NewsItem_NewsItemId");
            CreateIndex("dbo.Degrees", "NewsItem_NewsItemId");
            AddForeignKey("dbo.Campus", "NewsItem_NewsItemId", "dbo.NewsItems", "NewsItemId");
            AddForeignKey("dbo.Degrees", "NewsItem_NewsItemId", "dbo.NewsItems", "NewsItemId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Degrees", "NewsItem_NewsItemId", "dbo.NewsItems");
            DropForeignKey("dbo.Campus", "NewsItem_NewsItemId", "dbo.NewsItems");
            DropIndex("dbo.Degrees", new[] { "NewsItem_NewsItemId" });
            DropIndex("dbo.Campus", new[] { "NewsItem_NewsItemId" });
            DropColumn("dbo.Degrees", "NewsItem_NewsItemId");
            DropColumn("dbo.Campus", "NewsItem_NewsItemId");
            DropTable("dbo.NewsItems");
        }
    }
}
