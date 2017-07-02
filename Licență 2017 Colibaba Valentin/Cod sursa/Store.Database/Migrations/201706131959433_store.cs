namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class store : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 100),
                        Password = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "EmailIndex");
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Ingredients = c.String(),
                        categoryName = c.String(),
                        Price = c.Double(nullable: false),
                        ImageUrl = c.String(maxLength: 2046),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Message = c.String(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Cart_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Order_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "Author_Id", "dbo.Customers");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.ProductCarts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Cart_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Product_Id" });
            DropIndex("dbo.ProductReviews", new[] { "Author_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", "EmailIndex");
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropTable("dbo.ProductOrders");
            DropTable("dbo.ProductCarts");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
        }
    }
}
