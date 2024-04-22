using Microsoft.EntityFrameworkCore;
using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;
using sampleDotnetCoreApi.Infrastructure.DbContext.Models;

namespace sampleDotnetCoreApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Hero> heroes { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Customer> customers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(eb =>
            {
                eb.ToTable("order");
                eb.Property(b => b.Id).HasColumnName("id");
                eb.Property(b => b.CustomerId).HasColumnName("customer_id");
                eb.Property(b => b.CreatedDate).HasColumnName("created_date");
                eb.Property(b => b.TotalQty).HasColumnName("total_qty");
                eb.Property(b => b.TotalPrice).HasColumnName("total_price");

                eb.HasMany(e => e.OrderItems)
                    .WithOne(e => e.Order)
                    .HasForeignKey(e => e.OrderId)
                    .IsRequired(false);

                eb.HasOne(e => e.Customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.CustomerId);
            });

            modelBuilder.Entity<OrderItem>(eb => {
                eb.ToTable("order_item");
                eb.Property(b => b.Id).HasColumnName("id");
                eb.Property(b => b.ProductId).HasColumnName("product_id");
                eb.Property(b => b.OrderId).HasColumnName("order_id");
                eb.Property(b => b.Qty).HasColumnName("qty");

                eb.HasOne(e => e.Order)
                    .WithMany(e => e.OrderItems)
                    .IsRequired(false);
                
                eb.HasOne(e => e.Product)
                    .WithMany(e => e.orderItems)
                     .IsRequired(false);
            });

            modelBuilder.Entity<Product>(eb =>
            {
                eb.ToTable("product");
                eb.Property(b => b.Id).HasColumnName("id");
                eb.Property(b => b.Name).HasColumnName("name");
                eb.Property(b => b.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Customer>(eb =>
            {
                eb.ToTable("customer");
                eb.Property(b => b.Id).HasColumnName("id");
                eb.Property(b => b.Name).HasColumnName("name");
                eb.Property(b => b.LastName).HasColumnName("last_name");
            });
        }
    }
}