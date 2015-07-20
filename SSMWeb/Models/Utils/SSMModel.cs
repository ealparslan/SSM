using SSMWeb.Models;
namespace DataLayerPrimitives
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SSMModel : DbContext
    {
        public SSMModel() : base("name=SSMConnection")
        {
        }

        public virtual DbSet<Barcode> Barcodes { get; set; }
        public virtual DbSet<Box> Boxes { get; set; }
        public virtual DbSet<COG> COGS { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DeliveryList> DeliveryLists { get; set; }
        public virtual DbSet<FulfilmentSKU> FulfilmentSKUs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<QuantityUnit> QuantityUnits { get; set; }
        public virtual DbSet<ShipmentList> ShipmentLists { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barcode>()
                .HasMany(e => e.Boxes)
                .WithRequired(e => e.Barcode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COG>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.COG)
                .HasForeignKey(e => e.COGSId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.DeliveryLists)
                .WithRequired(e => e.Delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FulfilmentSKU>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.FulfilmentSKU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Boxes)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderList>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrderList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Boxes)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductColor>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductColor)
                .HasForeignKey(e => e.ColorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Boxes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShipmentLists)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductSize>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductSize)
                .HasForeignKey(e => e.SizeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuantityUnit>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.QuantityUnit)
                .HasForeignKey(e => e.PartQtyUnitID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipment>()
                .HasMany(e => e.ShipmentLists)
                .WithRequired(e => e.Shipment)
                .WillCascadeOnDelete(false);
        }
    }
}
