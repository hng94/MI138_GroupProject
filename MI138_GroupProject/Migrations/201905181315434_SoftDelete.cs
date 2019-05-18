namespace MI138_GroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Deleted");
        }
    }
}
