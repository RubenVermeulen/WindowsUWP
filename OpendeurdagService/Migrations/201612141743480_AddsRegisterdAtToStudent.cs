namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsRegisterdAtToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RegisterdAt", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "RegisterdAt");
        }
    }
}
