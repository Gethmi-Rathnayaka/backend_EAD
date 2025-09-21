using Microsoft.EntityFrameworkCore;

namespace AutoServiceBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Add your tables here
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    // Example model classes
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
    }
}
