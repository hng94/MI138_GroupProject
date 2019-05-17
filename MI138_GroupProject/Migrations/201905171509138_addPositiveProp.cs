namespace MI138_GroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPositiveProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Positive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Positive");
        }
    }
}
