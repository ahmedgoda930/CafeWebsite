namespace CafeWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateblogtitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Title", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Blogs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Name", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Blogs", "Title");
        }
    }
}
