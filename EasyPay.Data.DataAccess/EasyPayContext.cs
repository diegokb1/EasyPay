using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EasyPay.Data.Entities;

namespace EasyPay.Data.DataAccess
{
    public class EasyPayContext : DbContext
    {
        public DbSet<Field> Fields { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BillField> BillFields { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Admin).IsRequired();
            modelBuilder.Entity<User>().HasMany<Payment>(p => p.Payments).WithRequired(e => e.User).WillCascadeOnDelete();

            modelBuilder.Entity<Payment>().Property(p => p.PaymentDate).IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.DueAmount).IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.AmountGiven).IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.Change).IsRequired();
            modelBuilder.Entity<Payment>().HasRequired<User>(p => p.User);
            modelBuilder.Entity<Payment>().HasRequired<PaymentMethod>(p => p.PaymentMethod);
            modelBuilder.Entity<Payment>().HasMany<Bill>(f => f.Bills).WithRequired(e => e.Payment).WillCascadeOnDelete();

            modelBuilder.Entity<PaymentMethod>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<PaymentMethod>().HasMany<Payment>(p => p.Payments).WithRequired(e => e.PaymentMethod).WillCascadeOnDelete();

            modelBuilder.Entity<Bill>().Property(p => p.Amount).IsRequired();
            modelBuilder.Entity<Bill>().HasRequired<Supplier>(p => p.Supplier);
            modelBuilder.Entity<Bill>().HasRequired<Payment>(p => p.Payment);
            modelBuilder.Entity<Bill>().HasRequired<BillField>(p => p.BillField);

            modelBuilder.Entity<Supplier>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.CommisionPercentage).IsRequired();
            modelBuilder.Entity<Supplier>().HasMany<Bill>(f => f.Bills).WithRequired(e => e.Supplier).WillCascadeOnDelete();
            modelBuilder.Entity<Supplier>().HasMany<Field>(a => a.Fields).WithRequired(e => e.Supplier).WillCascadeOnDelete();

            modelBuilder.Entity<Field>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Field>().HasRequired<Supplier>(p => p.Supplier);
            modelBuilder.Entity<Field>().HasRequired<FieldType>(p => p.FieldType);
            modelBuilder.Entity<Field>().HasRequired<BillField>(p => p.BillField);

            modelBuilder.Entity<FieldType>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<FieldType>().HasMany<Field>(a => a.Fields).WithRequired(e => e.FieldType).WillCascadeOnDelete();

            modelBuilder.Entity<BillField>().Property(p => p.Value).IsRequired();
            modelBuilder.Entity<BillField>().HasMany<Bill>(f => f.Bills).WithRequired(e => e.BillField).WillCascadeOnDelete();
            modelBuilder.Entity<BillField>().HasMany<Field>(a => a.Fields).WithRequired(e => e.BillField).WillCascadeOnDelete();

        }

    }
}
