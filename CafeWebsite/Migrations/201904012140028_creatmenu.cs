namespace CafeWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatmenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.Menus",
    c => new
    {
        ID = c.Int(nullable: false, identity: true),
        FK_CatID = c.Int(nullable: false),
        Price = c.Double(nullable: false),
        PName = c.String(maxLength:200),
        Content = c.String(),
    })
    .PrimaryKey(t => t.ID)
    .ForeignKey("dbo.MenuCats", t => t.FK_CatID)
    .Index(t => t.FK_CatID);
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Menus", "FK_CatID", "dbo.MenuCats");
            DropTable("dbo.Menus");
        }
    }
}
