using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EShopApi.Models
{
    public partial class EShopApi_DbContext : DbContext
    {
        public EShopApi_DbContext()
        {
        }

        public EShopApi_DbContext(DbContextOptions<EShopApi_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SalesPerson> SalesPerson { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(150);

                entity.Property(e => e.State).HasMaxLength(150);

                entity.Property(e => e.ZipCode).HasMaxLength(150);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.Property(e => e.OrderItemId)
                    .HasColumnName("OrderItemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.OrderItem)
                    .WithOne(p => p.OrderItems)
                    .HasForeignKey<OrderItems>(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderItems_Products");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customer");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalesPersonId)
                    .HasConstraintName("FK_Orders_SalesPerson");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(150);

                entity.Property(e => e.Veienty).HasMaxLength(150);
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.HasKey(e => e.SalesPersonalid);

                entity.Property(e => e.PersonalAdress).HasMaxLength(150);

                entity.Property(e => e.PersonalCity).HasMaxLength(150);

                entity.Property(e => e.PersonalEmail).HasMaxLength(150);

                entity.Property(e => e.PersonalFirstName).HasMaxLength(150);

                entity.Property(e => e.PersonalLastName).HasMaxLength(150);

                entity.Property(e => e.PersonalPhone).HasMaxLength(150);

                entity.Property(e => e.PersonalState).HasMaxLength(150);

                entity.Property(e => e.PersonalZipCode).HasMaxLength(150);
            });
        }
    }
}
