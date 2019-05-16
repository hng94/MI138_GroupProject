namespace MI138_GroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        MyProperty = c.Int(nullable: false),
                        Review_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reviews", t => t.Review_ID)
                .Index(t => t.Review_ID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ScreenshotUrl = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                        Game_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Games", t => t.Game_ID)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Game_ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Game_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.Game_ID)
                .Index(t => t.Game_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Game_ID", "dbo.Games");
            DropForeignKey("dbo.Reviews", "Game_ID", "dbo.Games");
            DropForeignKey("dbo.Reviews", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Review_ID", "dbo.Reviews");
            DropForeignKey("dbo.Games", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tags", new[] { "Game_ID" });
            DropIndex("dbo.Reviews", new[] { "Game_ID" });
            DropIndex("dbo.Reviews", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Games", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Comments", new[] { "Review_ID" });
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Games");
            DropTable("dbo.Comments");
        }
    }
}
