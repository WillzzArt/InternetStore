using InternetStoreTestTask.Models.StorageModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternetStoreTestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(o => o.Products)
                .UsingEntity<Purchase>(
                    p => p
                        .HasOne(pur => pur.Order)
                        .WithMany(o => o.Purchases)
                        .HasForeignKey(pur => pur.OrderId),
                    p => p
                        .HasOne(pur => pur.Product)
                        .WithMany(pr => pr.Purchases)
                        .HasForeignKey(p2 => p2.ProductId),
                    p =>
                    {
                        p.Property(pur => pur.Count);
                        p.HasKey(pur => new { pur.ProductId, pur.OrderId });
                        p.ToTable("Purchase");
                    }
                );

        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
