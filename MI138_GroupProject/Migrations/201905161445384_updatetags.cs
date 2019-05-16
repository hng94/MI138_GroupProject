namespace MI138_GroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Game_ID", "dbo.Games");
            DropIndex("dbo.Tags", new[] { "Game_ID" });
            DropColumn("dbo.Games", "ScreenshotUrl");
            DropColumn("dbo.Tags", "Game_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Game_ID", c => c.Int());
            AddColumn("dbo.Games", "ScreenshotUrl", c => c.String());
            CreateIndex("dbo.Tags", "Game_ID");
            AddForeignKey("dbo.Tags", "Game_ID", "dbo.Games", "ID");
        }
    }
}
