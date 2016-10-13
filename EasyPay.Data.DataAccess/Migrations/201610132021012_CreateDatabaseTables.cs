namespace EasyPay.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabaseTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        BillField_Id = c.Int(),
                        Payment_Id = c.Int(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillFields", t => t.BillField_Id)
                .ForeignKey("dbo.Payments", t => t.Payment_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.BillField_Id)
                .Index(t => t.Payment_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        DueAmount = c.Int(nullable: false),
                        AmountGiven = c.Int(nullable: false),
                        Change = c.Int(nullable: false),
                        PaymentMethod_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CommisionPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BillField_Id = c.Int(),
                        FieldType_Id = c.Int(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillFields", t => t.BillField_Id)
                .ForeignKey("dbo.FieldTypes", t => t.FieldType_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.BillField_Id)
                .Index(t => t.FieldType_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.FieldTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fields", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Fields", "FieldType_Id", "dbo.FieldTypes");
            DropForeignKey("dbo.Fields", "BillField_Id", "dbo.BillFields");
            DropForeignKey("dbo.Bills", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Payments", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Bills", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Bills", "BillField_Id", "dbo.BillFields");
            DropIndex("dbo.Fields", new[] { "Supplier_Id" });
            DropIndex("dbo.Fields", new[] { "FieldType_Id" });
            DropIndex("dbo.Fields", new[] { "BillField_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Bills", new[] { "Supplier_Id" });
            DropIndex("dbo.Bills", new[] { "Payment_Id" });
            DropIndex("dbo.Bills", new[] { "BillField_Id" });
            DropTable("dbo.FieldTypes");
            DropTable("dbo.Fields");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Users");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Payments");
            DropTable("dbo.Bills");
            DropTable("dbo.BillFields");
        }
    }
}
