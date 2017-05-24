namespace Redweb.BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatabaseModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Colour_Id = c.Int(),
                        Model_Id = c.Int(nullable: false),
                        Size_Id = c.Int(),
                        Subcategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Colours", t => t.Colour_Id)
                .ForeignKey("dbo.Models", t => t.Model_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.Size_Id)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Colour_Id)
                .Index(t => t.Model_Id)
                .Index(t => t.Size_Id)
                .Index(t => t.Subcategory_Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Products", "Size_Id", "dbo.Sizes");
            DropForeignKey("dbo.Products", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Products", "Colour_Id", "dbo.Colours");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Subcategory_Id" });
            DropIndex("dbo.Products", new[] { "Size_Id" });
            DropIndex("dbo.Products", new[] { "Model_Id" });
            DropIndex("dbo.Products", new[] { "Colour_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropTable("dbo.Subcategories");
            DropTable("dbo.Sizes");
            DropTable("dbo.Products");
            DropTable("dbo.Models");
            DropTable("dbo.Colours");
            DropTable("dbo.Categories");
        }
    }
}
