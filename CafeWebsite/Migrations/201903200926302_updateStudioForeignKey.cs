namespace CafeWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStudioForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Studios", "StudioCat_ID", "dbo.StudioCats");
            DropIndex("dbo.Studios", new[] { "StudioCat_ID" });
            DropColumn("dbo.Studios", "FK_CatID");
            RenameColumn(table: "dbo.Studios", name: "StudioCat_ID", newName: "FK_CatID");
            AlterColumn("dbo.Studios", "FK_CatID", c => c.Int(nullable: false));
            CreateIndex("dbo.Studios", "FK_CatID");
            AddForeignKey("dbo.Studios", "FK_CatID", "dbo.StudioCats", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Studios", "FK_CatID", "dbo.StudioCats");
            DropIndex("dbo.Studios", new[] { "FK_CatID" });
            AlterColumn("dbo.Studios", "FK_CatID", c => c.Int());
            RenameColumn(table: "dbo.Studios", name: "FK_CatID", newName: "StudioCat_ID");
            AddColumn("dbo.Studios", "FK_CatID", c => c.Int(nullable: false));
            CreateIndex("dbo.Studios", "StudioCat_ID");
            AddForeignKey("dbo.Studios", "StudioCat_ID", "dbo.StudioCats", "ID");
        }
    }
}
