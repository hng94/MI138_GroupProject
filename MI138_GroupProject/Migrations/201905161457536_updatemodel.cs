namespace MI138_GroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ScreenshotUrl", c => c.String());
            AddColumn("dbo.Games", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Tags");
            DropColumn("dbo.Games", "ScreenshotUrl");
        }
    }
}
