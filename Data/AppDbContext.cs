using Microsoft.EntityFrameworkCore;
using backend_EAD.Models;

namespace AutoServiceBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Add your tables here
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            // Configure Post-User relationship
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            // Seed some test data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "john@example.com", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
                new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", CreatedAt = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc), IsActive = true }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, Stock = 10, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
                new Product { Id = 2, Name = "Mouse", Description = "Wireless mouse", Price = 29.99m, Stock = 50, CreatedAt = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc), IsActive = true }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Welcome Post", Content = "Welcome to our platform!", UserId = 1, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
                new Post { Id = 2, Title = "Getting Started", Content = "Here's how to get started...", UserId = 2, CreatedAt = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc), IsActive = true }
            );
        }
    }
}
