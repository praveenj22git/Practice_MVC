namespace MVC_PRAC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer_Details",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CustomerPhone = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.ProductsIvies",
                c => new
                    {
                        Product_Id = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Product_Name = c.String(nullable: false),
                        Product_Price = c.Double(nullable: false),
                        Product_Manufacturing_date = c.DateTime(nullable: false),
                        Product_Expiry_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductsIvies");
            DropTable("dbo.Customer_Details");
        }
    }
}
