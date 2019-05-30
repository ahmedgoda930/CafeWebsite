namespace CafeWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateblog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "date");
        }
    }
}
