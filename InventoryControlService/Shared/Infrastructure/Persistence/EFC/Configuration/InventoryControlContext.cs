using Microsoft.EntityFrameworkCore;
using InventoryControlService.Commerce.Domain.Model.Aggregates;
using InventoryControlService.Inventory.Domain.Model.Aggregates;

namespace InventoryControlService.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public partial class InventoryControlContext : DbContext
    {
        public InventoryControlContext() { }
        public InventoryControlContext
            (DbContextOptions<InventoryControlContext> options) :
            base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_order_id");

                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");
                entity.Property(e => e.ProductsId).HasColumnName("products_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");

                entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_products_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_product_id");

                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                OnModelCreatingPartial(modelBuilder);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}