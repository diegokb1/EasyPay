namespace EasyPay.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntitiesRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "BillField_Id", "dbo.BillFields");
            DropForeignKey("dbo.Fields", "BillField_Id", "dbo.BillFields");
            DropForeignKey("dbo.Bills", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Bills", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Payments", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Fields", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Fields", "FieldType_Id", "dbo.FieldTypes");
            DropIndex("dbo.Bills", new[] { "BillField_Id" });
            DropIndex("dbo.Bills", new[] { "Payment_Id" });
            DropIndex("dbo.Bills", new[] { "Supplier_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.Fields", new[] { "BillField_Id" });
            DropIndex("dbo.Fields", new[] { "FieldType_Id" });
            DropIndex("dbo.Fields", new[] { "Supplier_Id" });
            AlterColumn("dbo.BillFields", "Value", c => c.String(nullable: false));
            AlterColumn("dbo.Bills", "BillField_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Bills", "Payment_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Bills", "Supplier_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "PaymentMethod_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PaymentMethods", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Fields", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Fields", "BillField_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Fields", "FieldType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Fields", "Supplier_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.FieldTypes", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Bills", "Payment_Id");
            CreateIndex("dbo.Bills", "Supplier_Id");
            CreateIndex("dbo.Bills", "BillField_Id");
            CreateIndex("dbo.Payments", "PaymentMethod_Id");
            CreateIndex("dbo.Payments", "User_Id");
            CreateIndex("dbo.Fields", "FieldType_Id");
            CreateIndex("dbo.Fields", "Supplier_Id");
            CreateIndex("dbo.Fields", "BillField_Id");
            AddForeignKey("dbo.Bills", "BillField_Id", "dbo.BillFields", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fields", "BillField_Id", "dbo.BillFields", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "Payment_Id", "dbo.Payments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "Supplier_Id", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "PaymentMethod_Id", "dbo.PaymentMethods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fields", "Supplier_Id", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fields", "FieldType_Id", "dbo.FieldTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fields", "FieldType_Id", "dbo.FieldTypes");
            DropForeignKey("dbo.Fields", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Payments", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Bills", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Bills", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Fields", "BillField_Id", "dbo.BillFields");
            DropForeignKey("dbo.Bills", "BillField_Id", "dbo.BillFields");
            DropIndex("dbo.Fields", new[] { "BillField_Id" });
            DropIndex("dbo.Fields", new[] { "Supplier_Id" });
            DropIndex("dbo.Fields", new[] { "FieldType_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Bills", new[] { "BillField_Id" });
            DropIndex("dbo.Bills", new[] { "Supplier_Id" });
            DropIndex("dbo.Bills", new[] { "Payment_Id" });
            AlterColumn("dbo.FieldTypes", "Description", c => c.String());
            AlterColumn("dbo.Fields", "Supplier_Id", c => c.Int());
            AlterColumn("dbo.Fields", "FieldType_Id", c => c.Int());
            AlterColumn("dbo.Fields", "BillField_Id", c => c.Int());
            AlterColumn("dbo.Fields", "Name", c => c.String());
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.PaymentMethods", "Name", c => c.String());
            AlterColumn("dbo.Payments", "User_Id", c => c.Int());
            AlterColumn("dbo.Payments", "PaymentMethod_Id", c => c.Int());
            AlterColumn("dbo.Bills", "Supplier_Id", c => c.Int());
            AlterColumn("dbo.Bills", "Payment_Id", c => c.Int());
            AlterColumn("dbo.Bills", "BillField_Id", c => c.Int());
            AlterColumn("dbo.BillFields", "Value", c => c.String());
            CreateIndex("dbo.Fields", "Supplier_Id");
            CreateIndex("dbo.Fields", "FieldType_Id");
            CreateIndex("dbo.Fields", "BillField_Id");
            CreateIndex("dbo.Payments", "User_Id");
            CreateIndex("dbo.Payments", "PaymentMethod_Id");
            CreateIndex("dbo.Bills", "Supplier_Id");
            CreateIndex("dbo.Bills", "Payment_Id");
            CreateIndex("dbo.Bills", "BillField_Id");
            AddForeignKey("dbo.Fields", "FieldType_Id", "dbo.FieldTypes", "Id");
            AddForeignKey("dbo.Fields", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.Payments", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Payments", "PaymentMethod_Id", "dbo.PaymentMethods", "Id");
            AddForeignKey("dbo.Bills", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.Bills", "Payment_Id", "dbo.Payments", "Id");
            AddForeignKey("dbo.Fields", "BillField_Id", "dbo.BillFields", "Id");
            AddForeignKey("dbo.Bills", "BillField_Id", "dbo.BillFields", "Id");
        }
    }
}
