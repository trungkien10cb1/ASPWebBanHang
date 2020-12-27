namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopLapModel : DbContext
    {
        public ShopLapModel()
            : base("name=ShopLapModel1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.danhmucma)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.madathang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.ram)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.diacung)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.vga)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.manhinh)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.vixuly)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .HasOptional(e => e.Product)
                .WithRequired(e => e.ProductDetail)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.producttype);
        }
    }
}
